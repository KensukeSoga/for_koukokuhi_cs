package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 最終更新者情報のファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class FindLastUpdAccountBookDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindLastUpdAccountBookDAOFactory() {
    }

    /**
     * 最終更新者情報DAOインスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindLastUpdAccountBookDAO createFindLastUpdAccountBookDAO() {
        return (FindLastUpdAccountBookDAO) DaoFactory.createDao(FindLastUpdAccountBookDAO.class);
    }

}
