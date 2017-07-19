package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�o�͐ݒ�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj13CarOutCtrlDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj13CarOutCtrlCondition _condition = null;

    /** �폜VO */
    private Mbj13CarOutCtrlVO _delVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj13CarOutCtrlDAO() {
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
        return Mbj13CarOutCtrl.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj13CarOutCtrl.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.REPORTCD
                ,Mbj13CarOutCtrl.DCARCD
                ,Mbj13CarOutCtrl.OUTPUTFLG
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj13CarOutCtrl.PHASE
                ,Mbj13CarOutCtrl.UPDDATE
                ,Mbj13CarOutCtrl.UPDNM
                ,Mbj13CarOutCtrl.UPDAPL
                ,Mbj13CarOutCtrl.UPDID
        };
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (super.getModel() instanceof Mbj13CarOutCtrlVO) {
            // Mbj13CarOutCtrlVO�擾�pSQL�擾
            sql = getSelectSQLMbj13CarOutCtrlVO();
        }

        return sql;
    }

    /**
     * EXEC SQL
     */
    @Override
    public String getExecString() {

        String sql = "";

        if (_delVO != null) {
            // Mbj13CarOutCtrlVO�폜�pSQL�擾
            sql = getDeleteSQLMbj13CarOutCtrlVO();
        }

        return sql;
    }

    /**
     * SELECT SQL�iMbj13CarOutCtrlVO�j
     */
    private String getSelectSQLMbj13CarOutCtrlVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()�Afind()�Ŏg�p�����SELECT + FROM���SQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null)
        {
            Mbj13CarOutCtrlVO vo = new Mbj13CarOutCtrlVO();
            vo.setREPORTCD(_condition.getReportcd());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setOUTPUTFLG(_condition.getOutputflg());
            vo.setSORTNO(_condition.getSortno());
            vo.setPHASE(_condition.getPhase());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**
     * DELETE SQL�iMbj13CarOutCtrlVO�j
     */
    private String getDeleteSQLMbj13CarOutCtrlVO() {

        StringBuffer deleteSql = new StringBuffer();
        String whereSqlStr = "";

        deleteSql.append(" DELETE ");
        deleteSql.append(" FROM ");
        deleteSql.append(" " + getTableName() + " ");

        if (_delVO != null) {
            whereSqlStr = generateWhereByCond(_delVO);
        }

        return deleteSql.toString() + whereSqlStr;
    }

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj13CarOutCtrlVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            if (!super.insert()) {
                throw new HAMException("�o�^�G���[", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void updateVO(Mbj13CarOutCtrlVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("�X�V�G���[", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void deleteVO(Mbj13CarOutCtrlVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }

        // �v���C�}���L�[���Ȃ�����remove()���g���Ȃ��̂ŁA�폜������Ǝ�����
        _delVO = vo;

        try {
            super.exec();   // exec()�ō폜���������s����
        } catch(UserException e) {
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
    public List<Mbj13CarOutCtrlVO> selectVO(Mbj13CarOutCtrlCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj13CarOutCtrlVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}