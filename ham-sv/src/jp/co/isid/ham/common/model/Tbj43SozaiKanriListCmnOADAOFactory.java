package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 素材一覧（共有OA期間）DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj43SozaiKanriListCmnOADAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj43SozaiKanriListCmnOADAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj43SozaiKanriListCmnOADAO createTbj43SozaiKanriListCmnOADAO() {
        return (Tbj43SozaiKanriListCmnOADAO) DaoFactory.createDao(Tbj43SozaiKanriListCmnOADAO.class);
    }

}
