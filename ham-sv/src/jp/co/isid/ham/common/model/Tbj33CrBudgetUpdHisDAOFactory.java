package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * CR予算更新履歴DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj33CrBudgetUpdHisDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj33CrBudgetUpdHisDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj33CrBudgetUpdHisDAO createTbj33CrBudgetUpdHisDAO() {
        return (Tbj33CrBudgetUpdHisDAO) DaoFactory.createDao(Tbj33CrBudgetUpdHisDAO.class);
    }

}
