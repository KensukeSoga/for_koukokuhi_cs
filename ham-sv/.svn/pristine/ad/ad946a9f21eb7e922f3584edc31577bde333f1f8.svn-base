package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu2LGKbnHmok;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 業務区分費目対応マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu2LGKbnHmokDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private RepaVbjaMeu2LGKbnHmokCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu2LGKbnHmokDAO() {
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
        return RepaVbjaMeu2LGKbnHmok.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu2LGKbnHmok.GYOMKBN
                ,RepaVbjaMeu2LGKbnHmok.HMOKCD
                ,RepaVbjaMeu2LGKbnHmok.HKYMD
                ,RepaVbjaMeu2LGKbnHmok.HMOKSEQ
                ,RepaVbjaMeu2LGKbnHmok.HAISYMD
                ,RepaVbjaMeu2LGKbnHmok.KAIGAIKBN
        };
    }

}
