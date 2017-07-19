package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 素材一覧変更ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj26LogSozaiKanriListCondition implements Serializable {

    private static final long serialVersionUID = 1L;

    /** 車種コード */
    private String _dcarcd = null;

    /** 年月 */
    private Date _sozaiym = null;

    /** 作成区分 */
    private String _reckbn = null;

    /** 作成番号 */
    private String _recno = null;

    /** 履歴NO */
    private BigDecimal _historyno = null;

    /** 履歴区分 */
    private String _historykbn = null;

    /** 削除フラグ */
    private String _delflg = null;

    /** 10桁CMｺｰﾄﾞ */
    private String _cmcd = null;

    /** 仮10桁CMｺｰﾄﾞ */
    private String _tempcmcd = null;

    /** タイトル */
    private String _title = null;

    /** 秒数 */
    private String _second = null;

    /** 素材略コード */
    private String _rcode = null;

    /** 予算 */
    private BigDecimal _estimate = null;

    /** OA開始日 */
    private Date _datefrom = null;

    /** OA開始日(属性) */
    private String _datefrom_attr = null;

    /** OA終了日 */
    private Date _dateto = null;

    /** OA終了日(属性) */
    private String _dateto_attr = null;

    /** 新素材ﾌﾗｸﾞ */
    private String _newflg = null;

    /** NEW表示 */
    private String _newdispflg = null;

    /** Time使用ﾌﾗｸﾞ */
    private String _timeuse = null;

    /** Spot使用ﾌﾗｸﾞ */
    private String _spotuse = null;

    /** Spot契約名 */
    private String _spotctrt = null;

    /** Spot期間 */
    private String _spotspan = null;

    /** Spot予算 */
    private BigDecimal _spotestm = null;

    /** 使用可能期間 */
    private Date _limit = null;

    /** 車種担当(電通) */
    private String _syatan = null;

    /** 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ) */
    private String _hcsyatan = null;

    /** 車種担当(ﾎﾝﾀﾞ) */
    private String _hmsyatan = null;

    /** 備考 */
    private String _biko = null;

    /** HDX開放ﾌﾗｸﾞ */
    private String _openflg = null;

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

    /** デフォルトコンストラクタ */
    public Tbj26LogSozaiKanriListCondition() {
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * 車種コードを設定する
     *
     * @param dcarcd 車種コード
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSozaiym() {
        return _sozaiym;
    }

    /**
     * 年月を設定する
     *
     * @param sozaiym 年月
     */
    public void setSozaiym(Date sozaiym) {
        this._sozaiym = sozaiym;
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getReckbn() {
        return _reckbn;
    }

    /**
     * 作成区分を設定する
     *
     * @param reckbn 作成区分
     */
    public void setReckbn(String reckbn) {
        this._reckbn = reckbn;
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRecno() {
        return _recno;
    }

    /**
     * 作成番号を設定する
     *
     * @param recno 作成番号
     */
    public void setRecno(String recno) {
        this._recno = recno;
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
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDelflg() {
        return _delflg;
    }

    /**
     * 削除フラグを設定する
     *
     * @param delflg 削除フラグ
     */
    public void setDelflg(String delflg) {
        this._delflg = delflg;
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCmcd() {
        return _cmcd;
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param cmcd 10桁CMｺｰﾄﾞ
     */
    public void setCmcd(String cmcd) {
        this._cmcd = cmcd;
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTempcmcd() {
        return _tempcmcd;
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param tempcmcd 仮10桁CMｺｰﾄﾞ
     */
    public void setTempcmcd(String tempcmcd) {
        this._tempcmcd = tempcmcd;
    }

    /**
     * タイトルを取得する
     *
     * @return タイトル
     */
    public String getTitle() {
        return _title;
    }

    /**
     * タイトルを設定する
     *
     * @param title タイトル
     */
    public void setTitle(String title) {
        this._title = title;
    }

    /**
     * 秒数を取得する
     *
     * @return 秒数
     */
    public String getSecond() {
        return _second;
    }

    /**
     * 秒数を設定する
     *
     * @param second 秒数
     */
    public void setSecond(String second) {
        this._second = second;
    }

    /**
     * 素材略コードを取得する
     *
     * @return 素材略コード
     */
    public String getRcode() {
        return _rcode;
    }

    /**
     * 素材略コードを設定する
     *
     * @param rcode 素材略コード
     */
    public void setRcode(String rcode) {
        this._rcode = rcode;
    }

    /**
     * 予算を取得する
     *
     * @return 予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstimate() {
        return _estimate;
    }

    /**
     * 予算を設定する
     *
     * @param estimate 予算
     */
    public void setEstimate(BigDecimal estimate) {
        this._estimate = estimate;
    }

    /**
     * OA開始日を取得する
     *
     * @return OA開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDatefrom() {
        return _datefrom;
    }

    /**
     * OA開始日を設定する
     *
     * @param datefrom OA開始日
     */
    public void setDatefrom(Date datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * OA開始日(属性)を取得する
     *
     * @return OA開始日(属性)
     */
    public String getDatefrom_attr() {
        return _datefrom_attr;
    }

    /**
     * OA開始日(属性)を設定する
     *
     * @param datefrom_attr OA開始日(属性)
     */
    public void setDatefrom_attr(String datefrom_attr) {
        this._datefrom_attr = datefrom_attr;
    }

    /**
     * OA終了日を取得する
     *
     * @return OA終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateto() {
        return _dateto;
    }

    /**
     * OA終了日を設定する
     *
     * @param dateto OA終了日
     */
    public void setDateto(Date dateto) {
        this._dateto = dateto;
    }

    /**
     * OA終了日(属性)を取得する
     *
     * @return OA終了日(属性)
     */
    public String getDateto_attr() {
        return _dateto_attr;
    }

    /**
     * OA終了日(属性)を設定する
     *
     * @param dateto_attr OA終了日(属性)
     */
    public void setDateto_attr(String dateto_attr) {
        this._dateto_attr = dateto_attr;
    }

    /**
     * 新素材ﾌﾗｸﾞを取得する
     *
     * @return 新素材ﾌﾗｸﾞ
     */
    public String getNewflg() {
        return _newflg;
    }

    /**
     * 新素材ﾌﾗｸﾞを設定する
     *
     * @param newflg 新素材ﾌﾗｸﾞ
     */
    public void setNewflg(String newflg) {
        this._newflg = newflg;
    }

    /**
     * NEW表示を取得する
     *
     * @return NEW表示
     */
    public String getNewdispflg() {
        return _newdispflg;
    }

    /**
     * NEW表示を設定する
     *
     * @param newdispflg NEW表示
     */
    public void setNewdispflg(String newdispflg) {
        this._newdispflg = newdispflg;
    }

    /**
     * Time使用ﾌﾗｸﾞを取得する
     *
     * @return Time使用ﾌﾗｸﾞ
     */
    public String getTimeuse() {
        return _timeuse;
    }

    /**
     * Time使用ﾌﾗｸﾞを設定する
     *
     * @param timeuse Time使用ﾌﾗｸﾞ
     */
    public void setTimeuse(String timeuse) {
        this._timeuse = timeuse;
    }

    /**
     * Spot使用ﾌﾗｸﾞを取得する
     *
     * @return Spot使用ﾌﾗｸﾞ
     */
    public String getSpotuse() {
        return _spotuse;
    }

    /**
     * Spot使用ﾌﾗｸﾞを設定する
     *
     * @param spotuse Spot使用ﾌﾗｸﾞ
     */
    public void setSpotuse(String spotuse) {
        this._spotuse = spotuse;
    }

    /**
     * Spot契約名を取得する
     *
     * @return Spot契約名
     */
    public String getSpotctrt() {
        return _spotctrt;
    }

    /**
     * Spot契約名を設定する
     *
     * @param spotctrt Spot契約名
     */
    public void setSpotctrt(String spotctrt) {
        this._spotctrt = spotctrt;
    }

    /**
     * Spot期間を取得する
     *
     * @return Spot期間
     */
    public String getSpotspan() {
        return _spotspan;
    }

    /**
     * Spot期間を設定する
     *
     * @param spotspan Spot期間
     */
    public void setSpotspan(String spotspan) {
        this._spotspan = spotspan;
    }

    /**
     * Spot予算を取得する
     *
     * @return Spot予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSpotestm() {
        return _spotestm;
    }

    /**
     * Spot予算を設定する
     *
     * @param spotestm Spot予算
     */
    public void setSpotestm(BigDecimal spotestm) {
        this._spotestm = spotestm;
    }

    /**
     * 使用可能期間を取得する
     *
     * @return 使用可能期間
     */
    @XmlElement(required = true, nillable = true)
    public Date getLimit() {
        return _limit;
    }

    /**
     * 使用可能期間を設定する
     *
     * @param limit 使用可能期間
     */
    public void setLimit(Date limit) {
        this._limit = limit;
    }

    /**
     * 車種担当(電通)を取得する
     *
     * @return 車種担当(電通)
     */
    public String getSyatan() {
        return _syatan;
    }

    /**
     * 車種担当(電通)を設定する
     *
     * @param syatan 車種担当(電通)
     */
    public void setSyatan(String syatan) {
        this._syatan = syatan;
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public String getHcsyatan() {
        return _hcsyatan;
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を設定する
     *
     * @param hcsyatan 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public void setHcsyatan(String hcsyatan) {
        this._hcsyatan = hcsyatan;
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞ)
     */
    public String getHmsyatan() {
        return _hmsyatan;
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を設定する
     *
     * @param hmsyatan 車種担当(ﾎﾝﾀﾞ)
     */
    public void setHmsyatan(String hmsyatan) {
        this._hmsyatan = hmsyatan;
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
     * HDX開放ﾌﾗｸﾞを取得する
     *
     * @return HDX開放ﾌﾗｸﾞ
     */
    public String getOpenflg() {
        return _openflg;
    }

    /**
     * HDX開放ﾌﾗｸﾞを設定する
     *
     * @param openflg HDX開放ﾌﾗｸﾞ
     */
    public void setOpenflg(String openflg) {
        this._openflg = openflg;
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