package jp.co.isid.ham.billing.model;

import java.util.List;

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
 * ���쐿���\�o�̓f�[�^���݃`�F�b�N�i�����̃`�F�b�N�j
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/3 J.Kamiyama)<BR>
 * �E�����Ɩ��ύX�s��Ή�(2016/03/02 HLC K.Oki)<BR>
 * </P>
 * @author J.Kamiyama
 */
public class CheckBillProductionOutputSeikyuDAO extends AbstractRdbDao {

    private CheckBillProductionOutputCondition _condition = null;

    /* 2016/03/02 HDX�Ή� HLC K.Oki ADD Start */
    /** �R���{(���ׂĂ�ItemData�l) */
    private static final String ALL_ITEM_DATA = "-1";
    /* 2016/03/02 HDX�Ή� HLC K.Oki ADD End */

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CheckBillProductionOutputSeikyuDAO() {
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
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME;
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
        sql.append(Tbj22SeisakuhiSs.TBNAME);
        sql.append(" , ");
        sql.append(Tbj06EstimateDetail.TBNAME);
        sql.append(" , ");
        sql.append(Tbj07EstimateCreate.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = '0'");
        sql.append(" AND ");

        //������Gr���u���ׂāv�ȊO�̏ꍇ�̕ҏW(-1���u���ׂāv)
        /* 2016/03/02 HDX�Ή� HLC K.Oki MOD Start */
        //if (_condition.getDemandGroup().equals("-1")) {
        if (!(_condition.getDemandGroup().equals(ALL_ITEM_DATA))) {
        /* 2016/03/02 HDX�Ή� HLC K.Oki MOD End */
            sql.append("( ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" = ");
            sql.append(_condition.getDemandGroup());
            sql.append(" OR ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" is null ) ");
            sql.append(" AND ");
        }

        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" >= TO_DATE('");
        sql.append(_condition.getYearMonthFrom());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" <= TO_DATE('");
        sql.append(_condition.getYearMonthTo());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.DCARCD);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.PHASE);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.CRDATE);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.SEQUENCENO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.SEQUENCENO);

        return sql.toString();
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public void selectVO(CheckBillProductionOutputCondition condition) throws HAMException {

        List<CheckBillProductionVO> result = null;

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getPhase() == 0) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getYearMonthFrom() == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getYearMonthTo() == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        if (condition.getDemandGroup() == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new CheckBillProductionOutputVO());
        try {
            _condition = condition;
            result = super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }

        if (result.size() == 0) {
            throw new HAMException("���݃G���[","BJ-W0245");
        }
    }

}
