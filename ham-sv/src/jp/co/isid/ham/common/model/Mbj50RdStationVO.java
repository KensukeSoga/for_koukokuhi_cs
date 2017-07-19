package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ局マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj50RdStationVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj50RdStationVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj50RdStationVO();
    }

    /**
     * ラジオ局コードを取得する
     *
     * @return ラジオ局コード
     */
    public String getRDCD() {
        return (String) get(Mbj50RdStation.RDCD);
    }

    /**
     * ラジオ局コードを設定する
     *
     * @param val ラジオ局コード
     */
    public void setRDCD(String val) {
        set(Mbj50RdStation.RDCD, val);
    }

    /**
     * ラジオ局名称を取得する
     *
     * @return ラジオ局名称
     */
    public String getRDNM() {
        return (String) get(Mbj50RdStation.RDNM);
    }

    /**
     * ラジオ局名称を設定する
     *
     * @param val ラジオ局名称
     */
    public void setRDNM(String val) {
        set(Mbj50RdStation.RDNM, val);
    }

    /**
     * 愛称略称を取得する
     *
     * @return 愛称略称
     */
    public String getABBREVIATION() {
        return (String) get(Mbj50RdStation.ABBREVIATION);
    }

    /**
     * 愛称略称を設定する
     *
     * @param val 愛称略称
     */
    public void setABBREVIATION(String val) {
        set(Mbj50RdStation.ABBREVIATION, val);
    }

    /**
     * JASRAC帳票出力名称を取得する
     *
     * @return JASRAC帳票出力名称
     */
    public String getJASRACREPORTNM() {
        return (String) get(Mbj50RdStation.JASRACREPORTNM);
    }

    /**
     * JASRAC帳票出力名称を設定する
     *
     * @param val JASRAC帳票出力名称
     */
    public void setJASRACREPORTNM(String val) {
        set(Mbj50RdStation.JASRACREPORTNM, val);
    }

    /**
     * JFN系列フラグを取得する
     *
     * @return JFN系列フラグ
     */
    public String getJFNGRPFLG() {
        return (String) get(Mbj50RdStation.JFNGRPFLG);
    }

    /**
     * JFN系列フラグを設定する
     *
     * @param val JFN系列フラグ
     */
    public void setJFNGRPFLG(String val) {
        set(Mbj50RdStation.JFNGRPFLG, val);
    }

    /**
     * JRN系列フラグを取得する
     *
     * @return JRN系列フラグ
     */
    public String getJRNGRPFLG() {
        return (String) get(Mbj50RdStation.JRNGRPFLG);
    }

    /**
     * JRN系列フラグを設定する
     *
     * @param val JRN系列フラグ
     */
    public void setJRNGRPFLG(String val) {
        set(Mbj50RdStation.JRNGRPFLG, val);
    }

    /**
     * NRN系列フラグを取得する
     *
     * @return NRN系列フラグ
     */
    public String getNRNGRPFLG() {
        return (String) get(Mbj50RdStation.NRNGRPFLG);
    }

    /**
     * NRN系列フラグを設定する
     *
     * @param val NRN系列フラグ
     */
    public void setNRNGRPFLG(String val) {
        set(Mbj50RdStation.NRNGRPFLG, val);
    }

    /**
     * 表示順を取得する
     *
     * @return 表示順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj50RdStation.SORTNO);
    }

    /**
     * 表示順を設定する
     *
     * @param val 表示順
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj50RdStation.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj50RdStation.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj50RdStation.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj50RdStation.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj50RdStation.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj50RdStation.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj50RdStation.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj50RdStation.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj50RdStation.UPDID, val);
    }

}
