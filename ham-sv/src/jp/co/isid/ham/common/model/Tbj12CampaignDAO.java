package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �L�����y�[���ꗗDAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj12CampaignDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj12CampaignCondition _condition = null;
    private String _campCd = null;

    /**SQL���[�h�̑I��*/
    private enum SqlMode{ALL,MAX,CD,GETCAMPCD};
    private SqlMode _sqlMode = SqlMode.MAX;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj12CampaignDAO() {
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
                Tbj12Campaign.CAMPCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj12Campaign.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj12Campaign.CRTDATE
                ,Tbj12Campaign.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj12Campaign.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj12Campaign.CAMPCD
                ,Tbj12Campaign.DCARCD
                ,Tbj12Campaign.PHASE
                ,Tbj12Campaign.KIKANFROM
                ,Tbj12Campaign.KIKANTO
                ,Tbj12Campaign.CAMPNM
                ,Tbj12Campaign.FSTBUDGET
                ,Tbj12Campaign.BUDGET
                ,Tbj12Campaign.BUDGETHM
                ,Tbj12Campaign.ACTUAL
                ,Tbj12Campaign.ACTUALHM
                ,Tbj12Campaign.MEMO
                ,Tbj12Campaign.BAITAIFLG
                ,Tbj12Campaign.CRTDATE
                ,Tbj12Campaign.CRTNM
                ,Tbj12Campaign.CRTAPL
                ,Tbj12Campaign.CRTID
                ,Tbj12Campaign.UPDDATE
                ,Tbj12Campaign.UPDNM
                ,Tbj12Campaign.UPDAPL
                ,Tbj12Campaign.UPDID
        };
    }


    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = "";
        if (_sqlMode.equals(SqlMode.ALL)) {
            sql = getAllCampaign();
        } else if (_sqlMode.equals(SqlMode.MAX)) {
            sql = getMaxCampaignNoSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.CD)) {
            sql = getCampaignListByCampCd();
        } else if (_sqlMode.equals(SqlMode.GETCAMPCD)) {
            sql = getCampaignCd();
        }
        return sql;
    }

    /**
     * �L�����y�[���f�[�^�S�擾
     * @return SQL��
     */
    private String getAllCampaign() {

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
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj12Campaign.CAMPCD + " ASC ");

        return sql.toString();
    }

    /**�L�����y�[��MAX�l�擾*/
    private String getMaxCampaignNoSQLByCondition() {

         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" NVL(MAX(" + Tbj12Campaign.CAMPCD + "),'CP0000') AS " + Tbj12Campaign.CAMPCD);
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");


         return sql.toString();
    }


    /**
     * �L�����y�[���R�[�h�̍s���擾
     * @return SQL��
     */
    private String getCampaignListByCampCd() {
         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" * ");
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");
         sql.append(" WHERE ");
         sql.append(" " + Tbj12Campaign.CAMPCD + " = '" + _campCd + "' ");


         return sql.toString();
    }

    private String getCampaignCd() {
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
        sql.append(" " + Tbj12Campaign.DCARCD + " = '" + _condition.getDcarcd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.PHASE + " = '" + _condition.getPhase() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.KIKANFROM + " <= " + getDBModelInterface().ConvertToDBString(_condition.getKikanfrom()) + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.KIKANTO + " >= " + getDBModelInterface().ConvertToDBString(_condition.getKikanto()) + " ");

        return sql.toString();
    }

    /**
     * �L�����y�[���S�擾
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findAllCampaign() throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.ALL;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �L�����y�[���R�[�h�ő�l�擾
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findMaxCampCd() throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.MAX;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �L�����y�[���R�[�h�̃L�����y�[�����擾����.
     * @param �L�����y�[���R�[�h
     * @return �L�����y�[���ꗗ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignListByCampCd(String campaignCd) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.CD;
            _campCd = campaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �c�ƍ�Ƒ䒠�̓��̓f�[�^�ŃL�����y�[�����擾
     * @param cond ��������
     * @return �L�����y�[���ꗗ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignCd(Tbj12CampaignCondition cond) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.GETCAMPCD;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
