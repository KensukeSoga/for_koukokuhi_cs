package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�\�Z��ڃ}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj16CrExpenceDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private Mbj16CrExpenceCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{VO,};
    private SelSqlMode _SelSqlMode = SelSqlMode.VO;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj16CrExpenceDAO() {
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
                Mbj16CrExpence.EXPCD
                ,Mbj16CrExpence.CLASSDIV
                ,Mbj16CrExpence.DATEFROM
                ,Mbj16CrExpence.DATETO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj16CrExpence.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj16CrExpence.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj16CrExpence.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj16CrExpence.EXPCD
                ,Mbj16CrExpence.CLASSDIV
                ,Mbj16CrExpence.DATEFROM
                ,Mbj16CrExpence.DATETO
                ,Mbj16CrExpence.EXPNM
                ,Mbj16CrExpence.SORTNO
                ,Mbj16CrExpence.FLG1
                ,Mbj16CrExpence.UPDDATE
                ,Mbj16CrExpence.UPDNM
                ,Mbj16CrExpence.UPDAPL
                ,Mbj16CrExpence.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.VO)) {

            //*******************************************
            //selectVO�Ŏg�p�����SELECT + FROM���SQL
            //*******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");
            //WHERE��
            whereSql.append(generateWhereByCond(getModel()));
            //ORDER��
            orderSql.append(" ORDER BY ");
            orderSql.append("     " + Mbj16CrExpence.SORTNO + " ");
            orderSql.append("    ," + Mbj16CrExpence.CLASSDIV + " ");
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
    };

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
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj16CrExpenceVO> selectVO(Mbj16CrExpenceVO vo) throws HAMException {

      super.setModel(vo);
      try {
          _SelSqlMode = SelSqlMode.VO;
          return (List<Mbj16CrExpenceVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }
}
