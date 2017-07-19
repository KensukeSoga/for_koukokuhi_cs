package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * キャンペーン明細検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj13CampDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** キャンペーンコード */
    private String _campcd = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 媒体コード */
    private String _mediacd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 出稿予定年月 */
    private Date _yoteiym = null;

    /** 予定期間開始 */
    private Date _kikanfrom = null;

    /** 予定期間終了 */
    private Date _kikanto = null;

    /** 予算金額 */
    private BigDecimal _budget = null;

    /** 予算金額(新) */
    private BigDecimal _budgethm = null;

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
    public Tbj13CampDetailCondition() {
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
