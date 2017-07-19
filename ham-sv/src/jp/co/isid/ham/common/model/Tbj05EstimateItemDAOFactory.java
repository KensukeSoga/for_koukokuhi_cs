package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 見積案件DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj05EstimateItemDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj05EstimateItemDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj05EstimateItemDAO createTbj05EstimateItemDAO() {
        return (Tbj05EstimateItemDAO) DaoFactory.createDao(Tbj05EstimateItemDAO.class);
    }

}
