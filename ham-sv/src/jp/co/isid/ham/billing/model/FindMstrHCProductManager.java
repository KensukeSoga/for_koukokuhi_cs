package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj08HcProductCondition;
import jp.co.isid.ham.common.model.Mbj08HcProductDAO;
import jp.co.isid.ham.common.model.Mbj08HcProductDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * HC商品マスタを取得する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMstrHCProductManager {

    /** シングルトンインスタンス */
    private static FindMstrHCProductManager _manager = new FindMstrHCProductManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindMstrHCProductManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static FindMstrHCProductManager getInstance() {
        return _manager;
    }

    /**
     * 商品マスタ取得(商品コード手入力時)
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindMstrHCProductResult findMstrHCProduct(Mbj08HcProductCondition cond) throws HAMException {

        FindMstrHCProductResult result = new FindMstrHCProductResult();

        Mbj08HcProductDAO mbj08Dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();
        result.setProduct(mbj08Dao.selectVO(cond));

        return result;
    }

    /**
     * HC商品マスタ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHCProductResult findHCProduct(FindHCProductCondition cond) throws HAMException {

        FindHCProductResult result = new FindHCProductResult();

        // HC商品マスタ取得
        FindHCProductDAO productDao = FindHCEstimateCreationDAOFactory.createFindHCProductDao();
        result.setProduct(productDao.selectVO(cond));

        return result;
    }

}
