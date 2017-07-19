package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 制作費変更点確認DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/12 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExpenseChangeCheckDAOFactory extends DaoFactory {


    /**
     * インスタンス生成禁止
     */
    private FindExpenseChangeCheckDAOFactory() {
    }

    /**
     * 現在の制作原価取得DAOインスタンスを生成します
     *
     * @return 現在の制作原価取得DAOインスタンス
     */
    public static FindNowExpenseDAO createFindNowExpenseDao() {
        return new FindNowExpenseDAO();
    }

    /**
     *  制作時の制作原価取得DAOインスタンスを生成します
     *
     *  @return 制作時の制作原価取得DAOインスタンス
     */
    public static FindBeforeExpenseDAO createFindBeforeExpenseDao() {
        return new FindBeforeExpenseDAO();
    }
}
