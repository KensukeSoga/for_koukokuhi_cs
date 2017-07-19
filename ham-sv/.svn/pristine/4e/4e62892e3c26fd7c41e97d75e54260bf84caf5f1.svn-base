package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM見積書、請求書作成(媒体)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/01/27 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateMediaReportVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMEstimateMediaReportVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMEstimateMediaReportVO();
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getItemPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setItemPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getItemCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val 年月
     */
    public void setItemCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     * @return BigDecimal 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getItemESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     * @param val BigDecimal 見積案件管理NO
     */
    public void setItemESTSEQNO(BigDecimal val) {
        set(Tbj05EstimateItem.ESTSEQNO, val);
    }

    /**
     * 見積種別を取得する
     * @return String 見積種別
     */
    public String getESTIMATECLASS() {
        return (String) get(Tbj05EstimateItem.ESTIMATECLASS);
    }

    /**
     * 見積種別を設定する
     * @param val String 見積種別
     */
    public void setESTIMATECLASS(String val) {
        set(Tbj05EstimateItem.ESTIMATECLASS, val);
    }

    /**
     * 見積日付を取得する
     * @return Date 見積日付
     */
    @XmlElement(required = true, nillable = true)
    public Date getESTIMATEDATE() {
        return (Date) get(Tbj05EstimateItem.ESTIMATEDATE);
    }

    /**
     * 見積日付を設定する
     * @param val Date 見積日付
     */
    public void setESTIMATEDATE(Date val) {
        set(Tbj05EstimateItem.ESTIMATEDATE, val);
    }

    /**
     * コープ区分を取得する
     * @return String コープ区分
     */
    public String getCOOPKBN() {
        return (String) get(Tbj05EstimateItem.COOPKBN);
    }

    /**
     * コープ区分を設定する
     * @param val String コープ区分
     */
    public void setCOOPKBN(String val) {
        set(Tbj05EstimateItem.COOPKBN, val);
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
     * 案件名を取得する
     * @return String 案件名
     */
    public String getESTIMATENM() {
        return (String) get(Tbj05EstimateItem.ESTIMATENM);
    }

    /**
     * 案件名を設定する
     * @param val String 案件名
     */
    public void setESTIMATENM(String val) {
        set(Tbj05EstimateItem.ESTIMATENM, val);
    }

    /**
     * HC部門コードを取得する
     * @return String HC部門コード
     */
    public String getHCBUMONCD() {
        return (String) get(Tbj05EstimateItem.HCBUMONCD);
    }

    /**
     * HC部門コードを設定する
     * @param val String HC部門コード
     */
    public void setHCBUMONCD(String val) {
        set(Tbj05EstimateItem.HCBUMONCD, val);
    }

    /**
     * HC担当者名を取得する
     * @return String HC担当者名
     */
    public String getHCUSERNM() {
        return (String) get(Tbj05EstimateItem.HCUSERNM);
    }

    /**
     * HC担当者名を設定する
     * @param val String HC担当者名
     */
    public void setHCUSERNM(String val) {
        set(Tbj05EstimateItem.HCUSERNM, val);
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
     * 値引率を取得する
     * @return BigDecimal 値引率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDISCOUNTRATE() {
        return (BigDecimal) get(Tbj05EstimateItem.DISCOUNTRATE);
    }

    /**
     * 値引率を設定する
     * @param val BigDecimal 値引率
     */
    public void setDISCOUNTRATE(BigDecimal val) {
        set(Tbj05EstimateItem.DISCOUNTRATE, val);
    }

    /**
     * 備考を取得する
     * @return String 備考
     */
    public String getBIKO() {
        return (String) get(Tbj05EstimateItem.BIKO);
    }

    /**
     * 備考を設定する
     * @param val String 備考
     */
    public void setBIKO(String val) {
        set(Tbj05EstimateItem.BIKO, val);
    }

    /**
     * 最終見積出力日時を取得する
     * @return Date 最終見積出力日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getLASTOUTPUTDATE() {
        return (Date) get(Tbj05EstimateItem.LASTOUTPUTDATE);
    }

    /**
     * 最終見積出力日時を設定する
     * @param val Date 最終見積出力日時
     */
    public void setLASTOUTPUTDATE(Date val) {
        set(Tbj05EstimateItem.LASTOUTPUTDATE, val);
    }

    /**
     * 最終見積出力担当者を取得する
     * @return String 最終見積出力担当者
     */
    public String getLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.LASTOUTPUTNM);
    }

    /**
     * 最終見積出力担当者を設定する
     * @param val String 最終見積出力担当者
     */
    public void setLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.LASTOUTPUTNM, val);
    }

    /**
     * 見積出力ファイル名を取得する
     * @return String 出力ファイル名
     */
    public String getOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.OUTPUTFILENM);
    }

    /**
     * 見積出力ファイル名を設定する
     * @param val String 出力ファイル名
     */
    public void setOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.OUTPUTFILENM, val);
    }

    /**
     * 請求明細書最終出力日時を取得する
     * @return String 請求明細書最終出力日時
     */
    public String getBILLDTLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE);
    }

    /**
     * 請求明細書最終出力日時を設定する
     * @param val String 請求明細書最終出力日時
     */
    public void setBILLDTLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE, val);
    }

    /**
     * 請求明細書最終出力担当者を取得する
     * @return String 請求明細書最終出力担当者
     */
    public String getBILLDTLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLDTLLASTOUTPUTNM);
    }

    /**
     * 請求明細書最終出力担当者を設定する
     * @param val String 請求明細書最終出力担当者
     */
    public void setBILLDTLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLDTLLASTOUTPUTNM, val);
    }

    /**
     * 請求明細書出力ファイル名を取得する
     * @return String 請求明細書出力ファイル名
     */
    public String getBILLDTLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLDTLOUTPUTFILENM);
    }

    /**
     * 請求明細書出力ファイル名を設定する
     * @param val String 請求明細書出力ファイル名
     */
    public void setBILLDTLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLDTLOUTPUTFILENM, val);
    }

    /**
     * 請求書最終出力日時を取得する
     * @return String 請求書最終出力日時
     */
    public String getBILLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLLASTOUTPUTDATE);
    }

    /**
     * 請求書最終出力日時を設定する
     * @param val String 請求書最終出力日時
     */
    public void setBILLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLLASTOUTPUTDATE, val);
    }

    /**
     * 請求書最終出力担当者を取得する
     * @return String 請求書最終出力担当者
     */
    public String getBILLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLLASTOUTPUTNM);
    }

    /**
     * 請求書最終出力担当者を設定する
     * @param val String 請求書最終出力担当者
     */
    public void setBILLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLLASTOUTPUTNM, val);
    }

    /**
     * 請求書出力ファイル名を取得する
     * @return String 請求書出力ファイル名
     */
    public String getBILLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLOUTPUTFILENM);
    }

    /**
     * 請求書出力ファイル名を設定する
     * @param val String 請求書出力ファイル名
     */
    public void setBILLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLOUTPUTFILENM, val);
    }

    /**
     * 請求データExcelファイル最終出力日時を取得する
     * @return String 請求データExcelファイル最終出力日時
     */
    public String getBILLEXLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE);
    }

    /**
     * 請求データExcelファイル最終出力日時を設定する
     * @param val String 請求データExcelファイル最終出力日時
     */
    public void setBILLEXLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE, val);
    }

    /**
     * 請求データExcelファイル最終出力担当者を取得する
     * @return String 請求データExcelファイル最終出力担当者
     */
    public String getBILLEXLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLEXLLASTOUTPUTNM);
    }

    /**
     * 請求データExcelファイル最終出力担当者を設定する
     * @param val String 請求データExcelファイル最終出力担当者
     */
    public void setBILLEXLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLEXLLASTOUTPUTNM, val);
    }

    /**
     * 請求データ出力Excelファイル名を取得する
     * @return String 請求データ出力Excelファイル名
     */
    public String getBILLEXLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLEXLOUTPUTFILENM);
    }

    /**
     * 請求データ出力Excelファイル名を設定する
     * @param val String 請求データ出力Excelファイル名
     */
    public void setBILLEXLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLEXLOUTPUTFILENM, val);
    }

    /**
     * 区分コードを取得する
     * @return String 区分コード
     */
    public String getDIVCD() {
        return (String) get(Tbj05EstimateItem.DIVCD);
    }

    /**
     * 区分コードを設定する
     * @param val String 区分コード
     */
    public void setDIVCD(String val) {
        set(Tbj05EstimateItem.DIVCD, val);
    }

    /**
     * グループコードを取得する
     * @return BigDecimal グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj05EstimateItem.GROUPCD);
    }

    /**
     * グループコードを設定する
     * @param val BigDecimal グループコード
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj05EstimateItem.GROUPCD, val);
    }

    /**
     * データ作成日時を取得する
     * @return Date データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj05EstimateItem.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     * @param val Date データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj05EstimateItem.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     * @return String データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj05EstimateItem.CRTNM);
    }

    /**
     * データ作成者を設定する
     * @param val String データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj05EstimateItem.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     * @return String 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj05EstimateItem.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     * @param val String 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj05EstimateItem.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     * @return String 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj05EstimateItem.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     * @param val String 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj05EstimateItem.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     * @return Date データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj05EstimateItem.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     * @param val Date データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj05EstimateItem.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj05EstimateItem.UPDNM);
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj05EstimateItem.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj05EstimateItem.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj05EstimateItem.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj05EstimateItem.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj05EstimateItem.UPDID, val);
    }

    /**
     * 区分名を取得する
     * @return String 区分名
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分名を設定する
     * @param val String 区分名
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * グループ名を取得する
     * @return String グループ名
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * グループ名を設定する
     * @param val String グループ名
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * コープ区分名を取得する
     * @return String コープ区分名
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }

    /**
     * コープ区分名を設定する
     * @param val String コープ区分名
     */
    public void setCODENAME(String val) {
        set(Mbj12Code.CODENAME, val);
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
    public BigDecimal getDtlPHASE() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setDtlPHASE(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getDtlCRDATE() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val Date 年月
     */
    public void setDtlCRDATE(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     * @return BigDecimal 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDtlESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     * @param val BigDecimal 見積案件管理NO
     */
    public void setDtlESTSEQNO(BigDecimal val) {
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
     * 商品名(サブ）を取得する
     * @return String 商品名(サブ）
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * 商品名(サブ）を設定する
     * @param val String 商品名(サブ）
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
     * 商品媒体コードを取得する
     * @return String 媒体コード
     */
    public String getDtlMEDIACD() {
        return (String) get(Tbj06EstimateDetail.MEDIACD);
    }

    /**
     * 商品媒体コードを設定する
     * @param val String 媒体コード
     */
    public void setDtlMEDIACD(String val) {
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
     * 商品媒体名を取得する
     * @return String 商品媒体名
     */
    public String getDtlMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * 商品媒体名を設定する
     * @param val String 商品媒体名
     */
    public void setDtlMEDIANM(String val) {
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
     * 案件媒体コードを取得する
     * @return String 見積媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * 案件媒体コードを設定する
     * @param val String 案件媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

    /**
     * 案件媒体名を取得する
     * @return String 案件媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 案件媒体名を設定する
     * @param val String 案件媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 電通車種コードを取得する
     * @return String 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj03MediaMng.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     * @param val String 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj03MediaMng.DCARCD, val);
    }

    /**
     * 車種名を取得する
     * @return String 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     * @param val String 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 費用計画Noを取得する
     * @return String 費用計画No
     */
    public String getHIYOUNO() {
        return (String) get(Mbj09Hiyou.HIYOUNO);
    }

    /**
     * 費用計画Noを設定する
     * @param val String 費用計画No
     */
    public void setHIYOUNO(String val) {
        set(Mbj09Hiyou.HIYOUNO, val);
    }

    /* 2016/01/21 請求業務変更対応 HLC K.Soga ADD Start */
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
    /* 2016/01/21 請求業務変更対応 HLC K.Soga ADD End */
}