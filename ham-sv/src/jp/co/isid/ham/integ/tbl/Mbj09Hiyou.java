package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 費用企画Noマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj09Hiyou {

    /**
     * インスタンス生成禁止
     */
    private Mbj09Hiyou() {
    }

    /** 費用企画Noマスタ (MBJ09HIYOU) */
    public static final String TBNAME = "MBJ09HIYOU";

    /** Prefix (MBJ09_) */
    public static final String PREFIX = "MBJ09_";

    /** 媒体コード (MEDIACD) */
    public static final String MEDIACD = PREFIX + "MEDIACD";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 費用計画No (HIYOUNO) */
    public static final String HIYOUNO = PREFIX + "HIYOUNO";

    /** 企画No (KIKAKUNO) */
    public static final String KIKAKUNO = PREFIX + "KIKAKUNO";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 期 (TERM) */
    public static final String TERM = PREFIX + "TERM";

    /** 費用企画Noﾌﾗｸﾞ (HIYOUFLG) */
    public static final String HIYOUFLG = PREFIX + "HIYOUFLG";

    /** HM部門コード (HMDIVCD) */
    public static final String HMDIVCD = PREFIX + "HMDIVCD";

    /** HM担当者コード (HMUSERCD) */
    public static final String HMUSERCD = PREFIX + "HMUSERCD";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
