package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class FindExcelOutSettingManager {


    /** シングルトンインスタンス */
    private static FindExcelOutSettingManager _manager = new FindExcelOutSettingManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindExcelOutSettingManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindExcelOutSettingManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindExcelOutSettingResult findExcelOutSetting(FindExcelOutSettingCondition cond)
            throws HAMException {

        //検索結果
        FindExcelOutSettingResult result = new FindExcelOutSettingResult();

        // ******************************************************
        // 媒体出力設定の取得
        // ******************************************************
        OutputMediaDAO mediadao = OutputMediaDAOFactory.createOutputMediaDAO();
        List<OutputMediaVO> medialist = mediadao.findOutputMediaList(cond);
        result.setOutputMedia(medialist);

        // ******************************************************
        // 車種出力設定の取得
        // ******************************************************
        OutputCarDAO cardao = OutputCarDAOFactory.createOutputCarDAO();
        List<OutputCarVO> carlist = cardao.findOutputCarList(cond);
        result.setOutputCar(carlist);

        // ******************************************************
        // 出力しない媒体の取得
        // ******************************************************
        MediaNotOutDAO nooutmediadao = MediaNotOutDAOFactory.createMediaNotOutDAO();
        List<Mbj03MediaVO> nooutmedialist = nooutmediadao.findNotOutMediaList(cond);
        result.setMbj03Media(nooutmedialist);

        // ******************************************************
        // 出力しない車種の取得
        // ******************************************************
        CarNotOutDAO nooutcardao = CarNotOutDAOFactory.createCarNotOutDAO();
        List<Mbj05CarVO> nooutcarist = nooutcardao.findNotOutCarList(cond);
        result.setMbj05Car(nooutcarist);

        return result;
    }
}
