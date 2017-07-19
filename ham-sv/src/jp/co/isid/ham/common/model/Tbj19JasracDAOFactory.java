package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * JASRACDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj19JasracDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj19JasracDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj19JasracDAO createTbj19JasracDAO() {
        return (Tbj19JasracDAO) DaoFactory.createDao(Tbj19JasracDAO.class);
    }

}
