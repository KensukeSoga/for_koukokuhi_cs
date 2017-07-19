package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 部署マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj32Department {

    /**
     * インスタンス生成禁止
     */
    private Mbj32Department() {
    }

    /** 部署マスタ (MBJ32DEPARTMENT) */
    public static final String TBNAME = "MBJ32DEPARTMENT";

    /** Prefix (MBJ32_) */
    public static final String PREFIX = "MBJ32_";

    /** 種別 (DATATYPE) */
    public static final String DATATYPE = PREFIX + "DATATYPE";

    /** ナンバー (DATANUMBER) */
    public static final String DATANUMBER = PREFIX + "DATANUMBER";

    /** 局名 (KYOKUNAME) */
    public static final String KYOKUNAME = PREFIX + "KYOKUNAME";

    /** 名称 (DATANAME) */
    public static final String DATANAME = PREFIX + "DATANAME";

    /** 出力フラグ (OUTPUTFLG) */
    public static final String OUTPUTFLG = PREFIX + "OUTPUTFLG";

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
