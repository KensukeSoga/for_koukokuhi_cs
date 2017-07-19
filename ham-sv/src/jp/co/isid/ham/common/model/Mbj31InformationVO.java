package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj31Information;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * インフォメーションマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj31InformationVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj31InformationVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj31InformationVO();
    }

    /**
     * インフォメーションナンバーを取得する
     *
     * @return インフォメーションナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getINFONUMBER() {
        return (BigDecimal) get(Mbj31Information.INFONUMBER);
    }

    /**
     * インフォメーションナンバーを設定する
     *
     * @param val インフォメーションナンバー
     */
    public void setINFONUMBER(BigDecimal val) {
        set(Mbj31Information.INFONUMBER, val);
    }

    /**
     * 作成日時を取得する
     *
     * @return 作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getMAKEDATE() {
        return (Date) get(Mbj31Information.MAKEDATE);
    }

    /**
     * 作成日時を設定する
     *
     * @param val 作成日時
     */
    public void setMAKEDATE(Date val) {
        set(Mbj31Information.MAKEDATE, val);
    }

    /**
     * お知らせ内容を取得する
     *
     * @return お知らせ内容
     */
    public String getMESSAGE() {
        return (String) get(Mbj31Information.MESSAGE);
    }

    /**
     * お知らせ内容を設定する
     *
     * @param val お知らせ内容
     */
    public void setMESSAGE(String val) {
        set(Mbj31Information.MESSAGE, val);
    }

    /**
     * 発信者（登録者）を取得する
     *
     * @return 発信者（登録者）
     */
    public String getMAKEUSER() {
        return (String) get(Mbj31Information.MAKEUSER);
    }

    /**
     * 発信者（登録者）を設定する
     *
     * @param val 発信者（登録者）
     */
    public void setMAKEUSER(String val) {
        set(Mbj31Information.MAKEUSER, val);
    }

    /**
     * 表示状態を取得する
     *
     * @return 表示状態
     */
    public String getDISPSTS() {
        return (String) get(Mbj31Information.DISPSTS);
    }

    /**
     * 表示状態を設定する
     *
     * @param val 表示状態
     */
    public void setDISPSTS(String val) {
        set(Mbj31Information.DISPSTS, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj31Information.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj31Information.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj31Information.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj31Information.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj31Information.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj31Information.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj31Information.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj31Information.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj31Information.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj31Information.UPDID, val);
    }

}
