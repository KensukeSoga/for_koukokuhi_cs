package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdCondition;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class CheckListDAO extends AbstractRdbDao {

    /** 検索条件 */
    private GetRepDataForChkListCondition _getRepDataForChkListCondition = null;
    private RepaVbjaMeu07SikKrSprdCondition _repaVbjaMeu07SikKrSprdCondition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        REPDATA, HATKYK, THS,
    };


    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public CheckListDAO() {
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

        if (SelSqlMode.REPDATA.equals(_SelSqlMode)) {
            sql = getSelectSQLForREPDATA();
        } else if (SelSqlMode.HATKYK.equals(_SelSqlMode)) {
            sql = getSelectSQLForHATKYK();
        } else if (SelSqlMode.THS.equals(_SelSqlMode)) {
            sql = getSelectSQLForTHS();
        }

        return sql.toString();
    };

    /**
     * モード"REPDATA"のSQL文を返します
     */
    public String getSelectSQLForREPDATA() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + Tbj11CrCreateData.ORDERNO + " ");
        sql.append("    ," + Mbj05Car.CARNM + " ");
        sql.append("    ," + Mbj16CrExpence.EXPNM + " ");
        sql.append("    ," + Tbj11CrCreateData.EXPENSE + " ");
        sql.append("    ," + Tbj11CrCreateData.DETAIL + " ");
        sql.append("    ," + Mbj26BillGroup.GROUPNM + " ");
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAY + " ");
        sql.append("    ," + Tbj11CrCreateData.CLMMONEY + " ");
        sql.append("    ," + Mbj17CrDivision.DIVNM + " ");
        sql.append("    ," + Mbj30InputTnt.INPUTTNT + " ");
        sql.append(" FROM ");
        sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj05Car.TBNAME + " ");
        sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
        sql.append("    ," + Mbj26BillGroup.TBNAME + " ");
        sql.append("    ," + Mbj17CrDivision.TBNAME + " ");
        sql.append("    ," + Mbj30InputTnt.TBNAME + " ");
        sql.append(" WHERE ");
        //結合条件(車種マスタ)
        sql.append("     " + Tbj11CrCreateData.DCARCD    + " = " + Mbj05Car.DCARCD);
        //結合条件(CR予算表費目マスタ)
        sql.append(" AND " + Tbj11CrCreateData.EXPCD    + " = " + Mbj16CrExpence.EXPCD);
        //結合条件(請求グループマスタ)
        sql.append(" AND " + Tbj11CrCreateData.GROUPCD    + " = " + Mbj26BillGroup.GROUPCD + "(+)");
        //結合条件(CR区分マスタ)
        sql.append(" AND " + Tbj11CrCreateData.DIVCD    + " = " + Mbj17CrDivision.DIVCD + "(+)");
        //結合条件(入力担当者マスタ)
        sql.append(" AND " + Tbj11CrCreateData.PHASE       + " = " + Mbj30InputTnt.PHASE + "(+)");
        sql.append(" AND " + Tbj11CrCreateData.CLASSDIV    + " = " + Mbj30InputTnt.CLASSDIV + "(+)");
        sql.append(" AND " + Tbj11CrCreateData.INPUTTNTCD  + " = " + Mbj30InputTnt.SEQNO + "(+)");

        //検索条件(フェイズ)
        sql.append(" AND " + Tbj11CrCreateData.PHASE    + " = " + ConvertToDBString(_getRepDataForChkListCondition.getPhase()));
        //検索条件(請求月)
        sql.append(" AND " + Mbj16CrExpence.DATEFROM + " <= " + ConvertToDBString(_getRepDataForChkListCondition.getFromSeikyuDate()));
        sql.append(" AND " + Mbj16CrExpence.DATETO   + " >= " + ConvertToDBString(_getRepDataForChkListCondition.getToSeikyuDate()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE + " >= " + ConvertToDBString(_getRepDataForChkListCondition.getFromSeikyuDate()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + ConvertToDBString(_getRepDataForChkListCondition.getToSeikyuDate()));
        //検索条件(得意先)
        if (_getRepDataForChkListCondition.getCarList() != null && _getRepDataForChkListCondition.getCarList().length > 0) {
            sql.append(" AND " + Tbj11CrCreateData.DCARCD + " IN ( ");
            for (int i = 0; i < _getRepDataForChkListCondition.getCarList().length; i++) {
                if (i > 0) {
                    sql.append(",");
                }
                sql.append(" " + ConvertToDBString(_getRepDataForChkListCondition.getCarList()[i]) + " ");
            }
            sql.append(" ) ");
        }
        sql.append(" AND " + Tbj11CrCreateData.CLASSDIV    + " = '0'");
        sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");
        sql.append(" ORDER BY ");
        sql.append("     " + Mbj05Car.CARNM + " ");
        sql.append("    ," + Tbj11CrCreateData.ORDERNO + " ");

        return sql.toString();
    };



    /**
     * モード"HATKYK"のSQL文を返します
     */
    public String getSelectSQLForHATKYK() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK + " AS SIKCDKYK");
        sql.append("    ," + RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ + " AS KYOKUNM");
        sql.append("    ,ListAgg(" + RepaVbjaMeu07SikKrSprd.SIKCD + ", ',') WITHIN GROUP (order by " + RepaVbjaMeu07SikKrSprd.SIKCD + ") AS SIKCD");
        sql.append(" FROM ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(RepaVbjaMeu07SikKrSprd.SIKCD);
        sql.append(" IN (");
        sql.append(_repaVbjaMeu07SikKrSprdCondition.getSikcd());
        sql.append(" )");
        sql.append(" AND ");
//        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
//        sql.append(" <= ");
//        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getStartymd()));
//        sql.append(" AND ");
//        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
//        sql.append(" >= ");
//        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getEndymd()));
        sql.append(" ( ");
        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getStartymd()));
        sql.append(" BETWEEN ");
        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" OR ");
        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getEndymd()));
        sql.append(" BETWEEN ");
        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" ) ");
        sql.append(" GROUP BY ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK);
        sql.append("    ," + RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ);
        sql.append(" ORDER BY ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK  + " ");
//        sql.append("    ," + RepaVbjaMeu07SikKrSprd.ENDYMD  + " DESC ");

        return sql.toString();
    };



    /**
     * モード"THS"のSQL文を返します
     */
    public String getSelectSQLForTHS() {
        StringBuffer sql = new StringBuffer();

        CheckListThsDataVO vo = (CheckListThsDataVO)getModel();

        sql.append(" SELECT ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYCD);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);
        sql.append("    ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI);
        sql.append(" FROM ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.TBNAME + " ");
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + getDBModelInterface().ConvertToDBString(vo.getTHSKGYCD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu12ThsKgy.STARTYMD + " <= " + getDBModelInterface().ConvertToDBString(vo.getSTARTYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu12ThsKgy.ENDYMD + " >= " + getDBModelInterface().ConvertToDBString(vo.getENDYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.THSKGYCD + " = " + getDBModelInterface().ConvertToDBString(vo.getTHSKGYCD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.SEQNO + " = " + getDBModelInterface().ConvertToDBString(vo.getSEQNO()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.STARTYMD + " <= " + getDBModelInterface().ConvertToDBString(vo.getSTARTYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.ENDYMD + " >= " + getDBModelInterface().ConvertToDBString(vo.getENDYMD()));
        sql.append(" ORDER BY ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYCD);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);


        return sql.toString();
    };


    /**
     * 画面で指定した条件で検索を行い、帳票に出力するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepDataForChkListHAMVO> findCheckListREPDATA(GetRepDataForChkListCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new RepDataForChkListHAMVO());
        try {
            _SelSqlMode = SelSqlMode.REPDATA;
            _getRepDataForChkListCondition = cond;
            return (List<RepDataForChkListHAMVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 画面で指定した条件で検索を行い、帳票に出力するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCheckListHattyuKykVO> findCheckListHATKYK(RepaVbjaMeu07SikKrSprdCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindCheckListHattyuKykVO());
        try {
            _SelSqlMode = SelSqlMode.HATKYK;
            _repaVbjaMeu07SikKrSprdCondition = cond;
            return (List<FindCheckListHattyuKykVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 得意先名称を取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<CheckListThsDataVO> findCheckListTHS(CheckListThsDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.THS;
            return (List<CheckListThsDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
