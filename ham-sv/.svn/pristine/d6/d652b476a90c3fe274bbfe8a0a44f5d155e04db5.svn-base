package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新雑媒体マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu20MsMzBtDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private RepaVbjaMeu20MsMzBtCondition _condition = null;

    private enum SelSqlMode
            {
                DEF,
                MEDIANM
            }
    private SelSqlMode _selSqlMode = SelSqlMode.DEF;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu20MsMzBtDAO() {
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
        return null;
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
        return RepaVbjaMeu20MsMzBt.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu20MsMzBt.SZKBN
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD
                ,RepaVbjaMeu20MsMzBt.KBANCD
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK
                ,RepaVbjaMeu20MsMzBt.BTAISYAKCD
                ,RepaVbjaMeu20MsMzBt.BTAISYASEQNO
                ,RepaVbjaMeu20MsMzBt.KYUTRCD
                ,RepaVbjaMeu20MsMzBt.KHYOYMD
                ,RepaVbjaMeu20MsMzBt.JANR1
                ,RepaVbjaMeu20MsMzBt.JANR2
                ,RepaVbjaMeu20MsMzBt.JANR3
                ,RepaVbjaMeu20MsMzBt.CHUCHIKBN
                ,RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_selSqlMode.equals(SelSqlMode.DEF)) {

            // 検索用SQL取得
            sql = getSelectSQLDefault();

        } else if (_selSqlMode.equals(SelSqlMode.MEDIANM)) {

            // キーワード検索用SQL取得
            sql = getMediaByMediaNm();
        }

        return sql;
    }

    /**
     * 検索SQL取得
     * @return SQL文
     */
    private String getSelectSQLDefault()
    {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        sqlSelect.append("SELECT ");
        //全項目を取得
        for (int i = 0 ; i < getTableColumnNames().length ; i++)
        {
            sqlSelect.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length - 1)
            {
                sqlSelect.append(", ");
            }
        }
        sqlSelect.append(" FROM ");
        sqlSelect.append(getTableName());

        if (_condition != null)
        {
            RepaVbjaMeu20MsMzBtVO vo = new RepaVbjaMeu20MsMzBtVO();
            vo.setSZKBN(_condition.getSzkbn());
            vo.setSINZATSUBTAICD(_condition.getSinzatsubtaicd());
            vo.setKBANCD(_condition.getKbancd());
            vo.setSINZATSUBTAINMJ(_condition.getSinzatsubtainmj());
            vo.setSINZATSUBTAINMK(_condition.getSinzatsubtainmk());
            vo.setBTAISYAKCD(_condition.getBtaisyakcd());
            vo.setBTAISYASEQNO(_condition.getBtaisyaseqno());
            vo.setKYUTRCD(_condition.getKyutrcd());
            vo.setKHYOYMD(_condition.getKhyoymd());
            vo.setJANR1(_condition.getJanr1());
            vo.setJANR2(_condition.getJanr2());
            vo.setJANR3(_condition.getJanr3());
            vo.setCHUCHIKBN(_condition.getChuchikbn());
            vo.setSINBUNDAIGOCD(_condition.getSinbundaigocd());
            whereSqlStr = generateWhereByCond(vo);

        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * キーワード検索SQL取得
     * @return SQL文
     */
    private String getMediaByMediaNm() {

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
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ + " LIKE('%" + _condition.getSinzatsubtainmj() + "%')");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getSzkbn() + "' ");

        return sql.toString();
    }

    /**
     * 検索を行う
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu20MsMzBtVO> selectVO(RepaVbjaMeu20MsMzBtCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMeu20MsMzBtVO());

        try {
            _condition = cond;
            _selSqlMode = SelSqlMode.DEF;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キーワードで検索を行う
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu20MsMzBtVO> FindMediaByMediaNm(RepaVbjaMeu20MsMzBtCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMeu20MsMzBtVO());

        try {
            _condition = cond;
            _selSqlMode = SelSqlMode.MEDIANM;
            return super.find();
        }
        catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
