package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 担当者マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCampaignDetailstVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCampaignDetailstVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindCampaignDetailstVO();
    }

    /**
     * キャンペーンコードを取得する
     *
     * @return キャンペーンコード
     */
    public String getCAMPCD() {
        return (String) get(Tbj13CampDetail.CAMPCD);
    }

    /**
     * キャンペーンコードを設定する
     *
     * @param val キャンペーンコード
     */
    public void setCAMPCD(String val) {
        set(Tbj13CampDetail.CAMPCD, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj13CampDetail.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj13CampDetail.DCARCD, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj13CampDetail.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj13CampDetail.MEDIACD, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj13CampDetail.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj13CampDetail.PHASE, val);
    }

    /**
     * 出稿予定年月を取得する
     *
     * @return 出稿予定年月
     */
    @XmlElement(required = true)
    public Date getYOTEIYM() {
        return (Date) get(Tbj13CampDetail.YOTEIYM);
    }

    /**
     * 出稿予定年月を設定する
     *
     * @param val 出稿予定年月
     */
    public void setYOTEIYM(Date val) {
        set(Tbj13CampDetail.YOTEIYM, val);
    }

    /**
     * 予定期間開始を取得する
     *
     * @return 予定期間開始
     */
    @XmlElement(required = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj13CampDetail.KIKANFROM);
    }

    /**
     * 予定期間開始を設定する
     *
     * @param val 予定期間開始
     */
    public void setKIKANFROM(Date val) {
        set(Tbj13CampDetail.KIKANFROM, val);
    }

    /**
     * 予定期間終了を取得する
     *
     * @return 予定期間終了
     */
    @XmlElement(required = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj13CampDetail.KIKANTO);
    }

    /**
     * 予定期間終了を設定する
     *
     * @param val 予定期間終了
     */
    public void setKIKANTO(Date val) {
        set(Tbj13CampDetail.KIKANTO, val);
    }

    /**
     * 予算金額を取得する
     *
     * @return 予算金額
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGET() {
        return (BigDecimal) get(Tbj13CampDetail.BUDGET);
    }

    /**
     * 予算金額を設定する
     *
     * @param val 予算金額
     */
    public void setBUDGET(BigDecimal val) {
        set(Tbj13CampDetail.BUDGET, val);
    }

    /**
     * 予算金額(新)を取得する
     *
     * @return 予算金額(新)
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGETHM() {
        return (BigDecimal) get(Tbj13CampDetail.BUDGETHM);
    }

    /**
     * 予算金額(新)を設定する
     *
     * @param val 予算金額(新)
     */
    public void setBUDGETHM(BigDecimal val) {
        set(Tbj13CampDetail.BUDGETHM, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj13CampDetail.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj13CampDetail.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj13CampDetail.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj13CampDetail.CRTNM, val);
    }

    /**
     * データ作成アプリを取得する
     *
     * @return データ作成アプリ
     */
    public String getCRTAPL() {
        return (String) get(Tbj13CampDetail.CRTAPL);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTAPL(String val) {
        set(Tbj13CampDetail.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj13CampDetail.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj13CampDetail.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj13CampDetail.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj13CampDetail.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj13CampDetail.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj13CampDetail.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj13CampDetail.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj13CampDetail.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj13CampDetail.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj13CampDetail.UPDID, val);
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体名を設定する
     *
     * @param val 媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 媒体名（媒体費作成用）を取得する
     *
     * @return 媒体名（媒体費作成用）
     */
    public String getHCMEDIANM() {
        return (String) get(Mbj03Media.HCMEDIANM);
    }

    /**
     * 媒体名（媒体費作成用）を設定する
     *
     * @param val 媒体名（媒体費作成用）
     */
    public void setHCMEDIANM(String val) {
        set(Mbj03Media.HCMEDIANM, val);
    }

    /**
     * 電通値引率を取得する
     *
     * @return 電通値引率
     */
    @XmlElement(required = true)
    public BigDecimal getDNEBIKI() {
        return (BigDecimal) get(Mbj03Media.DNEBIKI);
    }

    /**
     * 電通値引率を設定する
     *
     * @param val 電通値引率
     */
    public void setDNEBIKI(BigDecimal val) {
        set(Mbj03Media.DNEBIKI, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj03Media.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj03Media.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true)
    public Date getMEDIAUPDDATE() {
        return (Date) get(Mbj03Media.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setMEDIAUPDDATE(Date val) {
        set(Mbj03Media.UPDDATE, val);
    }

}
