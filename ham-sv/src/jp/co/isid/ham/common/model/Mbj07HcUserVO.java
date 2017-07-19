package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj07HcUser;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HCユーザマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj07HcUserVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj07HcUserVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj07HcUserVO();
    }

    /**
     * HC担当者コードを取得する
     *
     * @return HC担当者コード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHCUSERCD() {
        return (BigDecimal) get(Mbj07HcUser.HCUSERCD);
    }

    /**
     * HC担当者コードを設定する
     *
     * @param val HC担当者コード
     */
    public void setHCUSERCD(BigDecimal val) {
        set(Mbj07HcUser.HCUSERCD, val);
    }

    /**
     * HC担当者名を取得する
     *
     * @return HC担当者名
     */
    public String getHCUSERNM() {
        return (String) get(Mbj07HcUser.HCUSERNM);
    }

    /**
     * HC担当者名を設定する
     *
     * @param val HC担当者名
     */
    public void setHCUSERNM(String val) {
        set(Mbj07HcUser.HCUSERNM, val);
    }

    /**
     * HC部門コードを取得する
     *
     * @return HC部門コード
     */
    public String getHCBUMONCD() {
        return (String) get(Mbj07HcUser.HCBUMONCD);
    }

    /**
     * HC部門コードを設定する
     *
     * @param val HC部門コード
     */
    public void setHCBUMONCD(String val) {
        set(Mbj07HcUser.HCBUMONCD, val);
    }

    /**
     * ソートNOを取得する
     *
     * @return ソートNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj07HcUser.SORTNO);
    }

    /**
     * ソートNOを設定する
     *
     * @param val ソートNO
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj07HcUser.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj07HcUser.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj07HcUser.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj07HcUser.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj07HcUser.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj07HcUser.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj07HcUser.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj07HcUser.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj07HcUser.UPDID, val);
    }

}
