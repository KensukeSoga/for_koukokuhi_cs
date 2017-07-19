package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HM請求書(見積明細)取得検索DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHMBillDetailDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMBillDetailCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillDetailDAO() {
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
        sql.append(" " + Tbj06EstimateDetail.TANKA + ",");
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
        sql.append(" " + Tbj06EstimateDetail.CRTDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRTNM + ",");
        sql.append(" " + Tbj06EstimateDetail.CRTAPL + ",");
        sql.append(" " + Tbj06EstimateDetail.CRTID + ",");
        sql.append(" " + Tbj06EstimateDetail.UPDDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.UPDNM + ",");
        sql.append(" " + Tbj06EstimateDetail.UPDAPL + ",");
        sql.append(" " + Tbj06EstimateDetail.UPDID + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.MEDIANM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSNM + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTNM + ",");
        sql.append(" NVL(" + Mbj12Code.YOBI1 + ", (");
        sql.append(" SELECT");
        sql.append(" " + Mbj12Code.YOBI1);
        sql.append(" FROM");
        sql.append(" " + Mbj12Code.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Mbj12Code.CODETYPE + " = '" + HAMConstants.CODETYPE_CALKBN + "' AND");
        sql.append(" " + Mbj12Code.KEYCODE + " = '" + HAMConstants.CALKBN_EXTERNAL + "'");
        sql.append(" )");
        sql.append(" ) " + FindHMEstimateDetailVO.TAX);

        sql.append(" FROM");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME + ",");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSCD + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACD + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSCD + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCD + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTCD + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.MEDIANM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSNM + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTNM);
        sql.append(" FROM");
        sql.append(" " + Mbj08HcProduct.TBNAME + ",");
        sql.append(" " + Mbj06HcBumon.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Mbj06HcBumon.HCBUMONCD + " = '" + _condition.getHcBumonCd() + "' AND");
        sql.append(" " + Mbj08HcProduct.USEBUMONCD + " = " + Mbj06HcBumon.USEBUMONCD);
        sql.append(" GROUP BY");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSCD + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACD + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSCD + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCD + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTCD + ",");
        sql.append(" " + Mbj08HcProduct.MEDIACLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.MEDIANM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSCLASSNM + ",");
        sql.append(" " + Mbj08HcProduct.BUSINESSNM + ",");
        sql.append(" " + Mbj08HcProduct.PRODUCTNM);
        sql.append(" )");

        sql.append(" WHERE");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "', 'YYYY/MM') AND");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + " = " + _condition.getEstSeqNo() + " AND");
        sql.append(" " + Mbj12Code.CODETYPE + " = '" + HAMConstants.CODETYPE_CALKBN + "' AND");
        sql.append(" " + Tbj06EstimateDetail.PRODUCTCD + " = " + Mbj08HcProduct.PRODUCTCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.MEDIACLASSCD + " = " + Mbj08HcProduct.MEDIACLASSCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.MEDIACD + " = " + Mbj08HcProduct.MEDIACD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCLASSCD + " = " + Mbj08HcProduct.BUSINESSCLASSCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.BUSINESSCD + " = " + Mbj08HcProduct.BUSINESSCD + "(+) AND");
        sql.append(" " + Tbj06EstimateDetail.CALKBN + " = " + Mbj12Code.KEYCODE + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj06EstimateDetail.SORTNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillDetailVO> selectVO(FindHMBillDetailCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMBillDetailVO());

        try {
            _condition = condition;
            return (List<FindHMBillDetailVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
