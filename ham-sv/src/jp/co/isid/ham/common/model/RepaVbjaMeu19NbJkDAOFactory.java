package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 値引条件DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu19NbJkDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu19NbJkDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static RepaVbjaMeu19NbJkDAO createRepaVbjaMeu19NbJkDAO() {
        return (RepaVbjaMeu19NbJkDAO) DaoFactory.createDao(RepaVbjaMeu19NbJkDAO.class);
    }

}
