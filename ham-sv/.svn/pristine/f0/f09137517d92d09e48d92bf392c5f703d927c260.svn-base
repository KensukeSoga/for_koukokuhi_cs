package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindAccountBookOutputManager {

    /** シングルトンインスタンス */
    private static FindAccountBookOutputManager _manager = new FindAccountBookOutputManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindAccountBookOutputManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindAccountBookOutputManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindAccountBookOutputResult findAccountBookOutput(FindAccountBookOutputCondition cond)
            throws HAMException {


        //検索結果
        FindAccountBookOutputResult result = new FindAccountBookOutputResult();

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

        return result;
        }

    public FindAccountBookOutPutDataResult findAuthorityAccountBookReport(FindAccountBookOutPutDataCondition cond)
           throws HAMException {

        //検索結果
        FindAccountBookOutPutDataResult result = new FindAccountBookOutPutDataResult();

        // ******************************************************
        // 営業作業台帳帳票情報の取得
        // ******************************************************
        FindAuthorityAccountbookReportDAO accountbookrepdao = FindAuthorityAccountBookDAOFactory.createFindAuthorityAccountbookReportDAO();
        List<FindAuthorityAccountBookReportVO> acbreplist = accountbookrepdao.findAuthorityAccountBookReportByCond(cond);
        result.setAuthorityAccountBookReport(acbreplist);

        //--過去の遺産--//

        // ******************************************************
        // 媒体情報の取得
        // ******************************************************
        //Mbj03MediaDAO mediadao = Mbj03MediaDAOFactory.createMbj03MediaDAO();
        //Mbj03MediaCondition mediacond = new Mbj03MediaCondition();
        //result.setMbj03Media(mediadao.selectVO(mediacond));

        // ******************************************************
        // 車種情報の取得
        // ******************************************************
        //Mbj05CarDAO cardao = Mbj05CarDAOFactory.createMbj05CarDAO();
        //Mbj05CarCondition carcond = new Mbj05CarCondition();
        //result.setMbj05Car(cardao.selectVO(carcond));

        //--過去の遺産--//

        return result;
    }

}
