package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ラジオ版AllocationPicture番組情報検索DAOファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureProgramDAOFactory extends DaoFactory {

    /**
     * インスタンス化を禁止します
     */
    private FindRdAllocationPictureProgramDAOFactory() {
    }

    /**
     * ラジオ版AllocationPicture情報検索DAOインスタンスを生成します
     * @return ラジオ版AllocationPicture情報検索DAOインスタンス
     */
    public static FindRdAllocationPictureProgramDAO createFindRdAllocationPictureProgramDAOFactory() {
        return (FindRdAllocationPictureProgramDAO) DaoFactory.createDao(FindRdAllocationPictureProgramDAO.class);
    }

}
