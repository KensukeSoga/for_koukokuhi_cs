package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 費用企画Noマスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj09HiyouCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体コード */
    private String _mediacd = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 費用計画No */
    private String _hiyouno = null;

    /** 企画No */
    private String _kikakuno = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 期 */
    private String _term = null;

    /** 費用企画Noﾌﾗｸﾞ */
    private String _hiyouflg = null;

    /** HM部門コード */
    private String _hmdivcd = null;

    /** HM担当者コード */
    private String _hmusercd = null;

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
    public Mbj09HiyouCondition() {
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
     * 費用企画Noﾌﾗｸﾞを取得する
     *
     * @return 費用企画Noﾌﾗｸﾞ
     */
    public String getHiyouflg() {
        return _hiyouflg;
    }

    /**
     * 費用企画Noﾌﾗｸﾞを設定する
     *
     * @param hiyouflg 費用企画Noﾌﾗｸﾞ
     */
    public void setHiyouflg(String hiyouflg) {
        this._hiyouflg = hiyouflg;
    }

    /**
     * HM部門コードを取得する
     *
     * @return HM部門コード
     */
    public String getHmdivcd() {
        return _hmdivcd;
    }

    /**
     * HM部門コードを設定する
     *
     * @param hmdivcd HM部門コード
     */
    public void setHmdivcd(String hmdivcd) {
        this._hmdivcd = hmdivcd;
    }

    /**
     * HM担当者コードを取得する
     *
     * @return HM担当者コード
     */
    public String getHmusercd() {
        return _hmusercd;
    }

    /**
     * HM担当者コードを設定する
     *
     * @param hmusercd HM担当者コード
     */
    public void setHmusercd(String hmusercd) {
        this._hmusercd = hmusercd;
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
