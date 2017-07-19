package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
//import jp.co.isid.ham.integ.tbl.Mfk02Jun;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体状況管理VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/17 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindMediaPlanVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * ステータス
     */
    private BigDecimal _STATUS = null;

    /**
     * キャンペーンNo＋キャンペーン名
     */
    private String _CODENAME = null;


    /**
     * デフォルトコンストラクタ
     */
    public FindMediaPlanVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMediaPlanVO();
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj01MediaPlan.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj01MediaPlan.DCARCD, val);
    }

    /**
     * キャンペーンコードを取得する
     *
     * @return キャンペーンコード
     */
    public String getCAMPCD() {
        return (String) get(Tbj01MediaPlan.CAMPCD);
    }

    /**
     * キャンペーンコードを設定する
     *
     * @param val キャンペーンコード
     */
    public void setCAMPCD(String val) {
        set(Tbj01MediaPlan.CAMPCD, val);
    }

    /**
     * 媒体管理Noを取得する
     *
     * @return 媒体管理No
     */
    @XmlElement(required = true)
    public BigDecimal getMEDIAPLANNO() {
        return (BigDecimal) get(Tbj01MediaPlan.MEDIAPLANNO);
    }

    /**
     * 媒体管理Noを設定する
     *
     * @param val 媒体管理No
     */
    public void setMEDIAPLANNO(BigDecimal val) {
        set(Tbj01MediaPlan.MEDIAPLANNO, val);
    }

    /**
     * 媒体ソート順を取得する
     *
     * @return 媒体ソート順
     */
    @XmlElement(required = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj03Media.SORTNO);
    }

    /**
     * 媒体ソート順を設定する
     *
     * @param val 媒体ソート順
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj03Media.SORTNO, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj01MediaPlan.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj01MediaPlan.MEDIACD, val);
    }

    /**
     * 媒体を取得する
     *
     * @return 媒体
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体を設定する
     *
     * @param val 媒体
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 費用計画Noを取得する
     *
     * @return 費用計画No
     */
    public String getHIYOUNO() {
        return (String) get(Tbj01MediaPlan.HIYOUNO);
    }

    /**
     * 費用計画Noを設定する
     *
     * @param val 費用計画No
     */
    public void setHIYOUNO(String val) {
        set(Tbj01MediaPlan.HIYOUNO, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj01MediaPlan.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj01MediaPlan.PHASE, val);
    }

    /**
     * 期を取得する
     *
     * @return 期
     */
    public String getTERM() {
        return (String) get(Tbj01MediaPlan.TERM);
    }

    /**
     * 期を設定する
     *
     * @param val 期
     */
    public void setTERM(String val) {
        set(Tbj01MediaPlan.TERM, val);
    }

    /**
     * 月を取得する
     *
     * @return 月
     */
    @XmlElement(required = true)
    public Date getYOTEIYM() {
        return (Date) get(Tbj01MediaPlan.YOTEIYM);
    }

    /**
     * 月を設定する
     *
     * @param val 月
     */
    public void setYOTEIYM(Date val) {
        set(Tbj01MediaPlan.YOTEIYM, val);
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj01MediaPlan.KIKANFROM);
    }

    /**
     * 期間開始を設定する
     *
     * @param val 期間開始
     */
    public void setKIKANFROM(Date val) {
        set(Tbj01MediaPlan.KIKANFROM, val);
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj01MediaPlan.KIKANTO);
    }

    /**
     * 期間終了を設定する
     *
     * @param val 期間終了
     */
    public void setKIKANTO(Date val) {
        set(Tbj01MediaPlan.KIKANTO, val);
    }

    /**
     * 予算金額を取得する
     *
     * @return 予算金額
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGET() {
        return (BigDecimal) get(Tbj01MediaPlan.BUDGET);
    }

    /**
     * 予算金額を設定する
     *
     * @param val 予算金額
     */
    public void setBUDGET(BigDecimal val) {
        set(Tbj01MediaPlan.BUDGET, val);
    }

    /**
     * 予算金額(新)を取得する
     *
     * @return 予算金額(新)
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGETHM() {
        return (BigDecimal) get(Tbj01MediaPlan.BUDGETHM);
    }

    /**
     * 予算金額(新)を設定する
     *
     * @param val 予算金額(新)
     */
    public void setBUDGETHM(BigDecimal val) {
        set(Tbj01MediaPlan.BUDGETHM, val);
    }

    /**
     * 調整金額を取得する
     *
     * @return 調整金額
     */
    @XmlElement(required = true)
    public BigDecimal getADJUSTMENT() {
        return (BigDecimal) get(Tbj01MediaPlan.ADJUSTMENT);
    }

    /**
     * 調整金額を設定する
     *
     * @param val 調整金額
     */
    public void setADJUSTMENT(BigDecimal val) {
        set(Tbj01MediaPlan.ADJUSTMENT, val);
    }

    /**
     * 実施金額を取得する
     *
     * @return 実施金額
     */
    @XmlElement(required = true)
    public BigDecimal getACTUAL() {
        return (BigDecimal) get(Tbj01MediaPlan.ACTUAL);
    }

    /**
     * 実施金額を設定する
     *
     * @param val 実施金額
     */
    public void setACTUAL(BigDecimal val) {
        set(Tbj01MediaPlan.ACTUAL, val);
    }

    /**
     * 実施金額(新)を取得する
     *
     * @return 実施金額(新)
     */
    @XmlElement(required = true)
    public BigDecimal getACTUALHM() {
        return (BigDecimal) get(Tbj01MediaPlan.ACTUALHM);
    }

    /**
     * 実施金額(新)を設定する
     *
     * @param val 実施金額(新)
     */
    public void setACTUALHM(BigDecimal val) {
        set(Tbj01MediaPlan.ACTUALHM, val);
    }

    /**
     * 予実差額を取得する
     *
     * @return 予実差額
     */
    @XmlElement(required = true)
    public BigDecimal getDIFAMT() {
        return (BigDecimal) get(Tbj01MediaPlan.DIFAMT);
    }

    /**
     * 予実差額を設定する
     *
     * @param val 予実差額
     */
    public void setDIFAMT(BigDecimal val) {
        set(Tbj01MediaPlan.DIFAMT, val);
    }

    /**
     * 予実差額(新)を取得する
     *
     * @return 予実差額(新)
     */
    @XmlElement(required = true)
    public BigDecimal getDIFAMTHM() {
        return (BigDecimal) get(Tbj01MediaPlan.DIFAMTHM);
    }

    /**
     * 予実差額(新)を設定する
     *
     * @param val 予実差額(新)
     */
    public void setDIFAMTHM(BigDecimal val) {
        set(Tbj01MediaPlan.DIFAMTHM, val);
    }

    /**
     * ＨＭ承認を取得する
     *
     * @return ＨＭ承認
     */
    public String getHMOK() {
        return (String) get(Tbj01MediaPlan.HMOK);
    }

    /**
     * ＨＭ承認を設定する
     *
     * @param val ＨＭ承認
     */
    public void setHMOK(String val) {
        set(Tbj01MediaPlan.HMOK, val);
    }

    /**
     * 媒体発注を取得する
     *
     * @return 媒体発注
     */
    public String getBUYEROK() {
        return (String) get(Tbj01MediaPlan.BUYEROK);
    }

    /**
     * 媒体発注を設定する
     *
     * @param val 媒体発注
     */
    public void setBUYEROK(String val) {
        set(Tbj01MediaPlan.BUYEROK, val);
    }

    /**
     * 件名を取得する
     *
     * @return 件名
     */
    public String getKENMEI() {
        return (String) get(Tbj01MediaPlan.KENMEI);
    }

    /**
     * 件名を設定する
     *
     * @param val 件名
     */
    public void setKENMEI(String val) {
        set(Tbj01MediaPlan.KENMEI, val);
    }

    /**
     * 特記事項を取得する
     *
     * @return 特記事項
     */
    public String getMEMO() {
        return (String) get(Tbj01MediaPlan.MEMO);
    }

    /**
     * 特記事項を設定する
     *
     * @param val 特記事項
     */
    public void setMEMO(String val) {
        set(Tbj01MediaPlan.MEMO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj01MediaPlan.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj01MediaPlan.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj01MediaPlan.CRTNM);
    }

    /**
     * データ作成アプリを設定する
     *
     * @param val データ作成アプリ
     */
    public void setCRTAPL(String val) {
        set(Tbj01MediaPlan.CRTAPL, val);
    }

    /**
     * データ作成アプリを取得する
     *
     * @return データ作成アプリ
     */
    public String getCRTAPL() {
        return (String) get(Tbj01MediaPlan.CRTAPL);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj01MediaPlan.CRTNM, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj01MediaPlan.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj01MediaPlan.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj01MediaPlan.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj01MediaPlan.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj01MediaPlan.UPDNM);
    }

    /**
     * データ更新IDを設定する
     *
     * @param val データ更新ID
     */
    public void setUPDID(String val) {
        set(Tbj01MediaPlan.UPDID, val);
    }

    /**
     * データ更新IDを取得する
     *
     * @return データ更新ID
     */
    public String getUPDID() {
        return (String) get(Tbj01MediaPlan.UPDID);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj01MediaPlan.UPDNM, val);
    }

    /**
     * ステータスを取得します
     * @return
     */
    public BigDecimal getSTATUS() {
        return _STATUS;
    }

    /**
     * ステータスを設定します
     * @param val
     */
    public void setSTATUS(BigDecimal val) {
        _STATUS = val;
    }

    /**
     * 媒体権限を取得する
     *
     * @return 媒体権限
     */
    public String getAUTHORITY() {
        return (String) get(Mbj10MediaSec.AUTHORITY);
    }

    /**
     * 媒体権限を設定する
     *
     * @param val 媒体権限
     */
    public void setAUTHORITY(String val) {
        set(Mbj10MediaSec.AUTHORITY, val);
    }

    /**
     * キャンペーンNo＋キャンペーン名を取得します
     * @return
     */
    public String getCODENAME() {
        return _CODENAME;
    }

    /**
     *キャンペーンNo＋キャンペーン名を設定します
     * @param val
     */
    public void setCODENAME(String val) {
        _CODENAME = val;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj01MediaPlan.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj01MediaPlan.UPDAPL, val);
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj05Car.KEIRETSUCD);
    }

    /**
     * 系列コードを設定する
     *
     * @param val 系列コード
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj05Car.KEIRETSUCD, val);
    }

    /**
     * 予算登録フラグを取得する
     *
     * @return 予算登録フラグ
     */
    public String getBUDGETUPDFLG() {
        return (String) get(Tbj01MediaPlan.BUDGETUPDFLG);
    }

    /**
     * 予算登録フラグを設定する
     *
     * @param val 予算登録フラグ
     */
    public void setBUDGETUPDFLG(String val) {
        set(Tbj01MediaPlan.BUDGETUPDFLG, val);
    }

}
