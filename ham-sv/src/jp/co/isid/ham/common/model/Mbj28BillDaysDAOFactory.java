package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 請求書出力年月マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj28BillDaysDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj28BillDaysDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj28BillDaysDAO createMbj28BillDaysDAO() {
        return (Mbj28BillDaysDAO) DaoFactory.createDao(Mbj28BillDaysDAO.class);
    }

}
