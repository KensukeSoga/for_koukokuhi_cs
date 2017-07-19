package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;


/**
 * <P>
 * 制作原価変更点確認DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindProductionChangeCheckDAOFactory extends DaoFactory{


    /**
     * インスタンス生成禁止
     */
    private FindProductionChangeCheckDAOFactory() {
    }

    /**
     * 現在の制作原価取得DAOインスタンスを生成します
     *
     * @return 現在の制作原価取得DAOインスタンス
     */
    public static FindNowProductionDAO createFindNowProductionDao() {
        return new FindNowProductionDAO();
    }

    /**
     *  制作時の制作原価取得DAOインスタンスを生成します
     *
     *  @return 制作時の制作原価取得DAOインスタンス
     */
    public static FindBeforeProductionDAO createFindBeforeProductionDao() {
        return new FindBeforeProductionDAO();
    }

}
