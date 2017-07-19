package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC媒体費作成DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCMediaCreationDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindHCMediaCreationDAOFactory() {
    }

    /**
     * 媒体・商品紐付けマスタ取得DAOのインスタンスを生成します
     * @return 媒体・商品紐付けマスタDAO
     */
    public static FindMediaProductDAO createFindMediaProductDao() {
        return new FindMediaProductDAO();
    }

    /**
     * 媒体費管理取得DAOのインスタンスを生成します
     * @return 媒体費管理取得DAO
     */
    public static FindMediaMngDAO createFindMediaMngDao() {
        return new FindMediaMngDAO();
    }

    /**
     * 媒体費見積明細管理取得DAOのインスタンスを生成します
     * @return 媒体費見積明細管理取得DAO
     */
    public static FindMediaMngEstDtlDAO createFindMediaMngEstDtlDao() {
        return new FindMediaMngEstDtlDAO();
    }

    /**
     * H新モデルコスト合計取得DAOのインスタンスを生成します
     * @return H新モデルコスト合計取得DAO
     */
    public static FindSumHmCostDAO createFindSumHmCostDao() {
        return new FindSumHmCostDAO();
    }

    /**
     * 見積案件/見積明細取得DAOのインスタンスを生成します
     * @return 見積案件/見積明細取得DAO
     */
    public static FindEstItemDtlDAO createFindEstItemDtlDao() {
        return new FindEstItemDtlDAO();
    }

    /**
     * 媒体費管理登録DAOのインスタンスを生成します
     * @return 媒体費管理登録DAO
     */
    public static RegisterMediaMngDAO createRegisterMediaMngDao() {
        return new RegisterMediaMngDAO();
    }

    /**
     * HC商品マスタ取得DAOインスタンスを生成します
     * @return HC商品マスタ取得DAO
     */
    public static FindHCProductDAO createFindHCProductDAO() {
        return new FindHCProductDAO();
    }

    /**
     * 見積案件取得DAOインスタンスを生成します
     * @return 見積案件取得DAO
     */
    public static FindHCEstimateListItemDAO createFindHCEstimateListItemDao() {
        return new FindHCEstimateListItemDAO();
    }

    /**
     * 見積詳細取得DAOインスタンスを生成します
     * @return 見積詳細取得DAO
     */
    public static FindEstimateDetailDAO createFindEstimateDetailDao() {
        return new FindEstimateDetailDAO();
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM見積書、請求明細書作成(媒体)取得DAOインスタンスを生成する
     * @return FindHMEstimateMediaDAO HM見積書、請求明細書作成(媒体)取得DAOインスタンス
     */
    public static FindHMEstimateMediaReportDAO createHMEstimateMediaReportDao() {
        return new FindHMEstimateMediaReportDAO();
    }

    /**
     * HM請求書作成(媒体)取得DAOインスタンスを生成する
     * @return HM請求書作成(媒体)取得DAOインスタンス
     */
    public static FindHMBillMediaReportDAO createHMBillMediaReportDao() {
        return new FindHMBillMediaReportDAO();
    }

    /**
     * HM合計請求書作成(媒体)取得DAOインスタンスを生成する
     * @return FindHMBillTotalMediaReport HM合計請求書作成(媒体)取得DAOインスタンス
     */
    public static FindHMBillTotalMediaReportDAO createFindHMBillTotalMediaReportDao() {
        return new FindHMBillTotalMediaReportDAO();
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

}
