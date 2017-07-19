package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ラジオ番組登録表示情報DAOファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class FindRdProgramRegisterDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindRdProgramRegisterDAOFactory() {
    }

    /**
     * ラジオ番組一覧画面情報検索DAOインスタンスを生成します
     * @return ラジオ番組一覧画面情報検索DAO
     */
    public static FindRdProgramListDAO createFindRdProgramListDAOFactory() {
        return (FindRdProgramListDAO) DaoFactory.createDao(FindRdProgramListDAO.class);
    }

    /**
     * ラジオ番組登録画面素材情報検索DAOインスタンスを生成します
     * @return ラジオ番組登録画面素材情報検索DAOインスタンス
     */
    public static FindRdProgramMaterialDAO createFindRdProgramMaterialDAOFactory() {
        return (FindRdProgramMaterialDAO) DaoFactory.createDao(FindRdProgramMaterialDAO.class);
    }

}
