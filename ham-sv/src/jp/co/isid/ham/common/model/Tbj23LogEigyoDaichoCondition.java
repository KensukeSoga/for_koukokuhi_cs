package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 営業作業台帳変更ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj23LogEigyoDaichoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体管理No */
    private BigDecimal _mediaplanno = null;

    /** 台帳No */
    private String _daichono = null;

    /** 履歴NO */
    private BigDecimal _historyno = null;

    /** 履歴区分 */
    private String _historykbn = null;

    /** IMPキー */
    private String _impkey = null;

    /** 請求年月 */
    private Date _seikyuym = null;

    /** 媒体コード */
    private String _mediacd = null;

    /** 媒体種別コード */
    private String _mediascd = null;

    /** 媒体種別名 */
    private String _mediasnm = null;

    /** 系列コード */
    private String _keiretsucd = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 費用計画No */
    private String _hiyouno = null;

    /** 企画No */
    private String _kikakuno = null;

    /** キャンペーン名 */
    private String _campaign = null;

    /** 内容費目 */
    private String _naiyohimoku = null;

    /** スペース（新聞のみ） */
    private String _space = null;

    /** 朝夕（新聞のみ） */
    private String _npdivision = null;

    /** 掲載版（新聞のみ） */
    private String _publishver = null;

    /** 記雑区分（新聞のみ） */
    private String _symboldivision = null;

    /** 掲載面（新聞のみ） */
    private String _postedsurface = null;

    /** 単位（新聞のみ） */
    private String _unit = null;

    /** 契約区分（新聞のみ） */
    private String _contractdivision = null;

    /** 期間開始 */
    private Date _kikanfrom = null;

    /** 期間終了 */
    private Date _kikanto = null;

    /** 原価入力フラグ */
    private String _genkaflg = null;

    /** グロス金額 */
    private BigDecimal _gross = null;

    /** 電通値引率 */
    private BigDecimal _dnebikiritsu = null;

    /** 電通値引額 */
    private BigDecimal _dnebikigaku = null;

    /** H新モデルコスト */
    private BigDecimal _hmcost = null;

    /** 営業申込利益率 */
    private BigDecimal _aplriekiritsu = null;

    /** 営業申込利益額 */
    private BigDecimal _aplriekigaku = null;

    /** 媒体社払金額 */
    private BigDecimal _mediaharai = null;

    /** 媒体マージン率 */
    private BigDecimal _mediamarginritsu = null;

    /** 媒体マージン額 */
    private BigDecimal _mediamargingaku = null;

    /** 媒体原価 */
    private BigDecimal _mediagenka = null;

    /** 取扱利益額 */
    private BigDecimal _toririeki = null;

    /** 通常利益配分額 */
    private BigDecimal _riekihaibun = null;

    /** 通常内勤利益額 */
    private BigDecimal _naikinrieki = null;

    /** 振替利益配分額 */
    private BigDecimal _furikaerieki = null;

    /** 営業要因額 */
    private BigDecimal _eigyoyoin = null;

    /** 振替利益配分額2 */
    private BigDecimal _furikaerieki2 = null;

    /** テレビタイム媒体社払単価 */
    private BigDecimal _tvtmediatanka = null;

    /** テレビタイムHM単価 */
    private BigDecimal _tvthmtanka = null;

    /** 色刷料（新聞のみ） */
    private BigDecimal _colorfee = null;

    /** 指定料（新聞のみ） */
    private BigDecimal _designationfee = null;

    /** 二連版料（新聞のみ） */
    private BigDecimal _doublefee = null;

    /** 組替料（新聞のみ） */
    private BigDecimal _reclassificationfee = null;

    /** 変形スペース料（新聞のみ） */
    private BigDecimal _spacefee = null;

    /** スプリットラン料（新聞のみ） */
    private BigDecimal _splitrunfee = null;

    /** 依頼先（新聞のみ） */
    private String _requestdestination = null;

    /** 放送日 */
    private String _brddate = null;

    /** 備考 */
    private String _biko = null;

    /** 請求対象フラグ */
    private String _seikyuflg = null;

    /** 日付設定(ラジオタイムのみ) */
    private String _cpdate = null;

    /** 秒数(ラジオタイムのみ) */
    private BigDecimal _brdsec = null;

    /** 受注ファイル出力フラグ（新聞のみ） */
    private String _fileoutflg = null;

    /** 掲載日 */
    private Date _appearancedate = null;

    /** ソート順 */
    private BigDecimal _sortno = null;

    /** データ作成日時 */
    private Date _crtdate = null;

    /** データ作成者 */
    private String _crtnm = null;

    /** 作成プログラム */
    private String _crtapl = null;

    /** 作成担当者ID */
    private String _crtid = null;

    /** データ更新日時 */
    private Date _upddate = null;

    /** データ更新者 */
    private String _updnm = null;

    /** 更新プログラム */
    private String _updapl = null;

    /** 更新担当者ID */
    private String _updid = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj23LogEigyoDaichoCondition() {
    }

    /**
     * 媒体管理Noを取得する
     *
     * @return 媒体管理No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediaplanno() {
        return _mediaplanno;
    }

    /**
     * 媒体管理Noを設定する
     *
     * @param mediaplanno 媒体管理No
     */
    public void setMediaplanno(BigDecimal mediaplanno) {
        this._mediaplanno = mediaplanno;
    }

    /**
     * 台帳Noを取得する
     *
     * @return 台帳No
     */
    public String getDaichono() {
        return _daichono;
    }

    /**
     * 台帳Noを設定する
     *
     * @param daichono 台帳No
     */
    public void setDaichono(String daichono) {
        this._daichono = daichono;
    }

    /**
     * 履歴NOを取得する
     *
     * @return 履歴NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHistoryno() {
        return _historyno;
    }

    /**
     * 履歴NOを設定する
     *
     * @param historyno 履歴NO
     */
    public void setHistoryno(BigDecimal historyno) {
        this._historyno = historyno;
    }

    /**
     * 履歴区分を取得する
     *
     * @return 履歴区分
     */
    public String getHistorykbn() {
        return _historykbn;
    }

    /**
     * 履歴区分を設定する
     *
     * @param historykbn 履歴区分
     */
    public void setHistorykbn(String historykbn) {
        this._historykbn = historykbn;
    }

    /**
     * IMPキーを取得する
     *
     * @return IMPキー
     */
    public String getImpkey() {
        return _impkey;
    }

    /**
     * IMPキーを設定する
     *
     * @param impkey IMPキー
     */
    public void setImpkey(String impkey) {
        this._impkey = impkey;
    }

    /**
     * 請求年月を取得する
     *
     * @return 請求年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSeikyuym() {
        return _seikyuym;
    }

    /**
     * 請求年月を設定する
     *
     * @param seikyuym 請求年月
     */
    public void setSeikyuym(Date seikyuym) {
        this._seikyuym = seikyuym;
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * 媒体コードを設定する
     *
     * @param mediacd 媒体コード
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * 媒体種別コードを取得する
     *
     * @return 媒体種別コード
     */
    public String getMediascd() {
        return _mediascd;
    }

    /**
     * 媒体種別コードを設定する
     *
     * @param mediascd 媒体種別コード
     */
    public void setMediascd(String mediascd) {
        this._mediascd = mediascd;
    }

    /**
     * 媒体種別名を取得する
     *
     * @return 媒体種別名
     */
    public String getMediasnm() {
        return _mediasnm;
    }

    /**
     * 媒体種別名を設定する
     *
     * @param mediasnm 媒体種別名
     */
    public void setMediasnm(String mediasnm) {
        this._mediasnm = mediasnm;
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKeiretsucd() {
        return _keiretsucd;
    }

    /**
     * 系列コードを設定する
     *
     * @param keiretsucd 系列コード
     */
    public void setKeiretsucd(String keiretsucd) {
        this._keiretsucd = keiretsucd;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarcd 電通車種コード
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * 費用計画Noを取得する
     *
     * @return 費用計画No
     */
    public String getHiyouno() {
        return _hiyouno;
    }

    /**
     * 費用計画Noを設定する
     *
     * @param hiyouno 費用計画No
     */
    public void setHiyouno(String hiyouno) {
        this._hiyouno = hiyouno;
    }

    /**
     * 企画Noを取得する
     *
     * @return 企画No
     */
    public String getKikakuno() {
        return _kikakuno;
    }

    /**
     * 企画Noを設定する
     *
     * @param kikakuno 企画No
     */
    public void setKikakuno(String kikakuno) {
        this._kikakuno = kikakuno;
    }

    /**
     * キャンペーン名を取得する
     *
     * @return キャンペーン名
     */
    public String getCampaign() {
        return _campaign;
    }

    /**
     * キャンペーン名を設定する
     *
     * @param campaign キャンペーン名
     */
    public void setCampaign(String campaign) {
        this._campaign = campaign;
    }

    /**
     * 内容費目を取得する
     *
     * @return 内容費目
     */
    public String getNaiyohimoku() {
        return _naiyohimoku;
    }

    /**
     * 内容費目を設定する
     *
     * @param naiyohimoku 内容費目
     */
    public void setNaiyohimoku(String naiyohimoku) {
        this._naiyohimoku = naiyohimoku;
    }

    /**
     * スペース（新聞のみ）を取得する
     *
     * @return スペース（新聞のみ）
     */
    public String getSpace() {
        return _space;
    }

    /**
     * スペース（新聞のみ）を設定する
     *
     * @param space スペース（新聞のみ）
     */
    public void setSpace(String space) {
        this._space = space;
    }

    /**
     * 朝夕（新聞のみ）を取得する
     *
     * @return 朝夕（新聞のみ）
     */
    public String getNpdivision() {
        return _npdivision;
    }

    /**
     * 朝夕（新聞のみ）を設定する
     *
     * @param npdivision 朝夕（新聞のみ）
     */
    public void setNpdivision(String npdivision) {
        this._npdivision = npdivision;
    }

    /**
     * 掲載版（新聞のみ）を取得する
     *
     * @return 掲載版（新聞のみ）
     */
    public String getPublishver() {
        return _publishver;
    }

    /**
     * 掲載版（新聞のみ）を設定する
     *
     * @param publishver 掲載版（新聞のみ）
     */
    public void setPublishver(String publishver) {
        this._publishver = publishver;
    }

    /**
     * 記雑区分（新聞のみ）を取得する
     *
     * @return 記雑区分（新聞のみ）
     */
    public String getSymboldivision() {
        return _symboldivision;
    }

    /**
     * 記雑区分（新聞のみ）を設定する
     *
     * @param symboldivision 記雑区分（新聞のみ）
     */
    public void setSymboldivision(String symboldivision) {
        this._symboldivision = symboldivision;
    }

    /**
     * 掲載面（新聞のみ）を取得する
     *
     * @return 掲載面（新聞のみ）
     */
    public String getPostedsurface() {
        return _postedsurface;
    }

    /**
     * 掲載面（新聞のみ）を設定する
     *
     * @param postedsurface 掲載面（新聞のみ）
     */
    public void setPostedsurface(String postedsurface) {
        this._postedsurface = postedsurface;
    }

    /**
     * 単位（新聞のみ）を取得する
     *
     * @return 単位（新聞のみ）
     */
    public String getUnit() {
        return _unit;
    }

    /**
     * 単位（新聞のみ）を設定する
     *
     * @param unit 単位（新聞のみ）
     */
    public void setUnit(String unit) {
        this._unit = unit;
    }

    /**
     * 契約区分（新聞のみ）を取得する
     *
     * @return 契約区分（新聞のみ）
     */
    public String getContractdivision() {
        return _contractdivision;
    }

    /**
     * 契約区分（新聞のみ）を設定する
     *
     * @param contractdivision 契約区分（新聞のみ）
     */
    public void setContractdivision(String contractdivision) {
        this._contractdivision = contractdivision;
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * 期間開始を設定する
     *
     * @param kikanfrom 期間開始
     */
    public void setKikanfrom(Date kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanto() {
        return _kikanto;
    }

    /**
     * 期間終了を設定する
     *
     * @param kikanto 期間終了
     */
    public void setKikanto(Date kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * 原価入力フラグを取得する
     *
     * @return 原価入力フラグ
     */
    public String getGenkaflg() {
        return _genkaflg;
    }

    /**
     * 原価入力フラグを設定する
     *
     * @param genkaflg 原価入力フラグ
     */
    public void setGenkaflg(String genkaflg) {
        this._genkaflg = genkaflg;
    }

    /**
     * グロス金額を取得する
     *
     * @return グロス金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGross() {
        return _gross;
    }

    /**
     * グロス金額を設定する
     *
     * @param gross グロス金額
     */
    public void setGross(BigDecimal gross) {
        this._gross = gross;
    }

    /**
     * 電通値引率を取得する
     *
     * @return 電通値引率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebikiritsu() {
        return _dnebikiritsu;
    }

    /**
     * 電通値引率を設定する
     *
     * @param dnebikiritsu 電通値引率
     */
    public void setDnebikiritsu(BigDecimal dnebikiritsu) {
        this._dnebikiritsu = dnebikiritsu;
    }

    /**
     * 電通値引額を取得する
     *
     * @return 電通値引額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebikigaku() {
        return _dnebikigaku;
    }

    /**
     * 電通値引額を設定する
     *
     * @param dnebikigaku 電通値引額
     */
    public void setDnebikigaku(BigDecimal dnebikigaku) {
        this._dnebikigaku = dnebikigaku;
    }

    /**
     * H新モデルコストを取得する
     *
     * @return H新モデルコスト
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHmcost() {
        return _hmcost;
    }

    /**
     * H新モデルコストを設定する
     *
     * @param hmcost H新モデルコスト
     */
    public void setHmcost(BigDecimal hmcost) {
        this._hmcost = hmcost;
    }

    /**
     * 営業申込利益率を取得する
     *
     * @return 営業申込利益率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAplriekiritsu() {
        return _aplriekiritsu;
    }

    /**
     * 営業申込利益率を設定する
     *
     * @param aplriekiritsu 営業申込利益率
     */
    public void setAplriekiritsu(BigDecimal aplriekiritsu) {
        this._aplriekiritsu = aplriekiritsu;
    }

    /**
     * 営業申込利益額を取得する
     *
     * @return 営業申込利益額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAplriekigaku() {
        return _aplriekigaku;
    }

    /**
     * 営業申込利益額を設定する
     *
     * @param aplriekigaku 営業申込利益額
     */
    public void setAplriekigaku(BigDecimal aplriekigaku) {
        this._aplriekigaku = aplriekigaku;
    }

    /**
     * 媒体社払金額を取得する
     *
     * @return 媒体社払金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediaharai() {
        return _mediaharai;
    }

    /**
     * 媒体社払金額を設定する
     *
     * @param mediaharai 媒体社払金額
     */
    public void setMediaharai(BigDecimal mediaharai) {
        this._mediaharai = mediaharai;
    }

    /**
     * 媒体マージン率を取得する
     *
     * @return 媒体マージン率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediamarginritsu() {
        return _mediamarginritsu;
    }

    /**
     * 媒体マージン率を設定する
     *
     * @param mediamarginritsu 媒体マージン率
     */
    public void setMediamarginritsu(BigDecimal mediamarginritsu) {
        this._mediamarginritsu = mediamarginritsu;
    }

    /**
     * 媒体マージン額を取得する
     *
     * @return 媒体マージン額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediamargingaku() {
        return _mediamargingaku;
    }

    /**
     * 媒体マージン額を設定する
     *
     * @param mediamargingaku 媒体マージン額
     */
    public void setMediamargingaku(BigDecimal mediamargingaku) {
        this._mediamargingaku = mediamargingaku;
    }

    /**
     * 媒体原価を取得する
     *
     * @return 媒体原価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediagenka() {
        return _mediagenka;
    }

    /**
     * 媒体原価を設定する
     *
     * @param mediagenka 媒体原価
     */
    public void setMediagenka(BigDecimal mediagenka) {
        this._mediagenka = mediagenka;
    }

    /**
     * 取扱利益額を取得する
     *
     * @return 取扱利益額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getToririeki() {
        return _toririeki;
    }

    /**
     * 取扱利益額を設定する
     *
     * @param toririeki 取扱利益額
     */
    public void setToririeki(BigDecimal toririeki) {
        this._toririeki = toririeki;
    }

    /**
     * 通常利益配分額を取得する
     *
     * @return 通常利益配分額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRiekihaibun() {
        return _riekihaibun;
    }

    /**
     * 通常利益配分額を設定する
     *
     * @param riekihaibun 通常利益配分額
     */
    public void setRiekihaibun(BigDecimal riekihaibun) {
        this._riekihaibun = riekihaibun;
    }

    /**
     * 通常内勤利益額を取得する
     *
     * @return 通常内勤利益額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNaikinrieki() {
        return _naikinrieki;
    }

    /**
     * 通常内勤利益額を設定する
     *
     * @param naikinrieki 通常内勤利益額
     */
    public void setNaikinrieki(BigDecimal naikinrieki) {
        this._naikinrieki = naikinrieki;
    }

    /**
     * 振替利益配分額を取得する
     *
     * @return 振替利益配分額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getFurikaerieki() {
        return _furikaerieki;
    }

    /**
     * 振替利益配分額を設定する
     *
     * @param furikaerieki 振替利益配分額
     */
    public void setFurikaerieki(BigDecimal furikaerieki) {
        this._furikaerieki = furikaerieki;
    }

    /**
     * 営業要因額を取得する
     *
     * @return 営業要因額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEigyoyoin() {
        return _eigyoyoin;
    }

    /**
     * 営業要因額を設定する
     *
     * @param eigyoyoin 営業要因額
     */
    public void setEigyoyoin(BigDecimal eigyoyoin) {
        this._eigyoyoin = eigyoyoin;
    }

    /**
     * 振替利益配分額2を取得する
     *
     * @return 振替利益配分額2
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getFurikaerieki2() {
        return _furikaerieki2;
    }

    /**
     * 振替利益配分額2を設定する
     *
     * @param furikaerieki2 振替利益配分額2
     */
    public void setFurikaerieki2(BigDecimal furikaerieki2) {
        this._furikaerieki2 = furikaerieki2;
    }

    /**
     * テレビタイム媒体社払単価を取得する
     *
     * @return テレビタイム媒体社払単価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTvtmediatanka() {
        return _tvtmediatanka;
    }

    /**
     * テレビタイム媒体社払単価を設定する
     *
     * @param tvtmediatanka テレビタイム媒体社払単価
     */
    public void setTvtmediatanka(BigDecimal tvtmediatanka) {
        this._tvtmediatanka = tvtmediatanka;
    }

    /**
     * テレビタイムHM単価を取得する
     *
     * @return テレビタイムHM単価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTvthmtanka() {
        return _tvthmtanka;
    }

    /**
     * テレビタイムHM単価を設定する
     *
     * @param tvthmtanka テレビタイムHM単価
     */
    public void setTvthmtanka(BigDecimal tvthmtanka) {
        this._tvthmtanka = tvthmtanka;
    }

    /**
     * 色刷料（新聞のみ）を取得する
     *
     * @return 色刷料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getColorfee() {
        return _colorfee;
    }

    /**
     * 色刷料（新聞のみ）を設定する
     *
     * @param colorfee 色刷料（新聞のみ）
     */
    public void setColorfee(BigDecimal colorfee) {
        this._colorfee = colorfee;
    }

    /**
     * 指定料（新聞のみ）を取得する
     *
     * @return 指定料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDesignationfee() {
        return _designationfee;
    }

    /**
     * 指定料（新聞のみ）を設定する
     *
     * @param designationfee 指定料（新聞のみ）
     */
    public void setDesignationfee(BigDecimal designationfee) {
        this._designationfee = designationfee;
    }

    /**
     * 二連版料（新聞のみ）を取得する
     *
     * @return 二連版料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDoublefee() {
        return _doublefee;
    }

    /**
     * 二連版料（新聞のみ）を設定する
     *
     * @param doublefee 二連版料（新聞のみ）
     */
    public void setDoublefee(BigDecimal doublefee) {
        this._doublefee = doublefee;
    }

    /**
     * 組替料（新聞のみ）を取得する
     *
     * @return 組替料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getReclassificationfee() {
        return _reclassificationfee;
    }

    /**
     * 組替料（新聞のみ）を設定する
     *
     * @param reclassificationfee 組替料（新聞のみ）
     */
    public void setReclassificationfee(BigDecimal reclassificationfee) {
        this._reclassificationfee = reclassificationfee;
    }

    /**
     * 変形スペース料（新聞のみ）を取得する
     *
     * @return 変形スペース料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSpacefee() {
        return _spacefee;
    }

    /**
     * 変形スペース料（新聞のみ）を設定する
     *
     * @param spacefee 変形スペース料（新聞のみ）
     */
    public void setSpacefee(BigDecimal spacefee) {
        this._spacefee = spacefee;
    }

    /**
     * スプリットラン料（新聞のみ）を取得する
     *
     * @return スプリットラン料（新聞のみ）
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSplitrunfee() {
        return _splitrunfee;
    }

    /**
     * スプリットラン料（新聞のみ）を設定する
     *
     * @param splitrunfee スプリットラン料（新聞のみ）
     */
    public void setSplitrunfee(BigDecimal splitrunfee) {
        this._splitrunfee = splitrunfee;
    }

    /**
     * 依頼先（新聞のみ）を取得する
     *
     * @return 依頼先（新聞のみ）
     */
    public String getRequestdestination() {
        return _requestdestination;
    }

    /**
     * 依頼先（新聞のみ）を設定する
     *
     * @param requestdestination 依頼先（新聞のみ）
     */
    public void setRequestdestination(String requestdestination) {
        this._requestdestination = requestdestination;
    }

    /**
     * 放送日を取得する
     *
     * @return 放送日
     */
    public String getBrddate() {
        return _brddate;
    }

    /**
     * 放送日を設定する
     *
     * @param brddate 放送日
     */
    public void setBrddate(String brddate) {
        this._brddate = brddate;
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBiko() {
        return _biko;
    }

    /**
     * 備考を設定する
     *
     * @param biko 備考
     */
    public void setBiko(String biko) {
        this._biko = biko;
    }

    /**
     * 請求対象フラグを取得する
     *
     * @return 請求対象フラグ
     */
    public String getSeikyuflg() {
        return _seikyuflg;
    }

    /**
     * 請求対象フラグを設定する
     *
     * @param seikyuflg 請求対象フラグ
     */
    public void setSeikyuflg(String seikyuflg) {
        this._seikyuflg = seikyuflg;
    }

    /**
     * 日付設定(ラジオタイムのみ)を取得する
     *
     * @return 日付設定(ラジオタイムのみ)
     */
    public String getCpdate() {
        return _cpdate;
    }

    /**
     * 日付設定(ラジオタイムのみ)を設定する
     *
     * @param cpdate 日付設定(ラジオタイムのみ)
     */
    public void setCpdate(String cpdate) {
        this._cpdate = cpdate;
    }

    /**
     * 秒数(ラジオタイムのみ)を取得する
     *
     * @return 秒数(ラジオタイムのみ)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBrdsec() {
        return _brdsec;
    }

    /**
     * 秒数(ラジオタイムのみ)を設定する
     *
     * @param brdsec 秒数(ラジオタイムのみ)
     */
    public void setBrdsec(BigDecimal brdsec) {
        this._brdsec = brdsec;
    }

    /**
     * 受注ファイル出力フラグ（新聞のみ）を取得する
     *
     * @return 受注ファイル出力フラグ（新聞のみ）
     */
    public String getFileoutflg() {
        return _fileoutflg;
    }

    /**
     * 受注ファイル出力フラグ（新聞のみ）を設定する
     *
     * @param fileoutflg 受注ファイル出力フラグ（新聞のみ）
     */
    public void setFileoutflg(String fileoutflg) {
        this._fileoutflg = fileoutflg;
    }

    /**
     * 掲載日を取得する
     *
     * @return 掲載日
     */
    @XmlElement(required = true, nillable = true)
    public Date getAppearancedate() {
        return _appearancedate;
    }

    /**
     * 掲載日を設定する
     *
     * @param appearancedate 掲載日
     */
    public void setAppearancedate(Date appearancedate) {
        this._appearancedate = appearancedate;
    }

    /**
     * ソート順を取得する
     *
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * ソート順を設定する
     *
     * @param sortno ソート順
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * データ作成日時を設定する
     *
     * @param crtdate データ作成日時
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * データ作成者を設定する
     *
     * @param crtnm データ作成者
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * 作成プログラムを設定する
     *
     * @param crtapl 作成プログラム
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param crtid 作成担当者ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * データ更新日時を設定する
     *
     * @param upddate データ更新日時
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * データ更新者を設定する
     *
     * @param updnm データ更新者
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * 更新プログラムを設定する
     *
     * @param updapl 更新プログラム
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param updid 更新担当者ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
