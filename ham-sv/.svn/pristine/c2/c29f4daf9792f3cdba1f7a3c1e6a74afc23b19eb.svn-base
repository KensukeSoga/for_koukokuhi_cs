package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanVO;
import jp.co.isid.ham.common.model.Tbj33CrBudgetUpdHisVO;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj31CrBudgetPlan;
import jp.co.isid.ham.integ.tbl.Tbj33CrBudgetUpdHis;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class BudgetDetailsDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindBudgetDetailsCondition _cond = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LIST,
        LAST,
        LAST2,
    };

    private SelSqlMode _SelSqlMode = null;

//    /** getExecSQLで発行するSQLのモード() */
//    private enum ExecSqlMode {
//        HISTORY,
//    };
//
//    private ExecSqlMode _ExecSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public BudgetDetailsDAO() {
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

        if (SelSqlMode.LAST.equals(_SelSqlMode)) {

            //TODO:不要なレコードも取得してしまうのでレスポンスによっては改善を検討.
            //最終更新者・最終更新日時を取得
            sql.append(" SELECT ");
            sql.append("  " + Tbj33CrBudgetUpdHis.UPDDATE);
            sql.append(" ," + Tbj33CrBudgetUpdHis.UPDNM);
            sql.append(" FROM ");
            sql.append("  " + Tbj33CrBudgetUpdHis.TBNAME);
            sql.append(" ," + Mbj11CarSec.TBNAME);
            sql.append(" WHERE ");
            sql.append("  " + Tbj33CrBudgetUpdHis.PHASE     + " =  " + ConvertToDBString(_cond.getPhase()));
            if (!StringUtil.isBlank(_cond.getDCarCd())) {
                sql.append(" AND " + Tbj33CrBudgetUpdHis.DCARCD + " =  " + ConvertToDBString(_cond.getDCarCd()));
            }
            sql.append(" AND " + Tbj33CrBudgetUpdHis.DCARCD + " =  " + Mbj11CarSec.DCARCD);
            sql.append(" AND " + Mbj11CarSec.HAMID          + " =  " + ConvertToDBString(_cond.getHamid()));
            sql.append(" AND " + Mbj11CarSec.AUTHORITY      + " IN ('1', '2')");
            sql.append(" ORDER BY ");
            sql.append("  " + Tbj33CrBudgetUpdHis.UPDDATE + " DESC ");

        } else if (SelSqlMode.LAST2.equals(_SelSqlMode)) {

            //TODO:不要なレコードも取得してしまうのでレスポンスによっては改善を検討.
            //最終更新者・最終更新日時を取得
            sql.append(" SELECT ");
            sql.append("  " + Tbj31CrBudgetPlan.UPDDATE);
            sql.append(" ," + Tbj31CrBudgetPlan.UPDNM);
            sql.append(" FROM ");
            sql.append("  " + Tbj31CrBudgetPlan.TBNAME);
            sql.append(" ," + Mbj11CarSec.TBNAME);
            sql.append(" WHERE ");
            sql.append("  " + Tbj31CrBudgetPlan.PHASE     + " =  " + ConvertToDBString(_cond.getPhase()));
            if (!StringUtil.isBlank(_cond.getDCarCd())) {
                sql.append(" AND " + Tbj31CrBudgetPlan.DCARCD + " =  " + ConvertToDBString(_cond.getDCarCd()));
            }
            sql.append(" AND " + Tbj31CrBudgetPlan.DCARCD + " =  " + Mbj11CarSec.DCARCD);
            sql.append(" AND " + Mbj11CarSec.HAMID          + " =  " + ConvertToDBString(_cond.getHamid()));
            sql.append(" AND " + Mbj11CarSec.AUTHORITY      + " IN ('1', '2')");
            sql.append(" ORDER BY ");
            sql.append("  " + Tbj31CrBudgetPlan.UPDDATE + " DESC ");
        }

        return sql.toString();
    };

    /**
     * 画面で指定した条件で検索を行い、最終更新情報データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj33CrBudgetUpdHisVO> findLastUpdInfoFromHistory(FindBudgetDetailsCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj33CrBudgetUpdHisVO());
        try {
            _SelSqlMode = SelSqlMode.LAST;
            _cond = cond;
            return (List<Tbj33CrBudgetUpdHisVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 画面で指定した条件で検索を行い、最終更新情報データを取得します
    *
    * @param cond
    * @return
    * @throws HAMException
    */
   @SuppressWarnings("unchecked")
   public List<Tbj31CrBudgetPlanVO> findLastUpdInfoFromBudget(FindBudgetDetailsCondition cond) throws HAMException {
       //パラメータチェック
       if (cond == null) {
           throw new HAMException("検索エラー", "BJ-E0001");
       }
       super.setModel(new Tbj31CrBudgetPlanVO());
       try {
           _SelSqlMode = SelSqlMode.LAST2;
           _cond = cond;
           return (List<Tbj31CrBudgetPlanVO>) super.find();
       } catch (UserException e) {
           throw new HAMException(e.getMessage(), "BJ-E0001");
       }
   }

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

    //▲検索系処理▲
    //▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
    //▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
    //▼更新系処理▼

}
