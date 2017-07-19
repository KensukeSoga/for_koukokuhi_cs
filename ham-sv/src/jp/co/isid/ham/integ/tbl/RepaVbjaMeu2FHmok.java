package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 費目マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu2FHmok {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu2FHmok() {
    }

    /** 費目マスタ (REP_VBJ_MEU2FHMOK) */
    public static final String TBNAME = "REP_VBJ_MEU2FHMOK";

    /** Prefix (VEU_BJ_MEU2F_) */
    public static final String PREFIX = "VEU_BJ_MEU2F_";

    /** 費目コード (HMOKCD) */
    public static final String HMOKCD = PREFIX + "HMOKCD";

    /** 発行年月日 (HKYMD) */
    public static final String HKYMD = PREFIX + "HKYMD";

    /** 廃止年月日 (HAISYMD) */
    public static final String HAISYMD = PREFIX + "HAISYMD";

    /** 内容（カナ） (NAIYKN) */
    public static final String NAIYKN = PREFIX + "NAIYKN";

    /** 内容（漢字） (NAIYJ) */
    public static final String NAIYJ = PREFIX + "NAIYJ";

    /** 経理費目表示区分 (KRIHMOKSHOWKBN) */
    public static final String KRIHMOKSHOWKBN = PREFIX + "KRIHMOKSHOWKBN";

}
