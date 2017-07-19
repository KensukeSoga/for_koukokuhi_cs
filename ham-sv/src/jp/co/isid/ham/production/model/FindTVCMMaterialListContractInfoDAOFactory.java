package jp.co.isid.ham.production.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * TVCM素材一覧契約情報検索DAOファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/10 HLC K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */
public class FindTVCMMaterialListContractInfoDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindTVCMMaterialListContractInfoDAOFactory() {
    }

    /**
     * TVCM素材一覧契約情報検索インスタンスを生成します
     * @return TTVCM素材一覧契約情報検索DAOインスタンス
     */
    public static FindTVCMMaterialListContractInfoDAO createFindTVCMMaterialListContractInfoDAOFactory() {
        return (FindTVCMMaterialListContractInfoDAO) DaoFactory.createDao(FindTVCMMaterialListContractInfoDAO.class);
    }

}
