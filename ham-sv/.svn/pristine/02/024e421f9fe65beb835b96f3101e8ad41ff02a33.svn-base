package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
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

public class TVTImportRegisterManager {

    //private TVTImportRegisterVO _vo;

    /** シングルトンインスタンス */
    private static TVTImportRegisterManager _manager = new TVTImportRegisterManager();

    /** フェイズ */
    private BigDecimal _phase;

    /** フェイズ基準年 */
    private int _standerdYear;

    /** 上or下期 */
    private String _term = null;

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private TVTImportRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static TVTImportRegisterManager getInstance() {
        return _manager;
    }

    /**
     * インポートデータを営業作業台帳に登録します
     * @param vo
     * @throws HAMException
     * @throws ParseException
     */
    public void TVTImport(TVTImportRegisterVO vo) throws HAMException {

        TVTImportRegisterDAO tvtdao = TVTImportRegisterDAOFactory.createTVTImportRegisterDAO();
        AccountBookLogRegisterDAO inslogdao = AccountBookRegisterDAOFactory.createAccountBookLogRegisterDAO();
        //_vo = vo;

        //更新対象の媒体状況管理NOリスト
        List<BigDecimal> plannolist = new ArrayList<BigDecimal>();

        //画面表示と無関係であるため、排他チェックは行わない
        //exclusionCheck();

        //登録処理を行う前に、媒体状況管理Noを持つ営業台帳データを消しておく
        for (Tbj02EigyoDaichoVO insvo : vo.getInsVo()) {
            if (insvo.getMEDIAPLANNO() != null) {
                tvtdao.delAccountBook(insvo.getMEDIAPLANNO());
                tvtdao.delAccountBookLog(insvo.getMEDIAPLANNO());
            }
        }

        for (Tbj02EigyoDaichoVO insvo : vo.getInsVo()) {
            getPhaseInfo(insvo);
            List<Mbj09HiyouVO> hiyoresult = getInsertHiyou(insvo);
            //営業作業台帳Noの最大値を取得します.
            Tbj02EigyoDaichoDAO eddao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
            List<Tbj02EigyoDaichoVO> edresult = eddao.selectMaxDaichoNo();
            if (edresult.size() == 0) {
                throw new HAMException("登録","BJ-E0001");
            }
            String maxDaichoNo = edresult.get(0).getDAICHONO();
            long count = Long.valueOf(maxDaichoNo)+1;
            String insDaichoNo = String.format("%015d", count);
            //0埋め
            insvo.setDAICHONO(insDaichoNo);

            //費用計画NOと企画NOのセット
            if (hiyoresult.isEmpty())
            {
                insvo.setHIYOUNO(null);
                insvo.setKIKAKUNO(null);
            }
            else
            {
                insvo.setHIYOUNO(hiyoresult.get(0).getHIYOUNO());
                insvo.setKIKAKUNO(hiyoresult.get(0).getKIKAKUNO());
            }

            //対象VOに媒体管理Noが無い時は、媒体管理Noの最大値+1をくっつける
            if (insvo.getMEDIAPLANNO() == null) {

                //------------------------媒体状況管理データのための処理------------------------//
                //媒体状況管理データの取得
                List<Tbj01MediaPlanVO> mediaplanvolist = getMediaPlan(insvo);
                Tbj01MediaPlanVO mediaplanvo = null;

                if (mediaplanvolist.size() == 0) {
                    //キャンペーン一覧データの取得
                    List<Tbj12CampaignVO> campvolist = getCampaign(insvo);

                    Tbj12CampaignVO campvo = null;


                    //------------------------キャンペーン一覧のための処理------------------------//
                    //紐づくキャンペーンが取得できないとき
                    if (campvolist.size() == 0) {

                        //ひとまず形だけのキャンペーン一覧を作成する
                        //予算や実績の合計は、媒体状況管理の更新時に行う
                        campvo = createCampaignVO(insvo);

                        //キャンペーンデータを登録
                        CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
                        campRegistDAO.insCampaignList(campvo);
                    } else {
                        campvo = campvolist.get(0);
                    }

                    //------------------------キャンペーン一覧のための処理------------------------//

                    //ひとまず形だけの媒体状況管理データを作成する
                    //予算や実績の合計は、媒体状況管理の更新で一気に行う
                    mediaplanvo = createMediaPlanVO(insvo,campvo);

                    //媒体状況管理データを登録
                    MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
                    mediaRegisterDAO.insMediaPlan(mediaplanvo);

                    //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                    insvo.setMEDIAPLANNO(mediaplanvo.getMEDIAPLANNO());

                } else {
                    //取得できるとき
                    //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                    insvo.setMEDIAPLANNO(mediaplanvolist.get(0).getMEDIAPLANNO());
                    mediaplanvo = mediaplanvolist.get(0);
                }
                //------------------------媒体状況管理データのための処理------------------------//
            }

            tvtdao.insAccounBook(insvo);
            inslogdao.insAccountBookHistory(insDaichoNo,"登録");

            //更新対象の媒体状況管理NOリストから、現在登録予定の媒体状況管理NOを取得
            int index = plannolist.indexOf(insvo.getMEDIAPLANNO());

            //見つからなかったら追加
            if (index == -1) {
                //更新対象の媒体状況管理リストに追加
                plannolist.add(insvo.getMEDIAPLANNO());
            }
        }

        //営業作業台帳より更新する他テーブルの更新
        for (BigDecimal mediaplanno : plannolist) {

            MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
            CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
            CampaignRegisterDetailsDAO campDetailRegistDAO = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

            //更新対象の媒体状況管理データの取得
            Tbj01MediaPlanCondition mediacond = new Tbj01MediaPlanCondition();
            mediacond.setMediaplanno(mediaplanno);
            Tbj01MediaPlanDAO mediaplandao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
            List<Tbj01MediaPlanVO> mediaplanvolist = mediaplandao.findMediaPlanByMediaPlanNo(mediacond);

            Tbj01MediaPlanVO mediaplanvo = mediaplanvolist.get(0);

            //更新用の媒体状況管理データを作成
            mediaplanvo = updateMediaPlanVO(mediaplanvo,mediaplanno);

            //媒体状況管理データを更新
            mediaRegisterDAO.updMediaPlan(mediaplanvo);

            //更新対象のキャンペーン一覧データの取得
            Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> campvolist = campdao.findCampaignListByCampCd(mediaplanvo.getCAMPCD());
            Tbj12CampaignVO campvo = campvolist.get(0);

            //更新用のキャンペーンVOを作成
            campvo = updateCampaignVO(mediaplanvo,campvo);

            //キャンペーンデータを更新
            campRegistDAO.updCampaignList(campvo);

            Tbj13CampDetailCondition campcond = new Tbj13CampDetailCondition();
            campcond.setCampcd(mediaplanvo.getCAMPCD());
            campcond.setMediacd(mediaplanvo.getMEDIACD());
            campcond.setYoteiym(mediaplanvo.getYOTEIYM());

            //更新対象のキャンペーン詳細データを一度削除しておく
            campDetailRegistDAO.delCampaignDetailsByCd(campcond);

            Tbj13CampDetailVO campdetailvo = createCampDetailVO(mediaplanvo);
            campDetailRegistDAO.insCampaignDetails(campdetailvo);
        }
    }

