package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 素材担当者マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/16 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class Mbj52SzTntUser {

    /**
     * インスタンス生成禁止
     */
    private Mbj52SzTntUser() {
    }

    /** 素材担当者マスタ (MBJ52SZTNTUSER) */
    public static final String TBNAME = "MBJ52SZTNTUSER";

    /** Prefix (MBJ52_) */
    public static final String PREFIX = "MBJ52_";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 担当者SEQ (USERSEQ) */
    public static final String USERSEQ = PREFIX + "USERSEQ";

    /** 担当者ID (USERID) */
    public static final String USERID = PREFIX + "USERID";

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
