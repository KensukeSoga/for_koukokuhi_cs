package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC見積一覧取得DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindHCEstimateListDAOFactory() {
    }

    /**
     * HC見積一覧(制作原価)取得DAOインスタンスを生成します
     *
     * @return HC見積一覧(制作原価)取得DAO
     */
    public static FindHCEstimateListCostDAO createFindHCEstimateListCostDao() {
        return new FindHCEstimateListCostDAO();
    }

    /**
     * HC見積一覧(制作費)取得DAOインスタンスを生成します
     *
     * @return HC見積一覧(制作費)取得DAO
     */
    public static FindHCEstimateListTotalDAO createFindHCEstimateListTotalDao() {
        return new FindHCEstimateListTotalDAO();
    }

    /**
     * HC見積一覧(見積案件)取得DAOインスタンスを生成します
     *
     * @return HC見積一覧(見積案件)取得DAO
     */
    public static FindHCEstimateListItemDAO createFindHCEstimateListItemDao() {
        return new FindHCEstimateListItemDAO();
    }
}
