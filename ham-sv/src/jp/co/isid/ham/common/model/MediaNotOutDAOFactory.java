package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 媒体DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class MediaNotOutDAOFactory extends DaoFactory{

    /**
     * インスタンス生成禁止
     */
    private MediaNotOutDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static MediaNotOutDAO createMediaNotOutDAO() {
        return (MediaNotOutDAO) DaoFactory.createDao(MediaNotOutDAO.class);
    }

}
