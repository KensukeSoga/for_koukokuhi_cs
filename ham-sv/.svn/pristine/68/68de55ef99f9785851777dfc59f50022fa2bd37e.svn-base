package jp.co.isid.ham.production.model;

import java.util.List;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataDAO;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataDAOFactory;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.common.model.Tbj27LogCrCreateDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.tbl.Tbj27LogCrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class CostManagementDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindCrCreateDataCondition _condSelectCrCreateData = null;
    /** 検索条件(更新履歴) */
    private FindLogCrCreateDataCondition _condLogCrCreateData = null;
    /** 検索条件(変更内容通知) */
    private FindChangeNoticeCondition _condChangeNotice = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LIST, HISTORY, MAXTIME, CN,
    };

    private SelSqlMode _SelSqlMode = null;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode {
        INSHISTORY, DELHISTORY, UPDSORT,
    };

    private ExecSqlMode _ExecSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public CostManagementDAO() {
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

        String sql = "";

        if (_SelSqlMode.equals(SelSqlMode.LIST)) {
            sql = getSelectSQLForLIST();
        } else if (_SelSqlMode.equals(SelSqlMode.HISTORY)) {
            sql = getSelectSQLForHISTORY();
        } else if (_SelSqlMode.equals(SelSqlMode.MAXTIME)) {
            sql = getSelectSQLForMAXTIME();
        } else if (_SelSqlMode.equals(SelSqlMode.CN)) {
            sql = getSelectSQLForCN();
        }

        return sql;
    };

    /**
     * 検索実行時に一覧に表示するデータを取得するSQL
     * @return
     */
    private String getSelectSQLForLIST() {
        StringBuffer sql = new StringBuffer();

        //*******************************************
        //selectListDataで実行されるSQL
        //*******************************************
        //SELECT句===============================================================================
        sql.append(" SELECT ");
        //↓列定義の変更に対応する為Tbj11CrCreateDataDAOのgetTableColumnNamesを使用テーブルがFIX次第Tbj11CrCreateDataDAOの使用はやめる予定
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        for (int i = 0; i < crCreateDataDao.getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append("" + crCreateDataDao.getTableColumnNames()[i] +" ");
        }
        //FROM句===============================================================================
        sql.append(" FROM ");
        sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj11CarSec.TBNAME + " ");
        //WHERE句===============================================================================
        String where = generateWhereForList();
        if (StringUtil.isBlank(where)) {
            sql.append(" WHERE ");
        } else {
            sql.append(where);
            sql.append(" AND ");
        }
        sql.append("     " + Mbj11CarSec.SECTYPE + " = '1' ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.HAMID + " = " + ConvertToDBString(_condSelectCrCreateData.getHamid()) + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.AUTHORITY + " IN ('1', '2') ");//参照、または更新の権限がある車種のデータのみ取得
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.DCARCD + " = " + Tbj11CrCreateData.DCARCD + " ");
        //ORDER句===============================================================================
        sql.append(" ORDER BY ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + " ");
        sql.append("    ," + Tbj11CrCreateData.PHASE + " ");
        sql.append("    ," + Tbj11CrCreateData.CRDATE + " ");
        sql.append("    ," + Tbj11CrCreateData.SORTNO + " ");

        return sql.toString();
    }

    /**
     * 検索実行時に一覧に表示するデータの最大更新日時を取得するSQL
     * ※取得した更新日時は主に排他チェックで使用する
     * @return
     */
    private String getSelectSQLForMAXTIME() {
        StringBuffer sql = new StringBuffer();

        //*******************************************
        //findMaxTimeStampで使用されるSQL
        //*******************************************
        sql.append(" SELECT ");
        sql.append("     NVL(MAX(" + Tbj11CrCreateData.UPDDATE + "), SYSDATE) AS " + Tbj11CrCreateData.UPDDATE + " ");
        //FROM句===============================================================================
        sql.append(" FROM ");
        sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj11CarSec.TBNAME + " ");
        //WHERE句===============================================================================
        String where = generateWhereForList();
        if (StringUtil.isBlank(where)) {
            sql.append(" WHERE ");
        } else {
            sql.append(where);
            sql.append(" AND ");
        }
        sql.append("     " + Mbj11CarSec.SECTYPE + " = '1' ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.HAMID + " = " + ConvertToDBString(_condSelectCrCreateData.getHamid()) + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.AUTHORITY + " IN ('1', '2') ");//参照、または更新の権限がある車種のデータのみ取得
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.DCARCD + " = " + Tbj11CrCreateData.DCARCD + " ");

        return sql.toString();
    }

    /**
     * getSelectSQLForLIST()、getSelectSQLForMAXTIME()のWHERE句を生成する(条件が同じになる必要があるSQLなのでまとめる)
     * @return
     */
    private String generateWhereForList() {
        StringBuffer sql = new StringBuffer();

        sql.append(" WHERE ");
        //検索条件(車種)
        if (!StringUtil.isBlank(_condSelectCrCreateData.getDCarCd())) {
            sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + ConvertToDBString(_condSelectCrCreateData.getDCarCd()));
            sql.append(" AND ");
        }
        //検索条件(フェイズ)
        sql.append("     " + Tbj11CrCreateData.PHASE + " = " + ConvertToDBString(_condSelectCrCreateData.getPhase()));
        //検索条件(年月)
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.CRDATE + " = " + ConvertToDBString(_condSelectCrCreateData.getCrDate()));
        //検索条件(入力担当者)
        if (!StringUtil.isBlank(_condSelectCrCreateData.getInputTntCd())) {
            sql.append(" AND ");
            sql.append("     " + Tbj11CrCreateData.INPUTTNTCD + " IN (");
            sql.append("     SELECT ");
            sql.append("         " + Mbj30InputTnt.SEQNO + " ");
            sql.append("     FROM ");
            sql.append("         " + Mbj30InputTnt.TBNAME + " ");
            sql.append("     WHERE ");
            sql.append("         " + Mbj30InputTnt.INPUTTNT + " = "
                    + ConvertToDBString(_condSelectCrCreateData.getInputTntCd()));
            sql.append(") ");
        }
        //検索条件(納品日From)
        if (!StringUtil.isBlank(_condSelectCrCreateData.getDeliverDayFrom())) {
            sql.append(" AND ");
            sql.append("     " + Tbj11CrCreateData.DELIVERDAY + " >= "
                    + ConvertToDBString(DateUtil.toDate(_condSelectCrCreateData.getDeliverDayFrom())));
        }
        //検索条件(納品日To)
        if (!StringUtil.isBlank(_condSelectCrCreateData.getDeliverDayTo())) {
            sql.append(" AND ");
            sql.append("     " + Tbj11CrCreateData.DELIVERDAY + " <= "
                    + ConvertToDBString(DateUtil.toDate(_condSelectCrCreateData.getDeliverDayTo())));
        }
        //検索条件(受注No未入力)
        if (_condSelectCrCreateData.getInputOrderFlg()) {
            sql.append(" AND ");
            sql.append("     NVL(" + Tbj11CrCreateData.ORDERNO + ", ' ') = ' ' ");
        }
        //検索条件(中止)
        if (!_condSelectCrCreateData.getStpFlg()) {
            sql.append(" AND ");
            sql.append("     " + Tbj11CrCreateData.STPKBN + " = '0' ");
        }
        //検索条件(未確認)
        if (_condSelectCrCreateData.getUnConfFlg()) {
            //アラート表示制御マスタ存在
            sql.append(" AND ");
            sql.append("EXISTS(");

            sql.append(" SELECT ");
            sql.append(" * ");
            sql.append(" FROM ");
            sql.append(Mbj41AlertDispControl.TBNAME);
            sql.append(" WHERE ");
            sql.append(Mbj41AlertDispControl.DISPTYPE);
            sql.append(" = ");
            sql.append("'01'");
            sql.append(" AND ");
            sql.append(Mbj41AlertDispControl.SIKOGNZUNTCD);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condSelectCrCreateData.getSikCd());
            sql.append("'");
            sql.append(" AND ");
            sql.append("(");
            sql.append(Mbj41AlertDispControl.DCARCD);
            sql.append(" IN (");
            sql.append(" SELECT ");
            sql.append(Mbj12Code.KEYCODE);
            sql.append(" FROM ");
            sql.append(Mbj12Code.TBNAME);
            sql.append(" WHERE ");
            sql.append(Mbj12Code.CODETYPE);
            sql.append(" = ");
            sql.append("'25'");
            sql.append(" )");
            sql.append(" OR ");
            sql.append(Mbj41AlertDispControl.DCARCD);
            sql.append(" = ");
            sql.append(Tbj11CrCreateData.DCARCD);
            sql.append(")");

            //確認有無判断
            sql.append(" AND (");
            appendCondition(sql, Tbj11CrCreateData.CLASSCDCONFFLG, Tbj11CrCreateData.CLASSCDCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.EXPCDCONFFLG, Tbj11CrCreateData.EXPCDCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.EXPENSECONFFLG, Tbj11CrCreateData.EXPENSECONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.DETAILCONFFLG, Tbj11CrCreateData.DETAILCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.KIKANSCONFFLG, Tbj11CrCreateData.KIKANSCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.KIKANECONFFLG, Tbj11CrCreateData.KIKANECONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.CONTRACTDATECONFFLG, Tbj11CrCreateData.CONTRACTDATECONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.CONTRACTTERMCONFFLG, Tbj11CrCreateData.CONTRACTTERMCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.SEIKYUCONFFLG, Tbj11CrCreateData.SEIKYUCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.ORDERNOCONFFLG, Tbj11CrCreateData.ORDERNOCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.PAYCONFFLG, Tbj11CrCreateData.PAYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.USERNAMECONFFLG, Tbj11CrCreateData.USERNAMECONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.GETMONEYCONFFLG, Tbj11CrCreateData.GETMONEYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.GETCONFCONFFLG, Tbj11CrCreateData.GETCONFCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.PAYMONEYCONFFLG, Tbj11CrCreateData.PAYMONEYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.PAYCONFCONFFLG, Tbj11CrCreateData.PAYCONFCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.ESTMONEYCONFFLG, Tbj11CrCreateData.ESTMONEYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.CLMMONEYCONFFLG, Tbj11CrCreateData.CLMMONEYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.DELIVERDAYCONFFLG, Tbj11CrCreateData.DELIVERDAYCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.SETMONTHCONFFLG, Tbj11CrCreateData.SETMONTHCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.DIVISIONCONFFLG, Tbj11CrCreateData.DIVISIONCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.GROUPCDCONFFLG, Tbj11CrCreateData.GROUPCDCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.STKYKNOCONFFLG, Tbj11CrCreateData.STKYKNOCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.STTNTNMCONFFLG, Tbj11CrCreateData.STTNTNMCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.EGTYKCONFFLG, Tbj11CrCreateData.EGTYKCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.INPUTTNTCDCONFFLG, Tbj11CrCreateData.INPUTTNTCDCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.CPTNTNMCONFFLG, Tbj11CrCreateData.CPTNTNMCONFHAMID);
            sql.append(" OR ");
            appendCondition(sql, Tbj11CrCreateData.NOTECONFFLG, Tbj11CrCreateData.NOTECONFHAMID);
            sql.append(" ) ");

            sql.append(")");
        }

        return sql.toString();
    }

    /**
     * 条件式の追加
     * @param sql
     * @param confflg 確認フラグのカラム名
     * @param sikcd   確認担当者のカラム名
     */
    private void appendCondition(StringBuffer sql, String confflg, String hamid) {

        sql.append("(");
        sql.append(Mbj41AlertDispControl.HAMID);
        sql.append(" = ");
        sql.append(hamid);
        sql.append(" AND ");
        sql.append(confflg);
        sql.append(" IN ('0', '2') ");
        sql.append(")");
    }

    /**
     * 更新履歴画面の一覧に表示するデータを取得するSQL
     * @return
     */
    private String getSelectSQLForHISTORY() {
        StringBuffer sql = new StringBuffer();

        //SELECT句===============================================================================
        sql.append(" SELECT ");
        sql.append("     " + Tbj27LogCrCreateData.DCARCD + " ");
        sql.append("    ," + Tbj27LogCrCreateData.PHASE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CRDATE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.SEQUENCENO + " ");
        sql.append("    ," + Tbj27LogCrCreateData.HISTORYNO + " ");
        sql.append("    ,CODE_HISTORYNM." + Mbj12Code.CODENAME + " AS HISTORYNM ");
        sql.append("    ," + Mbj05Car.CARNM + " ");
        sql.append("    ," + Mbj15CrClass.CLASSNM + " ");
        sql.append("    ," + Mbj16CrExpence.EXPNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.DETAIL + " ");
        sql.append("    ," + Tbj27LogCrCreateData.KIKANS + " ");
        sql.append("    ," + Tbj27LogCrCreateData.KIKANE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYU + " ");
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNO + " ");
        sql.append("    ," + Tbj27LogCrCreateData.PAY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.USERNAME + " ");
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.GETCONF + " ");
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONF + " ");
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTH + " ");
        sql.append("    ," + Mbj17CrDivision.DIVNM + " ");
        sql.append("    ," + Mbj26BillGroup.GROUPNM + " ");
        sql.append("    ," + Mbj29SetteiKyk.STKYKNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKFLG + " ");
        sql.append("    ," + Mbj30InputTnt.INPUTTNT + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.NOTE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CRTNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CRTDATE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.UPDNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.UPDDATE + " ");
        sql.append("    ,CODE_RSTATUSNM." + Mbj12Code.CODENAME + " AS RSTATUSNM ");

        //FROM句===============================================================================
        sql.append(" FROM ");
        sql.append("     " + Tbj27LogCrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj05Car.TBNAME + " ");
        sql.append("    ," + Mbj11CarSec.TBNAME + " ");
        sql.append("    ," + Mbj15CrClass.TBNAME + " ");
        sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
        sql.append("    ," + Mbj17CrDivision.TBNAME + " ");
        sql.append("    ," + Mbj26BillGroup.TBNAME + " ");
        sql.append("    ," + Mbj29SetteiKyk.TBNAME + " ");
        sql.append("    ," + Mbj30InputTnt.TBNAME + " ");
        sql.append("    ," + Mbj12Code.TBNAME + " CODE_HISTORYNM ");
        sql.append("    ," + Mbj12Code.TBNAME + " CODE_RSTATUSNM ");

        //WHERE句===============================================================================
        sql.append(" WHERE ");
        //条件は制作費管理Noだけ(これだけで一意になる ＆ 他のPKを条件に加えるとデータ移動に対応できないので)
        sql.append("     " + Tbj27LogCrCreateData.SEQUENCENO + " = " + ConvertToDBString(_condLogCrCreateData.getSequenceno()));
        sql.append(" AND ");
        sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj27LogCrCreateData.DCARCD);
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.SECTYPE + " = '1' ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.HAMID + " = " + ConvertToDBString(_condLogCrCreateData.getHamid()) + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.DCARCD + " = " + Tbj27LogCrCreateData.DCARCD + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.AUTHORITY + " IN ('1', '2') ");//参照、または更新の権限がある車種のデータのみ取得
        sql.append(" AND ");
        sql.append("     " + Mbj15CrClass.CLASSCD + "(+) = " + Tbj27LogCrCreateData.CLASSCD);
        sql.append(" AND ");
        sql.append("     " + Mbj15CrClass.DATEFROM + "(+) <= " + Tbj27LogCrCreateData.CRDATE);
        sql.append(" AND ");
        sql.append("     " + Mbj15CrClass.DATETO + "(+) >= " + Tbj27LogCrCreateData.CRDATE);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.EXPCD + "(+) = " + Tbj27LogCrCreateData.EXPCD);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.CLASSDIV + "(+) = " + Tbj27LogCrCreateData.CLASSDIV);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.DATEFROM + "(+) <= " + Tbj27LogCrCreateData.CRDATE);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.DATETO + "(+) >= " + Tbj27LogCrCreateData.CRDATE);
        sql.append(" AND ");
        sql.append("     " + Mbj17CrDivision.DIVCD + "(+) = " + Tbj27LogCrCreateData.DIVCD);
        sql.append(" AND ");
        sql.append("     " + Mbj26BillGroup.GROUPCD + "(+) = " + Tbj27LogCrCreateData.GROUPCD);
        sql.append(" AND ");
        sql.append("     " + Mbj29SetteiKyk.PHASE + "(+) = " + Tbj27LogCrCreateData.PHASE);
        sql.append(" AND ");
        sql.append("     " + Mbj29SetteiKyk.STKYKNO + "(+) = " + Tbj27LogCrCreateData.STKYKNO);
        sql.append(" AND ");
        sql.append("     " + Mbj30InputTnt.PHASE + "(+) = " + Tbj27LogCrCreateData.PHASE);
        sql.append(" AND ");
        sql.append("     " + Mbj30InputTnt.CLASSDIV + "(+) = " + Tbj27LogCrCreateData.CLASSDIV);
        sql.append(" AND ");
        sql.append("     " + Mbj30InputTnt.SEQNO + "(+) = " + Tbj27LogCrCreateData.INPUTTNTCD);
        sql.append(" AND ");
        sql.append("     CODE_HISTORYNM." + Mbj12Code.CODETYPE + "(+) = '33'");
        sql.append(" AND ");
        sql.append("     CODE_HISTORYNM." + Mbj12Code.KEYCODE + "(+) = " + Tbj27LogCrCreateData.HISTORYKBN);
        sql.append(" AND ");
        sql.append("     CODE_RSTATUSNM." + Mbj12Code.CODETYPE + "(+) = '34'");
        sql.append(" AND ");
        sql.append("     CODE_RSTATUSNM." + Mbj12Code.KEYCODE + "(+) = " + Tbj27LogCrCreateData.RSTATUS);

        //ORDER句===============================================================================
        sql.append(" ORDER BY ");
        sql.append("     " + Tbj27LogCrCreateData.HISTORYNO + " ");

        return sql.toString();
    }

    /**
     * 変更内容通知データの取得SQL
     * @return
     */
    private String getSelectSQLForCN() {
        StringBuffer sql = new StringBuffer();

        //SELECT句===============================================================================
        sql.append(" SELECT ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + " AS " + Tbj27LogCrCreateData.DCARCD);
        sql.append("    ," + Tbj11CrCreateData.PHASE + " AS " + Tbj27LogCrCreateData.PHASE);
        sql.append("    ," + Tbj11CrCreateData.CRDATE + " AS " + Tbj27LogCrCreateData.CRDATE);
        sql.append("    ," + Tbj11CrCreateData.SEQUENCENO + " AS " + Tbj27LogCrCreateData.SEQUENCENO);
        sql.append("    ," + Tbj27LogCrCreateData.HISTORYNO + " ");

        sql.append("    ," + Mbj05Car.CARNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.EXPCD + " ");
        sql.append("    ," + Mbj16CrExpence.EXPNM + " ");
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSE + " ");
        sql.append("    ," + Tbj27LogCrCreateData.PAY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEY + " ");
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAY + " ");

        sql.append("    ," + Tbj11CrCreateData.CLASSDIV + " AS " + Tbj27LogCrCreateData.CLASSDIV + " ");
        sql.append("    ," + Tbj27LogCrCreateData.STPKBN + " ");
        sql.append("    ," + Tbj27LogCrCreateData.STTNTID + " ");
        sql.append("    ," + Tbj27LogCrCreateData.UPDDATE + " ");
        sql.append("    ," + Mbj29SetteiKyk.MAILFLG + " ");
        //FROM句===============================================================================
        sql.append(" FROM ");

        sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
        sql.append("    ," + Tbj27LogCrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj05Car.TBNAME + " ");
        sql.append("    ," + Mbj11CarSec.TBNAME + " ");
        sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
        sql.append("    ," + Mbj29SetteiKyk.TBNAME + " ");
        //WHERE句===============================================================================
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.SEQUENCENO + " = " + Tbj27LogCrCreateData.SEQUENCENO);

        if (!StringUtil.isBlank(_condChangeNotice.getDCarCd())) {
            sql.append(" AND " + Tbj11CrCreateData.DCARCD + " = " + ConvertToDBString(_condChangeNotice.getDCarCd()));
        }
        if (_condChangeNotice.getPhase() != null) {
            sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + ConvertToDBString(_condChangeNotice.getPhase()));
        }
        if (!StringUtil.isBlank(_condChangeNotice.getUpdMonth())) {
            sql.append(" AND EXISTS(");
            sql.append("     SELECT ");
            sql.append("         ").append(Tbj27LogCrCreateData.SEQUENCENO);
            sql.append("     FROM ");
            sql.append("         " + Tbj27LogCrCreateData.TBNAME + " B ");
            sql.append("     WHERE ");
            sql.append("         B." + Tbj27LogCrCreateData.DCARCD + " = " + Tbj27LogCrCreateData.TBNAME + "." + Tbj27LogCrCreateData.DCARCD);
            sql.append("     AND B." + Tbj27LogCrCreateData.PHASE + " = " + Tbj27LogCrCreateData.TBNAME + "." + Tbj27LogCrCreateData.PHASE);
            sql.append("     AND B." + Tbj27LogCrCreateData.CRDATE + " = " + Tbj27LogCrCreateData.TBNAME + "." + Tbj27LogCrCreateData.CRDATE );
            sql.append("     AND B." + Tbj27LogCrCreateData.SEQUENCENO + " = " + Tbj27LogCrCreateData.TBNAME + "." + Tbj27LogCrCreateData.SEQUENCENO);
            sql.append("     AND B." + Tbj27LogCrCreateData.HISTORYNO + " = " + Tbj27LogCrCreateData.TBNAME + "." + Tbj27LogCrCreateData.HISTORYNO);
            sql.append("     AND TO_CHAR(B." + Tbj27LogCrCreateData.UPDDATE + ", 'YYYYMM') = " + ConvertToDBString(_condChangeNotice.getUpdMonth()));
            sql.append(" )");
        }
        if (_condChangeNotice.getSequencenoList() != null && _condChangeNotice.getSequencenoList().size() > 0) {
            sql.append(" AND " + Tbj11CrCreateData.SEQUENCENO + " IN( ");
            for (int i = 0; i < _condChangeNotice.getSequencenoList().size(); i++) {
                if (i > 0) {
                    sql.append(", ");
                }
                sql.append(ConvertToDBString(_condChangeNotice.getSequencenoList().get(i)));
            }
            sql.append(" ) ");
        }

        //取得する履歴は「登録・更新・中止・データ移動・データコピー」
        sql.append(" AND " + Tbj27LogCrCreateData.HISTORYKBN + " IN (");
        sql.append(" '").append(HAMConstants.HISTORYKBN_REGSTER).append("'");
        sql.append(",'").append(HAMConstants.HISTORYKBN_UPDATE).append("'");
        sql.append(",'").append(HAMConstants.HISTORYKBN_STOP).append("'");
        sql.append(",'").append(HAMConstants.HISTORYKBN_DATAMOVE).append("'");
        sql.append(",'").append(HAMConstants.HISTORYKBN_DATACOPY).append("'");
        sql.append(")");

        sql.append(" AND ");
        sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj11CrCreateData.DCARCD);

        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.SECTYPE + " = '1' ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.HAMID + " = " + ConvertToDBString(_condChangeNotice.getHamid()) + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.DCARCD + " = " + Tbj11CrCreateData.DCARCD + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj11CarSec.AUTHORITY + " IN ('1', '2') ");//参照、または更新の権限がある車種のデータのみ取得

        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.EXPCD + "(+) = " + Tbj27LogCrCreateData.EXPCD);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.CLASSDIV + "(+) = " + Tbj27LogCrCreateData.CLASSDIV);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.DATEFROM + "(+) <= " + Tbj27LogCrCreateData.CRDATE);
        sql.append(" AND ");
        sql.append("     " + Mbj16CrExpence.DATETO + "(+) >= " + Tbj27LogCrCreateData.CRDATE);

        sql.append(" AND ");
        sql.append("     " + Mbj29SetteiKyk.PHASE + "(+) = " + Tbj11CrCreateData.PHASE + " ");
        sql.append(" AND ");
        sql.append("     " + Mbj29SetteiKyk.STKYKNO + "(+) = " + Tbj11CrCreateData.STKYKNO + " ");
        //ORDER句===============================================================================
        sql.append(" ORDER BY ");
        sql.append("     " + Mbj05Car.TBNAME + "." + Mbj05Car.SORTNO + " ");
        sql.append("    ," + Mbj05Car.TBNAME + "." + Mbj05Car.DCARCD + " ");
        sql.append("    ," + Tbj11CrCreateData.SEQUENCENO + " ");
        sql.append("    ," + Tbj27LogCrCreateData.HISTORYNO + " ");

        return sql.toString();
    }

    /**
     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> selectListData(FindCrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.LIST;
            _condSelectCrCreateData = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 更新履歴画面に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindLogCrCreateDataVO> findLogCrCreateData(FindLogCrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindLogCrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.HISTORY;
            _condLogCrCreateData = cond;
            return (List<FindLogCrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * TIMESTAMP項目の現在の最大値を取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxTimeStamp(FindCrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
            _condSelectCrCreateData = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 変更通知用のデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindChangeNoticeVO> findChangeNoticeData(FindChangeNoticeCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindChangeNoticeVO());
        try {
            _SelSqlMode = SelSqlMode.CN;
            _condChangeNotice = cond;
            return (List<FindChangeNoticeVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    ///**
    //* Modelの生成を行う<br>
    //* 検索結果のVOのKEYが大文字のため変換処理を行う<br>
    //* AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
    //*
    //* @param hashList List 検索結果
    //* @return List<CommonCodeMasterVO> 変換後の検索結果
    //*/
    //@Override
    //@SuppressWarnings("unchecked")
    //protected List createFindedModelInstances(List hashList) {
    //List list = null;
    //if (getModel() instanceof MaterialRegisterCntrctVO) {
    //list = new ArrayList<MaterialRegisterCntrctVO>();
    //for (int i = 0; i < hashList.size(); i++) {
    //Map result = (Map) hashList.get(i);
    //MaterialRegisterCntrctVO vo = new MaterialRegisterCntrctVO();
    //vo.setCMCD((String)result.get(Tbj17Content.CMCD.toUpperCase()));
    //vo.setCTRTKBN((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase()));
    //vo.setCTRTNO((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase()));
    //vo.setNAMES((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase()));
    //vo.setDATEFROM(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
    //vo.setDATETO(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
    //vo.setMUSIC((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase()));
    //vo.setSALEFLG((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase()));
    //vo.setCRTDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
    //vo.setUPDDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
    //vo.setUPDNM((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase()));
    //vo.setUPDAPL((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase()));
    //vo.setUPDID((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase()));
    //vo.setDCARCD((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase()));
    //vo.setCATEGORY((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase()));
    //vo.setJASRACFLG((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase()));
    //
    //// 検索結果直後の状態にする
    //ModelUtils.copyMemberSearchAfterInstace(vo);
    //list.add(vo);
    //}
    //}
    //return list;
    //}

    //============================================================================================================================

    @Override
    public String getExecString() {
        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.INSHISTORY)) {
            sql = getExecStringForINSHISTORY();
        } else if (_ExecSqlMode.equals(ExecSqlMode.DELHISTORY)) {
            sql = getExecStringForDELHISTORY();
        } else if (_ExecSqlMode.equals(ExecSqlMode.UPDSORT)) {
            sql = getExecStringForUPDSORT();
        }

        return sql.toString();
    }

    /**
     * 更新履歴登録SQLを取得する
     * @return
     */
    private String getExecStringForINSHISTORY() {
        StringBuffer sql = new StringBuffer();

        Tbj27LogCrCreateDataVO vo = (Tbj27LogCrCreateDataVO) getModel();

        sql.append(" INSERT INTO ");
        sql.append("    " + Tbj27LogCrCreateData.TBNAME + " ");
        sql.append(" ( ");
        sql.append("     " + Tbj27LogCrCreateData.DCARCD);
        sql.append("    ," + Tbj27LogCrCreateData.PHASE);
        sql.append("    ," + Tbj27LogCrCreateData.CRDATE);
        sql.append("    ," + Tbj27LogCrCreateData.SEQUENCENO);
        sql.append("    ," + Tbj27LogCrCreateData.HISTORYNO);
        sql.append("    ," + Tbj27LogCrCreateData.HISTORYKBN);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSDIV);
        sql.append("    ," + Tbj27LogCrCreateData.SORTNO);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSCD);
        sql.append("    ," + Tbj27LogCrCreateData.EXPCD);
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSE);
        sql.append("    ," + Tbj27LogCrCreateData.DETAIL);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANS);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANE);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTDATE);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERM);
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYU);
        sql.append("    ," + Tbj27LogCrCreateData.TRTHSKGYCD);
        sql.append("    ," + Tbj27LogCrCreateData.TRSEQNO);
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNO);
        sql.append("    ," + Tbj27LogCrCreateData.PAY);
        sql.append("    ," + Tbj27LogCrCreateData.HRTHSKGYCD);
        sql.append("    ," + Tbj27LogCrCreateData.HRSEQNO);
        sql.append("    ," + Tbj27LogCrCreateData.USERNAME);
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEY);
        sql.append("    ," + Tbj27LogCrCreateData.GETCONF);
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEY);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONF);
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEY);
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEY);
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAY);
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTH);
        sql.append("    ," + Tbj27LogCrCreateData.DIVCD);
        sql.append("    ," + Tbj27LogCrCreateData.GROUPCD);
        sql.append("    ," + Tbj27LogCrCreateData.STKYKNO);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTID);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNM);
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKFLG);
        sql.append("    ," + Tbj27LogCrCreateData.INPUTTNTCD);
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNM);
        sql.append("    ," + Tbj27LogCrCreateData.NOTE);
        sql.append("    ," + Tbj27LogCrCreateData.TCKEY);
        sql.append("    ," + Tbj27LogCrCreateData.TRSUBNO);
        sql.append("    ," + Tbj27LogCrCreateData.HRSUBNO);
        sql.append("    ," + Tbj27LogCrCreateData.RSTATUS);
        sql.append("    ," + Tbj27LogCrCreateData.STPKBN);
        sql.append("    ," + Tbj27LogCrCreateData.DCARCDFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSCDFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EXPCDFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSEFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DETAILFLG);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANSFLG);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANEFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTDATEFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERMFLG);
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYUFLG);
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNOFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.USERNAMEFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GETCONFIRMFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFIRMFLG);
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAYFLG);
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTHFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DIVISIONFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GROUPCDFLG);
        sql.append("    ," + Tbj27LogCrCreateData.STKYKNOFLG);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNMFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKFLGFLG);
        sql.append("    ," + Tbj27LogCrCreateData.INPUTTNTCDFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNMFLG);
        sql.append("    ," + Tbj27LogCrCreateData.NOTEFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DCARCDCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DCARCDCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.DCARCDCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSCDCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSCDCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.CLASSCDCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.EXPCDCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EXPCDCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.EXPCDCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSECONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSECONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.EXPENSECONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.DETAILCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DETAILCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.DETAILCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANSCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANSCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANSCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANECONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANECONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.KIKANECONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTDATECONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTDATECONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTDATECONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERMCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERMCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.CONTRACTTERMCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYUCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYUCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.SEIKYUCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNOCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNOCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.ORDERNOCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.USERNAMECONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.USERNAMECONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.USERNAMECONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.GETMONEYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.GETCONFCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GETCONFCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.GETCONFCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.PAYMONEYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.PAYCONFCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.ESTMONEYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.CLMMONEYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAYCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAYCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.DELIVERDAYCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTHCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTHCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.SETMONTHCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.DIVISIONCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.DIVISIONCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.DIVISIONCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.GROUPCDCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.GROUPCDCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.GROUPCDCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.STKYKNOCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.STKYKNOCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.STKYKNOCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNMCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNMCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.STTNTNMCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.EGTYKCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.INPUTTNTCDCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.INPUTTNTCDCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.INPUTTNTCDCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNMCONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNMCONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.CPTNTNMCONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.NOTECONFFLG);
        sql.append("    ," + Tbj27LogCrCreateData.NOTECONFSIKCD);
        sql.append("    ," + Tbj27LogCrCreateData.NOTECONFHAMID);
        sql.append("    ," + Tbj27LogCrCreateData.CRTDATE);
        sql.append("    ," + Tbj27LogCrCreateData.CRTNM);
        sql.append("    ," + Tbj27LogCrCreateData.CRTAPL);
        sql.append("    ," + Tbj27LogCrCreateData.CRTID);
        sql.append("    ," + Tbj27LogCrCreateData.UPDDATE);
        sql.append("    ," + Tbj27LogCrCreateData.UPDNM);
        sql.append("    ," + Tbj27LogCrCreateData.UPDAPL);
        sql.append("    ," + Tbj27LogCrCreateData.UPDID);
        sql.append(" ) ");
        sql.append(" SELECT ");
        sql.append("     " + Tbj11CrCreateData.DCARCD);
        sql.append("    ," + Tbj11CrCreateData.PHASE);
        sql.append("    ," + Tbj11CrCreateData.CRDATE);
        sql.append("    ," + Tbj11CrCreateData.SEQUENCENO);
        sql.append("    ,(");
        sql.append("         SELECT ");
        sql.append("             NVL(MAX(" + Tbj27LogCrCreateData.HISTORYNO + "), 0) + 1");
        sql.append("         FROM ");
        sql.append("             " + Tbj27LogCrCreateData.TBNAME);
        sql.append("         WHERE ");
        sql.append("             " + Tbj27LogCrCreateData.SEQUENCENO + " = " + Tbj11CrCreateData.SEQUENCENO);
        sql.append("     )");
        sql.append("    ," + ConvertToDBString(vo.getHISTORYKBN()) + "");
        sql.append("    ," + Tbj11CrCreateData.CLASSDIV);
        sql.append("    ," + Tbj11CrCreateData.SORTNO);
        sql.append("    ," + Tbj11CrCreateData.CLASSCD);
        sql.append("    ," + Tbj11CrCreateData.EXPCD);
        sql.append("    ," + Tbj11CrCreateData.EXPENSE);
        sql.append("    ," + Tbj11CrCreateData.DETAIL);
        sql.append("    ," + Tbj11CrCreateData.KIKANS);
        sql.append("    ," + Tbj11CrCreateData.KIKANE);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTDATE);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTTERM);
        sql.append("    ," + Tbj11CrCreateData.SEIKYU);
        sql.append("    ," + Tbj11CrCreateData.TRTHSKGYCD);
        sql.append("    ," + Tbj11CrCreateData.TRSEQNO);
        sql.append("    ," + Tbj11CrCreateData.ORDERNO);
        sql.append("    ," + Tbj11CrCreateData.PAY);
        sql.append("    ," + Tbj11CrCreateData.HRTHSKGYCD);
        sql.append("    ," + Tbj11CrCreateData.HRSEQNO);
        sql.append("    ," + Tbj11CrCreateData.USERNAME);
        sql.append("    ," + Tbj11CrCreateData.GETMONEY);
        sql.append("    ," + Tbj11CrCreateData.GETCONF);
        sql.append("    ," + Tbj11CrCreateData.PAYMONEY);
        sql.append("    ," + Tbj11CrCreateData.PAYCONF);
        sql.append("    ," + Tbj11CrCreateData.ESTMONEY);
        sql.append("    ," + Tbj11CrCreateData.CLMMONEY);
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAY);
        sql.append("    ," + Tbj11CrCreateData.SETMONTH);
        sql.append("    ," + Tbj11CrCreateData.DIVCD);
        sql.append("    ," + Tbj11CrCreateData.GROUPCD);
        sql.append("    ," + Tbj11CrCreateData.STKYKNO);
        sql.append("    ," + Tbj11CrCreateData.STTNTID);
        sql.append("    ," + Tbj11CrCreateData.STTNTNM);
        sql.append("    ," + Tbj11CrCreateData.EGTYKFLG);
        sql.append("    ," + Tbj11CrCreateData.INPUTTNTCD);
        sql.append("    ," + Tbj11CrCreateData.CPTNTNM);
        sql.append("    ," + Tbj11CrCreateData.NOTE);
        sql.append("    ," + Tbj11CrCreateData.TCKEY);
        sql.append("    ," + Tbj11CrCreateData.TRSUBNO);
        sql.append("    ," + Tbj11CrCreateData.HRSUBNO);
        sql.append("    ," + Tbj11CrCreateData.RSTATUS);
        sql.append("    ," + Tbj11CrCreateData.STPKBN);
        sql.append("    ," + Tbj11CrCreateData.DCARCDFLG);
        sql.append("    ," + Tbj11CrCreateData.CLASSCDFLG);
        sql.append("    ," + Tbj11CrCreateData.EXPCDFLG);
        sql.append("    ," + Tbj11CrCreateData.EXPENSEFLG);
        sql.append("    ," + Tbj11CrCreateData.DETAILFLG);
        sql.append("    ," + Tbj11CrCreateData.KIKANSFLG);
        sql.append("    ," + Tbj11CrCreateData.KIKANEFLG);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTDATEFLG);
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
        sql.append("    ," + Tbj11CrCreateData.STTNTNMFLG);
        sql.append("    ," + Tbj11CrCreateData.EGTYKFLGFLG);
        sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDFLG);
        sql.append("    ," + Tbj11CrCreateData.CPTNTNMFLG);
        sql.append("    ," + Tbj11CrCreateData.NOTEFLG);
        sql.append("    ," + Tbj11CrCreateData.DCARCDCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.DCARCDCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.DCARCDCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CLASSCDCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.CLASSCDCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.CLASSCDCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.EXPCDCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.EXPCDCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.EXPCDCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.EXPENSECONFFLG);
        sql.append("    ," + Tbj11CrCreateData.EXPENSECONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.EXPENSECONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.DETAILCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.DETAILCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.DETAILCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.KIKANSCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.KIKANSCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.KIKANSCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.KIKANECONFFLG);
        sql.append("    ," + Tbj11CrCreateData.KIKANECONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.KIKANECONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTDATECONFFLG);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTDATECONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTDATECONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTTERMCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTTERMCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.CONTRACTTERMCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.SEIKYUCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.SEIKYUCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.SEIKYUCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.ORDERNOCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.ORDERNOCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.ORDERNOCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.USERNAMECONFFLG);
        sql.append("    ," + Tbj11CrCreateData.USERNAMECONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.USERNAMECONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.GETMONEYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.GETMONEYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.GETMONEYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.GETCONFCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.GETCONFCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.GETCONFCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.PAYMONEYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.PAYMONEYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.PAYMONEYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.PAYCONFCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.ESTMONEYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.ESTMONEYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.ESTMONEYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CLMMONEYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.CLMMONEYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.CLMMONEYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAYCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAYCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAYCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.SETMONTHCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.SETMONTHCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.SETMONTHCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.DIVISIONCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.DIVISIONCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.DIVISIONCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.GROUPCDCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.GROUPCDCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.GROUPCDCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.STKYKNOCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.STKYKNOCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.STKYKNOCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.STTNTNMCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.STTNTNMCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.STTNTNMCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.EGTYKCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.EGTYKCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.EGTYKCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.INPUTTNTCDCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CPTNTNMCONFFLG);
        sql.append("    ," + Tbj11CrCreateData.CPTNTNMCONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.CPTNTNMCONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.NOTECONFFLG);
        sql.append("    ," + Tbj11CrCreateData.NOTECONFSIKCD);
        sql.append("    ," + Tbj11CrCreateData.NOTECONFHAMID);
        sql.append("    ," + Tbj11CrCreateData.CRTDATE);
        sql.append("    ," + Tbj11CrCreateData.CRTNM);
        sql.append("    ," + Tbj11CrCreateData.CRTAPL);
        sql.append("    ," + Tbj11CrCreateData.CRTID);
        sql.append("    ," + Tbj11CrCreateData.UPDDATE);
        sql.append("    ," + Tbj11CrCreateData.UPDNM);
        sql.append("    ," + Tbj11CrCreateData.UPDAPL);
        sql.append("    ," + Tbj11CrCreateData.UPDID);

        sql.append(" FROM ");
        sql.append("     " + Tbj11CrCreateData.TBNAME);
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.SEQUENCENO + " = " + ConvertToDBString(vo.getSEQUENCENO()));

        return sql.toString();
    }

    /**
     * 更新履歴削除SQLを取得する
     * @return
     */
    private String getExecStringForDELHISTORY() {
        StringBuffer sql = new StringBuffer();

        Tbj27LogCrCreateDataVO vo = (Tbj27LogCrCreateDataVO) getModel();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append("     " + Tbj27LogCrCreateData.TBNAME);
        sql.append(" WHERE ");
        sql.append("     " + Tbj27LogCrCreateData.SEQUENCENO + " = " + ConvertToDBString(vo.getSEQUENCENO()));

        return sql.toString();
    }

    /**
     * CR制作費管理.ソートNo更新SQLを取得する
     * @return
     */
    private String getExecStringForUPDSORT() {
        StringBuffer sql = new StringBuffer();

        Tbj11CrCreateDataVO vo = (Tbj11CrCreateDataVO) getModel();

        sql.append(" UPDATE ");
        sql.append("     " + Tbj11CrCreateData.TBNAME);
        sql.append(" SET ");
        sql.append("     " + Tbj11CrCreateData.SORTNO + " = " + ConvertToDBString(vo.getSORTNO()));
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + ConvertToDBString(vo.getDCARCD()));
        sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + ConvertToDBString(vo.getPHASE()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + ConvertToDBString(vo.getCRDATE()));
        sql.append(" AND " + Tbj11CrCreateData.SEQUENCENO + " = " + ConvertToDBString(vo.getSEQUENCENO()));

        return sql.toString();
    }

    /**
     * 更新履歴(CR制作費管理)の登録を行う
     * @param vo
     * @throws HAMException
     */
    public void insertHistoryForCrCreate(Tbj27LogCrCreateDataVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _ExecSqlMode = ExecSqlMode.INSHISTORY;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 更新履歴(CR制作費管理)の登録を行う
     * @param vo
     * @throws HAMException
     */
    public void deleteHistoryForCrCreate(Tbj27LogCrCreateDataVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            _ExecSqlMode = ExecSqlMode.DELHISTORY;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

}
