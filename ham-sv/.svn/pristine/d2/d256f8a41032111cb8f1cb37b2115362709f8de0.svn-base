package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj35MediaPattern;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体パターンマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj35MediaPatternVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj35MediaPatternVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj35MediaPatternVO();
    }

    /**
     * 新雑区分を取得する
     *
     * @return 新雑区分
     */
    public String getSZKBN() {
        return (String) get(Mbj35MediaPattern.SZKBN);
    }

    /**
     * 新雑区分を設定する
     *
     * @param val 新雑区分
     */
    public void setSZKBN(String val) {
        set(Mbj35MediaPattern.SZKBN, val);
    }

    /**
     * 媒体パターンNoを取得する
     *
     * @return 媒体パターンNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBAITAIPATNNO() {
        return (BigDecimal) get(Mbj35MediaPattern.BAITAIPATNNO);
    }

    /**
     * 媒体パターンNoを設定する
     *
     * @param val 媒体パターンNo
     */
    public void setBAITAIPATNNO(BigDecimal val) {
        set(Mbj35MediaPattern.BAITAIPATNNO, val);
    }

    /**
     * 媒体パターン名を取得する
     *
     * @return 媒体パターン名
     */
    public String getBAITAIPATNNAME() {
        return (String) get(Mbj35MediaPattern.BAITAIPATNNAME);
    }

    /**
     * 媒体パターン名を設定する
     *
     * @param val 媒体パターン名
     */
    public void setBAITAIPATNNAME(String val) {
        set(Mbj35MediaPattern.BAITAIPATNNAME, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj35MediaPattern.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj35MediaPattern.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj35MediaPattern.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj35MediaPattern.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj35MediaPattern.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj35MediaPattern.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj35MediaPattern.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj35MediaPattern.UPDID, val);
    }

}
