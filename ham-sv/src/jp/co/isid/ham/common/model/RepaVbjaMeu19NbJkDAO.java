package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �l������DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu19NbJkDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private RepaVbjaMeu19NbJkCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu19NbJkDAO() {
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
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return RepaVbjaMeu19NbJk.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu19NbJk.THSKGYCD
                ,RepaVbjaMeu19NbJk.SEQNO
                ,RepaVbjaMeu19NbJk.TRTNTSEQNO
                ,RepaVbjaMeu19NbJk.NBIKSINSEINO
                ,RepaVbjaMeu19NbJk.KESYM
                ,RepaVbjaMeu19NbJk.ENDYMD
                ,RepaVbjaMeu19NbJk.STARTYMD
                ,RepaVbjaMeu19NbJk.SNSTNT
                ,RepaVbjaMeu19NbJk.TYSYMD
                ,RepaVbjaMeu19NbJk.TYEYMD
                ,RepaVbjaMeu19NbJk.KESDAY
                ,RepaVbjaMeu19NbJk.SNSKYK
        };
    }

}
