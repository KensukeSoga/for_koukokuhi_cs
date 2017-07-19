package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 依頼先DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/08/02 T.Fujiyoshi)<BR>
 * </P>
 *
 * @author T.Fujiyoshi
 */
public class FindContactRequestDAOFactory extends DaoFactory {

    private FindContactRequestDAOFactory() {
    }

    /**
     * 依頼先DAOインスタンスを生成します
     *
     * @return 依頼先DAO
     */
    public static FindContactRequestDAO createFindContactRequestDAO() {
        return (FindContactRequestDAO) DaoFactory.createDao(FindContactRequestDAO.class);
    }

}
