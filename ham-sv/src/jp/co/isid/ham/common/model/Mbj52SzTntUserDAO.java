package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.SzTntUserListVO;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�S���҃}�X�^(�f��)DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/23 HLC K.Oki)<BR>
 * �EHDX�s��Ή�(2016/06/08 HLC K.Soga)<BR>
 * </P>
 * @author K.Oki
 */
public class Mbj52SzTntUserDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj52SzTntUserCondition _condition = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, SYATANUSER, DELETE};

    /** �I��SQL���[�h�ϐ� */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** �f�t�H���g�R���X�g���N�^ */
    public Mbj52SzTntUserDAO() {
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
                Mbj52SzTntUser.DCARCD
                , Mbj52SzTntUser.USERSEQ
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj52SzTntUser.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj52SzTntUser.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj52SzTntUser.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj52SzTntUser.DCARCD
                , Mbj52SzTntUser.USERSEQ
                , Mbj52SzTntUser.USERID
                , Mbj52SzTntUser.SORTNO
                , Mbj52SzTntUser.UPDDATE
                , Mbj52SzTntUser.UPDNM
                , Mbj52SzTntUser.UPDAPL
                , Mbj52SzTntUser.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSeqSorSQL();
        } else if (_sqlMode.equals(SqlMode.SYATANUSER)) {
            //�Ԏ�S�����擾
            sql = getSyatanUser();
        }

        return sql;
    }

    /**
     * DELETE SQL
     */
    @Override
    public String getExecString() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DELETE)) {
            sql = getDeleteUserID();
        }

        return sql.toString();
    }

    /**
     * �S����SEQ�A�y�у\�[�gNo�̍ő�l���擾����
     */
    private String getSelectSeqSorSQL()
    {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");

        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length -1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(" " + getTableName());
        sql.append(" WHERE");
        sql.append(" " + Mbj52SzTntUser.USERSEQ + " = ");
        sql.append("(SELECT");
        sql.append(" MAX(" + Mbj52SzTntUser.USERSEQ + ")");

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Mbj52SzTntUser.DCARCD + " = '" + _condition.getDcarcd() + "') AND");
        sql.append(" " + Mbj52SzTntUser.DCARCD + " = '" + _condition.getDcarcd() + "'");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(" " +getTableColumnNames()[i]);
            if (i < getTableColumnNames().length -1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());
        sql.append(" WHERE");
        sql.append(" " + Mbj52SzTntUser.SORTNO + " = ");
        sql.append("(SELECT");
        sql.append(" MAX(" + Mbj52SzTntUser.SORTNO + ")");
        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Mbj52SzTntUser.DCARCD + " = '" + _condition.getDcarcd() + "') AND");
        sql.append(" " + Mbj52SzTntUser.DCARCD + " = '" + _condition.getDcarcd() +"'");

        return sql.toString();
    }

    /**
     * �Ԏ�S���Ґ��A�����擾����
     */
    private String getSyatanUser()
    {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Mbj02User.USERNAME1 + ",");
        sql.append(" " + Mbj02User.USERNAME2 + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Mbj52SzTntUser.DCARCD);

        sql.append(" FROM");
        sql.append(" " + Mbj02User.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        /** 2016/06/08 HDX�s��Ή� HLC K.Soga ADD Start */
        sql.append(" " + Mbj12Code.TBNAME + ",");
        sql.append(" " + T_UserInfo.TBNAME + ",");
        /** 2016/06/08 HDX�s��Ή� HLC K.Soga ADD End */
        sql.append(" " + Mbj52SzTntUser.TBNAME);

        sql.append(" WHERE");
        sql.append(" TRIM(" + Mbj02User.HAMID + ") = " + Mbj52SzTntUser.USERID + "(+) AND");
        sql.append(" " + Mbj52SzTntUser.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        /** 2016/06/08 HDX�s��Ή� HLC K.Soga ADD Start */
        sql.append(" " + Mbj12Code.CODETYPE + " = '" + HAMConstants.CODETYPE_SYATAN + "' AND");
        sql.append(" " + Mbj12Code.CODENAME + " = '" + HAMConstants.CODENAME_SYATAN + "' AND");
        sql.append(" " + Mbj52SzTntUser.USERID + " = " + T_UserInfo.USERID + " AND");
        sql.append(" " + T_UserInfo.SECURITYGROUPCODE + " = " + Mbj12Code.YOBI1 + " AND");
        sql.append(" " + T_UserInfo.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" " + T_UserInfo.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" " + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        /** 2016/06/08 HDX�s��Ή� HLC K.Soga ADD End */
        sql.append(" " + Mbj52SzTntUser.DCARCD + " IS NOT NULL");

        return sql.toString();
    }

    /**
     * DELETE SQL�iUSERID�w��j
     */
    private String getDeleteUserID() {

        StringBuffer sql = new StringBuffer();
        String whereSqlStr = null;

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Mbj52SzTntUser.TBNAME + " ");

        whereSqlStr = generateWhereByCond(super.getModel());

        return sql.toString() + whereSqlStr;
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
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj52SzTntUserVO> selectVO(Mbj52SzTntUserCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj52SzTntUserVO());
        _condition = condition;
        _sqlMode = SqlMode.DEFAULT;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }


    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj52SzTntUserVO vo) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (vo == null)
        {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);

        try
        {
            if (!super.insert())
            {
                throw new HAMException("�o�^�G���[", "BJ-E0002");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * DeleteVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void deleteVO(Mbj52SzTntUserVO vo) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (vo == null)
        {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);

        try
        {
            if (!super.remove())
            {
                throw new HAMException("�폜�G���[", "BJ-E0004");
            }
        }
        catch(ConcurrentUpdateException e)
        {
            // ���������u0�v�̏ꍇ
            // ����Ƃ���i�폜���R�[�h�Ȃ��j
            return;
        }
        catch(UpdateFailureException e)
        {
            // ���������u2�ȏ�v�̏ꍇ
            // ����Ƃ���
            return;
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * �S���Ґ��A���擾
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SzTntUserListVO> findSyatanUser(Mbj52SzTntUserCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new SzTntUserListVO());
        _condition = condition;
        _sqlMode = SqlMode.SYATANUSER;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �폜(USERID�w��)
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void deleteVOWhereUserID(Mbj52SzTntUserVO vo) throws HAMException
    {
        //�p�����[�^�`�F�b�N
        if (vo == null)
        {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.DELETE;

        try
        {
            super.exec();
        }
        catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }
}
