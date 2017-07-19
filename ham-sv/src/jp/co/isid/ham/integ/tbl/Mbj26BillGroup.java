package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 請求グループマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj26BillGroup {

    /**
     * インスタンス生成禁止
     */
    private Mbj26BillGroup() {
    }

    /** 請求グループマスタ (MBJ26BILLGROUP) */
    public static final String TBNAME = "MBJ26BILLGROUP";

    /** Prefix (MBJ26_) */
    public static final String PREFIX = "MBJ26_";

    /** グループコード (GROUPCD) */
    public static final String GROUPCD = PREFIX + "GROUPCD";

    /** グループ名 (GROUPNM) */
    public static final String GROUPNM = PREFIX + "GROUPNM";

    /** グループ名(帳票) (GROUPNMRPT) */
    public static final String GROUPNMRPT = PREFIX + "GROUPNMRPT";

    /** ソートNO (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** HC部門コード (HCBUMONCD) */
    public static final String HCBUMONCD = PREFIX + "HCBUMONCD";

    /** HC部門コード(Fee案件請求用) (HCBUMONCDBILL) */
    public static final String HCBUMONCDBILL = PREFIX + "HCBUMONCDBILL";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
