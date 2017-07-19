package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.integ.tbl.Tbj39RdProgramStation;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdAllocationPictureProgramStationDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private FindRdAllocationPictureProgramStationCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindRdAllocationPictureProgramStationDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{ };
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getMaterialInfo();
    }

    /**
     * ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�SQL����Ԃ��܂�
     * @return String SQL��
     */
    private String getMaterialInfo() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD);

        sql.append(" FROM");
        sql.append(" " + Tbj39RdProgramStation.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + " IN ( " + _cond.getRdSeqNo() + " )");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD);

        return sql.toString();
    }

    /**
     * ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj39RdProgramStationVO> findProgramStationInfo(FindRdAllocationPictureProgramStationCondition cond) throws HAMException {

        super.setModel(new Tbj39RdProgramStationVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
