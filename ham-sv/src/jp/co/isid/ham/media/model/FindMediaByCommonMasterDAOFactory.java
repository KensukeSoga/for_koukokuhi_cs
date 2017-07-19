package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

final class FindMediaByCommonMasterDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindMediaByCommonMasterDAOFactory() {
    }

    /**
     * 媒体検索インスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindMediaByCommonMasterDAO createFindAuthorityAccountBookDAO() {
        return (FindMediaByCommonMasterDAO) DaoFactory.createDao(FindMediaByCommonMasterDAO.class);
    }
}
