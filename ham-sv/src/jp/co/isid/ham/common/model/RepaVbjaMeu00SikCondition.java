package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 組織マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu00SikCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 組織コード */
    private String _sikcd = null;

    /** 有効終了年月日 */
    private String _endymd = null;

    /** 初期登録日時 */
    private Date _insdate = null;

    /** 初期登録組織担当者コード */
    private String _inssiktntcd = null;

    /** 初期登録アプリＩＤ */
    private String _insaplid = null;

    /** 最終更新日時 */
    private Date _updapldate = null;

    /** 最終更新組織担当者コード */
    private String _updsiktntcd = null;

    /** 最終更新オンラインアプリＩＤ */
    private String _updonlaplid = null;

    /** 最終更新バッチアプリＩＤ */
    private String _updbataplid = null;

    /** 有効開始年月日 */
    private String _startymd = null;

    /** 会社識別コード */
    private String _kshaskbtucd = null;

    /** 入出力コード */
    private String _iocd = null;

    /** 表示名（カナ） */
    private String _hyojikn = null;

    /** 表示名（漢字） */
    private String _hyojikj = null;

    /** 表示略称 */
    private String _hyojiryaku = null;

    /** 表示名（英字） */
    private String _hyojien = null;

    /** 特殊用途コード */
    private String _spusecd = null;

    /** 階層コード */
    private String _kaisocd = null;

    /** 上位組織コード */
    private String _jsikcd = null;

    /** 直轄区分 */
    private String _ckatukbn = null;

    /** 受注登録区分 */
    private String _jytrkkbn = null;

    /** 発注登録区分 */
    private String _odrtrkkbn = null;

    /** 管理部門 */
    private String _knribmon = null;

    /** 会社取引先企業コード */
    private String _kshathskgycd = null;

    /** 会社取引先ＳＥＱＮＯ */
    private String _kshathsseqno = null;

    /** 旧会社取引先コード */
    private String _kyukshathscd = null;

    /** 媒直区分 */
    private String _bckkbn = null;

    /** 営業所コード */
    private String _egsyocd = null;

    /** 広告主別Ｐ／Ｌ部門種別 */
    private String _clntplbmnsbetu = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu00SikCondition() {
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * 組織コードを設定する
     *
     * @param sikcd 組織コード
     */
    public void setSikcd(String sikcd) {
        this._sikcd = sikcd;
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getEndymd() {
        return _endymd;
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param endymd 有効終了年月日
     */
    public void setEndymd(String endymd) {
        this._endymd = endymd;
    }

    /**
     * 初期登録日時を取得する
     *
     * @return 初期登録日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getInsdate() {
        return _insdate;
    }

    /**
     * 初期登録日時を設定する
     *
     * @param insdate 初期登録日時
     */
    public void setInsdate(Date insdate) {
        this._insdate = insdate;
    }

    /**
     * 初期登録組織担当者コードを取得する
     *
     * @return 初期登録組織担当者コード
     */
    public String getInssiktntcd() {
        return _inssiktntcd;
    }

    /**
     * 初期登録組織担当者コードを設定する
     *
     * @param inssiktntcd 初期登録組織担当者コード
     */
    public void setInssiktntcd(String inssiktntcd) {
        this._inssiktntcd = inssiktntcd;
    }

    /**
     * 初期登録アプリＩＤを取得する
     *
     * @return 初期登録アプリＩＤ
     */
    public String getInsaplid() {
        return _insaplid;
    }

    /**
     * 初期登録アプリＩＤを設定する
     *
     * @param insaplid 初期登録アプリＩＤ
     */
    public void setInsaplid(String insaplid) {
        this._insaplid = insaplid;
    }

    /**
     * 最終更新日時を取得する
     *
     * @return 最終更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpdapldate() {
        return _updapldate;
    }

    /**
     * 最終更新日時を設定する
     *
     * @param updapldate 最終更新日時
     */
    public void setUpdapldate(Date updapldate) {
        this._updapldate = updapldate;
    }

    /**
     * 最終更新組織担当者コードを取得する
     *
     * @return 最終更新組織担当者コード
     */
    public String getUpdsiktntcd() {
        return _updsiktntcd;
    }

    /**
     * 最終更新組織担当者コードを設定する
     *
     * @param updsiktntcd 最終更新組織担当者コード
     */
    public void setUpdsiktntcd(String updsiktntcd) {
        this._updsiktntcd = updsiktntcd;
    }

    /**
     * 最終更新オンラインアプリＩＤを取得する
     *
     * @return 最終更新オンラインアプリＩＤ
     */
    public String getUpdonlaplid() {
        return _updonlaplid;
    }

    /**
     * 最終更新オンラインアプリＩＤを設定する
     *
     * @param updonlaplid 最終更新オンラインアプリＩＤ
     */
    public void setUpdonlaplid(String updonlaplid) {
        this._updonlaplid = updonlaplid;
    }

    /**
     * 最終更新バッチアプリＩＤを取得する
     *
     * @return 最終更新バッチアプリＩＤ
     */
    public String getUpdbataplid() {
        return _updbataplid;
    }

    /**
     * 最終更新バッチアプリＩＤを設定する
     *
     * @param updbataplid 最終更新バッチアプリＩＤ
     */
    public void setUpdbataplid(String updbataplid) {
        this._updbataplid = updbataplid;
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getStartymd() {
        return _startymd;
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param startymd 有効開始年月日
     */
    public void setStartymd(String startymd) {
        this._startymd = startymd;
    }

    /**
     * 会社識別コードを取得する
     *
     * @return 会社識別コード
     */
    public String getKshaskbtucd() {
        return _kshaskbtucd;
    }

    /**
     * 会社識別コードを設定する
     *
     * @param kshaskbtucd 会社識別コード
     */
    public void setKshaskbtucd(String kshaskbtucd) {
        this._kshaskbtucd = kshaskbtucd;
    }

    /**
     * 入出力コードを取得する
     *
     * @return 入出力コード
     */
    public String getIocd() {
        return _iocd;
    }

    /**
     * 入出力コードを設定する
     *
     * @param iocd 入出力コード
     */
    public void setIocd(String iocd) {
        this._iocd = iocd;
    }

    /**
     * 表示名（カナ）を取得する
     *
     * @return 表示名（カナ）
     */
    public String getHyojikn() {
        return _hyojikn;
    }

    /**
     * 表示名（カナ）を設定する
     *
     * @param hyojikn 表示名（カナ）
     */
    public void setHyojikn(String hyojikn) {
        this._hyojikn = hyojikn;
    }

    /**
     * 表示名（漢字）を取得する
     *
     * @return 表示名（漢字）
     */
    public String getHyojikj() {
        return _hyojikj;
    }

    /**
     * 表示名（漢字）を設定する
     *
     * @param hyojikj 表示名（漢字）
     */
    public void setHyojikj(String hyojikj) {
        this._hyojikj = hyojikj;
    }

    /**
     * 表示略称を取得する
     *
     * @return 表示略称
     */
    public String getHyojiryaku() {
        return _hyojiryaku;
    }

    /**
     * 表示略称を設定する
     *
     * @param hyojiryaku 表示略称
     */
    public void setHyojiryaku(String hyojiryaku) {
        this._hyojiryaku = hyojiryaku;
    }

    /**
     * 表示名（英字）を取得する
     *
     * @return 表示名（英字）
     */
    public String getHyojien() {
        return _hyojien;
    }

    /**
     * 表示名（英字）を設定する
     *
     * @param hyojien 表示名（英字）
     */
    public void setHyojien(String hyojien) {
        this._hyojien = hyojien;
    }

    /**
     * 特殊用途コードを取得する
     *
     * @return 特殊用途コード
     */
    public String getSpusecd() {
        return _spusecd;
    }

    /**
     * 特殊用途コードを設定する
     *
     * @param spusecd 特殊用途コード
     */
    public void setSpusecd(String spusecd) {
        this._spusecd = spusecd;
    }

    /**
     * 階層コードを取得する
     *
     * @return 階層コード
     */
    public String getKaisocd() {
        return _kaisocd;
    }

    /**
     * 階層コードを設定する
     *
     * @param kaisocd 階層コード
     */
    public void setKaisocd(String kaisocd) {
        this._kaisocd = kaisocd;
    }

    /**
     * 上位組織コードを取得する
     *
     * @return 上位組織コード
     */
    public String getJsikcd() {
        return _jsikcd;
    }

    /**
     * 上位組織コードを設定する
     *
     * @param jsikcd 上位組織コード
     */
    public void setJsikcd(String jsikcd) {
        this._jsikcd = jsikcd;
    }

    /**
     * 直轄区分を取得する
     *
     * @return 直轄区分
     */
    public String getCkatukbn() {
        return _ckatukbn;
    }

    /**
     * 直轄区分を設定する
     *
     * @param ckatukbn 直轄区分
     */
    public void setCkatukbn(String ckatukbn) {
        this._ckatukbn = ckatukbn;
    }

    /**
     * 受注登録区分を取得する
     *
     * @return 受注登録区分
     */
    public String getJytrkkbn() {
        return _jytrkkbn;
    }

    /**
     * 受注登録区分を設定する
     *
     * @param jytrkkbn 受注登録区分
     */
    public void setJytrkkbn(String jytrkkbn) {
        this._jytrkkbn = jytrkkbn;
    }

    /**
     * 発注登録区分を取得する
     *
     * @return 発注登録区分
     */
    public String getOdrtrkkbn() {
        return _odrtrkkbn;
    }

    /**
     * 発注登録区分を設定する
     *
     * @param odrtrkkbn 発注登録区分
     */
    public void setOdrtrkkbn(String odrtrkkbn) {
        this._odrtrkkbn = odrtrkkbn;
    }

    /**
     * 管理部門を取得する
     *
     * @return 管理部門
     */
    public String getKnribmon() {
        return _knribmon;
    }

    /**
     * 管理部門を設定する
     *
     * @param knribmon 管理部門
     */
    public void setKnribmon(String knribmon) {
        this._knribmon = knribmon;
    }

    /**
     * 会社取引先企業コードを取得する
     *
     * @return 会社取引先企業コード
     */
    public String getKshathskgycd() {
        return _kshathskgycd;
    }

    /**
     * 会社取引先企業コードを設定する
     *
     * @param kshathskgycd 会社取引先企業コード
     */
    public void setKshathskgycd(String kshathskgycd) {
        this._kshathskgycd = kshathskgycd;
    }

    /**
     * 会社取引先ＳＥＱＮＯを取得する
     *
     * @return 会社取引先ＳＥＱＮＯ
     */
    public String getKshathsseqno() {
        return _kshathsseqno;
    }

    /**
     * 会社取引先ＳＥＱＮＯを設定する
     *
     * @param kshathsseqno 会社取引先ＳＥＱＮＯ
     */
    public void setKshathsseqno(String kshathsseqno) {
        this._kshathsseqno = kshathsseqno;
    }

    /**
     * 旧会社取引先コードを取得する
     *
     * @return 旧会社取引先コード
     */
    public String getKyukshathscd() {
        return _kyukshathscd;
    }

    /**
     * 旧会社取引先コードを設定する
     *
     * @param kyukshathscd 旧会社取引先コード
     */
    public void setKyukshathscd(String kyukshathscd) {
        this._kyukshathscd = kyukshathscd;
    }

    /**
     * 媒直区分を取得する
     *
     * @return 媒直区分
     */
    public String getBckkbn() {
        return _bckkbn;
    }

    /**
     * 媒直区分を設定する
     *
     * @param bckkbn 媒直区分
     */
    public void setBckkbn(String bckkbn) {
        this._bckkbn = bckkbn;
    }

    /**
     * 営業所コードを取得する
     *
     * @return 営業所コード
     */
    public String getEgsyocd() {
        return _egsyocd;
    }

    /**
     * 営業所コードを設定する
     *
     * @param egsyocd 営業所コード
     */
    public void setEgsyocd(String egsyocd) {
        this._egsyocd = egsyocd;
    }

    /**
     * 広告主別Ｐ／Ｌ部門種別を取得する
     *
     * @return 広告主別Ｐ／Ｌ部門種別
     */
    public String getClntplbmnsbetu() {
        return _clntplbmnsbetu;
    }

    /**
     * 広告主別Ｐ／Ｌ部門種別を設定する
     *
     * @param clntplbmnsbetu 広告主別Ｐ／Ｌ部門種別
     */
    public void setClntplbmnsbetu(String clntplbmnsbetu) {
        this._clntplbmnsbetu = clntplbmnsbetu;
    }

}
