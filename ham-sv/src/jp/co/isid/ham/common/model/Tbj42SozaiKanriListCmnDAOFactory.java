package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 素材一覧（共有）DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj42SozaiKanriListCmnDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj42SozaiKanriListCmnDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj42SozaiKanriListCmnDAO createTbj42SozaiKanriListCmnDAO() {
        return (Tbj42SozaiKanriListCmnDAO) DaoFactory.createDao(Tbj42SozaiKanriListCmnDAO.class);
    }

}
