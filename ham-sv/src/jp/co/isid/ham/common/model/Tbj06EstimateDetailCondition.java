package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 見積明細検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj06EstimateDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積明細管理NO */
    private BigDecimal _estdetailseqno = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 年月 */
    private Date _crdate = null;

    /** 見積案件管理NO */
    private BigDecimal _estseqno = null;

    /** ソート順 */
    private BigDecimal _sortno = null;

    /** 商品コード */
    private String _productcd = null;

    /** 商品名 */
    private String _productnm = null;

    /** 商品名(サブ） */
    private String _productnmsub = null;

    /** 媒体分類コード */
    private String _mediaclasscd = null;

    /** 媒体コード */
    private String _mediacd = null;

    /** 業務分類コード */
    private String _businessclasscd = null;

    /** 業務コード */
    private String _businesscd = null;

    /** 摘要 */
    private String _tekiyou = null;

    /** 実施日 */
    private Date _operationdate = null;

    /** サイズコード */
    private String _sizecd = null;

    /** サイズ */
    private String _size = null;

    /** 数量 */
    private BigDecimal _suuryou = null;

    /** 単位グループコード */
    private String _unitgroupcd = null;

    /** 単位グループ名 */
    private String _unitgroupnm = null;

    /** 単価 */
    private BigDecimal _tanka = null;

    /** 標準金額 */
    private BigDecimal _hyoujun = null;

    /** 値引額 */
    private BigDecimal _nebiki = null;

    /** 見積金額 */
    private BigDecimal _mitumori = null;

    /** 課税対象額 */
    private BigDecimal _kazei = null;

    /** 消費税額 */
    private BigDecimal _syouhizei = null;

    /** 合計金額 */
    private BigDecimal _goukei = null;

    /** 仕入消費税計算区分 */
    private String _calkbn = null;

    /** 納入フラグ */
    private String _nounyuuflg = null;

    /** 出来高フラグ */
    private String _dekidakaflg = null;

    /** 出力グループ */
    private String _outputgroup = null;

    /** 請求先グループ */
    private String _hcbumoncdbill = null;

    /** 請求先グループ出力順SEQNO */
    private BigDecimal _hcbumoncdbillseqno = null;

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
    public Tbj06EstimateDetailCondition() {
    }

    /**
     * 見積明細管理NOを取得する
     *
     * @return 見積明細管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstdetailseqno() {
        return _estdetailseqno;
    }

    /**
     * 見積明細管理NOを設定する
     *
     * @param estdetailseqno 見積明細管理NO
     */
    public void setEstdetailseqno(BigDecimal estdetailseqno) {
        this._estdetailseqno = estdetailseqno;
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
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrdate() {
        return _crdate;
    }

    /**
     * 年月を設定する
     *
     * @param crdate 年月
     */
    public void setCrdate(Date crdate) {
        this._crdate = crdate;
    }

    /**
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstseqno() {
        return _estseqno;
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param estseqno 見積案件管理NO
     */
    public void setEstseqno(BigDecimal estseqno) {
        this._estseqno = estseqno;
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
     * 商品コードを取得する
     *
     * @return 商品コード
     */
    public String getProductcd() {
        return _productcd;
    }

    /**
     * 商品コードを設定する
     *
     * @param productcd 商品コード
     */
    public void setProductcd(String productcd) {
        this._productcd = productcd;
    }

    /**
     * 商品名を取得する
     *
     * @return 商品名
     */
    public String getProductnm() {
        return _productnm;
    }

    /**
     * 商品名を設定する
     *
     * @param productnm 商品名
     */
    public void setProductnm(String productnm) {
        this._productnm = productnm;
    }

    /**
     * 商品名(サブ）を取得する
     *
     * @return 商品名(サブ）
     */
    public String getProductnmsub() {
        return _productnmsub;
    }

    /**
     * 商品名(サブ）を設定する
     *
     * @param productnmsub 商品名(サブ）
     */
    public void setProductnmsub(String productnmsub) {
        this._productnmsub = productnmsub;
    }

    /**
     * 媒体分類コードを取得する
     *
     * @return 媒体分類コード
     */
    public String getMediaclasscd() {
        return _mediaclasscd;
    }

    /**
     * 媒体分類コードを設定する
     *
     * @param mediaclasscd 媒体分類コード
     */
    public void setMediaclasscd(String mediaclasscd) {
        this._mediaclasscd = mediaclasscd;
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
     * 業務分類コードを取得する
     *
     * @return 業務分類コード
     */
    public String getBusinessclasscd() {
        return _businessclasscd;
    }

    /**
     * 業務分類コードを設定する
     *
     * @param businessclasscd 業務分類コード
     */
    public void setBusinessclasscd(String businessclasscd) {
        this._businessclasscd = businessclasscd;
    }

    /**
     * 業務コードを取得する
     *
     * @return 業務コード
     */
    public String getBusinesscd() {
        return _businesscd;
    }

    /**
     * 業務コードを設定する
     *
     * @param businesscd 業務コード
     */
    public void setBusinesscd(String businesscd) {
        this._businesscd = businesscd;
    }

    /**
     * 摘要を取得する
     *
     * @return 摘要
     */
    public String getTekiyou() {
        return _tekiyou;
    }

    /**
     * 摘要を設定する
     *
     * @param tekiyou 摘要
     */
    public void setTekiyou(String tekiyou) {
        this._tekiyou = tekiyou;
    }

    /**
     * 実施日を取得する
     *
     * @return 実施日
     */
    @XmlElement(required = true, nillable = true)
    public Date getOperationdate() {
        return _operationdate;
    }

    /**
     * 実施日を設定する
     *
     * @param operationdate 実施日
     */
    public void setOperationdate(Date operationdate) {
        this._operationdate = operationdate;
    }

    /**
     * サイズコードを取得する
     *
     * @return サイズコード
     */
    public String getSizecd() {
        return _sizecd;
    }

    /**
     * サイズコードを設定する
     *
     * @param sizecd サイズコード
     */
    public void setSizecd(String sizecd) {
        this._sizecd = sizecd;
    }

    /**
     * サイズを取得する
     *
     * @return サイズ
     */
    public String getSize() {
        return _size;
    }

    /**
     * サイズを設定する
     *
     * @param size サイズ
     */
    public void setSize(String size) {
        this._size = size;
    }

    /**
     * 数量を取得する
     *
     * @return 数量
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSuuryou() {
        return _suuryou;
    }

    /**
     * 数量を設定する
     *
     * @param suuryou 数量
     */
    public void setSuuryou(BigDecimal suuryou) {
        this._suuryou = suuryou;
    }

    /**
     * 単位グループコードを取得する
     *
     * @return 単位グループコード
     */
    public String getUnitgroupcd() {
        return _unitgroupcd;
    }

    /**
     * 単位グループコードを設定する
     *
     * @param unitgroupcd 単位グループコード
     */
    public void setUnitgroupcd(String unitgroupcd) {
        this._unitgroupcd = unitgroupcd;
    }

    /**
     * 単位グループ名を取得する
     *
     * @return 単位グループ名
     */
    public String getUnitgroupnm() {
        return _unitgroupnm;
    }

    /**
     * 単位グループ名を設定する
     *
     * @param unitgroupnm 単位グループ名
     */
    public void setUnitgroupnm(String unitgroupnm) {
        this._unitgroupnm = unitgroupnm;
    }

    /**
     * 単価を取得する
     *
     * @return 単価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTanka() {
        return _tanka;
    }

    /**
     * 単価を設定する
     *
     * @param tanka 単価
     */
    public void setTanka(BigDecimal tanka) {
        this._tanka = tanka;
    }

    /**
     * 標準金額を取得する
     *
     * @return 標準金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHyoujun() {
        return _hyoujun;
    }

    /**
     * 標準金額を設定する
     *
     * @param hyoujun 標準金額
     */
    public void setHyoujun(BigDecimal hyoujun) {
        this._hyoujun = hyoujun;
    }

    /**
     * 値引額を取得する
     *
     * @return 値引額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNebiki() {
        return _nebiki;
    }

    /**
     * 値引額を設定する
     *
     * @param nebiki 値引額
     */
    public void setNebiki(BigDecimal nebiki) {
        this._nebiki = nebiki;
    }

    /**
     * 見積金額を取得する
     *
     * @return 見積金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMitumori() {
        return _mitumori;
    }

    /**
     * 見積金額を設定する
     *
     * @param mitumori 見積金額
     */
    public void setMitumori(BigDecimal mitumori) {
        this._mitumori = mitumori;
    }

    /**
     * 課税対象額を取得する
     *
     * @return 課税対象額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getKazei() {
        return _kazei;
    }

    /**
     * 課税対象額を設定する
     *
     * @param kazei 課税対象額
     */
    public void setKazei(BigDecimal kazei) {
        this._kazei = kazei;
    }

    /**
     * 消費税額を取得する
     *
     * @return 消費税額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSyouhizei() {
        return _syouhizei;
    }

    /**
     * 消費税額を設定する
     *
     * @param syouhizei 消費税額
     */
    public void setSyouhizei(BigDecimal syouhizei) {
        this._syouhizei = syouhizei;
    }

    /**
     * 合計金額を取得する
     *
     * @return 合計金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGoukei() {
        return _goukei;
    }

    /**
     * 合計金額を設定する
     *
     * @param goukei 合計金額
     */
    public void setGoukei(BigDecimal goukei) {
        this._goukei = goukei;
    }

    /**
     * 仕入消費税計算区分を取得する
     *
     * @return 仕入消費税計算区分
     */
    public String getCalkbn() {
        return _calkbn;
    }

    /**
     * 仕入消費税計算区分を設定する
     *
     * @param calkbn 仕入消費税計算区分
     */
    public void setCalkbn(String calkbn) {
        this._calkbn = calkbn;
    }

    /**
     * 納入フラグを取得する
     *
     * @return 納入フラグ
     */
    public String getNounyuuflg() {
        return _nounyuuflg;
    }

    /**
     * 納入フラグを設定する
     *
     * @param nounyuuflg 納入フラグ
     */
    public void setNounyuuflg(String nounyuuflg) {
        this._nounyuuflg = nounyuuflg;
    }

    /**
     * 出来高フラグを取得する
     *
     * @return 出来高フラグ
     */
    public String getDekidakaflg() {
        return _dekidakaflg;
    }

    /**
     * 出来高フラグを設定する
     *
     * @param dekidakaflg 出来高フラグ
     */
    public void setDekidakaflg(String dekidakaflg) {
        this._dekidakaflg = dekidakaflg;
    }

    /**
     * 出力グループを取得する
     *
     * @return 出力グループ
     */
    public String getOutputgroup() {
        return _outputgroup;
    }

    /**
     * 出力グループを設定する
     *
     * @param outputgroup 出力グループ
     */
    public void setOutputgroup(String outputgroup) {
        this._outputgroup = outputgroup;
    }

    /**
     * 請求先グループを取得する
     *
     * @return 請求先グループ
     */
    public String getHcbumoncdbill() {
        return _hcbumoncdbill;
    }

    /**
     * 請求先グループを設定する
     *
     * @param hcbumoncdbill 請求先グループ
     */
    public void setHcbumoncdbill(String hcbumoncdbill) {
        this._hcbumoncdbill = hcbumoncdbill;
    }

    /**
     * 請求先グループ出力順SEQNOを取得する
     *
     * @return 請求先グループ出力順SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHcbumoncdbillseqno() {
        return _hcbumoncdbillseqno;
    }

    /**
     * 請求先グループ出力順SEQNOを設定する
     *
     * @param hcbumoncdbillseqno 請求先グループ出力順SEQNO
     */
    public void setHcbumoncdbillseqno(BigDecimal hcbumoncdbillseqno) {
        this._hcbumoncdbillseqno = hcbumoncdbillseqno;
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
