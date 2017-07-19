package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 仮素材登録変更ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj41LogTempSozaiKanriDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 系統 */
    private String _nokbn = null;

    /** 仮10桁CMｺｰﾄﾞ */
    private String _tempcmcd = null;

    /** 履歴NO */
    private BigDecimal _historyno = null;

    /** 10桁CMｺｰﾄﾞ */
    private String _cmcd = null;

    /** 履歴区分 */
    private String _historykbn = null;

    /** 削除フラグ */
    private String _delflg = null;

    /** 車種コード */
    private String _dcarcd = null;

    /** カテゴリ */
    private String _category = null;

    /** タイトル */
    private String _title = null;

    /** 秒数 */
    private String _second = null;

    /** 車種担当 */
    private String _syatan = null;

    /** 納品日 */
    private String _nohin = null;

    /** 制作ﾌﾟﾛﾀﾞｸｼｮﾝ */
    private String _product = null;

    /** 放送開始日 */
    private Date _datefrom = null;

    /** 放送終了日 */
    private Date _dateto = null;

    /** ﾒﾃﾞｨｱ使用期限 */
    private Date _mlimit = null;

    /** 権利使用期限 */
    private String _klimit = null;

    /** 正式承認日 */
    private Date _daterecog = null;

    /** 発行日 */
    private Date _dateprt = null;

    /** 備考 */
    private String _biko = null;

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
    public Tbj41LogTempSozaiKanriDataCondition() {
    }

    /**
     * 系統を取得する
     *
     * @return 系統
     */
    public String getNokbn() {
        return _nokbn;
    }

    /**
     * 系統を設定する
     *
     * @param nokbn 系統
     */
    public void setNokbn(String nokbn) {
        this._nokbn = nokbn;
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
     * カテゴリを取得する
     *
     * @return カテゴリ
     */
    public String getCategory() {
        return _category;
    }

    /**
     * カテゴリを設定する
     *
     * @param category カテゴリ
     */
    public void setCategory(String category) {
        this._category = category;
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
     * 車種担当を取得する
     *
     * @return 車種担当
     */
    public String getSyatan() {
        return _syatan;
    }

    /**
     * 車種担当を設定する
     *
     * @param syatan 車種担当
     */
    public void setSyatan(String syatan) {
        this._syatan = syatan;
    }

    /**
     * 納品日を取得する
     *
     * @return 納品日
     */
    public String getNohin() {
        return _nohin;
    }

    /**
     * 納品日を設定する
     *
     * @param nohin 納品日
     */
    public void setNohin(String nohin) {
        this._nohin = nohin;
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを取得する
     *
     * @return 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public String getProduct() {
        return _product;
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを設定する
     *
     * @param product 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public void setProduct(String product) {
        this._product = product;
    }

    /**
     * 放送開始日を取得する
     *
     * @return 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDatefrom() {
        return _datefrom;
    }

    /**
     * 放送開始日を設定する
     *
     * @param datefrom 放送開始日
     */
    public void setDatefrom(Date datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * 放送終了日を取得する
     *
     * @return 放送終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateto() {
        return _dateto;
    }

    /**
     * 放送終了日を設定する
     *
     * @param dateto 放送終了日
     */
    public void setDateto(Date dateto) {
        this._dateto = dateto;
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を取得する
     *
     * @return ﾒﾃﾞｨｱ使用期限
     */
    @XmlElement(required = true, nillable = true)
    public Date getMlimit() {
        return _mlimit;
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を設定する
     *
     * @param mlimit ﾒﾃﾞｨｱ使用期限
     */
    public void setMlimit(Date mlimit) {
        this._mlimit = mlimit;
    }

    /**
     * 権利使用期限を取得する
     *
     * @return 権利使用期限
     */
    public String getKlimit() {
        return _klimit;
    }

    /**
     * 権利使用期限を設定する
     *
     * @param klimit 権利使用期限
     */
    public void setKlimit(String klimit) {
        this._klimit = klimit;
    }

    /**
     * 正式承認日を取得する
     *
     * @return 正式承認日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDaterecog() {
        return _daterecog;
    }

    /**
     * 正式承認日を設定する
     *
     * @param daterecog 正式承認日
     */
    public void setDaterecog(Date daterecog) {
        this._daterecog = daterecog;
    }

    /**
     * 発行日を取得する
     *
     * @return 発行日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateprt() {
        return _dateprt;
    }

    /**
     * 発行日を設定する
     *
     * @param dateprt 発行日
     */
    public void setDateprt(Date dateprt) {
        this._dateprt = dateprt;
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
