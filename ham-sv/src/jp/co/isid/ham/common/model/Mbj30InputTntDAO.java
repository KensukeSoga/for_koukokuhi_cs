package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���͒S���}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
public class Mbj30InputTntDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj30InputTntCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode {
        LOAD, VO, MAXSEQ, MAXSORT
    };

    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj30InputTntDAO() {
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
        return new String[] { Mbj30InputTnt.PHASE, Mbj30InputTnt.CLASSDIV, Mbj30InputTnt.SEQNO };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj30InputTnt.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj30InputTnt.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj30InputTnt.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj30InputTnt.PHASE,
                Mbj30InputTnt.CLASSDIV,
                Mbj30InputTnt.SEQNO,
                Mbj30InputTnt.DCARCD,
                Mbj30InputTnt.INPUTTNT,
                Mbj30InputTnt.SORTNO,
                Mbj30InputTnt.UPDDATE,
                Mbj30InputTnt.UPDNM,
                Mbj30InputTnt.UPDAPL,
                Mbj30InputTnt.UPDID };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            // *******************************************
            // Load()�Ŏg�p�����SELECT + FROM���SQL
            // *******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.VO)) {

            // *******************************************
            // selectVO�Ŏg�p�����SQL
            // *******************************************
            // SELECT + FROM��
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");
            // WHERE��
            if (_condition != null)
            {
                Mbj30InputTntVO vo = new Mbj30InputTntVO();
                vo.setPHASE(_condition.getPhase());
                vo.setCLASSDIV(_condition.getClassdiv());
                vo.setSEQNO(_condition.getSeqno());
                vo.setDCARCD(_condition.getDcarcd());
                vo.setINPUTTNT(_condition.getInputtnt());
                vo.setSORTNO(_condition.getSortno());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));

            }

            orderSql.append(" ORDER BY ");
            orderSql.append(" " + Mbj30InputTnt.SORTNO + "," + Mbj30InputTnt.SEQNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSEQ)) {

            //*******************************************
            //findMaxSeqNo�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            selectSql.append(" SELECT ");
            selectSql.append("     NVL(MAX(" + Mbj30InputTnt.SEQNO  + "), 0) AS " + Mbj30InputTnt.SEQNO + " ");
            selectSql.append(" FROM ");
            selectSql.append(" " + Mbj30InputTnt.TBNAME + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSORT)) {

            //*******************************************
            //findMaxSortNo�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            selectSql.append(" SELECT ");
            selectSql.append("     NVL(MAX(" + Mbj30InputTnt.SORTNO  + "), 0) AS " + Mbj30InputTnt.SORTNO + " ");
            selectSql.append(" FROM ");
            selectSql.append(" " + Mbj30InputTnt.TBNAME + " ");
            selectSql.append(" WHERE ");
            selectSql.append("     " + Mbj30InputTnt.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()));
            selectSql.append(" AND " + Mbj30InputTnt.CLASSDIV + " = " + getDBModelInterface().ConvertToDBString(_condition.getClassdiv()));
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     *
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
                }
                else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Mbj30InputTntVO vo) throws HAMException
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
    public void updateVO(Mbj30InputTntVO vo) throws HAMException
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
    public void deleteVO(Mbj30InputTntVO vo) throws HAMException
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
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> selectVO(Mbj30InputTntCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.VO;
            _condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SEQNO��MAX�l���擾���܂�
     *
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> findMaxSeqNo(/*Mbj30InputTntCondition condition*/) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSEQ;
            //_condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SORTNO��MAX�l���擾���܂�
     *
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> findMaxSortNo(Mbj30InputTntCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSORT;
            _condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
