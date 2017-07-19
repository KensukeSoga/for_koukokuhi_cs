package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu00Sik;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 組織マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu00SikDAO extends AbstractSimpleRdbDao {

//    /** 検索条件 */
//    private RepaVbjaMeu00SikCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu00SikDAO() {
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
                RepaVbjaMeu00Sik.SIKCD
                ,RepaVbjaMeu00Sik.ENDYMD
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
        return RepaVbjaMeu00Sik.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu00Sik.SIKCD
                ,RepaVbjaMeu00Sik.ENDYMD
                ,RepaVbjaMeu00Sik.INSDATE
                ,RepaVbjaMeu00Sik.INSSIKTNTCD
                ,RepaVbjaMeu00Sik.INSAPLID
                ,RepaVbjaMeu00Sik.UPDAPLDATE
                ,RepaVbjaMeu00Sik.UPDSIKTNTCD
                ,RepaVbjaMeu00Sik.UPDONLAPLID
                ,RepaVbjaMeu00Sik.UPDBATAPLID
                ,RepaVbjaMeu00Sik.STARTYMD
                ,RepaVbjaMeu00Sik.KSHASKBTUCD
                ,RepaVbjaMeu00Sik.IOCD
                ,RepaVbjaMeu00Sik.HYOJIKN
                ,RepaVbjaMeu00Sik.HYOJIKJ
                ,RepaVbjaMeu00Sik.HYOJIRYAKU
                ,RepaVbjaMeu00Sik.HYOJIEN
                ,RepaVbjaMeu00Sik.SPUSECD
                ,RepaVbjaMeu00Sik.KAISOCD
                ,RepaVbjaMeu00Sik.JSIKCD
                ,RepaVbjaMeu00Sik.CKATUKBN
                ,RepaVbjaMeu00Sik.JYTRKKBN
                ,RepaVbjaMeu00Sik.ODRTRKKBN
                ,RepaVbjaMeu00Sik.KNRIBMON
                ,RepaVbjaMeu00Sik.KSHATHSKGYCD
                ,RepaVbjaMeu00Sik.KSHATHSSEQNO
                ,RepaVbjaMeu00Sik.KYUKSHATHSCD
                ,RepaVbjaMeu00Sik.BCKKBN
                ,RepaVbjaMeu00Sik.EGSYOCD
                ,RepaVbjaMeu00Sik.CLNTPLBMNSBETU
        };
    }

}
