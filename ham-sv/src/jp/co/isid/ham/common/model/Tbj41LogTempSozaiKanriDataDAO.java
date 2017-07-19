package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj41LogTempSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���f�ޓo�^�ύX���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj41LogTempSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj41LogTempSozaiKanriDataCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, INS, UPD };
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj41LogTempSozaiKanriDataDAO() {
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
                Tbj41LogTempSozaiKanriData.NOKBN
                ,Tbj41LogTempSozaiKanriData.TEMPCMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj41LogTempSozaiKanriData.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj41LogTempSozaiKanriData.CRTDATE
                ,Tbj41LogTempSozaiKanriData.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj41LogTempSozaiKanriData.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj41LogTempSozaiKanriData.NOKBN
                ,Tbj41LogTempSozaiKanriData.TEMPCMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYNO
                ,Tbj41LogTempSozaiKanriData.CMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYKBN
                ,Tbj41LogTempSozaiKanriData.DELFLG
                ,Tbj41LogTempSozaiKanriData.DCARCD
                ,Tbj41LogTempSozaiKanriData.CATEGORY
                ,Tbj41LogTempSozaiKanriData.TITLE
                ,Tbj41LogTempSozaiKanriData.SECOND
                ,Tbj41LogTempSozaiKanriData.SYATAN
                ,Tbj41LogTempSozaiKanriData.NOHIN
                ,Tbj41LogTempSozaiKanriData.PRODUCT
                ,Tbj41LogTempSozaiKanriData.DATEFROM
                ,Tbj41LogTempSozaiKanriData.DATETO
                ,Tbj41LogTempSozaiKanriData.MLIMIT
                ,Tbj41LogTempSozaiKanriData.KLIMIT
                ,Tbj41LogTempSozaiKanriData.DATERECOG
                ,Tbj41LogTempSozaiKanriData.DATEPRT
                ,Tbj41LogTempSozaiKanriData.BIKO
                ,Tbj41LogTempSozaiKanriData.CRTDATE
                ,Tbj41LogTempSozaiKanriData.CRTNM
                ,Tbj41LogTempSozaiKanriData.CRTAPL
                ,Tbj41LogTempSozaiKanriData.CRTID
                ,Tbj41LogTempSozaiKanriData.UPDDATE
                ,Tbj41LogTempSozaiKanriData.UPDNM
                ,Tbj41LogTempSozaiKanriData.UPDAPL
                ,Tbj41LogTempSozaiKanriData.UPDID
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
            //Tbj41LogTempSozaiKanriDataVO�擾�pSQL�擾
            sql = getSelectSQLTbj41LogTempSozaiKanriDataVO();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj41LogTempSozaiKanriDataVO)
     */
    private String getSelectSQLTbj41LogTempSozaiKanriDataVO() {

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
            Tbj41LogTempSozaiKanriDataVO vo = new Tbj41LogTempSozaiKanriDataVO();
            vo.setNOKBN(_condition.getNokbn());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setHISTORYNO(_condition.getHistoryno());
            vo.setCMCD(_condition.getCmcd());
            vo.setHISTORYKBN(_condition.getHistorykbn());
            vo.setDELFLG(_condition.getDelflg());
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
        orderSql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * insertVO
     * @param vo �o�^VO
     * @throws HAMException
     */
    public void insertVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public void updateVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public void deleteVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public List<Tbj41LogTempSozaiKanriDataVO> selectVO(Tbj41LogTempSozaiKanriDataCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj41LogTempSozaiKanriDataVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
