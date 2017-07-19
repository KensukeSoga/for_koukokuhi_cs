package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignListManager {

    /** シングルトンインスタンス */
    private static FindCampaignListManager _manager = new FindCampaignListManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCampaignListManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindCampaignListManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン一覧情報を検索します
     *
     * @return FindCampaignListResult キャンペーン一覧情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindCampaignListResult findCampgaingList(FindCampaignListCondition cond)
            throws HAMException {

        //検索結果
        FindCampaignListResult result = new FindCampaignListResult();

        if (!cond.getCampaignFlg()) {
            result.setCarList(CarGet(cond));
            if (result.getCarList().size() == 0) {
                return result;
            }
            if (cond.getDCarCd() == null || cond.getDCarCd().trim().length() == 0) {

                cond.setDCarCd(result.getCarList().get(0).getDCARCD());
            }
        }
        // ******************************************************
        // キャンペーン情報の取得
        // ******************************************************
        FindCampaignListDAO campdao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        List<Tbj12CampaignVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);
        //キャンペーン詳細があるキャンペーンコードを取得する.
        List<Tbj12CampaignVO> camdetailList = campdao.findCampaignToDetailsByCond(cond);
        result.set_camDetail(camdetailList);

        return result;
    }

    /**
     * 車種取得.
     *
     * @return FindCampaignListResult キャンペーン一覧情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    private List<CarListVO> CarGet(FindCampaignListCondition cond) throws HAMException
    {

        if (!cond.getFullCar()) {
            FindCarListDAO cardao = FindCarCampaignListDAOFactory.createFindCarListDAO();
            List<CarListVO> carlist = cardao.findCarList(cond);
            return carlist;
        } else if (cond.getFullCar()) {
            CarListCondition carcond = new CarListCondition();
            carcond.setHamid(cond.getHamid());
            carcond.setSecType("0");
            CarListDAO dao = CarListDAOFactory.createCarListDAO();
            return dao.findCarList(carcond);
        }
        return null;
    }
}
