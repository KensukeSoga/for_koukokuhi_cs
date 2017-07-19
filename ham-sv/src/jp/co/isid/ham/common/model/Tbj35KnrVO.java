package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 管理テーブルVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj35KnrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj35KnrVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj35KnrVO();
    }

    /**
     * システムNOを取得する
     *
     * @return システムNO
     */
    public String getSYSTEMNO() {
        return (String) get(Tbj35Knr.SYSTEMNO);
    }

    /**
     * システムNOを設定する
     *
     * @param val システムNO
     */
    public void setSYSTEMNO(String val) {
        set(Tbj35Knr.SYSTEMNO, val);
    }

    /**
     * システム名称を取得する
     *
     * @return システム名称
     */
    public String getSYSTEMNAME() {
        return (String) get(Tbj35Knr.SYSTEMNAME);
    }

    /**
     * システム名称を設定する
     *
     * @param val システム名称
     */
    public void setSYSTEMNAME(String val) {
        set(Tbj35Knr.SYSTEMNAME, val);
    }

    /**
     * 管理フラグを取得する
     *
     * @return 管理フラグ
     */
    public String getKANRIFLG() {
        return (String) get(Tbj35Knr.KANRIFLG);
    }

    /**
     * 管理フラグを設定する
     *
     * @param val 管理フラグ
     */
    public void setKANRIFLG(String val) {
        set(Tbj35Knr.KANRIFLG, val);
    }

    /**
     * 利用可能開始曜日区分を取得する
     *
     * @return 利用可能開始曜日区分
     */
    public String getRSTAYOKBN() {
        return (String) get(Tbj35Knr.RSTAYOKBN);
    }

    /**
     * 利用可能開始曜日区分を設定する
     *
     * @param val 利用可能開始曜日区分
     */
    public void setRSTAYOKBN(String val) {
        set(Tbj35Knr.RSTAYOKBN, val);
    }

    /**
     * 利用可能終了曜日区分を取得する
     *
     * @return 利用可能終了曜日区分
     */
    public String getRENDYOKBN() {
        return (String) get(Tbj35Knr.RENDYOKBN);
    }

    /**
     * 利用可能終了曜日区分を設定する
     *
     * @param val 利用可能終了曜日区分
     */
    public void setRENDYOKBN(String val) {
        set(Tbj35Knr.RENDYOKBN, val);
    }

    /**
     * 利用可能日付変更区分を取得する
     *
     * @return 利用可能日付変更区分
     */
    public String getDAYCHGKBN() {
        return (String) get(Tbj35Knr.DAYCHGKBN);
    }

    /**
     * 利用可能日付変更区分を設定する
     *
     * @param val 利用可能日付変更区分
     */
    public void setDAYCHGKBN(String val) {
        set(Tbj35Knr.DAYCHGKBN, val);
    }

    /**
     * 利用可能開始時間を取得する
     *
     * @return 利用可能開始時間
     */
    public String getRSTARTTIME() {
        return (String) get(Tbj35Knr.RSTARTTIME);
    }

    /**
     * 利用可能開始時間を設定する
     *
     * @param val 利用可能開始時間
     */
    public void setRSTARTTIME(String val) {
        set(Tbj35Knr.RSTARTTIME, val);
    }

    /**
     * 利用可能終了時間を取得する
     *
     * @return 利用可能終了時間
     */
    public String getRENDTIME() {
        return (String) get(Tbj35Knr.RENDTIME);
    }

    /**
     * 利用可能終了時間を設定する
     *
     * @param val 利用可能終了時間
     */
    public void setRENDTIME(String val) {
        set(Tbj35Knr.RENDTIME, val);
    }

    /**
     * 営業日を取得する
     *
     * @return 営業日
     */
    public String getEIGYOBI() {
        return (String) get(Tbj35Knr.EIGYOBI);
    }

    /**
     * 営業日を設定する
     *
     * @param val 営業日
     */
    public void setEIGYOBI(String val) {
        set(Tbj35Knr.EIGYOBI, val);
    }

    /**
     * メッセージ１を取得する
     *
     * @return メッセージ１
     */
    public String getMSG01() {
        return (String) get(Tbj35Knr.MSG01);
    }

    /**
     * メッセージ１を設定する
     *
     * @param val メッセージ１
     */
    public void setMSG01(String val) {
        set(Tbj35Knr.MSG01, val);
    }

    /**
     * メッセージ２を取得する
     *
     * @return メッセージ２
     */
    public String getMSG02() {
        return (String) get(Tbj35Knr.MSG02);
    }

    /**
     * メッセージ２を設定する
     *
     * @param val メッセージ２
     */
    public void setMSG02(String val) {
        set(Tbj35Knr.MSG02, val);
    }

    /**
     * メッセージ３を取得する
     *
     * @return メッセージ３
     */
    public String getMSG03() {
        return (String) get(Tbj35Knr.MSG03);
    }

    /**
     * メッセージ３を設定する
     *
     * @param val メッセージ３
     */
    public void setMSG03(String val) {
        set(Tbj35Knr.MSG03, val);
    }

    /**
     * メッセージ４を取得する
     *
     * @return メッセージ４
     */
    public String getMSG04() {
        return (String) get(Tbj35Knr.MSG04);
    }

    /**
     * メッセージ４を設定する
     *
     * @param val メッセージ４
     */
    public void setMSG04(String val) {
        set(Tbj35Knr.MSG04, val);
    }

    /**
     * メッセージ５を取得する
     *
     * @return メッセージ５
     */
    public String getMSG05() {
        return (String) get(Tbj35Knr.MSG05);
    }

    /**
     * メッセージ５を設定する
     *
     * @param val メッセージ５
     */
    public void setMSG05(String val) {
        set(Tbj35Knr.MSG05, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKOU() {
        return (String) get(Tbj35Knr.BIKOU);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKOU(String val) {
        set(Tbj35Knr.BIKOU, val);
    }

    /**
     * 表示区分を取得する
     *
     * @return 表示区分
     */
    public String getHYOUJIKBN() {
        return (String) get(Tbj35Knr.HYOUJIKBN);
    }

    /**
     * 表示区分を設定する
     *
     * @param val 表示区分
     */
    public void setHYOUJIKBN(String val) {
        set(Tbj35Knr.HYOUJIKBN, val);
    }

    /**
     * バッチ制御フラグを取得する
     *
     * @return バッチ制御フラグ
     */
    public String getBATCHFLG() {
        return (String) get(Tbj35Knr.BATCHFLG);
    }

    /**
     * バッチ制御フラグを設定する
     *
     * @param val バッチ制御フラグ
     */
    public void setBATCHFLG(String val) {
        set(Tbj35Knr.BATCHFLG, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj35Knr.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj35Knr.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj35Knr.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj35Knr.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj35Knr.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj35Knr.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj35Knr.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj35Knr.UPDID, val);
    }

}
