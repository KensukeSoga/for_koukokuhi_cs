package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 契約情報
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・HDX対応(2016/02/24 HLC K.Oki)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj16ContractInfo {

    /**
     * インスタンス生成禁止
     */
    private Tbj16ContractInfo() {
    }

    /** 契約情報 (TBJ16CONTRACTINFO) */
    public static final String TBNAME = "TBJ16CONTRACTINFO";

    /** Prefix (TBJ16_) */
    public static final String PREFIX = "TBJ16_";

    /** 契約種類 (CTRTKBN) */
    public static final String CTRTKBN = PREFIX + "CTRTKBN";

    /** 契約コード (CTRTNO) */
    public static final String CTRTNO = PREFIX + "CTRTNO";

    /** 車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** カテゴリ (CATEGORY) */
    public static final String CATEGORY = PREFIX + "CATEGORY";

    /** 削除フラグ (DELFLG) */
    public static final String DELFLG = PREFIX + "DELFLG";

    /** 名称 (NAMES) */
    public static final String NAMES = PREFIX + "NAMES";

    /** 契約期間(From) (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 契約期間(To) (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** 楽曲名 (MUSIC) */
    public static final String MUSIC = PREFIX + "MUSIC";

    /** JASRAC登録 (JASRACFLG) */
    public static final String JASRACFLG = PREFIX + "JASRACFLG";

    /** CD発売 (SALEFLG) */
    public static final String SALEFLG = PREFIX + "SALEFLG";

    /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
    /** ぶら下がり (ENDTITLEFLG) */
    public static final String ENDTITLEFLG = PREFIX + "ENDTITLEFLG";

    /** アレンジ・オリジナル (ARRGORGFLG) */
    public static final String ARRGORGFLG = PREFIX + "ARRGORGFLG";
    /* 2016/02/24 HDX対応 HLC K.Oki ADD End */

    /** 備考 (BIKO) */
    public static final String BIKO = PREFIX + "BIKO";

    /** 履歴キー (HISTORYKEY) */
    public static final String HISTORYKEY = PREFIX + "HISTORYKEY";

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
