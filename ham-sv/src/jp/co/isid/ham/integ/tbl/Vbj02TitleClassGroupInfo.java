package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループ情報)
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Vbj02TitleClassGroupInfo {

    /**
     * インスタンス生成禁止
     */
    private Vbj02TitleClassGroupInfo() {
    }

    /** 新HAM向けVIEW(職位等級グループ情報) (VBJ02_TITLECLASSGROUPINFO) */
    public static final String TBNAME = "VBJ02_TITLECLASSGROUPINFO";

    /** Prefix (BJ02_) */
    public static final String PREFIX = "BJ02_";

    /** グループコード (GROUPCD) */
    public static final String GROUPCD = PREFIX + "GROUPCD";

    /** グループ名称漢字 (GROUPNMKJ) */
    public static final String GROUPNMKJ = PREFIX + "GROUPNMKJ";

    /** グループ名称アルファベット (GROUPNMALPH) */
    public static final String GROUPNMALPH = PREFIX + "GROUPNMALPH";

    /** 開始年月日 (STRTYMD) */
    public static final String STRTYMD = PREFIX + "STRTYMD";

    /** 終了年月日 (STPYMD) */
    public static final String STPYMD = PREFIX + "STPYMD";

}
