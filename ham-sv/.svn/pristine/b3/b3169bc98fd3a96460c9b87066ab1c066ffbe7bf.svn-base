package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu15ThsTntHr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 取引先担当（払）DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu15ThsTntHrDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    //private RepaVbjaMeu15ThsTntHrCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu15ThsTntHrDAO() {
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
                RepaVbjaMeu15ThsTntHr.THSKGYCD
                ,RepaVbjaMeu15ThsTntHr.SEQNO
                ,RepaVbjaMeu15ThsTntHr.HRTNTSEQNO
                ,RepaVbjaMeu15ThsTntHr.ENDYMD
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
        return RepaVbjaMeu15ThsTntHr.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu15ThsTntHr.THSKGYCD
                ,RepaVbjaMeu15ThsTntHr.SEQNO
                ,RepaVbjaMeu15ThsTntHr.HRTNTSEQNO
                ,RepaVbjaMeu15ThsTntHr.ENDYMD
                ,RepaVbjaMeu15ThsTntHr.STARTYMD
                ,RepaVbjaMeu15ThsTntHr.SNSTNT
                ,RepaVbjaMeu15ThsTntHr.SIKCD
                ,RepaVbjaMeu15ThsTntHr.SHRKBN
                ,RepaVbjaMeu15ThsTntHr.FRKSKBN
                ,RepaVbjaMeu15ThsTntHr.EGHISHRSKBN
                ,RepaVbjaMeu15ThsTntHr.STYSHRSKBN
                ,RepaVbjaMeu15ThsTntHr.SINSEINO
                ,RepaVbjaMeu15ThsTntHr.EGSYOCD
                ,RepaVbjaMeu15ThsTntHr.SHJYOKNPTNNO
                ,RepaVbjaMeu15ThsTntHr.KYUTRCD
                ,RepaVbjaMeu15ThsTntHr.HRTNTYOBI
        };
    }

}
