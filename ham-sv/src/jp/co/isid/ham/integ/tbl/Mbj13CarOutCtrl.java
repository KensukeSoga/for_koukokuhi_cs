package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 車種出力設定マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj13CarOutCtrl {

    /**
     * インスタンス生成禁止
     */
    private Mbj13CarOutCtrl() {
    }

    /** 車種出力設定マスタ (MBJ13CAROUTCTRL) */
    public static final String TBNAME = "MBJ13CAROUTCTRL";

    /** Prefix (MBJ13_) */
    public static final String PREFIX = "MBJ13_";

    /** 帳票コード (REPORTCD) */
    public static final String REPORTCD = PREFIX + "REPORTCD";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 出力フラグ (OUTPUTFLG) */
    public static final String OUTPUTFLG = PREFIX + "OUTPUTFLG";

    /** ソートNo (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
