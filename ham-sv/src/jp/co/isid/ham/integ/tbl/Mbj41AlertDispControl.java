package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * アラート表示制御マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj41AlertDispControl {

    /**
     * インスタンス生成禁止
     */
    private Mbj41AlertDispControl() {
    }

    /** アラート表示制御マスタ (MBJ41ALERTDISPCONTROL) */
    public static final String TBNAME = "MBJ41ALERTDISPCONTROL";

    /** Prefix (MBJ41_) */
    public static final String PREFIX = "MBJ41_";

    /** アラート表示種別 (DISPTYPE) */
    public static final String DISPTYPE = PREFIX + "DISPTYPE";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** シーケンス番号 (SEQNO) */
    public static final String SEQNO = PREFIX + "SEQNO";

    /** 担当者ID (HAMID) */
    public static final String HAMID = PREFIX + "HAMID";

    /** アラート表示先組織コード (SIKOGNZUNTCD) */
    public static final String SIKOGNZUNTCD = PREFIX + "SIKOGNZUNTCD";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
