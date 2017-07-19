package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 組織マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu00SikDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu00SikDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static RepaVbjaMeu00SikDAO createRepaVbjaMeu00SikDAO() {
        return (RepaVbjaMeu00SikDAO) DaoFactory.createDao(RepaVbjaMeu00SikDAO.class);
    }

}
