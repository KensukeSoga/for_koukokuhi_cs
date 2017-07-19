package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.FindContactRequestDAO;
import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 営業作業台帳DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
final class FindAuthorityAccountBookDAOFactory extends DaoFactory{

    /**
     * インスタンス化を禁止します
     */
    private FindAuthorityAccountBookDAOFactory() {
    }

    /**
     * 営業作業台帳取得DAOインスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindAuthorityAccountBookDAO createFindAuthorityAccountBookDAO() {
        return (FindAuthorityAccountBookDAO) DaoFactory.createDao(FindAuthorityAccountBookDAO.class);
    }

    /**
     * 媒体種別取得DAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindMediaCategoryDAO createFindMediaCategoryDAO() {
        return (FindMediaCategoryDAO)DaoFactory.createDao(FindMediaCategoryDAO.class);
    }

    /**
     * 営業作業台帳のキャンペーン取得DAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindAccountBookCampaignDAO createFindAccountBookCampaignDAO() {
        return (FindAccountBookCampaignDAO)DaoFactory.createDao(FindAccountBookCampaignDAO.class);
    }

     /**
     * 内容費目取得DAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindExpenseItemListDAO createFindExpenseitemListDAO() {
        return (FindExpenseItemListDAO)DaoFactory.createDao(FindExpenseItemListDAO.class);
    }

    /**
     * スペースDAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindSpaceDAO createFindSpaceDAO() {
        return (FindSpaceDAO)DaoFactory.createDao(FindSpaceDAO.class);
    }

    /**
     * 営業作業台帳帳票DAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindAuthorityAccountbookReportDAO createFindAuthorityAccountbookReportDAO() {
        return (FindAuthorityAccountbookReportDAO)DaoFactory.createDao(FindAuthorityAccountbookReportDAO.class);
    }

    /**
     * スペースマスタDAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindSpaceMasterDAO createSpaceMasterDAO() {
        return (FindSpaceMasterDAO)DaoFactory.createDao(FindSpaceMasterDAO.class);
    }

    /**
     * 依頼先DAOインスタンスを生成します
     *
     * @return 依頼先DAO
     */
    public static FindContactRequestDAO createFindContactRequestDAO() {
        return (FindContactRequestDAO)DaoFactory.createDao(FindContactRequestDAO.class);
    }

    /**
     * 依頼先絞り込み取得DAOインスタンスを生成
     *
     * @return 依頼先絞り込み取得DAOインスタンス
     */
    public static FindContactRequestNarrowingDAO createFindContactRequestNarrowingDAO() {
        return (FindContactRequestNarrowingDAO)DaoFactory.createDao(FindContactRequestNarrowingDAO.class);
    }
}