package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj04Keiretsu;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 営業作業台帳帳票VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/25 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")

public class FindAuthorityAccountBookReportVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindAuthorityAccountBookReportVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindAuthorityAccountBookReportVO();
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
     * 媒体管理Noを取得する
     *
     * @return 媒体管理No
     */
    @XmlElement(required = true)
    public BigDecimal getMEDIAPLANNO() {
        return (BigDecimal) get(Tbj02EigyoDaicho.MEDIAPLANNO);
    }

    /**
     * 媒体管理Noを設定する
     *
     * @param val 媒体管理No
     */
    public void setMEDIAPLANNO(BigDecimal val) {
        set(Tbj02EigyoDaicho.MEDIAPLANNO, val);
    }

    /**
     * 台帳Noを取得する
     *
     * @return 台帳No
     */
    public String getDAICHONO() {
        return (String) get(Tbj02EigyoDaicho.DAICHONO);
    }

    /**
     * 台帳Noを設定する
     *
     * @param val 台帳No
     */
    public void setDAICHONO(String val) {
        set(Tbj02EigyoDaicho.DAICHONO, val);
    }


    /**
     * 請求年月を取得する
     *
     * @return 請求年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj02EigyoDaicho.SEIKYUYM);
    }

    /**
     * 請求年月を設定する
     *
     * @param val 請求年月
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj02EigyoDaicho.SEIKYUYM, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj02EigyoDaicho.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj02EigyoDaicho.MEDIACD, val);
    }

    /**
     * 媒体種別コードを取得する
     *
     * @return 媒体種別コード
     */
    public String getMEDIASCD() {
        return (String) get(Tbj02EigyoDaicho.MEDIASCD);
    }

    /**
     * 媒体種別コードを設定する
     *
     * @param val 媒体種別コード
     */
    public void setMEDIASCD(String val) {
        set(Tbj02EigyoDaicho.MEDIASCD, val);
    }

    /**
     * 媒体種別名を取得する
     *
     * @return 媒体種別名
     */
    public String getMEDIASNM() {
        return (String) get(Tbj02EigyoDaicho.MEDIASNM);
    }

    /**
     * 媒体種別名を設定する
     *
     * @param val 媒体種別名
     */
    public void setMEDIASNM(String val) {
        set(Tbj02EigyoDaicho.MEDIASNM, val);
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKEIRETSUSNM() {
        return (String) get(Mbj04Keiretsu.KEIRETSUSNM);
    }

    /**
     * 系列コードを設定する
     *
     * @param val 系列コード
     */
    public void setKEIRETSUSNM(String val) {
        set(Mbj04Keiretsu.KEIRETSUSNM, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 費用計画Noを取得する
     *
     * @return 費用計画No
     */
    public String getHIYOUNO() {
        return (String) get(Tbj02EigyoDaicho.HIYOUNO);
    }

    /**
     * 費用計画Noを設定する
     *
     * @param val 費用計画No
     */
    public void setHIYOUNO(String val) {
        set(Tbj02EigyoDaicho.HIYOUNO, val);
    }

    /**
     * キャンペーン名を取得する
     *
     * @return キャンペーン名
     */
    public String getCAMPAIGN() {
        return (String) get(Tbj02EigyoDaicho.CAMPAIGN);
    }

    /**
     * キャンペーン名を設定する
     *
     * @param val キャンペーン名
     */
    public void setCAMPAIGN(String val) {
        set(Tbj02EigyoDaicho.CAMPAIGN, val);
    }

    /**
     * 内容費目を取得する
     *
     * @return 内容費目
     */
    public String getNAIYOHIMOKU() {
        return (String) get(Tbj02EigyoDaicho.NAIYOHIMOKU);
    }

    /**
     * 内容費目を設定する
     *
     * @param val 内容費目
     */
    public void setNAIYOHIMOKU(String val) {
        set(Tbj02EigyoDaicho.NAIYOHIMOKU, val);
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj02EigyoDaicho.KIKANFROM);
    }

    /**
     * 期間開始を設定する
     *
     * @param val 期間開始
     */
    public void setKIKANFROM(Date val) {
        set(Tbj02EigyoDaicho.KIKANFROM, val);
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj02EigyoDaicho.KIKANTO);
    }

    /**
     * 期間終了を設定する
     *
     * @param val 期間終了
     */
    public void setKIKANTO(Date val) {
        set(Tbj02EigyoDaicho.KIKANTO, val);
    }

    /**
     * グロス金額を取得する
     *
     * @return グロス金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROSS() {
        return (BigDecimal) get(Tbj02EigyoDaicho.GROSS);
    }

    /**
     * グロス金額を設定する
     *
     * @param val グロス金額
     */
    public void setGROSS(BigDecimal val) {
        set(Tbj02EigyoDaicho.GROSS, val);
    }

    /**
     * 電通値引率を取得する
     *
     * @return 電通値引率
     */
    @XmlElement(required = true, nillable = true)
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
     * 電通値引額を取得する
     *
     * @return 電通値引額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDNEBIKIGAKU() {
        return (BigDecimal) get(Tbj02EigyoDaicho.DNEBIKIGAKU);
    }

    /**
     * 電通値引額を設定する
     *
     * @param val 電通値引額
     */
    public void setDNEBIKIGAKU(BigDecimal val) {
        set(Tbj02EigyoDaicho.DNEBIKIGAKU, val);
    }

    /**
     * H新モデルコストを取得する
     *
     * @return H新モデルコスト
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHMCOST() {
        return (BigDecimal) get(Tbj02EigyoDaicho.HMCOST);
    }

    /**
     * H新モデルコストを設定する
     *
     * @param val H新モデルコスト
     */
    public void setHMCOST(BigDecimal val) {
        set(Tbj02EigyoDaicho.HMCOST, val);
    }

    /**
     * 営業申込利益率を取得する
     *
     * @return 営業申込利益率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAPLRIEKIRITSU() {
        return (BigDecimal) get(Tbj02EigyoDaicho.APLRIEKIRITSU);
    }

    /**
     * 営業申込利益率を設定する
     *
     * @param val 営業申込利益率
     */
    public void setAPLRIEKIRITSU(BigDecimal val) {
        set(Tbj02EigyoDaicho.APLRIEKIRITSU, val);
    }

    /**
     * 営業申込利益額を取得する
     *
     * @return 営業申込利益額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAPLRIEKIGAKU() {
        return (BigDecimal) get(Tbj02EigyoDaicho.APLRIEKIGAKU);
    }

    /**
     * 営業申込利益額を設定する
     *
     * @param val 営業申込利益額
     */
    public void setAPLRIEKIGAKU(BigDecimal val) {
        set(Tbj02EigyoDaicho.APLRIEKIGAKU, val);
    }

    /**
     * 媒体社払金額を取得する
     *
     * @return 媒体社払金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAHARAI() {
        return (BigDecimal) get(Tbj02EigyoDaicho.MEDIAHARAI);
    }

    /**
     * 媒体社払金額を設定する
     *
     * @param val 媒体社払金額
     */
    public void setMEDIAHARAI(BigDecimal val) {
        set(Tbj02EigyoDaicho.MEDIAHARAI, val);
    }

    /**
     * 媒体マージン率を取得する
     *
     * @return 媒体マージン率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAMARGINRITSU() {
        return (BigDecimal) get(Tbj02EigyoDaicho.MEDIAMARGINRITSU);
    }

    /**
     * 媒体マージン率を設定する
     *
     * @param val 媒体マージン率
     */
    public void setMEDIAMARGINRITSU(BigDecimal val) {
        set(Tbj02EigyoDaicho.MEDIAMARGINRITSU, val);
    }

    /**
     * 媒体マージン額を取得する
     *
     * @return 媒体マージン額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAMARGINGAKU() {
        return (BigDecimal) get(Tbj02EigyoDaicho.MEDIAMARGINGAKU);
    }

    /**
     * 媒体マージン額を設定する
     *
     * @param val 媒体マージン額
     */
    public void setMEDIAMARGINGAKU(BigDecimal val) {
        set(Tbj02EigyoDaicho.MEDIAMARGINGAKU, val);
    }

    /**
     * 媒体原価を取得する
     *
     * @return 媒体原価
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAGENKA() {
        return (BigDecimal) get(Tbj02EigyoDaicho.MEDIAGENKA);
    }

    /**
     * 媒体原価を設定する
     *
     * @param val 媒体原価
     */
    public void setMEDIAGENKA(BigDecimal val) {
        set(Tbj02EigyoDaicho.MEDIAGENKA, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj02EigyoDaicho.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj02EigyoDaicho.BIKO, val);
    }

    /**
     * 請求対象フラグを取得する
     *
     * @return 請求対象フラグ
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj02EigyoDaicho.SEIKYUFLG);
    }

    /**
     * 請求対象フラグを設定する
     *
     * @param val 請求対象フラグ
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj02EigyoDaicho.SEIKYUFLG, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj02EigyoDaicho.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj02EigyoDaicho.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj02EigyoDaicho.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj02EigyoDaicho.CRTNM, val);
    }

    /**
     * データ作成アプリを取得する
     *
     * @return データ作成アプリ
     */
    public String getCRTAPL() {
        return (String) get(Tbj02EigyoDaicho.CRTAPL);
    }

    /**
     * データ作成アプリを設定する
     *
     * @param val データ作成アプリ
     */
    public void setCRTAPL(String val) {
        set(Tbj02EigyoDaicho.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj02EigyoDaicho.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj02EigyoDaicho.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj02EigyoDaicho.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj02EigyoDaicho.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj02EigyoDaicho.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj02EigyoDaicho.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj02EigyoDaicho.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj02EigyoDaicho.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj02EigyoDaicho.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj02EigyoDaicho.UPDID, val);
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
     * 取扱利益額を取得する
     *
     * @return 取扱利益額
     */
    public BigDecimal getTORIRIEKI() {
        return (BigDecimal) get(Tbj02EigyoDaicho.TORIRIEKI);
    }

    /**
     * 取扱利益額を設定する
     *
     * @param val 取扱利益額
     */
    public void setTORIRIEKI(BigDecimal val) {
        set(Tbj02EigyoDaicho.TORIRIEKI, val);
    }

    /**
     * 通常利益配分額を取得する
     *
     * @return 通常利益配分額
     */
    public BigDecimal getRIEKIHAIBUN() {
        return (BigDecimal) get(Tbj02EigyoDaicho.RIEKIHAIBUN);
    }

    /**
     * 通常利益配分額を設定する
     *
     * @param val 通常利益配分額
     */
    public void setRIEKIHAIBUN(BigDecimal val) {
        set(Tbj02EigyoDaicho.RIEKIHAIBUN, val);
    }

    /**
     * 通常内勤利益配分額を取得する
     *
     * @return 通常内勤利益配分額
     */
    public BigDecimal getNAIKINRIEKI() {
        return (BigDecimal) get(Tbj02EigyoDaicho.NAIKINRIEKI);
    }

    /**
     * 通常内勤利益配分額を設定する
     *
     * @param val 通常内勤利益配分額
     */
    public void setNAIKINRIEKI(BigDecimal val) {
        set(Tbj02EigyoDaicho.NAIKINRIEKI, val);
    }

    /**
     * 振替利益配分額を取得する
     *
     * @return 振替利益配分額
     */
    public BigDecimal getFURIKAERIEKI() {
        return (BigDecimal) get(Tbj02EigyoDaicho.FURIKAERIEKI);
    }

    /**
     * 振替利益配分額を設定する
     *
     * @param val 振替利益配分額
     */
    public void setFURIKAERIEKI(BigDecimal val) {
        set(Tbj02EigyoDaicho.FURIKAERIEKI, val);
    }

    /**
     * 営業要因額を取得する
     *
     * @return 営業要因額
     */
    public BigDecimal getEIGYOYOIN() {
        return (BigDecimal) get(Tbj02EigyoDaicho.EIGYOYOIN);
    }

    /**
     * 営業要因額を設定する
     *
     * @param val 営業要因額
     */
    public void setEIGYOYOIN(BigDecimal val) {
        set(Tbj02EigyoDaicho.EIGYOYOIN, val);
    }
}
