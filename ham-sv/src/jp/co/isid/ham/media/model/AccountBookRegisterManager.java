package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj05CarDAO;
import jp.co.isid.ham.common.model.Mbj05CarDAOFactory;
import jp.co.isid.ham.common.model.Mbj05CarVO;
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
import jp.co.isid.ham.util.constants.HAMConstants;

import org.apache.cxf.common.util.StringUtils;

public class AccountBookRegisterManager {

    /** 定数 */
    private int _maxLengthCAMPNM = 50;

    /** シングルトンインスタンス */
    private static AccountBookRegisterManager _manager = new AccountBookRegisterManager();

    /** 営業作業台帳登録用VO */
    private AccountBookRegisterVO _vo;

    /** フェイズ */
    private BigDecimal _phase;

    /** フェイズ基準年 */
    private int _standerdYear;

    /** 上or下期 */
    private String _term = null;

    /** 媒体状況管理最大値 */
    private static BigDecimal MEDIAPLANGROSS_MAX = new BigDecimal("999999999999");

    /** キャンペーン一覧最大値 */
    private static BigDecimal CAMPGROSS_MAX = new BigDecimal("9999999999999");

    /** 媒体状況管理最大値 */
    private static String MEDIAPLAN_MAX_STRING = "\\999,999,999,999";

