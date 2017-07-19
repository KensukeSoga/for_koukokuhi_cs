package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ラジオ番組素材DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj38RdProgramMaterialDAOFactory extends DaoFactory {

    /**
     * インスタンス生成禁止
     */
    private Tbj38RdProgramMaterialDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static Tbj38RdProgramMaterialDAO createTbj38RdProgramMaterialDAO() {
        return (Tbj38RdProgramMaterialDAO) DaoFactory.createDao(Tbj38RdProgramMaterialDAO.class);
    }

}
