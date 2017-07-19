package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignListHomeLoadManager {

    /** シングルトンインスタンス */
    private static FindCampaignListHomeLoadManager _manager = new FindCampaignListHomeLoadManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCampaignListHomeLoadManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindCampaignListHomeLoadManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン一覧情報を検索します
     *
     * @return FindCampaignListResult キャンペーン一覧情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindCampaignListResult findCampgaingList(FindCampaignListCondition cond) throws HAMException {

        //検索結果
        FindCampaignListResult result = new FindCampaignListResult();

        //車種取得.
        result.setCarList(CarGet(cond));
        if (result.getCarList().size() != 0) {
            cond.setDCarCd(result.getCarList().get(0).getDCARCD());
        }

        Mbj37DisplayControlCondition discond = new Mbj37DisplayControlCondition();
        discond.setFormid(cond.getFormID());
        Mbj37DisplayControlDAO disDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        List<Mbj37DisplayControlVO> disList = disDao.selectVO(discond);
        result.setSpdControl(disList);

        // ******************************************************
        // キャンペーン情報の取得
        // ******************************************************
        FindCampaignListDAO campdao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        List<Tbj12CampaignVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);
        //キャンペーン詳細があるキャンペーンコードを取得する.
        List<Tbj12CampaignVO> camdetailList = campdao.findCampaignToDetailsByCond(cond);
        result.set_camDetail(camdetailList);

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
     * 車種を取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    private List<CarListVO> CarGet(FindCampaignListCondition cond) throws HAMException {

        FindCarListDAO cardao = FindCarCampaignListDAOFactory.createFindCarListDAO();
        List<CarListVO> carlist = cardao.findCarList(cond);

        return carlist;
    }

}
