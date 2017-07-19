package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM請求書(見積明細)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillDetailVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 税 */
    public static final String TAX = "TAX";

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillDetailVO() {
    }

    /**
     * 新規インスタンスを生成する
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillDetailVO();
    }

    /**
     * 見積明細管理NOを取得する
     * @return BigDecimal 見積明細管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * 見積明細管理NOを設定する
     * @param val BigDecimal 見積明細管理NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val Date 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     * @return BigDecimal 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     * @param val BigDecimal 見積案件管理NO
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    /**
     * ソート順を取得する
     * @return BigDecimal ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.SORTNO);
    }

    /**
     * ソート順を設定する
     * @param val BigDecimal ソート順
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj06EstimateDetail.SORTNO, val);
    }

    /**
     * 商品コードを取得する
     * @return String 商品コード
     */
    public String getPRODUCTCD() {
        return (String) get(Tbj06EstimateDetail.PRODUCTCD);
    }

    /**
     * 商品コードを設定する
     * @param val String 商品コード
     */
    public void setPRODUCTCD(String val) {
        set(Tbj06EstimateDetail.PRODUCTCD, val);
    }

    /**
     * 商品名を取得する
     * @return String 商品名
     */
    public String getPRODUCTNM() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNM);
    }

    /**
     * 商品名を設定する
     * @param val String 商品名
     */
    public void setPRODUCTNM(String val) {
        set(Tbj06EstimateDetail.PRODUCTNM, val);
    }

    /**
     * 商品名(サブ)を取得する
     * @return String 商品名(サブ）
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * 商品名(サブ)を設定する
     * @param val String 商品名(サブ)
     */
    public void setPRODUCTNMSUB(String val) {
        set(Tbj06EstimateDetail.PRODUCTNMSUB, val);
    }

    /**
     * 媒体分類コードを取得する
     * @return String 媒体分類コード
     */
    public String getMEDIACLASSCD() {
        return (String) get(Tbj06EstimateDetail.MEDIACLASSCD);
    }

    /**
     * 媒体分類コードを設定する
     * @param val String 媒体分類コード
     */
    public void setMEDIACLASSCD(String val) {
        set(Tbj06EstimateDetail.MEDIACLASSCD, val);
    }

    /**
     * 媒体コードを取得する
     * @return String 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj06EstimateDetail.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     * @param val String 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj06EstimateDetail.MEDIACD, val);
    }

    /**
     * 業務分類コードを取得する
     * @return String 業務分類コード
     */
    public String getBUSINESSCLASSCD() {
        return (String) get(Tbj06EstimateDetail.BUSINESSCLASSCD);
    }

    /**
     * 業務分類コードを設定する
     * @param val String 業務分類コード
     */
    public void setBUSINESSCLASSCD(String val) {
        set(Tbj06EstimateDetail.BUSINESSCLASSCD, val);
    }

    /**
     * 業務コードを取得する
     * @return String 業務コード
     */
    public String getBUSINESSCD() {
        return (String) get(Tbj06EstimateDetail.BUSINESSCD);
    }

    /**
     * 業務コードを設定する
     * @param val String 業務コード
     */
    public void setBUSINESSCD(String val) {
        set(Tbj06EstimateDetail.BUSINESSCD, val);
    }

    /**
     * 摘要を取得する
     * @return String 摘要
     */
    public String getTEKIYOU() {
        return (String) get(Tbj06EstimateDetail.TEKIYOU);
    }

    /**
     * 摘要を設定する
     * @param val String 摘要
     */
    public void setTEKIYOU(String val) {
        set(Tbj06EstimateDetail.TEKIYOU, val);
    }

    /**
     * 実施日を取得する
     * @return Date 実施日
     */
    @XmlElement(required = true, nillable = true)
    public Date getOPERATIONDATE() {
        return (Date) get(Tbj06EstimateDetail.OPERATIONDATE);
    }

    /**
     * 実施日を設定する
     * @param val Date 実施日
     */
    public void setOPERATIONDATE(Date val) {
        set(Tbj06EstimateDetail.OPERATIONDATE, val);
    }

    /**
     * サイズコードを取得する
     * @return String サイズコード
     */
    public String getSIZECD() {
        return (String) get(Tbj06EstimateDetail.SIZECD);
    }

    /**
     * サイズコードを設定する
     * @param val String サイズコード
     */
    public void setSIZECD(String val) {
        set(Tbj06EstimateDetail.SIZECD, val);
    }

    /**
     * サイズを取得する
     * @return String サイズ
     */
    public String getSIZE() {
        return (String) get(Tbj06EstimateDetail.SIZE);
    }

    /**
     * サイズを設定する
     * @param val String サイズ
     */
    public void setSIZE(String val) {
        set(Tbj06EstimateDetail.SIZE, val);
    }

    /**
     * 数量を取得する
     * @return BigDecimal 数量
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUURYOU() {
        return (BigDecimal) get(Tbj06EstimateDetail.SUURYOU);
    }

    /**
     * 数量を設定する
     * @param val BigDecimal 数量
     */
    public void setSUURYOU(BigDecimal val) {
        set(Tbj06EstimateDetail.SUURYOU, val);
    }

    /**
     * 単位グループコードを取得する
     * @return String 単位グループコード
     */
    public String getUNITGROUPCD() {
        return (String) get(Tbj06EstimateDetail.UNITGROUPCD);
    }

    /**
     * 単位グループコードを設定する
     * @param val String 単位グループコード
     */
    public void setUNITGROUPCD(String val) {
        set(Tbj06EstimateDetail.UNITGROUPCD, val);
    }

    /**
     * 単位グループ名を取得する
     * @return String 単位グループ名
     */
    public String getUNITGROUPNM() {
        return (String) get(Tbj06EstimateDetail.UNITGROUPNM);
    }

    /**
     * 単位グループ名を設定する
     * @param val String 単位グループ名
     */
    public void setUNITGROUPNM(String val) {
        set(Tbj06EstimateDetail.UNITGROUPNM, val);
    }

    /**
     * 単価を取得する
     * @return BigDecimal 単価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTANKA() {
        return (BigDecimal) get(Tbj06EstimateDetail.TANKA);
    }

    /**
     * 単価を設定する
     * @param val BigDecimal 単価
     */
    public void setTANKA(BigDecimal val) {
        set(Tbj06EstimateDetail.TANKA, val);
    }

    /**
     * 標準金額を取得する
     * @return BigDecimal 標準金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHYOUJUN() {
        return (BigDecimal) get(Tbj06EstimateDetail.HYOUJUN);
    }

    /**
     * 標準金額を設定する
     * @param val BigDecimal 標準金額
     */
    public void setHYOUJUN(BigDecimal val) {
        set(Tbj06EstimateDetail.HYOUJUN, val);
    }

    /**
     * 値引額を取得する
     * @return BigDecimal 値引額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNEBIKI() {
        return (BigDecimal) get(Tbj06EstimateDetail.NEBIKI);
    }

    /**
     * 値引額を設定する
     * @param val BigDecimal 値引額
     */
    public void setNEBIKI(BigDecimal val) {
        set(Tbj06EstimateDetail.NEBIKI, val);
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

    /**
     * 課税対象額を取得する
     *
     * @return BigDecimal 課税対象額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getKAZEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.KAZEI);
    }

    /**
     * 課税対象額を設定する
     * @param val BigDecimal 課税対象額
     */
    public void setKAZEI(BigDecimal val) {
        set(Tbj06EstimateDetail.KAZEI, val);
    }

    /**
     * 消費税額を取得する
     * @return BigDecimal 消費税額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSYOUHIZEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.SYOUHIZEI);
    }

    /**
     * 消費税額を設定する
     * @param val BigDecimal 消費税額
     */
    public void setSYOUHIZEI(BigDecimal val) {
        set(Tbj06EstimateDetail.SYOUHIZEI, val);
    }

    /**
     * 合計金額を取得する
     * @return BigDecimal 合計金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGOUKEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.GOUKEI);
    }

    /**
     * 合計金額を設定する
     * @param val BigDecimal 合計金額
     */
    public void setGOUKEI(BigDecimal val) {
        set(Tbj06EstimateDetail.GOUKEI, val);
    }

    /**
     * 仕入消費税計算区分を取得する
     * @return String 仕入消費税計算区分
     */
    public String getCALKBN() {
        return (String) get(Tbj06EstimateDetail.CALKBN);
    }

    /**
     * 仕入消費税計算区分を設定する
     * @param val String 仕入消費税計算区分
     */
    public void setCALKBN(String val) {
        set(Tbj06EstimateDetail.CALKBN, val);
    }

    /**
     * 納入フラグを取得する
     * @return String 納入フラグ
     */
    public String getNOUNYUUFLG() {
        return (String) get(Tbj06EstimateDetail.NOUNYUUFLG);
    }

    /**
     * 納入フラグを設定する
     * @param val String 納入フラグ
     */
    public void setNOUNYUUFLG(String val) {
        set(Tbj06EstimateDetail.NOUNYUUFLG, val);
    }

    /**
     * 出来高フラグを取得する
     * @return String 出来高フラグ
     */
    public String getDEKIDAKAFLG() {
        return (String) get(Tbj06EstimateDetail.DEKIDAKAFLG);
    }

    /**
     * 出来高フラグを設定する
     * @param val String 出来高フラグ
     */
    public void setDEKIDAKAFLG(String val) {
        set(Tbj06EstimateDetail.DEKIDAKAFLG, val);
    }

    /**
     * 出力グループを取得する
     * @return String 出力グループ
     */
    public String getOUTPUTGROUP() {
        return (String) get(Tbj06EstimateDetail.OUTPUTGROUP);
    }

    /**
     * 出力グループを設定する
     * @param val String 出力グループ
     */
    public void setOUTPUTGROUP(String val) {
        set(Tbj06EstimateDetail.OUTPUTGROUP, val);
    }

    /**
     * 請求先グループを取得する
     * @return String 請求先グループ
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Tbj06EstimateDetail.HCBUMONCDBILL);
    }

    /**
     * 請求先グループを設定する
     * @param val String 請求先グループ
     */
    public void setHCBUMONCDBILL(String val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILL, val);
    }

    /**
     * 請求先グループ出力順SEQNOを取得する
     * @return BigDecimal 請求先グループ出力順SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHCBUMONCDBILLSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);
    }

    /**
     * 請求先グループ出力順SEQNOを設定する
     * @param val BigDecimal 請求先グループ出力順SEQNO
     */
    public void setHCBUMONCDBILLSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }

    /**
     * データ作成日時を取得する
     * @return Date データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj06EstimateDetail.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     * @param val Date データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj06EstimateDetail.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     * @return String データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj06EstimateDetail.CRTNM);
    }

    /**
     * データ作成者を設定する
     * @param val String データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj06EstimateDetail.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     * @return String 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj06EstimateDetail.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     * @param val String 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj06EstimateDetail.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     * @return String 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj06EstimateDetail.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     * @param val String 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj06EstimateDetail.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     * @return Date データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj06EstimateDetail.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     * @param val Date データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj06EstimateDetail.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj06EstimateDetail.UPDNM);
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj06EstimateDetail.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj06EstimateDetail.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj06EstimateDetail.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj06EstimateDetail.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj06EstimateDetail.UPDID, val);
    }

    /**
     * 媒体分類名を取得する
     * @return String 媒体分類名
     */
    public String getMEDIACLASSNM() {
        return (String) get(Mbj08HcProduct.MEDIACLASSNM);
    }

    /**
     * 媒体分類名を設定する
     * @param val String 媒体分類名
     */
    public void setMEDIACLASSNM(String val) {
        set(Mbj08HcProduct.MEDIACLASSNM, val);
    }

    /**
     * 媒体名を取得する
     * @return String 媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * 媒体名を設定する
     * @param val String 媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj08HcProduct.MEDIANM, val);
    }

    /**
     * 業務分類名を取得する
     * @return String 業務分類名
     */
    public String getBUSINESSCLASSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSNM);
    }

    /**
     * 業務分類名を設定する
     * @param val String 業務分類名
     */
    public void setBUSINESSCLASSNM(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSNM, val);
    }

    /**
     * 業務名を取得する
     * @return String 業務名
     */
    public String getBUSINESSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSNM);
    }

    /**
     * 業務名を設定する
     * @param val String 業務名
     */
    public void setBUSINESSNM(String val) {
        set(Mbj08HcProduct.BUSINESSNM, val);
    }

    /**
     * 商品名を取得する
     * @return String 商品名
     */
    public String getMstrPRODUCTNM() {
        return (String) get(Mbj08HcProduct.PRODUCTNM);
    }

    /**
     * 商品名を設定する
     * @param val String 商品名
     */
    public void setMstrPRODUCTNM(String val) {
        set(Mbj08HcProduct.PRODUCTNM, val);
    }

    /**
     * 税を取得する
     * @return String 税
     */
    public String getTAX() {
        return (String) get(TAX);
    }

    /**
     * 税を設定する
     * @param val String 税
     */
    public void setTAX(String val) {
        set(TAX, val);
    }

}
