package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * カレンダーマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj21CalendarDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj21CalendarDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj21CalendarDAO createMbj21CalendarDAO() {
        return (Mbj21CalendarDAO) DaoFactory.createDao(Mbj21CalendarDAO.class);
    }

}
