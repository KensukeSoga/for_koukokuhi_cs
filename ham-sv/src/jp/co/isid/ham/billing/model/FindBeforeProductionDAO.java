package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
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
public class FindBeforeProductionDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    FindProductionChangeCheckCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindBeforeProductionDAO() {
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
                Tbj07EstimateCreate.ESTDETAILSEQNO
                ,Tbj07EstimateCreate.DCARCD
                ,Tbj07EstimateCreate.PHASE
                ,Tbj07EstimateCreate.CRDATE
                ,Tbj07EstimateCreate.SEQUENCENO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj07EstimateCreate.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj07EstimateCreate.CRTDATE
                ,Tbj07EstimateCreate.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj07EstimateCreate.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj07EstimateCreate.CRDATE
                ,Mbj05Car.CARNM
                ,Tbj07EstimateCreate.CLASSDIV
                ,Mbj15CrClass.CLASSNM
                ,Mbj16CrExpence.EXPNM
                ,Tbj07EstimateCreate.EXPENSE
                ,Tbj07EstimateCreate.DETAIL
                ,Tbj07EstimateCreate.KIKANS
                ,Tbj07EstimateCreate.KIKANE
                ,Tbj07EstimateCreate.CONTRACTDATE
                ,Tbj07EstimateCreate.CONTRACTTERM
                ,Tbj07EstimateCreate.ORDERNO
                ,Tbj07EstimateCreate.PAY
                ,Tbj07EstimateCreate.USERNAME
                ,Tbj07EstimateCreate.ESTMONEY
                ,Tbj07EstimateCreate.CLMMONEY
                ,Tbj07EstimateCreate.DELIVERDAY
                ,Tbj07EstimateCreate.SETMONTH
                ,Mbj17CrDivision.DIVNM
                ,Mbj26BillGroup.GROUPNM
                ,Mbj29SetteiKyk.STKYKNM
                ,Tbj07EstimateCreate.EGTYKFLG
                ,Mbj30InputTnt.INPUTTNT
                ,Tbj07EstimateCreate.NOTE
                ,Tbj07EstimateCreate.SEQUENCENO
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
        sql.append(" " + Tbj07EstimateCreate.CLASSCD + " =CL." + Mbj15CrClass.CLASSCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.CLASSDIV + " =" + Mbj16CrExpence.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.EXPCD + " =" + Mbj16CrExpence.EXPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.DIVCD + " =" + Mbj17CrDivision.DIVCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.GROUPCD + " =" + Mbj26BillGroup.GROUPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.STKYKNO + " =" + Mbj29SetteiKyk.STKYKNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.INPUTTNTCD + " =" + Mbj30InputTnt.SEQNO + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.CLASSDIV + " =" + Mbj30InputTnt.CLASSDIV + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.DCARCD + " =" + Mbj30InputTnt.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATEFROM + " <= " + getDBModelInterface().ConvertToDBString(_cond.getDateS()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj16CrExpence.DATETO + " >= " + getDBModelInterface().ConvertToDBString(_cond.getDateE()) + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj29SetteiKyk.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj30InputTnt.PHASE + "(+) = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.DCARCD + " = " + Mbj05Car.DCARCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj07EstimateCreate.ESTDETAILSEQNO + " = '" + _cond.getEstDetailSeqNo() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj07EstimateCreate.SEQUENCENO + ", ");
        sql.append(" " + Tbj07EstimateCreate.SORTNO + " ");

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindBeforeProductionVO> selectVO(FindProductionChangeCheckCondition cond) throws HAMException {

        super.setModel(new FindBeforeProductionVO());
        try
        {
            _cond = cond;
            return (List<FindBeforeProductionVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
