/**
 *
 */
package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * TVTimeインポート時のDAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/23 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class TVTImportRegisterDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private TVTImportRegisterDAOFactory() {
    }

    /**
     * 営業作業台帳更新DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static TVTImportRegisterDAO createTVTImportRegisterDAO() {
        return (TVTImportRegisterDAO) DaoFactory.createDao(TVTImportRegisterDAO.class);
    }

}
