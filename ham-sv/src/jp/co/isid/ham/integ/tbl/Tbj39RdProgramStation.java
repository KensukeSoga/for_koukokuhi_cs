package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * ラジオ番組ネット局
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj39RdProgramStation {

    /**
     * インスタンス生成禁止
     */
    private Tbj39RdProgramStation() {
    }

    /** ラジオ番組ネット局 (TBJ39RDPROGRAMSTATION) */
    public static final String TBNAME = "TBJ39RDPROGRAMSTATION";

    /** Prefix (TBJ39_) */
    public static final String PREFIX = "TBJ39_";

    /** ラジオ番組SEQNO (RDSEQNO) */
    public static final String RDSEQNO = PREFIX + "RDSEQNO";

    /** ネット局コード (STATIONCD) */
    public static final String STATIONCD = PREFIX + "STATIONCD";

    /** データ作成日時 (CRTDATE) */
    public static final String CRTDATE = PREFIX + "CRTDATE";

    /** データ作成者 (CRTNM) */
    public static final String CRTNM = PREFIX + "CRTNM";

    /** 作成プログラム (CRTAPL) */
    public static final String CRTAPL = PREFIX + "CRTAPL";

    /** 作成担当者ID (CRTID) */
    public static final String CRTID = PREFIX + "CRTID";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
