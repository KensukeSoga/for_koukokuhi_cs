package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu16Skukjk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 請求回収条件DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu16SkukjkDAO extends AbstractSimpleRdbDao {

//    /** 検索条件 */
//    private RepaVbjaMeu16SkukjkCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu16SkukjkDAO() {
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
                RepaVbjaMeu16Skukjk.THSKGYCD
                ,RepaVbjaMeu16Skukjk.SEQNO
                ,RepaVbjaMeu16Skukjk.TRTNTSEQNO
                ,RepaVbjaMeu16Skukjk.ENDYMD
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
        return RepaVbjaMeu16Skukjk.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu16Skukjk.THSKGYCD
                ,RepaVbjaMeu16Skukjk.SEQNO
                ,RepaVbjaMeu16Skukjk.TRTNTSEQNO
                ,RepaVbjaMeu16Skukjk.ENDYMD
                ,RepaVbjaMeu16Skukjk.INSDATE
                ,RepaVbjaMeu16Skukjk.INSTNTCD
                ,RepaVbjaMeu16Skukjk.INSAPLID
                ,RepaVbjaMeu16Skukjk.UPDAPLDATE
                ,RepaVbjaMeu16Skukjk.UPDTNTCD
                ,RepaVbjaMeu16Skukjk.UPDONLAPLID
                ,RepaVbjaMeu16Skukjk.UPDBATAPLID
                ,RepaVbjaMeu16Skukjk.STARTYMD
                ,RepaVbjaMeu16Skukjk.SNSTNT
                ,RepaVbjaMeu16Skukjk.EGSYOCD
                ,RepaVbjaMeu16Skukjk.SINUPDYMD
                ,RepaVbjaMeu16Skukjk.SINCD
                ,RepaVbjaMeu16Skukjk.SINGND
                ,RepaVbjaMeu16Skukjk.SKUPDYMD
                ,RepaVbjaMeu16Skukjk.SKKSNTNT
                ,RepaVbjaMeu16Skukjk.SKSMDAY
                ,RepaVbjaMeu16Skukjk.SKTDKDAY
                ,RepaVbjaMeu16Skukjk.SKHKDAY
                ,RepaVbjaMeu16Skukjk.KSUPDYMD
                ,RepaVbjaMeu16Skukjk.KSTNT
                ,RepaVbjaMeu16Skukjk.KSYOTEIDAY
                ,RepaVbjaMeu16Skukjk.KSTSURYO
                ,RepaVbjaMeu16Skukjk.BNKTKBN1
                ,RepaVbjaMeu16Skukjk.YSN11
                ,RepaVbjaMeu16Skukjk.JGNGAK11
                ,RepaVbjaMeu16Skukjk.KNS11
                ,RepaVbjaMeu16Skukjk.SITE11
                ,RepaVbjaMeu16Skukjk.YSN12
                ,RepaVbjaMeu16Skukjk.JGNGAK12
                ,RepaVbjaMeu16Skukjk.KNS12
                ,RepaVbjaMeu16Skukjk.SITE12
                ,RepaVbjaMeu16Skukjk.HRT11
                ,RepaVbjaMeu16Skukjk.HRT12
                ,RepaVbjaMeu16Skukjk.BNKTKBN2
                ,RepaVbjaMeu16Skukjk.YSN21
                ,RepaVbjaMeu16Skukjk.JGNGAK21
                ,RepaVbjaMeu16Skukjk.KNS21
                ,RepaVbjaMeu16Skukjk.SITE21
                ,RepaVbjaMeu16Skukjk.YSN22
                ,RepaVbjaMeu16Skukjk.JGNGAK22
                ,RepaVbjaMeu16Skukjk.KNS22
                ,RepaVbjaMeu16Skukjk.SITE22
                ,RepaVbjaMeu16Skukjk.HRT21
                ,RepaVbjaMeu16Skukjk.HRT22
                ,RepaVbjaMeu16Skukjk.POST
                ,RepaVbjaMeu16Skukjk.ADDRESS
                ,RepaVbjaMeu16Skukjk.BUSYO
                ,RepaVbjaMeu16Skukjk.TEL
                ,RepaVbjaMeu16Skukjk.SKIGEN
        };
    }

}
