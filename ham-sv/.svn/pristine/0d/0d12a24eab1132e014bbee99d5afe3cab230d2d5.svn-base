package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj36MediaPatternItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体パターン内容マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj36MediaPatternItemVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj36MediaPatternItemVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj36MediaPatternItemVO();
    }

    /**
     * 新雑区分を取得する
     *
     * @return 新雑区分
     */
    public String getSZKBN() {
        return (String) get(Mbj36MediaPatternItem.SZKBN);
    }

    /**
     * 新雑区分を設定する
     *
     * @param val 新雑区分
     */
    public void setSZKBN(String val) {
        set(Mbj36MediaPatternItem.SZKBN, val);
    }

    /**
     * 媒体パターンNoを取得する
     *
     * @return 媒体パターンNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBAITAIPATNNO() {
        return (BigDecimal) get(Mbj36MediaPatternItem.BAITAIPATNNO);
    }

    /**
     * 媒体パターンNoを設定する
     *
     * @param val 媒体パターンNo
     */
    public void setBAITAIPATNNO(BigDecimal val) {
        set(Mbj36MediaPatternItem.BAITAIPATNNO, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getNPCD() {
        return (String) get(Mbj36MediaPatternItem.NPCD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setNPCD(String val) {
        set(Mbj36MediaPatternItem.NPCD, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj36MediaPatternItem.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj36MediaPatternItem.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj36MediaPatternItem.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj36MediaPatternItem.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj36MediaPatternItem.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj36MediaPatternItem.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj36MediaPatternItem.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj36MediaPatternItem.UPDID, val);
    }

}
