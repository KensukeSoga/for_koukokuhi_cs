package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignDetailsHomeLoadManager {

    /** シングルトンインスタンス */
    private static FindCampaignDetailsHomeLoadManager _manager = new FindCampaignDetailsHomeLoadManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCampaignDetailsHomeLoadManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindCampaignDetailsHomeLoadManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン詳細情報を検索します
     *
     * @return FindCampaignListResult キャンペーン詳細情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindCampaignDetailsResult findCampgaingDetail(FindCampaignDetailsCondition cond)
    throws HAMException {

        //検索結果
        FindCampaignDetailsResult result = new FindCampaignDetailsResult();

        //**************************************************
        //媒体マスタの取得.
        //**************************************************
        MediaListCondition mcond = new MediaListCondition();
        mcond.setHamid(cond.getHamId());
        MediaListDAO dao = MediaListDAOFactory.createMediaListDAO();
        List<MediaListVO> medialist = dao.findMediaList(mcond);
        result.setMediaList(medialist);


        //**************************************************
        //キャンペーン詳細の取得.
        //**************************************************
        FindCampaignDetailsDAO campdao = Tbj13CampDetailDAOFactory.createFindCampaignDetailsDAO();
        List<FindCampaignDetailstVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);

        // ******************************************************
        // 媒体状況管理取得
        // ******************************************************
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        result.setMediaPlan(mediadao.findMediaPlanByCampCd(cond.getCampaignNo()));


        //**************************************************
        //スプレッド列情報の取得.
        //**************************************************
        Mbj37DisplayControlCondition discond = new Mbj37DisplayControlCondition();
        discond.setFormid(cond.getFormId());
        Mbj37DisplayControlDAO disDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        List<Mbj37DisplayControlVO> disList = disDao.selectVO(discond);
        result.setSpdCont(disList);

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
