package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj45CrExpConvert;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�\�Z��ڕϊ��}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj45CrExpConvertDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Mbj45CrExpConvertCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode {
        LOAD, VO, CNV,
    };

    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj45CrExpConvertDAO() {
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
                Mbj45CrExpConvert.EXPCD
                ,Mbj45CrExpConvert.CLASSDIV
                ,Mbj45CrExpConvert.DATEFROM
                ,Mbj45CrExpConvert.DATETO
                ,Mbj45CrExpConvert.NEWCLASSDIV
                ,Mbj45CrExpConvert.NEWDATEFROM
                ,Mbj45CrExpConvert.NEWDATETO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj45CrExpConvert.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj45CrExpConvert.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj45CrExpConvert.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj45CrExpConvert.EXPCD
                ,Mbj45CrExpConvert.CLASSDIV
                ,Mbj45CrExpConvert.DATEFROM
                ,Mbj45CrExpConvert.DATETO
                ,Mbj45CrExpConvert.NEWEXPCD
                ,Mbj45CrExpConvert.NEWCLASSDIV
                ,Mbj45CrExpConvert.NEWDATEFROM
                ,Mbj45CrExpConvert.NEWDATETO
                ,Mbj45CrExpConvert.UPDDATE
                ,Mbj45CrExpConvert.UPDNM
                ,Mbj45CrExpConvert.UPDAPL
                ,Mbj45CrExpConvert.UPDID
        };
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
            if (_condition != null) {
                Mbj45CrExpConvertVO vo = new Mbj45CrExpConvertVO();
                vo.setEXPCD(_condition.getExpcd());
                vo.setCLASSDIV(_condition.getClassdiv());
                vo.setDATEFROM(_condition.getDatefrom());
                vo.setDATETO(_condition.getDateto());
                vo.setNEWEXPCD(_condition.getNewexpcd());
                vo.setNEWCLASSDIV(_condition.getNewclassdiv());
                vo.setNEWDATEFROM(_condition.getNewdatefrom());
                vo.setNEWDATETO(_condition.getNewdateto());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));
            }

        } else if (_SelSqlMode.equals(SelSqlMode.CNV)) {

            Mbj45CrExpConvertVO cond = (Mbj45CrExpConvertVO)super.getModel();

            //SELECT + FROM��
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

            //WHERE��
            whereSql.append(" WHERE ");
            whereSql.append("     " + Mbj45CrExpConvert.EXPCD        +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getEXPCD())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.CLASSDIV     +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getCLASSDIV())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.DATEFROM     +" <= " + super.getDBModelInterface().ConvertToDBString(cond.getDATEFROM())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.DATETO       +" >= " + super.getDBModelInterface().ConvertToDBString(cond.getDATETO())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWCLASSDIV  +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getNEWCLASSDIV())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWDATEFROM  +" <= " + super.getDBModelInterface().ConvertToDBString(cond.getNEWDATEFROM())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWDATETO    +" >= " + super.getDBModelInterface().ConvertToDBString(cond.getNEWDATETO())  + " ");
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
    };

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
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj45CrExpConvertVO> selectVO(Mbj45CrExpConvertVO condition) throws HAMException {

        super.setModel(condition);
        try {
            _SelSqlMode = SelSqlMode.VO;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
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
    public List<Mbj45CrExpConvertVO> selectVO(Mbj45CrExpConvertCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.VO;
            _condition = condition;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
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
    public List<Mbj45CrExpConvertVO> selectVOForCNV(Mbj45CrExpConvertVO condition) throws HAMException {

        super.setModel(condition);
        try {
            _SelSqlMode = SelSqlMode.CNV;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
