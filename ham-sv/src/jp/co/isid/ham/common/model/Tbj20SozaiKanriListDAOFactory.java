package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 素材一覧DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj20SozaiKanriListDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj20SozaiKanriListDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj20SozaiKanriListDAO createTbj20SozaiKanriListDAO() {
        return (Tbj20SozaiKanriListDAO) DaoFactory.createDao(Tbj20SozaiKanriListDAO.class);
    }

}
