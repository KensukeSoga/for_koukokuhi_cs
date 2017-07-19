package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 機能制御項目マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj34FunctionControlItem {

    /**
     * インスタンス生成禁止
     */
    private Mbj34FunctionControlItem() {
    }

    /** 機能制御項目マスタ (MBJ34FUNCTIONCONTROLITEM) */
    public static final String TBNAME = "MBJ34FUNCTIONCONTROLITEM";

    /** Prefix (MBJ34_) */
    public static final String PREFIX = "MBJ34_";

    /** 機能コード (FUNCCD) */
    public static final String FUNCCD = PREFIX + "FUNCCD";

    /** 機能種別 (FUNCTYPE) */
    public static final String FUNCTYPE = PREFIX + "FUNCTYPE";

    /** 機能名 (FUNCNM) */
    public static final String FUNCNM = PREFIX + "FUNCNM";

    /** 種別 (ITEMTYPE) */
    public static final String ITEMTYPE = PREFIX + "ITEMTYPE";

    /** デフォルト制御 (DEFAULTCONTROL) */
    public static final String DEFAULTCONTROL = PREFIX + "DEFAULTCONTROL";

    /** フォームファイルID (FORMID) */
    public static final String FORMID = PREFIX + "FORMID";

    /** オブジェクト名 (OBJNAME) */
    public static final String OBJNAME = PREFIX + "OBJNAME";

    /** ソートNo (SORTNO) */
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
