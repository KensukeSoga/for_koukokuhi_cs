package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �����DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj21SeisakuhiDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj21SeisakuhiCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj21SeisakuhiDAO() {
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
                Tbj21Seisakuhi.PHASE
                ,Tbj21Seisakuhi.SEIKYUYM
                ,Tbj21Seisakuhi.DCARCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj21Seisakuhi.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj21Seisakuhi.CRTDATE
                ,Tbj21Seisakuhi.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj21Seisakuhi.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj21Seisakuhi.PHASE
                ,Tbj21Seisakuhi.SEIKYUYM
                ,Tbj21Seisakuhi.DCARCD
                ,Tbj21Seisakuhi.DCARNM
                ,Tbj21Seisakuhi.SEISAKUHIH
                ,Tbj21Seisakuhi.SEISAKUHIS
                ,Tbj21Seisakuhi.SEISAKUHIOTHER
                ,Tbj21Seisakuhi.BIKO
                ,Tbj21Seisakuhi.GETTIME
                ,Tbj21Seisakuhi.CRTDATE
                ,Tbj21Seisakuhi.CRTNM
                ,Tbj21Seisakuhi.CRTAPL
                ,Tbj21Seisakuhi.CRTID
                ,Tbj21Seisakuhi.UPDDATE
                ,Tbj21Seisakuhi.UPDNM
                ,Tbj21Seisakuhi.UPDAPL
                ,Tbj21Seisakuhi.UPDID
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        sql.append("DELETE FROM ");
        sql.append(Tbj21Seisakuhi.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj21Seisakuhi.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj21Seisakuhi.SEIKYUYM);
        sql.append(" = ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getSeikyuym()));

        return sql.toString();
    }

    /**
     * �������폜���܂�
     * @param condition �폜����
     * @throws HAMException
     */
    public void deleteSeisakuhi(Tbj21SeisakuhiCondition condition) throws HAMException {
        try {
            _condition = condition;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * �o�^
     * @param vo �o�^�f�[�^
     * @throws HAMException
     */
    public void insertVo(Tbj21SeisakuhiVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
