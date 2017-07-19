package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 請求先グループを取得
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindBillGroupManager {


    /** シングルトンインスタンス */
    private static FindBillGroupManager _manager = new FindBillGroupManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindBillGroupManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static FindBillGroupManager getInstance() {
        return _manager;
    }

    /**
     * HC商品選択検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindBillGroupResult findBillGroup(Mbj26BillGroupCondition cond) throws HAMException {

        FindBillGroupResult result = new FindBillGroupResult();
        Mbj26BillGroupDAO dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();

        // HC商品選択取得
        result.setBillGroup(dao.selectVO(cond));

        return result;
    }
}
