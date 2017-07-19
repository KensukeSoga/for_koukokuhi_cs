package jp.co.isid.ham.billing.model;

import java.util.List;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailVO;
import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * �}�̔�ϖ��׊Ǘ��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMediaMngEstDtlDAO extends AbstractRdbDao {

    /** �������� */
    private Tbj04MediaMngEstimateDetailCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaMngEstDtlDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj04MediaMngEstimateDetail.MEDIAMNGNO
                ,Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return Tbj04MediaMngEstimateDetail.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj04MediaMngEstimateDetail.CRTDATE
                ,Tbj04MediaMngEstimateDetail.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return Tbj04MediaMngEstimateDetail.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj04MediaMngEstimateDetail.MEDIAMNGNO
                ,Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO
                ,Tbj04MediaMngEstimateDetail.PHASE
                ,Tbj04MediaMngEstimateDetail.MDYEAR
                ,Tbj04MediaMngEstimateDetail.MDMONTH
                ,Tbj04MediaMngEstimateDetail.CRTDATE
                ,Tbj04MediaMngEstimateDetail.CRTNM
                ,Tbj04MediaMngEstimateDetail.CRTAPL
                ,Tbj04MediaMngEstimateDetail.CRTID
                ,Tbj04MediaMngEstimateDetail.UPDDATE
                ,Tbj04MediaMngEstimateDetail.UPDNM
                ,Tbj04MediaMngEstimateDetail.UPDAPL
                ,Tbj04MediaMngEstimateDetail.UPDID
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(Tbj04MediaMngEstimateDetail.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj04MediaMngEstimateDetail.MDYEAR);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdyear());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj04MediaMngEstimateDetail.MDMONTH);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdmonth());
        sql.append("'");

        sql.append(" ORDER BY ");
        sql.append(Tbj04MediaMngEstimateDetail.MEDIAMNGNO);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj04MediaMngEstimateDetailVO> selectVO(Tbj04MediaMngEstimateDetailCondition condition) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj04MediaMngEstimateDetailVO());
        try
        {
            _condition = condition;
            return (List<Tbj04MediaMngEstimateDetailVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
