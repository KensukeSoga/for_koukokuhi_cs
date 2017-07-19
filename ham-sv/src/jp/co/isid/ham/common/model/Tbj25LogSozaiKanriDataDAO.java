package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj25LogSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 素材登録変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj25LogSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj25LogSozaiKanriDataCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj25LogSozaiKanriDataDAO() {
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
                Tbj25LogSozaiKanriData.NOKBN
                ,Tbj25LogSozaiKanriData.CMCD
                ,Tbj25LogSozaiKanriData.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj25LogSozaiKanriData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj25LogSozaiKanriData.CRTDATE
                ,Tbj25LogSozaiKanriData.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj25LogSozaiKanriData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj25LogSozaiKanriData.NOKBN
                ,Tbj25LogSozaiKanriData.CMCD
                ,Tbj25LogSozaiKanriData.HISTORYNO
                ,Tbj25LogSozaiKanriData.HISTORYKBN
                ,Tbj25LogSozaiKanriData.DELFLG
                ,Tbj25LogSozaiKanriData.DCARCD
                ,Tbj25LogSozaiKanriData.CATEGORY
                ,Tbj25LogSozaiKanriData.TITLE
                ,Tbj25LogSozaiKanriData.SECOND
                ,Tbj25LogSozaiKanriData.SYATAN
                ,Tbj25LogSozaiKanriData.NOHIN
                ,Tbj25LogSozaiKanriData.PRODUCT
                ,Tbj25LogSozaiKanriData.DATEFROM
                ,Tbj25LogSozaiKanriData.DATETO
                ,Tbj25LogSozaiKanriData.MLIMIT
                ,Tbj25LogSozaiKanriData.KLIMIT
                ,Tbj25LogSozaiKanriData.DATERECOG
                ,Tbj25LogSozaiKanriData.DATEPRT
                ,Tbj25LogSozaiKanriData.BIKO
                ,Tbj25LogSozaiKanriData.CRTDATE
                ,Tbj25LogSozaiKanriData.CRTNM
                ,Tbj25LogSozaiKanriData.CRTAPL
                ,Tbj25LogSozaiKanriData.CRTID
                ,Tbj25LogSozaiKanriData.UPDDATE
                ,Tbj25LogSozaiKanriData.UPDNM
                ,Tbj25LogSozaiKanriData.UPDAPL
                ,Tbj25LogSozaiKanriData.UPDID
        };
    }

}
