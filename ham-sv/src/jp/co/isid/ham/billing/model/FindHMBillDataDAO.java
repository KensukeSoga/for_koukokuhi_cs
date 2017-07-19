package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HM�����f�[�^�쐬����DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/14 T.Fujiyoshi)<BR>
 * �E�����Ɩ��ύX�s��Ή�(2016/03/16 HLC K.Soga)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHMBillDataDAO extends AbstractRdbDao {

    /** �������� */
    private FindHMBillDataCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMBillDataDAO() {
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
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return null;
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

        sql.append(" SELECT");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.MITUMORI + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" SUM(" + Tbj06EstimateDetail.MITUMORI + ") " + Tbj06EstimateDetail.MITUMORI + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD);

        sql.append(" FROM");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Tbj06EstimateDetail.TBNAME+ ",");
        sql.append(" " + Tbj04MediaMngEstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj03MediaMng.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + "= " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "/01', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " = '" + HAMConstants.ESTIMATE_CLASS_MEDIA + "' AND");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + Tbj06EstimateDetail.PHASE + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + Tbj06EstimateDetail.CRDATE + " AND");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + Tbj06EstimateDetail.ESTSEQNO + " AND");
        /* 2016/03/16 �����Ɩ��ύX�s��Ή� HLC K.Soga ADD Start */
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + " IS NOT NULL AND");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + " IS NOT NULL AND");
        /* 2016/03/16 �����Ɩ��ύX�s��Ή� HLC K.Soga ADD End */
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO + "(+) AND");
        sql.append(" " + Tbj04MediaMngEstimateDetail.MEDIAMNGNO + " = " + Tbj03MediaMng.MEDIAMNGNO + "(+)");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD);

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" SUM(" + Tbj06EstimateDetail.MITUMORI + "),");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.DCARCD + ",");
        sql.append(" CASE WHEN " + Tbj05EstimateItem.DIVCD + " = '"+ HAMConstants.TAXKBN_CONTRACT + "'");
        sql.append(" THEN '" + HAMConstants.MEDIACD_CONTRACT + "'");
        sql.append(" ELSE '" + HAMConstants.MEDIACD_PRODUCTION + "'");
        sql.append(" END " + Tbj03MediaMng.MEDIACD);

        sql.append(" FROM");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Tbj06EstimateDetail.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + "= " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "/01', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " IN ( '" + HAMConstants.ESTIMATE_CLASS_PRODUCTION + "', '" + HAMConstants.ESTIMATE_CLASS_CRPRODUCTION + "' ) AND");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + Tbj06EstimateDetail.PHASE + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + Tbj06EstimateDetail.CRDATE + " AND");
        /* 2016/03/16 �����Ɩ��ύX�s��Ή� HLC K.Soga MOD Start */
        //sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + Tbj06EstimateDetail.ESTSEQNO);
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + Tbj06EstimateDetail.ESTSEQNO + " AND");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + " IS NOT NULL AND");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + " IS NOT NULL");
        /* 2016/03/16 �����Ɩ��ύX�s��Ή� HLC K.Soga MOD End */

        sql.append(" GROUP BY");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.DCARCD + ",");
        sql.append(" " + Tbj05EstimateItem.DIVCD);
        sql.append(" )");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillDataVO> selectVO(FindHMBillDataCondition condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindHMBillDataVO());

        try {
            _condition = condition;
            return (List<FindHMBillDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
