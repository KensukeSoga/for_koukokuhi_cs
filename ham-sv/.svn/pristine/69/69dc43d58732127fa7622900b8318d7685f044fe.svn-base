package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 発注先マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMea10IrskDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private RepaVbjaMea10IrskCondition _condition = null;

    /** 廃止年月 */
    private static String ENDYM = "99999999";

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea10IrskDAO() {
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
        return RepaVbjaMea10Irsk.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMea10Irsk.IRSKCD
                ,RepaVbjaMea10Irsk.IRSKSUBCD
                ,RepaVbjaMea10Irsk.IRSKALASHYOJIKN
                ,RepaVbjaMea10Irsk.IRSKALASHYOJIKJ
                ,RepaVbjaMea10Irsk.TKALASHYOJIKN
                ,RepaVbjaMea10Irsk.TKALASHYOJIKJ
                ,RepaVbjaMea10Irsk.ATSHONBCD
                ,RepaVbjaMea10Irsk.ALASUSEFLG
                ,RepaVbjaMea10Irsk.TKALASUSEFLG
                ,RepaVbjaMea10Irsk.HOSOK
                ,RepaVbjaMea10Irsk.HKYMD
                ,RepaVbjaMea10Irsk.HAISYMD
                ,RepaVbjaMea10Irsk.INSDATE
                ,RepaVbjaMea10Irsk.INSTNTCD
                ,RepaVbjaMea10Irsk.INSAPLID
                ,RepaVbjaMea10Irsk.UPDAPLDATE
                ,RepaVbjaMea10Irsk.UPDTNTCD
                ,RepaVbjaMea10Irsk.UPDONLAPLID
                ,RepaVbjaMea10Irsk.UPDBATAPLID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        return getOrderDestinationByDateFlg();
    }

    /**
     * キーコード検索を行う
     * @return SQL文
     */
    private String getOrderDestinationByDateFlg() {

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
        sql.append(" " + RepaVbjaMea10Irsk.ALASUSEFLG + " ='" + _condition.getAlasuseflg() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.TKALASUSEFLG + " ='" + _condition.getTkalasuseflg() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HAISYMD + " ='" + ENDYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKCD + " ASC, ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKSUBCD + " ASC ");

        return sql.toString();
    }

    /**
     * 日付とフラグで検索を行う
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMea10IrskVO> FindOrderDestinationByDateFlg(RepaVbjaMea10IrskCondition cond) throws HAMException {

        super.setModel(new RepaVbjaMea10IrskVO());

        try {
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
