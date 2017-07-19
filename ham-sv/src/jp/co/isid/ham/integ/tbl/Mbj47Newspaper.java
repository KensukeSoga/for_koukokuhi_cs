package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 新聞マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/17 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj47Newspaper
{
    /**
     * インスタンス生成禁止
     */
    private Mbj47Newspaper()
    {
    }

    /** 新聞マスタ (MBJ47NEWSPAPER) */
    public static final String TBNAME = "MBJ47NEWSPAPER";

    /** Prefix (MBJ47_) */
    public static final String PREFIX = "MBJ47_";

    /** 媒体種別コード (NPCD) */
    public static final String NPCD = PREFIX + "NPCD";

    /** 媒体略名称 (RNAME) */
    public static final String RNAME = PREFIX + "RNAME";

    /** エリア (AREA) */
    public static final String AREA = PREFIX + "AREA";

    /** 依頼先コード (IRAISAKICODE) */
    public static final String IRAISAKICODE = PREFIX + "IRAISAKICODE";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}

