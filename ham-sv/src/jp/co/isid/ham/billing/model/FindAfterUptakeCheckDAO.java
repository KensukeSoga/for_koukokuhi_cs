package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 変更情報の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/3/13 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/
public class FindAfterUptakeCheckDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindAfterUptakeCheckCondition _cond = null;

    /** フラグ */
    private boolean _flg = false;

    /**
     * デフォルトコンストラクタ
     */
    public FindAfterUptakeCheckDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        if (_flg) {
            return new String[]{
                    Tbj11CrCreateData.SEQUENCENO + " AS SEQUENCENO"
                    ,Tbj11CrCreateData.DCARCD + " AS DCARCD"
                    ,Mbj05Car.CARNM + " AS CARNM"
                    ,Tbj11CrCreateData.CRDATE + " AS CRDATE"
                    ,Tbj11CrCreateData.CLASSDIV + " AS CLASSDIV"
                    ,Tbj11CrCreateData.CLASSCD + " AS CLASSCD"
                    ,Mbj15CrClass.CLASSNM + " AS CLASSNM"
                    ,Tbj11CrCreateData.EXPCD + " AS EXPCD"
                    ,Mbj16CrExpence.EXPNM + " AS EXPNM"
                    ,Mbj16CrExpence.FLG1 + " AS FLG1"
                    ,Tbj11CrCreateData.EXPENSE + " AS EXPENSE"
                    ,Tbj11CrCreateData.KIKANS + " AS KIKANS"
                    ,Tbj11CrCreateData.KIKANE + " AS KIKANE"
                    ,Tbj11CrCreateData.ESTMONEY + " AS ESTMONEY"
                    ,Tbj11CrCreateData.CLMMONEY + " AS CLMMONEY"
                    ,Tbj11CrCreateData.DELIVERDAY + " AS DELIVERDAY"
                    ,Tbj11CrCreateData.SETMONTH + " AS SETMONTH"
                    ,Tbj11CrCreateData.DIVCD + " AS DIVCD"
                    ,Mbj17CrDivision.DIVNM + " AS DIVNM"
                    ,Tbj11CrCreateData.GROUPCD + " AS GROUPCD"
                    ,Mbj26BillGroup.GROUPNM + " AS GROUPNM"
                    ,Tbj11CrCreateData.STKYKNO + " AS STKYKNO"
                    ,Mbj29SetteiKyk.STKYKNM + " AS STKYKNM"
                    ,Tbj11CrCreateData.EGTYKFLG + " AS EGTYKFLG"
                    ,Tbj11CrCreateData.INPUTTNTCD + " AS INPUTTNTCD"
                    ,Mbj30InputTnt.INPUTTNT + " AS INPUTTNT"
                    ,Mbj05Car.SORTNO + " AS SORTNO"
            };
        }
        else
        {
            return new String[]{
                    Tbj22SeisakuhiSs.SEQUENCENO + " AS SEQUENCENO"
                    ,Tbj22SeisakuhiSs.DCARCD + " AS DCARCD"
                    ,Mbj05Car.CARNM + " AS CARNM"
                    ,Tbj22SeisakuhiSs.CRDATE + " AS CRDATE"
                    ,Tbj22SeisakuhiSs.CLASSDIV + " AS CLASSDIV"
                    ,Tbj22SeisakuhiSs.CLASSCD + " AS CLASSCD"
                    ,Mbj15CrClass.CLASSNM + " AS CLASSNM"
                    ,Tbj22SeisakuhiSs.EXPCD + " AS EXPCD"
                    ,Mbj16CrExpence.EXPNM + " AS EXPNM"
                    ,Mbj16CrExpence.FLG1 + " AS FLG1"
                    ,Tbj22SeisakuhiSs.EXPENSE + " AS EXPENSE"
                    ,Tbj22SeisakuhiSs.KIKANS + " AS KIKANS"
                    ,Tbj22SeisakuhiSs.KIKANE + " AS KIKANE"
                    ,Tbj22SeisakuhiSs.ESTMONEY + " AS ESTMONEY"
                    ,Tbj22SeisakuhiSs.CLMMONEY + " AS CLMMONEY"
                    ,Tbj22SeisakuhiSs.DELIVERDAY + " AS DELIVERDAY"
                    ,Tbj22SeisakuhiSs.SETMONTH + " AS SETMONTH"
                    ,Tbj22SeisakuhiSs.DIVCD + " AS DIVCD"
                    ,Mbj17CrDivision.DIVNM + " AS DIVNM"
                    ,Tbj22SeisakuhiSs.GROUPCD + " AS GROUPCD"
                    ,Mbj26BillGroup.GROUPNM + " AS GROUPNM"
                    ,Tbj22SeisakuhiSs.STKYKNO + " AS STKYKNO"
                    ,Mbj29SetteiKyk.STKYKNM + " AS STKYKNM"
                    ,Tbj22SeisakuhiSs.EGTYKFLG + " AS EGTYKFLG"
                    ,Tbj22SeisakuhiSs.INPUTTNTCD + " AS INPUTTNTCD"
                    ,Mbj30InputTnt.INPUTTNT + " AS INPUTTNT"
                    ,Mbj05Car.SORTNO + " AS SORTNO"
            };
        }
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getAfterUptakeCheckDAO();
    }

    /**
     * 営業作業台帳のSQL文を返します
     *
     * @return String SQL文
     */
    private String getAfterUptakeCheckDAO()
    {
        StringBuffer sql1 = new StringBuffer();
        StringBuffer sql2 = new StringBuffer();
        StringBuffer sql3 = new StringBuffer();
        StringBuffer sql4 = new StringBuffer();

        //新規に作成されたデータ
        sql1.append(" SELECT");
        //連番を取得
        sql1.append(" '00' AS FLAG ,");
        //全項目を取得
        _flg = true;
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql1.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql1.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql1.append(" FROM ");
        sql1.append(" "+ Tbj11CrCreateData.TBNAME + ", ");
        sql1.append(" "+ Mbj05Car.TBNAME +", ");
        sql1.append(" "+ Mbj15CrClass.TBNAME + ", ");
        sql1.append(" "+ Mbj16CrExpence.TBNAME +", ");
        sql1.append(" "+ Mbj17CrDivision.TBNAME +", ");
        sql1.append(" "+ Mbj26BillGroup.TBNAME + ", ");
        sql1.append(" "+ Mbj29SetteiKyk.TBNAME +", ");
        sql1.append(" "+ Mbj30InputTnt.TBNAME +" ");
        sql1.append(" WHERE ");
        sql1.append(" " + Tbj11CrCreateData.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql1.append(" AND ");
        sql1.append(" " + Mbj05Car.DISPSTS + " = '1' ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.CLASSCD + " = " + Mbj15CrClass.CLASSCD +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.EXPCD + " = " + Mbj16CrExpence.EXPCD +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.CLASSDIV + " = " + Mbj16CrExpence.CLASSDIV +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.DIVCD + " = " + Mbj17CrDivision.DIVCD +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.STKYKNO + " = " + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.INPUTTNTCD + " = " + Mbj30InputTnt.SEQNO +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.PHASE + " = " + Mbj29SetteiKyk.PHASE + "(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.PHASE + " = " + Mbj30InputTnt.PHASE +"(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.CLASSDIV + " = " + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.DCARCD + " = " + Mbj30InputTnt.DCARCD +"(+) ");
        sql1.append(" AND ");
        sql1.append(" NOT EXISTS(SELECT ");
        sql1.append(" 'X' ");
        sql1.append(" FROM ");
        sql1.append(" " + Tbj22SeisakuhiSs.TBNAME + " ");
        sql1.append(" WHERE ");
        sql1.append(" " + Tbj11CrCreateData.SEQUENCENO + " = " + Tbj22SeisakuhiSs.SEQUENCENO + " ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj22SeisakuhiSs.CRDATE + " =TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj22SeisakuhiSs.PHASE + " =" + _cond.getPhase() + " ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " ='" + _cond.getClassDiv() + "' ");
        sql1.append(" )AND ");
        sql1.append(" " + Tbj11CrCreateData.CRDATE + " =TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.PHASE + " =" + _cond.getPhase() + " ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.CLASSDIV + " ='" + _cond.getClassDiv() + "' ");
        sql1.append(" AND ");
        sql1.append(" " + Tbj11CrCreateData.STPKBN + " = '0'");
        sql1.append(" AND ");
        sql1.append(" " + Mbj15CrClass.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql1.append(" AND ");
        sql1.append(" " + Mbj15CrClass.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql1.append(" AND ");
        sql1.append(" " + Mbj16CrExpence.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql1.append(" AND ");
        sql1.append(" " + Mbj16CrExpence.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");


        //削除されたデータ
        sql2.append(" UNION ALL ");
        sql2.append(" SELECT");
        //連番を取得
        sql2.append(" '10' AS FLAG ,");
        //全項目を取得
        _flg = false;
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql2.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql2.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql2.append(" FROM ");
        sql2.append(" "+ Tbj22SeisakuhiSs.TBNAME + ", ");
        sql2.append(" "+ Mbj05Car.TBNAME +", ");
        sql2.append(" "+ Mbj15CrClass.TBNAME + ", ");
        sql2.append(" "+ Mbj16CrExpence.TBNAME +", ");
        sql2.append(" "+ Mbj17CrDivision.TBNAME +", ");
        sql2.append(" "+ Mbj26BillGroup.TBNAME + ", ");
        sql2.append(" "+ Mbj29SetteiKyk.TBNAME +", ");
        sql2.append(" "+ Mbj30InputTnt.TBNAME +" ");
        sql2.append(" WHERE ");
        sql2.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql2.append(" AND ");
        sql2.append(" " + Mbj05Car.DISPSTS + " = '1' ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.CLASSCD + " = " + Mbj15CrClass.CLASSCD +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.EXPCD + " = " + Mbj16CrExpence.EXPCD +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj16CrExpence.CLASSDIV +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.DIVCD + " = " + Mbj17CrDivision.DIVCD +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.STKYKNO + " = " + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj29SetteiKyk.PHASE + "(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.INPUTTNTCD + " = " + Mbj30InputTnt.SEQNO +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj30InputTnt.PHASE +"(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj30InputTnt.DCARCD +"(+) ");
        sql2.append(" AND ");
        sql2.append(" NOT EXISTS(SELECT ");
        sql2.append(" 'X' ");
        sql2.append(" FROM ");
        sql2.append(" " + Tbj11CrCreateData.TBNAME + " ");
        sql2.append(" WHERE ");
        sql2.append(" " + Tbj11CrCreateData.SEQUENCENO + " = " + Tbj22SeisakuhiSs.SEQUENCENO + " ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj11CrCreateData.CRDATE + " =TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj11CrCreateData.PHASE + " =" + _cond.getPhase() + " ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj11CrCreateData.STPKBN + " = '0'");
        sql2.append(" )AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.CRDATE + "=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.PHASE + " =" + _cond.getPhase() + " ");
        sql2.append(" AND ");
        sql2.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " ='" + _cond.getClassDiv() + "' ");
        sql2.append(" AND ");
        sql2.append(" " + Mbj15CrClass.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql2.append(" AND ");
        sql2.append(" " + Mbj15CrClass.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql2.append(" AND ");
        sql2.append(" " + Mbj16CrExpence.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql2.append(" AND ");
        sql2.append(" " + Mbj16CrExpence.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");


        //変更後データ
        sql3.append(" UNION ALL ");
        sql3.append(" SELECT");
        //連番を取得
        sql3.append(" '21' AS FLAG ,");
        //全項目を取得
        _flg = true;
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql3.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql3.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql3.append(" FROM ");
        sql3.append(" "+ Tbj11CrCreateData.TBNAME + ", ");
        sql3.append(" "+ Tbj22SeisakuhiSs.TBNAME + ", ");
        sql3.append(" "+ Mbj05Car.TBNAME +", ");
        sql3.append(" "+ Mbj15CrClass.TBNAME + ", ");
        sql3.append(" "+ Mbj16CrExpence.TBNAME +", ");
        sql3.append(" "+ Mbj17CrDivision.TBNAME +", ");
        sql3.append(" "+ Mbj26BillGroup.TBNAME + ", ");
        sql3.append(" "+ Mbj29SetteiKyk.TBNAME +", ");
        sql3.append(" "+ Mbj30InputTnt.TBNAME +" ");
        sql3.append(" WHERE ");
        sql3.append(" " + Tbj11CrCreateData.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql3.append(" AND ");
        sql3.append(" " + Mbj05Car.DISPSTS + " = '1' ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.CLASSCD + " = " + Mbj15CrClass.CLASSCD +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.EXPCD + " = " + Mbj16CrExpence.EXPCD +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.CLASSDIV + " = " + Mbj16CrExpence.CLASSDIV +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.DIVCD + " = " + Mbj17CrDivision.DIVCD +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.STKYKNO + " = " + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.INPUTTNTCD + " = " + Mbj30InputTnt.SEQNO +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.SEQUENCENO + " = " + Tbj22SeisakuhiSs.SEQUENCENO + " ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.PHASE + " = " + Mbj29SetteiKyk.PHASE + "(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.PHASE + " = " + Mbj30InputTnt.PHASE +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.CLASSDIV + " = " + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.DCARCD + " = " + Mbj30InputTnt.DCARCD +"(+) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj11CrCreateData.STPKBN + " = '0'");
        sql3.append(" AND ");
        sql3.append(" ( ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.DCARCD,Tbj22SeisakuhiSs.DCARCD));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.CRDATE,Tbj22SeisakuhiSs.CRDATE));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.CLASSDIV,Tbj22SeisakuhiSs.CLASSDIV));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.EXPCD,Tbj22SeisakuhiSs.EXPCD));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.EXPENSE,Tbj22SeisakuhiSs.EXPENSE));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.KIKANS,Tbj22SeisakuhiSs.KIKANS));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.KIKANE,Tbj22SeisakuhiSs.KIKANE));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.ESTMONEY ,Tbj22SeisakuhiSs.ESTMONEY));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.CLMMONEY,Tbj22SeisakuhiSs.CLMMONEY));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.DELIVERDAY,Tbj22SeisakuhiSs.DELIVERDAY));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.SETMONTH,Tbj22SeisakuhiSs.SETMONTH));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.DIVCD,Tbj22SeisakuhiSs.DIVCD));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.STKYKNO,Tbj22SeisakuhiSs.STKYKNO));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.INPUTTNTCD,Tbj22SeisakuhiSs.INPUTTNTCD));
        sql3.append(" OR ");
        sql3.append(createDiffWhere(Tbj11CrCreateData.EGTYKFLG,Tbj22SeisakuhiSs.EGTYKFLG));
        sql3.append(" ) ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj22SeisakuhiSs.CRDATE + " =TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj22SeisakuhiSs.PHASE + " =" + _cond.getPhase() + " ");
        sql3.append(" AND ");
        sql3.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " ='" + _cond.getClassDiv() + "' ");
        sql3.append(" AND ");
        sql3.append(" " + Mbj15CrClass.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql3.append(" AND ");
        sql3.append(" " + Mbj15CrClass.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql3.append(" AND ");
        sql3.append(" " + Mbj16CrExpence.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql3.append(" AND ");
        sql3.append(" " + Mbj16CrExpence.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");


        //変更前データ
        sql4.append(" UNION ALL ");
        sql4.append(" SELECT");
        //連番を取得
        sql4.append(" '20' AS FLAG ,");
        //全項目を取得
        _flg = false;
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql4.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql4.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql4.append(" FROM ");
        sql4.append(" "+ Tbj11CrCreateData.TBNAME + ", ");
        sql4.append(" "+ Tbj22SeisakuhiSs.TBNAME + ", ");
        sql4.append(" "+ Mbj05Car.TBNAME +", ");
        sql4.append(" "+ Mbj15CrClass.TBNAME + ", ");
        sql4.append(" "+ Mbj16CrExpence.TBNAME +", ");
        sql4.append(" "+ Mbj17CrDivision.TBNAME +", ");
        sql4.append(" "+ Mbj26BillGroup.TBNAME + ", ");
        sql4.append(" "+ Mbj29SetteiKyk.TBNAME +", ");
        sql4.append(" "+ Mbj30InputTnt.TBNAME +" ");
        sql4.append(" WHERE ");
        sql4.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql4.append(" AND ");
        sql4.append(" " + Mbj05Car.DISPSTS + " = '1' ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.CLASSCD + " = " + Mbj15CrClass.CLASSCD +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.EXPCD + " = " + Mbj16CrExpence.EXPCD +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj16CrExpence.CLASSDIV +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.DIVCD + " = " + Mbj17CrDivision.DIVCD +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.GROUPCD + " = " + Mbj26BillGroup.GROUPCD + "(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.STKYKNO + " = " + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.INPUTTNTCD + " = " + Mbj30InputTnt.SEQNO +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj29SetteiKyk.PHASE + "(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.PHASE + " = " + Mbj30InputTnt.PHASE +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " = " + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.DCARCD + " = " + Mbj30InputTnt.DCARCD +"(+) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj11CrCreateData.STPKBN + " = '0'");
        sql4.append(" AND ");
        sql4.append(" " + Tbj11CrCreateData.SEQUENCENO + " = " + Tbj22SeisakuhiSs.SEQUENCENO + " ");
        sql4.append(" AND ");
        sql4.append(" ( ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.DCARCD,Tbj22SeisakuhiSs.DCARCD));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.CRDATE,Tbj22SeisakuhiSs.CRDATE));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.CLASSDIV,Tbj22SeisakuhiSs.CLASSDIV));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.EXPCD,Tbj22SeisakuhiSs.EXPCD));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.EXPENSE,Tbj22SeisakuhiSs.EXPENSE));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.KIKANS,Tbj22SeisakuhiSs.KIKANS));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.KIKANE,Tbj22SeisakuhiSs.KIKANE));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.ESTMONEY ,Tbj22SeisakuhiSs.ESTMONEY));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.CLMMONEY,Tbj22SeisakuhiSs.CLMMONEY));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.DELIVERDAY,Tbj22SeisakuhiSs.DELIVERDAY));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.SETMONTH,Tbj22SeisakuhiSs.SETMONTH));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.DIVCD,Tbj22SeisakuhiSs.DIVCD));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.STKYKNO,Tbj22SeisakuhiSs.STKYKNO));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.INPUTTNTCD,Tbj22SeisakuhiSs.INPUTTNTCD));
        sql4.append(" OR ");
        sql4.append(createDiffWhere(Tbj11CrCreateData.EGTYKFLG,Tbj22SeisakuhiSs.EGTYKFLG));
        sql4.append(" ) ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.CRDATE + " =TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.PHASE + " =" + _cond.getPhase() + " ");
        sql4.append(" AND ");
        sql4.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " ='" + _cond.getClassDiv() + "' ");
        sql4.append(" AND ");
        sql4.append(" " + Mbj15CrClass.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql4.append(" AND ");
        sql4.append(" " + Mbj15CrClass.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql4.append(" AND ");
        sql4.append(" " + Mbj16CrExpence.DATEFROM + " <=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql4.append(" AND ");
        sql4.append(" " + Mbj16CrExpence.DATETO + " >=TO_DATE('" + _cond.getYearMonth() + "', 'YYYY/MM') ");
        sql4.append(" ORDER BY ");
        sql4.append(" SORTNO ASC, ");
        sql4.append(" DCARCD ASC, ");
        sql4.append(" SEQUENCENO ASC, ");
        sql4.append(" FLAG ASC");

        return sql1.toString() + sql2.toString() + sql3.toString() + sql4.toString();
    }

    /**
     * 比較を行うWhere文を作成する
     * (Nullとの比較、半角全角スペースを取り除いての比較)
     * @param source 比較項目1
     * @param target 比較項目2
     * @return Where文
     */
    private String createDiffWhere(String source,String target) {
        StringBuffer where = new StringBuffer();
        where.append("(");
        where.append("(");
        where.append(" " + source + " IS NULL AND " + target + " IS NOT NULL ");
        where.append(")");
        where.append(" OR ");
        where.append("(");
        where.append(" " + source + " IS NOT NULL AND " + target + " IS NULL ");
        where.append(")");
        where.append(" OR ");
        where.append("(");
        where.append(" RTRIM(" + source + ") <> RTRIM(" + target + ") ");
        where.append(" AND ");
        where.append(" RTRIM(" + source + ",'　') <> RTRIM(" + target + ",'　') ");
        where.append(")");
        where.append(")");

        return where.toString();
    }

    /**
     * 営業作業台帳の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindAfterUptakeCheckVO> findFindAfterUptakeCheck(
            FindAfterUptakeCheckCondition cond) throws HAMException {

        super.setModel(new FindAfterUptakeCheckVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
