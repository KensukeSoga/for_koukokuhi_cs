package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 媒体パターンマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj35MediaPattern {

    /**
     * インスタンス生成禁止
     */
    private Mbj35MediaPattern() {
    }

    /** 媒体パターンマスタ (MBJ35MEDIAPATTERN) */
    public static final String TBNAME = "MBJ35MEDIAPATTERN";

    /** Prefix (MBJ35_) */
    public static final String PREFIX = "MBJ35_";

    /** 新雑区分 (SZKBN) */
    public static final String SZKBN = PREFIX + "SZKBN";

    /** 媒体パターンNo (BAITAIPATNNO) */
    public static final String BAITAIPATNNO = PREFIX + "BAITAIPATNNO";

    /** 媒体パターン名 (BAITAIPATNNAME) */
    public static final String BAITAIPATNNAME = PREFIX + "BAITAIPATNNAME";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
