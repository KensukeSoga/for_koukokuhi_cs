package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * セキュリティ項目マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj43SecurityItemDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj43SecurityItemDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj43SecurityItemDAO createMbj43SecurityItemDAO() {
        return (Mbj43SecurityItemDAO) DaoFactory.createDao(Mbj43SecurityItemDAO.class);
    }

}
