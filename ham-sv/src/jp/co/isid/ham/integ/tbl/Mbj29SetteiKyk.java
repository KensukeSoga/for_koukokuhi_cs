package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 設定局マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj29SetteiKyk {

    /**
     * インスタンス生成禁止
     */
    private Mbj29SetteiKyk() {
    }

    /** 設定局マスタ (MBJ29SETTEIKYK) */
    public static final String TBNAME = "MBJ29SETTEIKYK";

    /** Prefix (MBJ29_) */
    public static final String PREFIX = "MBJ29_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 設定局ナンバー (STKYKNO) */
    public static final String STKYKNO = PREFIX + "STKYKNO";

    /** 設定局名 (STKYKNM) */
    public static final String STKYKNM = PREFIX + "STKYKNM";

    /** 組織コード (SIKCD) */
    public static final String SIKCD = PREFIX + "SIKCD";

    /** SSS公開フラグ (SSSFLG) */
    public static final String SSSFLG = PREFIX + "SSSFLG";

    /** メール送信フラグ (MAILFLG) */
    public static final String MAILFLG = PREFIX + "MAILFLG";

    /** ソートNO (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
