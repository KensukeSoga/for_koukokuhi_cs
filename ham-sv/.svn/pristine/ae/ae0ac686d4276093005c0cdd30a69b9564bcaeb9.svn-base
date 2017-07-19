package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM合計請求書作成(媒体)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillTotalMediaReportVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillTotalMediaReportVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillTotalMediaReportVO();
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * 宛先を取得する
     * @return String 宛先
     */
    public String getADDRESS() {
        return (String) get(Tbj05EstimateItem.ADDRESS);
    }

    /**
     * 宛先を設定する
     * @param val String 宛先
     */
    public void setADDRESS(String val) {
        set(Tbj05EstimateItem.ADDRESS, val);
    }

    /**
     * 納品期限を取得する
     * @return Date 納品期限
     */
    @XmlElement(required = true, nillable = true)
    public Date getDLVDATE() {
        return (Date) get(Tbj05EstimateItem.DLVDATE);
    }

    /**
     * 納品期限を設定する
     * @param val Date 納品期限
     */
    public void setDLVDATE(Date val) {
        set(Tbj05EstimateItem.DLVDATE, val);
    }

    /**
     * HC部門名を取得する
     * @return String HC部門名
     */
    public String getHCBUMONNM() {
        return (String) get(Mbj06HcBumon.HCBUMONNM);
    }

    /**
     * HC部門名を設定する
     * @param val String HC部門名
     */
    public void setHCBUMONNM(String val) {
        set(Mbj06HcBumon.HCBUMONNM, val);
    }

    /**
     * 郵便番号を取得する
     * @return String 郵便番号
     */
    public String getPOSTNO() {
        return (String) get(Mbj06HcBumon.POSTNO);
    }

    /**
     * 郵便番号を設定する
     * @param val String 郵便番号
     */
    public void setPOSTNO(String val) {
        set(Mbj06HcBumon.POSTNO, val);
    }

    /**
     * 住所１を取得する
     * @return String 住所１
     */
    public String getADDRESS1() {
        return (String) get(Mbj06HcBumon.ADDRESS1);
    }

    /**
     * 住所１を設定する
     * @param val String 住所１
     */
    public void setADDRESS1(String val) {
        set(Mbj06HcBumon.ADDRESS1, val);
    }

    /**
     * 住所２を取得する
     * @return String 住所２
     */
    public String getADDRESS2() {
        return (String) get(Mbj06HcBumon.ADDRESS2);
    }

    /**
     * 住所２を設定する
     * @param val String 住所２
     */
    public void setADDRESS2(String val) {
        set(Mbj06HcBumon.ADDRESS2, val);
    }

    /**
     * 部門会社名を取得する
     * @return String 部門会社名
     */
    public String getBUMONCORPNM() {
        return (String) get(Mbj06HcBumon.BUMONCORPNM);
    }

    /**
     * 部門会社名を設定する
     * @param val String 部門会社名
     */
    public void setBUMONCORPNM(String val) {
        set(Mbj06HcBumon.BUMONCORPNM, val);
    }

    /**
     * 見積金額を取得する
     * @return BigDecimal 見積金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMITUMORI() {
        return (BigDecimal) get(Tbj06EstimateDetail.MITUMORI);
    }

    /**
     * 見積金額を設定する
     * @param val BigDecimal 見積金額
     */
    public void setMITUMORI(BigDecimal val) {
        set(Tbj06EstimateDetail.MITUMORI, val);
    }

}
