package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * CR区分マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj17CrDivisionDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj17CrDivisionDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj17CrDivisionDAO createMbj17CrDivisionDAO() {
        return (Mbj17CrDivisionDAO) DaoFactory.createDao(Mbj17CrDivisionDAO.class);
    }

}
