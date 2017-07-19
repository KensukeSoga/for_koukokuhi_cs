package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �V�G�}�̃}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu20MsMzBtDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private RepaVbjaMeu20MsMzBtCondition _condition = null;

    private enum SelSqlMode
            {
                DEF,
                MEDIANM
            }
    private SelSqlMode _selSqlMode = SelSqlMode.DEF;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu20MsMzBtDAO() {
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
        return RepaVbjaMeu20MsMzBt.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu20MsMzBt.SZKBN
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD
                ,RepaVbjaMeu20MsMzBt.KBANCD
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK
                ,RepaVbjaMeu20MsMzBt.BTAISYAKCD
                ,RepaVbjaMeu20MsMzBt.BTAISYASEQNO
                ,RepaVbjaMeu20MsMzBt.KYUTRCD
                ,RepaVbjaMeu20MsMzBt.KHYOYMD
                ,RepaVbjaMeu20MsMzBt.JANR1
                ,RepaVbjaMeu20MsMzBt.JANR2
                ,RepaVbjaMeu20MsMzBt.JANR3
                ,RepaVbjaMeu20MsMzBt.CHUCHIKBN
                ,RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD
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
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_selSqlMode.equals(SelSqlMode.DEF)) {

            // �����pSQL�擾
            sql = getSelectSQLDefault();

        } else if (_selSqlMode.equals(SelSqlMode.MEDIANM)) {

            // �L�[���[�h�����pSQL�擾
            sql = getMediaByMediaNm();
        }

        return sql;
    }

    /**
     * ����SQL�擾
     * @return SQL��
     */
    private String getSelectSQLDefault()
    {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        sqlSelect.append("SELECT ");
        //�S���ڂ��擾
        for (int i = 0 ; i < getTableColumnNames().length ; i++)
        {
            sqlSelect.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length - 1)
            {
                sqlSelect.append(", ");
            }
        }
        sqlSelect.append(" FROM ");
        sqlSelect.append(getTableName());

        if (_condition != null)
        {
            RepaVbjaMeu20MsMzBtVO vo = new RepaVbjaMeu20MsMzBtVO();
            vo.setSZKBN(_condition.getSzkbn());
            vo.setSINZATSUBTAICD(_condition.getSinzatsubtaicd());
            vo.setKBANCD(_condition.getKbancd());
            vo.setSINZATSUBTAINMJ(_condition.getSinzatsubtainmj());
            vo.setSINZATSUBTAINMK(_condition.getSinzatsubtainmk());
            vo.setBTAISYAKCD(_condition.getBtaisyakcd());
            vo.setBTAISYASEQNO(_condition.getBtaisyaseqno());
            vo.setKYUTRCD(_condition.getKyutrcd());
            vo.setKHYOYMD(_condition.getKhyoymd());
            vo.setJANR1(_condition.getJanr1());
            vo.setJANR2(_condition.getJanr2());
            vo.setJANR3(_condition.getJanr3());
            vo.setCHUCHIKBN(_condition.getChuchikbn());
            vo.setSINBUNDAIGOCD(_condition.getSinbundaigocd());
            whereSqlStr = generateWhereByCond(vo);

        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * �L�[���[�h����SQL�擾
     * @return SQL��
     */
    private String getMediaByMediaNm() {

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
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ + " LIKE('%" + _condition.getSinzatsubtainmj() + "%')");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getSzkbn() + "' ");

        return sql.toString();
    }

    /**
     * �������s��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu20MsMzBtVO> selectVO(RepaVbjaMeu20MsMzBtCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMeu20MsMzBtVO());

        try {
            _condition = cond;
            _selSqlMode = SelSqlMode.DEF;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �L�[���[�h�Ō������s��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu20MsMzBtVO> FindMediaByMediaNm(RepaVbjaMeu20MsMzBtCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMeu20MsMzBtVO());

        try {
            _condition = cond;
            _selSqlMode = SelSqlMode.MEDIANM;
            return super.find();
        }
        catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
