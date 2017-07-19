package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 取得したデータを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/15 新HAMチーム)<BR>
 * ・HDX対応(2016/02/24 HLC K.Oki)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogContractInfoVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindLogContractInfoVO() {
    }

    /**
     * 作業区分を取得する
     *
     * @return 作業区分
     */
    public String getHISTORYNM() {
        return (String) get("HISTORYNM");
    }

    /**
     * 作業区分を設定する
     *
     * @param val 作業区分
     */
    public void setHISTORYNM(String val) {
        set("HISTORYNM", val);
    }

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBNNAM() {
        return (String) get("CTRTKBNNAM");
    }

    /**
     * 契約種類を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBNNAM(String val) {
        set("CTRTKBNNAM", val);
    }

    /**
     * 行ステータスを取得する
     *
     * @return 行ステータス
     */
    public String getROWST() {
        return (String) get("ROWST");
    }

    /**
     * 行ステータスを設定する
     *
     * @param val 行ステータス
     */
    public void setROWST(String val) {
        set("ROWST", val);
    }

    /**
     * 列ステータスを取得する
     *
     * @return 列ステータス
     */
    public String getCOLST() {
        return (String) get("COLST");
    }

    /**
     * 列ステータスを設定する
     *
     * @param val 列ステータス
     */
    public void setCOLST(String val) {
        set("COLST", val);
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj24LogContractInfo.CTRTNO);
    }

    /**
     * 契約コードを設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj24LogContractInfo.CTRTNO, val);
    }

    /**
     * 旧契約種類を取得する
     *
     * @return 旧契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj24LogContractInfo.CTRTKBN);
    }

    /**
     * 旧契約種類を設定する
     *
     * @param val 旧契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj24LogContractInfo.CTRTKBN, val);
    }

    /**
     * 車種を取得する
     *
     * @return 車種
     */
    public String getSHASHU() {
        return (String) get("SHASHU");
    }

    /**
     * 車種を設定する
     *
     * @param val 車種
     */
    public void setSHASHU(String val) {
        set("SHASHU", val);
    }

    /**
     * カテゴリを取得する
     *
     * @return カテゴリ
     */
    public String getCATEGORY() {
        return (String) get(Tbj24LogContractInfo.CATEGORY);
    }

    /**
     * カテゴリを設定する
     *
     * @param val カテゴリ
     */
    public void setCATEGORY(String val) {
        set(Tbj24LogContractInfo.CATEGORY, val);
    }

    /**
     * 曲名を取得する
     *
     * @return カテゴリ
     */
    public String getMUSIC() {
        return (String) get(Tbj24LogContractInfo.MUSIC);
    }

    /**
     * 曲名を設定する
     *
     * @param val カテゴリ
     */
    public void setMUSIC(String val) {
        set(Tbj24LogContractInfo.MUSIC, val);
    }

    /**
     * 人名、アーティストを取得する
     *
     * @return 人名、アーティスト
     */
    public String getNAMES() {
        return (String) get(Tbj24LogContractInfo.NAMES);
    }

    /**
     * 人名、アーティストを設定する
     *
     * @param val 人名、アーティスト
     */
    public void setNAMES(String val) {
        set(Tbj24LogContractInfo.NAMES, val);
    }

    /**
     * 契約期間(From)を取得する
     *
     * @return 契約期間(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj24LogContractInfo.DATEFROM);
    }

    /**
     * 契約期間(From)を設定する
     *
     * @param val 契約期間(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj24LogContractInfo.DATEFROM, val);
    }

    /**
     * 契約期間(To)を取得する
     *
     * @return 契約期間(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj24LogContractInfo.DATETO);
    }

    /**
     * 契約期間(To)を設定する
     *
     * @param val 契約期間(To)
     */
    public void setDATETO(Date val) {
        set(Tbj24LogContractInfo.DATETO, val);
    }

    /**
     * JASRAC登録を取得する
     *
     * @return JASRAC登録
     */
    public String getJASRACFLG() {
        return (String) get(Tbj24LogContractInfo.JASRACFLG);
    }

    /**
     * JASRAC登録を設定する
     *
     * @param val JASRAC登録
     */
    public void setJASRACFLG(String val) {
        set(Tbj24LogContractInfo.JASRACFLG, val);
    }

    /**
     * CD発売を取得する
     *
     * @return CD発売
     */
    public String getSALEFLG() {
        return (String) get(Tbj24LogContractInfo.SALEFLG);
    }

    /**
     * CD発売を設定する
     *
     * @param val CD発売
     */
    public void setSALEFLG(String val) {
        set(Tbj24LogContractInfo.SALEFLG, val);
    }

    /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
    /**
     * ぶら下がりを取得する
     *
     * @return ぶら下がり
     */
    public String getENDTITLEFLG() {
        return (String) get(Tbj24LogContractInfo.ENDTITLEFLG);
    }

    /**
     * ぶら下がりを設定する
     *
     * @param val ぶら下がり
     */
    public void setENDTITLEFLG(String val) {
        set(Tbj24LogContractInfo.ENDTITLEFLG, val);
    }

    /**
     * アレンジ・オリジナルを取得する
     *
     * @return アレンジ・オリジナル
     */
    public String getARRGORGFLG() {
        return (String) get(Tbj24LogContractInfo.ARRGORGFLG);
    }

    /**
     * アレンジ・オリジナルを設定する
     *
     * @param val アレンジ・オリジナル
     */
    public void setARRGORGFLG(String val) {
        set(Tbj24LogContractInfo.ARRGORGFLG, val);
    }
    /* 2016/02/24 HDX対応 HLC K.Oki ADD End */

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj24LogContractInfo.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj24LogContractInfo.BIKO, val);
    }

    /**
     * 登録者を取得する
     *
     * @return 登録者
     */
    public String getCRTNM() {
        return (String) get(Tbj24LogContractInfo.CRTNM);
    }

    /**
     * 登録者を設定する
     *
     * @param val 登録者
     */
    public void setCRTNM(String val) {
        set(Tbj24LogContractInfo.CRTNM, val);
    }

    /**
     * 登録者を取得する
     *
     * @return 登録者
     */
    public String getCRTAPL() {
        return (String) get(Tbj24LogContractInfo.CRTAPL);
    }

    /**
     * 登録者を設定する
     *
     * @param val 登録者
     */
    public void setCRTAPL(String val) {
        set(Tbj24LogContractInfo.CRTAPL, val);
    }

    /**
     * 登録者IDを取得する
     *
     * @return 登録者ID
     */
    public String getCRTID() {
        return (String) get(Tbj24LogContractInfo.CRTID);
    }

    /**
     * 登録者IDを設定する
     *
     * @param val 登録者ID
     */
    public void setCRTID(String val) {
        set(Tbj24LogContractInfo.CRTID, val);
    }

    /**
     * 登録日時を取得する
     *
     * @return 登録日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj24LogContractInfo.CRTDATE);
    }

    /**
     * 登録日時を設定する
     *
     * @param val 登録日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj24LogContractInfo.CRTDATE, val);
    }

    /**
     * 更新者を取得する
     *
     * @return 更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj24LogContractInfo.UPDNM);
    }

    /**
     * 更新者を設定する
     *
     * @param val 更新者
     */
    public void setUPDNM(String val) {
        set(Tbj24LogContractInfo.UPDNM, val);
    }

    /**
     * 更新日時を取得する
     *
     * @return 更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj24LogContractInfo.UPDDATE);
    }

    /**
     * 更新日時を設定する
     *
     * @param val 更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj24LogContractInfo.UPDDATE, val);
    }

}
