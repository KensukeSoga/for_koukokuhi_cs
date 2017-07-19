package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * キャンペーン一覧
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj12Campaign {

    /**
     * インスタンス生成禁止
     */
    private Tbj12Campaign() {
    }

    /** キャンペーン一覧 (TBJ12CAMPAIGN) */
    public static final String TBNAME = "TBJ12CAMPAIGN";

    /** Prefix (TBJ12_) */
    public static final String PREFIX = "TBJ12_";

    /** キャンペーンコード (CAMPCD) */
    public static final String CAMPCD = PREFIX + "CAMPCD";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 予定期間開始 (KIKANFROM) */
    public static final String KIKANFROM = PREFIX + "KIKANFROM";

    /** 予定期間終了 (KIKANTO) */
    public static final String KIKANTO = PREFIX + "KIKANTO";

    /** キャンペーン名 (CAMPNM) */
    public static final String CAMPNM = PREFIX + "CAMPNM";

    /** 期初予算金額 (FSTBUDGET) */
    public static final String FSTBUDGET = PREFIX + "FSTBUDGET";

    /** 予算金額 (BUDGET) */
    public static final String BUDGET = PREFIX + "BUDGET";

    /** 予算金額(新) (BUDGETHM) */
    public static final String BUDGETHM = PREFIX + "BUDGETHM";

    /** 実施金額 (ACTUAL) */
    public static final String ACTUAL = PREFIX + "ACTUAL";

    /** 実施金額(新) (ACTUALHM) */
    public static final String ACTUALHM = PREFIX + "ACTUALHM";

    /** 備考 (MEMO) */
    public static final String MEMO = PREFIX + "MEMO";

    /** 媒体作成済フラグ (BAITAIFLG) */
    public static final String BAITAIFLG = PREFIX + "BAITAIFLG";

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
