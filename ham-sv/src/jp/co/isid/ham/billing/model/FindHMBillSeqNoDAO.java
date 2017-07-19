package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
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
 * HM請求書(見積明細出力順SEQNO)取得検索DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/14 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Soga)<BR>
 * ・HDX対応(2016/04/18 HLC K.Soga)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHMBillSeqNoDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMBillSeqNoCondition _condition = null;

    /** デフォルトコンストラクタ */
    public FindHMBillSeqNoDAO() {
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

    public String getSelectSQL() {

        String sql = null;

        sql = getSelectSummarySQL();

        return sql;
    }

    /**
     * 見積明細出力順SEQNO集約キー取得SQL作成
     * @return String SQL文
     */
    public String getSelectSummarySQL() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + ",");
        sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD Start */
        //sql.append(" " + FindHMBillSeqNoVO.UPDATEFLG);
        sql.append(" " + FindHMBillSeqNoVO.UPDATEFLG + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO);
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + ",");
        /** 2016/02/02 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" NVL(" + Mbj26BillGroup.HCBUMONCDBILL + ", '" + HAMConstants.BILLGROUP_UNKNOWN + "') " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        /** 2016/02/02 HDX対応 HLC K.Soga MOD End */
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD Start */
        //sql.append(" " + BigDecimal.valueOf(0) + " " + FindHMBillSeqNoVO.UPDATEFLG);
        sql.append(" " + BigDecimal.valueOf(0) + " " + FindHMBillSeqNoVO.UPDATEFLG + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO);
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Mbj26BillGroup.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "/01', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " IN ( '" + HAMConstants.ESTIMATE_CLASS_PRODUCTION + "', '" + HAMConstants.ESTIMATE_CLASS_CRPRODUCTION + "' ) AND");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + Tbj05EstimateItem.PHASE + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = " + Tbj05EstimateItem.CRDATE + " AND");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + " = " + Tbj05EstimateItem.ESTSEQNO + " AND");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
        //制作の場合
        if(!_condition.getGroupCd().equals(HAMConstants.GROUPCODE0)){
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " = '" + _condition.getHcbumoncdbill() + "' AND");
        }
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj05EstimateItem.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+)");

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + ",");
        /** 2016/02/02 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" NVL(" + Mbj26BillGroup.HCBUMONCDBILL + ", '" + HAMConstants.BILLGROUP_UNKNOWN + "') " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        /** 2016/02/02 HDX対応 HLC K.Soga MOD End */
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");

        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD Start */
        //sql.append(" " + BigDecimal.valueOf(0) + " " + FindHMBillSeqNoVO.UPDATEFLG);
        sql.append(" " + BigDecimal.valueOf(0) + " " + FindHMBillSeqNoVO.UPDATEFLG + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO);
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" " + Tbj06EstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj05EstimateItem.TBNAME + ",");
        sql.append(" " + Mbj26BillGroup.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "/01', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + " = '" + HAMConstants.ESTIMATE_CLASS_MEDIA + "' AND");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + Tbj05EstimateItem.PHASE + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = " + Tbj05EstimateItem.CRDATE + " AND");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + " = " + Tbj05EstimateItem.ESTSEQNO + " AND");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
        //制作の場合
        if(!_condition.getGroupCd().equals(HAMConstants.GROUPCODE0)){
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " = '" + _condition.getHcbumoncdbill() + "' AND");
        }
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj05EstimateItem.HCBUMONCD + " = " + Mbj26BillGroup.HCBUMONCD + "(+)");
        sql.append(" )");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD + ",");
        sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD Start */
        //sql.append(" " + FindHMBillSeqNoVO.UPDATEFLG);
        sql.append(" " + FindHMBillSeqNoVO.UPDATEFLG + ",");
        sql.append(" " + Tbj05EstimateItem.ESTIMATECLASS + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.SORTNO);
        /** 2016/02/02 請求業務変更対応 HLC K.Soga MOD End */

        sql.append(" ORDER BY");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj06EstimateDetail.SORTNO + ",");
        /** 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */
        sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj05EstimateItem.GROUPCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillSeqNoVO> selectSummaryVO(FindHMBillSeqNoCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMBillSeqNoVO());

        try {
            _condition = condition;
            return (List<FindHMBillSeqNoVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}