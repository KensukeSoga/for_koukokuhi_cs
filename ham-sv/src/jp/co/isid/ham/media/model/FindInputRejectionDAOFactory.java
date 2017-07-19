package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 入力拒否データ更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/17 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class FindInputRejectionDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindInputRejectionDAOFactory() {
    }

    /**
     * 入力拒否データ検索DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static FindInputRejectionDAO createFindInputRejectionDAO() {
        return (FindInputRejectionDAO) DaoFactory.createDao(FindInputRejectionDAO.class);
    }
}
