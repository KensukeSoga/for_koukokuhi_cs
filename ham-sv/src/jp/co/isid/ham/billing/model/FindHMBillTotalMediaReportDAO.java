package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
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
 * HM合計請求書作成(媒体)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillTotalMediaReportDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMBillTotalMediaReportCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillTotalMediaReportDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
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
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
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
        sql.append(" " + Tbj05EstimateItem.ADDRESS + ",");
        sql.append(" MAX(" + Tbj05EstimateItem.DLVDATE + ") " + Tbj05EstimateItem.DLVDATE + ",");
        sql.append(" " + Mbj06HcBumon.HCBUMONNM + ",");
        sql.append(" " + Mbj06HcBumon.POSTNO + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS1 + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS2 + ",");
        sql.append(" " + Mbj06HcBumon.BUMONCORPNM + ",");
        sql.append(" SUM(" + Tbj06EstimateDetail.MITUMORI + ") " + Tbj06EstimateDetail.MITUMORI);

        sql.append(" FROM");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ",");
        sql.append(" " + Mbj06HcBumon.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "', 'YYYY/MM') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " = '" + HAMConstants.ESTIMATE_CLASS_MEDIA + "' AND");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + " LIKE '1%' AND");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + Tbj06EstimateDetail.PHASE + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + Tbj06EstimateDetail.CRDATE + " AND");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + Tbj06EstimateDetail.ESTSEQNO + " AND");
        sql.append(" " + Tbj05EstimateItem.HCBUMONCD + " = " + Mbj06HcBumon.HCBUMONCD + "(+)");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj05EstimateItem.PHASE + ",");
        sql.append(" " + Tbj05EstimateItem.CRDATE + ",");
        sql.append(" " + Tbj05EstimateItem.ADDRESS + ",");
        sql.append(" " + Mbj06HcBumon.HCBUMONNM + ",");
        sql.append(" " + Mbj06HcBumon.POSTNO + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS1 + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS2 + ",");
        sql.append(" " + Mbj06HcBumon.BUMONCORPNM);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillTotalMediaReportVO> selectVO(FindHMBillTotalMediaReportCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMBillTotalMediaReportVO());
        try
        {
            _condition = condition;
            return (List<FindHMBillTotalMediaReportVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
