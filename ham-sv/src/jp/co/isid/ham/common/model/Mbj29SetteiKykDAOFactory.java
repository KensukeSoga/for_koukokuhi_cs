package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 設定局マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj29SetteiKykDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj29SetteiKykDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj29SetteiKykDAO createMbj29SetteiKykDAO() {
        return (Mbj29SetteiKykDAO) DaoFactory.createDao(Mbj29SetteiKykDAO.class);
    }

}
