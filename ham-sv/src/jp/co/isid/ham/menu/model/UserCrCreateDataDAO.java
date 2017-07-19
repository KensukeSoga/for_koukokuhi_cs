package jp.co.isid.ham.menu.model;

import java.util.List;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * ユーザーCR制作費管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class UserCrCreateDataDAO extends AbstractRdbDao {

    private FindMainMenuCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{NOINPUT, UPDATED};
    private SelSqlMode _SelSqlMode = SelSqlMode.NOINPUT;

    /**
     * デフォルトコンストラクタ
     */
    public UserCrCreateDataDAO() {
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
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
                ,Tbj11CrCreateData.CLASSDIV
                ,Tbj11CrCreateData.SORTNO
                ,Tbj11CrCreateData.CLASSCD
                ,Tbj11CrCreateData.EXPCD
                ,Tbj11CrCreateData.EXPENSE
                ,Tbj11CrCreateData.DETAIL
                ,Tbj11CrCreateData.KIKANS
                ,Tbj11CrCreateData.KIKANE
                ,Tbj11CrCreateData.CONTRACTDATE
                ,Tbj11CrCreateData.CONTRACTTERM
                ,Tbj11CrCreateData.SEIKYU
                ,Tbj11CrCreateData.TRTHSKGYCD
                ,Tbj11CrCreateData.TRSEQNO
                ,Tbj11CrCreateData.ORDERNO
                ,Tbj11CrCreateData.PAY
                ,Tbj11CrCreateData.HRTHSKGYCD
                ,Tbj11CrCreateData.HRSEQNO
                ,Tbj11CrCreateData.USERNAME
                ,Tbj11CrCreateData.GETMONEY
                ,Tbj11CrCreateData.GETCONF
                ,Tbj11CrCreateData.PAYMONEY
                ,Tbj11CrCreateData.PAYCONF
                ,Tbj11CrCreateData.ESTMONEY
                ,Tbj11CrCreateData.CLMMONEY
                ,Tbj11CrCreateData.DELIVERDAY
                ,Tbj11CrCreateData.SETMONTH
                ,Tbj11CrCreateData.DIVCD
                ,Tbj11CrCreateData.GROUPCD
                ,Tbj11CrCreateData.STKYKNO
                ,Tbj11CrCreateData.STTNTID
                ,Tbj11CrCreateData.STTNTNM
                ,Tbj11CrCreateData.EGTYKFLG
                ,Tbj11CrCreateData.INPUTTNTCD
                ,Tbj11CrCreateData.CPTNTNM
                ,Tbj11CrCreateData.NOTE
                ,Tbj11CrCreateData.TCKEY
                ,Tbj11CrCreateData.TRSUBNO
                ,Tbj11CrCreateData.HRSUBNO
                ,Tbj11CrCreateData.RSTATUS
                ,Tbj11CrCreateData.STPKBN
                ,Tbj11CrCreateData.DCARCDFLG
                ,Tbj11CrCreateData.CLASSCDFLG
                ,Tbj11CrCreateData.EXPCDFLG
                ,Tbj11CrCreateData.EXPENSEFLG
                ,Tbj11CrCreateData.DETAILFLG
                ,Tbj11CrCreateData.KIKANSFLG
                ,Tbj11CrCreateData.KIKANEFLG
                ,Tbj11CrCreateData.CONTRACTDATEFLG
                ,Tbj11CrCreateData.CONTRACTTERMFLG
                ,Tbj11CrCreateData.SEIKYUFLG
                ,Tbj11CrCreateData.ORDERNOFLG
                ,Tbj11CrCreateData.PAYFLG
                ,Tbj11CrCreateData.USERNAMEFLG
                ,Tbj11CrCreateData.GETMONEYFLG
                ,Tbj11CrCreateData.GETCONFIRMFLG
                ,Tbj11CrCreateData.PAYMONEYFLG
                ,Tbj11CrCreateData.PAYCONFIRMFLG
                ,Tbj11CrCreateData.ESTMONEYFLG
                ,Tbj11CrCreateData.CLMMONEYFLG
                ,Tbj11CrCreateData.DELIVERDAYFLG
                ,Tbj11CrCreateData.SETMONTHFLG
                ,Tbj11CrCreateData.DIVISIONFLG
                ,Tbj11CrCreateData.GROUPCDFLG
                ,Tbj11CrCreateData.STKYKNOFLG
                ,Tbj11CrCreateData.STTNTNMFLG
                ,Tbj11CrCreateData.EGTYKFLGFLG
                ,Tbj11CrCreateData.INPUTTNTCDFLG
                ,Tbj11CrCreateData.CPTNTNMFLG
                ,Tbj11CrCreateData.NOTEFLG
                ,Tbj11CrCreateData.DCARCDCONFFLG
                ,Tbj11CrCreateData.DCARCDCONFSIKCD
                ,Tbj11CrCreateData.DCARCDCONFHAMID
                ,Tbj11CrCreateData.CLASSCDCONFFLG
                ,Tbj11CrCreateData.CLASSCDCONFSIKCD
                ,Tbj11CrCreateData.CLASSCDCONFHAMID
                ,Tbj11CrCreateData.EXPCDCONFFLG
                ,Tbj11CrCreateData.EXPCDCONFSIKCD
                ,Tbj11CrCreateData.EXPCDCONFHAMID
                ,Tbj11CrCreateData.EXPENSECONFFLG
                ,Tbj11CrCreateData.EXPENSECONFSIKCD
                ,Tbj11CrCreateData.EXPENSECONFHAMID
                ,Tbj11CrCreateData.DETAILCONFFLG
                ,Tbj11CrCreateData.DETAILCONFSIKCD
                ,Tbj11CrCreateData.DETAILCONFHAMID
                ,Tbj11CrCreateData.KIKANSCONFFLG
                ,Tbj11CrCreateData.KIKANSCONFSIKCD
                ,Tbj11CrCreateData.KIKANSCONFHAMID
                ,Tbj11CrCreateData.KIKANECONFFLG
                ,Tbj11CrCreateData.KIKANECONFSIKCD
                ,Tbj11CrCreateData.KIKANECONFHAMID
                ,Tbj11CrCreateData.CONTRACTDATECONFFLG
                ,Tbj11CrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj11CrCreateData.CONTRACTDATECONFHAMID
                ,Tbj11CrCreateData.CONTRACTTERMCONFFLG
                ,Tbj11CrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj11CrCreateData.CONTRACTTERMCONFHAMID
                ,Tbj11CrCreateData.SEIKYUCONFFLG
                ,Tbj11CrCreateData.SEIKYUCONFSIKCD
                ,Tbj11CrCreateData.SEIKYUCONFHAMID
                ,Tbj11CrCreateData.ORDERNOCONFFLG
                ,Tbj11CrCreateData.ORDERNOCONFSIKCD
                ,Tbj11CrCreateData.ORDERNOCONFHAMID
                ,Tbj11CrCreateData.PAYCONFFLG
                ,Tbj11CrCreateData.PAYCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFHAMID
                ,Tbj11CrCreateData.USERNAMECONFFLG
                ,Tbj11CrCreateData.USERNAMECONFSIKCD
                ,Tbj11CrCreateData.USERNAMECONFHAMID
                ,Tbj11CrCreateData.GETMONEYCONFFLG
                ,Tbj11CrCreateData.GETMONEYCONFSIKCD
                ,Tbj11CrCreateData.GETMONEYCONFHAMID
                ,Tbj11CrCreateData.GETCONFCONFFLG
                ,Tbj11CrCreateData.GETCONFCONFSIKCD
                ,Tbj11CrCreateData.GETCONFCONFHAMID
                ,Tbj11CrCreateData.PAYMONEYCONFFLG
                ,Tbj11CrCreateData.PAYMONEYCONFSIKCD
                ,Tbj11CrCreateData.PAYMONEYCONFHAMID
                ,Tbj11CrCreateData.PAYCONFCONFFLG
                ,Tbj11CrCreateData.PAYCONFCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFCONFHAMID
                ,Tbj11CrCreateData.ESTMONEYCONFFLG
                ,Tbj11CrCreateData.ESTMONEYCONFSIKCD
                ,Tbj11CrCreateData.ESTMONEYCONFHAMID
                ,Tbj11CrCreateData.CLMMONEYCONFFLG
                ,Tbj11CrCreateData.CLMMONEYCONFSIKCD
                ,Tbj11CrCreateData.CLMMONEYCONFHAMID
                ,Tbj11CrCreateData.DELIVERDAYCONFFLG
                ,Tbj11CrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj11CrCreateData.DELIVERDAYCONFHAMID
                ,Tbj11CrCreateData.SETMONTHCONFFLG
                ,Tbj11CrCreateData.SETMONTHCONFSIKCD
                ,Tbj11CrCreateData.SETMONTHCONFHAMID
                ,Tbj11CrCreateData.DIVISIONCONFFLG
                ,Tbj11CrCreateData.DIVISIONCONFSIKCD
                ,Tbj11CrCreateData.DIVISIONCONFHAMID
                ,Tbj11CrCreateData.GROUPCDCONFFLG
                ,Tbj11CrCreateData.GROUPCDCONFSIKCD
                ,Tbj11CrCreateData.GROUPCDCONFHAMID
                ,Tbj11CrCreateData.STKYKNOCONFFLG
                ,Tbj11CrCreateData.STKYKNOCONFSIKCD
                ,Tbj11CrCreateData.STKYKNOCONFHAMID
                ,Tbj11CrCreateData.STTNTNMCONFFLG
                ,Tbj11CrCreateData.STTNTNMCONFSIKCD
                ,Tbj11CrCreateData.STTNTNMCONFHAMID
                ,Tbj11CrCreateData.EGTYKCONFFLG
                ,Tbj11CrCreateData.EGTYKCONFSIKCD
                ,Tbj11CrCreateData.EGTYKCONFHAMID
                ,Tbj11CrCreateData.INPUTTNTCDCONFFLG
                ,Tbj11CrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj11CrCreateData.INPUTTNTCDCONFHAMID
                ,Tbj11CrCreateData.CPTNTNMCONFFLG
                ,Tbj11CrCreateData.CPTNTNMCONFSIKCD
                ,Tbj11CrCreateData.CPTNTNMCONFHAMID
                ,Tbj11CrCreateData.NOTECONFFLG
                ,Tbj11CrCreateData.NOTECONFSIKCD
                ,Tbj11CrCreateData.NOTECONFHAMID
                ,Tbj11CrCreateData.CRTDATE
                ,Tbj11CrCreateData.CRTNM
                ,Tbj11CrCreateData.CRTAPL
                ,Tbj11CrCreateData.CRTID
                ,Tbj11CrCreateData.UPDDATE
                ,Tbj11CrCreateData.UPDNM
                ,Tbj11CrCreateData.UPDAPL
                ,Tbj11CrCreateData.UPDID
                ,Mbj30InputTnt.INPUTTNT
        };
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

        if (_SelSqlMode.equals(SelSqlMode.NOINPUT)) {

            // CR制作費管理(受注No未入力)
            sql.append("SELECT ");
            //全項目を取得
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append(getTableColumnNames()[i]);
                if (i < getTableColumnNames().length-1) {
                    sql.append(", ");
                }
            }
            sql.append(" FROM ");
            sql.append(Tbj11CrCreateData.TBNAME);
            sql.append(", ");
            sql.append(Mbj30InputTnt.TBNAME);
            sql.append(", ");
            sql.append(Mbj05Car.TBNAME);
            sql.append(", ");
            sql.append(Mbj11CarSec.TBNAME);

            sql.append(" WHERE ");
            sql.append(Mbj30InputTnt.PHASE);
            sql.append(" = ");
            sql.append(Tbj11CrCreateData.PHASE);
            sql.append(" AND ");
            sql.append(Mbj30InputTnt.CLASSDIV);
            sql.append(" = ");
            sql.append(Tbj11CrCreateData.CLASSDIV);
            sql.append(" AND ");
            sql.append(Mbj30InputTnt.SEQNO);
            sql.append(" = ");
            sql.append(Tbj11CrCreateData.INPUTTNTCD);
            sql.append(" AND ");
            sql.append(Mbj30InputTnt.INPUTTNT);
            sql.append(" = '");
            sql.append(_condition.getInputIntNm());
            sql.append("'");
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.PHASE);
            sql.append(" = ");
            sql.append(_condition.getPhase());
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.CRDATE);
            sql.append(" = TRUNC(SYSDATE, 'MM')");
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.ORDERNO);
            sql.append(" IS NULL");
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.STPKBN);
            sql.append(" = '0'");

            // 車種マスタ連結
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.DCARCD);
            sql.append(" = ");
            sql.append(Mbj05Car.DCARCD);
            sql.append(" AND ");
            sql.append(Mbj05Car.DISPSTS);
            sql.append(" = ");
            sql.append("'1'");
            sql.append(" AND ");
            sql.append(Mbj05Car.DCARCD);
            sql.append(" = ");
            sql.append(Mbj11CarSec.DCARCD);
            sql.append(" AND ");
            sql.append(Mbj11CarSec.SECTYPE);
            sql.append(" = ");
            sql.append("'1'");
            sql.append(" AND ");
            sql.append(Mbj11CarSec.HAMID);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condition.getHamID());
            sql.append("'");
            sql.append(" AND ");
            sql.append(Mbj11CarSec.AUTHORITY);
            sql.append(" <> ");
            sql.append("'0'");

        } else if (_SelSqlMode.equals(SelSqlMode.UPDATED)) {
            StringBuffer sql1 = new StringBuffer();
            StringBuffer sql2 = new StringBuffer();
            StringBuffer sql3 = new StringBuffer();

            // CR制作費管理(変更データ)
            sql1.append("SELECT ");
            sql1.append(Tbj11CrCreateData.DCARCD);
            sql1.append(", ");
            sql1.append(Tbj11CrCreateData.PHASE);
            sql1.append(", ");
            sql1.append(Tbj11CrCreateData.CRDATE);
            sql1.append(", ");
            sql1.append("COUNT(*) CNT");
            sql1.append(", ");
            sql1.append("MIN(");
            sql1.append(Mbj05Car.CARNM);
            sql1.append(") ");
            sql1.append(Mbj05Car.CARNM);

            sql1.append(" FROM ");
            sql1.append(Tbj11CrCreateData.TBNAME);
            sql1.append(", ");
            sql1.append(Mbj05Car.TBNAME);
            sql1.append(", ");
            sql1.append(Mbj11CarSec.TBNAME);

            sql1.append(" WHERE ");
            sql1.append(Tbj11CrCreateData.STPKBN);
            sql1.append(" = '0'");
            sql1.append(" AND ");
            sql1.append(Tbj11CrCreateData.PHASE);
            sql1.append(" = ");
            sql1.append(_condition.getPhase());
            sql1.append(" AND ");
            sql1.append(Tbj11CrCreateData.CRDATE);
            sql1.append(" = TRUNC(SYSDATE, 'MM')");

            // 車種マスタ連結
            sql2.append(" AND ");
            sql2.append(Tbj11CrCreateData.DCARCD);
            sql2.append(" = ");
            sql2.append(Mbj05Car.DCARCD);
            sql2.append(" AND ");
            sql2.append(Mbj05Car.DISPSTS);
            sql2.append(" = ");
            sql2.append("'1'");
            sql2.append(" AND ");
            sql2.append(Mbj05Car.DCARCD);
            sql2.append(" = ");
            sql2.append(Mbj11CarSec.DCARCD);
            sql2.append(" AND ");
            sql2.append(Mbj11CarSec.SECTYPE);
            sql2.append(" = ");
            sql2.append("'1'");
            sql2.append(" AND ");
            sql2.append(Mbj11CarSec.HAMID);
            sql2.append(" = ");
            sql2.append("'");
            sql2.append(_condition.getHamID());
            sql2.append("'");
            sql2.append(" AND ");
            sql2.append(Mbj11CarSec.AUTHORITY);
            sql2.append(" <> ");
            sql2.append("'0'");

            // アラート表示制御マスタ存在
            sql2.append(" AND ");
            sql2.append("EXISTS(");

            sql2.append(" SELECT *");

            sql2.append(" FROM ");
            sql2.append(Mbj41AlertDispControl.TBNAME);

            sql2.append(" WHERE ");
            sql2.append(Mbj41AlertDispControl.DISPTYPE);
            sql2.append(" = ");
            sql2.append("'01'");
            sql2.append(" AND ");
            sql2.append(Mbj41AlertDispControl.SIKOGNZUNTCD);
            sql2.append(" = ");
            sql2.append("'");
            sql2.append(_condition.getSikCd());
            sql2.append("'");

            // 確認有無判断
            sql2.append(" AND (");
            if (_condition.getIsAmKyk()) {
                // AM局は全項目を対象とする
                appendCondition(sql2, Tbj11CrCreateData.CLASSCDCONFFLG, Tbj11CrCreateData.CLASSCDCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.EXPCDCONFFLG, Tbj11CrCreateData.EXPCDCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.EXPENSECONFFLG, Tbj11CrCreateData.EXPENSECONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.DETAILCONFFLG, Tbj11CrCreateData.DETAILCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.KIKANSCONFFLG, Tbj11CrCreateData.KIKANSCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.KIKANECONFFLG, Tbj11CrCreateData.KIKANECONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.CONTRACTDATECONFFLG, Tbj11CrCreateData.CONTRACTDATECONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.CONTRACTTERMCONFFLG, Tbj11CrCreateData.CONTRACTTERMCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.SEIKYUCONFFLG, Tbj11CrCreateData.SEIKYUCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.ORDERNOCONFFLG, Tbj11CrCreateData.ORDERNOCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.PAYCONFFLG, Tbj11CrCreateData.PAYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.USERNAMECONFFLG, Tbj11CrCreateData.USERNAMECONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.GETMONEYCONFFLG, Tbj11CrCreateData.GETMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.GETCONFCONFFLG, Tbj11CrCreateData.GETCONFCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.PAYMONEYCONFFLG, Tbj11CrCreateData.PAYMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.PAYCONFCONFFLG, Tbj11CrCreateData.PAYCONFCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.ESTMONEYCONFFLG, Tbj11CrCreateData.ESTMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.CLMMONEYCONFFLG, Tbj11CrCreateData.CLMMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.DELIVERDAYCONFFLG, Tbj11CrCreateData.DELIVERDAYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.SETMONTHCONFFLG, Tbj11CrCreateData.SETMONTHCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.DIVISIONCONFFLG, Tbj11CrCreateData.DIVISIONCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.GROUPCDCONFFLG, Tbj11CrCreateData.GROUPCDCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.STKYKNOCONFFLG, Tbj11CrCreateData.STKYKNOCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.STTNTNMCONFFLG, Tbj11CrCreateData.STTNTNMCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.EGTYKCONFFLG, Tbj11CrCreateData.EGTYKCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.INPUTTNTCDCONFFLG, Tbj11CrCreateData.INPUTTNTCDCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.CPTNTNMCONFFLG, Tbj11CrCreateData.CPTNTNMCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.NOTECONFFLG, Tbj11CrCreateData.NOTECONFHAMID);
            } else {
                // AM局以外は一部の項目を対象とする
                appendCondition(sql2, Tbj11CrCreateData.EXPCDCONFFLG, Tbj11CrCreateData.EXPCDCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.EXPENSECONFFLG, Tbj11CrCreateData.EXPENSECONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.PAYCONFFLG, Tbj11CrCreateData.PAYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.GETMONEYCONFFLG, Tbj11CrCreateData.GETMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.CLMMONEYCONFFLG, Tbj11CrCreateData.CLMMONEYCONFHAMID);
                sql2.append(" OR ");
                appendCondition(sql2, Tbj11CrCreateData.DELIVERDAYCONFFLG, Tbj11CrCreateData.DELIVERDAYCONFHAMID);
            }
            sql2.append(" ) ");

            sql2.append(" AND ");
            sql2.append("(");
            sql2.append(Mbj41AlertDispControl.DCARCD);
            sql2.append(" = ");
            sql2.append("'");
            sql2.append(_condition.getDCarCdAll());
            sql2.append("'");
            sql2.append(" OR ");
            sql2.append(Tbj11CrCreateData.DCARCD);
            sql2.append(" = ");
            sql2.append(Mbj41AlertDispControl.DCARCD);
            sql2.append(")");

            sql2.append(")");

            sql3.append(" GROUP BY ");
            sql3.append(Tbj11CrCreateData.DCARCD);
            sql3.append(", ");
            sql3.append(Tbj11CrCreateData.PHASE);
            sql3.append(", ");
            sql3.append(Tbj11CrCreateData.CRDATE);
            sql3.append(" ORDER BY ");
            sql3.append("MIN(");
            sql3.append(Mbj05Car.SORTNO);
            sql3.append(")");
            sql3.append(", ");
            sql3.append(Tbj11CrCreateData.DCARCD);

            // SQL文を連結
            sql.append(sql1);
            sql.append(sql2);
            sql.append(sql3);
        }

        return sql.toString();
    }

    /**
     * 条件式の追加
     * @param sql
     * @param confflg
     * @param sikcd
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
     * 指定した条件で検索を行い、データを取得します
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<NoInputOrderNoVo> selectNoInputOrderNo(FindMainMenuCondition condition) throws HAMException {

        super.setModel(new NoInputOrderNoVo());

        try {
            _condition = condition;
            _SelSqlMode = SelSqlMode.NOINPUT;
            return (List<NoInputOrderNoVo>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 変更したデータの検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<UpdatedCrVO> selectUpdatedCr(FindMainMenuCondition condition) throws HAMException {

        super.setModel(new UpdatedCrVO());

        try {
            _condition = condition;
            _SelSqlMode = SelSqlMode.UPDATED;
            return (List<UpdatedCrVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
