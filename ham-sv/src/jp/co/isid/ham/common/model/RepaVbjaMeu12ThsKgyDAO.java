package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �������DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu12ThsKgyDAO extends AbstractSimpleRdbDao {

    /** �������� */
    //private RepaVbjaMeu12ThsKgyCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu12ThsKgyDAO() {
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
                RepaVbjaMeu12ThsKgy.THSKGYCD
                ,RepaVbjaMeu12ThsKgy.ENDYMD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return RepaVbjaMeu12ThsKgy.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu12ThsKgy.THSKGYCD
                ,RepaVbjaMeu12ThsKgy.ENDYMD
                ,RepaVbjaMeu12ThsKgy.STARTYMD
                ,RepaVbjaMeu12ThsKgy.SNSTNT
                ,RepaVbjaMeu12ThsKgy.THSKGYKN
                ,RepaVbjaMeu12ThsKgy.THSKGYSRCHKN
                ,RepaVbjaMeu12ThsKgy.THSKGYEN
                ,RepaVbjaMeu12ThsKgy.THSKGYDISPKJ
                ,RepaVbjaMeu12ThsKgy.THSKGYLNGKJ
                ,RepaVbjaMeu12ThsKgy.KGYGSYLCD
                ,RepaVbjaMeu12ThsKgy.SYUYOU
                ,RepaVbjaMeu12ThsKgy.POST
                ,RepaVbjaMeu12ThsKgy.ADDRESS
                ,RepaVbjaMeu12ThsKgy.KGYOZOK
                ,RepaVbjaMeu12ThsKgy.KJNHJNKBN
                ,RepaVbjaMeu12ThsKgy.CNTRY
                ,RepaVbjaMeu12ThsKgy.LANG
                ,RepaVbjaMeu12ThsKgy.CHOSYM
                ,RepaVbjaMeu12ThsKgy.GNSKBN
                ,RepaVbjaMeu12ThsKgy.GNSSTAYMD
                ,RepaVbjaMeu12ThsKgy.GNSENDYMD
                ,RepaVbjaMeu12ThsKgy.GAISIKBN
                ,RepaVbjaMeu12ThsKgy.CM10CDCLNTCD
                ,RepaVbjaMeu12ThsKgy.DELNGFLG
                ,RepaVbjaMeu12ThsKgy.AORKGY
                ,RepaVbjaMeu12ThsKgy.FEEKGY
                ,RepaVbjaMeu12ThsKgy.DTENKBN
                ,RepaVbjaMeu12ThsKgy.AREADENTSUKBN
                ,RepaVbjaMeu12ThsKgy.SIHONKIN
                ,RepaVbjaMeu12ThsKgy.KJNINFOHGKBN
                ,RepaVbjaMeu12ThsKgy.KSNM
                ,RepaVbjaMeu12ThsKgy.DUMMYKBN
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        //*******************************************
        //selectVO�Ŏg�p�����SQL
        //*******************************************
        //SELECT + FROM��
        sql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append("" + getTableColumnNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        //WHERE��
        sql.append(generateWhereByCond(getModel()));

        return sql.toString();
    };

    /**
     * �l�̐ݒ�L������SQL��WHERE��𐶐�����
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

                if (getTableColumnNames()[i].equals(RepaVbjaMeu12ThsKgy.ENDYMD)) {
                    sql.append(getTableColumnNames()[i] + " >= " + getDBModelInterface().ConvertToDBString(value));
                } else if (getTableColumnNames()[i].equals(RepaVbjaMeu12ThsKgy.STARTYMD)) {
                    sql.append(getTableColumnNames()[i] + " <= " + getDBModelInterface().ConvertToDBString(value));
                } else {
                    sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
                }
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
    public List<RepaVbjaMeu12ThsKgyVO> selectVO(RepaVbjaMeu12ThsKgyVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            return (List<RepaVbjaMeu12ThsKgyVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
