package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC部門マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj06HcBumonDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj06HcBumonDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj06HcBumonDAO createMbj06HcBumonDAO() {
        return (Mbj06HcBumonDAO) DaoFactory.createDao(Mbj06HcBumonDAO.class);
    }

}
