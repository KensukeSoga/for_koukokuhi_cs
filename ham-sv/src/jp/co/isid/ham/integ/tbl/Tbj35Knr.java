package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 管理テーブル
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj35Knr {

    /**
     * インスタンス生成禁止
     */
    private Tbj35Knr() {
    }

    /** 管理テーブル (TBJ35KNR) */
    public static final String TBNAME = "TBJ35KNR";

    /** Prefix (TBJ35_) */
    public static final String PREFIX = "TBJ35_";

    /** システムNO (SYSTEMNO) */
    public static final String SYSTEMNO = PREFIX + "SYSTEMNO";

    /** システム名称 (SYSTEMNAME) */
    public static final String SYSTEMNAME = PREFIX + "SYSTEMNAME";

    /** 管理フラグ (KANRIFLG) */
    public static final String KANRIFLG = PREFIX + "KANRIFLG";

    /** 利用可能開始曜日区分 (RSTAYOKBN) */
    public static final String RSTAYOKBN = PREFIX + "RSTAYOKBN";

    /** 利用可能終了曜日区分 (RENDYOKBN) */
    public static final String RENDYOKBN = PREFIX + "RENDYOKBN";

    /** 利用可能日付変更区分 (DAYCHGKBN) */
    public static final String DAYCHGKBN = PREFIX + "DAYCHGKBN";

    /** 利用可能開始時間 (RSTARTTIME) */
    public static final String RSTARTTIME = PREFIX + "RSTARTTIME";

    /** 利用可能終了時間 (RENDTIME) */
    public static final String RENDTIME = PREFIX + "RENDTIME";

    /** 営業日 (EIGYOBI) */
    public static final String EIGYOBI = PREFIX + "EIGYOBI";

    /** メッセージ１ (MSG01) */
    public static final String MSG01 = PREFIX + "MSG01";

    /** メッセージ２ (MSG02) */
    public static final String MSG02 = PREFIX + "MSG02";

    /** メッセージ３ (MSG03) */
    public static final String MSG03 = PREFIX + "MSG03";

    /** メッセージ４ (MSG04) */
    public static final String MSG04 = PREFIX + "MSG04";

    /** メッセージ５ (MSG05) */
    public static final String MSG05 = PREFIX + "MSG05";

    /** 備考 (BIKOU) */
    public static final String BIKOU = PREFIX + "BIKOU";

    /** 表示区分 (HYOUJIKBN) */
    public static final String HYOUJIKBN = PREFIX + "HYOUJIKBN";

    /** バッチ制御フラグ (BATCHFLG) */
    public static final String BATCHFLG = PREFIX + "BATCHFLG";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
