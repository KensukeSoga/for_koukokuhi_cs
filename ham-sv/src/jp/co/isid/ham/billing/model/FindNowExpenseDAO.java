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
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 作成時データ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindNowExpenseDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    FindExpenseChangeCheckCondition _cond = null;

    /** 明細見積管理No */
    private String _estDetailSeqno;

    /**
     * デフォルトコンストラクタ
     */
    public FindNowExpenseDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj11CrCreateData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj11CrCreateData.CRTDATE
                ,Tbj11CrCreateData.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj11CrCreateData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj11CrCreateData.CRDATE
                ,Mbj05Car.CARNM
                ,Tbj11CrCreateData.CLASSDIV
                ,Mbj16CrExpence.EXPNM
                ,Tbj11CrCreateData.EXPENSE
                ,Tbj11CrCreateData.DETAIL
                ,Tbj11CrCreateData.SEIKYU
                ,Tbj11CrCreateData.ORDERNO
                ,Tbj11CrCreateData.PAY
                ,Tbj11CrCreateData.USERNAME
                ,Tbj11CrCreateData.GETMONEY
                ,Tbj11CrCreateData.GETCONF
                ,Tbj11CrCreateData.PAYMONEY
                ,Tbj11CrCreateData.PAYCONF
                ,Tbj11CrCreateData.DELIVERDAY
                ,Tbj11CrCreateData.SETMONTH
                ,Mbj17CrDivision.DIVNM
                ,Mbj26BillGroup.GROUPNM
                ,Mbj29SetteiKyk.STKYKNM
                ,Tbj11CrCreateData.EGTYKFLG
                ,Mbj30InputTnt.INPUTTNT
                ,Tbj11CrCreateData.NOTE
                ,Tbj11CrCreateData.SEQUENCENO
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" (SELECT ");
        sql.append(" " + Mbj15CrClass.CLASSCD + ", ");
        sql.append(" " + Mbj15CrClass.CLASSNM + " ");
        sql.append(" FROM ");
        sql.append(" " + Mbj15CrClass.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj15CrClass.DATEFROM + " <= " + getDBModelInterface().ConvertToDBString(_cond.getDateS()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj15CrClass.DATETO + " >= " + getDBModelInterface().ConvertToDBString(_cond.getDateE()) + " ");
        sql.append(" )CL,");
        sql.append(" " + Mbj16CrExpence.TBNAME + ", ");
        sql.append(" " + Mbj17CrDivision.TBNAME + ", ");
        sql.append(" " + Mbj26BillGroup.TBNAME + ", ");
        sql.append(" " + Mbj29SetteiKyk.TBNAME + ", ");
        sql.append(" " + Mbj30InputTnt.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj11CrCreateData.CLASSCD + " =CL." + Mbj15CrClass.CLASSCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.CLASSDIV + " =" + Mbj16CrExpence.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.EXPCD + " =" + Mbj16CrExpence.EXPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.DIVCD + " =" + Mbj17CrDivision.DIVCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.GROUPCD + " =" + Mbj26BillGroup.GROUPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.STKYKNO + " =" + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.INPUTTNTCD + " =" + Mbj30InputTnt.SEQNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.CLASSDIV + " =" + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.DCARCD + " =" + Mbj30InputTnt.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATEFROM + "(+) <= " + getDBModelInterface().ConvertToDBString(_cond.getDateS()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATETO + "(+) >= " + getDBModelInterface().ConvertToDBString(_cond.getDateE()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj29SetteiKyk.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj30InputTnt.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.DCARCD + " = " + Mbj05Car.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.SEQUENCENO + " IN (" + _estDetailSeqno + ") ");
        sql.append(" AND ");
        sql.append(" " + Tbj11CrCreateData.STPKBN + " = '0' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj11CrCreateData.SEQUENCENO + ", ");
        sql.append(" " + Tbj11CrCreateData.CRTDATE + " DESC, ");
        sql.append(" " + Tbj11CrCreateData.SORTNO + " ");

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindNowExpenseVO> selectVO(FindExpenseChangeCheckCondition cond,String  estDetailSeqno) throws HAMException {

        super.setModel(new FindNowExpenseVO());
        try
        {
            _cond = cond;
            _estDetailSeqno = estDetailSeqno;
            return (List<FindNowExpenseVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