    /**
     * 媒体状況管理データを更新する為のVOを作成
     * （紐づく媒体状況管理NOが見つかった場合のみ実施）
     * @param mediavo 取得した媒体状況管理VO
     * @param eigyovo 取得した営業台帳VO
     * @return 更新用媒体状況管理データ
     * @throws HAMException
     */
    private Tbj01MediaPlanVO updateMediaPlanVO(Tbj01MediaPlanVO mediavo,BigDecimal mediaplanno) throws HAMException {

        //営業作業台帳から、紐づく媒体状況管理NOに対する、HMコストとGROSS料金の合計を取得
        Tbj02EigyoDaichoDAO daichodao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        List<Tbj02EigyoDaichoVO> sumvo = daichodao.FindEigyoDaichoFeeSUM(mediaplanno.toString());
        if (sumvo.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        mediavo.setACTUAL(sumvo.get(0).getGROSS()); //実施金額（GROSS）
        mediavo.setACTUALHM(sumvo.get(0).getHMCOST()); //実施金額（HM）

        //予算登録フラグが1(媒体状況管理画面で手入力した場合以外)の時のみ、予算を更新
        //その場合は予算と実績を同じにしちゃう
        if (mediavo.getBUDGETUPDFLG().equals("1")) {
            mediavo.setBUDGET(sumvo.get(0).getGROSS());
            mediavo.setBUDGETHM(sumvo.get(0).getHMCOST());
        }
        mediavo.setDIFAMT(mediavo.getBUDGET().subtract(mediavo.getACTUAL())); //予実差額（GROSS）
        mediavo.setDIFAMTHM(mediavo.getBUDGETHM().subtract(mediavo.getACTUALHM())); //予実差額（HM）
        return mediavo;
    }

    /**
     * 媒体状況管理データを登録する為のVOを作成
     * （紐づく媒体状況管理NOが見つからなかった場合のみ実施）
     * @param eigyovo
     * @param campvo
     * @return
     * @throws HAMException
     */
    private Tbj01MediaPlanVO createMediaPlanVO(Tbj02EigyoDaichoVO eigyovo,Tbj12CampaignVO campvo) throws HAMException {

        //媒体状況管理の最大媒体状況管理NOを取得
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanMaxCd();
        if (mediavolist.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj01MediaPlanVO mediavo = mediavolist.get(0);

        //期間をXX月1日～XX月最終日とするために、月の最終日とかを取得
        Calendar cal = Calendar.getInstance();
        cal.setTime(eigyovo.getKIKANFROM());
        int maxdate = cal.getActualMaximum(Calendar.DATE);

        cal.set(Calendar.DATE, 1);
        Date fromDt = cal.getTime();

        cal.set(Calendar.DATE, maxdate);
        Date toDt = cal.getTime();

        //件名の作成
        //（車種名）XX期（上or下）期キャンペーン
        String kenmei = campvo.getCAMPNM();

        //キャンペーンコードは取得or作成したキャンペーンコードを入れる
        mediavo.setCAMPCD(campvo.getCAMPCD());

        //MAX媒体状況管理NO+1を入れる
        mediavo.setMEDIAPLANNO(mediavo.getMEDIAPLANNO().add(BigDecimal.valueOf(1)));

        //予定年月は営業作業台帳の期間開始の月の初日を入れる
        mediavo.setYOTEIYM(fromDt);

        mediavo.setKEIRESTUCD(eigyovo.getKEIRETSUCD()); //系列コードは営業作業台帳より取得
        mediavo.setDCARCD(eigyovo.getDCARCD()); //車種コードは営業作業台帳より取得
        mediavo.setMEDIACD(eigyovo.getMEDIACD()); //媒体コードは営業作業台帳より取得
        mediavo.setHIYOUNO(eigyovo.getHIYOUNO()); //費用計画Noは営業作業台帳より取得

        //広告代理店名は電通固定
        mediavo.setAGENCY("電通");

        mediavo.setKENMEI(kenmei); //作成した件名

        mediavo.setMEMO(""); //メモはとりあえずなし

        mediavo.setPHASE(_phase); //取得したフェーズを入力

        mediavo.setTERM(_term); //取得した上・下期を入れる

        mediavo.setKIKANFROM(fromDt); //期間開始はYYYY/MM/01

        mediavo.setKIKANTO(toDt); //期間終了はYYYY/MM/最終日

        mediavo.setHMOK("0"); //0固定でいいはず

        mediavo.setBUYEROK("0"); //0固定でいいはず

        //予算と実績を同じにしておく
        mediavo.setBUDGET(eigyovo.getGROSS());
        mediavo.setBUDGETHM(eigyovo.getHMCOST());
        mediavo.setACTUAL(eigyovo.getGROSS());
        mediavo.setACTUALHM(eigyovo.getHMCOST());

        //差額は調整金額は0
        mediavo.setADJUSTMENT(BigDecimal.valueOf(0));
        mediavo.setDIFAMT(BigDecimal.valueOf(0));
        mediavo.setDIFAMTHM(BigDecimal.valueOf(0));

        //営業作業台帳からの更新なので、フラグは1
        mediavo.setBUDGETUPDFLG("1");

        //作成者とかのデータも全て営業作業台帳と同じにしておく
        mediavo.setCRTNM(eigyovo.getCRTNM());
        mediavo.setCRTID(eigyovo.getCRTID());
        mediavo.setCRTAPL(eigyovo.getCRTAPL());
        mediavo.setUPDNM(eigyovo.getUPDNM());
        mediavo.setUPDAPL(eigyovo.getUPDAPL());
        mediavo.setUPDID(eigyovo.getUPDID());

        return mediavo;
    }

    /**
     * キャンペーンデータ更新用VOの作成
     * （紐づくキャンペーンデータが見つかった場合のみ実施）
     * @param mediavo 媒体管理VO
     * @param campvo キャンペーンVO
     * @return 更新用VO
     * @throws HAMException
     */
    private Tbj12CampaignVO updateCampaignVO(Tbj01MediaPlanVO mediavo,Tbj12CampaignVO campvo) throws HAMException {

        //対象のキャンペーンコードを持つ媒体状況管理データの合計を取得
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanByCampCdSUM(campvo.getCAMPCD());
        if (mediavolist.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj01MediaPlanVO summediavo = mediavolist.get(0);

        //予算と実績をvoに入れる
        campvo.setACTUAL(summediavo.getACTUAL());
        campvo.setACTUALHM(summediavo.getACTUALHM());
        campvo.setBUDGET(summediavo.getBUDGET());
        campvo.setBUDGETHM(summediavo.getBUDGETHM());

        return campvo;
    }

    /**
     * キャンペーンデータ登録用のVOの作成
     * （紐づくキャンペーンデータが見つからなかった場合のみ実施）
     * @param eigyovo
     * @return
     * @throws HAMException
     */
    private Tbj12CampaignVO createCampaignVO(Tbj02EigyoDaichoVO eigyovo) throws HAMException {

        //キャンペーンコードの最大値を取得します
        Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> campvolist = campdao.findMaxCampCd();
        if (campvolist.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj12CampaignVO campvo = campvolist.get(0);

        String maxCampNo = campvo.getCAMPCD();
        maxCampNo =  maxCampNo.replace("CP", "");
        int No = Integer.parseInt(maxCampNo) + 1;

        campvo.setCAMPCD("CP" + String.format("%1$05d", No));

        //期間を期初～期最終日とするために、月の最終日とかを取得
        Calendar cal = Calendar.getInstance();
        cal.setTime(eigyovo.getKIKANFROM());

        Date fromDt = null;
        Date toDt = null;

        if (_term.equals("上"))
        {
            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear)).intValue(),3,1);
            fromDt = cal.getTime();

            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear)).intValue(),8,1);
            int maxdate = cal.getActualMaximum(Calendar.DATE);
            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear)).intValue(),8,maxdate);
            toDt = cal.getTime();
        }
        else if (_term.equals("下")) {
            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear)).intValue(),9,1);
            fromDt = cal.getTime();

            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear + 1)).intValue(),2,1);
            int maxdate = cal.getActualMaximum(Calendar.DATE);
            cal.set(_phase.add(BigDecimal.valueOf(_standerdYear + 1)).intValue(),2,maxdate);
            toDt = cal.getTime();
        }

        //件名の作成
        //（車種名）XX期（上or下）期キャンペーン
        String kenmei = eigyovo.getDCARCD() + " " +_phase + "期" + _term + "期キャンペーン";

        campvo.setDCARCD(eigyovo.getDCARCD());
        campvo.setPHASE(_phase); //フェーズは媒体管理と同じ
        campvo.setKIKANFROM(fromDt); //上期なら4/1、下期なら10/1
        campvo.setKIKANTO(toDt); //上期なら9/30、下期なら3/30
        campvo.setCAMPNM(kenmei); //作成した件名
        campvo.setFSTBUDGET(BigDecimal.valueOf(0)); //期初予算は0しか入ってない様子なので0
        campvo.setBUDGET(eigyovo.getGROSS()); //予算を媒体状況管理と同じにする
        campvo.setBUDGETHM(eigyovo.getHMCOST()); //予算HMも媒体状況管理と同じにする
        campvo.setACTUAL(eigyovo.getGROSS()); //実績も同様
        campvo.setACTUALHM(eigyovo.getHMCOST());

        campvo.setMEMO(""); //メモはとりあえずなし

        campvo.setBAITAIFLG("1"); //媒体状況管理データは作ってしまうので、1を立てる

        campvo.setCRTNM(eigyovo.getCRTNM()); //作成者
        campvo.setCRTAPL(eigyovo.getCRTAPL());
        campvo.setCRTID(eigyovo.getCRTID());
        campvo.setUPDNM(eigyovo.getUPDNM()); //更新者
        campvo.setUPDID(eigyovo.getUPDID()); //更新者ID
        campvo.setUPDAPL(eigyovo.getUPDAPL()); //更新画面

        return campvo;
    }

    /**
     * 登録用キャンペーン詳細データを作成
     * （Delete→Insertするので、必ず全データを作成）
     * @param mediavo
     * @return
     * @throws HAMException
     */
    private Tbj13CampDetailVO createCampDetailVO(Tbj01MediaPlanVO mediavo) throws HAMException {
        Tbj13CampDetailVO campdetailvo = new Tbj13CampDetailVO();

        //期間とキャンペーンコードで検索し、見つかったデータの合計値を取得
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        Tbj01MediaPlanCondition mediacond = new Tbj01MediaPlanCondition();
        mediacond.setCampcd(mediavo.getCAMPCD());
        mediacond.setYoteiym(mediavo.getYOTEIYM());
        mediacond.setMediacd(mediavo.getMEDIACD());
        List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanSUMByCdAndMonth(mediacond);

        if (mediavolist.size() == 0) {
            throw new HAMException("登録","BJ-E0032");
        }

        Tbj01MediaPlanVO summediavo = mediavolist.get(0);

        campdetailvo.setCAMPCD(mediavo.getCAMPCD());
        campdetailvo.setDCARCD(mediavo.getDCARCD());
        campdetailvo.setMEDIACD(mediavo.getMEDIACD());
        campdetailvo.setPHASE(mediavo.getPHASE());
        campdetailvo.setYOTEIYM(mediavo.getYOTEIYM());
        campdetailvo.setKIKANFROM(mediavo.getKIKANFROM());
        campdetailvo.setKIKANTO(mediavo.getKIKANTO());
        campdetailvo.setBUDGET(summediavo.getBUDGET());
        campdetailvo.setBUDGETHM(summediavo.getBUDGETHM());
        campdetailvo.setCRTNM(mediavo.getCRTNM());
        campdetailvo.setCRTAPL(mediavo.getCRTAPL());
        campdetailvo.setCRTID(mediavo.getCRTID());
        campdetailvo.setUPDNM(mediavo.getUPDNM());
        campdetailvo.setUPDAPL(mediavo.getUPDAPL());
        campdetailvo.setUPDID(mediavo.getUPDID());

        return campdetailvo;
    }

    /**
     * 登録する営業作業台帳データに紐づけるキャンペーンを取得
     * @param vo 営業作業台帳VO
     * @return キャンペーンVO
     * @throws HAMException
     */
    private List<Tbj12CampaignVO> getCampaign(Tbj02EigyoDaichoVO vo) throws HAMException {
        Tbj12CampaignCondition campcond = new Tbj12CampaignCondition();
        Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        Calendar cal = Calendar.getInstance();
        cal.setTime(vo.getKIKANFROM());

        campcond.setDcarcd(vo.getDCARCD());
        campcond.setPhase(_phase);
        campcond.setKikanfrom(vo.getKIKANFROM());
        campcond.setKikanto(vo.getKIKANTO());

        return campdao.findCampaignCd(campcond);
    }

    /**
     * フェイズ情報を取得
     * @param vo 更新・登録対象vo
     * @throws HAMException
     */
    private void getPhaseInfo(Tbj02EigyoDaichoVO vo) throws HAMException {
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype("17");
        codecond.setKeycode("0");
        List<Mbj12CodeVO> coderesult = codedao.selectVO(codecond);

        Calendar cal = Calendar.getInstance();
        cal.setTime(vo.getKIKANFROM());

        int year = cal.get(Calendar.YEAR);
        int month = cal.get(Calendar.MONTH)+1;
        _standerdYear = Integer.parseInt(coderesult.get(0).getYOBI1());
        if (month < 4)
        {
            _phase = BigDecimal.valueOf(year - _standerdYear -1);
        }
        else
        {
            _phase = BigDecimal.valueOf(year - _standerdYear);
        }
        if (month >= 4 && month <= 9)
        {
            _term = "上";
        }
        else if (month <= 3 || month >= 10)
        {
            _term = "下";
        }
    }

    /**
     * 更新・登録対象voの費用計画情報を取得
     * @param vo 更新・登録対象vo
     * @return 費用計画情報
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> getInsertHiyou(Tbj02EigyoDaichoVO vo) throws HAMException
    {
        //費用計画Noの取得
        Mbj09HiyouDAO hiyodao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyocond = new Mbj09HiyouCondition();
        hiyocond.setDcarcd(vo.getDCARCD());
        hiyocond.setMediacd(vo.getMEDIACD());
        hiyocond.setPhase(_phase);
        hiyocond.setTerm(_term);
        List<Mbj09HiyouVO> hiyoresult =hiyodao.selectVO(hiyocond);

        return hiyoresult;
    }

    /**
     * 登録する営業作業台帳データに紐づける媒体状況管理データを取得
     * @param vo 営業作業台帳VO
     * @return 媒体状況管理VO
     * @throws HAMException
     */
    private List<Tbj01MediaPlanVO> getMediaPlan(Tbj02EigyoDaichoVO vo) throws HAMException {
        Tbj01MediaPlanCondition plancond = new Tbj01MediaPlanCondition();
        Tbj01MediaPlanDAO plandao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        plancond.setDcarcd(vo.getDCARCD());
        plancond.setMediacd(vo.getMEDIACD());
        plancond.setPhase(_phase);
        plancond.setTerm(_term);
        plancond.setKikanfrom(vo.getKIKANFROM());
        plancond.setKikanto(vo.getKIKANTO());

        return plandao.findMediaPlanNo(plancond);
    }

