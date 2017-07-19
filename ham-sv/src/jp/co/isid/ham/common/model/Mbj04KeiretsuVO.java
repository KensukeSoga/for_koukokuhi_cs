package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj04Keiretsu;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 系列マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj04KeiretsuVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj04KeiretsuVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj04KeiretsuVO();
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj04Keiretsu.KEIRETSUCD);
    }

    /**
     * 系列コードを設定する
     *
     * @param val 系列コード
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj04Keiretsu.KEIRETSUCD, val);
    }

    /**
     * 系列名を取得する
     *
     * @return 系列名
     */
    public String getKEIRETSUNM() {
        return (String) get(Mbj04Keiretsu.KEIRETSUNM);
    }

    /**
     * 系列名を設定する
     *
     * @param val 系列名
     */
    public void setKEIRETSUNM(String val) {
        set(Mbj04Keiretsu.KEIRETSUNM, val);
    }

    /**
     * 系列名略を取得する
     *
     * @return 系列名略
     */
    public String getKEIRETSUSNM() {
        return (String) get(Mbj04Keiretsu.KEIRETSUSNM);
    }

    /**
     * 系列名略を設定する
     *
     * @param val 系列名略
     */
    public void setKEIRETSUSNM(String val) {
        set(Mbj04Keiretsu.KEIRETSUSNM, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj04Keiretsu.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj04Keiretsu.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj04Keiretsu.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj04Keiretsu.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj04Keiretsu.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj04Keiretsu.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj04Keiretsu.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj04Keiretsu.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj04Keiretsu.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj04Keiretsu.UPDID, val);
    }

}
