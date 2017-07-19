package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * セキュリティマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj42SecurityDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj42SecurityDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj42SecurityDAO createMbj42SecurityDAO() {
        return (Mbj42SecurityDAO) DaoFactory.createDao(Mbj42SecurityDAO.class);
    }

}
