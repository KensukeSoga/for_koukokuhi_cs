package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC見積作成取得DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/14 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateCreationDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindHCEstimateCreationDAOFactory() {
    }

    /**
     * 見積案件取得DAOインスタンスを生成します
     * @return 見積案件取得DAOインスタンス
     */
    public static FindHCEstimateListItemDAO createFindHCEstimateListItemDao() {
        return new FindHCEstimateListItemDAO();
    }

    /**
     * 見積詳細取得DAOインスタンスを生成します
     * @return 見積詳細取得DAOインスタンス
     */
    public static FindEstimateDetailDAO createFindEstimateDetailDao() {
        return new FindEstimateDetailDAO();
    }

    /**
     * 見積案件CR制作費DAOインスタンスを生成します
     * @return 見積案件CR制作費DAOインスタンス
     */
    public static FindEstimateCreateDAO createFindEstimateCreateDao() {
        return new FindEstimateCreateDAO();
    }

    /**
     * HC見積作成(制作費取込)取得DAOインスタンスを生成します
     * @return HC見積作成(制作費取込)取得DAOインスタンス
     */
    public static FindHCEstimateCreationCaptureDAO createFindHCEstimateCreationCaptureDao() {
        return new FindHCEstimateCreationCaptureDAO();
    }

    /**
     * HC商品マスタ取得DAOインスタンスを生成します
     * @return HC商品マスタ取得DAOインスタンス
     */
    public static FindHCProductDAO createFindHCProductDao() {
        return new FindHCProductDAO();
    }

    /**
     * CR制作費取得DAOインスタンスを生成します
     * @return CR制作費取得DAOインスタンス
     */
    public static FindHCEstimateCreationCrDAO createFindCrCreateDataDao() {
        return new FindHCEstimateCreationCrDAO();
    }

    /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM見積書取得DAOインスタンスを生成する
     * @return FindHMEstimateListItemDAO HM見積書取得DAOインスタンス
     */
    public static FindHMEstimateItemDAO createFindHMEstimateItemListDao() {
        return new FindHMEstimateItemDAO();
    }

    /**
     * HM見積明細取得DAOインスタンスを生成する
     * @return FindHMEstimateDetailDAO HM見積明細取得DAOインスタンス
     */
    public static FindHMEstimateDetailDAO createFindHMEstimateDetailDao() {
        return new FindHMEstimateDetailDAO();
    }

    /**
     * HM見積案件CR制作費取得DAOインスタンスを生成する
     * @return FindHMEstimateCreateDAO HM見積案件CR制作費取得DAOインスタンス
     */
    public static FindHMEstimateCreateDAO createFindHMEstimateCreateDao() {
        return new FindHMEstimateCreateDAO();
    }

    /**
     * HM見積作成(制作費取込)取得DAOインスタンスを生成する
     * @return FindHMEstimateCreationCaptureDAO HM見積作成(制作費取込)取得DAOインスタンス
     */
    public static FindHMEstimateCreationCaptureDAO createFindHMEstimateCreationCaptureDao() {
        return new FindHMEstimateCreationCaptureDAO();
    }

    /**
     * CR制作費(HM)取得DAOインスタンスを生成する
     * @return FindHMEstimateCreationCrDAO CR制作費(HM)取得DAOインスタンス
     */
    public static FindHMEstimateCreationCrDAO createFindHMEstimateCreationCrDao() {
        return new FindHMEstimateCreationCrDAO();
    }

    /**
     * HM見積一覧(見積案件)取得DAOインスタンスを生成する
     * @return FindHMBillItemDAO HM見積一覧(見積案件)取得DAOインスタンス
     */
    public static FindHMBillItemDAO createFindHMBillItemDao() {
        return new FindHMBillItemDAO();
    }

    /**
     * HM見積一覧(見積明細)取得DAOインスタンスを生成する
     * @return FindHMBillDetailDAO HM見積一覧(見積明細)取得DAOインスタンス
     */
    public static FindHMBillDetailDAO createFindHMBillDetailDao() {
        return new FindHMBillDetailDAO();
    }

    /**
     * HM請求書(CR制作費)取得DAOインスタンスを生成する
     * @return FindHMBillCreateDAO HM請求書(CR制作費)取得DAOインスタンス
     */
    public static FindHMBillCreateDAO createFindHMBillCreateDao() {
        return new FindHMBillCreateDAO();
    }

    /**
     * HM請求書(制作費取込)取得検索DAOインスタンスを生成する
     * @return FindHMBillCreationCaptureDAO HM請求書(制作費取込)取得検索DAOインスタンス
     */
    public static FindHMBillCreationCaptureDAO createFindHMBillCreationCaptureDao() {
        return new FindHMBillCreationCaptureDAO();
    }

    /**
     * HM請求書(CR制作費)取得検索DAOインスタンスを生成する
     * @return FindHMBillCreationCrDAO HM請求書(CR制作費)取得検索DAOインスタンス
     */
    public static FindHMBillCreationCrDAO createFindHMBillCreationCrDao() {
        return new FindHMBillCreationCrDAO();
    }

    /**
     * HM請求書(見積明細出力順SEQNO)取得検索DAOインスタンスを生成する
     * @return FindHMBillDetailSeqNoDAO HM請求書(見積明細出力順SEQNO)取得検索DAO
     */
    public static FindHMBillSeqNoDAO createFindHMBillDetailSeqNoDao() {
        return new FindHMBillSeqNoDAO();
    }

    /**
     * HM請求データ作成検索DAOインスタンスを生成する
     * @return FindHMBillDataDAO HM請求データ作成検索DAO
     */
    public static FindHMBillDataDAO createFindHMBillDataDao() {
        return new FindHMBillDataDAO();
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fuiimoto ADD End */

}
