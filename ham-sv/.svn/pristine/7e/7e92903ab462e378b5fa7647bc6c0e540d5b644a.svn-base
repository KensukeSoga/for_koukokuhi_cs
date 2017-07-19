package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;


public class FindExpenseChangeCheckManager {



    /** シングルトンインスタンス */
    private static FindExpenseChangeCheckManager _manager = new FindExpenseChangeCheckManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindExpenseChangeCheckManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindExpenseChangeCheckManager getInstance() {
        return _manager;
    }


    /**
     * 制作原価変更情報を検索します
     *
     * @return FindProductionChangeCheckResult 制作原価変更情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindExpenseChangeCheckResult findProductionChangeCheck(FindExpenseChangeCheckCondition cond)
            throws HAMException {

        StringBuffer estDetailSeqno = new StringBuffer();

        //検索結果
        FindExpenseChangeCheckResult result = new FindExpenseChangeCheckResult();

        // ******************************************************
        // 作成時の情報取得
        // ******************************************************
        FindBeforeExpenseDAO beforeDao = FindExpenseChangeCheckDAOFactory.createFindBeforeExpenseDao();
        List<FindBeforeExpenseVO> beforelist = beforeDao.selectVO(cond);
        result.setBeforeExpense(beforelist);

        int index = 0;
        for (FindBeforeExpenseVO vo: beforelist) {
            if (index != 0) {
                estDetailSeqno.append(",");
            }
            estDetailSeqno.append("'");
            estDetailSeqno.append(vo.getSEQUENCENO().toString());
            estDetailSeqno.append("'");
            index++;
        }

       // ******************************************************
        // 現在の情報取得
        // ******************************************************
        if (estDetailSeqno.length() > 0) {
            FindNowExpenseDAO nowDao = FindExpenseChangeCheckDAOFactory.createFindNowExpenseDao();
            List<FindNowExpenseVO> nowlist = nowDao.selectVO(cond, estDetailSeqno.toString());
            result.setNowExpense(nowlist);
        }

        // ******************************************************
        // 画面項目表示列制御マスタ取得
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        return result;
    }

}
