package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * HMユーザマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj48HmUser {

    /**
     * インスタンス生成禁止
     */
    private Mbj48HmUser() {
    }

    /** HMユーザマスタ (MBJ48HMUSER) */
    public static final String TBNAME = "MBJ48HMUSER";

    /** Prefix (MBJ48_) */
    public static final String PREFIX = "MBJ48_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 期 (TERM) */
    public static final String TERM = PREFIX + "TERM";

    /** HM担当者職番 (HMUSERCD) */
    public static final String HMUSERCD = PREFIX + "HMUSERCD";

    /** HM担当者名 (HMUSERNM) */
    public static final String HMUSERNM = PREFIX + "HMUSERNM";

    /** HC担当者内線番号 (HMUSEREXTENSIONNO) */
    public static final String HMUSEREXTENSIONNO = PREFIX + "HMUSEREXTENSIONNO";

    /** ソートNO (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
