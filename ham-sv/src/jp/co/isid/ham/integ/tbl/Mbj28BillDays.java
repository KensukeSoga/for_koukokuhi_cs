package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 請求書出力年月マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj28BillDays {

    /**
     * インスタンス生成禁止
     */
    private Mbj28BillDays() {
    }

    /** 請求書出力年月マスタ (MBJ28BILLDAYS) */
    public static final String TBNAME = "MBJ28BILLDAYS";

    /** Prefix (MBJ28_) */
    public static final String PREFIX = "MBJ28_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 年 (YEAR) */
    public static final String YEAR = PREFIX + "YEAR";

    /** 月 (MONTH) */
    public static final String MONTH = PREFIX + "MONTH";

    /** 日 (DATE) */
    public static final String DATE = PREFIX + "DATE";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
