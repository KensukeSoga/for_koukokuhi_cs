package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class MediaListDAOFactory extends DaoFactory{

    /**
     * インスタンス生成禁止
     */
    private MediaListDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static MediaListDAO createMediaListDAO() {
        return (MediaListDAO) DaoFactory.createDao(MediaListDAO.class);
    }
}
