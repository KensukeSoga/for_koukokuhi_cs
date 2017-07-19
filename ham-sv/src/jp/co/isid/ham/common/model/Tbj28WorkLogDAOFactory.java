package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 稼働ログDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj28WorkLogDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj28WorkLogDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj28WorkLogDAO createTbj28WorkLogDAO() {
        return (Tbj28WorkLogDAO) DaoFactory.createDao(Tbj28WorkLogDAO.class);
    }

}
