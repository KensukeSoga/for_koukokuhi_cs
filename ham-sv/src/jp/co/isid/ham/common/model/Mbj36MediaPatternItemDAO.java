package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj36MediaPatternItem;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̃p�^�[�����e�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj36MediaPatternItemDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj36MediaPatternItemCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj36MediaPatternItemDAO() {
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
                Mbj36MediaPatternItem.SZKBN
                ,Mbj36MediaPatternItem.BAITAIPATNNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj36MediaPatternItem.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj36MediaPatternItem.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj36MediaPatternItem.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj36MediaPatternItem.SZKBN
                ,Mbj36MediaPatternItem.BAITAIPATNNO
                ,Mbj36MediaPatternItem.NPCD
                ,Mbj36MediaPatternItem.UPDDATE
                ,Mbj36MediaPatternItem.UPDNM
                ,Mbj36MediaPatternItem.UPDAPL
                ,Mbj36MediaPatternItem.UPDID
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
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof Mbj36MediaPatternItemVO)
        {
            // Mbj36MediaPatternItemVO�擾�pSQL�擾
            sql = getSelectSQLMbj36MediaPatternItemVO();
        }

        return sql;

    };

    /**
     * SELECT SQL�iMbj36MediaPatternItemVO�j
     */
    private String getSelectSQLMbj36MediaPatternItemVO()
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
            Mbj36MediaPatternItemVO vo = new Mbj36MediaPatternItemVO();
            vo.setSZKBN(_condition.getSzkbn());
            vo.setBAITAIPATNNO(_condition.getBaitaipatnno());
            vo.setNPCD(_condition.getNpcd());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);

        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj36MediaPatternItem.SZKBN + "," + Mbj36MediaPatternItem.BAITAIPATNNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj36MediaPatternItemVO vo) throws HAMException
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
    public void updateVO(Mbj36MediaPatternItemVO vo) throws HAMException
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
    public void deleteVO(Mbj36MediaPatternItemVO vo) throws HAMException
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
    public List<Mbj36MediaPatternItemVO> selectVO(Mbj36MediaPatternItemCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj36MediaPatternItemVO());
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

}