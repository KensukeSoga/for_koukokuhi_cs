/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * ���ϖ��׎擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/14 T.Fujiyoshi)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/02/05 HLC K.Soga)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstimateDetailDAO extends AbstractRdbDao {

    FindEstimateDetailCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{COND, ESTDETAILSEQNO};
    private SelSqlMode _SelSqlMode = SelSqlMode.COND;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindEstimateDetailDAO() {
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
        return new String[] {
                Tbj06EstimateDetail.ESTDETAILSEQNO
                ,Tbj06EstimateDetail.PHASE
                ,Tbj06EstimateDetail.CRDATE
                ,Tbj06EstimateDetail.ESTSEQNO
                ,Tbj06EstimateDetail.SORTNO
                ,Tbj06EstimateDetail.PRODUCTCD
                ,Tbj06EstimateDetail.PRODUCTNM
                ,Tbj06EstimateDetail.PRODUCTNMSUB
                ,Tbj06EstimateDetail.MEDIACLASSCD
                ,Tbj06EstimateDetail.MEDIACD
                ,Tbj06EstimateDetail.BUSINESSCLASSCD
                ,Tbj06EstimateDetail.BUSINESSCD
                ,Tbj06EstimateDetail.TEKIYOU
                ,Tbj06EstimateDetail.OPERATIONDATE
                ,Tbj06EstimateDetail.SIZECD
                ,Tbj06EstimateDetail.SIZE
                ,Tbj06EstimateDetail.SUURYOU
                ,Tbj06EstimateDetail.UNITGROUPCD
                ,Tbj06EstimateDetail.UNITGROUPNM
                ,Tbj06EstimateDetail.TANKA
                ,Tbj06EstimateDetail.HYOUJUN
                ,Tbj06EstimateDetail.NEBIKI
                ,Tbj06EstimateDetail.MITUMORI
                ,Tbj06EstimateDetail.KAZEI
                ,Tbj06EstimateDetail.SYOUHIZEI
                ,Tbj06EstimateDetail.GOUKEI
                ,Tbj06EstimateDetail.CALKBN
                ,Tbj06EstimateDetail.NOUNYUUFLG
                ,Tbj06EstimateDetail.DEKIDAKAFLG
                ,Tbj06EstimateDetail.OUTPUTGROUP

                /* 2016/02/05 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
                ,Tbj06EstimateDetail.HCBUMONCDBILL
                ,Tbj06EstimateDetail.HCBUMONCDBILLSEQNO
                /* 2016/02/05 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

                ,Tbj06EstimateDetail.CRTDATE
                ,Tbj06EstimateDetail.CRTNM
                ,Tbj06EstimateDetail.CRTAPL
                ,Tbj06EstimateDetail.CRTID
                ,Tbj06EstimateDetail.UPDDATE
                ,Tbj06EstimateDetail.UPDNM
                ,Tbj06EstimateDetail.UPDAPL
                ,Tbj06EstimateDetail.UPDID
                ,Mbj08HcProduct.MEDIACLASSNM
                ,Mbj08HcProduct.MEDIANM
                ,Mbj08HcProduct.BUSINESSCLASSNM
                ,Mbj08HcProduct.BUSINESSNM
                ,Mbj08HcProduct.PRODUCTNM
                ,getDefaultTaxString()
        };
    }

    /**
     * �ł̕�������擾����
     *
     * @return �ł̕�����(���A�O�A��)
     */
    public String getDefaultTaxString() {
        StringBuffer tax = new StringBuffer();

        tax.append("NVL(");
        tax.append(Mbj12Code.YOBI1);
        tax.append(", ");

        tax.append("(");
        tax.append("SELECT ");
        tax.append(Mbj12Code.YOBI1);
        tax.append(" FROM ");
        tax.append(Mbj12Code.TBNAME);
        tax.append(" WHERE ");
        tax.append(Mbj12Code.CODETYPE);
        tax.append(" = ");
        tax.append("'15'");
        tax.append(" AND ");
        tax.append(Mbj12Code.KEYCODE);
        tax.append(" = ");
        tax.append("'E'");
        tax.append(")");

        tax.append(") TAX");

        return tax.toString();
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj06EstimateDetail.TBNAME);

        tbl.append(", ");
        tbl.append(Mbj12Code.TBNAME);

        tbl.append(", (");
        tbl.append("SELECT DISTINCT ");
        tbl.append(Mbj08HcProduct.MEDIACLASSCD);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.MEDIACD);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.BUSINESSCLASSCD);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.BUSINESSCD);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.PRODUCTCD);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.MEDIACLASSNM);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.MEDIANM);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.BUSINESSCLASSNM);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.BUSINESSNM);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.PRODUCTNM);

        tbl.append(" FROM ");
        tbl.append(Mbj08HcProduct.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj06HcBumon.TBNAME);

        tbl.append(" WHERE ");
        tbl.append(Mbj06HcBumon.HCBUMONCD);
        tbl.append(" = '");
        tbl.append(_condition.getHcBumonCd());
        tbl.append("'");
        tbl.append(" AND ");
        tbl.append(Mbj08HcProduct.USEBUMONCD);
        tbl.append(" = ");
        tbl.append(Mbj06HcBumon.USEBUMONCD);

        tbl.append(") HCPRODUCT");

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

        if (_SelSqlMode.equals(SelSqlMode.COND)) {

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
            sql.append(Tbj06EstimateDetail.PHASE);
            sql.append(" = ");
            sql.append(_condition.getPhase());
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.CRDATE);
            sql.append(" = TO_DATE('");
            sql.append(_condition.getYearMonth());
            sql.append("', 'YYYY/MM')");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.ESTSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstSeqNo());
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.PRODUCTCD);
            sql.append(" = ");
            sql.append(Mbj08HcProduct.PRODUCTCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.MEDIACLASSCD);
            sql.append(" = ");
            sql.append(Mbj08HcProduct.MEDIACLASSCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.MEDIACD);
            sql.append(" = ");
            sql.append(Mbj08HcProduct.MEDIACD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.BUSINESSCLASSCD);
            sql.append(" = ");
            sql.append(Mbj08HcProduct.BUSINESSCLASSCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.BUSINESSCD);
            sql.append(" = ");
            sql.append(Mbj08HcProduct.BUSINESSCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append("'15'");
            sql.append(" = ");
            sql.append(Mbj12Code.CODETYPE);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.CALKBN);
            sql.append(" = ");
            sql.append(Mbj12Code.KEYCODE);
            sql.append("(+)");

            sql.append(" ORDER BY ");
            sql.append(Tbj06EstimateDetail.SORTNO);
        } else {
            sql.append("SELECT ");
            sql.append("NVL(MAX(");
            sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
            sql.append("), 0) + 1 ");
            sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
            sql.append(" FROM ");
            sql.append(Tbj06EstimateDetail.TBNAME);
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
    public List<FindEstimateDetailVO> selectVO(FindEstimateDetailCondition condition) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindEstimateDetailVO());

        try {
            _condition = condition;
            return (List<FindEstimateDetailVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾���܂�
     * @return ���ϖ��׊Ǘ�NO
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindEstimateDetailVO> getEstDetailSeqNo() throws HAMException {
        super.setModel(new FindEstimateDetailVO());
        try
        {
            _SelSqlMode = SelSqlMode.ESTDETAILSEQNO;
            return (List<FindEstimateDetailVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
