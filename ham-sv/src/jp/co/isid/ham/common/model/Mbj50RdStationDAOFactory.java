package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ラジオ局マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj50RdStationDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj50RdStationDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj50RdStationDAO createMbj50RdStationDAO() {
        return (Mbj50RdStationDAO) DaoFactory.createDao(Mbj50RdStationDAO.class);
    }

}
