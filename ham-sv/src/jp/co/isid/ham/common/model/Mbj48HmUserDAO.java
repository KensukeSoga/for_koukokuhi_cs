package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj48HmUser;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���[�U�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj48HmUserDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj48HmUserCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj48HmUserDAO() {
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
                Mbj48HmUser.PHASE
                ,Mbj48HmUser.TERM
                ,Mbj48HmUser.HMUSERCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj48HmUser.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj48HmUser.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj48HmUser.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj48HmUser.PHASE
                ,Mbj48HmUser.TERM
                ,Mbj48HmUser.HMUSERCD
                ,Mbj48HmUser.HMUSERNM
                ,Mbj48HmUser.HMUSEREXTENSIONNO
                ,Mbj48HmUser.SORTNO
                ,Mbj48HmUser.UPDDATE
                ,Mbj48HmUser.UPDNM
                ,Mbj48HmUser.UPDAPL
                ,Mbj48HmUser.UPDID
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

        if (super.getModel() instanceof Mbj48HmUserVO) {

            // Mbj48HmUserVO�擾�pSQL�擾
            sql = getSelectSQLMbj48HmUserVO();
        }

        return sql;
    }

    /**
     * SELECT SQL(Mbj48HmUserVO)
     */
    private String getSelectSQLMbj48HmUserVO() {

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

        if (_condition != null) {

            Mbj48HmUserVO vo = new Mbj48HmUserVO();

            vo.setPHASE(_condition.getPhase());
            vo.setTERM(_condition.getTerm());
            vo.setHMUSERCD(_condition.getHmusercd());
            vo.setHMUSERNM(_condition.getHmusernm());
            vo.setHMUSEREXTENSIONNO(_condition.getHmuserextensionno());
            vo.setSORTNO(_condition.getSortno());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj48HmUser.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj48HmUserVO vo) throws HAMException {

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
    public void updateVO(Mbj48HmUserVO vo) throws HAMException {

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
    public void deleteVO(Mbj48HmUserVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("�폜�G���[", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            //���������u0�v�̏ꍇ

            //����Ƃ���(�폜���R�[�h�Ȃ�)
            return;
        } catch(UpdateFailureException e)
        {   // ���������u2�ȏ�v�̏ꍇ

            //����Ƃ���
            return;
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
    public List<Mbj48HmUserVO> selectVO(Mbj48HmUserCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj48HmUserVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}