package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 制作費取込DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj22SeisakuhiSsDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj22SeisakuhiSsCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj22SeisakuhiSsDAO() {
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
                Tbj22SeisakuhiSs.DCARCD
                ,Tbj22SeisakuhiSs.PHASE
                ,Tbj22SeisakuhiSs.CRDATE
                ,Tbj22SeisakuhiSs.SEQUENCENO
                ,Tbj22SeisakuhiSs.CLASSDIV
                ,Tbj22SeisakuhiSs.SORTNO
                ,Tbj22SeisakuhiSs.CLASSCD
                ,Tbj22SeisakuhiSs.EXPCD
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
                ,Tbj22SeisakuhiSs.GETMONEY
                ,Tbj22SeisakuhiSs.GETCONF
                ,Tbj22SeisakuhiSs.PAYMONEY
                ,Tbj22SeisakuhiSs.PAYCONF
                ,Tbj22SeisakuhiSs.ESTMONEY
                ,Tbj22SeisakuhiSs.CLMMONEY
                ,Tbj22SeisakuhiSs.DELIVERDAY
                ,Tbj22SeisakuhiSs.SETMONTH
                ,Tbj22SeisakuhiSs.DIVCD
                ,Tbj22SeisakuhiSs.GROUPCD
                ,Tbj22SeisakuhiSs.STKYKNO
                ,Tbj22SeisakuhiSs.EGTYKFLG
                ,Tbj22SeisakuhiSs.INPUTTNTCD
                ,Tbj22SeisakuhiSs.NOTE
                ,Tbj22SeisakuhiSs.CLASSCDFLG
                ,Tbj22SeisakuhiSs.EXPCDFLG
                ,Tbj22SeisakuhiSs.EXPENSEFLG
                ,Tbj22SeisakuhiSs.DETAILFLG
                ,Tbj22SeisakuhiSs.KIKANSFLG
                ,Tbj22SeisakuhiSs.KIKANEFLG
                ,Tbj22SeisakuhiSs.CONTRACTDATEFLG
                ,Tbj22SeisakuhiSs.CONTRACTTERMFLG
                ,Tbj22SeisakuhiSs.SEIKYUFLG
                ,Tbj22SeisakuhiSs.ORDERNOFLG
                ,Tbj22SeisakuhiSs.PAYFLG
                ,Tbj22SeisakuhiSs.USERNAMEFLG
                ,Tbj22SeisakuhiSs.GETMONEYFLG
                ,Tbj22SeisakuhiSs.PAYMONEYFLG
                ,Tbj22SeisakuhiSs.ESTMONEYFLG
                ,Tbj22SeisakuhiSs.CLMMONEYFLG
                ,Tbj22SeisakuhiSs.DELIVERDAYFLG
                ,Tbj22SeisakuhiSs.SETMONTHFLG
                ,Tbj22SeisakuhiSs.DIVISIONFLG
                ,Tbj22SeisakuhiSs.GROUPCDFLG
                ,Tbj22SeisakuhiSs.STKYKNOFLG
                ,Tbj22SeisakuhiSs.INPUTTNTCDFLG
                ,Tbj22SeisakuhiSs.NOTEFLG
                ,Tbj22SeisakuhiSs.CRTDATE
                ,Tbj22SeisakuhiSs.CRTNM
                ,Tbj22SeisakuhiSs.CRTAPL
                ,Tbj22SeisakuhiSs.CRTID
                ,Tbj22SeisakuhiSs.UPDDATE
                ,Tbj22SeisakuhiSs.UPDNM
                ,Tbj22SeisakuhiSs.UPDAPL
                ,Tbj22SeisakuhiSs.UPDID
                ,Tbj22SeisakuhiSs.GETTIME
                ,Tbj22SeisakuhiSs.TIMSTMPSS
                ,Tbj22SeisakuhiSs.UPDAPLSS
                ,Tbj22SeisakuhiSs.UPDIDSS
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
        sql.append(Tbj22SeisakuhiSs.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));

        return sql.toString();
    }

    /**
     * 制作費取込を削除します
     * @param condition 削除条件
     * @throws HAMException
     */
    public void deleteSeisakuhiSs(Tbj22SeisakuhiSsCondition condition) throws HAMException {
        try {
            _condition = condition;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 制作費取込を登録します
     * @param vo 登録データ
     * @throws HAMException
     */
    public void insertVo(Tbj22SeisakuhiSsVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
