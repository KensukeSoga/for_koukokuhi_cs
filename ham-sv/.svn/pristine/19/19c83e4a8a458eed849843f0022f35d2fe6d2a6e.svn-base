package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * キャンペーン一覧情報DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class FindCarCampaignListDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindCarCampaignListDAOFactory() {
    }

    /**
     * キャンペーンデータ取得DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static FindCampaignListDAO createFindCampaignListDAO() {
        return (FindCampaignListDAO) DaoFactory.createDao(FindCampaignListDAO.class);
    }

    public static FindCarListDAO createFindCarListDAO() {
        return (FindCarListDAO)DaoFactory.createDao(FindCarListDAO.class);
    }
}
