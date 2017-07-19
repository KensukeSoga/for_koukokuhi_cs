package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj03MediaMngCondition;
import jp.co.isid.ham.common.model.Tbj03MediaMngVO;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * �}�̔�Ǘ��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMediaMngDAO extends AbstractRdbDao {

    /** �������� */
    private Tbj03MediaMngCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaMngDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj03MediaMng.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj03MediaMng.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
                ,Tbj03MediaMng.PHASE
                ,Tbj03MediaMng.MDYEAR
                ,Tbj03MediaMng.MDMONTH
                ,Tbj03MediaMng.DCARCD
                ,Tbj03MediaMng.MEDIACD
                ,Tbj03MediaMng.HMCOSTTOTAL
                ,Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.CRTNM
                ,Tbj03MediaMng.CRTAPL
                ,Tbj03MediaMng.CRTID
                ,Tbj03MediaMng.UPDDATE
                ,Tbj03MediaMng.UPDNM
                ,Tbj03MediaMng.UPDAPL
                ,Tbj03MediaMng.UPDID
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
        sql.append(Tbj03MediaMng.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj03MediaMng.MDYEAR);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdyear());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj03MediaMng.MDMONTH);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdmonth());
        sql.append("'");

        if (_condition.getDcarcd() != null && _condition.getDcarcd().length() > 0) {
            sql.append(" AND ");
            sql.append(Tbj03MediaMng.DCARCD);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condition.getDcarcd());
            sql.append("'");
        }

        if (_condition.getMediacd() != null && _condition.getMediacd().length() > 0) {
            sql.append(" AND ");
            sql.append(Tbj03MediaMng.MEDIACD);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condition.getMediacd());
            sql.append("'");
        }

        sql.append(" ORDER BY ");
        sql.append(Tbj03MediaMng.DCARCD);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj03MediaMngVO> selectVO(Tbj03MediaMngCondition condition) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj03MediaMngVO());
        try
        {
            _condition = condition;
            return (List<Tbj03MediaMngVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
