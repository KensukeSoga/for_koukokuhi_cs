package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 費用企画NoマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj09HiyouDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj09HiyouDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj09HiyouDAO createMbj09HiyouDAO() {
        return (Mbj09HiyouDAO) DaoFactory.createDao(Mbj09HiyouDAO.class);
    }

}
