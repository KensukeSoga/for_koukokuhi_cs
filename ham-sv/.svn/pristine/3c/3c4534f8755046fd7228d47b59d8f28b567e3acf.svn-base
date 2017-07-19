package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ番組登録画面素材情報検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 本素材・仮素材区分 */
    public static final String MATERIALKBN = "MATERIALKBN";

    /**
     * デフォルトコンストラクタ
     */
    public FindRdProgramMaterialVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindRdProgramMaterialVO();
    }

    /**
     * 車種コードを取得する
     * @return String 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * 車種コードを設定する
     * @param val String 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
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
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSozaiYm() {
        return (Date) get(Tbj20SozaiKanriList.SOZAIYM);
    }

    /**
     * 年月を設定する
     * @param val Date 年月
     */
    public void setSOZAIYM(Date val) {
        set(Tbj20SozaiKanriList.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     * @return String 作成区分
     */
    public String getRECKBN() {
        return (String) get(Tbj20SozaiKanriList.RECKBN);
    }

    /**
     * 作成区分を設定する
     * @param val String 作成区分
     */
    public void setRECKBN(String val) {
        set(Tbj20SozaiKanriList.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     * @return String 作成番号
     */
    public String getRECNO() {
        return (String) get(Tbj20SozaiKanriList.RECNO);
    }

    /**
     * 作成番号を設定する
     * @param val String 作成番号
     */
    public void setRECNO(String val) {
        set(Tbj20SozaiKanriList.RECNO, val);
    }

    /**
     * 削除フラグを取得する
     * @return String 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj20SozaiKanriList.DELFLG);
    }

    /**
     * 削除フラグを設定する
     * @param val String 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj20SozaiKanriList.DELFLG, val);
    }

    /**
     * 共通コードを取得する
     * @return String 共通コード
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * 共通コードを設定する
     * @param val String 共通コード
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * 本素材・仮素材区分を取得する
     * @return String 本素材・仮素材区分
     */
    public String getMATERIALKBN() {
        return (String) get(MATERIALKBN);
    }

    /**
     * 本素材・仮素材区分を設定する
     * @param val String 本素材・仮素材区分
     */
    public void setMATERIALKBN(String val) {
        set(MATERIALKBN, val);
    }

    /**
     * タイトルを取得する
     * @return String タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * タイトルを設定する
     * @param val String タイトル
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * 秒数を取得する
     * @return String 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     * @param val String 秒数
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * 略コードを取得する
     * @return String 略コード
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * 略コードを設定する
     * @param val String 略コード
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * 予算を取得する
     * @return BigDecimal 予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTIMATE() {
        return (BigDecimal) get(Tbj20SozaiKanriList.ESTIMATE);
    }

    /**
     * 予算を設定する
     * @param val BigDecimal 予算
     */
    public void setESTIMATE(BigDecimal val) {
        set(Tbj20SozaiKanriList.ESTIMATE, val);
    }

    /**
     * 放送開始日を取得する
     * @return Date 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj20SozaiKanriList.DATEFROM);
    }

    /**
     * 放送開始日を設定する
     * @param val Date 放送開始日
     */
    public void setDATEFROM(Date val) {
        set(Tbj20SozaiKanriList.DATEFROM, val);
    }

    /**
     * 放送終了日を取得する
     * @return Date 放送終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj20SozaiKanriList.DATETO);
    }

    /**
     * 放送終了日を設定する
     * @param val Date 放送終了日
     */
    public void setDATETO(Date val) {
        set(Tbj20SozaiKanriList.DATETO, val);
    }

    /**
     * 新素材フラグを取得する
     * @return String 新素材フラグ
     */
    public String getNEWFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWFLG);
    }

    /**
     * 新素材フラグを設定する
     * @param val String 新素材フラグ
     */
    public void setNEWFLG(String val) {
        set(Tbj20SozaiKanriList.NEWFLG, val);
    }

    /**
     * タイム使用フラグを取得する
     * @return String タイム使用フラグ
     */
    public String getTIMEUSE() {
        return (String) get(Tbj20SozaiKanriList.TIMEUSE);
    }

    /**
     * タイム使用フラグを設定する
     * @param val String タイム使用フラグ
     */
    public void setTIMEUSE(String val) {
        set(Tbj20SozaiKanriList.TIMEUSE, val);
    }

    /**
     * スポット使用フラグを取得する
     * @return String スポット使用フラグ
     */
    public String getSPOTUSE() {
        return (String) get(Tbj20SozaiKanriList.SPOTUSE);
    }

    /**
     * スポット使用フラグを設定する
     * @param val String スポット使用フラグ
     */
    public void setSPOTUSE(String val) {
        set(Tbj20SozaiKanriList.SPOTUSE, val);
    }

    /**
     * スポット契約名を取得する
     * @return String スポット契約名
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj20SozaiKanriList.SPOTCTRT);
    }

    /**
     * スポット契約名を設定する
     * @param val String スポット契約名
     */
    public void setSPOTCTRT(String val) {
        set(Tbj20SozaiKanriList.SPOTCTRT, val);
    }

    /**
     * スポット期間を取得する
     * @return String スポット期間
     */
    public String getSPOTSPAN() {
        return (String) get(Tbj20SozaiKanriList.SPOTSPAN);
    }

    /**
     * スポット期間を設定する
     * @param val String スポット期間
     */
    public void setSPOTSPAN(String val) {
        set(Tbj20SozaiKanriList.SPOTSPAN, val);
    }

    /**
     * スポット予算を取得する
     * @return BigDecimal スポット予算
     */
    public BigDecimal getSPOTESTM() {
        return (BigDecimal) get(Tbj20SozaiKanriList.SPOTESTM);
    }

    /**
     * スポット予算を設定する
     * @param val BigDecimal スポット予算
     */
    public void setSPOTESTM(BigDecimal val) {
        set(Tbj20SozaiKanriList.SPOTESTM, val);
    }

    /**
     * 使用可能期間を取得する
     * @return Date 使用可能期間
     */
    @XmlElement(required = true, nillable = true)
    public Date getLIMIT() {
        return (Date) get(Tbj20SozaiKanriList.LIMIT);
    }

    /**
     * 使用可能期間を設定する
     * @param val Date 使用可能期間
     */
    public void setLIMIT(Date val) {
        set(Tbj20SozaiKanriList.LIMIT, val);
    }

    /**
     * 車種担当を取得する
     * @return String 車種担当
     */
    public String getSYATAN() {
        return (String) get(Tbj20SozaiKanriList.SYATAN);
    }

    /**
     * 車種担当を設定する
     * @param val String 車種担当
     */
    public void setSYATAN(String val) {
        set(Tbj20SozaiKanriList.SYATAN, val);
    }

    /**
     * 備考を取得する
     * @return String 備考
     */
    public String getBIKO() {
        return (String) get(Tbj20SozaiKanriList.BIKO);
    }

    /**
     * 備考を設定する
     * @param val String 備考
     */
    public void setBIKO(String val) {
        set(Tbj20SozaiKanriList.BIKO, val);
    }

    /**
     * 文字色を取得する
     * @return String 文字色
     */
    public String getFORECOLOR() {
        return (String) get(Tbj20SozaiKanriList.FORECOLOR);
    }

    /**
     * 文字色を設定する
     * @param val String 文字色
     */
    public void setFORECOLOR(String val) {
        set(Tbj20SozaiKanriList.FORECOLOR, val);
    }

    /**
     * 背景色を取得する
     * @return String 背景色
     */
    public String getBACKCOLOR() {
        return (String) get(Tbj20SozaiKanriList.BACKCOLOR);
    }

    /**
     * 背景色を設定する
     * @param val String 背景色
     */
    public void setBACKCOLOR(String val) {
        set(Tbj20SozaiKanriList.BACKCOLOR, val);
    }

    /**
     * データ作成日時を取得する
     * @return Date データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj20SozaiKanriList.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     * @param val String データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj20SozaiKanriList.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     * @return String データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj20SozaiKanriList.CRTNM);
    }

    /**
     * データ作成者を設定する
     * @param val String データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj20SozaiKanriList.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     * @return String 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj20SozaiKanriList.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     * @param val String 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj20SozaiKanriList.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     * @return String 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj20SozaiKanriList.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     * @param val String 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj20SozaiKanriList.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     * @return Date データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj20SozaiKanriList.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     * @param val Date データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj20SozaiKanriList.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj20SozaiKanriList.UPDNM);
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj20SozaiKanriList.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj20SozaiKanriList.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj20SozaiKanriList.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj20SozaiKanriList.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj20SozaiKanriList.UPDID, val);
    }

}
