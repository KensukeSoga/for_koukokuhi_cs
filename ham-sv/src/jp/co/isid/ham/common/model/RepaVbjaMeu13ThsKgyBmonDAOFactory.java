package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 取引先部門DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu13ThsKgyBmonDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu13ThsKgyBmonDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static RepaVbjaMeu13ThsKgyBmonDAO createRepaVbjaMeu13ThsKgyBmonDAO() {
        return (RepaVbjaMeu13ThsKgyBmonDAO) DaoFactory.createDao(RepaVbjaMeu13ThsKgyBmonDAO.class);
    }

}
