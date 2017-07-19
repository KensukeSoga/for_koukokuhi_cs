package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 素材登録変更ログDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj25LogSozaiKanriDataDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj25LogSozaiKanriDataDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj25LogSozaiKanriDataDAO createTbj25LogSozaiKanriDataDAO() {
        return (Tbj25LogSozaiKanriDataDAO) DaoFactory.createDao(Tbj25LogSozaiKanriDataDAO.class);
    }

}
