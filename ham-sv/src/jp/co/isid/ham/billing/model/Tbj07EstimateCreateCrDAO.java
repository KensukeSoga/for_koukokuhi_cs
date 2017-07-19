package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Tbj07EstimateCreateCondition;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 見積案件CR制作費作成(CR制作費管理)DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class Tbj07EstimateCreateCrDAO extends AbstractRdbDao {

    Tbj07EstimateCreateCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj07EstimateCreateCrDAO() {
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
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
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

        sql.append("INSERT INTO ");
        sql.append(Tbj07EstimateCreate.TBNAME);

        sql.append(" SELECT ");
        sql.append(_condition.getEstdetailseqno());
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DCARCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PHASE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SEQUENCENO);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CLASSDIV);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SORTNO);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CLASSCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.EXPCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.EXPENSE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DETAIL);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.KIKANS);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.KIKANE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CONTRACTDATE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CONTRACTTERM);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SEIKYU);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.ORDERNO);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PAY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.USERNAME);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.GETMONEY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.GETCONF);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PAYMONEY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PAYCONF);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.ESTMONEY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CLMMONEY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DELIVERDAY);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SETMONTH);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DIVCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.GROUPCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.STKYKNO);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.EGTYKFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.INPUTTNTCD);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.NOTE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CLASSCDFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.EXPCDFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.EXPENSEFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DETAILFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.KIKANSFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.KIKANEFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CONTRACTDATEFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CONTRACTTERMFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SEIKYUFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.ORDERNOFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PAYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.USERNAMEFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.GETMONEYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.PAYMONEYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.ESTMONEYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CLMMONEYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DELIVERDAYFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.SETMONTHFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DIVISIONFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.GROUPCDFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.STKYKNOFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.INPUTTNTCDFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.NOTEFLG);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CRTDATE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CRTNM);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CRTAPL);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.CRTID);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDDATE);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDNM);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDAPL);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDID);
        sql.append(", ");
        sql.append("SYSDATE");
        sql.append(", ");
        sql.append("SYSDATE");
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDAPL);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.UPDID);

        sql.append(" FROM ");
        sql.append(Tbj11CrCreateData.TBNAME);

        sql.append(" WHERE ");
        sql.append(Tbj11CrCreateData.DCARCD);
        sql.append(" = '");
        sql.append(_condition.getDcarcd());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" = ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.SEQUENCENO);
        sql.append(" = ");
        sql.append(_condition.getSequenceno());
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.STPKBN);
        sql.append(" = ");
        sql.append(" '0' ");

        return sql.toString();
    }

    /**
     * 見積案件CR制作費を作成します
     * @param condition 検索条件
     * @throws HAMException
     */
    public void insertEstimateCreate(Tbj07EstimateCreateCondition condition) throws HAMException {
        try {
            _condition = condition;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
