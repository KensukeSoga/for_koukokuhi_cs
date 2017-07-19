package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * ����敔��DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu13ThsKgyBmonDAO extends AbstractSimpleRdbDao {

    /** �������� */
    //private RepaVbjaMeu13ThsKgyBmonCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu13ThsKgyBmonDAO() {
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
                RepaVbjaMeu13ThsKgyBmon.THSKGYCD
                ,RepaVbjaMeu13ThsKgyBmon.SEQNO
                ,RepaVbjaMeu13ThsKgyBmon.ENDYMD
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
        return RepaVbjaMeu13ThsKgyBmon.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu13ThsKgyBmon.THSKGYCD
                ,RepaVbjaMeu13ThsKgyBmon.SEQNO
                ,RepaVbjaMeu13ThsKgyBmon.ENDYMD
                ,RepaVbjaMeu13ThsKgyBmon.STARTYMD
                ,RepaVbjaMeu13ThsKgyBmon.SNSTNT
                ,RepaVbjaMeu13ThsKgyBmon.SUBMEI
                ,RepaVbjaMeu13ThsKgyBmon.SUBKN
                ,RepaVbjaMeu13ThsKgyBmon.SUBEN
                ,RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN
                ,RepaVbjaMeu13ThsKgyBmon.GSYLMCD
                ,RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD
                ,RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO
                ,RepaVbjaMeu13ThsKgyBmon.SHRSINCD
                ,RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN
                ,RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD
        };
    }

}
