package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 自然数テーブル
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj51Natural {

    /**
     * インスタンス生成禁止
     */
    private Mbj51Natural() {
    }

    /** 自然数テーブル (MBJ51NATURAL) */
    public static final String TBNAME = "MBJ51NATURAL";

    /** Prefix (MBJ51_) */
    public static final String PREFIX = "MBJ51_";

    /** データ区分 (NO) */
    public static final String NO = PREFIX + "NO";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
