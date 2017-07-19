package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj31CrBudgetPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj31CrBudgetPlanDAO extends AbstractSimpleRdbDao {

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{MULTIPK,};
    private SelSqlMode _SelSqlMode = null;

    /** 検索条件 */
//    private Tbj31CrBudgetPlanCondition _condition = null;
    private List<Tbj31CrBudgetPlanVO> _conditions = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj31CrBudgetPlanDAO() {
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
                Tbj31CrBudgetPlan.DCARCD
                ,Tbj31CrBudgetPlan.PHASE
                ,Tbj31CrBudgetPlan.CRDATE
                ,Tbj31CrBudgetPlan.CLASSCD
                ,Tbj31CrBudgetPlan.EXPCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj31CrBudgetPlan.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj31CrBudgetPlan.CRTDATE
                ,Tbj31CrBudgetPlan.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj31CrBudgetPlan.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj31CrBudgetPlan.DCARCD
                ,Tbj31CrBudgetPlan.PHASE
                ,Tbj31CrBudgetPlan.CRDATE
                ,Tbj31CrBudgetPlan.CLASSCD
                ,Tbj31CrBudgetPlan.EXPCD
                ,Tbj31CrBudgetPlan.BUDGET
                ,Tbj31CrBudgetPlan.CRTDATE
                ,Tbj31CrBudgetPlan.CRTNM
                ,Tbj31CrBudgetPlan.CRTAPL
                ,Tbj31CrBudgetPlan.CRTID
                ,Tbj31CrBudgetPlan.UPDDATE
                ,Tbj31CrBudgetPlan.UPDNM
                ,Tbj31CrBudgetPlan.UPDAPL
                ,Tbj31CrBudgetPlan.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        String sql = "";
        if (SelSqlMode.MULTIPK.equals(_SelSqlMode)) {
            sql = getSelectSQLForMultiPK();
        }
        return sql;
    }

    private String getSelectSQLForMultiPK() {

        StringBuffer sql = new StringBuffer();

        // *******************************************
        // 排他用SQL
        // *******************************************
        sql.append(" SELECT ");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            AbstractModel cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" ( ");
            for (int j = 0; j < getPrimryKeyNames().length; j++) {
                sql.append((j != 0 ? " AND " : " "));
                sql.append("" + getPrimryKeyNames()[j] +" ");
                sql.append(" = ");
                sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
            }
            sql.append(" ) ");
        }

        return sql.toString();
    }

    /**
     * PKを条件にして検索を行います(複数指定可)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj31CrBudgetPlanVO> selectByMultiPk(List<Tbj31CrBudgetPlanVO> cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj31CrBudgetPlanVO());
        try {
            _SelSqlMode = SelSqlMode.MULTIPK;
            _conditions = cond;
            return (List<Tbj31CrBudgetPlanVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Tbj31CrBudgetPlanVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean updateVO(Tbj31CrBudgetPlanVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            return super.update();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean deleteVO(Tbj31CrBudgetPlanVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            return super.remove();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }
}
