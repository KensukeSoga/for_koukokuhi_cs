package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 車種担当者(素材)マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/24 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class Mbj52SzTntUserDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj52SzTntUserDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj52SzTntUserDAO createMbj52SzTntUserDAO() {
        return (Mbj52SzTntUserDAO) DaoFactory.createDao(Mbj52SzTntUserDAO.class);
    }

}
