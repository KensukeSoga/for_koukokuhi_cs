package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj39RdProgramStation;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I�ԑg�l�b�g��DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj39RdProgramStationDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj39RdProgramStationCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, INS, UPD };
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj39RdProgramStationDAO() {
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
                Tbj39RdProgramStation.RDSEQNO
                ,Tbj39RdProgramStation.STATIONCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj39RdProgramStation.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.INS)) {
            return new String[] {
                    Tbj39RdProgramStation.CRTDATE
                    ,Tbj39RdProgramStation.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj39RdProgramStation.UPDDATE
            };
        } else {
            return new String[] { };
        }
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj39RdProgramStation.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj39RdProgramStation.RDSEQNO
                ,Tbj39RdProgramStation.STATIONCD
                ,Tbj39RdProgramStation.CRTDATE
                ,Tbj39RdProgramStation.CRTNM
                ,Tbj39RdProgramStation.CRTAPL
                ,Tbj39RdProgramStation.CRTID
                ,Tbj39RdProgramStation.UPDDATE
                ,Tbj39RdProgramStation.UPDNM
                ,Tbj39RdProgramStation.UPDAPL
                ,Tbj39RdProgramStation.UPDID
        };
    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.FIND)) {
            //Tbj39RdProgramStationVO�擾�pSQL�擾
            sql = getSelectSQLTbj39RdProgramStationVO();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj39RdProgramStationVO)
     */
    private String getSelectSQLTbj39RdProgramStationVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {
            Tbj39RdProgramStationVO vo = new Tbj39RdProgramStationVO();
            vo.setRDSEQNO(_condition.getRdseqno());
            vo.setSTATIONCD(_condition.getStationcd());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTID(_condition.getCrtid());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj39RdProgramStation.RDSEQNO + ",");
        orderSql.append(" " + Tbj39RdProgramStation.STATIONCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * insertVO
     * @param vo �o�^VO
     * @throws HAMException
     */
    public void insertVO(Tbj39RdProgramStationVO vo) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.INS;

        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * updateVO
     * @param vo �X�VVO
     * @throws HAMException
     */
    public void updateVO(Tbj39RdProgramStationVO vo) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.UPD;

        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * deleteVO
     * @param vo �폜VO
     * @throws HAMException
     */
    public void deleteVO(Tbj39RdProgramStationVO vo) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }

        super.setModel(vo);

        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj39RdProgramStationVO> selectVO(Tbj39RdProgramStationCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj39RdProgramStationVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
