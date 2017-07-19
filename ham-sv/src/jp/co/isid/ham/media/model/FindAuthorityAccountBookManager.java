package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.FindContactRequestCondition;
import jp.co.isid.ham.common.model.FindContactRequestDAO;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj47NewspaperCondition;
import jp.co.isid.ham.common.model.Mbj47NewspaperDAO;
import jp.co.isid.ham.common.model.Mbj47NewspaperDAOFactory;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindAuthorityAccountBookManager {

    /** シングルトンインスタンス */
    private static FindAuthorityAccountBookManager _manager = new FindAuthorityAccountBookManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindAuthorityAccountBookManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindAuthorityAccountBookManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindAuthorityAccountBookResult findAuthorityAccountBook(FindAuthorityAccountBookCondition cond)
            throws HAMException {

        String code = "'WB','WC','9V'";
        String hamcode = "'28','29','30','37'";

        //検索結果
        FindAuthorityAccountBookResult result = new FindAuthorityAccountBookResult();

        // ******************************************************
        // 営業作業台帳情報の取得
        // ******************************************************
        FindAuthorityAccountBookDAO accountbookdao = FindAuthorityAccountBookDAOFactory.createFindAuthorityAccountBookDAO();
        List<FindAuthorityAccountBookVO> acblist = accountbookdao.findAuthorityAccountBookByCond(cond);
        result.setAuthorityAccountBook(acblist);

        // ******************************************************
        // 媒体状況管理情報の取得
        // ******************************************************
        Tbj01MediaPlanDAO mediaplandao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mediaplanlist = mediaplandao.findAllMediaPlan();
        result.setTbj01MediaPlan(mediaplanlist);

        // ******************************************************
        // 媒体状況管理情報の取得
        // ******************************************************
        Tbj12CampaignDAO campaigndao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> campaignlist = campaigndao.findAllCampaign();
        result.setTbj12Campaign(campaignlist);

        // ******************************************************
        // 媒体種別の取得
        // ******************************************************
        FindMediaCategoryDAO mediasdao = FindAuthorityAccountBookDAOFactory.createFindMediaCategoryDAO();
        List<FindMediaCategoryVO> carlist = mediasdao.findMediaCategory(cond);
        result.setMediaCategory(carlist);

        // ******************************************************
        // キャンペーンの取得
        // ******************************************************
        FindAccountBookCampaignDAO campdao = FindAuthorityAccountBookDAOFactory.createFindAccountBookCampaignDAO();
        List<FindAccountBookCampaignVO> camplist = campdao.findAccountBookCampaign(cond);
        result.setAccountBookCampaign(camplist);

        // ******************************************************
        // 内容費目キャンペーンの取得
        // ******************************************************
        FindExpenseItemListDAO eidao = FindAuthorityAccountBookDAOFactory.createFindExpenseitemListDAO();
        List<FindExpenseItemListVO> itemlist = eidao.findExpenseItemList(cond);
        result.setExpenseItemList(itemlist);

        // ******************************************************
        // スペースの取得
        // ******************************************************
        FindSpaceDAO spacedao = FindAuthorityAccountBookDAOFactory.createFindSpaceDAO();
        List<FindSpaceVO> spacelist = spacedao.findSpace(cond);
        result.setSpace(spacelist);

        // ******************************************************
        // 画面項目表示列制御マスタ取得
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // ******************************************************
        // 一覧表示パターン取得
        // ******************************************************
        Tbj30DisplayPatternDAO dpdao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition dpcond = new Tbj30DisplayPatternCondition();
        dpcond.setHamid(cond.getHamid());
        dpcond.setFormid(cond.getFormID());
        dpcond.setViewid(cond.getViewID());
        result.setDisplayPattern(dpdao.selectVO(dpcond));

        // ******************************************************
        // 車種一覧取得
        // ******************************************************
        CarListDAO cldao =CarListDAOFactory.createCarListDAO();
        CarListCondition clcond = new CarListCondition();
        clcond.setHamid(cond.getHamid());
        clcond.setSecType("0");
        result.setCarList(cldao.findCarList(clcond));

        // ******************************************************
        // 媒体一覧取得
        // ******************************************************
        MediaListDAO mldao = MediaListDAOFactory.createMediaListDAO();
        MediaListCondition mlcond = new MediaListCondition();
        mlcond.setHamid(cond.getHamid());
        result.setMediaList(mldao.findMediaList(mlcond));

        // ******************************************************
        // 全社マスタの新雑の情報取得
        // ******************************************************
        RepaVbjaMeu29CcDAO masterdao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        result.setRepaVbjaMeu29Cc(masterdao.FindCodeMasterByCode(code,""));

        // ******************************************************
        // 依頼先情報取得
        // ******************************************************
//        RepaVbjaMea10IrskDAO irskdao =  RepaVbjaMea10IrskDAOFactory.createRepaVbjaMea10IrskDAO();
//        RepaVbjaMea10IrskCondition irskcond = new RepaVbjaMea10IrskCondition();
//        irskcond.setAlasuseflg("1");
//        irskcond.setTkalasuseflg("1");
//        result.setRepaVbjaMea10Irsk(irskdao.FindOrderDestinationByDateFlg(irskcond));

        FindContactRequestDAO fcrdao = FindAuthorityAccountBookDAOFactory.createFindContactRequestDAO();
        FindContactRequestCondition fcrcond = new FindContactRequestCondition();
        fcrcond.setJYUCTYPE("10");
        fcrcond.setALASUSEFLG("1");
        fcrcond.setATSEGSYOCD(cond.getEgsyocd());
        fcrcond.setJYUCFLG("1");
        result.setFindContactRequest(fcrdao.selectVO(fcrcond));

        // ******************************************************
        // 依頼先情報(絞り込み)取得
        // ******************************************************
        if (cond.getEgsyocd() != null && !cond.getEgsyocd().isEmpty()) {
            FindContactRequestNarrowingDAO fcrndao = FindAuthorityAccountBookDAOFactory.createFindContactRequestNarrowingDAO();
            FindContactRequestNarrowingCondition fcrncond = new FindContactRequestNarrowingCondition();
            fcrncond.setJYUCTYPE("10");
            fcrncond.setALASUSEFLG("1");
            fcrncond.setATSEGSYOCD(cond.getEgsyocd());
            fcrncond.setJYUCFLG("1");
            fcrncond.setCODETYPEEGSYOCD(cond.getCodetypeegsyocd());
            result.setFCRNarrowing(fcrndao.selectVO(fcrncond));
        }

        // ******************************************************
        // コードマスタ取得
        // ******************************************************
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype(hamcode);
        result.setMbj12Code(codedao.FindManyCd(codecond));

        // ******************************************************
        // スペースマスタの取得
        // ******************************************************
        FindSpaceMasterDAO spaceMasterDao = FindAuthorityAccountBookDAOFactory.createSpaceMasterDAO();
        result.setSpaceMasterList(spaceMasterDao.selectVO());

        // ******************************************************
        // 新聞マスタの取得
        // ******************************************************
        Mbj47NewspaperDAO newspaperdao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();
        result.setNewspaper(newspaperdao.selectVO(new Mbj47NewspaperCondition()));

        //--共通の取得処理--//
        // ******************************************************
        // 機能制御Infoの取得
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());


        // ******************************************************
        // セキュリティInfoの取得
        // ******************************************************
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        seccond.setHamid(cond.getHamid());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        result.setSecurityInfoVoList(secmanager.getSecurityInfo(seccond).getSecurityInfo());


        return result;
    }

}
