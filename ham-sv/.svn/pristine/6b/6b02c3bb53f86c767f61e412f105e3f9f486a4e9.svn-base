package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
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
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class FindNowProductionDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    FindProductionChangeCheckCondition _cond = null;

    /** 明細見積管理No */
    private String _estDetailSeqno;

    /**
     * デフォルトコンストラクタ
     */
    public FindNowProductionDAO() {
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
                Tbj22SeisakuhiSs.DCARCD
                ,Tbj22SeisakuhiSs.PHASE
                ,Tbj22SeisakuhiSs.CRDATE
                ,Tbj22SeisakuhiSs.SEQUENCENO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj22SeisakuhiSs.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj22SeisakuhiSs.CRTDATE
                ,Tbj22SeisakuhiSs.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME;
    }


    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj22SeisakuhiSs.CRDATE
                ,Mbj05Car.CARNM
                ,Tbj22SeisakuhiSs.CLASSDIV
                ,Mbj16CrExpence.EXPNM
                ,Mbj15CrClass.CLASSNM
                ,Tbj22SeisakuhiSs.EXPENSE
                ,Tbj22SeisakuhiSs.DETAIL
                ,Tbj22SeisakuhiSs.KIKANS
                ,Tbj22SeisakuhiSs.KIKANE
                ,Tbj22SeisakuhiSs.CONTRACTDATE
                ,Tbj22SeisakuhiSs.CONTRACTTERM
                ,Tbj22SeisakuhiSs.ORDERNO
                ,Tbj22SeisakuhiSs.PAY
                ,Tbj22SeisakuhiSs.USERNAME
                ,Tbj22SeisakuhiSs.ESTMONEY
                ,Tbj22SeisakuhiSs.CLMMONEY
                ,Tbj22SeisakuhiSs.DELIVERDAY
                ,Tbj22SeisakuhiSs.SETMONTH
                ,Mbj17CrDivision.DIVNM
                ,Mbj26BillGroup.GROUPNM
                ,Mbj29SetteiKyk.STKYKNM
                ,Tbj22SeisakuhiSs.EGTYKFLG
                ,Mbj30InputTnt.INPUTTNT
                ,Tbj22SeisakuhiSs.NOTE
                ,Tbj22SeisakuhiSs.SEQUENCENO
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
        sql.append(" " + Tbj22SeisakuhiSs.CLASSCD + " =CL." + Mbj15CrClass.CLASSCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " =" + Mbj16CrExpence.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.EXPCD + " =" + Mbj16CrExpence.EXPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.DIVCD + " =" + Mbj17CrDivision.DIVCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.GROUPCD + " =" + Mbj26BillGroup.GROUPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.STKYKNO + " =" + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.INPUTTNTCD + " =" + Mbj30InputTnt.SEQNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.CLASSDIV + " =" + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " =" + Mbj30InputTnt.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATEFROM + "(+) <= " + getDBModelInterface().ConvertToDBString(_cond.getDateS()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATETO + "(+) >= " + getDBModelInterface().ConvertToDBString(_cond.getDateE()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj29SetteiKyk.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj30InputTnt.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.DCARCD + " =" + Mbj05Car.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj22SeisakuhiSs.SEQUENCENO + "  IN (" + _estDetailSeqno + ") ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj22SeisakuhiSs.SEQUENCENO + ", ");
        sql.append(" " + Tbj22SeisakuhiSs.GETTIME + " DESC, ");
        sql.append(" " + Tbj22SeisakuhiSs.SORTNO + " ");

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindNowProductionVO> selectVO(FindProductionChangeCheckCondition cond, String  estDetailSeqno) throws HAMException {

        super.setModel(new FindNowProductionVO());
        try
        {
            _cond = cond;
            _estDetailSeqno = estDetailSeqno;
            return (List<FindNowProductionVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
