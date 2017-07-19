package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �����S���i��jDAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu14ThsTntTrDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private RepaVbjaMeu14ThsTntTrCondition _condition = null;

    /** ���ԊJ�n */
    private String _kikanFrom;

    /** ���ԏI�� */
    private String _kikanTo;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu14ThsTntTrDAO() {
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
        return RepaVbjaMeu14ThsTntTr.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu14ThsTntTr.THSKGYCD
                ,RepaVbjaMeu14ThsTntTr.SEQNO
                ,RepaVbjaMeu14ThsTntTr.TRTNTSEQNO
                ,RepaVbjaMeu14ThsTntTr.ENDYMD
                ,RepaVbjaMeu14ThsTntTr.STARTYMD
                ,RepaVbjaMeu14ThsTntTr.SNSTNT
                ,RepaVbjaMeu14ThsTntTr.SIKCD
                ,RepaVbjaMeu14ThsTntTr.CLNTKBN
                ,RepaVbjaMeu14ThsTntTr.TKKBN
                ,RepaVbjaMeu14ThsTntTr.SKYUSKBN
                ,RepaVbjaMeu14ThsTntTr.NKINSKBN
                ,RepaVbjaMeu14ThsTntTr.MKMTKSKBN
                ,RepaVbjaMeu14ThsTntTr.EGHISHRSKBN
                ,RepaVbjaMeu14ThsTntTr.SINSEINO
                ,RepaVbjaMeu14ThsTntTr.EGSYOCD
                ,RepaVbjaMeu14ThsTntTr.CLNTKGYCD
                ,RepaVbjaMeu14ThsTntTr.CLNTSEQNO
                ,RepaVbjaMeu14ThsTntTr.KYUTRCD
                ,RepaVbjaMeu14ThsTntTr.TRTNTYOBI
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {
        return getCharge();
    }


    /**
     * ������񌟍���SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getCharge()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.EGSYOCD + " ='" + _condition.getEgsyocd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " ='" + _condition.getThskgycd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SEQNO + " ='" + _condition.getSeqno() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TRTNTSEQNO + " ='" + _condition.getTrtntseqno() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.STARTYMD + " <='" + _kikanFrom + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.ENDYMD + " >='" + _kikanTo + "' ");


        return sql.toString();
    }

    /**
     * �������̌������s���܂�
     *
     * @return �������VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu14ThsTntTrVO> findCharge(
            RepaVbjaMeu14ThsTntTrCondition cond,String kikanFrom,String kikanTo) throws HAMException {

        super.setModel(new RepaVbjaMeu14ThsTntTrVO());

        try {
            _condition = cond;
            _kikanFrom = kikanFrom;
            _kikanTo = kikanTo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
