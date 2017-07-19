package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 汎用コメントDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj32CompurposeDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj32CompurposeDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj32CompurposeDAO createTbj32CompurposeDAO() {
        return (Tbj32CompurposeDAO) DaoFactory.createDao(Tbj32CompurposeDAO.class);
    }

}