    /** キャンペーン一覧最大値 */
    private static String CAMP_MAX_STRING = "\\9,999,999,999,999";


    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private AccountBookRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static AccountBookRegisterManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン一覧情報を登録します
     *
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public void AccountBookIUD(AccountBookRegisterVO vo)
            throws HAMException {
        AccountBookRegisterDAO daichodao = AccountBookRegisterDAOFactory.createAccountBookRegisterDAO();
        AccountBookLogRegisterDAO inslogdao = AccountBookRegisterDAOFactory.createAccountBookLogRegisterDAO();
        FindAccountBookSortNoDAO sortdao = AccountBookRegisterDAOFactory.createFindAccountBookSortNoDAO();

        //更新対象の媒体状況管理NOリスト
        List<BigDecimal> plannolist = new ArrayList<BigDecimal>();

        if (vo.getMediaPlanNO() != null) {
            for (String planno:vo.getMediaPlanNO()) {
                BigDecimal temp = new BigDecimal(planno);
                plannolist.add(temp);
            }
        }

        _vo = vo;

        /** 排他チェック */
        exclusionCheck();

        //削除.
        if (vo.getDelVo() == null || vo.getDelVo().size() == 0) {
        } else {

            for (FindAuthorityAccountBookVO delvo : vo.getDelVo()) {

                Tbj02EigyoDaichoVO deledVO = convertRegistVO(delvo);

                daichodao.delAccounBook(deledVO);
                inslogdao.delAccountBookHistory(deledVO.getDAICHONO());

                //更新対象の媒体状況管理NOリストから、現在削除予定の媒体状況管理NOを取得
                int index = plannolist.indexOf(delvo.getMEDIAPLANNO());

                //見つからなかったら追加
                if (index == -1) {
                    //更新対象の媒体状況管理リストに追加
                    plannolist.add(delvo.getMEDIAPLANNO());
                }
            }
        }

        //登録
        if (vo.getInsVo() == null || vo.getInsVo().size() == 0) {
        } else {

            for (FindAuthorityAccountBookVO insvo : vo.getInsVo()) {

                Tbj02EigyoDaichoVO insedVO = convertRegistVO(insvo);
                //------------------------営業作業台帳の不足データ取得のための処理------------------------//
                //フェイズ情報の取得
                getPhaseInfo(insedVO);

                //営業作業台帳Noの最大値を取得
                Tbj02EigyoDaichoDAO eddao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
                List<Tbj02EigyoDaichoVO> edmaxresult = eddao.selectMaxDaichoNo();
                if (edmaxresult.size() == 0) {
                    throw new HAMException("登録","BJ-E0032");
                }
                String maxDaichoNo = edmaxresult.get(0).getDAICHONO();
                long count = Long.valueOf(maxDaichoNo)+1;
                //0埋めした台帳No
                String newDaichoNo = String.format("%015d", count);
                insedVO.setDAICHONO(newDaichoNo); //台帳Noをセット

                //費用計画NOや企画NOをあらかじめ取得
                List<Mbj09HiyouVO> hiyoresult = getInsertHiyou(insedVO);

                //費用計画NOと企画NOのセット
                if (hiyoresult.isEmpty())
                {
                    insedVO.setHIYOUNO(null);
                    insedVO.setKIKAKUNO(null);
                }
                else
                {
                    insedVO.setHIYOUNO(hiyoresult.get(0).getHIYOUNO());
                    insedVO.setKIKAKUNO(hiyoresult.get(0).getKIKAKUNO());
                }

                if (insedVO.getMEDIAPLANNO().equals(BigDecimal.valueOf(0))) {

                    //------------------------媒体状況管理データのための処理------------------------//
                    //媒体状況管理データの取得
                    List<Tbj01MediaPlanVO> mediaplanvolist = getMediaPlan(insedVO);
                    Tbj01MediaPlanVO mediaplanvo = null;

                    //紐づく媒体状況管理データが取得できないとき
                    if (mediaplanvolist.size() == 0) {
                        List<Tbj12CampaignVO> campvolist = getCampaign(insedVO);
                        Tbj12CampaignVO campvo = new Tbj12CampaignVO();
                        //画面からキャンペーンコードを入力していない時
                        if (StringUtils.isEmpty(insvo.getCAMPCD())) {
                            //------------------------キャンペーン一覧のための処理------------------------//
                            //キャンペーン一覧データの取得

                            //紐づくキャンペーンが取得できないとき
                            if (campvolist.size() == 0) {

                                //ひとまず形だけのキャンペーン一覧を作成する
                                //予算や実績の合計は、媒体状況管理の更新時に行う
                                campvo = createCampaignVO(insedVO);

                                //キャンペーンデータを登録
                                CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
                                campRegistDAO.insCampaignList(campvo);

                            } else {
                                //見つかった時
                                campvo = campvolist.get(0);
                            }
                        } else {
                            //画面でキャンペーンコードを入力しているときは、キャンペーンコードをセット
                            campvo.setCAMPCD(insvo.getCAMPCD());
                        }

                        //------------------------キャンペーン一覧のための処理------------------------//

                        //ひとまず形だけの媒体状況管理データを作成する
                        //予算や実績の合計は、媒体状況管理の更新で一気に行う
                        mediaplanvo = createMediaPlanVO(insedVO,campvo);

                        //媒体状況管理データを登録
                        MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
                        mediaRegisterDAO.insMediaPlan(mediaplanvo);

                        //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                        insedVO.setMEDIAPLANNO(mediaplanvo.getMEDIAPLANNO());
                    } else {
                        //取得できるとき
                        //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                        insedVO.setMEDIAPLANNO(mediaplanvolist.get(0).getMEDIAPLANNO());
                        mediaplanvo = mediaplanvolist.get(0);
                    }
                    //------------------------媒体状況管理データのための処理------------------------//
                }
                //------------------------営業作業台帳の不足データ取得のための処理------------------------//

                //ソート順が設定されていない場合は、ソート順をセット
                if (insedVO.getSORTNO() == null) {
                    FindAccountBookSortNoCondition sortcond = new FindAccountBookSortNoCondition();
                    sortcond.setMEDIAPLANNO(insedVO.getMEDIAPLANNO());
                    List<FindAccountBookSortNoVO> sortvolist = sortdao.selectVO(sortcond);
                    insedVO.setSORTNO(sortvolist.get(0).getSORTNO());
                }

                //営業作業台帳と営業作業台帳ログを登録
                daichodao.insAccounBook(insedVO);
                inslogdao.insAccountBookHistory(insedVO.getDAICHONO(),HAMConstants.HISTORYKBN_REGSTER );

                //更新対象の媒体状況管理NOリストから、現在登録予定の媒体状況管理NOを取得
                int index = plannolist.indexOf(insedVO.getMEDIAPLANNO());

                //見つからなかったら追加
                if (index == -1) {
                    //更新対象の媒体状況管理リストに追加
                    plannolist.add(insedVO.getMEDIAPLANNO());
                }
            }

        }

        //更新
        if (vo.getUpdVo() == null || vo.getUpdVo().size() == 0) {
        } else {

            for (FindAuthorityAccountBookVO updvo : vo.getUpdVo()) {

                Tbj02EigyoDaichoVO updedVO = convertRegistVO(updvo);

                //更新対象の媒体状況管理Noを取得
                Tbj02EigyoDaichoDAO getUpdDaicho = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
                List<Tbj02EigyoDaichoVO> updDaichoVO = getUpdDaicho.FindEigyoDaichoByDaichoNo(updedVO.getDAICHONO());

                BigDecimal updMediaPlanNo = updDaichoVO.get(0).getMEDIAPLANNO();
                int index;
                if (updedVO.getMEDIAPLANNO().compareTo(BigDecimal.valueOf(0)) != 0) {

                    //更新対象の媒体状況管理NOリストから、更新前の媒体状況管理NOを取得
                    index = plannolist.indexOf(updedVO.getMEDIAPLANNO());

                    //見つからなかったら追加
                    if (index == -1) {
                        //更新対象の媒体状況管理リストに追加
                        plannolist.add(updedVO.getMEDIAPLANNO());
                    }
                }

                //------------------------営業作業台帳の不足データ取得のための処理------------------------//
                //フェイズ情報の取得
                getPhaseInfo(updedVO);

                //費用計画NOや企画NOをあらかじめ取得
                List<Mbj09HiyouVO> hiyoresult = getInsertHiyou(updedVO);

                //費用計画NOと企画NOのセット
                if (hiyoresult.isEmpty())
                {
                    updedVO.setHIYOUNO("");
                    updedVO.setKIKAKUNO("");
                }
                else
                {
                    updedVO.setHIYOUNO(hiyoresult.get(0).getHIYOUNO());
                    updedVO.setKIKAKUNO(hiyoresult.get(0).getKIKAKUNO());
                }

                //------------------------営業作業台帳の不足データ取得のための処理------------------------//
                if (updedVO.getMEDIAPLANNO().equals(BigDecimal.valueOf(0))) {

                    //------------------------媒体状況管理データのための処理------------------------//
                    //媒体状況管理データの取得
                    List<Tbj01MediaPlanVO> mediaplanvolist = getMediaPlan(updedVO);
                    Tbj01MediaPlanVO mediaplanvo = null;

                    //紐づく媒体状況管理データが取得できないとき
                    if (mediaplanvolist.size() == 0) {
                        List<Tbj12CampaignVO> campvolist = getCampaign(updedVO);
                        Tbj12CampaignVO campvo = new Tbj12CampaignVO();
                        //画面からキャンペーンコードを入力していない時
                        if (StringUtils.isEmpty(updvo.getCAMPCD())) {
                            //------------------------キャンペーン一覧のための処理------------------------//
                            //キャンペーン一覧データの取得

                            //紐づくキャンペーンが取得できないとき
                            if (campvolist.size() == 0) {

                                //ひとまず形だけのキャンペーン一覧を作成する
                                //予算や実績の合計は、媒体状況管理の更新時に行う
                                campvo = createCampaignVO(updedVO);

                                //キャンペーンデータを登録
                                CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
                                campRegistDAO.insCampaignList(campvo);

                            } else {
                                //見つかった時
                                campvo = campvolist.get(0);
                            }
                        } else {
                            //画面でキャンペーンコードを入力しているときは、キャンペーンコードをセット
                            campvo.setCAMPCD(updvo.getCAMPCD());
                        }

                        //------------------------キャンペーン一覧のための処理------------------------//

                        //ひとまず形だけの媒体状況管理データを作成する
                        //予算や実績の合計は、媒体状況管理の更新で一気に行う
                        mediaplanvo = createMediaPlanVO(updedVO,campvo);

                        //媒体状況管理データを登録
                        MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
                        mediaRegisterDAO.insMediaPlan(mediaplanvo);

                        //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                        updedVO.setMEDIAPLANNO(mediaplanvo.getMEDIAPLANNO());
                    } else {
                        //取得できるとき
                        //営業作業台帳の媒体状況管理NOに、作成した媒体状況管理NOを設定
                        updedVO.setMEDIAPLANNO(mediaplanvolist.get(0).getMEDIAPLANNO());
                        mediaplanvo = mediaplanvolist.get(0);
                    }
                    //------------------------媒体状況管理データのための処理------------------------//
                }

                //ソート順が設定されていない場合は、ソート順をセット
                if (updedVO.getSORTNO() == null) {
                    FindAccountBookSortNoCondition sortcond = new FindAccountBookSortNoCondition();
                    sortcond.setMEDIAPLANNO(updedVO.getMEDIAPLANNO());
                    List<FindAccountBookSortNoVO> sortvolist = sortdao.selectVO(sortcond);
                    updedVO.setSORTNO(sortvolist.get(0).getSORTNO());
                }

                //営業作業台帳と営業作業台帳ログを登録
                daichodao.updAccounBook(updedVO,updMediaPlanNo);
                inslogdao.insAccountBookHistory(updedVO.getDAICHONO(),HAMConstants.HISTORYKBN_UPDATE);

                //更新対象の媒体状況管理NOリストから、現在更新予定の媒体状況管理NOを取得
                index = plannolist.indexOf(updedVO.getMEDIAPLANNO());

                //見つからなかったら追加
                if (index == -1) {
                    //更新対象の媒体状況管理リストに追加
                    plannolist.add(updedVO.getMEDIAPLANNO());
                }
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
            if (mediaplanvo.getACTUAL().compareTo(MEDIAPLANGROSS_MAX) > 0) {
                throw new HAMException("登録","BJ-W0094\t" + MEDIAPLAN_MAX_STRING + "\t" + mediaplanvo.getKENMEI());

            }

            //媒体状況管理データを更新
            mediaRegisterDAO.updMediaPlan(mediaplanvo);

            //更新対象のキャンペーン一覧データの取得
            Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> campvolist = campdao.findCampaignListByCampCd(mediaplanvo.getCAMPCD());
            Tbj12CampaignVO campvo = campvolist.get(0);

            //更新用のキャンペーンVOを作成
            campvo = updateCampaignVO(mediaplanvo,campvo);
            if (campvo.getACTUAL().compareTo(CAMPGROSS_MAX) > 0) {
                throw new HAMException("登録","BJ-W0094\t" + CAMP_MAX_STRING + "\t" + campvo.getCAMPNM());
            }

            //キャンペーンデータを更新
            campRegistDAO.updCampaignList(campvo);

            Tbj13CampDetailCondition campcond = new Tbj13CampDetailCondition();
            campcond.setCampcd(mediaplanvo.getCAMPCD());
            campcond.setMediacd(mediaplanvo.getMEDIACD());
            campcond.setYoteiym(mediaplanvo.getYOTEIYM());

            //更新対象のキャンペーン詳細データを一度削除しておく
            campDetailRegistDAO.delCampaignDetailsByCd(campcond);

            List<Tbj13CampDetailVO> campdetailvo = createCampDetailVO(mediaplanvo);
            for (Tbj13CampDetailVO insvo : campdetailvo) {
                campDetailRegistDAO.insCampaignDetails(insvo);
            }

        }
    }

    /**
     * 画面上のデータから登録用データに変換
     * @param vo 画面表示用データ
     * @return 登録用データ
     */
    private Tbj02EigyoDaichoVO convertRegistVO(FindAuthorityAccountBookVO vo) {

        Tbj02EigyoDaichoVO eigyoVO = new Tbj02EigyoDaichoVO();

        eigyoVO.setMEDIAPLANNO(vo.getMEDIAPLANNO());
        eigyoVO.setDAICHONO(vo.getDAICHONO());
        eigyoVO.setIMPKEY(vo.getIMPKEY());
        eigyoVO.setSEIKYUYM(vo.getSEIKYUYM());
        eigyoVO.setMEDIACD(vo.getMEDIACD());
        eigyoVO.setMEDIASCD(vo.getMEDIASCD());
        eigyoVO.setMEDIASNM(vo.getMEDIASNM());
        eigyoVO.setKEIRETSUCD(vo.getKEIRETSUCD());
        eigyoVO.setDCARCD(vo.getDCARCD());
        eigyoVO.setHIYOUNO(vo.getHIYOUNO());
        eigyoVO.setKIKAKUNO(vo.getKIKAKUNO());
        eigyoVO.setCAMPAIGN(vo.getCAMPAIGN());
        eigyoVO.setNAIYOHIMOKU(vo.getNAIYOHIMOKU());
        eigyoVO.setSPACE(vo.getSPACE());
        eigyoVO.setNPDIVISION(vo.getNPDIVISION());
        eigyoVO.setPUBLISHVER(vo.getPUBLISHVER());
        eigyoVO.setSYMBOLDIVISION(vo.getSYMBOLDIVISION());
        eigyoVO.setPOSTEDSURFACE(vo.getPOSTEDSURFACE());
        eigyoVO.setUNIT(vo.getUNIT());
        eigyoVO.setCONTRACTDIVISION(vo.getCONTRACTDIVISION());
        eigyoVO.setKIKANFROM(vo.getKIKANFROM());
        eigyoVO.setKIKANTO(vo.getKIKANTO());
        eigyoVO.setGENKAFLG(vo.getGENKAFLG());
        eigyoVO.setGROSS(vo.getGROSS());
        eigyoVO.setDNEBIKIRITSU(vo.getDNEBIKIRITSU());
        eigyoVO.setDNEBIKIGAKU(vo.getDNEBIKIGAKU());
        eigyoVO.setHMCOST(vo.getHMCOST());
        eigyoVO.setAPLRIEKIRITSU(vo.getAPLRIEKIRITSU());
        eigyoVO.setAPLRIEKIGAKU(vo.getAPLRIEKIGAKU());
        eigyoVO.setMEDIAHARAI(vo.getMEDIAHARAI());
        eigyoVO.setMEDIAMARGINRITSU(vo.getMEDIAMARGINRITSU());
        eigyoVO.setMEDIAMARGINGAKU(vo.getMEDIAMARGINGAKU());
        eigyoVO.setMEDIAGENKA(vo.getMEDIAGENKA());
        eigyoVO.setTORIRIEKI(vo.getTORIRIEKI());
        eigyoVO.setRIEKIHAIBUN(vo.getRIEKIHAIBUN());
        eigyoVO.setNAIKINRIEKI(vo.getNAIKINRIEKI());
        eigyoVO.setFURIKAERIEKI(vo.getFURIKAERIEKI());
        eigyoVO.setEIGYOYOIN(vo.getEIGYOYOIN());
        eigyoVO.setFURIKAERIEKI2(vo.getFURIKAERIEKI2());
        eigyoVO.setTVTHMTANKA(vo.getTVTHMTANKA());
        eigyoVO.setTVTMEDIATANKA(vo.getTVTMEDIATANKA());
        eigyoVO.setCOLORFEE(vo.getCOLORFEE());
        eigyoVO.setDESIGNATIONFEE(vo.getDESIGNATIONFEE());
        eigyoVO.setDOUBLEFEE(vo.getDOUBLEFEE());
        eigyoVO.setRECLASSIFICATIONFEE(vo.getRECLASSIFICATIONFEE());
        eigyoVO.setSPACEFEE(vo.getSPACEFEE());
        eigyoVO.setSPLITRUNFEE(vo.getSPLITRUNFEE());
        eigyoVO.setREQUESTDESTINATION(vo.getREQUESTDESTINATION());
        eigyoVO.setBRDDATE(vo.getBRDDATE());
        eigyoVO.setBIKO(vo.getBIKO());
        eigyoVO.setSEIKYUFLG(vo.getSEIKYUFLG());
        eigyoVO.setCPDATE(vo.getCPDATE());
        eigyoVO.setBRDSEC(vo.getBRDSEC());
        eigyoVO.setFILEOUTFLG(vo.getFILEOUTFLG());
        eigyoVO.setAPPEARANCEDATE(vo.getAPPEARANCEDATE());
        eigyoVO.setSORTNO(vo.getSORTNO());
        eigyoVO.setCRTDATE(vo.getCRTDATE());
        eigyoVO.setCRTNM(vo.getCRTNM());
        eigyoVO.setCRTAPL(vo.getCRTAPL());
        eigyoVO.setCRTID(vo.getCRTID());
        eigyoVO.setUPDDATE(vo.getUPDDATE());
        eigyoVO.setUPDNM(vo.getUPDNM());
        eigyoVO.setUPDAPL(vo.getUPDAPL());
        eigyoVO.setUPDID(vo.getUPDID());


        return eigyoVO;
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
        mediavo.setCRTID(eigyovo.getCRTID());
        mediavo.setCRTAPL(eigyovo.getCRTAPL());
        mediavo.setCRTNM(eigyovo.getCRTNM());
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

        //実績をvoに入れる
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

        //車種マスタを取得
        Mbj05CarDAO cardao = Mbj05CarDAOFactory.createMbj05CarDAO();
        Mbj05CarCondition carCondition = new Mbj05CarCondition();
        carCondition.setDcarcd(eigyovo.getDCARCD());
        List<Mbj05CarVO> carvolist = cardao.selectVO(carCondition);
        if (carvolist.size() == 0)
        {
            throw new HAMException("登録","BJ-E0032");
        }
        Mbj05CarVO carvo = carvolist.get(0);

        //件名の作成
        //（車種名）XX期（上or下）期キャンペーン
        String kenmei = " " +_phase + "期" + _term + "期キャンペーン";
        if (kenmei.length() > _maxLengthCAMPNM)
        {
            kenmei = kenmei.substring(0,_maxLengthCAMPNM);
        }
        String carNm = carvo.getCARNM();
        int kenmeiLength = kenmei.length() + carNm.length();
        if (kenmeiLength > _maxLengthCAMPNM)
        {   // 最大文字数を超えていた場合
            // 車種名を切り詰める
            carNm = carNm.substring(0,carNm.length() - (kenmeiLength - _maxLengthCAMPNM));
        }

        kenmei = carNm + kenmei;

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
        campvo.setCRTID(eigyovo.getCRTID()); //作成者ID
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
    private List<Tbj13CampDetailVO> createCampDetailVO(Tbj01MediaPlanVO mediavo) throws HAMException {
        List<Tbj13CampDetailVO> campdetailvo = new ArrayList<Tbj13CampDetailVO>();

        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> resistList = mediadao.findMediaPlanByCampCdDist(mediavo.getCAMPCD());

        for (Tbj01MediaPlanVO vo : resistList)
        {
            //期間とキャンペーンコードと媒体で検索し、見つかったデータの合計値を取得

            Tbj01MediaPlanCondition mediacond = new Tbj01MediaPlanCondition();
            mediacond.setCampcd(vo.getCAMPCD());
            mediacond.setYoteiym(vo.getYOTEIYM());
            mediacond.setMediacd(vo.getMEDIACD());
            List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanSUMByCdAndMonth(mediacond);
            List<Tbj01MediaPlanVO> mediavolists = mediadao.findMediaPlanByCampCd(vo.getCAMPCD());

            //見つからなかった時（削除した時など）はnullとしておく
            if (mediavolists.size() == 0) {
                campdetailvo = null;
            } else {
                //ある時は登録用データを作成

                Tbj01MediaPlanVO summediavo = mediavolist.get(0);
                Tbj13CampDetailVO addvo = new Tbj13CampDetailVO();

                addvo.setCAMPCD(vo.getCAMPCD());
                addvo.setDCARCD(mediavo.getDCARCD());
                addvo.setMEDIACD(vo.getMEDIACD());
                addvo.setPHASE(mediavo.getPHASE());
                addvo.setYOTEIYM(vo.getYOTEIYM());
                addvo.setKIKANFROM(vo.getKIKANFROM());
                addvo.setKIKANTO(vo.getKIKANTO());
                addvo.setBUDGET(summediavo.getBUDGET());
                addvo.setBUDGETHM(summediavo.getBUDGETHM());
                addvo.setCRTAPL(mediavo.getCRTAPL());
                addvo.setCRTNM(mediavo.getCRTNM());
                addvo.setCRTID(mediavo.getCRTID());
                addvo.setUPDNM(mediavo.getUPDNM());
                addvo.setUPDAPL(mediavo.getUPDAPL());
                addvo.setUPDID(mediavo.getUPDID());

                campdetailvo.add(addvo);
            }
        }

        return campdetailvo;
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
     * 排他チェックを行います
     * @throws HAMException
     *
     */
    private  void exclusionCheck() throws HAMException {

        //再検索をする.
        FindAuthorityAccountBookDAO dao = FindAuthorityAccountBookDAOFactory.createFindAuthorityAccountBookDAO();
        FindAuthorityAccountBookCondition toCond = new FindAuthorityAccountBookCondition();

        toCond.setMediaCd(_vo.getMediaCd());
        toCond.setDCarCd(_vo.getDCarCd());
        toCond.setKikanFrom(_vo.getKikanFrom());
        toCond.setKikanTo(_vo.getKikanTo());
        toCond.setMediasNm(_vo.getMediasNm());
        toCond.setCampNm(_vo.getCampNm());
        toCond.setHamid(_vo.getHamid());

        List<FindAuthorityAccountBookVO> list = dao.findAuthorityAccountBookByCond(toCond);

        // 比較を簡略化するために、HashMapに型を変換
        HashMap<String, Date> hm = new HashMap<String, Date>();
        for (FindAuthorityAccountBookVO abvo : list) {
            hm.put(abvo.getDAICHONO(), abvo.getUPDDATE());
        }

        boolean error = false;

        // 更新対象排他チェック
        if (_vo.getUpdVo() != null && _vo.getUpdVo().size() > 0) {
            for (FindAuthorityAccountBookVO updVo : _vo.getUpdVo()) {
                // 更新対象が既に削除されている場合はエラー
                if (!hm.containsKey(updVo.getDAICHONO())) {
                    error = true;
                    break;
                }

                // 更新対象が既に更新されている場合はエラー
                if (_vo.getLatestDate().before(hm.get(updVo.getDAICHONO()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                throw new HAMException("登録","BJ-E0005");
            }
        }

        // 削除対象排他チェック
        if (_vo.getDelVo() != null && _vo.getDelVo().size() > 0) {
            for (FindAuthorityAccountBookVO delVo : _vo.getDelVo()) {
                // 削除対象が既に削除されている場合はエラー
                if (!hm.containsKey(delVo.getDAICHONO())) {
                    error = true;
                    break;
                }

                // 削除対象が既に更新されている場合はエラー
                if (_vo.getLatestDate().before(hm.get(delVo.getDAICHONO()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                throw new HAMException("登録","BJ-E0005");
            }
        }
    }
}
