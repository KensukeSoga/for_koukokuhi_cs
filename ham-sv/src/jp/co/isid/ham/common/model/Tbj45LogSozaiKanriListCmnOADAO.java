package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ވꗗ�i���LOA���ԁj���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/29 HLC K.Soga)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj45LogSozaiKanriListCmnOADAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj45LogSozaiKanriListCmnOACondition _condition = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, MAXSOZAIYM};

    /** �I��SQL���[�h�ϐ� */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj45LogSozaiKanriListCmnOADAO() {
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
                Tbj45LogSozaiKanriListCmnOA.DCARCD
                ,Tbj45LogSozaiKanriListCmnOA.SOZAIYM
                ,Tbj45LogSozaiKanriListCmnOA.RECKBN
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj45LogSozaiKanriListCmnOA.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj45LogSozaiKanriListCmnOA.CRTDATE
                ,Tbj45LogSozaiKanriListCmnOA.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj45LogSozaiKanriListCmnOA.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj45LogSozaiKanriListCmnOA.DCARCD
                ,Tbj45LogSozaiKanriListCmnOA.SOZAIYM
                ,Tbj45LogSozaiKanriListCmnOA.RECKBN
                ,Tbj45LogSozaiKanriListCmnOA.RECNO
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYNO
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYKBN
                ,Tbj45LogSozaiKanriListCmnOA.DELFLG
                ,Tbj45LogSozaiKanriListCmnOA.CMCD
                ,Tbj45LogSozaiKanriListCmnOA.TEMPCMCD
                ,Tbj45LogSozaiKanriListCmnOA.OADATETERM
                ,Tbj45LogSozaiKanriListCmnOA.CRTDATE
                ,Tbj45LogSozaiKanriListCmnOA.CRTNM
                ,Tbj45LogSozaiKanriListCmnOA.CRTAPL
                ,Tbj45LogSozaiKanriListCmnOA.CRTID
                ,Tbj45LogSozaiKanriListCmnOA.UPDDATE
                ,Tbj45LogSozaiKanriListCmnOA.UPDNM
                ,Tbj45LogSozaiKanriListCmnOA.UPDAPL
                ,Tbj45LogSozaiKanriListCmnOA.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj45LogSozaiKanriListCmnOA();
        } else if (_sqlMode.equals(SqlMode.MAXSOZAIYM)) {
            //�f�ޔN���̍ő�l�擾
            sql = getMaxSozaiYm();
        }

        return sql;
    };

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
     * SELECT SQL(Tbj45LogSozaiKanriListCmnOA)
     */
    private String getSelectSQLTbj45LogSozaiKanriListCmnOA() {

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
            Tbj45LogSozaiKanriListCmnOAVO vo = new Tbj45LogSozaiKanriListCmnOAVO();
            vo.setCMCD(_condition.getCmcd());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setDELFLG(_condition.getDelflg());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTID(_condition.getCrtid());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDID(_condition.getUpdid());
            vo.setUPDNM(_condition.getUpdnm());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };
    
    /**
     * �f�ޔN���̍ő�l�擾�pSQL�쐬
     * @return String SQL��
     */
    private String getMaxSozaiYm() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" MAX(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 " + Tbj45LogSozaiKanriListCmnOA.SOZAIYM);

        sql.append(" FROM");
        sql.append(" "+ Tbj45LogSozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DCARCD + " = '" + _condition.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj45LogSozaiKanriListCmnOAVO> selectVO(Tbj45LogSozaiKanriListCmnOACondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj45LogSozaiKanriListCmnOAVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * deleteVO
     * @param vo �폜VO
     * @throws HAMException
     */
    public void deleteVO(Tbj45LogSozaiKanriListCmnOAVO vo) throws HAMException {

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
     * �f�ޔN���̍ő�l�擾
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj45LogSozaiKanriListCmnOAVO> findMaxSozaiYm(Tbj45LogSozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj45LogSozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.MAXSOZAIYM;
            _condition = cond;
            return (List<Tbj45LogSozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}