package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj44LogSozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ވꗗ�i���L�j���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/03/10 HDX�Ή� K.Soga)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj44LogSozaiKanriListCmnDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj44LogSozaiKanriListCmnCondition _condition = null;

    /** �o�^�f�[�^ */
    private Tbj44LogSozaiKanriListCmnVO _vo = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, DEL};

    /** �I��SQL���[�h�ϐ� */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** �f�t�H���g�R���X�g���N�^ */
    public Tbj44LogSozaiKanriListCmnDAO() {
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
                Tbj44LogSozaiKanriListCmn.DCARCD
                ,Tbj44LogSozaiKanriListCmn.SOZAIYM
                ,Tbj44LogSozaiKanriListCmn.RECKBN
                ,Tbj44LogSozaiKanriListCmn.RECNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj44LogSozaiKanriListCmn.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj44LogSozaiKanriListCmn.CRTDATE
                ,Tbj44LogSozaiKanriListCmn.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj44LogSozaiKanriListCmn.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj44LogSozaiKanriListCmn.DCARCD
                ,Tbj44LogSozaiKanriListCmn.SOZAIYM
                ,Tbj44LogSozaiKanriListCmn.RECKBN
                ,Tbj44LogSozaiKanriListCmn.RECNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYKBN
                ,Tbj44LogSozaiKanriListCmn.DELFLG
                ,Tbj44LogSozaiKanriListCmn.CMCD
                ,Tbj44LogSozaiKanriListCmn.TEMPCMCD
                ,Tbj44LogSozaiKanriListCmn.ALIASTITLE
                ,Tbj44LogSozaiKanriListCmn.ENDTITLE
                ,Tbj44LogSozaiKanriListCmn.BSCSUSE
                ,Tbj44LogSozaiKanriListCmn.TIMEUSE
                ,Tbj44LogSozaiKanriListCmn.SPOTUSE
                ,Tbj44LogSozaiKanriListCmn.SPOTCTRT
                ,Tbj44LogSozaiKanriListCmn.SPOTFROM
                ,Tbj44LogSozaiKanriListCmn.SPOTTO
                ,Tbj44LogSozaiKanriListCmn.HMORDER
                ,Tbj44LogSozaiKanriListCmn.LAYOUTORDER
                ,Tbj44LogSozaiKanriListCmn.OANGSPAN
                ,Tbj44LogSozaiKanriListCmn.TARGET
                ,Tbj44LogSozaiKanriListCmn.CARNEWS
                ,Tbj44LogSozaiKanriListCmn.NEXTCARNEWS
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3
                ,Tbj44LogSozaiKanriListCmn.CRTDATE
                ,Tbj44LogSozaiKanriListCmn.CRTNM
                ,Tbj44LogSozaiKanriListCmn.CRTAPL
                ,Tbj44LogSozaiKanriListCmn.CRTID
                ,Tbj44LogSozaiKanriListCmn.UPDDATE
                ,Tbj44LogSozaiKanriListCmn.UPDNM
                ,Tbj44LogSozaiKanriListCmn.UPDAPL
                ,Tbj44LogSozaiKanriListCmn.UPDID
        };
    }

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj44LogSozaiKanriListCmn();
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

    /** SELECT SQL(Tbj44LogSozaiKanriListCmn) */
    private String getSelectSQLTbj44LogSozaiKanriListCmn() {

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
            Tbj44LogSozaiKanriListCmnVO vo = new Tbj44LogSozaiKanriListCmnVO();
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCMCD(_condition.getCmcd());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj44LogSozaiKanriListCmn.CRTDATE);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();


        //�f�ވꗗ(����)���O�폜
        if (_sqlMode.equals(SqlMode.DEL)) {

            sql.append("DELETE");
            sql.append(" FROM");
            sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME);

            sql.append(" WHERE");
            //�{�f��
            if(_vo.getCMCD() != null){
                sql.append(" " + Tbj44LogSozaiKanriListCmn.CMCD + " = '" + _vo.getCMCD() + "' AND");
            }else{
                sql.append(" " + Tbj44LogSozaiKanriListCmn.CMCD + " IS NULL AND");
            }
            //���f��
            if(_vo.getTEMPCMCD() != null){
                sql.append(" " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            }else{
                sql.append(" " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + " IS NULL");
            }
        }

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj44LogSozaiKanriListCmnVO>selectVO(Tbj44LogSozaiKanriListCmnCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj44LogSozaiKanriListCmnVO());
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
    public void deleteVO(Tbj44LogSozaiKanriListCmnVO vo) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.DEL;
        _vo = vo;
        try {
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}