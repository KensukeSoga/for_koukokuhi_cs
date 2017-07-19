package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループ情報)DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Vbj02TitleClassGroupInfoDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Vbj02TitleClassGroupInfoDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Vbj02TitleClassGroupInfoDAO createVbj02TitleClassGroupInfoDAO() {
        return (Vbj02TitleClassGroupInfoDAO) DaoFactory.createDao(Vbj02TitleClassGroupInfoDAO.class);
    }

}
