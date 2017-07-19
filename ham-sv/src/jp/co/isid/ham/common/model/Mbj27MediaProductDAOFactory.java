package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体・商品紐付けマスタDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj27MediaProductDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Mbj27MediaProductDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Mbj27MediaProductDAO createMbj27MediaProductDAO() {
        return (Mbj27MediaProductDAO) DaoFactory.createDao(Mbj27MediaProductDAO.class);
    }

}
