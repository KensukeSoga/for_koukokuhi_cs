package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体状況管理データ更新DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/17 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class MediaPlanRegisterDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private MediaPlanRegisterDAOFactory() {
    }

    /**
     * 媒体状況管理データ更新DAOインスタンスを生成します
     *
     * @return DAOインスタンス
     */
    public static MediaPlanRegisterDAO createCampaignRegisterDetailsDAO() {
        return (MediaPlanRegisterDAO) DaoFactory.createDao(MediaPlanRegisterDAO.class);
    }
}
