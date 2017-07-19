package jp.co.isid.ham.production.model;

import java.util.List;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj10CrCarInfo;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class GetRepDataForCostMngDAO extends AbstractRdbDao {

    /** 検索条件 */
    private GetRepDataForCostMngCondition _cond = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        HEADER,
        DETAILS,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public GetRepDataForCostMngDAO() {
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
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (SelSqlMode.HEADER.equals(_SelSqlMode)) {
            sql.append(" SELECT ");
            sql.append("     " + Tbj10CrCarInfo.DCARCD + "");
            sql.append("    ," + Tbj10CrCarInfo.PHASE + "");
            sql.append("    ," + Tbj10CrCarInfo.CRDATE + "");
            sql.append("    ," + Tbj10CrCarInfo.RAP + "");
            sql.append("    ," + Tbj10CrCarInfo.CPUSER + "");
            sql.append("    ," + Tbj10CrCarInfo.CDSTAFF + "");
            sql.append("    ," + Tbj10CrCarInfo.CRCOMPANY + "");
            sql.append("    ," + Tbj10CrCarInfo.SCHEDULE1 + "");
            sql.append("    ," + Tbj10CrCarInfo.SCHEDULE2 + "");
            sql.append("    ," + Tbj10CrCarInfo.SCHEDULE3 + "");
            sql.append("    ," + Tbj10CrCarInfo.NOTE + "");
            sql.append(" FROM ");
            sql.append("     " + Tbj10CrCarInfo.TBNAME);
            sql.append(" WHERE ");
            sql.append("     " + Tbj10CrCarInfo.PHASE  + "  = " + ConvertToDBString(_cond.getPhase()));
            if (_cond.getToDate() != null) {
                sql.append(" AND " + Tbj10CrCarInfo.CRDATE + " <= " + ConvertToDBString(_cond.getToDate()));
            }
            if (_cond.getCarList() != null && _cond.getCarList().size() > 0) {
                sql.append(" AND " + Tbj10CrCarInfo.DCARCD + " IN ('" + StringUtil.join("','", _cond.getCarList().toArray(new String[0])) + "')");
            }
            sql.append(" ORDER BY ");
            sql.append("     " + Tbj10CrCarInfo.CRDATE + " DESC ");

        } else if (SelSqlMode.DETAILS.equals(_SelSqlMode)) {
            if ((_cond.getOutFlgGenkaMeisai() || _cond.getOutFlgGenkaToukei())) {
                //制作原価表データ取得用SQL
                sql.append(" SELECT ");
                //出力用項目
                sql.append("     " + Mbj05Car.CARNM);
                sql.append("    ," + Mbj15CrClass.CLASSNM);
                sql.append("    ," + Mbj16CrExpence.EXPNM);
                sql.append("    ," + Tbj11CrCreateData.EXPENSE);
                sql.append("    ," + Tbj11CrCreateData.DETAIL);
                sql.append("    ," + Tbj11CrCreateData.KIKANS);
                sql.append("    ," + Tbj11CrCreateData.KIKANE);
                sql.append("    ," + Tbj11CrCreateData.CONTRACTTERM);
                sql.append("    ," + Tbj11CrCreateData.SEIKYU);
                sql.append("    ," + Tbj11CrCreateData.ORDERNO);
                sql.append("    ," + Tbj11CrCreateData.PAY);
                sql.append("    ," + Tbj11CrCreateData.USERNAME);
                sql.append("    ," + Tbj11CrCreateData.GETMONEY);
                sql.append("    ," + Tbj11CrCreateData.GETCONF);
                sql.append("    ," + Tbj11CrCreateData.PAYMONEY);
                sql.append("    ," + Tbj11CrCreateData.PAYCONF);
                sql.append("    ," + Tbj11CrCreateData.ESTMONEY);
                sql.append("    ," + Tbj11CrCreateData.CLMMONEY);
                sql.append("    ," + Tbj11CrCreateData.DELIVERDAY);
                sql.append("    ," + Tbj11CrCreateData.SETMONTH);
                sql.append("    ," + Mbj17CrDivision.DIVNM);
                sql.append("    ," + Mbj26BillGroup.GROUPNMRPT);
                sql.append("    ," + Mbj29SetteiKyk.STKYKNM);
                sql.append("    ," + Tbj11CrCreateData.EGTYKFLG);
                sql.append("    ," + Mbj30InputTnt.INPUTTNT);
                sql.append("    ," + Tbj11CrCreateData.CPTNTNM);
                sql.append("    ," + Tbj11CrCreateData.NOTE);
                //色変更情報項目
                sql.append("    ," + Tbj11CrCreateData.DCARCDFLG);
                sql.append("    ," + Tbj11CrCreateData.CLASSCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EXPCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EXPENSEFLG);
                sql.append("    ," + Tbj11CrCreateData.DETAILFLG);
                sql.append("    ," + Tbj11CrCreateData.KIKANSFLG);
                sql.append("    ," + Tbj11CrCreateData.KIKANEFLG);
                sql.append("    ," + Tbj11CrCreateData.CONTRACTTERMFLG);
                sql.append("    ," + Tbj11CrCreateData.SEIKYUFLG);
                sql.append("    ," + Tbj11CrCreateData.ORDERNOFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYFLG);
                sql.append("    ," + Tbj11CrCreateData.USERNAMEFLG);
                sql.append("    ," + Tbj11CrCreateData.GETMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.GETCONFIRMFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYCONFIRMFLG);
                sql.append("    ," + Tbj11CrCreateData.ESTMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.CLMMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.DELIVERDAYFLG);
                sql.append("    ," + Tbj11CrCreateData.SETMONTHFLG);
                sql.append("    ," + Tbj11CrCreateData.DIVISIONFLG);
                sql.append("    ," + Tbj11CrCreateData.GROUPCDFLG);
                sql.append("    ," + Tbj11CrCreateData.STKYKNOFLG);
                sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EGTYKFLGFLG);
                sql.append("    ," + Tbj11CrCreateData.CPTNTNMFLG);
                sql.append("    ," + Tbj11CrCreateData.NOTEFLG);
                //内部処理用項目
                sql.append("    ," + Tbj11CrCreateData.CRDATE);
                sql.append("    ," + Tbj11CrCreateData.CLASSDIV);
                sql.append("    ," + Tbj11CrCreateData.DCARCD);
                sql.append("    ," + Tbj11CrCreateData.CLASSCD);
                sql.append("    ," + Tbj11CrCreateData.EXPCD);
                sql.append("    ," + Tbj11CrCreateData.DIVCD);
                sql.append("    ," + Mbj11CarSec.AUTHORITY);
                //ソート用
                sql.append("    ," + Tbj11CrCreateData.SORTNO + " ");

                sql.append(" FROM ");
                sql.append("     " + Tbj11CrCreateData.TBNAME);
                sql.append("    ," + Mbj05Car.TBNAME);
                sql.append("    ," + Mbj11CarSec.TBNAME);
                sql.append("    ," + Mbj15CrClass.TBNAME);
                sql.append("    ," + Mbj16CrExpence.TBNAME);
                sql.append("    ," + Mbj17CrDivision.TBNAME);
                sql.append("    ," + Mbj26BillGroup.TBNAME);
                sql.append("    ," + Mbj29SetteiKyk.TBNAME);
                sql.append("    ," + Mbj30InputTnt.TBNAME);

                sql.append(" WHERE ");
                sql.append("     " + Tbj11CrCreateData.PHASE  + "  = " + ConvertToDBString(_cond.getPhase()));
                if (_cond.getFromDate() != null) {
                    sql.append(" AND " + Tbj11CrCreateData.CRDATE + " >= " + ConvertToDBString(_cond.getFromDate()));
                }
                if (_cond.getToDate() != null) {
                    sql.append(" AND " + Tbj11CrCreateData.CRDATE + " <= " + ConvertToDBString(_cond.getToDate()));
                }
                if (_cond.getCarList() != null && _cond.getCarList().size() > 0) {
                    sql.append(" AND " + Tbj11CrCreateData.DCARCD + " IN ('" + StringUtil.join("','", _cond.getCarList().toArray(new String[0])) + "')");
                }
                sql.append(" AND " + Tbj11CrCreateData.CLASSDIV + "  = '0'");

                if (!StringUtil.isBlank(_cond.getClassCd())) {
                    sql.append(" AND " + Tbj11CrCreateData.CLASSCD + "  = " + ConvertToDBString(_cond.getClassCd()));
                }

                sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");

                if (!StringUtil.isBlank(_cond.getExp())) {
                    //sql.append(" AND " + Tbj11CrCreateData.EXPCD + "  = " + ConvertToDBString(_cond.getExp()));
                    sql.append(" AND " + Mbj16CrExpence.EXPNM + "  = " + ConvertToDBString(_cond.getExp()));
                }

                //結合条件(車種マスタ)
                sql.append(" AND " + Mbj05Car.DCARCD         + "(+)  = " + Tbj11CrCreateData.DCARCD);
                //結合条件(車種権限マスタ)
                sql.append(" AND " + Mbj11CarSec.SECTYPE     + "     = '1'");
                sql.append(" AND " + Mbj11CarSec.HAMID       + "(+)  = " + ConvertToDBString(_cond.getHamid()));
                sql.append(" AND " + Mbj11CarSec.DCARCD      + "(+)  = " + Tbj11CrCreateData.DCARCD);
                //結合条件(予算分類マスタ)
                sql.append(" AND " + Mbj15CrClass.CLASSCD    + "(+)  = " + Tbj11CrCreateData.CLASSCD);
                sql.append(" AND " + Mbj15CrClass.DATEFROM   + "(+) <= " + Tbj11CrCreateData.CRDATE);
                sql.append(" AND " + Mbj15CrClass.DATETO     + "(+) >= " + Tbj11CrCreateData.CRDATE);
                //結合条件(予算費目マスタ)
                sql.append(" AND " + Mbj16CrExpence.EXPCD    + "(+) = " + Tbj11CrCreateData.EXPCD);
                sql.append(" AND " + Mbj16CrExpence.CLASSDIV + "(+) = " + Tbj11CrCreateData.CLASSDIV);
                sql.append(" AND " + Mbj16CrExpence.DATEFROM + "(+) <= " + Tbj11CrCreateData.CRDATE);
                sql.append(" AND " + Mbj16CrExpence.DATETO   + "(+) >= " + Tbj11CrCreateData.CRDATE);
                //結合条件(区分マスタ)
                sql.append(" AND " + Mbj17CrDivision.DIVCD   + "(+)  = " + Tbj11CrCreateData.DIVCD);
                //結合条件(請求グループマスタ)
                sql.append(" AND " + Mbj26BillGroup.GROUPCD  + "(+)  = " + Tbj11CrCreateData.GROUPCD);
                //結合条件(設定局マスタ)
                sql.append(" AND " + Mbj29SetteiKyk.PHASE    + "(+)  = " + Tbj11CrCreateData.PHASE);
                sql.append(" AND " + Mbj29SetteiKyk.STKYKNO  + "(+)  = " + Tbj11CrCreateData.STKYKNO);
                //結合条件(入力担当マスタ)
                sql.append(" AND " + Mbj30InputTnt.PHASE     + "(+)  = " + Tbj11CrCreateData.PHASE);
                sql.append(" AND " + Mbj30InputTnt.CLASSDIV  + "(+)  = " + Tbj11CrCreateData.CLASSDIV);
                sql.append(" AND " + Mbj30InputTnt.SEQNO     + "(+)  = " + Tbj11CrCreateData.INPUTTNTCD);
                sql.append(" AND " + Mbj30InputTnt.DCARCD    + "(+)  = " + Tbj11CrCreateData.DCARCD);
                if (_cond.getInputTntList() != null && _cond.getInputTntList().size() > 0 && _cond.getInputTntNullFlg()) {
                    sql.append(" AND (");
                    sql.append(Mbj30InputTnt.INPUTTNT + " IN ('" + StringUtil.join("','", _cond.getInputTntList().toArray(new String[0])) + "')");
                    sql.append(" OR ");
                    sql.append(Tbj11CrCreateData.INPUTTNTCD + " IS NULL ");
                    sql.append(" )");
                } else if (_cond.getInputTntList() != null && _cond.getInputTntList().size() > 0 && !_cond.getInputTntNullFlg()) {
                    sql.append(" AND " + Mbj30InputTnt.INPUTTNT + " IN ('" + StringUtil.join("','", _cond.getInputTntList().toArray(new String[0])) + "')");
                    //sql.append(" AND " + Mbj30InputTnt.INPUTTNT + " IS NOT NULL ");
                } else if (!_cond.getInputTntNullFlg()) {
                    sql.append(" AND " + Tbj11CrCreateData.INPUTTNTCD + " IS NOT NULL ");
                }
            }

            if ((_cond.getOutFlgSeisakuMeisai() || _cond.getOutFlgSeisakuToukei())) {

                if ((_cond.getOutFlgGenkaMeisai() || _cond.getOutFlgGenkaToukei())) {
                    //制作原価表用の出力がある場合
                    sql.append(" UNION ALL ");
                }
                //制作費表データ取得用SQL
                sql.append(" SELECT ");
                //出力用項目
                sql.append("     " + Mbj05Car.CARNM);
                sql.append("    ,'' AS " + Mbj15CrClass.CLASSNM);
                sql.append("    ," + Mbj16CrExpence.EXPNM);
                sql.append("    ," + Tbj11CrCreateData.EXPENSE);
                sql.append("    ," + Tbj11CrCreateData.DETAIL);
                sql.append("    ," + Tbj11CrCreateData.KIKANS);
                sql.append("    ," + Tbj11CrCreateData.KIKANE);
                sql.append("    ," + Tbj11CrCreateData.CONTRACTTERM);
                sql.append("    ," + Tbj11CrCreateData.SEIKYU);
                sql.append("    ," + Tbj11CrCreateData.ORDERNO);
                sql.append("    ," + Tbj11CrCreateData.PAY);
                sql.append("    ," + Tbj11CrCreateData.USERNAME);
                sql.append("    ," + Tbj11CrCreateData.GETMONEY);
                sql.append("    ," + Tbj11CrCreateData.GETCONF);
                sql.append("    ," + Tbj11CrCreateData.PAYMONEY);
                sql.append("    ," + Tbj11CrCreateData.PAYCONF);
                sql.append("    ," + Tbj11CrCreateData.ESTMONEY);
                sql.append("    ," + Tbj11CrCreateData.CLMMONEY);
                sql.append("    ," + Tbj11CrCreateData.DELIVERDAY);
                sql.append("    ," + Tbj11CrCreateData.SETMONTH);
                sql.append("    ," + Mbj17CrDivision.DIVNM);
                sql.append("    ," + Mbj26BillGroup.GROUPNMRPT);
                sql.append("    ," + Mbj29SetteiKyk.STKYKNM);
                sql.append("    ," + Tbj11CrCreateData.EGTYKFLG);
                sql.append("    ," + Mbj30InputTnt.INPUTTNT);
                sql.append("    ," + Tbj11CrCreateData.CPTNTNM);
                sql.append("    ," + Tbj11CrCreateData.NOTE);
                //色変更情報項目
                sql.append("    ," + Tbj11CrCreateData.DCARCDFLG);
                sql.append("    ," + Tbj11CrCreateData.CLASSCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EXPCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EXPENSEFLG);
                sql.append("    ," + Tbj11CrCreateData.DETAILFLG);
                sql.append("    ," + Tbj11CrCreateData.KIKANSFLG);
                sql.append("    ," + Tbj11CrCreateData.KIKANEFLG);
                sql.append("    ," + Tbj11CrCreateData.CONTRACTTERMFLG);
                sql.append("    ," + Tbj11CrCreateData.SEIKYUFLG);
                sql.append("    ," + Tbj11CrCreateData.ORDERNOFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYFLG);
                sql.append("    ," + Tbj11CrCreateData.USERNAMEFLG);
                sql.append("    ," + Tbj11CrCreateData.GETMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.GETCONFIRMFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.PAYCONFIRMFLG);
                sql.append("    ," + Tbj11CrCreateData.ESTMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.CLMMONEYFLG);
                sql.append("    ," + Tbj11CrCreateData.DELIVERDAYFLG);
                sql.append("    ," + Tbj11CrCreateData.SETMONTHFLG);
                sql.append("    ," + Tbj11CrCreateData.DIVISIONFLG);
                sql.append("    ," + Tbj11CrCreateData.GROUPCDFLG);
                sql.append("    ," + Tbj11CrCreateData.STKYKNOFLG);
                sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDFLG);
                sql.append("    ," + Tbj11CrCreateData.EGTYKFLGFLG);
                sql.append("    ," + Tbj11CrCreateData.CPTNTNMFLG);
                sql.append("    ," + Tbj11CrCreateData.NOTEFLG);
                //内部処理用項目
                sql.append("    ," + Tbj11CrCreateData.CRDATE);
                sql.append("    ," + Tbj11CrCreateData.CLASSDIV);
                sql.append("    ," + Tbj11CrCreateData.DCARCD);
                sql.append("    ," + Tbj11CrCreateData.CLASSCD);
                sql.append("    ," + Tbj11CrCreateData.EXPCD);
                sql.append("    ," + Tbj11CrCreateData.DIVCD);
                sql.append("    ," + Mbj11CarSec.AUTHORITY);
                //ソート用
                sql.append("    ," + Tbj11CrCreateData.SORTNO + " ");

                sql.append(" FROM ");
                sql.append("     " + Tbj11CrCreateData.TBNAME);
                sql.append("    ," + Mbj05Car.TBNAME);
                sql.append("    ," + Mbj11CarSec.TBNAME);
                //sql.append("    ," + Mbj15CrClass.TBNAME);
                sql.append("    ," + Mbj16CrExpence.TBNAME);
                sql.append("    ," + Mbj17CrDivision.TBNAME);
                sql.append("    ," + Mbj26BillGroup.TBNAME);
                sql.append("    ," + Mbj29SetteiKyk.TBNAME);
                sql.append("    ," + Mbj30InputTnt.TBNAME);

                sql.append(" WHERE ");
                sql.append("     " + Tbj11CrCreateData.PHASE  + "  = " + ConvertToDBString(_cond.getPhase()));
                if (_cond.getFromDate() != null) {
                    sql.append(" AND " + Tbj11CrCreateData.CRDATE + " >= " + ConvertToDBString(_cond.getFromDate()));
                }
                if (_cond.getToDate() != null) {
                    sql.append(" AND " + Tbj11CrCreateData.CRDATE + " <= " + ConvertToDBString(_cond.getToDate()));
                }
                if (_cond.getCarList() != null && _cond.getCarList().size() > 0) {
                    sql.append(" AND " + Tbj11CrCreateData.DCARCD + " IN ('" + StringUtil.join("','", _cond.getCarList().toArray(new String[0])) + "')");
                }
                sql.append(" AND " + Tbj11CrCreateData.CLASSDIV + "  = '1'");
                sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");

                if (!StringUtil.isBlank(_cond.getExp())) {
                    //sql.append(" AND " + Tbj11CrCreateData.EXPCD + "  = " + ConvertToDBString(_cond.getExp()));
                    sql.append(" AND " + Mbj16CrExpence.EXPNM + "  = " + ConvertToDBString(_cond.getExp()));
                }

                //結合条件(車種マスタ)
                sql.append(" AND " + Mbj05Car.DCARCD         + "(+)  = " + Tbj11CrCreateData.DCARCD);
                //結合条件(車種権限マスタ)
                sql.append(" AND " + Mbj11CarSec.SECTYPE     + "     = '1'");
                sql.append(" AND " + Mbj11CarSec.HAMID       + "(+)  = " + ConvertToDBString(_cond.getHamid()));
                sql.append(" AND " + Mbj11CarSec.DCARCD      + "(+)  = " + Tbj11CrCreateData.DCARCD);
                //結合条件(予算費目マスタ)
                sql.append(" AND " + Mbj16CrExpence.EXPCD    + "(+) = " + Tbj11CrCreateData.EXPCD);
                sql.append(" AND " + Mbj16CrExpence.CLASSDIV + "(+) = " + Tbj11CrCreateData.CLASSDIV);
                sql.append(" AND " + Mbj16CrExpence.DATEFROM + "(+) <= " + Tbj11CrCreateData.CRDATE);
                sql.append(" AND " + Mbj16CrExpence.DATETO   + "(+) >= " + Tbj11CrCreateData.CRDATE);
                //結合条件(区分マスタ)
                sql.append(" AND " + Mbj17CrDivision.DIVCD   + "(+)  = " + Tbj11CrCreateData.DIVCD);
                //結合条件(請求グループマスタ)
                sql.append(" AND " + Mbj26BillGroup.GROUPCD  + "(+)  = " + Tbj11CrCreateData.GROUPCD);
                //結合条件(設定局マスタ)
                sql.append(" AND " + Mbj29SetteiKyk.PHASE    + "(+)  = " + Tbj11CrCreateData.PHASE);
                sql.append(" AND " + Mbj29SetteiKyk.STKYKNO  + "(+)  = " + Tbj11CrCreateData.STKYKNO);
                //結合条件(入力担当マスタ)
                sql.append(" AND " + Mbj30InputTnt.PHASE     + "(+)  = " + Tbj11CrCreateData.PHASE);
                sql.append(" AND " + Mbj30InputTnt.CLASSDIV  + "(+)  = " + Tbj11CrCreateData.CLASSDIV);
                sql.append(" AND " + Mbj30InputTnt.SEQNO     + "(+)  = " + Tbj11CrCreateData.INPUTTNTCD);
                sql.append(" AND " + Mbj30InputTnt.DCARCD    + "(+)  = " + Tbj11CrCreateData.DCARCD);
                if (_cond.getInputTntList() != null && _cond.getInputTntList().size() > 0 && _cond.getInputTntNullFlg()) {
                    sql.append(" AND (");
                    sql.append(Mbj30InputTnt.INPUTTNT + " IN ('" + StringUtil.join("','", _cond.getInputTntList().toArray(new String[0])) + "')");
                    sql.append(" OR ");
                    sql.append(Tbj11CrCreateData.INPUTTNTCD + " IS NULL ");
                    sql.append(" )");
                } else if (_cond.getInputTntList() != null && _cond.getInputTntList().size() > 0 && !_cond.getInputTntNullFlg()) {
                    sql.append(" AND " + Mbj30InputTnt.INPUTTNT + " IN ('" + StringUtil.join("','", _cond.getInputTntList().toArray(new String[0])) + "')");
                    //sql.append(" AND " + Mbj30InputTnt.INPUTTNT + " IS NOT NULL ");
                } else if (!_cond.getInputTntNullFlg()) {
                    sql.append(" AND " + Tbj11CrCreateData.INPUTTNTCD + " IS NOT NULL ");
                }
            }

            sql.append(" ORDER BY ");
            sql.append("     " + Tbj11CrCreateData.CRDATE + " ");
            sql.append("    ," + Tbj11CrCreateData.DCARCD + " ");
            sql.append("    ," + Tbj11CrCreateData.SORTNO + " ");
        }

        return sql.toString();
    };

    /**
     * 画面で指定した条件で検索を行い、制作原価表／制作費表のヘッダに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepDataForCostMngHeaderVO> findRepDataForCostMngHeader(GetRepDataForCostMngCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new RepDataForCostMngHeaderVO());
        try {
            _SelSqlMode = SelSqlMode.HEADER;
            _cond = cond;
            return (List<RepDataForCostMngHeaderVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 画面で指定した条件で検索を行い、制作原価表／制作費表の明細に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepDataForCostMngDetailsVO> findRepDataForCostMngDetails(GetRepDataForCostMngCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new RepDataForCostMngDetailsVO());
        try {
            _SelSqlMode = SelSqlMode.DETAILS;
            _cond = cond;
            return (List<RepDataForCostMngDetailsVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
