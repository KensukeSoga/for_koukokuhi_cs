package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
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
 * HM見積一覧(見積案件)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateItemDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMEstimateItemCondition _condition = null;


    /**
     * デフォルトコンストラクタ
     */
    public FindHMEstimateItemDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATEDATE + ",");
        sql.append(" " + Tbj05EstimateItem.COOPKBN + ",");
        sql.append(" " + Tbj05EstimateItem.ADDRESS + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.HCBUMONCD + ",");
        sql.append(" " + Tbj05EstimateItem.HCUSERNM + ",");
        sql.append(" " + Tbj05EstimateItem.DLVDATE + ",");
        sql.append(" " + Tbj05EstimateItem.DISCOUNTRATE + ",");
        sql.append(" " + Tbj05EstimateItem.BIKO + ",");
        sql.append(" " + Tbj05EstimateItem.LASTOUTPUTDATE + ",");
        sql.append(" " + Tbj05EstimateItem.LASTOUTPUTNM + ",");
        sql.append(" " + Tbj05EstimateItem.OUTPUTFILENM + ",");
        sql.append(" " + Tbj05EstimateItem.DCARCD + ",");
        sql.append(" " + Tbj05EstimateItem.DIVCD + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + ",");
        sql.append(" " + Tbj05EstimateItem.CRTDATE + ",");
        sql.append(" " + Tbj05EstimateItem.CRTNM + ",");
        sql.append(" " + Tbj05EstimateItem.CRTAPL + ",");
        sql.append(" " + Tbj05EstimateItem.CRTID + ",");
        sql.append(" " + Tbj05EstimateItem.UPDDATE + ",");
        sql.append(" " + Tbj05EstimateItem.UPDNM + ",");
        sql.append(" " + Tbj05EstimateItem.UPDAPL + ",");
        sql.append(" " + Tbj05EstimateItem.UPDID + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Mbj17CrDivision.DIVNM + ",");
        sql.append(" NVL(" + Mbj26BillGroup.GROUPNM + ", '" + HAMConstants.BILLGROUP_UNKNOWN + "') " + Mbj26BillGroup.GROUPNM + ",");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Mbj06HcBumon.HCBUMONNM + ",");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" NVL(SUM(" + Tbj06EstimateDetail.MITUMORI + "), 0)");
        sql.append(" FROM");
        sql.append(" " + Tbj06EstimateDetail.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + Tbj05EstimateItem.PHASE + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = " + Tbj05EstimateItem.CRDATE + " AND");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + " = " + Tbj05EstimateItem.ESTSEQNO + " ");
        sql.append(" ) " + Tbj06EstimateDetail.MITUMORI + ",");
        sql.append(" TO_CHAR(" + Tbj05EstimateItem.CRDATE + ", 'MM') || '月-' || TRIM(TO_CHAR(" + Tbj05EstimateItem.ESTSEQNO + ", '0000')) || '-' || TO_CHAR(" + Tbj05EstimateItem.COOPKBN + ") " + FindHMEstimateItemVO.ESTIMATENO + ",");
        sql.append(" CASE WHEN " + Tbj05EstimateItem.DIVCD + " = '"+ HAMConstants.TAXKBN_CONTRACT + "'");
        sql.append(" THEN '" + HAMConstants.MEDIACD_CONTRACT + "'");
        sql.append(" ELSE '" + HAMConstants.MEDIACD_PRODUCTION + "'");
        sql.append(" END " + Tbj03MediaMng.MEDIACD);

        sql.append(" FROM");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj17CrDivision.TBNAME + ",");
        sql.append(" " + Mbj26BillGroup.TBNAME + ",");
        sql.append(" " + Mbj06HcBumon.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "', 'YYYY/MM') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " = '" + _condition.getEstimateClass() + "' AND");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + _condition.getEstSeqNo() + " AND");
        sql.append(" " + Mbj12Code.CODETYPE + " = '" + _condition.getCodeType() + "' AND");
        sql.append(" " + Tbj05EstimateItem.DCARCD  + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.DIVCD + " = " + Mbj17CrDivision.DIVCD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.COOPKBN + " = " + Mbj12Code.KEYCODE + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.HCBUMONCD + " = " + Mbj06HcBumon.HCBUMONCD + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj05EstimateItem.ESTIMATENM + ",");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMEstimateItemVO> selectVO(FindHMEstimateItemCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMEstimateItemVO());

        try {
            _condition = condition;
            return (List<FindHMEstimateItemVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
