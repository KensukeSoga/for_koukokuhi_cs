package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 機能制御ベースマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj39FunctionControlBase {

    /**
     * インスタンス生成禁止
     */
    private Mbj39FunctionControlBase() {
    }

    /** 機能制御ベースマスタ (MBJ39FUNCTIONCONTROLBASE) */
    public static final String TBNAME = "MBJ39FUNCTIONCONTROLBASE";

    /** Prefix (MBJ39_) */
    public static final String PREFIX = "MBJ39_";

    /** 局コード (KKSIKOGNZUNTCD) */
    public static final String KKSIKOGNZUNTCD = PREFIX + "KKSIKOGNZUNTCD";

    /** ユーザ種別 (USERTYPE) */
    public static final String USERTYPE = PREFIX + "USERTYPE";

    /** 機能コード (FUNCCD) */
    public static final String FUNCCD = PREFIX + "FUNCCD";

    /** 機能種別 (FUNCTYPE) */
    public static final String FUNCTYPE = PREFIX + "FUNCTYPE";

    /** 制御 (CONTROL) */
    public static final String CONTROL = PREFIX + "CONTROL";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
