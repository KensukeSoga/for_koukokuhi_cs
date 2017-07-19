package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 画面－発注先マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMea11DisplayIrskDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//   private RepaVbjaMea11DisplayIrskCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea11DisplayIrskDAO() {
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
        return RepaVbjaMea11DisplayIrsk.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMea11DisplayIrsk.ATSEGSYOCD
                ,RepaVbjaMea11DisplayIrsk.JYUCTYPE
                ,RepaVbjaMea11DisplayIrsk.IRSKCD
                ,RepaVbjaMea11DisplayIrsk.IRSKSUBCD
                ,RepaVbjaMea11DisplayIrsk.IRIKYKSHOWNO
                ,RepaVbjaMea11DisplayIrsk.IRSKSHOWNO
                ,RepaVbjaMea11DisplayIrsk.KISEKBN
                ,RepaVbjaMea11DisplayIrsk.DSIKKBNCD
                ,RepaVbjaMea11DisplayIrsk.JYUCFLG
                ,RepaVbjaMea11DisplayIrsk.TKFLG
                ,RepaVbjaMea11DisplayIrsk.HKYMD
                ,RepaVbjaMea11DisplayIrsk.HAISYMD
                ,RepaVbjaMea11DisplayIrsk.INSDATE
                ,RepaVbjaMea11DisplayIrsk.INSTNTCD
                ,RepaVbjaMea11DisplayIrsk.INSAPLID
                ,RepaVbjaMea11DisplayIrsk.UPDAPLDATE
                ,RepaVbjaMea11DisplayIrsk.UPDTNTCD
                ,RepaVbjaMea11DisplayIrsk.UPDONLAPLID
                ,RepaVbjaMea11DisplayIrsk.UPDBATAPLID
        };
    }

}
