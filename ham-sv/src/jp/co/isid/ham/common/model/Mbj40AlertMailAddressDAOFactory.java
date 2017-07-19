package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * メール配信マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj40AlertMailAddressDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj40AlertMailAddressDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj40AlertMailAddressDAO createMbj40AlertMailAddressDAO() {
        return (Mbj40AlertMailAddressDAO) DaoFactory.createDao(Mbj40AlertMailAddressDAO.class);
    }

}
