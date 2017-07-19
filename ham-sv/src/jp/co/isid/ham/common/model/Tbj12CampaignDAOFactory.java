package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * キャンペーン一覧DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj12CampaignDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj12CampaignDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj12CampaignDAO createTbj12CampaignDAO() {
        return (Tbj12CampaignDAO) DaoFactory.createDao(Tbj12CampaignDAO.class);
    }

}
