package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * �����擾(�o�̓I�v�V�����ȊO)DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementExceptOptDAO extends AbstractRdbDao {

    FindCostManagementExceptOptCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCostManagementExceptOptDAO() {
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
                Mbj05Car.DCARCD,
                Mbj05Car.CARNM,
                Tbj21Seisakuhi.SEISAKUHIS,
                Tbj21Seisakuhi.DCARNM,
                Tbj21Seisakuhi.SEISAKUHIOTHER,
                Tbj21Seisakuhi.BIKO,
                Tbj21Seisakuhi.GETTIME
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append("(SELECT * FROM ");
        tbl.append(Tbj21Seisakuhi.TBNAME);
        tbl.append(" WHERE ");
        tbl.append(Tbj21Seisakuhi.PHASE);
        tbl.append(" = ");
        tbl.append(_condition.getPhase());
        tbl.append(" AND ");
        tbl.append(Tbj21Seisakuhi.SEIKYUYM);
        tbl.append(" = TO_DATE('");
        tbl.append(_condition.getYearMonth());
        tbl.append("', 'YYYY/MM') ");
        tbl.append(") Tbj21, ");
        tbl.append("(SELECT ");
        tbl.append(Mbj05Car.DCARCD);
        tbl.append(" AS EXT_DCAR_CD");
        tbl.append(" FROM ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(" MINUS ");
        tbl.append("SELECT ");
        tbl.append(Mbj13CarOutCtrl.DCARCD);
        tbl.append(" FROM ");
        tbl.append(Mbj13CarOutCtrl.TBNAME);
        tbl.append(" WHERE ");
        tbl.append(Mbj13CarOutCtrl.REPORTCD);
        tbl.append(" = '");
        tbl.append(_condition.getReportCd());
        tbl.append("' AND ");
        tbl.append(Mbj13CarOutCtrl.PHASE);
        tbl.append(" = ");
        tbl.append(_condition.getPhase());
        tbl.append(") EXT");

        return tbl.toString();
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
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1' ");
        sql.append(" AND ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" = ");
        sql.append(Tbj21Seisakuhi.DCARCD);
        sql.append("(+) AND ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" = EXT_DCAR_CD");
        sql.append(" ORDER BY ");
        sql.append(Mbj05Car.SORTNO);
        sql.append(", ");
        sql.append(Mbj05Car.DCARCD);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCostManagementExceptOptVO> selectVO(FindCostManagementExceptOptCondition condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindCostManagementExceptOptVO());

        try {
            _condition = condition;
            return (List<FindCostManagementExceptOptVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