//    /**
//     * 排他チェックを行います
//     * @throws HAMException
//     *
//     */
//    private  void exclusionCheck() throws HAMException {
//
//        //再検索をする.
//        FindAuthorityAccountBookDAO dao = FindAuthorityAccountBookDAOFactory.createFindAuthorityAccountBookDAO();
//        FindAuthorityAccountBookCondition toCond = new FindAuthorityAccountBookCondition();
//
//        //期間のみで検索を行う(必要のない場所は空白を送る)
//        toCond.setMediaCd("");
//        toCond.setDCarCd("");
//        toCond.setKikanFrom(_vo.getKikanFrom());
//        toCond.setKikanTo(_vo.getKikanTo());
//        toCond.setMediasNm("");
//        toCond.setCampNm("");
//        toCond.setHamid(_vo.getHamid());
//
//        List<FindAuthorityAccountBookVO> list = dao.findAuthorityAccountBookByCond(toCond);
//        if (list.size() != _vo.getDataCount()) {
//            throw new HAMException("登録","BJ-E0005");
//        }
//
//        if (_vo.getDataCount() != 0) {
//        //  最新日時を取得.
//            FindAuthorityAccountBookVO result = new FindAuthorityAccountBookVO();
//            int count = 0;
//            for (FindAuthorityAccountBookVO vo : list) {
//                if (count == 0) {
//                    result = vo;
//                    count++;
//                    continue;
//                }
//                if (result.getUPDDATE().before(vo.getUPDDATE())) {
//                    result = vo;
//                }
//                count++;
//            }
//            if (!result.getUPDDATE().equals(_vo.getLatestDate())) {
//                throw new HAMException("登録","BJ-E0005");
//            }
//            if (!result.getUPDID().equals(_vo.getLatestID())) {
//                throw new HAMException("登録","BJ-E0005");
//            }
//        }
//
//    }

}
