package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * �����捞DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementCaptureDAO extends AbstractRdbDao {

    private FindCostManagementCaptureCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCostManagementCaptureDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj22SeisakuhiSs.DCARCD,
                Tbj22SeisakuhiSs.GROUPCD,
                "SUM(" + Tbj22SeisakuhiSs.CLMMONEY  + ") AS " + Tbj22SeisakuhiSs.CLMMONEY
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME + ", " + Mbj05Car.TBNAME;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" AND ");
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1'");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = '");
        sql.append(_condition.getClassDiv());
        sql.append("'");
        sql.append(" GROUP BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" ORDER BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCostManagementCaptureVO> selectVO(FindCostManagementCaptureCondition condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getPhase() == 0) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getYearMonth() == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getClassDiv() == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new FindCostManagementCaptureVO());
        try {
            _condition = condition;
            return (List<FindCostManagementCaptureVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
