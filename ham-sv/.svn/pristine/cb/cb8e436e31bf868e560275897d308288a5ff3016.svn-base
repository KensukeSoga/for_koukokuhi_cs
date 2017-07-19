package jp.co.isid.ham.billing.model;

/**
 * <P>
 * コスト管理表出力データ検索のDAOファクトリ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 H.Watabe)<BR>
 * </P>
 * @author H.Watabe
 */
public class FindCostManagementReportDAOFactory {

    /**
     * インスタンス生成禁止
     */
    private FindCostManagementReportDAOFactory() {
    }

    /**
     * 媒体コストDAOを取得
     * @return 媒体コストDAO
     */
    public static FindMediaCostDAO createFindMediaCostDAO() {
        return new FindMediaCostDAO();
    }

    /**
     * 制作費DAOを取得
     * @return 制作費DAO
     */
    public static FindCreateCostDAO createFindCreateCostDAO() {
        return new FindCreateCostDAO();
    }

    /**
     * 制作費取込DAOを取得
     * @return
     */
    public static FindCreateUptakeCostDAO createFindCreateUptakeCostDAO() {
        return new FindCreateUptakeCostDAO();
    }
}
