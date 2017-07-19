package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* �����̏��擾DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/4/2 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/
public class FindCreateCostDAO extends AbstractSimpleRdbDao {

    /** �f�[�^�������� */
    private FindCostManagementReportCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCreateCostDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                "SUM(" + Tbj21Seisakuhi.SEISAKUHIS + ") AS SUMSEISAKUHIS"
                ,Tbj21Seisakuhi.DCARCD
                ,Mbj05Car.CARNM
                ,"TRUNC(" + Tbj21Seisakuhi.SEIKYUYM + ", 'MM') AS TBJ21_SEIKYUYM"};
    }

    /**
     * �e�[�u�����擾
     */
    @Override
    public String getTableName() {
        return Tbj21Seisakuhi.TBNAME;
    }

    /**
     * �X�V���t�t�B�[���h�擾
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

        return getCreateCost();
    }

    /**
     * �����f�[�^�擾��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getCreateCost()
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
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj21Seisakuhi.SEIKYUYM + " >= TO_DATE('" + _cond.getKikanFrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.SEIKYUYM + " < TO_DATE('" + _cond.getKikanTo() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " = 'R05' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.SEISAKUHIS + " <> 0 ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + ", ");
        sql.append(" " + Mbj05Car.CARNM + ", ");
        sql.append(" TRUNC(" + Tbj21Seisakuhi.SEIKYUYM + ",'MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");
        sql.append(" ORDER BY ");
        sql.append(" TO_CHAR(" + Tbj21Seisakuhi.SEIKYUYM + ",'YYYY/MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");


        return sql.toString();
    }


    /**
     * �����擾
     * @return �����VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindCreateCostVO> findCreateCost(
            FindCostManagementReportCondition cond) throws HAMException {

        super.setModel(new FindCreateCostVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
