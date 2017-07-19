package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * CR制作費管理DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj11CrCreateDataDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj11CrCreateDataDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj11CrCreateDataDAO createTbj11CrCreateDataDAO() {
        return (Tbj11CrCreateDataDAO) DaoFactory.createDao(Tbj11CrCreateDataDAO.class);
    }

}
