package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �}�̔�Ǘ�DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj03MediaMngDAO extends AbstractSimpleRdbDao {

//    /** �������� */
//    private Tbj03MediaMngCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj03MediaMngDAO() {
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

}
