package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループメンバー情報)DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Vbj03TitleClassMemberDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Vbj03TitleClassMemberDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Vbj03TitleClassMemberDAO createVbj03TitleClassMemberDAO() {
        return (Vbj03TitleClassMemberDAO) DaoFactory.createDao(Vbj03TitleClassMemberDAO.class);
    }

}
