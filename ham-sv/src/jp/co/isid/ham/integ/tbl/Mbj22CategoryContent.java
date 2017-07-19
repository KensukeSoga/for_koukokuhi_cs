package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 車種カテゴリ紐付けマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj22CategoryContent {

    /**
     * インスタンス生成禁止
     */
    private Mbj22CategoryContent() {
    }

    /** 車種カテゴリ紐付けマスタ (MBJ22CATEGORYCONTENT) */
    public static final String TBNAME = "MBJ22CATEGORYCONTENT";

    /** Prefix (MBJ22_) */
    public static final String PREFIX = "MBJ22_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** カテゴリナンバー (CATEGORYNO) */
    public static final String CATEGORYNO = PREFIX + "CATEGORYNO";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
