/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;


/**
 * <P>
 * ���쐿���\�擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindBillProductionOutputDAO extends AbstractRdbDao {

    private CheckBillProductionOutputCondition _condition = null;

    /** �R�X�g�Ǘ��\ */
    private static final String RPTID_CKH = "R05";
    /** �t���OON */
    private static final String FLG_ON = "1";
    /** �t���OOFF */
    private static final String FLG_OFF = "0";
    /** �R���{(���ׂĂ�ItemData�l) */
    private static final String ALL_ITEM_DATA = "-1";
    /** �Ԏ�\����(���я�) */
    private static final String CARSORT_NAME = "NAME";
    /** �Ԏ�\����(�o�̓I�v�V������) */
    private static final String CARSORT_OPTION = "OPTION";
    /** �o�͑Ώ�(�\��) */
    private static final String OUTPUT_PLAN = "yotei";
    /** �o�͑Ώ�(����) */
    private static final String OUTPUT_REQUEST = "seikyu";
    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindBillProductionOutputDAO() {
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

        String[] retTbl = new String[]{};

        if (_condition.getOutputFlg().equals(OUTPUT_PLAN)) {
            // �o�͑Ώ�(�\��)
            retTbl = new String[]{
                    Tbj22SeisakuhiSs.CRDATE,
                    Mbj05Car.CARNM,
                    Tbj22SeisakuhiSs.EXPENSE,
                    Tbj22SeisakuhiSs.DETAIL,
                    Tbj22SeisakuhiSs.KIKANS,
                    Tbj22SeisakuhiSs.KIKANE,
                    Tbj22SeisakuhiSs.CONTRACTTERM,
                    Tbj22SeisakuhiSs.ESTMONEY,
                    Mbj17CrDivision.DIVNM,
                    Tbj22SeisakuhiSs.GROUPCD,
                    Mbj26BillGroup.GROUPNM,
                    Mbj26BillGroup.GROUPNMRPT,
                    Tbj22SeisakuhiSs.DELIVERDAY
            };
        } else if (_condition.getOutputFlg().equals(OUTPUT_REQUEST)) {
            // �o�͑Ώ�(����)
            retTbl = new String[]{
                    Tbj22SeisakuhiSs.CRDATE,
                    Mbj05Car.CARNM,
                    Tbj22SeisakuhiSs.EXPENSE,
                    Tbj22SeisakuhiSs.DETAIL,
                    Tbj22SeisakuhiSs.KIKANS,
                    Tbj22SeisakuhiSs.KIKANE,
                    Tbj22SeisakuhiSs.CONTRACTTERM,
                    Tbj22SeisakuhiSs.ESTMONEY,
                    Mbj17CrDivision.DIVNM,
                    Tbj22SeisakuhiSs.GROUPCD,
                    Mbj26BillGroup.GROUPNM,
                    Mbj26BillGroup.GROUPNMRPT,
                    Tbj22SeisakuhiSs.DELIVERDAY,
                    Tbj06EstimateDetail.SORTNO,
                    Tbj07EstimateCreate.SEQUENCENO,
                    Tbj06EstimateDetail.PRODUCTNM,
                    //�����\�s��Ή� 2013/11/13 HLC H.Watabe update start
                    //Tbj06EstimateDetail.MITUMORI
                    Tbj06EstimateDetail.MITUMORI,
                    Tbj06EstimateDetail.ESTDETAILSEQNO
                    //�����\�s��Ή� 2013/11/13 HLC H.Watabe update end
            };
        }

        return retTbl;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj22SeisakuhiSs.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj17CrDivision.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj26BillGroup.TBNAME);

        if (_condition.getCarSort().equals(CARSORT_OPTION)) {
            // �o�̓I�v�V�������̏ꍇ
            // �o�͑Ώۂ̎Ԏ���擾
            tbl.append(",( ");

            tbl.append("  SELECT ");
            tbl.append(     Mbj13CarOutCtrl.DCARCD + " AS EXT_DCAR_CD, ");
            tbl.append(     Mbj13CarOutCtrl.SORTNO);

            tbl.append("  FROM ");
            tbl.append(     Mbj13CarOutCtrl.TBNAME);

            tbl.append("  WHERE ");
            tbl.append(     Mbj13CarOutCtrl.REPORTCD + " = '" + RPTID_CKH + "'");
            tbl.append("    AND " + Mbj13CarOutCtrl.OUTPUTFLG + " = '" + FLG_ON + "'");
            tbl.append("    AND " + Mbj13CarOutCtrl.PHASE + " = '" + _condition.getPhase() + "'");

            tbl.append("  ) EXT_MPH24_CAROUTCTRL ");
        }

        if (_condition.getOutputFlg().equals(OUTPUT_REQUEST)) {
            // �o�͑Ώ�(����)

            tbl.append(", ");
            tbl.append(Tbj06EstimateDetail.TBNAME);
            tbl.append(", ");
            tbl.append(Tbj07EstimateCreate.TBNAME);
        }

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
            if (i < getTableColumnNames().length - 1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(    Tbj22SeisakuhiSs.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");
        sql.append("   AND " + Tbj22SeisakuhiSs.DIVCD + " = " + Mbj17CrDivision.DIVCD + "(+)");
        sql.append("   AND " + Tbj22SeisakuhiSs.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+)");
        sql.append("   AND " + Tbj22SeisakuhiSs.CLASSDIV + " = '" + FLG_OFF + "'");

        //������Gr���u���ׂāv�ȊO�̏ꍇ�̕ҏW�i-1���u���ׂāv�j
        if (_condition.getDemandGroup().equals(ALL_ITEM_DATA)) {
            // ���ׂ�

        } else if (_condition.getDemandGroup().equals("")) {
            // ���ݒ�
            sql.append(" AND " + Tbj22SeisakuhiSs.GROUPCD + " IS NULL");
        } else {
            // ��L�ȊO
            sql.append(" AND " + Tbj22SeisakuhiSs.GROUPCD + " = '" + _condition.getDemandGroup() + "'");
        }

        sql.append("   AND " + Tbj22SeisakuhiSs.PHASE + " = '" + _condition.getPhase() + "'");
        sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " >= " + "TO_DATE('" + _condition.getYearMonthFrom() + "', 'YYYY/MM')");
        sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " <= " + "TO_DATE('" + _condition.getYearMonthTo() + "', 'YYYY/MM')");

        if (_condition.getCarSort().equals(CARSORT_OPTION)) {
            // �o�̓I�v�V�������̏ꍇ
            sql.append("   AND " + Tbj22SeisakuhiSs.DCARCD + " = EXT_DCAR_CD(+)");
        }

        if (_condition.getOutputFlg().equals(OUTPUT_PLAN)) {
            // �o�͑Ώ�(�\��)

            sql.append(" ORDER BY ");
            if (_condition.getCarSort().equals(CARSORT_OPTION)) {
                // �o�̓I�v�V�������̏ꍇ
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj13CarOutCtrl.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj22SeisakuhiSs.SORTNO);
            } else if (_condition.getCarSort().equals(CARSORT_NAME)) {
                // ���я��̏ꍇ
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj05Car.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM);
            }

        } else {
            // �o�͑Ώ�(����)

            sql.append("   AND " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj07EstimateCreate.ESTDETAILSEQNO);
            sql.append("   AND " + Tbj22SeisakuhiSs.DCARCD + " = " + Tbj07EstimateCreate.DCARCD);
            sql.append("   AND " + Tbj22SeisakuhiSs.PHASE + " = " + Tbj07EstimateCreate.PHASE);
            sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " = " + Tbj07EstimateCreate.CRDATE);
            sql.append("   AND " + Tbj22SeisakuhiSs.SEQUENCENO + " = " + Tbj07EstimateCreate.SEQUENCENO);

            sql.append(" ORDER BY ");
            if (_condition.getCarSort().equals(CARSORT_OPTION)) {
                // �o�̓I�v�V�������̏ꍇ
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj13CarOutCtrl.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj22SeisakuhiSs.SORTNO + ",");
                sql.append(    Tbj06EstimateDetail.SORTNO);
            } else if (_condition.getCarSort().equals(CARSORT_NAME)) {
                // ���я��̏ꍇ
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj05Car.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj06EstimateDetail.SORTNO);
            }
        }

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindBillProductionOutputVO> selectVO(CheckBillProductionOutputCondition cond) throws HAMException {

        List<FindBillProductionOutputVO> result = null;

        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindBillProductionOutputVO());

        try {
            _condition = cond;
            result = super.find();

            return result;

        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
