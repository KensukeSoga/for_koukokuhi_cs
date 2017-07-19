package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 制作費
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj21Seisakuhi {

    /**
     * インスタンス生成禁止
     */
    private Tbj21Seisakuhi() {
    }

    /** 制作費 (TBJ21SEISAKUHI) */
    public static final String TBNAME = "TBJ21SEISAKUHI";

    /** Prefix (TBJ21_) */
    public static final String PREFIX = "TBJ21_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 請求月 (SEIKYUYM) */
    public static final String SEIKYUYM = PREFIX + "SEIKYUYM";

    /** 車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 車種名 (DCARNM) */
    public static final String DCARNM = PREFIX + "DCARNM";

    /** 制作費(発注) (SEISAKUHIH) */
    public static final String SEISAKUHIH = PREFIX + "SEISAKUHIH";

    /** 制作費(請求) (SEISAKUHIS) */
    public static final String SEISAKUHIS = PREFIX + "SEISAKUHIS";

    /** その他 (SEISAKUHIOTHER) */
    public static final String SEISAKUHIOTHER = PREFIX + "SEISAKUHIOTHER";

    /** 備考 (BIKO) */
    public static final String BIKO = PREFIX + "BIKO";

    /** 制作費データ取得日時 (GETTIME) */
    public static final String GETTIME = PREFIX + "GETTIME";

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
