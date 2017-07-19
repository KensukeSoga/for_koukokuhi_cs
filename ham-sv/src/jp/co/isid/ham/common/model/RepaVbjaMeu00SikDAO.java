package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu00Sik;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �g�D�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu00SikDAO extends AbstractSimpleRdbDao {

//    /** �������� */
//    private RepaVbjaMeu00SikCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu00SikDAO() {
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
                RepaVbjaMeu00Sik.SIKCD
                ,RepaVbjaMeu00Sik.ENDYMD
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
        return RepaVbjaMeu00Sik.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu00Sik.SIKCD
                ,RepaVbjaMeu00Sik.ENDYMD
                ,RepaVbjaMeu00Sik.INSDATE
                ,RepaVbjaMeu00Sik.INSSIKTNTCD
                ,RepaVbjaMeu00Sik.INSAPLID
                ,RepaVbjaMeu00Sik.UPDAPLDATE
                ,RepaVbjaMeu00Sik.UPDSIKTNTCD
                ,RepaVbjaMeu00Sik.UPDONLAPLID
                ,RepaVbjaMeu00Sik.UPDBATAPLID
                ,RepaVbjaMeu00Sik.STARTYMD
                ,RepaVbjaMeu00Sik.KSHASKBTUCD
                ,RepaVbjaMeu00Sik.IOCD
                ,RepaVbjaMeu00Sik.HYOJIKN
                ,RepaVbjaMeu00Sik.HYOJIKJ
                ,RepaVbjaMeu00Sik.HYOJIRYAKU
                ,RepaVbjaMeu00Sik.HYOJIEN
                ,RepaVbjaMeu00Sik.SPUSECD
                ,RepaVbjaMeu00Sik.KAISOCD
                ,RepaVbjaMeu00Sik.JSIKCD
                ,RepaVbjaMeu00Sik.CKATUKBN
                ,RepaVbjaMeu00Sik.JYTRKKBN
                ,RepaVbjaMeu00Sik.ODRTRKKBN
                ,RepaVbjaMeu00Sik.KNRIBMON
                ,RepaVbjaMeu00Sik.KSHATHSKGYCD
                ,RepaVbjaMeu00Sik.KSHATHSSEQNO
                ,RepaVbjaMeu00Sik.KYUKSHATHSCD
                ,RepaVbjaMeu00Sik.BCKKBN
                ,RepaVbjaMeu00Sik.EGSYOCD
                ,RepaVbjaMeu00Sik.CLNTPLBMNSBETU
        };
    }

}
