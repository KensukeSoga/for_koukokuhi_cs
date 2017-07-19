package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj44SecurityBase;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Z�L�����e�B�x�[�X�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/19 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj44SecurityBaseDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj44SecurityBaseCondition _condition = null;

    private enum SqlMode{SINGLE,MANY};
    private SqlMode _sqlMode = SqlMode.SINGLE;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj44SecurityBaseDAO() {
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
                Mbj44SecurityBase.KKSIKOGNZUNTCD
                ,Mbj44SecurityBase.USERTYPE
                ,Mbj44SecurityBase.SECURITYCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj44SecurityBase.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj44SecurityBase.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj44SecurityBase.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj44SecurityBase.KKSIKOGNZUNTCD
                ,Mbj44SecurityBase.USERTYPE
                ,Mbj44SecurityBase.SECURITYCD
                ,Mbj44SecurityBase.SECURITYTYPE
                ,Mbj44SecurityBase.UPDATE
                ,Mbj44SecurityBase.CHECK
                ,Mbj44SecurityBase.REFERENCE
                ,Mbj44SecurityBase.UPDDATE
                ,Mbj44SecurityBase.UPDNM
                ,Mbj44SecurityBase.UPDAPL
                ,Mbj44SecurityBase.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

//        if (super.getModel() instanceof Mbj44SecurityBaseVO)
//        {
//            // Mbj44SecurityBaseVO�擾�pSQL�擾
//            sql = getSelectSQLMbj44SecurityBaseVO();
//        }

        if (_sqlMode.equals(SqlMode.SINGLE)) {
            sql = getSelectSQLMbj44SecurityBaseVO();
        } else if (_sqlMode.equals(SqlMode.MANY)) {
            sql = getManyCd();
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
     * SELECT SQL�iMbj44SecurityBaseVO�j
     */
    private String getSelectSQLMbj44SecurityBaseVO()
    {
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
            Mbj44SecurityBaseVO vo = new Mbj44SecurityBaseVO();
            vo.setKKSIKOGNZUNTCD(_condition.getKksikognzuntcd());
            vo.setUSERTYPE(_condition.getUsertype());
            vo.setSECURITYCD(_condition.getSecuritycd());
            vo.setSECURITYTYPE(_condition.getSecuritytype());
            vo.setUPDATE(_condition.getUpdate());
            vo.setCHECK(_condition.getCheck());
            vo.setREFERENCE(_condition.getReference());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);

        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj44SecurityBase.KKSIKOGNZUNTCD + "," + Mbj44SecurityBase.USERTYPE + "," + Mbj44SecurityBase.SECURITYCD + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * SELECT SQL(�����R�[�h�擾�p)
     * @return
     */
    private String getManyCd() {

        StringBuffer selectSql = new StringBuffer();
//        String whereSqlStr = "";
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

        Mbj42SecurityVO vo = new Mbj42SecurityVO();

        if (_condition != null)
        {
            vo.setHAMID(_condition.getUpdid());
            vo.setSECURITYCD(_condition.getSecuritycd());
            vo.setSECURITYTYPE(_condition.getSecuritytype());
            vo.setUPDATE(_condition.getUpdate());
            vo.setCHECK(_condition.getCheck());
            vo.setREFERENCE(_condition.getReference());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
//            whereSqlStr = generateWhereByCond2(vo);
        }
        orderSql.append(" WHERE ");
        orderSql.append(" " + Mbj42Security.SECURITYCD + " IN(" + _condition.getSecuritycd() + ") ");
        orderSql.append(" AND ");
        orderSql.append(" " + Mbj42Security.HAMID+ " = '" + _condition.getUpdid() + "' ");
        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj42Security.HAMID + "," + Mbj42Security.SECURITYCD + " ");

//        return selectSql.toString() + whereSqlStr + orderSql.toString();
        return selectSql.toString() + orderSql.toString();
    }

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj44SecurityBaseVO vo) throws HAMException
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
     * UpdateVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void updateVO(Mbj44SecurityBaseVO vo) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (vo == null)
        {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);

        try
        {
            if (!super.update())
            {
                throw new HAMException("�X�V�G���[", "BJ-E0003");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }

    /**
     * DeleteVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void deleteVO(Mbj44SecurityBaseVO vo) throws HAMException
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
        {   // ���������u0�v�̏ꍇ
            return;   // ����Ƃ���i�폜���R�[�h�Ȃ��j
        }
        catch(UpdateFailureException e)
        {   // ���������u2�ȏ�v�̏ꍇ
            return;   // ����Ƃ���
        }
        catch(UserException e)
        {
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
    public List<Mbj44SecurityBaseVO> selectVO(Mbj44SecurityBaseCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj44SecurityBaseVO());
        _condition = condition;

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
     * �����̃R�[�h�Ō������s��
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj44SecurityBaseVO> FindManyCd(Mbj44SecurityBaseCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj44SecurityBaseVO());
        _condition = condition;
        _sqlMode = SqlMode.MANY;
        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
