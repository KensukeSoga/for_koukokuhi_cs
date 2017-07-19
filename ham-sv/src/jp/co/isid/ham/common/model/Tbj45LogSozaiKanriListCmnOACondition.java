package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 素材一覧（共有OA期間）ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HDX対応 K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj45LogSozaiKanriListCmnOACondition implements Serializable {

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

    /** 共通コード */
    private String _cmcd = null;

    /** 仮10桁CMｺｰﾄﾞ */
    private String _tempcmcd = null;

    /** OA期間 */
    private String _oadateterm = null;

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
    public Tbj45LogSozaiKanriListCmnOACondition() {
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
     * 共通コードを取得する
     *
     * @return 共通コード
     */
    public String getCmcd() {
        return _cmcd;
    }

    /**
     * 共通コードを設定する
     *
     * @param cmcd 共通コード
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
     * OA期間を取得する
     *
     * @return OA期間
     */
    public String getOadateterm() {
        return _oadateterm;
    }

    /**
     * OA期間を設定する
     *
     * @param oadateterm OA期間
     */
    public void setOadateterm(String oadateterm) {
        this._oadateterm = oadateterm;
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