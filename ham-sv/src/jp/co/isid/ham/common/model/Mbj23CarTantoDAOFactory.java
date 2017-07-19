package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 車種担当者マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj23CarTantoDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj23CarTantoDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj23CarTantoDAO createMbj23CarTantoDAO() {
        return (Mbj23CarTantoDAO) DaoFactory.createDao(Mbj23CarTantoDAO.class);
    }

}
