package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 値引条件DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu19NbJkDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private RepaVbjaMeu19NbJkCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu19NbJkDAO() {
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
        return RepaVbjaMeu19NbJk.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu19NbJk.THSKGYCD
                ,RepaVbjaMeu19NbJk.SEQNO
                ,RepaVbjaMeu19NbJk.TRTNTSEQNO
                ,RepaVbjaMeu19NbJk.NBIKSINSEINO
                ,RepaVbjaMeu19NbJk.KESYM
                ,RepaVbjaMeu19NbJk.ENDYMD
                ,RepaVbjaMeu19NbJk.STARTYMD
                ,RepaVbjaMeu19NbJk.SNSTNT
                ,RepaVbjaMeu19NbJk.TYSYMD
                ,RepaVbjaMeu19NbJk.TYEYMD
                ,RepaVbjaMeu19NbJk.KESDAY
                ,RepaVbjaMeu19NbJk.SNSKYK
        };
    }

}
