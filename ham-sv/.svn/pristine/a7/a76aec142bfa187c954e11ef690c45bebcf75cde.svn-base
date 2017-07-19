package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Tbj07EstimateCreateCondition;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 見積案件CR制作費作成(制作費取込)DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class Tbj07EstimateCreateCostDAO extends AbstractRdbDao {

    Tbj07EstimateCreateCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj07EstimateCreateCostDAO() {
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
       sql.append(Tbj22SeisakuhiSs.DCARCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PHASE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CRDATE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SEQUENCENO);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CLASSDIV);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SORTNO);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CLASSCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.EXPCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.EXPENSE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DETAIL);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.KIKANS);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.KIKANE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CONTRACTDATE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CONTRACTTERM);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SEIKYU);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.ORDERNO);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PAY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.USERNAME);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GETMONEY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GETCONF);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PAYMONEY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PAYCONF);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.ESTMONEY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CLMMONEY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DELIVERDAY);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SETMONTH);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DIVCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GROUPCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.STKYKNO);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.EGTYKFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.INPUTTNTCD);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.NOTE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CLASSCDFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.EXPCDFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.EXPENSEFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DETAILFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.KIKANSFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.KIKANEFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CONTRACTDATEFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CONTRACTTERMFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SEIKYUFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.ORDERNOFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PAYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.USERNAMEFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GETMONEYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.PAYMONEYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.ESTMONEYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CLMMONEYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DELIVERDAYFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.SETMONTHFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.DIVISIONFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GROUPCDFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.STKYKNOFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.INPUTTNTCDFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.NOTEFLG);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CRTDATE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CRTNM);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CRTAPL);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.CRTID);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDDATE);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDNM);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDAPL);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDID);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.GETTIME);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.TIMSTMPSS);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDAPLSS);
       sql.append(", ");
       sql.append(Tbj22SeisakuhiSs.UPDIDSS);

       sql.append(" FROM ");
       sql.append(Tbj22SeisakuhiSs.TBNAME);

       sql.append(" WHERE ");
       sql.append(Tbj22SeisakuhiSs.DCARCD);
       sql.append(" = '");
       sql.append(_condition.getDcarcd());
       sql.append("'");
       sql.append(" AND ");
       sql.append(Tbj22SeisakuhiSs.PHASE);
       sql.append(" = ");
       sql.append(_condition.getPhase());
       sql.append(" AND ");
       sql.append(Tbj22SeisakuhiSs.CRDATE);
       sql.append(" = ");
       sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));
       sql.append(" AND ");
       sql.append(Tbj22SeisakuhiSs.SEQUENCENO);
       sql.append(" = ");
       sql.append(_condition.getSequenceno());

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
