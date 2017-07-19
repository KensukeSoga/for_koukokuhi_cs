package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 業務区分費目対応マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu2LGKbnHmok {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu2LGKbnHmok() {
    }

    /** 業務区分費目対応マスタ (REP_VBJ_MEU2LGKBNHMOK) */
    public static final String TBNAME = "REP_VBJ_MEU2LGKBNHMOK";

    /** Prefix (VEU_BJ_MEU2L_) */
    public static final String PREFIX = "VEU_BJ_MEU2L_";

    /** 業務区分 (GYOMKBN) */
    public static final String GYOMKBN = PREFIX + "GYOMKBN";

    /** 費目コード (HMOKCD) */
    public static final String HMOKCD = PREFIX + "HMOKCD";

    /** 発行年月日 (HKYMD) */
    public static final String HKYMD = PREFIX + "HKYMD";

    /** 費目表示順 (HMOKSEQ) */
    public static final String HMOKSEQ = PREFIX + "HMOKSEQ";

    /** 廃止年月日 (HAISYMD) */
    public static final String HAISYMD = PREFIX + "HAISYMD";

    /** 海外区分 (KAIGAIKBN) */
    public static final String KAIGAIKBN = PREFIX + "KAIGAIKBN";

}
