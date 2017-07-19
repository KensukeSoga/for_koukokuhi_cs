package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 仮素材登録DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj36TempSozaiKanriDataDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj36TempSozaiKanriDataDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj36TempSozaiKanriDataDAO createTbj36TempSozaiKanriDataDAO() {
        return (Tbj36TempSozaiKanriDataDAO) DaoFactory.createDao(Tbj36TempSozaiKanriDataDAO.class);
    }

}
