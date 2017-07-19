package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * フィー管理検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj14FeeKanriCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 請求月 */
    private Date _seikyuym = null;

    /** 人件費 */
    private BigDecimal _jinkenhi = null;

    /** 販促費 */
    private BigDecimal _hansokuhi = null;

    /** 出張費 */
    private BigDecimal _syuttyouhi = null;

    /** 実費 */
    private BigDecimal _jippi = null;

    /** 暫定月額調整 */
    private BigDecimal _monthadjust = null;

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
    public Tbj14FeeKanriCondition() {
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
     * 請求月を取得する
     *
     * @return 請求月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSeikyuym() {
        return _seikyuym;
    }

    /**
     * 請求月を設定する
     *
     * @param seikyuym 請求月
     */
    public void setSeikyuym(Date seikyuym) {
        this._seikyuym = seikyuym;
    }

    /**
     * 人件費を取得する
     *
     * @return 人件費
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJinkenhi() {
        return _jinkenhi;
    }

    /**
     * 人件費を設定する
     *
     * @param jinkenhi 人件費
     */
    public void setJinkenhi(BigDecimal jinkenhi) {
        this._jinkenhi = jinkenhi;
    }

    /**
     * 販促費を取得する
     *
     * @return 販促費
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHansokuhi() {
        return _hansokuhi;
    }

    /**
     * 販促費を設定する
     *
     * @param hansokuhi 販促費
     */
    public void setHansokuhi(BigDecimal hansokuhi) {
        this._hansokuhi = hansokuhi;
    }

    /**
     * 出張費を取得する
     *
     * @return 出張費
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSyuttyouhi() {
        return _syuttyouhi;
    }

    /**
     * 出張費を設定する
     *
     * @param syuttyouhi 出張費
     */
    public void setSyuttyouhi(BigDecimal syuttyouhi) {
        this._syuttyouhi = syuttyouhi;
    }

    /**
     * 実費を取得する
     *
     * @return 実費
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJippi() {
        return _jippi;
    }

    /**
     * 実費を設定する
     *
     * @param jippi 実費
     */
    public void setJippi(BigDecimal jippi) {
        this._jippi = jippi;
    }

    /**
     * 暫定月額調整を取得する
     *
     * @return 暫定月額調整
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMonthadjust() {
        return _monthadjust;
    }

    /**
     * 暫定月額調整を設定する
     *
     * @param monthadjust 暫定月額調整
     */
    public void setMonthadjust(BigDecimal monthadjust) {
        this._monthadjust = monthadjust;
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
