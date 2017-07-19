package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * CR予算費目変換マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj45CrExpConvert {

    /**
     * インスタンス生成禁止
     */
    private Mbj45CrExpConvert() {
    }

    /** CR予算費目変換マスタ (MBJ45CREXPCONVERT) */
    public static final String TBNAME = "MBJ45CREXPCONVERT";

    /** Prefix (MBJ45_) */
    public static final String PREFIX = "MBJ45_";

    /** 費目コード (EXPCD) */
    public static final String EXPCD = PREFIX + "EXPCD";

    /** 種別判断フラグ (CLASSDIV) */
    public static final String CLASSDIV = PREFIX + "CLASSDIV";

    /** 開始年月日 (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 終了年月日 (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** 変換後費目コード (NEWEXPCD) */
    public static final String NEWEXPCD = PREFIX + "NEWEXPCD";

    /** 変換後種別判断フラグ (NEWCLASSDIV) */
    public static final String NEWCLASSDIV = PREFIX + "NEWCLASSDIV";

    /** 変換後開始年月日 (NEWDATEFROM) */
    public static final String NEWDATEFROM = PREFIX + "NEWDATEFROM";

    /** 変換後終了年月日 (NEWDATETO) */
    public static final String NEWDATETO = PREFIX + "NEWDATETO";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
