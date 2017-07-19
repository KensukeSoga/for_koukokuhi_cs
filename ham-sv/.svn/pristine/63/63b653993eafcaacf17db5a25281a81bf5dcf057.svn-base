package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.tbl.Tbj31CrBudgetPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class BudgetDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindBudgetCondition _findBudgetCondition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LIST,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public BudgetDAO() {
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

        if (_SelSqlMode.equals(SelSqlMode.LIST)) {

            //************************************************************
            //[実績(費目が契約系以外)]を取得するSQL
            //　⇒過去ロック以前かつ費目が契約系以外のCR制作費のデータ
            //************************************************************
            sql.append(" SELECT ");
            sql.append("     " + Tbj11CrCreateData.DCARCD                  + " AS " + Tbj11CrCreateData.DCARCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CLASSCD                 + " AS " + Tbj11CrCreateData.CLASSCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CRDATE                  + " AS " + Tbj11CrCreateData.CRDATE + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.KIKANS + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.KIKANE + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.CONTRACTTERM + " ");
            sql.append("    ," + "SUM(" + Tbj11CrCreateData.CLMMONEY + ")" + " AS " + Tbj11CrCreateData.CLMMONEY + " ");
            sql.append("    ," + Tbj11CrCreateData.EXPCD                   + " AS " + Tbj11CrCreateData.EXPCD + " ");
            sql.append("    ," + Mbj16CrExpence.FLG1                       + " AS " + Mbj16CrExpence.FLG1 + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM                      + " AS " + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj05Car.CARNM                            + " AS " + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY                     + " AS " + Mbj11CarSec.AUTHORITY + " ");
            sql.append("    ," + "'0'"                                     + " AS " + "DATAKBN" + " ");
            sql.append(" FROM ");
            sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
            sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
            sql.append("    ," + Mbj15CrClass.TBNAME + " ");
            sql.append("    ," + Mbj05Car.TBNAME + " ");
            sql.append("    ," + Mbj11CarSec.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("     " + Tbj11CrCreateData.PHASE + "  = " + ConvertToDBString(_findBudgetCondition.getPhase()));
            sql.append(" AND " + Tbj11CrCreateData.CLASSDIV + "  = " + ConvertToDBString("0"));
            if (_findBudgetCondition.getLockDate() != null) {
                sql.append(" AND " + Tbj11CrCreateData.CRDATE + " <= " + ConvertToDBString(_findBudgetCondition.getLockDate()));
            }
            if (!StringUtil.isBlank(_findBudgetCondition.getDCarCd())) {
                sql.append(" AND " + Tbj11CrCreateData.DCARCD + "  = " + ConvertToDBString(_findBudgetCondition.getDCarCd()));
            }
            sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");
            sql.append(" AND " + Tbj11CrCreateData.EXPCD    + "  = " + Mbj16CrExpence.EXPCD + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CLASSDIV + "  = " + Mbj16CrExpence.CLASSDIV + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " >= " + Mbj16CrExpence.DATEFROM + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + Mbj16CrExpence.DATETO + "(+)");
            sql.append(" AND " + Mbj16CrExpence.FLG1        + " <> " + "'1'");

            sql.append(" AND " + Tbj11CrCreateData.CLASSCD  + "  = " + Mbj15CrClass.CLASSCD + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " >= " + Mbj15CrClass.DATEFROM + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + Mbj15CrClass.DATETO + "(+)");

            sql.append(" AND " + Tbj11CrCreateData.DCARCD   + "  = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" AND " + Mbj11CarSec.SECTYPE        + "  = " + ConvertToDBString("1"));
            sql.append(" AND " + Mbj11CarSec.AUTHORITY      + " IN ('1', '2')");
            sql.append(" AND " + Mbj11CarSec.HAMID          + "  = " + ConvertToDBString(_findBudgetCondition.getHamid()));
            sql.append(" AND " + Tbj11CrCreateData.DCARCD   + "  = " + Mbj11CarSec.DCARCD + "(+)");
            sql.append(" GROUP BY ");
            sql.append("     " + Tbj11CrCreateData.DCARCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CLASSCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CRDATE + " ");
            sql.append("    ," + Tbj11CrCreateData.EXPCD + " ");
            sql.append("    ," + Mbj16CrExpence.FLG1 + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY + " ");

            sql.append(" UNION ALL ");

            //************************************************************
            //[実績(費目が契約系)]を取得するSQL
            //　⇒費目が契約系のCR制作費のデータ
            //************************************************************
            sql.append(" SELECT ");
            sql.append("     " + Tbj11CrCreateData.DCARCD                  + " AS " + Tbj11CrCreateData.DCARCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CLASSCD                 + " AS " + Tbj11CrCreateData.CLASSCD + " ");
            sql.append("    ," + Tbj11CrCreateData.CRDATE                  + " AS " + Tbj11CrCreateData.CRDATE + " ");
            sql.append("    ," + Tbj11CrCreateData.KIKANS                  + " AS " + Tbj11CrCreateData.KIKANS + " ");
            sql.append("    ," + Tbj11CrCreateData.KIKANE                  + " AS " + Tbj11CrCreateData.KIKANE + " ");
            sql.append("    ," + Tbj11CrCreateData.CONTRACTTERM            + " AS " + Tbj11CrCreateData.CONTRACTTERM + " ");
            sql.append("    ," + Tbj11CrCreateData.CLMMONEY                + " AS " + Tbj11CrCreateData.CLMMONEY + " ");
            sql.append("    ," + Tbj11CrCreateData.EXPCD                   + " AS " + Tbj11CrCreateData.EXPCD + " ");
            sql.append("    ," + Mbj16CrExpence.FLG1                       + " AS " + Mbj16CrExpence.FLG1 + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM                      + " AS " + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj05Car.CARNM                            + " AS " + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY                     + " AS " + Mbj11CarSec.AUTHORITY + " ");
            sql.append("    ," + "'0'"                                     + " AS " + "DATAKBN" + " ");
            sql.append(" FROM ");
            sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
            sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
            sql.append("    ," + Mbj15CrClass.TBNAME + " ");
            sql.append("    ," + Mbj05Car.TBNAME + " ");
            sql.append("    ," + Mbj11CarSec.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("     " + Tbj11CrCreateData.CLASSDIV + "  = " + ConvertToDBString("0"));
            if (!StringUtil.isBlank(_findBudgetCondition.getDCarCd())) {
                sql.append(" AND " + Tbj11CrCreateData.DCARCD + "  = " + ConvertToDBString(_findBudgetCondition.getDCarCd()));
            }
            sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");
            sql.append(" AND " + Tbj11CrCreateData.EXPCD    + "  = " + Mbj16CrExpence.EXPCD + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CLASSDIV + "  = " + Mbj16CrExpence.CLASSDIV + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " >= " + Mbj16CrExpence.DATEFROM + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + Mbj16CrExpence.DATETO + "(+)");
            sql.append(" AND " + Mbj16CrExpence.FLG1        + "  = " + "'1'");

            sql.append(" AND " + Tbj11CrCreateData.CLASSCD  + "  = " + Mbj15CrClass.CLASSCD + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " >= " + Mbj15CrClass.DATEFROM + "(+)");
            sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + Mbj15CrClass.DATETO + "(+)");

            sql.append(" AND " + Tbj11CrCreateData.DCARCD   + "  = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" AND " + Mbj11CarSec.SECTYPE        + "  = " + ConvertToDBString("1"));
            sql.append(" AND " + Mbj11CarSec.AUTHORITY      + " IN ('1', '2')");
            sql.append(" AND " + Mbj11CarSec.HAMID          + "  = " + ConvertToDBString(_findBudgetCondition.getHamid()));
            sql.append(" AND " + Tbj11CrCreateData.DCARCD   + "  = " + Mbj11CarSec.DCARCD + "(+)");

            sql.append(" UNION ALL ");

            //************************************************************
            //[予算]を取得するSQL
            //　⇒CR予算のデータ
            //************************************************************
            sql.append(" SELECT ");
            sql.append("     " + Tbj31CrBudgetPlan.DCARCD                  + " AS " + Tbj11CrCreateData.DCARCD + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.CLASSCD                 + " AS " + Tbj11CrCreateData.CLASSCD + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.CRDATE                  + " AS " + Tbj11CrCreateData.CRDATE + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.KIKANS + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.KIKANE + " ");
            sql.append("    ," + "NULL"                                    + " AS " + Tbj11CrCreateData.CONTRACTTERM + " ");
            sql.append("    ," + "SUM(" + Tbj31CrBudgetPlan.BUDGET + ")"   + " AS " + Tbj11CrCreateData.CLMMONEY + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.EXPCD                   + " AS " + Tbj11CrCreateData.EXPCD + " ");
            sql.append("    ," + Mbj16CrExpence.FLG1                       + " AS " + Mbj16CrExpence.FLG1 + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM                      + " AS " + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj05Car.CARNM                            + " AS " + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY                     + " AS " + Mbj11CarSec.AUTHORITY + " ");
            sql.append("    ," + "'1'"                                     + " AS " + "DATAKBN" + " ");
            sql.append(" FROM ");
            sql.append("     " + Tbj31CrBudgetPlan.TBNAME + " ");
            sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
            sql.append("    ," + Mbj15CrClass.TBNAME + " ");
            sql.append("    ," + Mbj05Car.TBNAME + " ");
            sql.append("    ," + Mbj11CarSec.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("     " + Tbj31CrBudgetPlan.PHASE + "  = " + ConvertToDBString(_findBudgetCondition.getPhase()));
            if (_findBudgetCondition.getLockDate() != null) {
                sql.append(" AND " + Tbj31CrBudgetPlan.CRDATE + " > " + ConvertToDBString(_findBudgetCondition.getLockDate()));
            }
            if (!StringUtil.isBlank(_findBudgetCondition.getDCarCd())) {
                sql.append(" AND " + Tbj31CrBudgetPlan.DCARCD + "  = " + ConvertToDBString(_findBudgetCondition.getDCarCd()));
            }
            sql.append(" AND " + Tbj31CrBudgetPlan.EXPCD    + "  = " + Mbj16CrExpence.EXPCD + "(+)");
            sql.append(" AND " + Tbj31CrBudgetPlan.CRDATE   + " >= " + Mbj16CrExpence.DATEFROM + "(+)");
            sql.append(" AND " + Tbj31CrBudgetPlan.CRDATE   + " <= " + Mbj16CrExpence.DATETO + "(+)");
            sql.append(" AND " + Mbj16CrExpence.CLASSDIV    + "  = " + "'0'");

            sql.append(" AND " + Tbj31CrBudgetPlan.CLASSCD  + "  = " + Mbj15CrClass.CLASSCD + "(+)");
            sql.append(" AND " + Tbj31CrBudgetPlan.CRDATE   + " >= " + Mbj15CrClass.DATEFROM + "(+)");
            sql.append(" AND " + Tbj31CrBudgetPlan.CRDATE   + " <= " + Mbj15CrClass.DATETO + "(+)");

            sql.append(" AND " + Tbj31CrBudgetPlan.DCARCD   + "  = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" AND " + Mbj11CarSec.SECTYPE        + "  = " + ConvertToDBString("1"));
            sql.append(" AND " + Mbj11CarSec.AUTHORITY      + " IN ('1', '2')");
            sql.append(" AND " + Mbj11CarSec.HAMID          + "  = " + ConvertToDBString(_findBudgetCondition.getHamid()));
            sql.append(" AND " + Tbj31CrBudgetPlan.DCARCD   + "  = " + Mbj11CarSec.DCARCD + "(+)");
            sql.append(" GROUP BY ");
            sql.append("     " + Tbj31CrBudgetPlan.DCARCD + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.CLASSCD + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.CRDATE + " ");
            sql.append("    ," + Tbj31CrBudgetPlan.EXPCD + " ");
            sql.append("    ," + Mbj16CrExpence.FLG1 + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY + " ");

            sql.append(" ORDER BY ");
            sql.append("     " + Tbj11CrCreateData.DCARCD + " ");
        }

        return sql.toString();
    };

    /**
     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindBudgetVO> findBudget(FindBudgetCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindBudgetVO());
        try {
            _SelSqlMode = SelSqlMode.LIST;
            _findBudgetCondition = cond;
            return (List<FindBudgetVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
