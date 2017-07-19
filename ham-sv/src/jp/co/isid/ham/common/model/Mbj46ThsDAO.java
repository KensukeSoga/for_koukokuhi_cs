package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj46Ths;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HAM�����}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj46ThsDAO extends AbstractSimpleRdbDao {

    /** �������� */
//   private Mbj46ThsCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj46ThsDAO() {
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
                Mbj46Ths.THSKGYCD
                ,Mbj46Ths.SEQNO
                ,Mbj46Ths.TRTHKBN
                ,Mbj46Ths.CLASSDIV
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj46Ths.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj46Ths.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj46Ths.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj46Ths.THSKGYCD
                ,Mbj46Ths.SEQNO
                ,Mbj46Ths.TRTHKBN
                ,Mbj46Ths.CLASSDIV
                ,Mbj46Ths.SORTNO
                ,Mbj46Ths.UPDDATE
                ,Mbj46Ths.UPDNM
                ,Mbj46Ths.UPDAPL
                ,Mbj46Ths.UPDID
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

        //*******************************************
        //�g�p�����SELECT + FROM���SQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append("" + getTableColumnNames()[i] +" ");
        }
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");
        whereSql.append(generateWhereByCond(getModel()));

//        orderSql.append(" ORDER BY ");


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
     * �o�^
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Mbj46ThsVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj46ThsVO> selectVO(Mbj46ThsVO vo) throws HAMException {

      super.setModel(vo);
      try {
          return (List<Mbj46ThsVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }

}
