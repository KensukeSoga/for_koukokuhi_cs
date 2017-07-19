package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC商品選択取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/26 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCItemSelectionVO() {
    }


    /**
     * 媒体分類コードを取得する
     *
     * @return 媒体分類コード
     */
    public String getMEDIACLASSCD() {
        return (String) get(Mbj08HcProduct.MEDIACLASSCD);
    }

    /**
     * 媒体分類コードを設定する
     *
     * @param val 媒体分類コード
     */
    public void setMEDIACLASSCD(String val) {
        set(Mbj08HcProduct.MEDIACLASSCD, val);
    }

    /**
     * 媒体分類名を取得する
     *
     * @return 媒体分類名
     */
    public String getMEDIACLASSNM() {
        return (String) get(Mbj08HcProduct.MEDIACLASSNM);
    }

    /**
     * 媒体分類名を設定する
     *
     * @param val 媒体分類名
     */
    public void setMEDIACLASSNM(String val) {
        set(Mbj08HcProduct.MEDIACLASSNM, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Mbj08HcProduct.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Mbj08HcProduct.MEDIACD, val);
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * 媒体名を設定する
     *
     * @param val 媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj08HcProduct.MEDIANM, val);
    }

    /**
     * 業務分類コードを取得する
     *
     * @return 業務分類コード
     */
    public String getBUSINESSCLASSCD() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSCD);
    }

    /**
     * 業務分類コードを設定する
     *
     * @param val 業務分類コード
     */
    public void setBUSINESSCLASSCD(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSCD, val);
    }

    /**
     * 業務分類名を取得する
     *
     * @return 業務分類名
     */
    public String getBUSINESSCLASSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSNM);
    }

    /**
     * 業務分類名を設定する
     *
     * @param val 業務分類名
     */
    public void setBUSINESSCLASSNM(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSNM, val);
    }

    /**
     * 業務コードを取得する
     *
     * @return 業務コード
     */
    public String getBUSINESSCD() {
        return (String) get(Mbj08HcProduct.BUSINESSCD);
    }

    /**
     * 業務コードを設定する
     *
     * @param val 業務コード
     */
    public void setBUSINESSCD(String val) {
        set(Mbj08HcProduct.BUSINESSCD, val);
    }

    /**
     * 業務名を取得する
     *
     * @return 業務名
     */
    public String getBUSINESSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSNM);
    }

    /**
     * 業務名を設定する
     *
     * @param val 業務名
     */
    public void setBUSINESSNM(String val) {
        set(Mbj08HcProduct.BUSINESSNM, val);
    }

    /**
     * 商品コードを取得する
     *
     * @return 商品コード
     */
    public String getPRODUCTCD() {
        return (String) get(Mbj08HcProduct.PRODUCTCD);
    }

    /**
     * 商品コードを設定する
     *
     * @param val 商品コード
     */
    public void setPRODUCTCD(String val) {
        set(Mbj08HcProduct.PRODUCTCD, val);
    }

    /**
     * 商品名を取得する
     *
     * @return 商品名
     */
    public String getMstrPRODUCTNM() {
        return (String) get(Mbj08HcProduct.PRODUCTNM);
    }

    /**
     * 商品名を設定する
     *
     * @param val 商品名
     */
    public void setMstrPRODUCTNM(String val) {
        set(Mbj08HcProduct.PRODUCTNM, val);
    }

    /**
     * 商品名を取得する
     *
     * @return 商品名
     */
    public String getPRODUCTNM() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNM);
    }

    /**
     * 商品名を設定する
     *
     * @param val 商品名
     */
    public void setPRODUCTNM(String val) {
        set(Tbj06EstimateDetail.PRODUCTNM, val);
    }

    /**
     * 商品名(サブ）を取得する
     *
     * @return 商品名(サブ）
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * 商品名(サブ）を設定する
     *
     * @param val 商品名(サブ）
     */
    public void setPRODUCTNMSUB(String val) {
        set(Tbj06EstimateDetail.PRODUCTNMSUB, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj06EstimateDetail.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj06EstimateDetail.UPDID, val);
    }

    /**
     * 連番を取得する
     *
     * @return 連番
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNUM() {
        return (BigDecimal) get("NUM");
    }

    /**
     * 連番を設定する
     *
     * @param val 連番
     */
    public void setNum(BigDecimal val) {
        set("NUM", val);
    }

    /**
     * 詳細数を取得する
     *
     * @return 詳細数
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDETAILCNT() {
        return (BigDecimal) get("DETAILCNT");
    }

    /**
     * 詳細数を設定する
     *
     * @param val 詳細数
     */
    public void setDETAILCNT(BigDecimal val) {
        set("DETAILCNT",val);
    }
}
