package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.model.base.HAMException;

public class FindBillStatementManager {

    /** シングルトンインスタンス */
    private static FindBillStatementManager _manager = new FindBillStatementManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindBillStatementManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindBillStatementManager getInstance() {
        return _manager;
    }

    /**
     * 請求明細書表示情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindBillStatementResult findBillStatement(FindBillStatementCondition cond)
            throws HAMException {


        //検索結果
        FindBillStatementResult result = new FindBillStatementResult();

        // ******************************************************
        // 営業作業台帳情報の取得
        // ******************************************************
        FindLastUpdAccountBookDAO abdao = FindLastUpdAccountBookDAOFactory.createFindLastUpdAccountBookDAO();
        result.setTbj02EigyoDaicho(abdao.findLastUpdAccountBook(cond));

        // 車種一覧や機能制御は、初回起動時のみ取得
        if (cond.getLoadFlg()) {

            // ******************************************************
            // 車種一覧取得
            // ******************************************************
            CarListDAO cldao =CarListDAOFactory.createCarListDAO();
            CarListCondition clcond = new CarListCondition();
            clcond.setHamid(cond.getHamid());
            clcond.setSecType("0");
            result.setCarList(cldao.findCarList(clcond));

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
        }

        return result;
    }

    /**
     * 請求明細書に出力する情報を取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindBillStatementDataResult findBillStatementOutData(FindBillStatementDataCondition cond)
            throws HAMException {

        //検索結果
        FindBillStatementDataResult result = new FindBillStatementDataResult();

        // ******************************************************
        // 請求明細書出力情報の取得
        // ******************************************************
        FindBillStatementDataDAO billdao = FindBillStatementDataDAOFactory.createFindBillStatementDataDAO();
        List<FindBillStatementDataVO> billlist =billdao.findBillOutputData(cond);
        result.setTbj02EigyoDaicho(billlist);

        return result;
    }
}
