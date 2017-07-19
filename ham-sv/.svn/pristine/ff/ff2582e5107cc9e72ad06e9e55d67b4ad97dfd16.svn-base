package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 契約情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・HDX対応(2016/02/25 HLC K.Oki)
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj16ContractInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj16ContractInfoVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj16ContractInfoVO();
    }

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj16ContractInfo.CTRTKBN);
    }

    /**
     * 契約種類を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * 契約コードを設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj16ContractInfo.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj16ContractInfo.DCARCD, val);
    }

    /**
     * カテゴリを取得する
     *
     * @return カテゴリ
     */
    public String getCATEGORY() {
        return (String) get(Tbj16ContractInfo.CATEGORY);
    }

    /**
     * カテゴリを設定する
     *
     * @param val カテゴリ
     */
    public void setCATEGORY(String val) {
        set(Tbj16ContractInfo.CATEGORY, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj16ContractInfo.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj16ContractInfo.DELFLG, val);
    }

    /**
     * 名称を取得する
     *
     * @return 名称
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * 名称を設定する
     *
     * @param val 名称
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * 契約期間(From)を取得する
     *
     * @return 契約期間(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj16ContractInfo.DATEFROM);
    }

    /**
     * 契約期間(From)を設定する
     *
     * @param val 契約期間(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * 契約期間(To)を取得する
     *
     * @return 契約期間(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj16ContractInfo.DATETO);
    }

    /**
     * 契約期間(To)を設定する
     *
     * @param val 契約期間(To)
     */
    public void setDATETO(Date val) {
        set(Tbj16ContractInfo.DATETO, val);
    }

    /**
     * 楽曲名を取得する
     *
     * @return 楽曲名
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * 楽曲名を設定する
     *
     * @param val 楽曲名
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * JASRAC登録を取得する
     *
     * @return JASRAC登録
     */
    public String getJASRACFLG() {
        return (String) get(Tbj16ContractInfo.JASRACFLG);
    }

    /**
     * JASRAC登録を設定する
     *
     * @param val JASRAC登録
     */
    public void setJASRACFLG(String val) {
        set(Tbj16ContractInfo.JASRACFLG, val);
    }

    /**
     * CD発売を取得する
     *
     * @return CD発売
     */
    public String getSALEFLG() {
        return (String) get(Tbj16ContractInfo.SALEFLG);
    }

    /**
     * CD発売を設定する
     *
     * @param val CD発売
     */
    public void setSALEFLG(String val) {
        set(Tbj16ContractInfo.SALEFLG, val);
    }

    /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
    /**
     *  ぶら下がりを取得する
     *
     * @return ぶら下がり
     */
    public String getENDTITLEFLG() {
        return (String) get(Tbj16ContractInfo.ENDTITLEFLG);
    }

    /**
     *  ぶら下がりを設定する
     *
     * @param val ぶら下がり
     */
    public void setENDTITLEFLG(String val) {
        set(Tbj16ContractInfo.ENDTITLEFLG, val);
    }

    /**
     *  アレンジ・オリジナルを取得する
     *
     * @return アレンジ・オリジナル
     */
    public String getARRGORGFLG() {
        return (String) get(Tbj16ContractInfo.ARRGORGFLG);
    }

    /**
     *  アレンジ・オリジナルを設定する
     *
     * @param val アレンジ・オリジナル
     */
    public void setARRGORGFLG(String val) {
        set(Tbj16ContractInfo.ARRGORGFLG, val);
    }
    /* 2016/02/24 HDX対応 HLC K.Oki ADD End */

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj16ContractInfo.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj16ContractInfo.BIKO, val);
    }

    /**
     * 履歴キーを取得する
     *
     * @return 履歴キー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYKEY() {
        return (BigDecimal) get(Tbj16ContractInfo.HISTORYKEY);
    }

    /**
     * 履歴キーを設定する
     *
     * @param val 履歴キー
     */
    public void setHISTORYKEY(BigDecimal val) {
        set(Tbj16ContractInfo.HISTORYKEY, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj16ContractInfo.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj16ContractInfo.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj16ContractInfo.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj16ContractInfo.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj16ContractInfo.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj16ContractInfo.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj16ContractInfo.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj16ContractInfo.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj16ContractInfo.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj16ContractInfo.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj16ContractInfo.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj16ContractInfo.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj16ContractInfo.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj16ContractInfo.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj16ContractInfo.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj16ContractInfo.UPDID, val);
    }

}
