package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 営業作業台帳更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
final class AccountBookRegisterDAOFactory extends DaoFactory{
    /**
     * インスタンス化を禁止します
     */
    private AccountBookRegisterDAOFactory() {
    }

    /**
     * 営業作業台帳更新DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static AccountBookRegisterDAO createAccountBookRegisterDAO() {
        return (AccountBookRegisterDAO) DaoFactory.createDao(AccountBookRegisterDAO.class);
    }


    public static AccountBookLogRegisterDAO createAccountBookLogRegisterDAO() {
        return (AccountBookLogRegisterDAO) DaoFactory.createDao(AccountBookLogRegisterDAO.class);
    }

    /**
     * ソート順取得DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static FindAccountBookSortNoDAO createFindAccountBookSortNoDAO() {
        return (FindAccountBookSortNoDAO) DaoFactory.createDao(FindAccountBookSortNoDAO.class);
    }

}
