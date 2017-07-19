package jp.co.isid.ham.media.model;


import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;


/**
 *
 * <P>
 * �L�����y�[���ꗗ�̏��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class CampaignRegisterDAO extends AbstractSimpleRdbDao {

    private enum SqlMode{INS,UPD,DEL};
    private SqlMode _sqlmode = SqlMode.INS;
    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CampaignRegisterDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return new String[]{
                Tbj12Campaign.CAMPCD
        };
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj12Campaign.CRTDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlmode.equals(SqlMode.INS)) {
            return new String[]{
                    Tbj12Campaign.CRTDATE,
                    Tbj12Campaign.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.UPD)) {
            return new String[]{
                    Tbj12Campaign.UPDDATE
            };
        }

        return null;

    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj12Campaign.TBNAME;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj12Campaign.CAMPCD,
                Tbj12Campaign.DCARCD,
                Tbj12Campaign.PHASE,
                Tbj12Campaign.KIKANFROM,
                Tbj12Campaign.KIKANTO,
                Tbj12Campaign.CAMPNM,
                Tbj12Campaign.FSTBUDGET,
                Tbj12Campaign.BUDGET,
                Tbj12Campaign.BUDGETHM,
                Tbj12Campaign.ACTUAL,
                Tbj12Campaign.ACTUALHM,
                Tbj12Campaign.MEMO,
                Tbj12Campaign.BAITAIFLG,
                Tbj12Campaign.CRTDATE,
                Tbj12Campaign.CRTNM,
                Tbj12Campaign.CRTAPL,
                Tbj12Campaign.CRTID,
                Tbj12Campaign.UPDDATE,
                Tbj12Campaign.UPDNM,
                Tbj12Campaign.UPDAPL,
                Tbj12Campaign.UPDID
        };
    }

    /**
     * �L�����y�[���ꗗ�̍폜���s���܂�
     *
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void delCampaignList(
            Tbj12CampaignVO vo) throws HAMException {
        super.setModel(vo);
        try {
            _sqlmode = SqlMode.DEL;
            if (!super.remove())
            {
                throw new HAMException("�폜�G���[","BJ-E0004");
            }

        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * �L�����y�[���ꗗ�̓o�^���s���܂�.
     *
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void insCampaignList(
            Tbj12CampaignVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.INS;
            if (!super.insert()) {
                throw new HAMException("�o�^�G���[", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * �L�����y�[���ꗗ�̍X�V���s���܂�.
     *
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void updCampaignList(
            Tbj12CampaignVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.UPD;
            if (!super.update()) {
                throw new HAMException("�X�V�G���[", "BJ-E0003");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

}