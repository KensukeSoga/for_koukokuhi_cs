package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindSumCarManager {

    /** シングルトンインスタンス */
    private static FindSumCarManager _manager = new FindSumCarManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindSumCarManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindSumCarManager getInstance() {
        return _manager;
    }

    /**
     * 入力拒否情報を検索します
     *
     * @return FindInputRejectionResult 入力拒否情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindSumCarResult findSumCar(Tbj01MediaPlanCondition cond)
    throws HAMException {

        FindSumCarResult result = new FindSumCarResult();

        //****************************************
        //媒体状況管理の合計金額を取得.
        //****************************************
        Tbj01MediaPlanDAO dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> list = dao.findMediaPlanSumMoney(cond);
        result.setCarSum(list);

        //****************************************
        //媒体マスタより媒体を取得.
        //****************************************
        MediaListCondition mcond = new MediaListCondition();
        mcond.setHamid(cond.getUpdid());
        MediaListDAO mdao = MediaListDAOFactory.createMediaListDAO();
        List<MediaListVO> medialist = mdao.findMediaList(mcond);
        result.setMedia(medialist);

        return result;
    }

}
