package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体パターン内容マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj36MediaPatternItemDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj36MediaPatternItemDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj36MediaPatternItemDAO createMbj36MediaPatternItemDAO() {
        return (Mbj36MediaPatternItemDAO) DaoFactory.createDao(Mbj36MediaPatternItemDAO.class);
    }

}
