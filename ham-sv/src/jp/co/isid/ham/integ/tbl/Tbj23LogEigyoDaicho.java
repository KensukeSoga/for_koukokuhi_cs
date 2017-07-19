package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 営業作業台帳変更ログ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj23LogEigyoDaicho {

    /**
     * インスタンス生成禁止
     */
    private Tbj23LogEigyoDaicho() {
    }

    /** 営業作業台帳変更ログ (TBJ23LOGEIGYODAICHO) */
    public static final String TBNAME = "TBJ23LOGEIGYODAICHO";

    /** Prefix (TBJ23_) */
    public static final String PREFIX = "TBJ23_";

    /** 媒体管理No (MEDIAPLANNO) */
    public static final String MEDIAPLANNO = PREFIX + "MEDIAPLANNO";

    /** 台帳No (DAICHONO) */
    public static final String DAICHONO = PREFIX + "DAICHONO";

    /** 履歴NO (HISTORYNO) */
    public static final String HISTORYNO = PREFIX + "HISTORYNO";

    /** 履歴区分 (HISTORYKBN) */
    public static final String HISTORYKBN = PREFIX + "HISTORYKBN";

    /** IMPキー (IMPKEY) */
    public static final String IMPKEY = PREFIX + "IMPKEY";

    /** 請求年月 (SEIKYUYM) */
    public static final String SEIKYUYM = PREFIX + "SEIKYUYM";

    /** 媒体コード (MEDIACD) */
    public static final String MEDIACD = PREFIX + "MEDIACD";

    /** 媒体種別コード (MEDIASCD) */
    public static final String MEDIASCD = PREFIX + "MEDIASCD";

    /** 媒体種別名 (MEDIASNM) */
    public static final String MEDIASNM = PREFIX + "MEDIASNM";

    /** 系列コード (KEIRETSUCD) */
    public static final String KEIRETSUCD = PREFIX + "KEIRETSUCD";

    /** 電通車種コード (DCARCD) */
    public static final String DCARCD = PREFIX + "DCARCD";

    /** 費用計画No (HIYOUNO) */
    public static final String HIYOUNO = PREFIX + "HIYOUNO";

    /** 企画No (KIKAKUNO) */
    public static final String KIKAKUNO = PREFIX + "KIKAKUNO";

    /** キャンペーン名 (CAMPAIGN) */
    public static final String CAMPAIGN = PREFIX + "CAMPAIGN";

    /** 内容費目 (NAIYOHIMOKU) */
    public static final String NAIYOHIMOKU = PREFIX + "NAIYOHIMOKU";

    /** スペース（新聞のみ） (SPACE) */
    public static final String SPACE = PREFIX + "SPACE";

    /** 朝夕（新聞のみ） (NPDIVISION) */
    public static final String NPDIVISION = PREFIX + "NPDIVISION";

    /** 掲載版（新聞のみ） (PUBLISHVER) */
    public static final String PUBLISHVER = PREFIX + "PUBLISHVER";

    /** 記雑区分（新聞のみ） (SYMBOLDIVISION) */
    public static final String SYMBOLDIVISION = PREFIX + "SYMBOLDIVISION";

    /** 掲載面（新聞のみ） (POSTEDSURFACE) */
    public static final String POSTEDSURFACE = PREFIX + "POSTEDSURFACE";

    /** 単位（新聞のみ） (UNIT) */
    public static final String UNIT = PREFIX + "UNIT";

    /** 契約区分（新聞のみ） (CONTRACTDIVISION) */
    public static final String CONTRACTDIVISION = PREFIX + "CONTRACTDIVISION";

    /** 期間開始 (KIKANFROM) */
    public static final String KIKANFROM = PREFIX + "KIKANFROM";

    /** 期間終了 (KIKANTO) */
    public static final String KIKANTO = PREFIX + "KIKANTO";

    /** 原価入力フラグ (GENKAFLG) */
    public static final String GENKAFLG = PREFIX + "GENKAFLG";

    /** グロス金額 (GROSS) */
    public static final String GROSS = PREFIX + "GROSS";

    /** 電通値引率 (DNEBIKIRITSU) */
    public static final String DNEBIKIRITSU = PREFIX + "DNEBIKIRITSU";

    /** 電通値引額 (DNEBIKIGAKU) */
    public static final String DNEBIKIGAKU = PREFIX + "DNEBIKIGAKU";

    /** H新モデルコスト (HMCOST) */
    public static final String HMCOST = PREFIX + "HMCOST";

    /** 営業申込利益率 (APLRIEKIRITSU) */
    public static final String APLRIEKIRITSU = PREFIX + "APLRIEKIRITSU";

    /** 営業申込利益額 (APLRIEKIGAKU) */
    public static final String APLRIEKIGAKU = PREFIX + "APLRIEKIGAKU";

    /** 媒体社払金額 (MEDIAHARAI) */
    public static final String MEDIAHARAI = PREFIX + "MEDIAHARAI";

    /** 媒体マージン率 (MEDIAMARGINRITSU) */
    public static final String MEDIAMARGINRITSU = PREFIX + "MEDIAMARGINRITSU";

    /** 媒体マージン額 (MEDIAMARGINGAKU) */
    public static final String MEDIAMARGINGAKU = PREFIX + "MEDIAMARGINGAKU";

    /** 媒体原価 (MEDIAGENKA) */
    public static final String MEDIAGENKA = PREFIX + "MEDIAGENKA";

    /** 取扱利益額 (TORIRIEKI) */
    public static final String TORIRIEKI = PREFIX + "TORIRIEKI";

    /** 通常利益配分額 (RIEKIHAIBUN) */
    public static final String RIEKIHAIBUN = PREFIX + "RIEKIHAIBUN";

    /** 通常内勤利益額 (NAIKINRIEKI) */
    public static final String NAIKINRIEKI = PREFIX + "NAIKINRIEKI";

    /** 振替利益配分額 (FURIKAERIEKI) */
    public static final String FURIKAERIEKI = PREFIX + "FURIKAERIEKI";

    /** 営業要因額 (EIGYOYOIN) */
    public static final String EIGYOYOIN = PREFIX + "EIGYOYOIN";

    /** 振替利益配分額2 (FURIKAERIEKI2) */
    public static final String FURIKAERIEKI2 = PREFIX + "FURIKAERIEKI2";

    /** テレビタイム媒体社払単価 (TVTMEDIATANKA) */
    public static final String TVTMEDIATANKA = PREFIX + "TVTMEDIATANKA";

    /** テレビタイムHM単価 (TVTHMTANKA) */
    public static final String TVTHMTANKA = PREFIX + "TVTHMTANKA";

    /** 色刷料（新聞のみ） (COLORFEE) */
    public static final String COLORFEE = PREFIX + "COLORFEE";

    /** 指定料（新聞のみ） (DESIGNATIONFEE) */
    public static final String DESIGNATIONFEE = PREFIX + "DESIGNATIONFEE";

    /** 二連版料（新聞のみ） (DOUBLEFEE) */
    public static final String DOUBLEFEE = PREFIX + "DOUBLEFEE";

    /** 組替料（新聞のみ） (RECLASSIFICATIONFEE) */
    public static final String RECLASSIFICATIONFEE = PREFIX + "RECLASSIFICATIONFEE";

    /** 変形スペース料（新聞のみ） (SPACEFEE) */
    public static final String SPACEFEE = PREFIX + "SPACEFEE";

    /** スプリットラン料（新聞のみ） (SPLITRUNFEE) */
    public static final String SPLITRUNFEE = PREFIX + "SPLITRUNFEE";

    /** 依頼先（新聞のみ） (REQUESTDESTINATION) */
    public static final String REQUESTDESTINATION = PREFIX + "REQUESTDESTINATION";

    /** 放送日 (BRDDATE) */
    public static final String BRDDATE = PREFIX + "BRDDATE";

    /** 備考 (BIKO) */
    public static final String BIKO = PREFIX + "BIKO";

    /** 請求対象フラグ (SEIKYUFLG) */
    public static final String SEIKYUFLG = PREFIX + "SEIKYUFLG";

    /** 日付設定(ラジオタイムのみ) (CPDATE) */
    public static final String CPDATE = PREFIX + "CPDATE";

    /** 秒数(ラジオタイムのみ) (BRDSEC) */
    public static final String BRDSEC = PREFIX + "BRDSEC";

    /** 受注ファイル出力フラグ（新聞のみ） (FILEOUTFLG) */
    public static final String FILEOUTFLG = PREFIX + "FILEOUTFLG";

    /** 掲載日 (APPEARANCEDATE) */
    public static final String APPEARANCEDATE = PREFIX + "APPEARANCEDATE";

    /** ソート順 (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

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
