package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 画面－業務区分DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMea12DisplayGyomKbnDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private RepaVbjaMea12DisplayGyomKbnCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea12DisplayGyomKbnDAO() {
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
        return RepaVbjaMea12DisplayGyomKbn.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMea12DisplayGyomKbn.JYUCTYPE
                ,RepaVbjaMea12DisplayGyomKbn.IRSKCD
                ,RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD
                ,RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD
                ,RepaVbjaMea12DisplayGyomKbn.GYOMKBNSHOWNO
                ,RepaVbjaMea12DisplayGyomKbn.KISEKBN
                ,RepaVbjaMea12DisplayGyomKbn.HKYMD
                ,RepaVbjaMea12DisplayGyomKbn.HAISYMD
                ,RepaVbjaMea12DisplayGyomKbn.INSDATE
                ,RepaVbjaMea12DisplayGyomKbn.INSTNTCD
                ,RepaVbjaMea12DisplayGyomKbn.INSAPLID
                ,RepaVbjaMea12DisplayGyomKbn.UPDAPLDATE
                ,RepaVbjaMea12DisplayGyomKbn.UPDTNTCD
                ,RepaVbjaMea12DisplayGyomKbn.UPDONLAPLID
                ,RepaVbjaMea12DisplayGyomKbn.UPDBATAPLID
        };
    }

}
