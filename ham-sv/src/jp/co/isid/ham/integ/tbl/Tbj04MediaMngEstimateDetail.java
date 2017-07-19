package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 媒体費見積明細管理
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj04MediaMngEstimateDetail {

    /**
     * インスタンス生成禁止
     */
    private Tbj04MediaMngEstimateDetail() {
    }

    /** 媒体費見積明細管理 (TBJ04MEDIAMNGESTIMATEDETAIL) */
    public static final String TBNAME = "TBJ04MEDIAMNGESTIMATEDETAIL";

    /** Prefix (TBJ04_) */
    public static final String PREFIX = "TBJ04_";

    /** 媒体費管理No (MEDIAMNGNO) */
    public static final String MEDIAMNGNO = PREFIX + "MEDIAMNGNO";

    /** 見積明細管理NO (ESTDETAILSEQNO) */
    public static final String ESTDETAILSEQNO = PREFIX + "ESTDETAILSEQNO";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 年 (MDYEAR) */
    public static final String MDYEAR = PREFIX + "MDYEAR";

    /** 月 (MDMONTH) */
    public static final String MDMONTH = PREFIX + "MDMONTH";

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
