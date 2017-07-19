package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 媒体パターン内容マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj36MediaPatternItem {

    /**
     * インスタンス生成禁止
     */
    private Mbj36MediaPatternItem() {
    }

    /** 媒体パターン内容マスタ (MBJ36MEDIAPATTERNITEM) */
    public static final String TBNAME = "MBJ36MEDIAPATTERNITEM";

    /** Prefix (MBJ36_) */
    public static final String PREFIX = "MBJ36_";

    /** 新雑区分 (SZKBN) */
    public static final String SZKBN = PREFIX + "SZKBN";

    /** 媒体パターンNo (BAITAIPATNNO) */
    public static final String BAITAIPATNNO = PREFIX + "BAITAIPATNNO";

    /** 媒体コード (NPCD) */
    public static final String NPCD = PREFIX + "NPCD";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
