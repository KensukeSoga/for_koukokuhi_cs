package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 削減額管理
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj34CutManagement {

    /**
     * インスタンス生成禁止
     */
    private Tbj34CutManagement() {
    }

    /** 削減額管理 (TBJ34CUTMANAGEMENT) */
    public static final String TBNAME = "TBJ34CUTMANAGEMENT";

    /** Prefix (TBJ34_) */
    public static final String PREFIX = "TBJ34_";

    /** 種別コード (CLASSCD) */
    public static final String CLASSCD = PREFIX + "CLASSCD";

    /** 開始年月日 (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 終了年月日 (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** 削減実績額 (CUTMONEY) */
    public static final String CUTMONEY = PREFIX + "CUTMONEY";

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
