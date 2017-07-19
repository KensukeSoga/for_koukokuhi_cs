package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC見積作成登録DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/3 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCEstimateCreationDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private RegisterHCEstimateCreationDAOFactory() {
    }

    /**
     * 見積案件CR制作費作成(制作費取込)DAOのインスタンスを生成します
     *
     * @return 見積案件CR制作費作成(制作費取込)DAO
     */
    public static Tbj07EstimateCreateCostDAO createTbj07EstimateCreateCostDao() {
        return new Tbj07EstimateCreateCostDAO();
    }

    /**
     * 見積案件CR制作費作成(CR制作費管理)DAOのインスタンスを生成します
     *
     * @return 見積案件CR制作費作成(CR制作費管理)DAO
     */
    public static Tbj07EstimateCreateCrDAO createTbj07EstimateCreateCrDao() {
        return new Tbj07EstimateCreateCrDAO();
    }

}
