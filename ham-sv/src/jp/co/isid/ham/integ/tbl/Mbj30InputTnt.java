package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 入力担当マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj30InputTnt {

    /**
     * インスタンス生成禁止
     */
    private Mbj30InputTnt() {
    }

    /** 入力担当マスタ (MBJ30INPUTTNT) */
    public static final String TBNAME = "MBJ30INPUTTNT";

    /** Prefix (MBJ30_) */
    public static final String PREFIX = "MBJ30_";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 種別判断フラグ (CLASSDIV) */
    public static final String CLASSDIV = PREFIX + "CLASSDIV";

    /** 入力担当SeqNo (SEQNO) */
    public static final String SEQNO = PREFIX + "SEQNO";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 入力担当 (INPUTTNT) */
    public static final String INPUTTNT = PREFIX + "INPUTTNT";

    /** ソートNO (SORTNO) */
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
