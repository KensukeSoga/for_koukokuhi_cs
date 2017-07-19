package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 請求明細書出力情報DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/25 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class FindBillStatementDataDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindBillStatementDataDAOFactory() {
    }

    /**
     * 請求明細書出力情報取得DAOインスタンスを生成
     *
     * @return DAOインスタンス
     */
    public static FindBillStatementDataDAO createFindBillStatementDataDAO() {
        return (FindBillStatementDataDAO) DaoFactory.createDao(FindBillStatementDataDAO.class);
    }

}
