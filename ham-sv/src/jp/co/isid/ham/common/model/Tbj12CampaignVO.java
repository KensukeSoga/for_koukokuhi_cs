package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * キャンペーン一覧VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj12CampaignVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj12CampaignVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj12CampaignVO();
    }

    /**
     * キャンペーンコードを取得する
     *
     * @return キャンペーンコード
     */
    public String getCAMPCD() {
        return (String) get(Tbj12Campaign.CAMPCD);
    }

    /**
     * キャンペーンコードを設定する
     *
     * @param val キャンペーンコード
     */
    public void setCAMPCD(String val) {
        set(Tbj12Campaign.CAMPCD, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj12Campaign.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj12Campaign.DCARCD, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj12Campaign.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj12Campaign.PHASE, val);
    }

    /**
     * 予定期間開始を取得する
     *
     * @return 予定期間開始
     */
   @XmlElement(required = true, nillable = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj12Campaign.KIKANFROM);
    }

    /**
     * 予定期間開始を設定する
     *
     * @param val 予定期間開始
     */
    public void setKIKANFROM(Date val) {
        set(Tbj12Campaign.KIKANFROM, val);
    }

    /**
     * 予定期間終了を取得する
     *
     * @return 予定期間終了
     */
   @XmlElement(required = true, nillable = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj12Campaign.KIKANTO);
    }

    /**
     * 予定期間終了を設定する
     *
     * @param val 予定期間終了
     */
    public void setKIKANTO(Date val) {
        set(Tbj12Campaign.KIKANTO, val);
    }

    /**
     * キャンペーン名を取得する
     *
     * @return キャンペーン名
     */
    public String getCAMPNM() {
        return (String) get(Tbj12Campaign.CAMPNM);
    }

    /**
     * キャンペーン名を設定する
     *
     * @param val キャンペーン名
     */
    public void setCAMPNM(String val) {
        set(Tbj12Campaign.CAMPNM, val);
    }

    /**
     * 期初予算金額を取得する
     *
     * @return 期初予算金額
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getFSTBUDGET() {
        return (BigDecimal) get(Tbj12Campaign.FSTBUDGET);
    }

    /**
     * 期初予算金額を設定する
     *
     * @param val 期初予算金額
     */
    public void setFSTBUDGET(BigDecimal val) {
        set(Tbj12Campaign.FSTBUDGET, val);
    }

    /**
     * 予算金額を取得する
     *
     * @return 予算金額
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getBUDGET() {
        return (BigDecimal) get(Tbj12Campaign.BUDGET);
    }

    /**
     * 予算金額を設定する
     *
     * @param val 予算金額
     */
    public void setBUDGET(BigDecimal val) {
        set(Tbj12Campaign.BUDGET, val);
    }

    /**
     * 予算金額(新)を取得する
     *
     * @return 予算金額(新)
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getBUDGETHM() {
        return (BigDecimal) get(Tbj12Campaign.BUDGETHM);
    }

    /**
     * 予算金額(新)を設定する
     *
     * @param val 予算金額(新)
     */
    public void setBUDGETHM(BigDecimal val) {
        set(Tbj12Campaign.BUDGETHM, val);
    }

    /**
     * 実施金額を取得する
     *
     * @return 実施金額
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getACTUAL() {
        return (BigDecimal) get(Tbj12Campaign.ACTUAL);
    }

    /**
     * 実施金額を設定する
     *
     * @param val 実施金額
     */
    public void setACTUAL(BigDecimal val) {
        set(Tbj12Campaign.ACTUAL, val);
    }

    /**
     * 実施金額(新)を取得する
     *
     * @return 実施金額(新)
     */
   @XmlElement(required = true, nillable = true)
    public BigDecimal getACTUALHM() {
        return (BigDecimal) get(Tbj12Campaign.ACTUALHM);
    }

    /**
     * 実施金額(新)を設定する
     *
     * @param val 実施金額(新)
     */
    public void setACTUALHM(BigDecimal val) {
        set(Tbj12Campaign.ACTUALHM, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getMEMO() {
        return (String) get(Tbj12Campaign.MEMO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setMEMO(String val) {
        set(Tbj12Campaign.MEMO, val);
    }

    /**
     * 媒体作成済フラグを取得する
     *
     * @return 媒体作成済フラグ
     */
    public String getBAITAIFLG() {
        return (String) get(Tbj12Campaign.BAITAIFLG);
    }

    /**
     * 媒体作成済フラグを設定する
     *
     * @param val 媒体作成済フラグ
     */
    public void setBAITAIFLG(String val) {
        set(Tbj12Campaign.BAITAIFLG, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
   @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj12Campaign.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj12Campaign.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj12Campaign.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj12Campaign.CRTNM, val);
    }

    /**
     * データ作成アプリを取得する
     *
     * @return データ作成アプリ
     */
    public String getCRTAPL() {
        return (String) get(Tbj12Campaign.CRTAPL);
    }

    /**
     * データ作成アプリを設定する
     *
     * @param val データ作成アプリ
     */
    public void setCRTAPL(String val) {
        set(Tbj12Campaign.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj12Campaign.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj12Campaign.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
   @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj12Campaign.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj12Campaign.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj12Campaign.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj12Campaign.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj12Campaign.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj12Campaign.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj12Campaign.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj12Campaign.UPDID, val);
    }

}
