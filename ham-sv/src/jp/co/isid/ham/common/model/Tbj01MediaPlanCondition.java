package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 媒体状況管理検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj01MediaPlanCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** キャンペーンコード */
    private String _campcd = null;

    /** 媒体管理No */
    private BigDecimal _mediaplanno = null;

    /** 出稿予定年月 */
    private Date _yoteiym = null;

    /** 系列コード */
    private String _keirestucd = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 媒体コード */
    private String _mediacd = null;

    /** 費用計画No */
    private String _hiyouno = null;

    /** 代理店名 */
    private String _agency = null;

    /** 広告件名 */
    private String _kenmei = null;

    /** 特記事項 */
    private String _memo = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 期 */
    private String _term = null;

    /** 予定期間開始 */
    private Date _kikanfrom = null;

    /** 予定期間終了 */
    private Date _kikanto = null;

    /** ＨＭ承認 */
    private String _hmok = null;

    /** 媒体発注 */
    private String _buyerok = null;

    /** 予算金額 */
    private BigDecimal _budget = null;

    /** 予算金額(新) */
    private BigDecimal _budgethm = null;

    /** 実施金額 */
    private BigDecimal _actual = null;

    /** 実施金額(新) */
    private BigDecimal _actualhm = null;

    /** 調整金額 */
    private BigDecimal _adjustment = null;

    /** 予実差額 */
    private BigDecimal _difamt = null;

    /** 予実差額(新) */
    private BigDecimal _difamthm = null;

    /** 予算登録フラグ */
    private String _budgetupdflg = null;

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
    public Tbj01MediaPlanCondition() {
    }

    /**
     * キャンペーンコードを取得する
     *
     * @return キャンペーンコード
     */
    public String getCampcd() {
        return _campcd;
    }

    /**
     * キャンペーンコードを設定する
     *
     * @param campcd キャンペーンコード
     */
    public void setCampcd(String campcd) {
        this._campcd = campcd;
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
     * 出稿予定年月を取得する
     *
     * @return 出稿予定年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getYoteiym() {
        return _yoteiym;
    }

    /**
     * 出稿予定年月を設定する
     *
     * @param yoteiym 出稿予定年月
     */
    public void setYoteiym(Date yoteiym) {
        this._yoteiym = yoteiym;
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKeirestucd() {
        return _keirestucd;
    }

    /**
     * 系列コードを設定する
     *
     * @param keirestucd 系列コード
     */
    public void setKeirestucd(String keirestucd) {
        this._keirestucd = keirestucd;
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
     * 代理店名を取得する
     *
     * @return 代理店名
     */
    public String getAgency() {
        return _agency;
    }

    /**
     * 代理店名を設定する
     *
     * @param agency 代理店名
     */
    public void setAgency(String agency) {
        this._agency = agency;
    }

    /**
     * 広告件名を取得する
     *
     * @return 広告件名
     */
    public String getKenmei() {
        return _kenmei;
    }

    /**
     * 広告件名を設定する
     *
     * @param kenmei 広告件名
     */
    public void setKenmei(String kenmei) {
        this._kenmei = kenmei;
    }

    /**
     * 特記事項を取得する
     *
     * @return 特記事項
     */
    public String getMemo() {
        return _memo;
    }

    /**
     * 特記事項を設定する
     *
     * @param memo 特記事項
     */
    public void setMemo(String memo) {
        this._memo = memo;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * 期を取得する
     *
     * @return 期
     */
    public String getTerm() {
        return _term;
    }

    /**
     * 期を設定する
     *
     * @param term 期
     */
    public void setTerm(String term) {
        this._term = term;
    }

    /**
     * 予定期間開始を取得する
     *
     * @return 予定期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * 予定期間開始を設定する
     *
     * @param kikanfrom 予定期間開始
     */
    public void setKikanfrom(Date kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * 予定期間終了を取得する
     *
     * @return 予定期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanto() {
        return _kikanto;
    }

    /**
     * 予定期間終了を設定する
     *
     * @param kikanto 予定期間終了
     */
    public void setKikanto(Date kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * ＨＭ承認を取得する
     *
     * @return ＨＭ承認
     */
    public String getHmok() {
        return _hmok;
    }

    /**
     * ＨＭ承認を設定する
     *
     * @param hmok ＨＭ承認
     */
    public void setHmok(String hmok) {
        this._hmok = hmok;
    }

    /**
     * 媒体発注を取得する
     *
     * @return 媒体発注
     */
    public String getBuyerok() {
        return _buyerok;
    }

    /**
     * 媒体発注を設定する
     *
     * @param buyerok 媒体発注
     */
    public void setBuyerok(String buyerok) {
        this._buyerok = buyerok;
    }

    /**
     * 予算金額を取得する
     *
     * @return 予算金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBudget() {
        return _budget;
    }

    /**
     * 予算金額を設定する
     *
     * @param budget 予算金額
     */
    public void setBudget(BigDecimal budget) {
        this._budget = budget;
    }

    /**
     * 予算金額(新)を取得する
     *
     * @return 予算金額(新)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBudgethm() {
        return _budgethm;
    }

    /**
     * 予算金額(新)を設定する
     *
     * @param budgethm 予算金額(新)
     */
    public void setBudgethm(BigDecimal budgethm) {
        this._budgethm = budgethm;
    }

    /**
     * 実施金額を取得する
     *
     * @return 実施金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getActual() {
        return _actual;
    }

    /**
     * 実施金額を設定する
     *
     * @param actual 実施金額
     */
    public void setActual(BigDecimal actual) {
        this._actual = actual;
    }

    /**
     * 実施金額(新)を取得する
     *
     * @return 実施金額(新)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getActualhm() {
        return _actualhm;
    }

    /**
     * 実施金額(新)を設定する
     *
     * @param actualhm 実施金額(新)
     */
    public void setActualhm(BigDecimal actualhm) {
        this._actualhm = actualhm;
    }

    /**
     * 調整金額を取得する
     *
     * @return 調整金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAdjustment() {
        return _adjustment;
    }

    /**
     * 調整金額を設定する
     *
     * @param adjustment 調整金額
     */
    public void setAdjustment(BigDecimal adjustment) {
        this._adjustment = adjustment;
    }

    /**
     * 予実差額を取得する
     *
     * @return 予実差額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDifamt() {
        return _difamt;
    }

    /**
     * 予実差額を設定する
     *
     * @param difamt 予実差額
     */
    public void setDifamt(BigDecimal difamt) {
        this._difamt = difamt;
    }

    /**
     * 予実差額(新)を取得する
     *
     * @return 予実差額(新)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDifamthm() {
        return _difamthm;
    }

    /**
     * 予実差額(新)を設定する
     *
     * @param difamthm 予実差額(新)
     */
    public void setDifamthm(BigDecimal difamthm) {
        this._difamthm = difamthm;
    }

    /**
     * 予算登録フラグを取得する
     *
     * @return 予算登録フラグ
     */
    public String getBudgetupdflg() {
        return _budgetupdflg;
    }

    /**
     * 予算登録フラグを設定する
     *
     * @param budgetupdflg 予算登録フラグ
     */
    public void setBudgetupdflg(String budgetupdflg) {
        this._budgetupdflg = budgetupdflg;
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
