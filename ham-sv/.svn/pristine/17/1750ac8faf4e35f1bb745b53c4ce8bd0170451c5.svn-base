package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * HC商品選択データを管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class HCItemSelectionManager {

    /** シングルトンインスタンス */
    private static HCItemSelectionManager _manager = new HCItemSelectionManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private HCItemSelectionManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static HCItemSelectionManager getInstance() {
        return _manager;
    }

    /**
     * HC商品選択マスタ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHCItemSelectionMstrResult findHCItemSelectionMstr(FindHCItemSelectionMstrCondition cond) throws HAMException {

        FindHCItemSelectionMstrResult result = new FindHCItemSelectionMstrResult();

        // 画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // HC商品マスタ取得
        FindHCItemSelectionMstrDAO isDao = FindHCItemSelectionDAOFactory.createFindHCItemSelectionMstrDao();
        result.setProduct(isDao.findPruduct(cond));


        return result;
    }

    /**
     * HC商品選択検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHCItemSelectionResult findHCItemSelection(FindHCItemSelectionCondition cond) throws HAMException {

        FindHCItemSelectionResult result = new FindHCItemSelectionResult();
        FindHCItemSelectionDAO isDao = FindHCItemSelectionDAOFactory.createFindHCItemSelectionDao();

        // HC商品選択取得
        result.setHCItemSelection(isDao.selectVO(cond));


        return result;
    }

}
