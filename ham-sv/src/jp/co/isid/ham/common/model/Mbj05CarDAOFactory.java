package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 車種マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj05CarDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj05CarDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj05CarDAO createMbj05CarDAO() {
        return (Mbj05CarDAO) DaoFactory.createDao(Mbj05CarDAO.class);
    }

}
