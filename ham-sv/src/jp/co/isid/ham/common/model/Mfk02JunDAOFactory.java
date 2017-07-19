package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ユニットNo.マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mfk02JunDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mfk02JunDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mfk02JunDAO createMfk02JunDAO() {
        return (Mfk02JunDAO) DaoFactory.createDao(Mfk02JunDAO.class);
    }

}
