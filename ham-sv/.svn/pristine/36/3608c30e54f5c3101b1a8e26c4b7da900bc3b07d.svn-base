package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体状況管理DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/18 HLC M.Tsuchiya)<BR>
 * </P>
 *
 * @author HLC M.Tsuchiya
 */

final class FindMediaPlanDAOFactory extends DaoFactory{

    /**
     * インスタンス化を禁止します
     */
    private FindMediaPlanDAOFactory() {
    }

    /**
     * 媒体状況管理DAOインスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindMediaPlanDAO createFindMediaPlanDAO() {
        return (FindMediaPlanDAO) DaoFactory.createDao(FindMediaPlanDAO.class);
    }

//    /**
//     * 媒体種別取得DAOインスタンスを作成
//     *
//     * @return DAOインスタンス
//     */
//    public static FindMediaCategoryDAO createFindMediaCategoryDAO() {
//        return (FindMediaCategoryDAO)DaoFactory.createDao(FindMediaCategoryDAO.class);
//    }


    /**
     * 媒体状況管理のキャンペーン取得DAOインスタンスを作成
     *
     * @return DAOインスタンス
     */
    public static FindMediaPlanCampaignDAO createFindMediaPlanCampaignDAO() {
        return (FindMediaPlanCampaignDAO)DaoFactory.createDao(FindMediaPlanCampaignDAO.class);
    }
}
