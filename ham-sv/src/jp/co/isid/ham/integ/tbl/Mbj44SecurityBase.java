package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * セキュリティベースマスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj44SecurityBase {

    /**
     * インスタンス生成禁止
     */
    private Mbj44SecurityBase() {
    }

    /** セキュリティベースマスタ (MBJ44SECURITYBASE) */
    public static final String TBNAME = "MBJ44SECURITYBASE";

    /** Prefix (MBJ44_) */
    public static final String PREFIX = "MBJ44_";

    /** 局コード (KKSIKOGNZUNTCD) */
    public static final String KKSIKOGNZUNTCD = PREFIX + "KKSIKOGNZUNTCD";

    /** ユーザ種別 (USERTYPE) */
    public static final String USERTYPE = PREFIX + "USERTYPE";

    /** セキュリティコード (SECURITYCD) */
    public static final String SECURITYCD = PREFIX + "SECURITYCD";

    /** セキュリティ種別 (SECURITYTYPE) */
    public static final String SECURITYTYPE = PREFIX + "SECURITYTYPE";

    /** 登録・更新 (UPDATE) */
    public static final String UPDATE = PREFIX + "UPDATE";

    /** 確認 (CHECK) */
    public static final String CHECK = PREFIX + "CHECK";

    /** 参照 (REFERENCE) */
    public static final String REFERENCE = PREFIX + "REFERENCE";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
