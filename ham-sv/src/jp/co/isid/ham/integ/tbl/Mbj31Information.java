package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * インフォメーションマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj31Information {

    /**
     * インスタンス生成禁止
     */
    private Mbj31Information() {
    }

    /** インフォメーションマスタ (MBJ31INFORMATION) */
    public static final String TBNAME = "MBJ31INFORMATION";

    /** Prefix (MBJ31_) */
    public static final String PREFIX = "MBJ31_";

    /** インフォメーションナンバー (INFONUMBER) */
    public static final String INFONUMBER = PREFIX + "INFONUMBER";

    /** 作成日時 (MAKEDATE) */
    public static final String MAKEDATE = PREFIX + "MAKEDATE";

    /** お知らせ内容 (MESSAGE) */
    public static final String MESSAGE = PREFIX + "MESSAGE";

    /** 発信者（登録者） (MAKEUSER) */
    public static final String MAKEUSER = PREFIX + "MAKEUSER";

    /** 表示状態 (DISPSTS) */
    public static final String DISPSTS = PREFIX + "DISPSTS";

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
