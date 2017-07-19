package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HAM取引先マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj46ThsDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj46ThsDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj46ThsDAO createMbj46ThsDAO() {
        return (Mbj46ThsDAO) DaoFactory.createDao(Mbj46ThsDAO.class);
    }

}
