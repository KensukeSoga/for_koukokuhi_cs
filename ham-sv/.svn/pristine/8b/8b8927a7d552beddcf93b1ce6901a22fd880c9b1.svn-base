package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM見積一覧(見積案件)(制作)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillItemVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積番号 */
    private static final String ESTIMATENO = "ESTIMATENO";

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillItemVO() {
    }

    /**
     * 新規インスタンスを生成する
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillItemVO();
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPhase(BigDecimal val) {
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
     * @param val Date 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     * @return BigDecimal 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     * @param val BigDecimal 見積案件管理NO
     */
    public void setESTSEQNO(BigDecimal val) {
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
     * 出力ファイル名を取得する
     * @return String 出力ファイル名
     */
    public String getOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.OUTPUTFILENM);
    }

    /**
     * 出力ファイル名を設定する
     * @param val String 出力ファイル名
     */
    public void setOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.OUTPUTFILENM, val);
    }

    /**
     * 電通車種コードを取得する
     * @return String 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj05EstimateItem.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     * @param val String 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj05EstimateItem.DCARCD, val);
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
     * コード名を取得する
     * @return String コード名
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }

    /**
     * コード名を設定する
     * @param val String コード名
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
     * 見積番号を取得する
     * @return String 見積番号
     */
    public String getEstimateNo() {
        return (String) get(ESTIMATENO);
    }

    /**
     * 見積番号を設定する
     * @param val String 見積番号
     */
    public void setESTIMATENO(String val) {
        set(ESTIMATENO, val);
    }

    /**
     * 媒体コードを取得する
     * @return String 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     * @param val String 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

}
