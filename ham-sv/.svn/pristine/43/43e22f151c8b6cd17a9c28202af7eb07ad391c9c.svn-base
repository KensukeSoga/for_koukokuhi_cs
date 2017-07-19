package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Tbj33CrBudgetUpdHis;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class BudgetHistoryDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindBudgetHistoryCondition _findBudgetHistoryCondition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LIST,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public BudgetHistoryDAO() {
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
            sql.append(" SELECT ");
            sql.append("     " + Tbj33CrBudgetUpdHis.PHASE      + " AS " + Tbj33CrBudgetUpdHis.PHASE + " ");
            sql.append("    ," + Mbj05Car.CARNM                 + " AS " + Mbj05Car.CARNM + " ");
            sql.append("    ," + Mbj15CrClass.CLASSNM           + " AS " + Mbj15CrClass.CLASSNM + " ");
            sql.append("    ," + Mbj16CrExpence.EXPNM           + " AS " + Mbj16CrExpence.EXPNM + " ");
            sql.append("    ," + Tbj33CrBudgetUpdHis.UPDDATE    + " AS " + Tbj33CrBudgetUpdHis.UPDDATE + " ");
            sql.append("    ," + Tbj33CrBudgetUpdHis.UPDNM      + " AS " + Tbj33CrBudgetUpdHis.UPDNM + " ");
            sql.append("    ," + Mbj11CarSec.AUTHORITY          + " AS " + Mbj11CarSec.AUTHORITY + " ");
            sql.append(" FROM ");
            sql.append("     " + Tbj33CrBudgetUpdHis.TBNAME + " ");
            sql.append("    ," + Mbj05Car.TBNAME + " ");
            sql.append("    ," + Mbj11CarSec.TBNAME + " ");
            sql.append("    ," + Mbj15CrClass.TBNAME + " ");
            sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("     " + Tbj33CrBudgetUpdHis.PHASE + "  = " + ConvertToDBString(_findBudgetHistoryCondition.getPhase()));
            if (!StringUtil.isBlank(_findBudgetHistoryCondition.getDCarCd())) {
                sql.append(" AND " + Tbj33CrBudgetUpdHis.DCARCD  + " = " + ConvertToDBString(_findBudgetHistoryCondition.getDCarCd()));
            }
            if (!StringUtil.isBlank(_findBudgetHistoryCondition.getClasscd())) {
                sql.append(" AND " + Tbj33CrBudgetUpdHis.CLASSCD + " = " + ConvertToDBString(_findBudgetHistoryCondition.getClasscd()));
            }
            if (!StringUtil.isBlank(_findBudgetHistoryCondition.getExpcd())) {
                sql.append(" AND " + Tbj33CrBudgetUpdHis.EXPCD   + " = " + ConvertToDBString(_findBudgetHistoryCondition.getExpcd()));
            }
            sql.append(" AND " + Tbj33CrBudgetUpdHis.EXPCD    + "  = " + Mbj16CrExpence.EXPCD + "(+)");
            sql.append(" AND " + Mbj16CrExpence.CLASSDIV + "  = '0'");
            sql.append(" AND (");
            sql.append("         (");
            sql.append("             " + Mbj16CrExpence.DATEFROM   + " <= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         AND " + Mbj16CrExpence.DATETO     + " >= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         ) OR (");
            sql.append("             " + Mbj16CrExpence.DATEFROM   + " <= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         AND " + Mbj16CrExpence.DATETO     + " >= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         )");
            sql.append("     )");

            sql.append(" AND " + Tbj33CrBudgetUpdHis.CLASSCD  + "  = " + Mbj15CrClass.CLASSCD + "(+)");
            sql.append(" AND (");
            sql.append("         (");
            sql.append("             " + Mbj15CrClass.DATEFROM   + " <= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         AND " + Mbj15CrClass.DATETO     + " >= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         ) OR (");
            sql.append("             " + Mbj15CrClass.DATEFROM   + " <= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         AND " + Mbj15CrClass.DATETO     + " >= " + ConvertToDBString(_findBudgetHistoryCondition.getSDate()) + "");
            sql.append("         )");
            sql.append("     )");

            sql.append(" AND " + Tbj33CrBudgetUpdHis.DCARCD + "  = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" AND " + Mbj11CarSec.SECTYPE        + "  = " + ConvertToDBString("1"));
            sql.append(" AND " + Mbj11CarSec.HAMID          + "  = " + ConvertToDBString(_findBudgetHistoryCondition.getHamid()));
            sql.append(" AND " + Tbj33CrBudgetUpdHis.DCARCD + "  = " + Mbj11CarSec.DCARCD + "(+)");
            sql.append(" ORDER BY ");
            sql.append("     " + Tbj33CrBudgetUpdHis.UPDDATE + " ");
            sql.append("    ," + Tbj33CrBudgetUpdHis.CLASSCD + " ");
            sql.append("    ," + Tbj33CrBudgetUpdHis.EXPCD + " ");
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
    public List<FindBudgetHistoryVO> findBudgetHistory(FindBudgetHistoryCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindBudgetHistoryVO());
        try {
            _SelSqlMode = SelSqlMode.LIST;
            _findBudgetHistoryCondition = cond;
            return (List<FindBudgetHistoryVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
