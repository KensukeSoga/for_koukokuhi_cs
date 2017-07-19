package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ވꗗDAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * �EJASRAC�Ή�(2015/11/25 HLC K.Soga)<BR>
 * �EHDX�Ή�(2016/02/18 HLC K.Soga)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj20SozaiKanriListDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj20SozaiKanriListCondition _condition = null;
    private List<Tbj20SozaiKanriListVO> _conditions = null;

    /** SQL���[�h */
    private enum SqlMode {RCODE, MAXRECNO, MULTIPK, MULTICMCD, INS, UPD, NEWNO};
    private SqlMode _sqlMode = SqlMode.RCODE;

    /** �f�t�H���g�R���X�g���N�^ */
    public Tbj20SozaiKanriListDAO() {
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
                Tbj20SozaiKanriList.DCARCD
                ,Tbj20SozaiKanriList.SOZAIYM
                ,Tbj20SozaiKanriList.RECKBN
                ,Tbj20SozaiKanriList.RECNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj20SozaiKanriList.UPDDATE;
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
                    Tbj20SozaiKanriList.CRTDATE
                    ,Tbj20SozaiKanriList.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj20SozaiKanriList.UPDDATE
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
        return Tbj20SozaiKanriList.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj20SozaiKanriList.DCARCD
                ,Tbj20SozaiKanriList.SOZAIYM
                ,Tbj20SozaiKanriList.RECKBN
                ,Tbj20SozaiKanriList.RECNO
                ,Tbj20SozaiKanriList.DELFLG
                ,Tbj20SozaiKanriList.CMCD
                ,Tbj20SozaiKanriList.TEMPCMCD
                ,Tbj20SozaiKanriList.TITLE
                ,Tbj20SozaiKanriList.SECOND
                ,Tbj20SozaiKanriList.RCODE
                ,Tbj20SozaiKanriList.ESTIMATE
                ,Tbj20SozaiKanriList.DATEFROM
                ,Tbj20SozaiKanriList.DATETO
                /** 2016/02/18 HDX�Ή� HLC K.Soga ADD Start */
                ,Tbj20SozaiKanriList.DATEFROM_ATTR
                ,Tbj20SozaiKanriList.DATETO_ATTR
                ,Tbj20SozaiKanriList.NEWDISPFLG
                ,Tbj20SozaiKanriList.OPENFLG
                ,Tbj20SozaiKanriList.HCSYATAN
                ,Tbj20SozaiKanriList.HMSYATAN
                /** 2016/02/18 HDX�Ή� HLC K.Soga ADD End */
                ,Tbj20SozaiKanriList.NEWFLG
                ,Tbj20SozaiKanriList.TIMEUSE
                ,Tbj20SozaiKanriList.SPOTUSE
                ,Tbj20SozaiKanriList.SPOTCTRT
                ,Tbj20SozaiKanriList.SPOTSPAN
                ,Tbj20SozaiKanriList.SPOTESTM
                ,Tbj20SozaiKanriList.LIMIT
                ,Tbj20SozaiKanriList.SYATAN
                ,Tbj20SozaiKanriList.BIKO
                ,Tbj20SozaiKanriList.FORECOLOR
                ,Tbj20SozaiKanriList.BACKCOLOR
                ,Tbj20SozaiKanriList.CRTDATE
                ,Tbj20SozaiKanriList.CRTNM
                ,Tbj20SozaiKanriList.CRTAPL
                ,Tbj20SozaiKanriList.CRTID
                ,Tbj20SozaiKanriList.UPDDATE
                ,Tbj20SozaiKanriList.UPDNM
                ,Tbj20SozaiKanriList.UPDAPL
                ,Tbj20SozaiKanriList.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = null;
        if (_sqlMode.equals(SqlMode.RCODE)) {
            sql = getSozaiKanriByRCode();
        } else if (_sqlMode.equals(SqlMode.MAXRECNO)) {
            sql = getMaxRecNoByConditoin();
        } else if (_sqlMode.equals(SqlMode.MULTIPK)) {
            sql = getSelectSQLForMultiPK();
        } else if (_sqlMode.equals(SqlMode.MULTICMCD)) {
            sql = getSelectSQLForMultiCmCd();
        /** 2016/03/10 HDX�Ή� HLC K.Soga ADD Start */
        } else if (_sqlMode.equals(SqlMode.NEWNO)) {
            sql = getFindNewNo();
        }
        /** 2016/03/10 HDX�Ή� HLC K.Soga ADD End */
        return sql;
    }

    /**
     * ���R�[�h�ɂ�錟���pSQL�쐬
     * @return String SQL��
     */
    private String getSozaiKanriByRCode() {
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
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " = '" + _condition.getRcode() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_condition.getSozaiym()) + " ");

        return sql.toString();
    }

    /**
     * �쐬�ԍ��̍ő�l�擾�pSQL�쐬
     * @return String SQL��
     */
    private String getMaxRecNoByConditoin() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "),0) + 1,'FM0000') AS " + Tbj20SozaiKanriList.RECNO);
        sql.append("  FROM " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" WHERE " + Tbj20SozaiKanriList.DCARCD + " = " + "'" + _condition.getDcarcd() + "'" );
        sql.append("   AND " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_condition.getSozaiym()));
        sql.append("   AND " + Tbj20SozaiKanriList.RECKBN + " = " + "'" + _condition.getReckbn() + "'" );

        return sql.toString();
    }

    /**
     * ����PK�����pSQL�쐬
     * @return String ����PK����
     */
    private String getSelectSQLForMultiPK() {

        StringBuffer sql = new StringBuffer();

        // �r���pSQL
        sql.append(" SELECT ");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            AbstractModel cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" ( ");
            for (int j = 0; j < getPrimryKeyNames().length; j++) {
                sql.append((j != 0 ? " AND " : " "));
                sql.append("" + getPrimryKeyNames()[j] +" ");
                sql.append(" = ");
                sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
            }
            sql.append(" ) ");
        }

        return sql.toString();
    }

    /**
     * 10��CM�R�[�h�A�N���Ō����pSQL�쐬(�r���`�F�b�N�p)
     * @return String SQL��
     */
    private String getSelectSQLForMultiCmCd() {

        StringBuffer sql = new StringBuffer();

        /** 2015/11/24 JASRAC�Ή� HLC K.Soga MOD Start */
//        sql.append(" SELECT ");
//        sql.append(" " + getTimeStampKeyName() + " ");
//        for (int i = 0; i < getPrimryKeyNames().length; i++) {
//            sql.append(" ," + getPrimryKeyNames()[i] +" ");
//        }
//        sql.append(" FROM ");
//        sql.append(" " + getTableName() + " ");
//        sql.append(" WHERE ");
//        for (int i = 0; i < _conditions.size(); i++) {
//            Tbj20SozaiKanriListVO cond = _conditions.get(i);
//            sql.append((i != 0 ? " OR " : " "));
//            sql.append(" ( ");
//            sql.append("" + Tbj20SozaiKanriList.SOZAIYM +" ");
//            sql.append(" = ");
//            sql.append(getDBModelInterface().ConvertToDBString(cond.getSOZAIYM()));
//            sql.append(" AND ");
//            sql.append("" + Tbj20SozaiKanriList.CMCD +" ");
//            sql.append(" = ");
//            sql.append(getDBModelInterface().ConvertToDBString(cond.getCMCD()));
//            sql.append(" ) ");
//        }

        sql.append(" SELECT");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] + " ");
        }

        sql.append(" FROM");
        sql.append(" " + getTableName() + " ");

        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            Tbj20SozaiKanriListVO cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" (");
            sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = " + "' ' AND");
            sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(cond.getSOZAIYM()) + " AND");
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + getDBModelInterface().ConvertToDBString(cond.getCMCD()));
            sql.append(" ) ");
        }

        return sql.toString();
    }
    /** 2015/11/24 JASRAC�Ή� HLC K.Soga MOD End */

    /** 2016/03/10 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * NewNo(RECNO)�����pSQL�쐬
     * @return String SQL��
     */
    private String getFindNewNo() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Tbj20SozaiKanriList.RECNO);

        sql.append(" FROM ");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");
        //�{�f��
        if(_condition.getCmcd() != null){
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " = '" + _condition.getCmcd() + "' AND");
        }else{
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        }
        //���f��
        if(_condition.getTempcmcd() != null){
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = '" + _condition.getTempcmcd() + "' AND");
        }else{
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NULL AND");
        }
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }
    /** 2016/03/10 HDX�Ή� HLC K.Soga ADD End */

    /**
     * ���R�[�h�ɂ�錟��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> FindSozaiKanriByRCode(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.RCODE;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �쐬�ԍ��̍ő�l�擾
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> findMaxRecNoByConditoin(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MAXRECNO;
            _condition = cond;
            return (List<Tbj20SozaiKanriListVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ����PK�����ł̌���
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> selectByMultiPk(List<Tbj20SozaiKanriListVO> cond) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MULTIPK;
            _conditions = cond;
            return (List<Tbj20SozaiKanriListVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 10��CM�R�[�h�A�N���Ō���
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> selectByMultiCmCd(List<Tbj20SozaiKanriListVO> cond) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MULTICMCD;
            _conditions = cond;
            return (List<Tbj20SozaiKanriListVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /** 2016/03/10 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * �쐬�ԍ�(NewNo/RECNO)����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> FindNewNo(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.NEWNO;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    /** 2016/03/10 HDX�Ή� HLC K.Soga ADD End */

    /**
     * �o�^����
     * @param vo �o�^VO
     * @throws HAMException
     */
    public void insertVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
     * �X�V����
     * @param vo �X�VVO
     * @throws HAMException
     */
    public void updateVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
     * �폜����
     * @param vo �폜VO
     * @throws HAMException
     */
    public void deleteVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
}