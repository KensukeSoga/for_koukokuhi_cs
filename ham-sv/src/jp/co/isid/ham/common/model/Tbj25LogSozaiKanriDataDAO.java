package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj25LogSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �f�ޓo�^�ύX���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj25LogSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private Tbj25LogSozaiKanriDataCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj25LogSozaiKanriDataDAO() {
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
                Tbj25LogSozaiKanriData.NOKBN
                ,Tbj25LogSozaiKanriData.CMCD
                ,Tbj25LogSozaiKanriData.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj25LogSozaiKanriData.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj25LogSozaiKanriData.CRTDATE
                ,Tbj25LogSozaiKanriData.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj25LogSozaiKanriData.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj25LogSozaiKanriData.NOKBN
                ,Tbj25LogSozaiKanriData.CMCD
                ,Tbj25LogSozaiKanriData.HISTORYNO
                ,Tbj25LogSozaiKanriData.HISTORYKBN
                ,Tbj25LogSozaiKanriData.DELFLG
                ,Tbj25LogSozaiKanriData.DCARCD
                ,Tbj25LogSozaiKanriData.CATEGORY
                ,Tbj25LogSozaiKanriData.TITLE
                ,Tbj25LogSozaiKanriData.SECOND
                ,Tbj25LogSozaiKanriData.SYATAN
                ,Tbj25LogSozaiKanriData.NOHIN
                ,Tbj25LogSozaiKanriData.PRODUCT
                ,Tbj25LogSozaiKanriData.DATEFROM
                ,Tbj25LogSozaiKanriData.DATETO
                ,Tbj25LogSozaiKanriData.MLIMIT
                ,Tbj25LogSozaiKanriData.KLIMIT
                ,Tbj25LogSozaiKanriData.DATERECOG
                ,Tbj25LogSozaiKanriData.DATEPRT
                ,Tbj25LogSozaiKanriData.BIKO
                ,Tbj25LogSozaiKanriData.CRTDATE
                ,Tbj25LogSozaiKanriData.CRTNM
                ,Tbj25LogSozaiKanriData.CRTAPL
                ,Tbj25LogSozaiKanriData.CRTID
                ,Tbj25LogSozaiKanriData.UPDDATE
                ,Tbj25LogSozaiKanriData.UPDNM
                ,Tbj25LogSozaiKanriData.UPDAPL
                ,Tbj25LogSozaiKanriData.UPDID
        };
    }

}
