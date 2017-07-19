package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 画面項目表示列制御マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj37DisplayControl {

    /**
     * インスタンス生成禁止
     */
    private Mbj37DisplayControl() {
    }

    /** 画面項目表示列制御マスタ (MBJ37DISPLAYCONTROL) */
    public static final String TBNAME = "MBJ37DISPLAYCONTROL";

    /** Prefix (MBJ37_) */
    public static final String PREFIX = "MBJ37_";

    /** 画面ID (FORMID) */
    public static final String FORMID = PREFIX + "FORMID";

    /** 一覧ID (VIEWID) */
    public static final String VIEWID = PREFIX + "VIEWID";

    /** 列数 (COLCNT) */
    public static final String COLCNT = PREFIX + "COLCNT";

    /** 列名 (COLNM) */
    public static final String COLNM = PREFIX + "COLNM";

    /** 列幅 (COLWIDTH) */
    public static final String COLWIDTH = PREFIX + "COLWIDTH";

    /** 表示区分 (DISPLAYKBN) */
    public static final String DISPLAYKBN = PREFIX + "DISPLAYKBN";

    /** 制御区分 (CONTROLKBN) */
    public static final String CONTROLKBN = PREFIX + "CONTROLKBN";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
