package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * トランザクションセキュリティ(HDX)
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class T_TransactionSecurity {

    /**
     * インスタンス生成禁止
     */
    private T_TransactionSecurity() {
    }

    /** トランザクションセキュリティ (T_TRANSACTIONSECURITY) */
    public static final String TBNAME = "T_TRANSACTIONSECURITY";

    /** 作成日時 (INSERTDATE) */
    public static final String INSERTDATE = "INSERTDATE";

    /** 作成者ユーザID (INSERTUSERID) */
    public static final String INSERTUSERID = "INSERTUSERID";

    /** 更新日時 (UPDATEDATE) */
    public static final String UPDATEDATE = "UPDATEDATE";

    /** 更新者ユーザID (UPDATEUSERID) */
    public static final String UPDATEUSERID = "UPDATEUSERID";

    /** 削除フラグ (DELETEFLG) */
    public static final String DELETEFLG = "DELETEFLG";

    /** システムID (SYSTEMID) */
    public static final String SYSTEMID = "SYSTEMID";

    /** 広告主種別 (CLIENTSBT) */
    public static final String CLIENTSBT = "CLIENTSBT";

    /** メニュータブコード (MENUTABCODE) */
    public static final String MENUTABCODE = "MENUTABCODE";

    /** トランザクション番号  (TRANSACTIONNO) */
    public static final String TRANSACTIONNO = "TRANSACTIONNO";

    /** ユーザーID (USERID) */
    public static final String USERID = "USERID";

    /** セキュリティ属性01 (SECURITYTYPE01) */
    public static final String SECURITYTYPE01 = "SECURITYTYPE01";

    /** セキュリティ属性02 (SECURITYTYPE02) */
    public static final String SECURITYTYPE02 = "SECURITYTYPE02";

    /** セキュリティ属性03 (SECURITYTYPE03) */
    public static final String SECURITYTYPE03 = "SECURITYTYPE03";

    /** セキュリティ属性04 (SECURITYTYPE04) */
    public static final String SECURITYTYPE04 = "SECURITYTYPE04";

    /** セキュリティ属性05 (SECURITYTYPE05) */
    public static final String SECURITYTYPE05 = "SECURITYTYPE05";

}
