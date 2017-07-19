package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
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
 * HM請求書作成(媒体)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillMediaReportDAO extends AbstractRdbDao {

    /** 期 */
    private static final String TERM = "TERM";
    /** コープ区分 */
    private static final String COOPKBN = "COOPKBN";
    /** 未設定(媒体・電通車種未設定に使用 */
    private static final String UNKNOWN = "未設定";

    /** 検索条件 */
    private FindHMBillMediaReportCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillMediaReportDAO() {
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
        sql.append(" " + Mbj17CrDivision.DIVNM + ",");
        sql.append(" " + Mbj26BillGroup.GROUPNM + ",");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Mbj06HcBumon.HCBUMONNM + ",");
        sql.append(" " + Mbj06HcBumon.POSTNO + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS1 + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS2 + ",");
        sql.append(" " + Mbj06HcBumon.BUMONCORPNM + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTCD + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTNM + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTNMSUB + ",");
        sql.append(" " + Tbj06EstimateDetail.MEDIACLASSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.MEDIACD + ",");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCLASSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.TEKIYOU + ",");
        sql.append(" " + Tbj06EstimateDetail.OPERATIONDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.SIZECD + ",");
        sql.append(" " + Tbj06EstimateDetail.SIZE + ",");
        sql.append(" " + Tbj06EstimateDetail.SUURYOU + ",");
        sql.append(" " + Tbj06EstimateDetail.UNITGROUPCD + ",");
        sql.append(" " + Tbj06EstimateDetail.UNITGROUPNM + ",");
        sql.append(" " + Tbj06EstimateDetail.TANKA + ", ");
        sql.append(" " + Tbj06EstimateDetail.HYOUJUN + ",");
        sql.append(" " + Tbj06EstimateDetail.NEBIKI + ",");
        sql.append(" " + Tbj06EstimateDetail.MITUMORI + ",");
        sql.append(" " + Tbj06EstimateDetail.KAZEI + ",");
        sql.append(" " + Tbj06EstimateDetail.SYOUHIZEI + ",");
        sql.append(" " + Tbj06EstimateDetail.GOUKEI + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.NOUNYUUFLG + ",");
        sql.append(" " + Tbj06EstimateDetail.DEKIDAKAFLG + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.MEDIANM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSNM + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTNM + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD + ",");
        sql.append(" CASE WHEN " + Tbj03MediaMng.MEDIACD + " IS NULL THEN '" + UNKNOWN + "' ELSE " + Mbj03Media.MEDIANM + " END " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" CASE WHEN " + Tbj03MediaMng.DCARCD + " IS NULL THEN '" + UNKNOWN + "' ELSE " + Mbj05Car.CARNM + " END " + Mbj05Car.CARNM + ",");
        sql.append(" " + Mbj09Hiyou.HIYOUNO);

        sql.append(" FROM");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" DISTINCT");
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
        sql.append(" " + Mbj17CrDivision.DIVNM + ",");
        sql.append(" " + Mbj26BillGroup.GROUPNM + ",");
        sql.append(" " + COOPKBN + "." + Mbj12Code.CODENAME + ",");
        sql.append(" " + Mbj06HcBumon.HCBUMONNM + ",");
        sql.append(" " + Mbj06HcBumon.POSTNO + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS1 + ",");
        sql.append(" " + Mbj06HcBumon.ADDRESS2 + ",");
        sql.append(" " + Mbj06HcBumon.BUMONCORPNM + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTCD + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTNM + ",");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTNMSUB + ",");
        sql.append(" " + Tbj06EstimateDetail.MEDIACLASSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.MEDIACD + ",");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCLASSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCD + ",");
        sql.append(" " + Tbj06EstimateDetail.TEKIYOU + ",");
        sql.append(" " + Tbj06EstimateDetail.OPERATIONDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.SIZECD + ",");
        sql.append(" " + Tbj06EstimateDetail.SIZE + ",");
        sql.append(" " + Tbj06EstimateDetail.SUURYOU + ",");
        sql.append(" " + Tbj06EstimateDetail.UNITGROUPCD + ",");
        sql.append(" " + Tbj06EstimateDetail.UNITGROUPNM + ",");
        sql.append(" " + Tbj06EstimateDetail.TANKA + ", ");
        sql.append(" " + Tbj06EstimateDetail.HYOUJUN + ",");
        sql.append(" " + Tbj06EstimateDetail.NEBIKI + ",");
        sql.append(" " + Tbj06EstimateDetail.MITUMORI + ",");
        sql.append(" " + Tbj06EstimateDetail.KAZEI + ",");
        sql.append(" " + Tbj06EstimateDetail.SYOUHIZEI + ",");
        sql.append(" " + Tbj06EstimateDetail.GOUKEI + ",");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
        sql.append(" " + Tbj06EstimateDetail.NOUNYUUFLG + ",");
        sql.append(" " + Tbj06EstimateDetail.DEKIDAKAFLG + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.MEDIANM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSNM + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTNM + ",");
        sql.append(" " + Tbj03MediaMng.MDYEAR + ",");
        sql.append(" " + Tbj03MediaMng.MDMONTH + ",");
        sql.append(" CASE WHEN TO_NUMBER(" + Tbj03MediaMng.MDMONTH + ") BETWEEN " + HAMConstants.MONTH_APR + " AND " + HAMConstants.MONTH_SEP);
        sql.append(" THEN " + HAMConstants.TERM_FIRST + " ELSE " + HAMConstants.TERM_SECOND + " END " + TERM + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM);

        sql.append(" FROM");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj04MediaMngEstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj03MediaMng.TBNAME + ",");
        sql.append(" " + Mbj03Media.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj17CrDivision.TBNAME + ",");
        sql.append(" " + Mbj26BillGroup.TBNAME + ",");
        sql.append(" " + Mbj06HcBumon.TBNAME + ",");
        sql.append(" " + Mbj08HcProduct.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME + " " + COOPKBN);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "', 'YYYY/MM') AND");
        sql.append(" " + COOPKBN + "." + Mbj12Code.CODETYPE + " = '" + HAMConstants.CODETYPE_COOPKBN + "' AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " = '2' AND");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + " LIKE '1%' AND");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + Tbj06EstimateDetail.PHASE + " AND");
        sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + Tbj06EstimateDetail.CRDATE + " AND");
        sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + Tbj06EstimateDetail.ESTSEQNO + " AND");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO + "(+) AND");
        sql.append(" " + Tbj04MediaMngEstimateDetail.MEDIAMNGNO + " = " + Tbj03MediaMng.MEDIAMNGNO + "(+) AND");
        sql.append(" " + Tbj03MediaMng.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj03MediaMng.MEDIACD + " = " + Mbj03Media.MEDIACD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.DIVCD + " = " + Mbj17CrDivision.DIVCD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.COOPKBN + " = " + Mbj12Code.KEYCODE + "(+) AND");
        sql.append(" " + Tbj05EstimateItem.HCBUMONCD + " = " + Mbj06HcBumon.HCBUMONCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTCD + " = " + Mbj08HcProduct.PRODUCTCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.MEDIACLASSCD + " = " + Mbj08HcProduct.MEDIACLASSCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.MEDIACD + " = " + Mbj08HcProduct.MEDIACD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCLASSCD + " = " + Mbj08HcProduct.BUSINESSCLASSCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCD + " = " + Mbj08HcProduct.BUSINESSCD + "(+)");
        sql.append(" ),");
        sql.append(" " + Mbj09Hiyou.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj05EstimateItem.PHASE + " = " + Mbj09Hiyou.PHASE +"(+) AND");
        sql.append(" " + TERM + " = " + Mbj09Hiyou.TERM + "(+) AND");
        sql.append(" " + Tbj03MediaMng.MEDIACD + " =" + Mbj09Hiyou.MEDIACD + "(+) AND");
        sql.append(" " + Tbj03MediaMng.DCARCD + " =  "+ Mbj09Hiyou.DCARCD + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj03MediaMng.MEDIACD + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillMediaReportVO> selectVO(FindHMBillMediaReportCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMBillMediaReportVO());
        try
        {
            _condition = condition;
            return (List<FindHMBillMediaReportVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
