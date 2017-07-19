package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 車種担当者マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj23CarTanto {

    /**
     * インスタンス生成禁止
     */
    private Mbj23CarTanto() {
    }

    /** 車種担当者マスタ (MBJ23CARTANTO) */
    public static final String TBNAME = "MBJ23CARTANTO";

    /** Prefix (MBJ23_) */
    public static final String PREFIX = "MBJ23_";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 媒体担当者 (MEDIATANTO) */
    public static final String MEDIATANTO = PREFIX + "MEDIATANTO";

    /** 制作担当者 (CRTANTO) */
    public static final String CRTANTO = PREFIX + "CRTANTO";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
