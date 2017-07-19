package jp.co.isid.ham.production.model;

import jp.co.isid.nj.integ.DaoFactory;

public class FindCarSortedByNameDAOFactory extends DaoFactory{

    /**
     * インスタンス生成禁止
     */
    private FindCarSortedByNameDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static FindCarSortedByNameDAO createFindCarSortedByNameDAO() {
        return (FindCarSortedByNameDAO) DaoFactory.createDao(FindCarSortedByNameDAO.class);
    }
}
