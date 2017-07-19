package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 素材登録DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj18SozaiKanriDataDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj18SozaiKanriDataDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj18SozaiKanriDataDAO createTbj18SozaiKanriDataDAO() {
        return (Tbj18SozaiKanriDataDAO) DaoFactory.createDao(Tbj18SozaiKanriDataDAO.class);
    }

}
