package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * ������}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMea10IrskDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private RepaVbjaMea10IrskCondition _condition = null;

    /** �p�~�N�� */
    private static String ENDYM = "99999999";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMea10IrskDAO() {
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
        return RepaVbjaMea10Irsk.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMea10Irsk.IRSKCD
                ,RepaVbjaMea10Irsk.IRSKSUBCD
                ,RepaVbjaMea10Irsk.IRSKALASHYOJIKN
                ,RepaVbjaMea10Irsk.IRSKALASHYOJIKJ
                ,RepaVbjaMea10Irsk.TKALASHYOJIKN
                ,RepaVbjaMea10Irsk.TKALASHYOJIKJ
                ,RepaVbjaMea10Irsk.ATSHONBCD
                ,RepaVbjaMea10Irsk.ALASUSEFLG
                ,RepaVbjaMea10Irsk.TKALASUSEFLG
                ,RepaVbjaMea10Irsk.HOSOK
                ,RepaVbjaMea10Irsk.HKYMD
                ,RepaVbjaMea10Irsk.HAISYMD
                ,RepaVbjaMea10Irsk.INSDATE
                ,RepaVbjaMea10Irsk.INSTNTCD
                ,RepaVbjaMea10Irsk.INSAPLID
                ,RepaVbjaMea10Irsk.UPDAPLDATE
                ,RepaVbjaMea10Irsk.UPDTNTCD
                ,RepaVbjaMea10Irsk.UPDONLAPLID
                ,RepaVbjaMea10Irsk.UPDBATAPLID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        return getOrderDestinationByDateFlg();
    }

    /**
     * �L�[�R�[�h�������s��
     * @return SQL��
     */
    private String getOrderDestinationByDateFlg() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMea10Irsk.ALASUSEFLG + " ='" + _condition.getAlasuseflg() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.TKALASUSEFLG + " ='" + _condition.getTkalasuseflg() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HAISYMD + " ='" + ENDYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKCD + " ASC, ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKSUBCD + " ASC ");

        return sql.toString();
    }

    /**
     * ���t�ƃt���O�Ō������s��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMea10IrskVO> FindOrderDestinationByDateFlg(RepaVbjaMea10IrskCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMea10IrskVO());

        try {
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
