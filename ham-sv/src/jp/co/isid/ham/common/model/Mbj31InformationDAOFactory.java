package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * インフォメーションマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj31InformationDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj31InformationDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj31InformationDAO createMbj31InformationDAO() {
        return (Mbj31InformationDAO) DaoFactory.createDao(Mbj31InformationDAO.class);
    }

}
