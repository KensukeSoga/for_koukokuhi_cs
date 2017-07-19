package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj05CarDAO;
import jp.co.isid.ham.common.model.Mbj05CarDAOFactory;
import jp.co.isid.ham.common.model.Mbj50RdStationCondition;
import jp.co.isid.ham.common.model.Mbj50RdStationDAO;
import jp.co.isid.ham.common.model.Mbj50RdStationDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ラジオ版AllocationPicture検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureManager {

    /** シングルトンインスタンス */
    private static FindRdAllocationPictureManager _manager = new FindRdAllocationPictureManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindRdAllocationPictureManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindRdAllocationPictureManager getInstance() {
        return _manager;
    }

    /**
     * ラジオ版AllocationPicture出力情報を検索します
     * @param cond 検索条件
     * @return ラジオ版AllocationPicture出力情報
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public FindRdAllocationPictureResult findRdAllocationPicture(FindRdAllocationPictureCondition cond) throws HAMException {

        //検索結果
        FindRdAllocationPictureResult result = new FindRdAllocationPictureResult();

        //素材情報
        FindRdAllocationPictureMaterialDAO materialDao = FindRdAllocationPictureMaterialDAOFactory.createFindRdAllocationMaterialDAOFactory();
        FindRdAllocationPictureMaterialCondition materialCond = new FindRdAllocationPictureMaterialCondition();
        materialCond.setYearMonth(cond.getYearMonth());
        result.setRdAPMaterial(materialDao.findMaterialInfo(materialCond));

        //ラジオ番組情報取得
        FindRdAllocationPictureProgramDAO programDao = FindRdAllocationPictureProgramDAOFactory.createFindRdAllocationPictureProgramDAOFactory();
        FindRdAllocationPictureProgramCondition programCond = new FindRdAllocationPictureProgramCondition();
        programCond.setYearMonth(cond.getYearMonth());
        programCond.setRdSeqNo(cond.getRdSeqNo());
        result.setRdAPProgram(programDao.findRdProgramInfo(programCond));

        //ラジオ番組素材情報取得
        FindRdAllocationPictureProgramMaterialDAO programMaterialDao = FindRdAllocationPictureProgramMaterialDAOFactory.createFindRdAllocationPictureMaterialDAOFactory();
        FindRdAllocationPictureProgramMaterialCondition programMaterialCond = new FindRdAllocationPictureProgramMaterialCondition();
        programMaterialCond.setYearMonth(cond.getYearMonth());
        programMaterialCond.setRdSeqNo(cond.getRdSeqNo());
        result.setRdAPPogramMaterial(programMaterialDao.findRdProgramMaterialInfo(programMaterialCond));

        //ラジオ番組ネット局情報取得
        FindRdAllocationPictureProgramStationDAO programStationDao = FindRdAllocationPictureProgramStationDAOFactory.createFindRdAllocationProgramStationDAOFactory();
        FindRdAllocationPictureProgramStationCondition programStationCond = new FindRdAllocationPictureProgramStationCondition();
        programStationCond.setRdSeqNo(cond.getRdSeqNo());
        result.setRdAPStation(programStationDao.findProgramStationInfo(programStationCond));

        //車種マスタ
        Mbj05CarDAO mbj05dao = Mbj05CarDAOFactory.createMbj05CarDAO();
        Mbj05CarCondition mbj05cond = new Mbj05CarCondition();
        result.setCar(mbj05dao.selectVO(mbj05cond));

        //ラジオ局マスタ取得
        Mbj50RdStationDAO mbj50dao = Mbj50RdStationDAOFactory.createMbj50RdStationDAO();
        Mbj50RdStationCondition mbj50cond = new Mbj50RdStationCondition();
        result.setRdStation(mbj50dao.selectVO(mbj50cond));

        return result;
    }

}
