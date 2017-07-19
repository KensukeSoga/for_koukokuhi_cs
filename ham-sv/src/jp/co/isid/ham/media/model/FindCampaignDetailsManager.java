package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAO;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignDetailsManager {

    /** シングルトンインスタンス */
    private static FindCampaignDetailsManager _manager = new FindCampaignDetailsManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCampaignDetailsManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindCampaignDetailsManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン詳細情報を検索します
     *
     * @return FindCampaignListResult キャンペーン詳細情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindCampaignDetailsResult findCampgaingDetail(FindCampaignDetailsCondition cond) throws HAMException {

        //検索結果
        FindCampaignDetailsResult result = new FindCampaignDetailsResult();

        if (cond.getTbj13AllSelectFlg()) {
            Tbj13CampDetailDAO dao = Tbj13CampDetailDAOFactory.createTbj13CampDetailDAO();
            List<Tbj13CampDetailVO> list13 = dao.findCampaignDetailsByCond(cond);
            result.setCampaignDetails(list13);
        } else {
            FindCampaignDetailsDAO campdao = Tbj13CampDetailDAOFactory.createFindCampaignDetailsDAO();
            List<FindCampaignDetailstVO>list =  campdao.findCampaignListByCond(cond);
            result.setCampaignList(list);
        }

        // ******************************************************
        // 媒体状況管理取得
        // ******************************************************
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        result.setMediaPlan(mediadao.findMediaPlanByCampCd(cond.getCampaignNo()));

        //--共通の取得処理--//
        // ******************************************************
        // 機能制御Infoの取得
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFunctionType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // ******************************************************
        // セキュリティInfoの取得
        // ******************************************************
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        List<SecurityInfoVO> secvolist = new ArrayList<SecurityInfoVO>();
        List<SecurityInfoVO> tempvolist = new ArrayList<SecurityInfoVO>();
        seccond.setHamid(cond.getHamId());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getCampaignSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        secvolist = secmanager.getSecurityInfo(seccond).getSecurityInfo();

        //キャンペーンだけでなく、媒体状況管理も登録するおそれがあるので、そっちのセキュリティも取得する
        seccond.setSecuritycd(cond.getMediaPlanSecuritycd());
        tempvolist = secmanager.getSecurityInfo(seccond).getSecurityInfo();

        //secvolistに追加してあげる
        for (SecurityInfoVO vo : tempvolist) {
            secvolist.add(vo);
        }
        result.setSecurityInfoVoList(secvolist);

        return result;
    }

}
