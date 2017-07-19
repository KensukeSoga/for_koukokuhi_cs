package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* �����捞�̏��擾DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/4/2 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/
public class FindCreateUptakeCostDAO extends AbstractSimpleRdbDao {

    /** �f�[�^�������� */
    private FindCostManagementReportCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCreateUptakeCostDAO() {
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
                "NVL(SUM(" + Tbj22SeisakuhiSs.CLMMONEY + "),0) AS SUMCLMMONEY"
                //�R�X�g�Ǘ��[�s��Ή� 2013/11/11 HLC H.Watabe update start
                //,"NVL(SUM(" + Tbj06EstimateDetail.MITUMORI + ",0) AS SUMMITUMORI"
                ,Tbj06EstimateDetail.MITUMORI
                //�R�X�g�Ǘ��[�s��Ή� 2013/11/11 HLC H.Watabe update end
                ,Tbj22SeisakuhiSs.DCARCD
                ,Mbj05Car.CARNM
                ,"TO_DATE(TO_CHAR(" + Tbj22SeisakuhiSs.CRDATE + ",'YYYY/MM'),'YYYY/MM') AS TBJ22_CRDATE"
                ,Tbj22SeisakuhiSs.GROUPCD
                ,Mbj26BillGroup.GROUPNM
                ,Mbj26BillGroup.GROUPNMRPT
                ,Tbj06EstimateDetail.PRODUCTNM};
    }

    /**
     * �e�[�u�����擾
     */
    @Override
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME;
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

        return getCreateUptakeCost();
    }

    /**
     * �����捞�݃f�[�^�擾��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getCreateUptakeCost()
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
        sql.append(" " + Mbj26BillGroup.TBNAME + ", ");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ", ");
        sql.append(" " + Tbj07EstimateCreate.TBNAME + ", ");
        sql.append(" (SELECT ");
        sql.append(" " + Mbj13CarOutCtrl.DCARCD + " AS EXT_DCARCD, ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");
        sql.append(" FROM ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + "= 'R05' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + "= '1' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" ) EXT_MBJ13CAROUTCTRL ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj05Car.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = EXT_DCARCD(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = " +Mbj26BillGroup.GROUPCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = '0' ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " >= TO_DATE('" + _cond.getKikanFrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " < TO_DATE('" + _cond.getKikanTo() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj07EstimateCreate.ESTDETAILSEQNO + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Tbj07EstimateCreate.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Tbj07EstimateCreate.PHASE + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " = " + Tbj07EstimateCreate.CRDATE + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.SEQUENCENO + " = " + Tbj07EstimateCreate.SEQUENCENO + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CLMMONEY + " <> 0 ");
        sql.append(" AND ");
        sql.append(" " + Tbj06EstimateDetail.MITUMORI + " <> 0 ");

        sql.append(" GROUP BY ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + ", ");
        sql.append(" " + Mbj05Car.CARNM + ", ");
        sql.append(" TO_CHAR(" + Tbj22SeisakuhiSs.CRDATE + ",'YYYY/MM'), ");
        sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + ", ");
        sql.append(" " + Mbj26BillGroup.GROUPNM + ", ");
        sql.append(" " + Mbj26BillGroup.GROUPNMRPT + ", ");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTNM + ", ");
        sql.append(" " + Mbj26BillGroup.SORTNO + ", ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + ", ");
        sql.append(" " + Tbj06EstimateDetail.SORTNO + ", ");
        // �R�X�g�Ǘ��[�s��Ή� 2013/11/11 HLC H.Watabe add start
        sql.append(" " + Tbj06EstimateDetail.MITUMORI + " ");
        // �R�X�g�Ǘ��[�s��Ή� 2013/11/11 HLC H.Watabe add end
        sql.append(" ORDER BY ");
        sql.append(" TO_CHAR(" + Tbj22SeisakuhiSs.CRDATE + ",'YYYY/MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + ", ");
        sql.append(" " + Mbj26BillGroup.SORTNO + ", ");
        sql.append(" " + Tbj06EstimateDetail.SORTNO + " ");



        return sql.toString();
    }


    /**
     * �����捞�R�X�g�擾
     * @return �����捞�R�X�g��VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindCreateUptakeCostVO> findCreateUptakeCost(
            FindCostManagementReportCondition cond) throws HAMException {

        super.setModel(new FindCreateUptakeCostVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
