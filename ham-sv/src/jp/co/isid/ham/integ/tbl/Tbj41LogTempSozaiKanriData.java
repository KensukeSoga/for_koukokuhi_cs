package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 仮素材登録変更ログ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj41LogTempSozaiKanriData {

    /**
     * インスタンス生成禁止
     */
    private Tbj41LogTempSozaiKanriData() {
    }

    /** 仮素材登録変更ログ (TBJ41LOGTEMPSOZAIKANRIDATA) */
    public static final String TBNAME = "TBJ41LOGTEMPSOZAIKANRIDATA";

    /** Prefix (TBJ41_) */
    public static final String PREFIX = "TBJ41_";

    /** 系統 (NOKBN) */
    public static final String NOKBN = PREFIX + "NOKBN";

    /** 仮10桁CMｺｰﾄﾞ (TEMPCMCD) */
    public static final String TEMPCMCD = PREFIX + "TEMPCMCD";

    /** 履歴NO (HISTORYNO) */
    public static final String HISTORYNO = PREFIX + "HISTORYNO";

    /** 10桁CMｺｰﾄﾞ (CMCD) */
    public static final String CMCD = PREFIX + "CMCD";

    /** 履歴区分 (HISTORYKBN) */
    public static final String HISTORYKBN = PREFIX + "HISTORYKBN";

    /** 削除フラグ (DELFLG) */
    public static final String DELFLG = PREFIX + "DELFLG";

    /** 車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** カテゴリ (CATEGORY) */
    public static final String CATEGORY = PREFIX + "CATEGORY";

    /** タイトル (TITLE) */
    public static final String TITLE = PREFIX + "TITLE";

    /** 通称タイトル (ALIASTITLE) */
    public static final String ALIASTITLE = PREFIX + "ALIASTITLE";

    /** ぶら下がり (ENDTITLE) */
    public static final String ENDTITLE = PREFIX + "ENDTITLE";

    /** 秒数 (SECOND) */
    public static final String SECOND = PREFIX + "SECOND";

    /** 車種担当 (SYATAN) */
    public static final String SYATAN = PREFIX + "SYATAN";

    /** 納品日 (NOHIN) */
    public static final String NOHIN = PREFIX + "NOHIN";

    /** 制作ﾌﾟﾛﾀﾞｸｼｮﾝ (PRODUCT) */
    public static final String PRODUCT = PREFIX + "PRODUCT";

    /** 放送開始日 (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 放送開始日(属性) (DATEFROM_ATTR) */
    public static final String DATEFROM_ATTR = PREFIX + "DATEFROM_ATTR";

    /** 放送終了日 (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** 放送終了日(属性) (DATETO_ATTR) */
    public static final String DATETO_ATTR = PREFIX + "DATETO_ATTR";

    /** ﾒﾃﾞｨｱ使用期限 (MLIMIT) */
    public static final String MLIMIT = PREFIX + "MLIMIT";

    /** 権利使用期限 (KLIMIT) */
    public static final String KLIMIT = PREFIX + "KLIMIT";

    /** 正式承認日 (DATERECOG) */
    public static final String DATERECOG = PREFIX + "DATERECOG";

    /** 発行日 (DATEPRT) */
    public static final String DATEPRT = PREFIX + "DATEPRT";

    /** 備考 (BIKO) */
    public static final String BIKO = PREFIX + "BIKO";

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
