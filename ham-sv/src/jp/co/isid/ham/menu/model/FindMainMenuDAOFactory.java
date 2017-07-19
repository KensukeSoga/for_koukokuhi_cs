package jp.co.isid.ham.menu.model;

import jp.co.isid.nj.integ.DaoFactory;

public class FindMainMenuDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindMainMenuDAOFactory() {
    }

    /**
     * ログインDAOインスタンスを生成する
     *
     * @return ログインDAOインスタンス
     */
    public static LoginDAO createLoginDAO() {
        return (LoginDAO) DaoFactory.createDao(LoginDAO.class);
    }

    /**
     * ユーザーCR制作費管理DAOインスタンスを生成する
     *
     * @return ユーザーCR制作費管理DAOインスタンス
     */
    public static UserCrCreateDataDAO createUserCrCreateDataDAO() {
        return (UserCrCreateDataDAO) DaoFactory.createDao(UserCrCreateDataDAO.class);
    }

}
