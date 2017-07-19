package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有OA期間）ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj45LogSozaiKanriListCmnOAVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /** デフォルトコンストラクタ */
    public Tbj45LogSozaiKanriListCmnOAVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj45LogSozaiKanriListCmnOAVO();
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.DCARCD, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj45LogSozaiKanriListCmnOA.SOZAIYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSOZAIYM(Date val) {
        set(Tbj45LogSozaiKanriListCmnOA.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getRECKBN() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.RECKBN);
    }

    /**
     * 作成区分を設定する
     *
     * @param val 作成区分
     */
    public void setRECKBN(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRECNO() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.RECNO);
    }

    /**
     * 作成番号を設定する
     *
     * @param val 作成番号
     */
    public void setRECNO(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.RECNO, val);
    }

    /**
     * 履歴NOを取得する
     *
     * @return 履歴NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj45LogSozaiKanriListCmnOA.HISTORYNO);
    }

    /**
     * 履歴NOを設定する
     *
     * @param val 履歴NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj45LogSozaiKanriListCmnOA.HISTORYNO, val);
    }

    /**
     * 履歴区分を取得する
     *
     * @return 履歴区分
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.HISTORYKBN);
    }

    /**
     * 履歴区分を設定する
     *
     * @param val 履歴区分
     */
    public void setHISTORYKBN(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.HISTORYKBN, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.DELFLG, val);
    }

    /**
     * 共通コードを取得する
     *
     * @return 共通コード
     */
    public String getCMCD() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.CMCD);
    }

    /**
     * 共通コードを設定する
     *
     * @param val 共通コード
     */
    public void setCMCD(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.CMCD, val);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.TEMPCMCD);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param val 仮10桁CMｺｰﾄﾞ
     */
    public void setTEMPCMCD(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.TEMPCMCD, val);
    }

    /**
     * OA期間を取得する
     *
     * @return OA期間
     */
    public String getOADATETERM() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.OADATETERM);
    }

    /**
     * OA期間を設定する
     *
     * @param val OA期間
     */
    public void setOADATETERM(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.OADATETERM, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj45LogSozaiKanriListCmnOA.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj45LogSozaiKanriListCmnOA.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj45LogSozaiKanriListCmnOA.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj45LogSozaiKanriListCmnOA.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj45LogSozaiKanriListCmnOA.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj45LogSozaiKanriListCmnOA.UPDID, val);
    }
}