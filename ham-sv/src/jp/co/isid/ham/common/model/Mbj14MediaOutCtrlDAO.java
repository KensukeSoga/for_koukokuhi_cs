package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̏o�͐ݒ�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj14MediaOutCtrlDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj14MediaOutCtrlCondition _condition = null;

    /** �폜���� */
    private Mbj14MediaOutCtrlVO _delVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj14MediaOutCtrlDAO() {
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
        return Mbj14MediaOutCtrl.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj14MediaOutCtrl.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.REPORTCD
                ,Mbj14MediaOutCtrl.MEDIACD
                ,Mbj14MediaOutCtrl.OUTPUTFLG
                ,Mbj14MediaOutCtrl.SORTNO
                ,Mbj14MediaOutCtrl.PHASE
                ,Mbj14MediaOutCtrl.UPDDATE
                ,Mbj14MediaOutCtrl.UPDNM
                ,Mbj14MediaOutCtrl.UPDAPL
                ,Mbj14MediaOutCtrl.UPDID
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

        if (super.getModel() instanceof Mbj14MediaOutCtrlVO)
        {
            // Mbj14MediaOutCtrlVO�擾�pSQL�擾
            sql = getSelectSQLMbj14MediaOutCtrlVO();
        }

        return sql;

    };

    /**
     * EXEC SQL
     */
    @Override
    public String getExecString()
    {
        String sql = "";

        if (_delVO != null)
        {
            // Mbj14MediaOutCtrlVO�폜�pSQL�擾
            sql = getDeleteSQLMbj14MediaOutCtrlVO();
        }

        return sql;

    };

    /**
     * SELECT SQL�iMbj14MediaOutCtrlVO�j
     */
    private String getSelectSQLMbj14MediaOutCtrlVO()
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
            Mbj14MediaOutCtrlVO vo = new Mbj14MediaOutCtrlVO();
            vo.setREPORTCD(_condition.getReportcd());
            vo.setMEDIACD(_condition.getMediacd());
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
        orderSql.append(" " + Mbj14MediaOutCtrl.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * DELETE SQL�iMbj14MediaOutCtrlVO�j
     */
    private String getDeleteSQLMbj14MediaOutCtrlVO()
    {
        StringBuffer deleteSql = new StringBuffer();
        String whereSqlStr = "";

        deleteSql.append(" DELETE ");
        deleteSql.append(" FROM ");
        deleteSql.append(" " + getTableName() + " ");

        if (_delVO != null)
        {
            whereSqlStr = generateWhereByCond(_delVO);
        }

        return deleteSql.toString() + whereSqlStr;
    };

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj14MediaOutCtrlVO vo) throws HAMException
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
    public void updateVO(Mbj14MediaOutCtrlVO vo) throws HAMException
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
    public void deleteVO(Mbj14MediaOutCtrlVO vo) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (vo == null)
        {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }

        // �v���C�}���L�[���Ȃ�����remove()���g���Ȃ��̂ŁA�폜������Ǝ�����
        _delVO = vo;

        try
        {
            super.exec();   // exec()�ō폜���������s����
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
    public List<Mbj14MediaOutCtrlVO> selectVO(Mbj14MediaOutCtrlCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Mbj14MediaOutCtrlVO());
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
