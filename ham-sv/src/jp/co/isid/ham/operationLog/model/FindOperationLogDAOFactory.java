package jp.co.isid.ham.operationLog.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 稼働ログ取得DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/5/15 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindOperationLogDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private FindOperationLogDAOFactory() {
    }

    /**
     * 稼働ログ取得DAOインスタンスを生成します
     *
     * @return 稼働ログ取得DAOインスタンス
     */
    public static FindOperationLogDAO createFindOperationLogDAO() {
        return new FindOperationLogDAO();
    }
}
