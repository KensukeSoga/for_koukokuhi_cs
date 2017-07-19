package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �o���g�D�W�J�e�[�u��DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu07SikKrSprdDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private RepaVbjaMeu07SikKrSprdCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode {
        DATE,
    };
    private SelSqlMode _SelSqlMode = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu07SikKrSprdDAO() {
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
        return RepaVbjaMeu07SikKrSprd.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu07SikKrSprd.SIKCD
                ,RepaVbjaMeu07SikKrSprd.ENDYMD
                ,RepaVbjaMeu07SikKrSprd.STARTYMD
                ,RepaVbjaMeu07SikKrSprd.KRIKAISOCD
                ,RepaVbjaMeu07SikKrSprd.KRIJSIKCD
                ,RepaVbjaMeu07SikKrSprd.CKATUKBN
                ,RepaVbjaMeu07SikKrSprd.JYTRKKBN
                ,RepaVbjaMeu07SikKrSprd.ODRTRKKBN
                ,RepaVbjaMeu07SikKrSprd.KNRIBMON
                ,RepaVbjaMeu07SikKrSprd.KSHATHSCD
                ,RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO
                ,RepaVbjaMeu07SikKrSprd.KYUTRCD
                ,RepaVbjaMeu07SikKrSprd.BCKKBN
                ,RepaVbjaMeu07SikKrSprd.EGSYOCD
                ,RepaVbjaMeu07SikKrSprd.SHOWNO
                ,RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN
                ,RepaVbjaMeu07SikKrSprd.HYOJIKN
                ,RepaVbjaMeu07SikKrSprd.HYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.HYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.HYOJIEN
                ,RepaVbjaMeu07SikKrSprd.KSHASKBTUCD
                ,RepaVbjaMeu07SikKrSprd.IOCD
                ,RepaVbjaMeu07SikKrSprd.SPUSECD
                ,RepaVbjaMeu07SikKrSprd.SIKCDHONB
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDKYK
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDSITU
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDBU
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDKA
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIEN
        };
    }

//    /**
//     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
//     * @param vo
//     * @return
//     */
//    private String generateWhereByCond(AbstractModel vo)
//    {
//        StringBuffer sql = new StringBuffer();
//
//        for (int i = 0; i < getTableColumnNames().length; i++) {
//            if (vo.getUpdateMember().containsKey(getTableColumnNames()[i])) {
//                Object value = vo.get(getTableColumnNames()[i]);
//                if (sql.length() == 0) {
//                    sql.append(" WHERE ");
//                } else {
//                    sql.append(" AND ");
//                }
//                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
//            }
//        }
//
//        return sql.toString();
//    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCondForDATE(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (vo.getUpdateMember().containsKey(getTableColumnNames()[i])) {
                Object value = vo.get(getTableColumnNames()[i]);
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                if (getTableColumnNames()[i].equals(RepaVbjaMeu07SikKrSprd.STARTYMD)) {
                    sql.append(getTableColumnNames()[i] + " <= " + getDBModelInterface().ConvertToDBString(value));
                } else if (getTableColumnNames()[i].equals(RepaVbjaMeu07SikKrSprd.ENDYMD)) {
                    sql.append(getTableColumnNames()[i] + " >= " + getDBModelInterface().ConvertToDBString(value));
                } else {
                    sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
                }
            }
        }

        return sql.toString();
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        String sql = "";

        if (SelSqlMode.DATE.equals(_SelSqlMode)) {
            sql = getSelectSQLForDATE();
        }

        return sql;
    };

    /**
     * Mode��DATE�̏ꍇ��SQL����Ԃ��܂�
     * @return
     */
    private String getSelectSQLForDATE() {
        StringBuffer sql = new StringBuffer();
        StringBuffer sqlSelect = new StringBuffer();
        StringBuffer sqlWhere = new StringBuffer();
        StringBuffer sqlOrder = new StringBuffer();


        sqlSelect.append("SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sqlSelect.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sqlSelect.append(", ");
            }
        }
        sqlSelect.append(" FROM ");
        sqlSelect.append(getTableName());
        //WHERE��
        RepaVbjaMeu07SikKrSprdVO condVo = (RepaVbjaMeu07SikKrSprdVO)getModel();
        sqlSelect.append(generateWhereByCondForDATE(condVo));


        sql.append(sqlSelect);
        sql.append(sqlWhere);
        sql.append(sqlOrder);
        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���܂�
     * �������L���J�n�N�����A�L���I���N�����ɂ��Ă͔͈͎w��Ō������܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu07SikKrSprdVO> selectVoByDate(RepaVbjaMeu07SikKrSprdVO vo) throws HAMException {
        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.DATE;
            return (List<RepaVbjaMeu07SikKrSprdVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
