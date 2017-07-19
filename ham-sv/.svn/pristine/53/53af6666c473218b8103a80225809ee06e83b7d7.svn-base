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
 * 制作請求表取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindBillProductionOutputDAO extends AbstractRdbDao {

    private CheckBillProductionOutputCondition _condition = null;

    /** コスト管理表 */
    private static final String RPTID_CKH = "R05";
    /** フラグON */
    private static final String FLG_ON = "1";
    /** フラグOFF */
    private static final String FLG_OFF = "0";
    /** コンボ(すべてのItemData値) */
    private static final String ALL_ITEM_DATA = "-1";
    /** 車種表示順(並び順) */
    private static final String CARSORT_NAME = "NAME";
    /** 車種表示順(出力オプション順) */
    private static final String CARSORT_OPTION = "OPTION";
    /** 出力対象(予定) */
    private static final String OUTPUT_PLAN = "yotei";
    /** 出力対象(請求) */
    private static final String OUTPUT_REQUEST = "seikyu";
    /**
     * デフォルトコンストラクタ
     */
    public FindBillProductionOutputDAO() {
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
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {

        String[] retTbl = new String[]{};

        if (_condition.getOutputFlg().equals(OUTPUT_PLAN)) {
            // 出力対象(予定)
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
            // 出力対象(請求)
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
                    //請求表不具合対応 2013/11/13 HLC H.Watabe update start
                    //Tbj06EstimateDetail.MITUMORI
                    Tbj06EstimateDetail.MITUMORI,
                    Tbj06EstimateDetail.ESTDETAILSEQNO
                    //請求表不具合対応 2013/11/13 HLC H.Watabe update end
            };
        }

        return retTbl;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
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
            // 出力オプション順の場合
            // 出力対象の車種を取得
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
            // 出力対象(請求)

            tbl.append(", ");
            tbl.append(Tbj06EstimateDetail.TBNAME);
            tbl.append(", ");
            tbl.append(Tbj07EstimateCreate.TBNAME);
        }

        return tbl.toString();
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

        sql.append("SELECT ");
        //全項目を取得
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

        //請求先Grが「すべて」以外の場合の編集（-1が「すべて」）
        if (_condition.getDemandGroup().equals(ALL_ITEM_DATA)) {
            // すべて

        } else if (_condition.getDemandGroup().equals("")) {
            // 未設定
            sql.append(" AND " + Tbj22SeisakuhiSs.GROUPCD + " IS NULL");
        } else {
            // 上記以外
            sql.append(" AND " + Tbj22SeisakuhiSs.GROUPCD + " = '" + _condition.getDemandGroup() + "'");
        }

        sql.append("   AND " + Tbj22SeisakuhiSs.PHASE + " = '" + _condition.getPhase() + "'");
        sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " >= " + "TO_DATE('" + _condition.getYearMonthFrom() + "', 'YYYY/MM')");
        sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " <= " + "TO_DATE('" + _condition.getYearMonthTo() + "', 'YYYY/MM')");

        if (_condition.getCarSort().equals(CARSORT_OPTION)) {
            // 出力オプション順の場合
            sql.append("   AND " + Tbj22SeisakuhiSs.DCARCD + " = EXT_DCAR_CD(+)");
        }

        if (_condition.getOutputFlg().equals(OUTPUT_PLAN)) {
            // 出力対象(予定)

            sql.append(" ORDER BY ");
            if (_condition.getCarSort().equals(CARSORT_OPTION)) {
                // 出力オプション順の場合
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj13CarOutCtrl.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj22SeisakuhiSs.SORTNO);
            } else if (_condition.getCarSort().equals(CARSORT_NAME)) {
                // 並び順の場合
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj05Car.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM);
            }

        } else {
            // 出力対象(請求)

            sql.append("   AND " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj07EstimateCreate.ESTDETAILSEQNO);
            sql.append("   AND " + Tbj22SeisakuhiSs.DCARCD + " = " + Tbj07EstimateCreate.DCARCD);
            sql.append("   AND " + Tbj22SeisakuhiSs.PHASE + " = " + Tbj07EstimateCreate.PHASE);
            sql.append("   AND " + Tbj22SeisakuhiSs.CRDATE + " = " + Tbj07EstimateCreate.CRDATE);
            sql.append("   AND " + Tbj22SeisakuhiSs.SEQUENCENO + " = " + Tbj07EstimateCreate.SEQUENCENO);

            sql.append(" ORDER BY ");
            if (_condition.getCarSort().equals(CARSORT_OPTION)) {
                // 出力オプション順の場合
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj13CarOutCtrl.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj22SeisakuhiSs.SORTNO + ",");
                sql.append(    Tbj06EstimateDetail.SORTNO);
            } else if (_condition.getCarSort().equals(CARSORT_NAME)) {
                // 並び順の場合
                sql.append(    Tbj22SeisakuhiSs.CRDATE + ",");
                sql.append(    Mbj05Car.SORTNO + ",");
                sql.append(    Mbj05Car.CARNM + ",");
                sql.append(    Tbj06EstimateDetail.SORTNO);
            }
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindBillProductionOutputVO> selectVO(CheckBillProductionOutputCondition cond) throws HAMException {

        List<FindBillProductionOutputVO> result = null;

        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
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
