package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���ʃR�[�h�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu29CcDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private RepaVbjaMeu29CcCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{COND, CD};
    private SelSqlMode _SelSqlMode = SelSqlMode.COND;


    /** �R�[�h��ێ� */
    private String _code = null;

    /** ���eJ�H��ێ� */
    private String _naiyoJ = null;

    /** �p�~�N�� */
    private static String ENDYM = "99999999";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu29CcDAO() {
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
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return RepaVbjaMeu29Cc.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu29Cc.KYCDKND
                ,RepaVbjaMeu29Cc.KYCD
                ,RepaVbjaMeu29Cc.HKYMD
                ,RepaVbjaMeu29Cc.HAISYMD
                ,RepaVbjaMeu29Cc.NAIYKN
                ,RepaVbjaMeu29Cc.NAIYJ
                ,RepaVbjaMeu29Cc.YOBI1
                ,RepaVbjaMeu29Cc.HOSOK
                ,RepaVbjaMeu29Cc.YOBI2
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        if (_SelSqlMode.equals(SelSqlMode.COND)) {
            return getCodeMasterByCond();
        } else if (_SelSqlMode.equals(SelSqlMode.CD)) {
            return getCodeMasterByCd();
        } else {
            return null;
        }
    }

    /**
     * �w�肵�������ɏ]���Č�������SQL�����擾����
     *
     * @return SQL��
     */
    private String getCodeMasterByCond() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";

        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null)
        {
            RepaVbjaMeu29CcVO vo = new RepaVbjaMeu29CcVO();
            vo.setKYCDKND(_condition.getKycdknd());
            vo.setKYCD(_condition.getKycd());
            vo.setHKYMD(_condition.getHkymd());
            vo.setHAISYMD(_condition.getHaisymd());
            vo.setNAIYKN(_condition.getNaiykn());
            vo.setNAIYJ(_condition.getNaiyj());
            vo.setYOBI1(_condition.getYobi1());
            vo.setHOSOK(_condition.getHosok());
            vo.setYOBI2(_condition.getYobi2());
            whereSqlStr = generateWhereByCond(vo);
        }

        return selectSql.toString() + whereSqlStr;
    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {

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
     * �L�[�R�[�h�������s��
     * @return SQL��
     */
    private String getCodeMasterByCd() {

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
        sql.append(" " + RepaVbjaMeu29Cc.KYCDKND + " IN(" + _code + ") ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.NAIYJ + " LIKE('%" + _naiyoJ + "%') ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.HAISYMD + " ='" + ENDYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu29Cc.KYCDKND + " ASC, ");
        sql.append(" " + RepaVbjaMeu29Cc.KYCD + " ASC ");

        return sql.toString();
    }

    /**
     * �L�[�R�[�h�������s��
     * @param code �����Ώۂ̃R�[�h
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu29CcVO> FindCodeMasterByCode(String code,String naiyoJ) throws HAMException {

        super.setModel(new RepaVbjaMeu29CcVO());

        try {
            _code = code;
            _naiyoJ = naiyoJ;
            _SelSqlMode = SelSqlMode.CD;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu29CcVO> selectVO(RepaVbjaMeu29CcCondition condition) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new RepaVbjaMeu29CcVO());
        try {
            _SelSqlMode = SelSqlMode.COND;
            _condition = condition;
            return (List<RepaVbjaMeu29CcVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
