package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 制作費DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj21SeisakuhiDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj21SeisakuhiDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj21SeisakuhiDAO createTbj21SeisakuhiDAO() {
        return (Tbj21SeisakuhiDAO) DaoFactory.createDao(Tbj21SeisakuhiDAO.class);
    }

}
