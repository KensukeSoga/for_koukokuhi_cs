package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj11CrCreateDataCondition;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * CR制作費管理(制作費設定用)DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCrCreateDataForCmsDAO extends AbstractRdbDao {

    Tbj11CrCreateDataCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindCrCreateDataForCmsDAO() {
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
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
        };
    }

    /**
     * テーブル列名を取得する
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
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj11CrCreateData.TBNAME + ", " + Mbj05Car.TBNAME;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
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
        sql.append(Tbj11CrCreateData.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" AND ");
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1'");
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.CRDATE);
        sql.append(" = ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));
        sql.append(" AND ");
        sql.append(Tbj11CrCreateData.STPKBN);
        sql.append(" = ");
        sql.append(" '0' ");
        sql.append(" ORDER BY ");
        sql.append(Tbj11CrCreateData.CLASSDIV);
        sql.append(", ");
        sql.append(Tbj11CrCreateData.DCARCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> selectVO(Tbj11CrCreateDataCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try
        {
            _condition = condition;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
