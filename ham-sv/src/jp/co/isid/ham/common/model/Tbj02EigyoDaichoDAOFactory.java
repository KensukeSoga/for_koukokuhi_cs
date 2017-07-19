package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 営業作業台帳DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj02EigyoDaichoDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj02EigyoDaichoDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj02EigyoDaichoDAO createTbj02EigyoDaichoDAO() {
        return (Tbj02EigyoDaichoDAO) DaoFactory.createDao(Tbj02EigyoDaichoDAO.class);
    }

}
