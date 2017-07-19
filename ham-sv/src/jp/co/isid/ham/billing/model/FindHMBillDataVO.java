package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM請求データ作成検索取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillDataVO();
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
