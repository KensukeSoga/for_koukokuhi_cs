package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * システム使用状況
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj01SysSts {

    /**
     * インスタンス生成禁止
     */
    private Mbj01SysSts() {
    }

    /** システム使用状況 (MBJ01SYSSTS) */
    public static final String TBNAME = "MBJ01SYSSTS";

    /** Prefix (MBJ01_) */
    public static final String PREFIX = "MBJ01_";

    /** 種別 (LOCKTYPE) */
    public static final String LOCKTYPE = PREFIX + "LOCKTYPE";

    /** 過去ロック状態 (LOCKDATESTS) */
    public static final String LOCKDATESTS = PREFIX + "LOCKDATESTS";

    /** データロック年月 (LOCKDATE) */
    public static final String LOCKDATE = PREFIX + "LOCKDATE";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
