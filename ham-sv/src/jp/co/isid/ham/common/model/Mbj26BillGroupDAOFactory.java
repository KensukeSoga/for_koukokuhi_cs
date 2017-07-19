package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 請求グループマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj26BillGroupDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj26BillGroupDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj26BillGroupDAO createMbj26BillGroupDAO() {
        return (Mbj26BillGroupDAO) DaoFactory.createDao(Mbj26BillGroupDAO.class);
    }

}
