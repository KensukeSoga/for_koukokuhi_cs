package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj33CrBudgetUpdHis;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * CR�\�Z�X�V����DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj33CrBudgetUpdHisDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private Tbj33CrBudgetUpdHisCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj33CrBudgetUpdHisDAO() {
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
        return null;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj33CrBudgetUpdHis.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj33CrBudgetUpdHis.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj33CrBudgetUpdHis.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj33CrBudgetUpdHis.PHASE
                ,Tbj33CrBudgetUpdHis.DCARCD
                ,Tbj33CrBudgetUpdHis.CLASSCD
                ,Tbj33CrBudgetUpdHis.EXPCD
                ,Tbj33CrBudgetUpdHis.CRTDATE
                ,Tbj33CrBudgetUpdHis.CRTNM
                ,Tbj33CrBudgetUpdHis.CRTAPL
                ,Tbj33CrBudgetUpdHis.CRTID
                ,Tbj33CrBudgetUpdHis.UPDDATE
                ,Tbj33CrBudgetUpdHis.UPDNM
                ,Tbj33CrBudgetUpdHis.UPDAPL
                ,Tbj33CrBudgetUpdHis.UPDID
        };
    }



    /**
     * �o�^
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK�X�V
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean updateVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            return super.update();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK�폜
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean deleteVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            return super.remove();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }
}
