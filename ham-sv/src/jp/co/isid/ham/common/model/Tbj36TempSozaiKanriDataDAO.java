package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���f�ޓo�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj36TempSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj36TempSozaiKanriDataCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, INS, UPD};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** �f�t�H���g�R���X�g���N�^ */
    public Tbj36TempSozaiKanriDataDAO() {
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
                Tbj36TempSozaiKanriData.NOKBN
                ,Tbj36TempSozaiKanriData.TEMPCMCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj36TempSozaiKanriData.UPDDATE;
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
                    Tbj36TempSozaiKanriData.CRTDATE
                    ,Tbj36TempSozaiKanriData.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj36TempSozaiKanriData.UPDDATE
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
        return Tbj36TempSozaiKanriData.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj36TempSozaiKanriData.NOKBN
                ,Tbj36TempSozaiKanriData.TEMPCMCD
                ,Tbj36TempSozaiKanriData.CMCD
                ,Tbj36TempSozaiKanriData.STATUS
                ,Tbj36TempSozaiKanriData.DCARCD
                ,Tbj36TempSozaiKanriData.CATEGORY
                ,Tbj36TempSozaiKanriData.TITLE
                /** 2016/02/17 HDX�Ή� HLC K.Soga ADD Start */
                ,Tbj36TempSozaiKanriData.ALIASTITLE
                ,Tbj36TempSozaiKanriData.ENDTITLE
                ,Tbj36TempSozaiKanriData.DATEFROM_ATTR
                ,Tbj36TempSozaiKanriData.DATETO_ATTR
                /** 2016/02/17 HDX�Ή� HLC K.Soga ADD End */
                ,Tbj36TempSozaiKanriData.SECOND
                ,Tbj36TempSozaiKanriData.SYATAN
                ,Tbj36TempSozaiKanriData.NOHIN
                ,Tbj36TempSozaiKanriData.PRODUCT
                ,Tbj36TempSozaiKanriData.DATEFROM
                ,Tbj36TempSozaiKanriData.DATETO
                ,Tbj36TempSozaiKanriData.MLIMIT
                ,Tbj36TempSozaiKanriData.KLIMIT
                ,Tbj36TempSozaiKanriData.DATERECOG
                ,Tbj36TempSozaiKanriData.DATEPRT
                ,Tbj36TempSozaiKanriData.BIKO
                ,Tbj36TempSozaiKanriData.CRTDATE
                ,Tbj36TempSozaiKanriData.CRTNM
                ,Tbj36TempSozaiKanriData.CRTAPL
                ,Tbj36TempSozaiKanriData.CRTID
                ,Tbj36TempSozaiKanriData.UPDDATE
                ,Tbj36TempSozaiKanriData.UPDNM
                ,Tbj36TempSozaiKanriData.UPDAPL
                ,Tbj36TempSozaiKanriData.UPDID
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

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            //Tbj36TempSozaiKanriDataVO�擾�pSQL�擾
            sql = getSelectSQLTbj36TempSozaiKanriDataVO();
        } else if (_sqlMode.equals(SqlMode.FIND)) {
            //���f�ޏ��擾SQL
            sql = getSelectSQLFind();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj36TempSozaiKanriDataVO)
     */
    private String getSelectSQLTbj36TempSozaiKanriDataVO() {

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
            Tbj36TempSozaiKanriDataVO vo = new Tbj36TempSozaiKanriDataVO();
            vo.setNOKBN(_condition.getNokbn());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setCMCD(_condition.getCmcd());
            vo.setSTATUS(_condition.getStatus());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCATEGORY(_condition.getCategory());
            vo.setTITLE(_condition.getTitle());
            vo.setSECOND(_condition.getSecond());
            vo.setSYATAN(_condition.getSyatan());
            vo.setNOHIN(_condition.getNohin());
            vo.setPRODUCT(_condition.getProduct());
            vo.setDATEFROM(_condition.getDatefrom());
            vo.setDATETO(_condition.getDateto());
            vo.setMLIMIT(_condition.getMlimit());
            vo.setKLIMIT(_condition.getKlimit());
            vo.setDATERECOG(_condition.getDaterecog());
            vo.setDATEPRT(_condition.getDateprt());
            vo.setBIKO(_condition.getBiko());
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
        orderSql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
        orderSql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * ���f�ޏ��擾
     * @return ���f�ޏ��擾SQL
     */
    private String getSelectSQLFind() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append(getTableColumnNames()[i] + " ");
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD);

        return sql.toString();
    }

    /**
     * insertVO
     * @param vo �o�^VO
     * @throws HAMException
     */
    public void insertVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

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
    public void updateVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

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
    public void deleteVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

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
    public List<Tbj36TempSozaiKanriDataVO> findVO(Tbj36TempSozaiKanriDataCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj36TempSozaiKanriDataVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj36TempSozaiKanriDataVO> selectVO(Tbj36TempSozaiKanriDataCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj36TempSozaiKanriDataVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}