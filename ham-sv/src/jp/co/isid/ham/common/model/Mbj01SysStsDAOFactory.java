package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * システム使用状況DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj01SysStsDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj01SysStsDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj01SysStsDAO createMbj01SysStsDAO() {
        return (Mbj01SysStsDAO) DaoFactory.createDao(Mbj01SysStsDAO.class);
    }

}
