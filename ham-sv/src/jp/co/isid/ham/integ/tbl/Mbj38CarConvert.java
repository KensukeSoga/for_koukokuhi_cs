package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 車種変換マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj38CarConvert {

    /**
     * インスタンス生成禁止
     */
    private Mbj38CarConvert() {
    }

    /** 車種変換マスタ (MBJ38CARCONVERT) */
    public static final String TBNAME = "MBJ38CARCONVERT";

    /** Prefix (MBJ38_) */
    public static final String PREFIX = "MBJ38_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 年月 (SOZAIYM) */
    public static final String SOZAIYM = PREFIX + "SOZAIYM";

    /** 素材記号 (SOZAIKG) */
    public static final String SOZAIKG = PREFIX + "SOZAIKG";

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
