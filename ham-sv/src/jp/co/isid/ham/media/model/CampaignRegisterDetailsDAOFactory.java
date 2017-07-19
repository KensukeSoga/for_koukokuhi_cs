package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * キャンペーン詳細データ更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class CampaignRegisterDetailsDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private CampaignRegisterDetailsDAOFactory() {
    }

    /**
     * キャンペーンデータ更新DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static CampaignRegisterDetailsDAO createCampaignRegisterDetailsDAO() {
        return (CampaignRegisterDetailsDAO) DaoFactory.createDao(CampaignRegisterDetailsDAO.class);
    }

}
