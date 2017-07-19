/**
 *
 */
package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報検索DAOファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/11 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class FindRdTime2AccountBookDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindRdTime2AccountBookDAOFactory() {
    }

    /**
     * ラジオタイムインポートDAOインスタンスを生成する
     * @return RdTimeImportRegisterDAO ラジオタイムインポートDAOインスタンス
     */
    public static FindRdTime2AccountBookDAO createFindRdTime2AccountBookDAO() {
        return (FindRdTime2AccountBookDAO) DaoFactory.createDao(FindRdTime2AccountBookDAO.class);
    }

}
