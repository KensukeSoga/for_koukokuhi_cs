package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 一覧表示パターンDAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj30DisplayPatternDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj30DisplayPatternDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj30DisplayPatternDAO createTbj30DisplayPatternDAO() {
        return (Tbj30DisplayPatternDAO) DaoFactory.createDao(Tbj30DisplayPatternDAO.class);
    }

}
