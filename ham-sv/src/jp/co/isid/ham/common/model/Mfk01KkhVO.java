package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mfk01Kkh;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 公開範囲マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mfk01KkhVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mfk01KkhVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mfk01KkhVO();
    }

    /**
     * タイムスタンプを取得する
     *
     * @return タイムスタンプ
     */
    @XmlElement(required = true, nillable = true)
    public Date getTIMSTMP() {
        return (Date) get(Mfk01Kkh.TIMSTMP);
    }

    /**
     * タイムスタンプを設定する
     *
     * @param val タイムスタンプ
     */
    public void setTIMSTMP(Date val) {
        set(Mfk01Kkh.TIMSTMP, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mfk01Kkh.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mfk01Kkh.UPDAPL, val);
    }

    /**
     * 更新担当者を取得する
     *
     * @return 更新担当者
     */
    public String getUPDTNT() {
        return (String) get(Mfk01Kkh.UPDTNT);
    }

    /**
     * 更新担当者を設定する
     *
     * @param val 更新担当者
     */
    public void setUPDTNT(String val) {
        set(Mfk01Kkh.UPDTNT, val);
    }

    /**
     * ユニットNo.を取得する
     *
     * @return ユニットNo.
     */
    public String getZSBCH0100() {
        return (String) get(Mfk01Kkh.ZSBCH0100);
    }

    /**
     * ユニットNo.を設定する
     *
     * @param val ユニットNo.
     */
    public void setZSBCH0100(String val) {
        set(Mfk01Kkh.ZSBCH0100, val);
    }

    /**
     * 有効終了日を取得する
     *
     * @return 有効終了日
     */
    public String getDATETO() {
        return (String) get(Mfk01Kkh.DATETO);
    }

    /**
     * 有効終了日を設定する
     *
     * @param val 有効終了日
     */
    public void setDATETO(String val) {
        set(Mfk01Kkh.DATETO, val);
    }

    /**
     * 有効開始日を取得する
     *
     * @return 有効開始日
     */
    public String getDATEFROM() {
        return (String) get(Mfk01Kkh.DATEFROM);
    }

    /**
     * 有効開始日を設定する
     *
     * @param val 有効開始日
     */
    public void setDATEFROM(String val) {
        set(Mfk01Kkh.DATEFROM, val);
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getZSBCH0105() {
        return (String) get(Mfk01Kkh.ZSBCH0105);
    }

    /**
     * 組織コードを設定する
     *
     * @param val 組織コード
     */
    public void setZSBCH0105(String val) {
        set(Mfk01Kkh.ZSBCH0105, val);
    }

    /**
     * 範囲フラグを取得する
     *
     * @return 範囲フラグ
     */
    public String getZHANNIGF() {
        return (String) get(Mfk01Kkh.ZHANNIGF);
    }

    /**
     * 範囲フラグを設定する
     *
     * @param val 範囲フラグ
     */
    public void setZHANNIGF(String val) {
        set(Mfk01Kkh.ZHANNIGF, val);
    }

    /**
     * 担当グループを取得する
     *
     * @return 担当グループ
     */
    public String getZSBCH0109() {
        return (String) get(Mfk01Kkh.ZSBCH0109);
    }

    /**
     * 担当グループを設定する
     *
     * @param val 担当グループ
     */
    public void setZSBCH0109(String val) {
        set(Mfk01Kkh.ZSBCH0109, val);
    }

    /**
     * 職位・等級グループを取得する
     *
     * @return 職位・等級グループ
     */
    public String getZTOUKYU() {
        return (String) get(Mfk01Kkh.ZTOUKYU);
    }

    /**
     * 職位・等級グループを設定する
     *
     * @param val 職位・等級グループ
     */
    public void setZTOUKYU(String val) {
        set(Mfk01Kkh.ZTOUKYU, val);
    }

    /**
     * 社員コードを取得する
     *
     * @return 社員コード
     */
    public String getZSBCH0110() {
        return (String) get(Mfk01Kkh.ZSBCH0110);
    }

    /**
     * 社員コードを設定する
     *
     * @param val 社員コード
     */
    public void setZSBCH0110(String val) {
        set(Mfk01Kkh.ZSBCH0110, val);
    }

    /**
     * 予算科目（大分類）を取得する
     *
     * @return 予算科目（大分類）
     */
    public String getZBACCTL() {
        return (String) get(Mfk01Kkh.ZBACCTL);
    }

    /**
     * 予算科目（大分類）を設定する
     *
     * @param val 予算科目（大分類）
     */
    public void setZBACCTL(String val) {
        set(Mfk01Kkh.ZBACCTL, val);
    }

    /**
     * 予算科目(中分類）を取得する
     *
     * @return 予算科目(中分類）
     */
    public String getZBACCTM() {
        return (String) get(Mfk01Kkh.ZBACCTM);
    }

    /**
     * 予算科目(中分類）を設定する
     *
     * @param val 予算科目(中分類）
     */
    public void setZBACCTM(String val) {
        set(Mfk01Kkh.ZBACCTM, val);
    }

    /**
     * 予算科目(小分類）を取得する
     *
     * @return 予算科目(小分類）
     */
    public String getZBACCTS() {
        return (String) get(Mfk01Kkh.ZBACCTS);
    }

    /**
     * 予算科目(小分類）を設定する
     *
     * @param val 予算科目(小分類）
     */
    public void setZBACCTS(String val) {
        set(Mfk01Kkh.ZBACCTS, val);
    }

    /**
     * 営業費登録可フラグを取得する
     *
     * @return 営業費登録可フラグ
     */
    public String getZEIGYOU() {
        return (String) get(Mfk01Kkh.ZEIGYOU);
    }

    /**
     * 営業費登録可フラグを設定する
     *
     * @param val 営業費登録可フラグ
     */
    public void setZEIGYOU(String val) {
        set(Mfk01Kkh.ZEIGYOU, val);
    }

    /**
     * ＴＲＳ登録可フラグを取得する
     *
     * @return ＴＲＳ登録可フラグ
     */
    public String getZTRSFG() {
        return (String) get(Mfk01Kkh.ZTRSFG);
    }

    /**
     * ＴＲＳ登録可フラグを設定する
     *
     * @param val ＴＲＳ登録可フラグ
     */
    public void setZTRSFG(String val) {
        set(Mfk01Kkh.ZTRSFG, val);
    }

    /**
     * PL照会フラグを取得する
     *
     * @return PL照会フラグ
     */
    public String getZPLFG() {
        return (String) get(Mfk01Kkh.ZPLFG);
    }

    /**
     * PL照会フラグを設定する
     *
     * @param val PL照会フラグ
     */
    public void setZPLFG(String val) {
        set(Mfk01Kkh.ZPLFG, val);
    }

    /**
     * 受発注登録可フラグを取得する
     *
     * @return 受発注登録可フラグ
     */
    public String getZJYUHACHU() {
        return (String) get(Mfk01Kkh.ZJYUHACHU);
    }

    /**
     * 受発注登録可フラグを設定する
     *
     * @param val 受発注登録可フラグ
     */
    public void setZJYUHACHU(String val) {
        set(Mfk01Kkh.ZJYUHACHU, val);
    }

    /**
     * 全権限フラグを取得する
     *
     * @return 全権限フラグ
     */
    public String getZALLFG() {
        return (String) get(Mfk01Kkh.ZALLFG);
    }

    /**
     * 全権限フラグを設定する
     *
     * @param val 全権限フラグ
     */
    public void setZALLFG(String val) {
        set(Mfk01Kkh.ZALLFG, val);
    }

    /**
     * 継承管理フラグを取得する
     *
     * @return 継承管理フラグ
     */
    public String getZKEISYOU() {
        return (String) get(Mfk01Kkh.ZKEISYOU);
    }

    /**
     * 継承管理フラグを設定する
     *
     * @param val 継承管理フラグ
     */
    public void setZKEISYOU(String val) {
        set(Mfk01Kkh.ZKEISYOU, val);
    }

    /**
     * 論理削除フラグを取得する
     *
     * @return 論理削除フラグ
     */
    public String getZDELFG() {
        return (String) get(Mfk01Kkh.ZDELFG);
    }

    /**
     * 論理削除フラグを設定する
     *
     * @param val 論理削除フラグ
     */
    public void setZDELFG(String val) {
        set(Mfk01Kkh.ZDELFG, val);
    }

    /**
     * 公開範囲タイムスタンプを取得する
     *
     * @return 公開範囲タイムスタンプ
     */
    public String getKKHTIMESTAMP() {
        return (String) get(Mfk01Kkh.KKHTIMESTAMP);
    }

    /**
     * 公開範囲タイムスタンプを設定する
     *
     * @param val 公開範囲タイムスタンプ
     */
    public void setKKHTIMESTAMP(String val) {
        set(Mfk01Kkh.KKHTIMESTAMP, val);
    }

}
