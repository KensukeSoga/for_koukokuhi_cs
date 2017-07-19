package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 請求グループマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj26BillGroupVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj26BillGroupVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj26BillGroupVO();
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Mbj26BillGroup.GROUPCD);
    }

    /**
     * グループコードを設定する
     *
     * @param val グループコード
     */
    public void setGROUPCD(BigDecimal val) {
        set(Mbj26BillGroup.GROUPCD, val);
    }

    /**
     * グループ名を取得する
     *
     * @return グループ名
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * グループ名を設定する
     *
     * @param val グループ名
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * グループ名(帳票)を取得する
     *
     * @return グループ名(帳票)
     */
    public String getGROUPNMRPT() {
        return (String) get(Mbj26BillGroup.GROUPNMRPT);
    }

    /**
     * グループ名(帳票)を設定する
     *
     * @param val グループ名(帳票)
     */
    public void setGROUPNMRPT(String val) {
        set(Mbj26BillGroup.GROUPNMRPT, val);
    }

    /**
     * ソートNOを取得する
     *
     * @return ソートNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj26BillGroup.SORTNO);
    }

    /**
     * ソートNOを設定する
     *
     * @param val ソートNO
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj26BillGroup.SORTNO, val);
    }

    /**
     * HC部門コードを取得する
     *
     * @return HC部門コード
     */
    public String getHCBUMONCD() {
        return (String) get(Mbj26BillGroup.HCBUMONCD);
    }

    /**
     * HC部門コードを設定する
     *
     * @param val HC部門コード
     */
    public void setHCBUMONCD(String val) {
        set(Mbj26BillGroup.HCBUMONCD, val);
    }

    /**
     * HC部門コード(Fee案件請求用)を取得する
     *
     * @return HC部門コード(Fee案件請求用)
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Mbj26BillGroup.HCBUMONCDBILL);
    }

    /**
     * HC部門コード(Fee案件請求用)を設定する
     *
     * @param val HC部門コード(Fee案件請求用)
     */
    public void setHCBUMONCDBILL(String val) {
        set(Mbj26BillGroup.HCBUMONCDBILL, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj26BillGroup.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj26BillGroup.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj26BillGroup.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj26BillGroup.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj26BillGroup.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj26BillGroup.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj26BillGroup.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj26BillGroup.UPDID, val);
    }

}
