package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindMediaPlanManager {

    /** シングルトンインスタンス */
    private static FindMediaPlanManager _manager = new FindMediaPlanManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindMediaPlanManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindMediaPlanManager getInstance() {
        return _manager;
    }

    /**
     * 媒体状況管理情報を検索します
     *
     * @return FindMediaPlanResult 媒体状況管理情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindMediaPlanResult findMediaPlan(FindMediaPlanCondition cond)
            throws HAMException {

        //検索結果
        FindMediaPlanResult result = new FindMediaPlanResult();


        // ******************************************************
        // 車種一覧取得
        // ******************************************************
        CarListDAO cldao =CarListDAOFactory.createCarListDAO();
        CarListCondition clcond = new CarListCondition();
        clcond.setHamid(cond.getHamid());
        clcond.setSecType("0");
        result.setCarList(cldao.findCarList(clcond));

        // ******************************************************
        // 媒体状況管理情報の取得
        // ******************************************************
        FindMediaPlanDAO mediaplandao = FindMediaPlanDAOFactory.createFindMediaPlanDAO();
        List<FindMediaPlanVO> mplist = mediaplandao.findMediaPlanByCond(cond);
        result.setMediaPlan(mplist);

        // ******************************************************
        // キャンペーンの取得
        // ******************************************************
        FindMediaPlanCampaignDAO campdao = FindMediaPlanDAOFactory.createFindMediaPlanCampaignDAO();
        List<FindMediaPlanCampaignVO> camplist = campdao.findMediaPlanCampaign(cond);
        result.setMediaPlanCampaign(camplist);

        // ******************************************************
        // 媒体一覧取得
        // ******************************************************
        MediaListDAO mldao = MediaListDAOFactory.createMediaListDAO();
        MediaListCondition mlcond = new MediaListCondition();
        mlcond.setHamid(cond.getHamid());
        result.setMediaList(mldao.findMediaList(mlcond));

        // ******************************************************
        // 画面項目表示列制御マスタ取得
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        //--共通の取得処理--//
        // ******************************************************
        // 機能制御Infoの取得
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFunctionType());
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


    /**
     * 営業作業台帳の取得
     *
     * @param cond 取得条件
     * @return 取得結果
     * @throws HAMException
     */
    public FindAccountBookResult findAccountBook(FindAccountBookCondition cond) throws HAMException
    {
        FindAccountBookResult result = new FindAccountBookResult();
        List<Tbj02EigyoDaichoVO> ac = new ArrayList<Tbj02EigyoDaichoVO>();

        for (String strMediaPlanNo : cond.getMediaPlanNo()) {
            //*******************************************
            //営業作業台帳の取得
            //*******************************************
            Tbj02EigyoDaichoDAO edao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
            ac.addAll(edao.FindEigyoDaichoByMediaPlanNo(strMediaPlanNo));
        }

        result.setAccountBook(ac);

        return result;
    }
}
