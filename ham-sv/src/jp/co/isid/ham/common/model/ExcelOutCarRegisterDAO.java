package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �Ԏ�o�͐ݒ�}�X�^�o�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class ExcelOutCarRegisterDAO extends AbstractSimpleRdbDao{

    /** �폜�����̒��[�R�[�h */
    private String _reportCd = null;

    /** �폜�����̃t�F�C�Y */
    private BigDecimal _phase = null;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public ExcelOutCarRegisterDAO() {
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
        return Mbj13CarOutCtrl.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj13CarOutCtrl.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.REPORTCD
                ,Mbj13CarOutCtrl.DCARCD
                ,Mbj13CarOutCtrl.OUTPUTFLG
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj13CarOutCtrl.PHASE
                ,Mbj13CarOutCtrl.UPDDATE
                ,Mbj13CarOutCtrl.UPDNM
                ,Mbj13CarOutCtrl.UPDAPL
                ,Mbj13CarOutCtrl.UPDID
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getExecString() {
        return getDelCarOutCtrl();

    }

    /**
     * �Ώۂ̎Ԏ�o�͐ݒ���폜���܂�
     *
     * @return �폜SQL��
     */
    public String getDelCarOutCtrl() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " ='" + _reportCd + "' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _phase + " ");

        return sql.toString();
    }

    /**
     * �Ԏ�o�͐ݒ�̓o�^���s���܂�.
     *
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void insCarOutCtrl(
            Mbj13CarOutCtrlVO vo) throws HAMException {

        super.setModel(vo);
        try {
            if (!super.insert()) {
                throw new HAMException("�o�^�G���[", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * �Ԏ�o�͐ݒ�̍폜���s���܂�
     *
     * @return
     * @throws HAMException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void delCarOutCtrl(String reportCd,BigDecimal phase) throws HAMException {

        try {
            _reportCd = reportCd;
            _phase = phase;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
