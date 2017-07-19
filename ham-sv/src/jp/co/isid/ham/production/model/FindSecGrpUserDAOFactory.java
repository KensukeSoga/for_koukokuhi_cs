package jp.co.isid.ham.production.model;

import jp.co.isid.nj.integ.DaoFactory;


/**
 * <P>
 * セキュリティグループユーザー検索DAOファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/23 HLC K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */
public class FindSecGrpUserDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindSecGrpUserDAOFactory() {
    }

    /**
     * TVCM素材一覧契約情報検索インスタンスを生成します
     * @return TTVCM素材一覧契約情報検索DAOインスタンス
     */
    public static FindSecGrpUserDAO createFindSecGrpUserDAOFactory() {
        return (FindSecGrpUserDAO) DaoFactory.createDao(FindSecGrpUserDAO.class);
    }
}
