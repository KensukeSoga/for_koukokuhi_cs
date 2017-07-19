package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 制作費設定DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementSettingDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindCostManagementSettingDAOFactory() {
    }

    /**
     * 制作費取込DAOインスタンスを生成します
     *
     * @return 制作費取込DAOインスタンス
     */
    public static FindCostManagementCaptureDAO createFindCMCaptureDao() {
        return new FindCostManagementCaptureDAO();
    }

    /**
     * 制作費車種DAOインスタンスを生成します
     *
     * @return 制作費車種DAOインスタンス
     */
    public static FindCostManagementCarDAO createFindCMCarDao() {
        return new FindCostManagementCarDAO();
    }

    /**
     * 制作費費車種出力設定DAOインスタンスを生成します
     *
     * @return 制作費費車種出力設定DAOインスタンス
     */
    public static FindCostManagementCaroutctrlDAO createFindCMCaroutctrlDao() {
        return new FindCostManagementCaroutctrlDAO();
    }

    /**
     * 制作費(出力オプション以外)DAOインスタンスを生成します
     *
     * @return 制作費(出力オプション以外)DAOインスタンス
     */
    public static FindCostManagementExceptOptDAO createFindCMExceptOptDao() {
        return new FindCostManagementExceptOptDAO();
    }

    /**
     * 変更確認データDAOインスタンスを作成します
     * @return
     */
    public static FindAfterUptakeCheckDAO createFindAfterUptakeCheckDao() {
        return new FindAfterUptakeCheckDAO();
    }

}
