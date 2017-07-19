package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 見積案件CR制作費DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj07EstimateCreateDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj07EstimateCreateDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj07EstimateCreateDAO createTbj07EstimateCreateDAO() {
        return (Tbj07EstimateCreateDAO) DaoFactory.createDao(Tbj07EstimateCreateDAO.class);
    }

}
