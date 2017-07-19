package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HM見積作成(制作費取込)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/02/02 HLC K.Oki)<BR>
 * ・HDX対応(2016/04/20 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateCreationCaptureDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMEstimateCreationCaptureCondition _condition = null;

    /** デフォルトコンストラクタ */
    public FindHMEstimateCreationCaptureDAO() {
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
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + ",");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.SEQUENCENO + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + ",");
        sql.append(" " + Tbj22SeisakuhiSs.SORTNO + ",");
        sql.append(" " + Mbj15CrClass.CLASSNM + ",");
        sql.append(" " + Tbj22SeisakuhiSs.EXPCD + ",");
        sql.append(" " + Mbj16CrExpence.EXPNM + ",");
        sql.append(" " + Tbj22SeisakuhiSs.EXPENSE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.DETAIL + ",");
        sql.append(" " + Tbj22SeisakuhiSs.KIKANS + ",");
        sql.append(" " + Tbj22SeisakuhiSs.KIKANE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CONTRACTDATE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CONTRACTTERM + ",");
        sql.append(" " + Tbj22SeisakuhiSs.SEIKYU + ",");
        sql.append(" " + Tbj22SeisakuhiSs.ORDERNO + ",");
        sql.append(" " + Tbj22SeisakuhiSs.PAY + ",");
        sql.append(" " + Tbj22SeisakuhiSs.USERNAME + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.GETMONEY + ", 0) " + Tbj22SeisakuhiSs.GETMONEY + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.GETCONF + ", '0') " + Tbj22SeisakuhiSs.GETCONF + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.PAYMONEY + ", 0) " + Tbj22SeisakuhiSs.PAYMONEY + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.PAYCONF + ", '0') " + Tbj22SeisakuhiSs.PAYCONF + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.ESTMONEY + ", 0) " + Tbj22SeisakuhiSs.ESTMONEY + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.CLMMONEY + ", 0) " + Tbj22SeisakuhiSs.CLMMONEY + ",");
        sql.append(" " + Tbj22SeisakuhiSs.DELIVERDAY + ",");
        sql.append(" " + Tbj22SeisakuhiSs.SETMONTH + ",");
        sql.append(" " + Mbj17CrDivision.DIVNM + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.GROUPCD + ", 0) " + Tbj22SeisakuhiSs.GROUPCD + ",");
        sql.append(" " + Mbj26BillGroup.GROUPNM + ",");
        sql.append(" " + Mbj26BillGroup.GROUPNMRPT + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.STKYKNO + ", '') " + Tbj22SeisakuhiSs.STKYKNO + ",");
        sql.append(" NVL(" + Mbj29SetteiKyk.STKYKNM + ", '') " + Mbj29SetteiKyk.STKYKNM + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.EGTYKFLG + ", 0) " + Tbj22SeisakuhiSs.EGTYKFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.INPUTTNTCD + ", '') " + Tbj22SeisakuhiSs.INPUTTNTCD + ",");
        sql.append(" " + Mbj30InputTnt.INPUTTNT + ",");
        sql.append(" " + Tbj22SeisakuhiSs.NOTE + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.CLASSCDFLG + ", '0') " + Tbj22SeisakuhiSs.CLASSCDFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.EXPCDFLG + ", '0') " + Tbj22SeisakuhiSs.EXPCDFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.EXPENSEFLG + ", '0') " + Tbj22SeisakuhiSs.EXPENSEFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.DETAILFLG + ", '0') " + Tbj22SeisakuhiSs.DETAILFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.KIKANSFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANSFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.KIKANEFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANEFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.CONTRACTDATEFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTDATEFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.CONTRACTTERMFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTTERMFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.SEIKYUFLG + ", '0') " + Tbj22SeisakuhiSs.SEIKYUFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.ORDERNOFLG + ", '0') " + Tbj22SeisakuhiSs.ORDERNOFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.PAYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.USERNAMEFLG + ", '0') " + Tbj22SeisakuhiSs.USERNAMEFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.GETMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.GETMONEYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.PAYMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYMONEYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.ESTMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.ESTMONEYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.CLMMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.CLMMONEYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.DELIVERDAYFLG + ", '0') " + Tbj22SeisakuhiSs.DELIVERDAYFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.SETMONTHFLG + ", '0') " + Tbj22SeisakuhiSs.SETMONTHFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.DIVISIONFLG + ", '0') " + Tbj22SeisakuhiSs.DIVISIONFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.GROUPCDFLG + ", '0') " + Tbj22SeisakuhiSs.GROUPCDFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.STKYKNOFLG + ", '0') " + Tbj22SeisakuhiSs.STKYKNOFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.INPUTTNTCDFLG + ", '0') " + Tbj22SeisakuhiSs.INPUTTNTCDFLG + ",");
        sql.append(" NVL(" + Tbj22SeisakuhiSs.NOTEFLG + ", '0') " + Tbj22SeisakuhiSs.NOTEFLG + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CRTDATE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CRTNM + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CRTAPL + ",");
        sql.append(" " + Tbj22SeisakuhiSs.CRTID + ",");
        sql.append(" " + Tbj22SeisakuhiSs.UPDDATE + ",");
        sql.append(" " + Tbj22SeisakuhiSs.UPDNM + ",");
        sql.append(" " + Tbj22SeisakuhiSs.UPDAPL + ",");
        sql.append(" " + Tbj22SeisakuhiSs.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj22SeisakuhiSs.TBNAME + ",");
        sql.append(" " + Mbj15CrClass.TBNAME + ",");
        sql.append(" " + Mbj16CrExpence.TBNAME + ",");
        sql.append(" " + Mbj17CrDivision.TBNAME + ",");
        sql.append(" " + Mbj26BillGroup.TBNAME + ",");
        sql.append(" " + Mbj29SetteiKyk.TBNAME + ",");
        sql.append(" " + Mbj30InputTnt.TBNAME + ",");
        sql.append(" " + Mbj09Hiyou.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " = TO_DATE('" + _condition.getYearMonth() + "', 'YYYY/MM') AND");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = '" + _condition.getDCarCd() + "' AND");
        sql.append(" " + Tbj22SeisakuhiSs.DIVCD + " = '" + _condition.getDivCd() + "' AND");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = '" + _condition.getClassDiv() + "' AND");
        sql.append(" " + Mbj09Hiyou.TERM + " = '" + DateUtil.getTerm(_condition.getYearMonth()) + "' AND");

        //課税区分＝契約の場合
        if(_condition.getDivCd() != null){
            if (_condition.getDivCd().equals(HAMConstants.TAXKBN_CONTRACT)) {
                //契約関連
                sql.append(" " + Mbj09Hiyou.MEDIACD + " = '" + HAMConstants.MEDIACD_CONTRACT + "' AND");
            } else {
                //広告制作費
                sql.append(" " + Mbj09Hiyou.MEDIACD + " = '" + HAMConstants.MEDIACD_PRODUCTION + "' AND");
            }
        }

        if (_condition.getGroupCd() == null) {
            /** 2016/02/02 請求業務変更対応 HLC K.Oki MOD Start */
            //sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = ''");
            sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = '' AND");
            /** 2016/02/02 請求業務変更対応 HLC K.Oki MOD End */
        } else {
            sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = '" + _condition.getGroupCd() + "' AND");
        }

        sql.append(" " + Tbj22SeisakuhiSs.CLASSCD + " = " + Mbj15CrClass.CLASSCD + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " >= " + Mbj15CrClass.DATEFROM + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " <= " + Mbj15CrClass.DATETO + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj16CrExpence.CLASSDIV + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.EXPCD + " = " + Mbj16CrExpence.EXPCD + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " >= " + Mbj16CrExpence.DATEFROM + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CRDATE + " <= " + Mbj16CrExpence.DATETO + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.DIVCD + " = " + Mbj17CrDivision.DIVCD + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.STKYKNO + " = " + Mbj29SetteiKyk.STKYKNO + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj29SetteiKyk.PHASE + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj30InputTnt.PHASE + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj30InputTnt.CLASSDIV + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.INPUTTNTCD + " = " + Mbj30InputTnt.SEQNO + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj30InputTnt.DCARCD + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj09Hiyou.PHASE + "(+) AND");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj09Hiyou.DCARCD + "(+)");

        sql.append(" ORDER BY ");
        sql.append(Tbj22SeisakuhiSs.SORTNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMEstimateCreationCaptureVO> selectVO(FindHMEstimateCreationCaptureCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMEstimateCreationCaptureVO());

        try {
            _condition = condition;
            return (List<FindHMEstimateCreationCaptureVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
