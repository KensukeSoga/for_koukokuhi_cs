package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;


public class FindProductionChangeCheckManager {


    /** シングルトンインスタンス */
    private static FindProductionChangeCheckManager _manager = new FindProductionChangeCheckManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindProductionChangeCheckManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindProductionChangeCheckManager getInstance() {
        return _manager;
    }


    /**
     * 制作原価変更情報を検索します
     *
     * @return FindProductionChangeCheckResult 制作原価変更情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindProductionChangeCheckResult findProductionChangeCheck(FindProductionChangeCheckCondition cond)
            throws HAMException {

        StringBuffer estDetailSeqno = new StringBuffer();

        //検索結果
        FindProductionChangeCheckResult result = new FindProductionChangeCheckResult();

        // ******************************************************
        // 作成時の情報取得
        // ******************************************************
        FindBeforeProductionDAO beforeDao = FindProductionChangeCheckDAOFactory.createFindBeforeProductionDao();
        List<FindBeforeProductionVO> beforelist = beforeDao.selectVO(cond);
        result.setBeforeProduction(beforelist);

        int index = 0;
        for (FindBeforeProductionVO vo: beforelist) {
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
            FindNowProductionDAO nowDao = FindProductionChangeCheckDAOFactory.createFindNowProductionDao();
            List<FindNowProductionVO> nowlist = nowDao.selectVO(cond, estDetailSeqno.toString());
            result.setNowProduction(nowlist);
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
