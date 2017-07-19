package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * キャンペーン一覧更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/7 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class CampaignRegisterDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private CampaignRegisterDAOFactory() {
    }

    /**
     * キャンペーンデータ更新DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static CampaignRegisterDAO createCampaignRegisterDAO() {
        return (CampaignRegisterDAO) DaoFactory.createDao(CampaignRegisterDAO.class);
    }

}
