package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体権限マスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj10MediaSecDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj10MediaSecDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj10MediaSecDAO createMbj10MediaSecDAO() {
        return (Mbj10MediaSecDAO) DaoFactory.createDao(Mbj10MediaSecDAO.class);
    }

}
