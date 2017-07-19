package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 取引先部門DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu13ThsKgyBmonDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    //private RepaVbjaMeu13ThsKgyBmonCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu13ThsKgyBmonDAO() {
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
                RepaVbjaMeu13ThsKgyBmon.THSKGYCD
                ,RepaVbjaMeu13ThsKgyBmon.SEQNO
                ,RepaVbjaMeu13ThsKgyBmon.ENDYMD
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
        return RepaVbjaMeu13ThsKgyBmon.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu13ThsKgyBmon.THSKGYCD
                ,RepaVbjaMeu13ThsKgyBmon.SEQNO
                ,RepaVbjaMeu13ThsKgyBmon.ENDYMD
                ,RepaVbjaMeu13ThsKgyBmon.STARTYMD
                ,RepaVbjaMeu13ThsKgyBmon.SNSTNT
                ,RepaVbjaMeu13ThsKgyBmon.SUBMEI
                ,RepaVbjaMeu13ThsKgyBmon.SUBKN
                ,RepaVbjaMeu13ThsKgyBmon.SUBEN
                ,RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN
                ,RepaVbjaMeu13ThsKgyBmon.GSYLMCD
                ,RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD
                ,RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO
                ,RepaVbjaMeu13ThsKgyBmon.SHRSINCD
                ,RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN
                ,RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD
        };
    }

}
