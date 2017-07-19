package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC商品マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj08HcProductCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC商品コード */
    private BigDecimal _hcproductcd = null;

    /** 使用部門コード */
    private String _usebumoncd = null;

    /** 使用部門名 */
    private String _usebumonnm = null;

    /** 媒体分類コード */
    private String _mediaclasscd = null;

    /** 媒体分類名 */
    private String _mediaclassnm = null;

    /** 媒体コード */
    private String _mediacd = null;

    /** 媒体名 */
    private String _medianm = null;

    /** 業務分類コード */
    private String _businessclasscd = null;

    /** 業務分類名 */
    private String _businessclassnm = null;

    /** 業務コード */
    private String _businesscd = null;

    /** 業務名 */
    private String _businessnm = null;

    /** 商品コード */
    private String _productcd = null;

    /** 商品名 */
    private String _productnm = null;

    /** 週コード */
    private String _weekcd = null;

    /** 週 */
    private String _week = null;

    /** サイズコード */
    private String _sizecd = null;

    /** サイズ */
    private String _size = null;

    /** 単位グループコード */
    private String _unitgroupcd = null;

    /** 単位グループ名 */
    private String _unitgroupnm = null;

    /** 仕入消費税計算区分 */
    private String _calkbn = null;

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
    public Mbj08HcProductCondition() {
    }

    /**
     * HC商品コードを取得する
     *
     * @return HC商品コード
     */
    @XmlElement(nillable = true)
    public BigDecimal getHcproductcd() {
        return _hcproductcd;
    }

    /**
     * HC商品コードを設定する
     *
     * @param hcproductcd HC商品コード
     */
    public void setHcproductcd(BigDecimal hcproductcd) {
        this._hcproductcd = hcproductcd;
    }

    /**
     * 使用部門コードを取得する
     *
     * @return 使用部門コード
     */
    public String getUsebumoncd() {
        return _usebumoncd;
    }

    /**
     * 使用部門コードを設定する
     *
     * @param usebumoncd 使用部門コード
     */
    public void setUsebumoncd(String usebumoncd) {
        this._usebumoncd = usebumoncd;
    }

    /**
     * 使用部門名を取得する
     *
     * @return 使用部門名
     */
    public String getUsebumonnm() {
        return _usebumonnm;
    }

    /**
     * 使用部門名を設定する
     *
     * @param usebumonnm 使用部門名
     */
    public void setUsebumonnm(String usebumonnm) {
        this._usebumonnm = usebumonnm;
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
     * 媒体分類名を取得する
     *
     * @return 媒体分類名
     */
    public String getMediaclassnm() {
        return _mediaclassnm;
    }

    /**
     * 媒体分類名を設定する
     *
     * @param mediaclassnm 媒体分類名
     */
    public void setMediaclassnm(String mediaclassnm) {
        this._mediaclassnm = mediaclassnm;
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
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMedianm() {
        return _medianm;
    }

    /**
     * 媒体名を設定する
     *
     * @param medianm 媒体名
     */
    public void setMedianm(String medianm) {
        this._medianm = medianm;
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
     * 業務分類名を取得する
     *
     * @return 業務分類名
     */
    public String getBusinessclassnm() {
        return _businessclassnm;
    }

    /**
     * 業務分類名を設定する
     *
     * @param businessclassnm 業務分類名
     */
    public void setBusinessclassnm(String businessclassnm) {
        this._businessclassnm = businessclassnm;
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
     * 業務名を取得する
     *
     * @return 業務名
     */
    public String getBusinessnm() {
        return _businessnm;
    }

    /**
     * 業務名を設定する
     *
     * @param businessnm 業務名
     */
    public void setBusinessnm(String businessnm) {
        this._businessnm = businessnm;
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
     * 週コードを取得する
     *
     * @return 週コード
     */
    public String getWeekcd() {
        return _weekcd;
    }

    /**
     * 週コードを設定する
     *
     * @param weekcd 週コード
     */
    public void setWeekcd(String weekcd) {
        this._weekcd = weekcd;
    }

    /**
     * 週を取得する
     *
     * @return 週
     */
    public String getWeek() {
        return _week;
    }

    /**
     * 週を設定する
     *
     * @param week 週
     */
    public void setWeek(String week) {
        this._week = week;
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
