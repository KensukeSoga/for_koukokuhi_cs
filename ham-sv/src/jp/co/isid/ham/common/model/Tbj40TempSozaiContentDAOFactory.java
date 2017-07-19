package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 契約仮素材紐付けDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj40TempSozaiContentDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj40TempSozaiContentDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj40TempSozaiContentDAO createTbj40TempSozaiContentDAO() {
        return (Tbj40TempSozaiContentDAO) DaoFactory.createDao(Tbj40TempSozaiContentDAO.class);
    }

}
