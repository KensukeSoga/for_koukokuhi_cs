package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.common.model.Tbj12CampaignCondition;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailCondition;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報登録Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/11 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RdTime2AccountBookRegisterManager {

    /** シングルトンインスタンス */
    private static RdTime2AccountBookRegisterManager _manager = new RdTime2AccountBookRegisterManager();

    /** 営業作業台帳ラジオタイムインポート情報検索条件 */
    private FindRdTime2AccountBookCondition _cond = null;
    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 上期/下期 */
    private String _term = null;

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private RdTime2AccountBookRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static RdTime2AccountBookRegisterManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳ラジオタイムインポート情報登録
     * @param vo 営業作業台帳VO
     * @param cond 営業作業台帳ラジオタイムインポート情報検索条件
     * @throws HAMException
     */
    public void registerRdTimeInfo2AccountBook(List<Tbj02EigyoDaichoVO> vo, FindRdTime2AccountBookCondition cond) throws HAMException {

        //検索条件
        _cond = cond;

        //フェイズ
        _phase = _cond.getPhase();
        //期
        _term = DateUtil.getTerm(_cond.getYearMonth());

        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        AccountBookLogRegisterDAO accountBoolLogRegisterDao = AccountBookRegisterDAOFactory.createAccountBookLogRegisterDAO();

        MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
        CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();

        //更新対象の媒体状況管理NOリスト
        List<BigDecimal> planNoList = new ArrayList<BigDecimal>();

        for (Tbj02EigyoDaichoVO tb02vo : vo) {

            //営業作業台帳No最大値取得
            List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.selectMaxDaichoNo();

            //取得できない場合
            if (tbj02VoList.size() == 0) {
                throw new HAMException("登録","BJ-E0001");
            }

            String insDaichoNo = String.format("%015d", Long.valueOf(tbj02VoList.get(0).getDAICHONO()) + 1);
            tb02vo.setDAICHONO(insDaichoNo);

            //------------------------媒体状況管理データのための処理------------------------//
            //媒体状況管理情報取得
            List<Tbj01MediaPlanVO> tbj01VoList = getMediaPlan(tb02vo);

            //媒体状況管理VO
            //※関連テーブル更新用
            Tbj01MediaPlanVO tbj00NewVo = null;

            //取得できる場合
            if (tbj01VoList.size() != 0) {

                //営業作業台帳の媒体状況管理NOに取得した媒体状況管理NOを付与
                tb02vo.setMEDIAPLANNO(tbj01VoList.get(0).getMEDIAPLANNO());
                tbj00NewVo = tbj01VoList.get(0);
            } else {
                //取得できない場合

                //キャンペーン一覧データの取得
                List<Tbj12CampaignVO> tbj12VoList = getCampaign(tb02vo);

                //キャンペーン一覧VO
                //※関連テーブル更新用
                Tbj12CampaignVO tbj12NewVo = null;

                //------------------------キャンペーン一覧のための処理------------------------//
                //紐づくキャンペーンが取得できないとき
                if (tbj12VoList.size() != 0) {
                    //取得できる場合
                    tbj12NewVo = tbj12VoList.get(0);
                } else {
                    //取得できない場合

                    //ひとまず形だけのキャンペーン一覧を作成
                    //予算や実績の合計は媒体状況管理の更新時に行う
                    tbj12NewVo = createCampaignVO(tb02vo);

                    //キャンペーンデータを登録
                    campRegistDAO.insCampaignList(tbj12NewVo);
                }
                //------------------------キャンペーン一覧のための処理------------------------//

                //ひとまず形だけの媒体状況管理データを作成する
                //予算や実績の合計は、媒体状況管理の更新で一気に行う
                tbj00NewVo = createMediaPlanVO(tb02vo, tbj12NewVo);

                //媒体状況管理データを登録
                mediaRegisterDAO.insMediaPlan(tbj00NewVo);

                //営業作業台帳の媒体状況管理NOに作成した媒体状況管理NOを付与
                tb02vo.setMEDIAPLANNO(tbj00NewVo.getMEDIAPLANNO());
            }
            //------------------------媒体状況管理データのための処理------------------------//

            //営業作業台帳登録
            tbj02dao.insertVO(tb02vo);

            //【登録】で営業作業台帳ログ作成
            accountBoolLogRegisterDao.insAccountBookHistory(insDaichoNo, HAMConstants.HISTORYKBN_REGSTER);

            //更新対象の媒体状況管理NOリストから現在登録予定の媒体状況管理NOを取得
            int index = planNoList.indexOf(tb02vo.getMEDIAPLANNO());

            //見つからなかったら追加
            if (index == -1) {
                //更新対象の媒体状況管理リストに追加
                planNoList.add(tb02vo.getMEDIAPLANNO());
            }
        }

        //営業作業台帳より更新する他テーブルの更新
        for (BigDecimal planNo : planNoList) {

            CampaignRegisterDetailsDAO campDetailRegistDAO = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

            //更新対象の媒体状況管理データの取得
            Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
            tbj01cond.setMediaplanno(planNo);
            Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
            List<Tbj01MediaPlanVO> mediaplanvolist = tbj01dao.findMediaPlanByMediaPlanNo(tbj01cond);

            Tbj01MediaPlanVO tbj01vo = mediaplanvolist.get(0);

            //更新用の媒体状況管理データを作成
            tbj01vo = updateMediaPlanVO(tbj01vo, planNo);

            //媒体状況管理データを更新
            mediaRegisterDAO.updMediaPlan(tbj01vo);

            //更新対象のキャンペーン一覧データの取得
            Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> tbj12VoList = tbj12dao.findCampaignListByCampCd(tbj01vo.getCAMPCD());
            Tbj12CampaignVO tbj12vo = tbj12VoList.get(0);

            //更新用のキャンペーンVOを作成
            tbj12vo = updateCampaignVO(tbj12vo);

            //キャンペーンデータを更新
            campRegistDAO.updCampaignList(tbj12vo);

            Tbj13CampDetailCondition tbj13cond = new Tbj13CampDetailCondition();
            tbj13cond.setCampcd(tbj01vo.getCAMPCD());
            tbj13cond.setMediacd(tbj01vo.getMEDIACD());
            tbj13cond.setYoteiym(tbj01vo.getYOTEIYM());

            //更新対象のキャンペーン詳細データを一度削除しておく
            campDetailRegistDAO.delCampaignDetailsByCd(tbj13cond);

            Tbj13CampDetailVO tbj13vo = createCampDetailVO(tbj01vo);
            campDetailRegistDAO.insCampaignDetails(tbj13vo);
        }
    }

    /**
     * キャンペーン登録VO作成
     * (紐づくキャンペーンが見つからなかった場合のみ実施)
     * @param tbj02vo 営業作業台帳VO
     * @return キャンペーン一覧VO
     * @throws HAMException
     */
    private Tbj12CampaignVO createCampaignVO(Tbj02EigyoDaichoVO tbj02vo) throws HAMException {

        //キャンペーンコード最大値取得
        Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> tbj12VoList = tbj12dao.findMaxCampCd();

        //取得できない場合
        if (tbj12VoList.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj12CampaignVO tbj12vo = tbj12VoList.get(0);

        String maxCampNo = tbj12vo.getCAMPCD();
        maxCampNo =  maxCampNo.replace("CP", "");
        int No = Integer.parseInt(maxCampNo) + 1;

        //キャンペーンコード
        tbj12vo.setCAMPCD("CP" + String.format("%1$05d", No));

        //電通車種コード
        tbj12vo.setDCARCD(tbj02vo.getDCARCD());
        //フェイズ
        tbj12vo.setPHASE(_phase);

        //予定期間開始、予定期間終了
        Calendar calendar = Calendar.getInstance();

        //期初日
        String termStartDate = DateUtil.getTermBegin(_cond.getYearMonth().replace("/", "") + "01") + "01";
        Date fromDate = DateUtil.toDate(termStartDate);

        //下期の場合
        if (_term.equals(HAMConstants.TERM_SECOND)) {
            calendar.setTime(fromDate);
            calendar.add(Calendar.MONTH, 6);
            fromDate = calendar.getTime();
        }

        //期末日
        calendar.setTime(fromDate);
        calendar.add(Calendar.MONTH, 6);
        calendar.add(Calendar.DAY_OF_MONTH, -1);

        //予定期間開始
        tbj12vo.setKIKANFROM(fromDate);
        //予定期間終了
        tbj12vo.setKIKANTO(calendar.getTime());

        //キャンペーン名
        //「<車種名>XX期<上/下>期キャンペーン」
        tbj12vo.setCAMPNM(tbj02vo.getDCARCD() + " " +_phase + "期" + _term + "期キャンペーン");
        //期初予定金額
        tbj12vo.setFSTBUDGET(BigDecimal.valueOf(0));    //期初予算なので0
        //予算金額
        tbj12vo.setBUDGET(tbj02vo.getGROSS());
        //予算金額(新)
        tbj12vo.setBUDGETHM(tbj02vo.getHMCOST());
        //実施金額
        tbj12vo.setACTUAL(tbj02vo.getGROSS());
        //実施金額(新)
        tbj12vo.setACTUALHM(tbj02vo.getHMCOST());
        //備考
        tbj12vo.setMEMO("");
        //媒体作成済フラグ
        tbj12vo.setBAITAIFLG("1");  //作成済
        //データ作成者
        tbj12vo.setCRTNM(tbj02vo.getCRTNM()); //作成者
        //作成プログラム
        tbj12vo.setCRTAPL(tbj02vo.getCRTAPL());
        //作成担当者ID
        tbj12vo.setCRTID(tbj02vo.getCRTID());
        //データ更新者
        tbj12vo.setUPDNM(tbj02vo.getUPDNM());
        //更新プログラム
        tbj12vo.setUPDAPL(tbj02vo.getUPDAPL());
        //更新担当者ID
        tbj12vo.setUPDID(tbj02vo.getUPDID());

        return tbj12vo;
    }

    /**
     * 媒体状況管理登録VO作成
     * (紐づく媒体状況管理NOが見つからなかった場合のみ実施)
     * @param tbj02vo 営業作業台帳VO
     * @param tbj12vo キャンペーンVO
     * @return 媒体状況管理VO
     * @throws HAMException
     */
    private Tbj01MediaPlanVO createMediaPlanVO(Tbj02EigyoDaichoVO tbj02vo, Tbj12CampaignVO tbj12vo) throws HAMException {

        //媒体管理No最大値取得
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> tbj01VoList = tbj01dao.findMediaPlanMaxCd();

        //取得できない場合
        if (tbj01VoList.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj01MediaPlanVO tbj01vo = tbj01VoList.get(0);

        //当月最終日取得
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(tbj02vo.getKIKANFROM());

        //月初日
        calendar.set(Calendar.DATE, 1);
        //月末日
        calendar.set(Calendar.DATE, calendar.getActualMaximum(Calendar.DATE));

        //キャンペーンコード
        tbj01vo.setCAMPCD(tbj12vo.getCAMPCD());
        //媒体管理No
        tbj01vo.setMEDIAPLANNO(tbj01vo.getMEDIAPLANNO().add(BigDecimal.valueOf(1)));
        //出稿予定年月
        tbj01vo.setYOTEIYM(DateUtil.toDate(_cond.getYearMonth().replace("/", "") + "01"));
        //系列コード
        tbj01vo.setKEIRESTUCD(tbj02vo.getKEIRETSUCD());
        //電通車種コード
        tbj01vo.setDCARCD(tbj02vo.getDCARCD());
        //媒体コード
        tbj01vo.setMEDIACD(tbj02vo.getMEDIACD());
        //費用計画No
        tbj01vo.setHIYOUNO(tbj02vo.getHIYOUNO());
        //代理店名
        tbj01vo.setAGENCY("電通");
        //広告件名
        tbj01vo.setKENMEI(tbj12vo.getCAMPNM());
        //特記事項
        tbj01vo.setMEMO("");
        //フェイズ
        tbj01vo.setPHASE(_phase);
        //期
        if (_term.equals(HAMConstants.TERM_FIRST)) {
            tbj01vo.setTERM(HAMConstants.TERM_STR_FIRST);   //上期
        } else {
            tbj01vo.setTERM(HAMConstants.TERM_STR_SECOND);  //下期
        }
        //予定期間開始
        tbj01vo.setKIKANFROM(tbj01vo.getYOTEIYM()); //YYYY/MM/01
        //予定期間終了
        tbj01vo.setKIKANTO(calendar.getTime()); //YYYY/MM/最終日
        //ＨＭ承認
        tbj01vo.setHMOK("0");   //"0"固定
        //媒体発注
        tbj01vo.setBUYEROK("0");    //"0"固定
        //予算金額
        tbj01vo.setBUDGET(tbj02vo.getGROSS());
        //予算金額(新)
        tbj01vo.setBUDGETHM(tbj02vo.getHMCOST());
        //実施金額
        tbj01vo.setACTUAL(tbj02vo.getGROSS());
        //実施金額(新)
        tbj01vo.setACTUALHM(tbj02vo.getHMCOST());
        //調整金額
        tbj01vo.setADJUSTMENT(BigDecimal.valueOf(0));
        //予実差額
        tbj01vo.setDIFAMT(BigDecimal.valueOf(0));
        //予実差額(新)
        tbj01vo.setDIFAMTHM(BigDecimal.valueOf(0));
        //予算登録フラグ
        tbj01vo.setBUDGETUPDFLG("1");   //営業作業台帳
        //データ作成者
        tbj01vo.setCRTNM(tbj02vo.getCRTNM());
        //作成プログラム
        tbj01vo.setCRTAPL(tbj02vo.getCRTAPL());
        //作成担当者ID
        tbj01vo.setCRTID(tbj02vo.getCRTID());
        //データ更新者
        tbj01vo.setUPDNM(tbj02vo.getUPDNM());
        //更新プログラム
        tbj01vo.setUPDAPL(tbj02vo.getUPDAPL());
        //更新担当者ID
        tbj01vo.setUPDID(tbj02vo.getUPDID());

        return tbj01vo;
    }

    /**
     * 媒体状況管理データ更新VO作成
     * (紐づく媒体状況管理NO存在時のみ実施)
     * @param tbj01vo 媒体状況管理VO
     * @param planNo bai取得した営業台帳VO
     * @return 更新用媒体状況管理データ
     * @throws HAMException
     */
    private Tbj01MediaPlanVO updateMediaPlanVO(Tbj01MediaPlanVO tbj01vo, BigDecimal planNo) throws HAMException {

        //営業作業台帳から、紐づく媒体状況管理NOに対する、HMコストとGROSS料金の合計を取得
        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.FindEigyoDaichoFeeSUM(planNo.toString());

        //取得できない場合
        if (tbj02VoList.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        //予算金額
        tbj01vo.setBUDGET(tbj02VoList.get(0).getGROSS());
        //予算金額(新)
        tbj01vo.setBUDGETHM(tbj02VoList.get(0).getHMCOST());
        //実施金額
        tbj01vo.setACTUAL(tbj02VoList.get(0).getGROSS());
        //実施金額(新)
        tbj01vo.setACTUALHM(tbj02VoList.get(0).getHMCOST());
        //予実差額
        tbj01vo.setDIFAMT(tbj01vo.getBUDGET().subtract(tbj01vo.getACTUAL())); //0
        //予実差額(新)
        tbj01vo.setDIFAMTHM(tbj01vo.getBUDGETHM().subtract(tbj01vo.getACTUALHM())); //0

        return tbj01vo;
    }

    /**
     * キャンペーンデータ更新用VO作成
     * (紐づくキャンペーンデータが存在時のみ実施）
     * @param tbj12vo キャンペーンVO
     * @return 更新用VO
     * @throws HAMException
     */
    private Tbj12CampaignVO updateCampaignVO(Tbj12CampaignVO tbj12vo) throws HAMException {

        //対象のキャンペーンコードを持つ媒体状況管理データの合計を取得
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> tbj01VoList = tbj01dao.findMediaPlanByCampCdSUM(tbj12vo.getCAMPCD());

        //取得できない場合
        if (tbj01VoList.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        //予算金額、実施金額
        tbj12vo.setACTUAL(tbj01VoList.get(0).getACTUAL());
        tbj12vo.setACTUALHM(tbj01VoList.get(0).getACTUALHM());
        tbj12vo.setBUDGET(tbj01VoList.get(0).getBUDGET());
        tbj12vo.setBUDGETHM(tbj01VoList.get(0).getBUDGETHM());

        return tbj12vo;
    }

    /**
     * 登録用キャンペーン詳細データを作成
     * (Delete/Insertを行うため、毎回作成)
     * @param tbj01vo 媒体状況管理VO
     * @return キャンペーン明細VO
     * @throws HAMException
     */
    private Tbj13CampDetailVO createCampDetailVO(Tbj01MediaPlanVO tbj01vo) throws HAMException {

        Tbj13CampDetailVO tbj13vo = new Tbj13CampDetailVO();

        //期間とキャンペーンコードで検索し、見つかったデータの合計値を取得
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
        tbj01cond.setCampcd(tbj01vo.getCAMPCD());
        tbj01cond.setYoteiym(tbj01vo.getYOTEIYM());
        tbj01cond.setMediacd(tbj01vo.getMEDIACD());
        List<Tbj01MediaPlanVO> mediavolist = tbj01dao.findMediaPlanSUMByCdAndMonth(tbj01cond);

        //取得できない場合
        if (mediavolist.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj01MediaPlanVO tbj01SumVo = mediavolist.get(0);

        //キャンペーンコード
        tbj13vo.setCAMPCD(tbj01vo.getCAMPCD());
        //電通車種コード
        tbj13vo.setDCARCD(tbj01vo.getDCARCD());
        //媒体コード
        tbj13vo.setMEDIACD(tbj01vo.getMEDIACD());
        //フェイズ
        tbj13vo.setPHASE(tbj01vo.getPHASE());
        //出稿予定年月
        tbj13vo.setYOTEIYM(tbj01vo.getYOTEIYM());
        //予定期間開始
        tbj13vo.setKIKANFROM(tbj01vo.getKIKANFROM());
        //予定期間終了
        tbj13vo.setKIKANTO(tbj01vo.getKIKANTO());
        //予算金額
        tbj13vo.setBUDGET(tbj01SumVo.getBUDGET());
        //予算金額(新)
        tbj13vo.setBUDGETHM(tbj01SumVo.getBUDGETHM());
        //データ作成者
        tbj13vo.setCRTNM(tbj01vo.getCRTNM());
        //作成プログラム
        tbj13vo.setCRTAPL(tbj01vo.getCRTAPL());
        //作成担当者ID
        tbj13vo.setCRTID(tbj01vo.getCRTID());
        //データ更新者
        tbj13vo.setUPDNM(tbj01vo.getUPDNM());
        //更新プログラム
        tbj13vo.setUPDAPL(tbj01vo.getUPDAPL());
        //更新担当者ID
        tbj13vo.setUPDID(tbj01vo.getUPDID());

        return tbj13vo;
    }

    /**
     * 登録する営業作業台帳データに紐づけるキャンペーンを取得
     * @param vo 営業作業台帳VO
     * @return キャンペーンVO
     * @throws HAMException
     */
    private List<Tbj12CampaignVO> getCampaign(Tbj02EigyoDaichoVO vo) throws HAMException {

        Tbj12CampaignCondition tbj12cond = new Tbj12CampaignCondition();
        Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        tbj12cond.setDcarcd(vo.getDCARCD());
        tbj12cond.setPhase(_phase);
        tbj12cond.setKikanfrom(vo.getKIKANFROM());
        tbj12cond.setKikanto(vo.getKIKANTO());
        return tbj12dao.findCampaignCd(tbj12cond);
    }

    /**
     * 登録する営業作業台帳データに紐づける媒体状況管理データを取得
     * @param vo 営業作業台帳VO
     * @return 媒体状況管理VO
     * @throws HAMException
     */
    private List<Tbj01MediaPlanVO> getMediaPlan(Tbj02EigyoDaichoVO vo) throws HAMException {

        Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        tbj01cond.setDcarcd(vo.getDCARCD());
        tbj01cond.setMediacd(vo.getMEDIACD());
        tbj01cond.setPhase(_phase);
        tbj01cond.setTerm(_term);
        tbj01cond.setKikanfrom(vo.getKIKANFROM());
        tbj01cond.setKikanto(vo.getKIKANTO());
        return tbj01dao.findMediaPlanNo(tbj01cond);
    }

}
