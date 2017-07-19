package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * アラート表示制御マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj41AlertDispControlVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj41AlertDispControlVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj41AlertDispControlVO();
    }

    /**
     * アラート表示種別を取得する
     *
     * @return アラート表示種別
     */
    public String getDISPTYPE() {
        return (String) get(Mbj41AlertDispControl.DISPTYPE);
    }

    /**
     * アラート表示種別を設定する
     *
     * @param val アラート表示種別
     */
    public void setDISPTYPE(String val) {
        set(Mbj41AlertDispControl.DISPTYPE, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Mbj41AlertDispControl.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Mbj41AlertDispControl.DCARCD, val);
    }

    /**
     * シーケンス番号を取得する
     *
     * @return シーケンス番号
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQNO() {
        return (BigDecimal) get(Mbj41AlertDispControl.SEQNO);
    }

    /**
     * シーケンス番号を設定する
     *
     * @param val シーケンス番号
     */
    public void setSEQNO(BigDecimal val) {
        set(Mbj41AlertDispControl.SEQNO, val);
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID() {
        return (String) get(Mbj41AlertDispControl.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val) {
        set(Mbj41AlertDispControl.HAMID, val);
    }

    /**
     * アラート表示先組織コードを取得する
     *
     * @return アラート表示先組織コード
     */
    public String getSIKOGNZUNTCD() {
        return (String) get(Mbj41AlertDispControl.SIKOGNZUNTCD);
    }

    /**
     * アラート表示先組織コードを設定する
     *
     * @param val アラート表示先組織コード
     */
    public void setSIKOGNZUNTCD(String val) {
        set(Mbj41AlertDispControl.SIKOGNZUNTCD, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj41AlertDispControl.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj41AlertDispControl.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj41AlertDispControl.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj41AlertDispControl.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj41AlertDispControl.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj41AlertDispControl.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj41AlertDispControl.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj41AlertDispControl.UPDID, val);
    }

}
