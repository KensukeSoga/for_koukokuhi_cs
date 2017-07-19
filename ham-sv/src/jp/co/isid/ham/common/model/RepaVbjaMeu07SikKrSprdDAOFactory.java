package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 経理組織展開テーブルDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu07SikKrSprdDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu07SikKrSprdDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static RepaVbjaMeu07SikKrSprdDAO createRepaVbjaMeu07SikKrSprdDAO() {
        return (RepaVbjaMeu07SikKrSprdDAO) DaoFactory.createDao(RepaVbjaMeu07SikKrSprdDAO.class);
    }

}
