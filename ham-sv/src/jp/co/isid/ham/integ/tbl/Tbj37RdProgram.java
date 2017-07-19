package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * ラジオ番組
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj37RdProgram {

    /**
     * インスタンス生成禁止
     */
    private Tbj37RdProgram() {
    }

    /** ラジオ番組 (TBJ37RDPROGRAM) */
    public static final String TBNAME = "TBJ37RDPROGRAM";

    /** Prefix (TBJ37_) */
    public static final String PREFIX = "TBJ37_";

    /** ラジオ番組SEQNO (RDSEQNO) */
    public static final String RDSEQNO = PREFIX + "RDSEQNO";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 番組名 (PROGRAMNM) */
    public static final String PROGRAMNM = PREFIX + "PROGRAMNM";

    /** レ単区分 (RSDIV) */
    public static final String RSDIV = PREFIX + "RSDIV";

    /** ネットローカル区分 (NLDIV) */
    public static final String NLDIV = PREFIX + "NLDIV";

    /** 秒数 (SECOND) */
    public static final String SECOND = PREFIX + "SECOND";

    /** 枠 (TIMES) */
    public static final String TIMES = PREFIX + "TIMES";

    /** 総秒数 (TOTALSECOND) */
    public static final String TOTALSECOND = PREFIX + "TOTALSECOND";

    /** 放送開始日 (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 放送終了日 (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** キー局コード (KEYSTATIONCD) */
    public static final String KEYSTATIONCD = PREFIX + "KEYSTATIONCD";

    /** 放送開始時間 (STARTTIME) */
    public static final String STARTTIME = PREFIX + "STARTTIME";

    /** 放送終了時間 (ENDTIME) */
    public static final String ENDTIME = PREFIX + "ENDTIME";

    /** 売上料金設定区分 (SALESPRICEDIV) */
    public static final String SALESPRICEDIV = PREFIX + "SALESPRICEDIV";

    /** 売上料金設定 (SALESPRICE) */
    public static final String SALESPRICE = PREFIX + "SALESPRICE";

    /** 設定額料金設定区分 (CONFIGPRICEDIV) */
    public static final String CONFIGPRICEDIV = PREFIX + "CONFIGPRICEDIV";

    /** 設定額料金設定 (CONFIGPRICE) */
    public static final String CONFIGPRICE = PREFIX + "CONFIGPRICE";

    /** 月曜日放送 (ONAIRMON) */
    public static final String ONAIRMON = PREFIX + "ONAIRMON";

    /** 火曜日放送 (ONAIRTUE) */
    public static final String ONAIRTUE = PREFIX + "ONAIRTUE";

    /** 水曜日放送 (ONAIRWED) */
    public static final String ONAIRWED = PREFIX + "ONAIRWED";

    /** 木曜日放送 (ONAIRTHU) */
    public static final String ONAIRTHU = PREFIX + "ONAIRTHU";

    /** 金曜日放送 (ONAIRFRI) */
    public static final String ONAIRFRI = PREFIX + "ONAIRFRI";

    /** 土曜日放送 (ONAIRSAT) */
    public static final String ONAIRSAT = PREFIX + "ONAIRSAT";

    /** 日曜日放送 (ONAIRSUN) */
    public static final String ONAIRSUN = PREFIX + "ONAIRSUN";

    /** データ作成日時 (CRTDATE) */
    public static final String CRTDATE = PREFIX + "CRTDATE";

    /** データ作成者 (CRTNM) */
    public static final String CRTNM = PREFIX + "CRTNM";

    /** 作成プログラム (CRTAPL) */
    public static final String CRTAPL = PREFIX + "CRTAPL";

    /** 作成担当者ID (CRTID) */
    public static final String CRTID = PREFIX + "CRTID";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
