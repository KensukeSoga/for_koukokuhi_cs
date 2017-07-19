package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.media.model.FindCampaignDetailsCondition;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �L�����y�[������DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj13CampDetailDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj13CampDetailCondition _condition = null;
    private FindCampaignDetailsCondition _findCondition = null;
    private String _CampaignCd = null;
    /**SQL�I��*/
    private enum SqlMode{SH,BU,KI,BYKEY};
    private SqlMode _sqlMode = SqlMode.SH;
    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj13CampDetailDAO() {
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
                Tbj13CampDetail.CAMPCD
                ,Tbj13CampDetail.MEDIACD
                ,Tbj13CampDetail.PHASE
                ,Tbj13CampDetail.YOTEIYM
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj13CampDetail.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj13CampDetail.CRTDATE
                ,Tbj13CampDetail.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj13CampDetail.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj13CampDetail.CAMPCD
                ,Tbj13CampDetail.DCARCD
                ,Tbj13CampDetail.MEDIACD
                ,Tbj13CampDetail.PHASE
                ,Tbj13CampDetail.YOTEIYM
                ,Tbj13CampDetail.KIKANFROM
                ,Tbj13CampDetail.KIKANTO
                ,Tbj13CampDetail.BUDGET
                ,Tbj13CampDetail.BUDGETHM
                ,Tbj13CampDetail.CRTDATE
                ,Tbj13CampDetail.CRTNM
                ,Tbj13CampDetail.CRTAPL
                ,Tbj13CampDetail.CRTID
                ,Tbj13CampDetail.UPDDATE
                ,Tbj13CampDetail.UPDNM
                ,Tbj13CampDetail.UPDAPL
                ,Tbj13CampDetail.UPDID
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.SH)) {
            sql = findCampaignDetails();
        } else if (_sqlMode.equals(SqlMode.BU)) {
            sql = findCampaignDetailsBudget();
        } else if (_sqlMode.equals(SqlMode.KI)) {
            sql = findCampaignDetailsKikan();
        } else if (_sqlMode.equals(SqlMode.BYKEY)) {
            sql = findCampaignDetailsByKey();
        }

        return sql;
    }

    /**
     *�L�����y�[���ڍׂ��擾���܂�.
     *@return SQL��.
     */
    private String findCampaignDetails() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _findCondition.getCampaignNo() + "' ");

        return sql.toString();
    }

    /**
     *�L�����y�[���ڍׂ̍��v�\�Z���擾���܂�.
     *@return SQL��.
     *
     */
    private String findCampaignDetailsBudget() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + ", ");
        sql.append(" SUM(" + Tbj13CampDetail.BUDGET+ ") AS " + Tbj13CampDetail.BUDGET + ", ");
        sql.append(" SUM(" + Tbj13CampDetail.BUDGETHM+ ") AS " + Tbj13CampDetail.BUDGETHM + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _CampaignCd + "' ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " ");

        return sql.toString();
    }

    /**
     *�L�����y�[���ڍׂ̊��Ԃ̍ŏ��ő���擾���܂�
     *@return SQL��.
     */
    private String findCampaignDetailsKikan() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" MIN(" + Tbj13CampDetail.KIKANFROM + ") AS " + Tbj13CampDetail.KIKANFROM + ", ");
        sql.append(" MAX(" + Tbj13CampDetail.KIKANTO + ") AS " + Tbj13CampDetail.KIKANTO + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _CampaignCd + "' ");

        return sql.toString();
    }

    /**
     *�L�����y�[���ڍׂ��擾���܂�.
     *@return SQL��.
     */
    private String findCampaignDetailsByKey() {

        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " +Tbj13CampDetail.CAMPCD +" ='" + _condition.getCampcd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.DCARCD +" ='" + _condition.getDcarcd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.MEDIACD +" ='" + _condition.getMediacd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.PHASE +" = " + _condition.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.YOTEIYM +" = " + getDBModelInterface().ConvertToDBString(_condition.getYoteiym()) + " ");

        return sql.toString();
    }

    /**
     * �L�����y�[���ڍׂ̌������s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsByCond(
            FindCampaignDetailsCondition cond) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.SH;
            _findCondition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * �L�����y�[���ڍׂ̗\�Z���v�̌����s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsSumBudget(
            String CampaignCd) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.BU;
            _CampaignCd = CampaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * �L�����y�[���ڍׂ̊��Ԃ̌������s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsKikan(
            String CampaignCd) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.KI;
            _CampaignCd = CampaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * �����L�[�Ō������s��
     * @param CampaignCd
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsByKey(Tbj13CampDetailCondition cond) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.BYKEY;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

}
