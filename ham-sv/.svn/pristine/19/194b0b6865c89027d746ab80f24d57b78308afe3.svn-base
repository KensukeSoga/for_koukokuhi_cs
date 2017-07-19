package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 車種＆権限DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class CarListDAOFactory extends DaoFactory{

    /**
     * インスタンス生成禁止
     */
    private CarListDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static CarListDAO createCarListDAO() {
        return (CarListDAO) DaoFactory.createDao(CarListDAO.class);
    }
}
