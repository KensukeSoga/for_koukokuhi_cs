package jp.co.isid.ham.billing.model;

import java.util.List;

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
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HC見積作成(制作費取込)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateCreationCaptureDAO extends AbstractRdbDao {

    FindHCEstimateCreationCaptureCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateCreationCaptureDAO() {
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
        return new String[]{
                Tbj22SeisakuhiSs.DCARCD
                ,Tbj22SeisakuhiSs.PHASE
                ,Tbj22SeisakuhiSs.CRDATE
                ,Tbj22SeisakuhiSs.SEQUENCENO
                ,Tbj22SeisakuhiSs.CLASSDIV
                ,Tbj22SeisakuhiSs.SORTNO
                ,Mbj15CrClass.CLASSNM
                ,Tbj22SeisakuhiSs.EXPCD
                ,Mbj16CrExpence.EXPNM
                ,Tbj22SeisakuhiSs.EXPENSE
                ,Tbj22SeisakuhiSs.DETAIL
                ,Tbj22SeisakuhiSs.KIKANS
                ,Tbj22SeisakuhiSs.KIKANE
                ,Tbj22SeisakuhiSs.CONTRACTDATE
                ,Tbj22SeisakuhiSs.CONTRACTTERM
                ,Tbj22SeisakuhiSs.SEIKYU
                ,Tbj22SeisakuhiSs.ORDERNO
                ,Tbj22SeisakuhiSs.PAY
                ,Tbj22SeisakuhiSs.USERNAME
                ,"NVL(" + Tbj22SeisakuhiSs.GETMONEY + ", 0) " + Tbj22SeisakuhiSs.GETMONEY
                ,"NVL(" + Tbj22SeisakuhiSs.GETCONF + ", '0') " + Tbj22SeisakuhiSs.GETCONF
                ,"NVL(" + Tbj22SeisakuhiSs.PAYMONEY + ", 0) " + Tbj22SeisakuhiSs.PAYMONEY
                ,"NVL(" + Tbj22SeisakuhiSs.PAYCONF + ", '0') " + Tbj22SeisakuhiSs.PAYCONF
                ,"NVL(" + Tbj22SeisakuhiSs.ESTMONEY + ", 0) " + Tbj22SeisakuhiSs.ESTMONEY
                ,"NVL(" + Tbj22SeisakuhiSs.CLMMONEY + ", 0) " + Tbj22SeisakuhiSs.CLMMONEY
                ,Tbj22SeisakuhiSs.DELIVERDAY
                ,Tbj22SeisakuhiSs.SETMONTH
                ,Mbj17CrDivision.DIVNM
                ,"NVL(" + Tbj22SeisakuhiSs.GROUPCD + ", 0) " + Tbj22SeisakuhiSs.GROUPCD
                ,Mbj26BillGroup.GROUPNM
                ,Mbj26BillGroup.GROUPNMRPT
                ,"NVL(" + Tbj22SeisakuhiSs.STKYKNO + ", '') " + Tbj22SeisakuhiSs.STKYKNO
                ,"NVL(" + Mbj29SetteiKyk.STKYKNM + ", '') " + Mbj29SetteiKyk.STKYKNM
                ,"NVL(" + Tbj22SeisakuhiSs.EGTYKFLG + ", 0) " + Tbj22SeisakuhiSs.EGTYKFLG
                ,"NVL(" + Tbj22SeisakuhiSs.INPUTTNTCD + ", '') " + Tbj22SeisakuhiSs.INPUTTNTCD
                ,Mbj30InputTnt.INPUTTNT
                ,Tbj22SeisakuhiSs.NOTE
                ,"NVL(" + Tbj22SeisakuhiSs.CLASSCDFLG + ", '0') " + Tbj22SeisakuhiSs.CLASSCDFLG
                ,"NVL(" + Tbj22SeisakuhiSs.EXPCDFLG + ", '0') " + Tbj22SeisakuhiSs.EXPCDFLG
                ,"NVL(" + Tbj22SeisakuhiSs.EXPENSEFLG + ", '0') " + Tbj22SeisakuhiSs.EXPENSEFLG
                ,"NVL(" + Tbj22SeisakuhiSs.DETAILFLG + ", '0') " + Tbj22SeisakuhiSs.DETAILFLG
                ,"NVL(" + Tbj22SeisakuhiSs.KIKANSFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANSFLG
                ,"NVL(" + Tbj22SeisakuhiSs.KIKANEFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANEFLG
                ,"NVL(" + Tbj22SeisakuhiSs.CONTRACTDATEFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTDATEFLG
                ,"NVL(" + Tbj22SeisakuhiSs.CONTRACTTERMFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTTERMFLG
                ,"NVL(" + Tbj22SeisakuhiSs.SEIKYUFLG + ", '0') " + Tbj22SeisakuhiSs.SEIKYUFLG
                ,"NVL(" + Tbj22SeisakuhiSs.ORDERNOFLG + ", '0') " + Tbj22SeisakuhiSs.ORDERNOFLG
                ,"NVL(" + Tbj22SeisakuhiSs.PAYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.USERNAMEFLG + ", '0') " + Tbj22SeisakuhiSs.USERNAMEFLG
                ,"NVL(" + Tbj22SeisakuhiSs.GETMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.GETMONEYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.PAYMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYMONEYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.ESTMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.ESTMONEYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.CLMMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.CLMMONEYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.DELIVERDAYFLG + ", '0') " + Tbj22SeisakuhiSs.DELIVERDAYFLG
                ,"NVL(" + Tbj22SeisakuhiSs.SETMONTHFLG + ", '0') " + Tbj22SeisakuhiSs.SETMONTHFLG
                ,"NVL(" + Tbj22SeisakuhiSs.DIVISIONFLG + ", '0') " + Tbj22SeisakuhiSs.DIVISIONFLG
                ,"NVL(" + Tbj22SeisakuhiSs.GROUPCDFLG + ", '0') " + Tbj22SeisakuhiSs.GROUPCDFLG
                ,"NVL(" + Tbj22SeisakuhiSs.STKYKNOFLG + ", '0') " + Tbj22SeisakuhiSs.STKYKNOFLG
                ,"NVL(" + Tbj22SeisakuhiSs.INPUTTNTCDFLG + ", '0') " + Tbj22SeisakuhiSs.INPUTTNTCDFLG
                ,"NVL(" + Tbj22SeisakuhiSs.NOTEFLG + ", '0') " + Tbj22SeisakuhiSs.NOTEFLG
                ,Tbj22SeisakuhiSs.CRTDATE
                ,Tbj22SeisakuhiSs.CRTNM
                ,Tbj22SeisakuhiSs.CRTAPL
                ,Tbj22SeisakuhiSs.CRTID
                ,Tbj22SeisakuhiSs.UPDDATE
                ,Tbj22SeisakuhiSs.UPDNM
                ,Tbj22SeisakuhiSs.UPDAPL
                ,Tbj22SeisakuhiSs.UPDID
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

        tbl.append(Tbj22SeisakuhiSs.TBNAME);
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
        sql.append(Tbj22SeisakuhiSs.CLASSCD);
        sql.append(" = ");
        sql.append(Mbj15CrClass.CLASSCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" >= ");
        sql.append(Mbj15CrClass.DATEFROM);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" <= ");
        sql.append(Mbj15CrClass.DATETO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = ");
        sql.append(Mbj16CrExpence.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.EXPCD);
        sql.append(" = ");
        sql.append(Mbj16CrExpence.EXPCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" >= ");
        sql.append(Mbj16CrExpence.DATEFROM);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" <= ");
        sql.append(Mbj16CrExpence.DATETO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(" = ");
        sql.append(Mbj17CrDivision.DIVCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" = ");
        sql.append(Mbj26BillGroup.GROUPCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.STKYKNO);
        sql.append(" = ");
        sql.append(Mbj29SetteiKyk.STKYKNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Mbj29SetteiKyk.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());

        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.PHASE);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.INPUTTNTCD);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.SEQNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append(Mbj30InputTnt.DCARCD);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = '");
        sql.append(_condition.getDCarCd());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(" = '");
        sql.append(_condition.getDivCd());
        sql.append("'");

        if (_condition.getGroupCd() == null) {
            sql.append(" AND ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" = ''");
        } else {
            sql.append(" AND ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" = '");
            sql.append(_condition.getGroupCd());
            sql.append("'");
        }

        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = '");
        sql.append(_condition.getClassDiv());
        sql.append("'");
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
    public List<FindHCEstimateCreationCaptureVO> selectVO(FindHCEstimateCreationCaptureCondition condition) throws HAMException {
      //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCEstimateCreationCaptureVO());
        try
        {
            _condition = condition;
            return (List<FindHCEstimateCreationCaptureVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
