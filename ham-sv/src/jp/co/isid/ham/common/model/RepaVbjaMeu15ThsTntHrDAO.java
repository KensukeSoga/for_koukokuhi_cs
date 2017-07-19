package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu15ThsTntHr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �����S���i���jDAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu15ThsTntHrDAO extends AbstractSimpleRdbDao {

    /** �������� */
    //private RepaVbjaMeu15ThsTntHrCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu15ThsTntHrDAO() {
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
                RepaVbjaMeu15ThsTntHr.THSKGYCD
                ,RepaVbjaMeu15ThsTntHr.SEQNO
                ,RepaVbjaMeu15ThsTntHr.HRTNTSEQNO
                ,RepaVbjaMeu15ThsTntHr.ENDYMD
        };
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
        return RepaVbjaMeu15ThsTntHr.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu15ThsTntHr.THSKGYCD
                ,RepaVbjaMeu15ThsTntHr.SEQNO
                ,RepaVbjaMeu15ThsTntHr.HRTNTSEQNO
                ,RepaVbjaMeu15ThsTntHr.ENDYMD
                ,RepaVbjaMeu15ThsTntHr.STARTYMD
                ,RepaVbjaMeu15ThsTntHr.SNSTNT
                ,RepaVbjaMeu15ThsTntHr.SIKCD
                ,RepaVbjaMeu15ThsTntHr.SHRKBN
                ,RepaVbjaMeu15ThsTntHr.FRKSKBN
                ,RepaVbjaMeu15ThsTntHr.EGHISHRSKBN
                ,RepaVbjaMeu15ThsTntHr.STYSHRSKBN
                ,RepaVbjaMeu15ThsTntHr.SINSEINO
                ,RepaVbjaMeu15ThsTntHr.EGSYOCD
                ,RepaVbjaMeu15ThsTntHr.SHJYOKNPTNNO
                ,RepaVbjaMeu15ThsTntHr.KYUTRCD
                ,RepaVbjaMeu15ThsTntHr.HRTNTYOBI
        };
    }

}
