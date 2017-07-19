package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

final class FindCooperationDataDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindCooperationDataDAOFactory() {
    }

    /**
     * 値引き区分DAOインスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindDiscountFlgDAO createFindDiscountFlgDAO() {
        return (FindDiscountFlgDAO) DaoFactory.createDao(FindDiscountFlgDAO.class);
    }

    /**
     * 費目DAOインスタンスを生成
     * @return DAOインスタンス
     */
    public static FindItemDAO createFindItemDAO() {
        return (FindItemDAO) DaoFactory.createDao(FindItemDAO.class);
    }

    /**
     * 組織DAOインスタンスを生成
     * @return DAOインスタンス
     */
    public static FindSocietyDataDAO createFindSocietyDataDAO() {
        return(FindSocietyDataDAO) DaoFactory.createDao(FindSocietyDataDAO.class);
    }
}
