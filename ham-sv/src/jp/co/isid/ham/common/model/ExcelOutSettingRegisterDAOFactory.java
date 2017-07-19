package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 帳票出力設定更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class ExcelOutSettingRegisterDAOFactory extends DaoFactory{

    private ExcelOutSettingRegisterDAOFactory() {
    }

    /**
     * 帳票出力媒体登録DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static ExcelOutMediaRegisterDAO createExcelOutMediaRegisterDAO() {
        return (ExcelOutMediaRegisterDAO) DaoFactory.createDao(ExcelOutMediaRegisterDAO.class);
    }

    /**
     * 帳票出力車種登録DAOインスタンスを生成します
     * @return DAOインスタンス
     */
    public static ExcelOutCarRegisterDAO createExcelOutCarRegisterDAO() {
        return (ExcelOutCarRegisterDAO) DaoFactory.createDao(ExcelOutCarRegisterDAO.class);
    }
}
