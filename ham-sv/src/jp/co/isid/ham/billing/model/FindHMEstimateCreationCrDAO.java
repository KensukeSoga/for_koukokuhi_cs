package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * CR制作費(HM)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateCreationCrDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMEstimateCreationCrCondition _condition;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMEstimateCreationCrDAO() {
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
        return new String[]{
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
                ,Tbj11CrCreateData.CLASSDIV
                ,Tbj11CrCreateData.SORTNO
                ,Mbj15CrClass.CLASSNM
                ,Tbj11CrCreateData.CLASSCD
                ,Tbj11CrCreateData.EXPCD
                ,Mbj16CrExpence.EXPNM
                ,Tbj11CrCreateData.EXPENSE
                ,Tbj11CrCreateData.DETAIL
                ,Tbj11CrCreateData.KIKANS
                ,Tbj11CrCreateData.KIKANE
                ,Tbj11CrCreateData.CONTRACTDATE
                ,Tbj11CrCreateData.CONTRACTTERM
                ,Tbj11CrCreateData.SEIKYU
                ,Tbj11CrCreateData.ORDERNO
                ,Tbj11CrCreateData.PAY
                ,Tbj11CrCreateData.USERNAME
                ,"NVL(" + Tbj11CrCreateData.GETMONEY + ", 0) " + Tbj11CrCreateData.GETMONEY
                ,"NVL(" + Tbj11CrCreateData.GETCONF + ", '0') " + Tbj11CrCreateData.GETCONF
                ,"NVL(" + Tbj11CrCreateData.PAYMONEY + ", 0) " + Tbj11CrCreateData.PAYMONEY
                ,"NVL(" + Tbj11CrCreateData.PAYCONF + ", '0') " + Tbj11CrCreateData.PAYCONF
                ,"NVL(" + Tbj11CrCreateData.ESTMONEY + ", 0) " + Tbj11CrCreateData.ESTMONEY
                ,"NVL(" + Tbj11CrCreateData.CLMMONEY + ", 0) " + Tbj11CrCreateData.CLMMONEY
                ,Tbj11CrCreateData.DELIVERDAY
                ,Tbj11CrCreateData.SETMONTH
                ,Tbj11CrCreateData.DIVCD
                ,Mbj17CrDivision.DIVNM
                ,"NVL(" + Tbj11CrCreateData.GROUPCD + ", 0) " + Tbj11CrCreateData.GROUPCD
                ,Mbj26BillGroup.GROUPNM
                ,Mbj26BillGroup.GROUPNMRPT
                ,"NVL(" + Tbj11CrCreateData.STKYKNO + ", '') " + Tbj11CrCreateData.STKYKNO
                ,"NVL(" + Mbj29SetteiKyk.STKYKNM + ", '') " + Mbj29SetteiKyk.STKYKNM
                ,Tbj11CrCreateData.EGTYKFLG
                ,Tbj11CrCreateData.INPUTTNTCD
                ,Mbj30InputTnt.INPUTTNT
                ,Tbj11CrCreateData.CPTNTNM
                ,Tbj11CrCreateData.NOTE
                ,"NVL(" + Tbj11CrCreateData.DCARCDFLG + ", '0') " + Tbj11CrCreateData.DCARCDFLG
                ,"NVL(" + Tbj11CrCreateData.CLASSCDFLG + ", '0') " + Tbj11CrCreateData.CLASSCDFLG
                ,"NVL(" + Tbj11CrCreateData.EXPCDFLG + ", '0') " + Tbj11CrCreateData.EXPCDFLG
                ,"NVL(" + Tbj11CrCreateData.EXPENSEFLG + ", '0') " + Tbj11CrCreateData.EXPENSEFLG
                ,"NVL(" + Tbj11CrCreateData.DETAILFLG + ", '0') " + Tbj11CrCreateData.KIKANSFLG
                ,"NVL(" + Tbj11CrCreateData.KIKANSFLG+ ", '0')" + Tbj11CrCreateData.KIKANSFLG
                ,"NVL(" + Tbj11CrCreateData.KIKANEFLG+ ", '0')" + Tbj11CrCreateData.KIKANEFLG
                ,"NVL(" + Tbj11CrCreateData.CONTRACTDATEFLG+ ", '0')" + Tbj11CrCreateData.CONTRACTDATEFLG
                ,"NVL(" + Tbj11CrCreateData.CONTRACTTERMFLG+ ", '0')" + Tbj11CrCreateData.CONTRACTTERMFLG
                ,"NVL(" + Tbj11CrCreateData.SEIKYUFLG+ ", '0')" + Tbj11CrCreateData.SEIKYUFLG
                ,"NVL(" + Tbj11CrCreateData.ORDERNOFLG+ ", '0')" + Tbj11CrCreateData.ORDERNOFLG
                ,"NVL(" + Tbj11CrCreateData.PAYFLG+ ", '0')" + Tbj11CrCreateData.PAYFLG
                ,"NVL(" + Tbj11CrCreateData.USERNAMEFLG+ ", '0')" + Tbj11CrCreateData.USERNAMEFLG
                ,"NVL(" + Tbj11CrCreateData.GETMONEYFLG+ ", '0')" + Tbj11CrCreateData.GETMONEYFLG
                ,"NVL(" + Tbj11CrCreateData.GETCONFIRMFLG+ ", '0')" + Tbj11CrCreateData.GETCONFIRMFLG
                ,"NVL(" + Tbj11CrCreateData.PAYMONEYFLG+ ", '0')" + Tbj11CrCreateData.PAYMONEYFLG
                ,"NVL(" + Tbj11CrCreateData.PAYCONFIRMFLG+ ", '0')" + Tbj11CrCreateData.PAYCONFIRMFLG
                ,"NVL(" + Tbj11CrCreateData.ESTMONEYFLG+ ", '0')" + Tbj11CrCreateData.ESTMONEYFLG
                ,"NVL(" + Tbj11CrCreateData.CLMMONEYFLG+ ", '0')" + Tbj11CrCreateData.CLMMONEYFLG
                ,"NVL(" + Tbj11CrCreateData.DELIVERDAYFLG+ ", '0')" + Tbj11CrCreateData.DELIVERDAYFLG
                ,"NVL(" + Tbj11CrCreateData.SETMONTHFLG+ ", '0')" + Tbj11CrCreateData.SETMONTHFLG
                ,"NVL(" + Tbj11CrCreateData.DIVISIONFLG+ ", '0')" + Tbj11CrCreateData.DIVISIONFLG
                ,"NVL(" + Tbj11CrCreateData.GROUPCDFLG+ ", '0')" + Tbj11CrCreateData.GROUPCDFLG
                ,"NVL(" + Tbj11CrCreateData.STKYKNOFLG+ ", '0')" + Tbj11CrCreateData.STKYKNOFLG
                ,"NVL(" + Tbj11CrCreateData.EGTYKFLGFLG+ ", '0')" + Tbj11CrCreateData.EGTYKFLGFLG
                ,"NVL(" + Tbj11CrCreateData.INPUTTNTCDFLG+ ", '0')" + Tbj11CrCreateData.INPUTTNTCDFLG
                ,"NVL(" + Tbj11CrCreateData.CPTNTNMFLG+ ", '0')" + Tbj11CrCreateData.CPTNTNMFLG
                ,"NVL(" + Tbj11CrCreateData.NOTEFLG+ ", '0')" + Tbj11CrCreateData.NOTEFLG
                ,"NVL(" + Tbj11CrCreateData.DCARCDCONFFLG+ ", '0')" + Tbj11CrCreateData.DCARCDCONFFLG
                ,Tbj11CrCreateData.DCARCDCONFSIKCD
                ,Tbj11CrCreateData.DCARCDCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.CLASSCDCONFFLG+ ", '0')" + Tbj11CrCreateData.CLASSCDCONFFLG
                ,Tbj11CrCreateData.CLASSCDCONFSIKCD
                ,Tbj11CrCreateData.CLASSCDCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.EXPCDCONFFLG+ ", '0')" + Tbj11CrCreateData.EXPCDCONFFLG
                ,Tbj11CrCreateData.EXPCDCONFSIKCD
                ,Tbj11CrCreateData.EXPCDCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.EXPENSECONFFLG+ ", '0')" + Tbj11CrCreateData.EXPENSECONFFLG
                ,Tbj11CrCreateData.EXPENSECONFSIKCD
                ,Tbj11CrCreateData.EXPENSECONFHAMID
                ,"NVL(" + Tbj11CrCreateData.DETAILCONFFLG+ ", '0')" + Tbj11CrCreateData.DETAILCONFFLG
                ,Tbj11CrCreateData.DETAILCONFSIKCD
                ,Tbj11CrCreateData.DETAILCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.KIKANSCONFFLG+ ", '0')" + Tbj11CrCreateData.KIKANSCONFFLG
                ,Tbj11CrCreateData.KIKANSCONFSIKCD
                ,Tbj11CrCreateData.KIKANSCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.KIKANECONFFLG+ ", '0')" + Tbj11CrCreateData.KIKANECONFFLG
                ,Tbj11CrCreateData.KIKANECONFSIKCD
                ,Tbj11CrCreateData.KIKANECONFHAMID
                ,"NVL(" + Tbj11CrCreateData.CONTRACTDATECONFFLG+ ", '0')" + Tbj11CrCreateData.CONTRACTDATECONFFLG
                ,Tbj11CrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj11CrCreateData.CONTRACTDATECONFHAMID
                ,"NVL(" + Tbj11CrCreateData.CONTRACTTERMCONFFLG+ ", '0')" + Tbj11CrCreateData.CONTRACTTERMCONFFLG
                ,Tbj11CrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj11CrCreateData.CONTRACTTERMCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.SEIKYUCONFFLG+ ", '0')" + Tbj11CrCreateData.SEIKYUCONFFLG
                ,Tbj11CrCreateData.SEIKYUCONFSIKCD
                ,Tbj11CrCreateData.SEIKYUCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.ORDERNOCONFFLG+ ", '0')" + Tbj11CrCreateData.ORDERNOCONFFLG
                ,Tbj11CrCreateData.ORDERNOCONFSIKCD
                ,Tbj11CrCreateData.ORDERNOCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.PAYCONFFLG+ ", '0')" + Tbj11CrCreateData.PAYCONFFLG
                ,Tbj11CrCreateData.PAYCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.USERNAMECONFFLG+ ", '0')" + Tbj11CrCreateData.USERNAMECONFFLG
                ,Tbj11CrCreateData.USERNAMECONFSIKCD
                ,Tbj11CrCreateData.USERNAMECONFHAMID
                ,"NVL(" + Tbj11CrCreateData.GETMONEYCONFFLG+ ", '0')" + Tbj11CrCreateData.GETMONEYCONFFLG
                ,Tbj11CrCreateData.GETMONEYCONFSIKCD
                ,Tbj11CrCreateData.GETMONEYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.GETCONFCONFFLG+ ", '0')" + Tbj11CrCreateData.GETCONFCONFFLG
                ,Tbj11CrCreateData.GETCONFCONFSIKCD
                ,Tbj11CrCreateData.GETCONFCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.PAYMONEYCONFFLG+ ", '0')" + Tbj11CrCreateData.PAYMONEYCONFFLG
                ,Tbj11CrCreateData.PAYMONEYCONFSIKCD
                ,Tbj11CrCreateData.PAYMONEYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.PAYCONFCONFFLG+ ", '0')" + Tbj11CrCreateData.PAYCONFCONFFLG
                ,Tbj11CrCreateData.PAYCONFCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.ESTMONEYCONFFLG+ ", '0')" + Tbj11CrCreateData.ESTMONEYCONFFLG
                ,Tbj11CrCreateData.ESTMONEYCONFSIKCD
                ,Tbj11CrCreateData.ESTMONEYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.CLMMONEYCONFFLG+ ", '0')" + Tbj11CrCreateData.CLMMONEYCONFFLG
                ,Tbj11CrCreateData.CLMMONEYCONFSIKCD
                ,Tbj11CrCreateData.CLMMONEYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.DELIVERDAYCONFFLG+ ", '0')" + Tbj11CrCreateData.DELIVERDAYCONFFLG
                ,Tbj11CrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj11CrCreateData.DELIVERDAYCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.SETMONTHCONFFLG+ ", '0')" + Tbj11CrCreateData.SETMONTHCONFFLG
                ,Tbj11CrCreateData.SETMONTHCONFSIKCD
                ,Tbj11CrCreateData.SETMONTHCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.DIVISIONCONFFLG+ ", '0')" + Tbj11CrCreateData.DIVISIONCONFFLG
                ,Tbj11CrCreateData.DIVISIONCONFSIKCD
                ,Tbj11CrCreateData.DIVISIONCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.GROUPCDCONFFLG+ ", '0')" + Tbj11CrCreateData.GROUPCDCONFFLG
                ,Tbj11CrCreateData.GROUPCDCONFSIKCD
                ,Tbj11CrCreateData.GROUPCDCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.STKYKNOCONFFLG+ ", '0')" + Tbj11CrCreateData.STKYKNOCONFFLG
                ,Tbj11CrCreateData.STKYKNOCONFSIKCD
                ,Tbj11CrCreateData.STKYKNOCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.EGTYKCONFFLG+ ", '0')" + Tbj11CrCreateData.EGTYKCONFFLG
                ,Tbj11CrCreateData.EGTYKCONFSIKCD
                ,Tbj11CrCreateData.EGTYKCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.INPUTTNTCDCONFFLG+ ", '0')" + Tbj11CrCreateData.INPUTTNTCDCONFFLG
                ,Tbj11CrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj11CrCreateData.INPUTTNTCDCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.CPTNTNMCONFFLG+ ", '0')" + Tbj11CrCreateData.CPTNTNMCONFFLG
                ,Tbj11CrCreateData.CPTNTNMCONFSIKCD
                ,Tbj11CrCreateData.CPTNTNMCONFHAMID
                ,"NVL(" + Tbj11CrCreateData.NOTECONFFLG+ ", '0')" + Tbj11CrCreateData.NOTECONFFLG
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
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj11CrCreateData.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj15CrClass.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj16CrExpence.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj17CrDivision.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj26BillGroup.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj29SetteiKyk.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj30InputTnt.TBNAME);

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
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(Tbj11CrCreateData.CLASSCD);
        sql.append(" = ");
        sql.append(Mbj15CrClass.CLASSCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" >= ");
        sql.append(Mbj15CrClass.DATEFROM);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" <= ");
        sql.append(Mbj15CrClass.DATETO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CLASSDIV);
        sql.append(" = ");
        sql.append(Mbj16CrExpence.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.EXPCD);
        sql.append(" = ");
        sql.append(Mbj16CrExpence.EXPCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" >= ");
        sql.append(Mbj16CrExpence.DATEFROM);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" <= ");
        sql.append(Mbj16CrExpence.DATETO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.DIVCD);
        sql.append(" = ");
        sql.append(Mbj17CrDivision.DIVCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.GROUPCD);
        sql.append(" = ");
        sql.append(Mbj26BillGroup.GROUPCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.STKYKNO);
        sql.append(" = ");
        sql.append(Mbj29SetteiKyk.STKYKNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Mbj29SetteiKyk.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());

        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.PHASE);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.PHASE);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CLASSDIV);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.INPUTTNTCD);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.SEQNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.DCARCD);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.DCARCD);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");

        if (_condition.getDCarCd() == null || _condition.getDCarCd().trim().length() == 0) {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.DCARCD);
            sql.append(" IS NULL ");
        } else {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.DCARCD);
            sql.append(" = '");
            sql.append(_condition.getDCarCd());
            sql.append("'");
        }

        if (_condition.getDivCd() == null || _condition.getDivCd().trim().length() == 0) {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.DIVCD);
            sql.append(" IS NULL ");
        } else {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.DIVCD);
            sql.append(" = '");
            sql.append(_condition.getDivCd());
            sql.append("'");
        }

        if (_condition.getGroupCd() == null || _condition.getDivCd().trim().length() == 0) {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.GROUPCD);
            sql.append(" IS NULL ");
        } else {
            sql.append(" AND ");
            sql.append(Tbj11CrCreateData.GROUPCD);
            sql.append(" = ");
            sql.append(_condition.getGroupCd());
        }

        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CLASSDIV);
        sql.append(" = '");
        sql.append(_condition.getClassDiv());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.STPKBN);
        sql.append(" = ");
        sql.append(" '0' ");

        sql.append(" ORDER BY ");
        sql.append(Tbj11CrCreateData.SORTNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMEstimateCreationCrVO> selectVO(FindHMEstimateCreationCrCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMEstimateCreationCrVO());

        try {
            _condition = condition;
            return (List<FindHMEstimateCreationCrVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
