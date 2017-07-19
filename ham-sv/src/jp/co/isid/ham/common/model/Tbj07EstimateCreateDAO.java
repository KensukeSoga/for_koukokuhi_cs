package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 見積案件CR制作費DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj07EstimateCreateDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj07EstimateCreateCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj07EstimateCreateDAO() {
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
                Tbj07EstimateCreate.ESTDETAILSEQNO
                ,Tbj07EstimateCreate.DCARCD
                ,Tbj07EstimateCreate.PHASE
                ,Tbj07EstimateCreate.CRDATE
                ,Tbj07EstimateCreate.SEQUENCENO
                ,Tbj07EstimateCreate.CLASSDIV
                ,Tbj07EstimateCreate.SORTNO
                ,Tbj07EstimateCreate.CLASSCD
                ,Tbj07EstimateCreate.EXPCD
                ,Tbj07EstimateCreate.EXPENSE
                ,Tbj07EstimateCreate.DETAIL
                ,Tbj07EstimateCreate.KIKANS
                ,Tbj07EstimateCreate.KIKANE
                ,Tbj07EstimateCreate.CONTRACTDATE
                ,Tbj07EstimateCreate.CONTRACTTERM
                ,Tbj07EstimateCreate.SEIKYU
                ,Tbj07EstimateCreate.ORDERNO
                ,Tbj07EstimateCreate.PAY
                ,Tbj07EstimateCreate.USERNAME
                ,Tbj07EstimateCreate.GETMONEY
                ,Tbj07EstimateCreate.GETCONF
                ,Tbj07EstimateCreate.PAYMONEY
                ,Tbj07EstimateCreate.PAYCONF
                ,Tbj07EstimateCreate.ESTMONEY
                ,Tbj07EstimateCreate.CLMMONEY
                ,Tbj07EstimateCreate.DELIVERDAY
                ,Tbj07EstimateCreate.SETMONTH
                ,Tbj07EstimateCreate.DIVCD
                ,Tbj07EstimateCreate.GROUPCD
                ,Tbj07EstimateCreate.STKYKNO
                ,Tbj07EstimateCreate.EGTYKFLG
                ,Tbj07EstimateCreate.INPUTTNTCD
                ,Tbj07EstimateCreate.NOTE
                ,Tbj07EstimateCreate.CLASSCDFLG
                ,Tbj07EstimateCreate.EXPCDFLG
                ,Tbj07EstimateCreate.EXPENSEFLG
                ,Tbj07EstimateCreate.DETAILFLG
                ,Tbj07EstimateCreate.KIKANSFLG
                ,Tbj07EstimateCreate.KIKANEFLG
                ,Tbj07EstimateCreate.CONTRACTDATEFLG
                ,Tbj07EstimateCreate.CONTRACTTERMFLG
                ,Tbj07EstimateCreate.SEIKYUFLG
                ,Tbj07EstimateCreate.ORDERNOFLG
                ,Tbj07EstimateCreate.PAYFLG
                ,Tbj07EstimateCreate.USERNAMEFLG
                ,Tbj07EstimateCreate.GETMONEYFLG
                ,Tbj07EstimateCreate.PAYMONEYFLG
                ,Tbj07EstimateCreate.ESTMONEYFLG
                ,Tbj07EstimateCreate.CLMMONEYFLG
                ,Tbj07EstimateCreate.DELIVERDAYFLG
                ,Tbj07EstimateCreate.SETMONTHFLG
                ,Tbj07EstimateCreate.DIVISIONFLG
                ,Tbj07EstimateCreate.GROUPCDFLG
                ,Tbj07EstimateCreate.STKYKNOFLG
                ,Tbj07EstimateCreate.INPUTTNTCDFLG
                ,Tbj07EstimateCreate.NOTEFLG
                ,Tbj07EstimateCreate.CRTDATE
                ,Tbj07EstimateCreate.CRTNM
                ,Tbj07EstimateCreate.CRTAPL
                ,Tbj07EstimateCreate.CRTID
                ,Tbj07EstimateCreate.UPDDATE
                ,Tbj07EstimateCreate.UPDNM
                ,Tbj07EstimateCreate.UPDAPL
                ,Tbj07EstimateCreate.UPDID
                ,Tbj07EstimateCreate.GETTIME
                ,Tbj07EstimateCreate.TIMSTMPSS
                ,Tbj07EstimateCreate.UPDAPLSS
                ,Tbj07EstimateCreate.UPDIDSS
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        sql.append("DELETE FROM ");
        sql.append(Tbj07EstimateCreate.TBNAME);
        sql.append(" WHERE ");

        if (!_condition.getEstdetailseqno().equals(BigDecimal.valueOf(0))) {
            sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstdetailseqno());
        }
        else
        {
            sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
            sql.append(" IN (");
            sql.append("SELECT ");
            sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
            sql.append(" FROM ");
            sql.append(Tbj06EstimateDetail.TBNAME);
            sql.append(" WHERE ");
            sql.append(Tbj06EstimateDetail.PHASE);
            sql.append(" = ");
            sql.append(_condition.getPhase());
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.CRDATE);
            sql.append(" = ");
            sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.ESTSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstseqno());
            sql.append(")");
        }

        return sql.toString();
    }

    /**
     * 見積案件CR制作費を削除します
     * @param condition 削除条件
     * @throws HAMException
     */
    public void deleteEstimateCreate(Tbj07EstimateCreateCondition condition) throws HAMException {
        try {
            _condition = condition;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
