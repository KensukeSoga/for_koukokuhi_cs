package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 機能制御項目マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj34FunctionControlItemVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj34FunctionControlItemVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj34FunctionControlItemVO();
    }

    /**
     * 機能コードを取得する
     *
     * @return 機能コード
     */
    public String getFUNCCD() {
        return (String) get(Mbj34FunctionControlItem.FUNCCD);
    }

    /**
     * 機能コードを設定する
     *
     * @param val 機能コード
     */
    public void setFUNCCD(String val) {
        set(Mbj34FunctionControlItem.FUNCCD, val);
    }

    /**
     * 機能種別を取得する
     *
     * @return 種別
     */
    public String getFUNCTYPE() {
        return (String) get(Mbj34FunctionControlItem.FUNCTYPE);
    }

    /**
     * 機能種別を設定する
     *
     * @param val 種別
     */
    public void setFUNCTYPE(String val) {
        set(Mbj34FunctionControlItem.FUNCTYPE, val);
    }

    /**
     * 機能名を取得する
     *
     * @return 機能名
     */
    public String getFUNCNM() {
        return (String) get(Mbj34FunctionControlItem.FUNCNM);
    }

    /**
     * 機能名を設定する
     *
     * @param val 機能名
     */
    public void setFUNCNM(String val) {
        set(Mbj34FunctionControlItem.FUNCNM, val);
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getITEMTYPE() {
        return (String) get(Mbj34FunctionControlItem.ITEMTYPE);
    }

    /**
     * 種別を設定する
     *
     * @param val 種別
     */
    public void setITEMTYPE(String val) {
        set(Mbj34FunctionControlItem.ITEMTYPE, val);
    }

    /**
     * デフォルト制御を取得する
     *
     * @return デフォルト制御
     */
    public String getDEFAULTCONTROL() {
        return (String) get(Mbj34FunctionControlItem.DEFAULTCONTROL);
    }

    /**
     * デフォルト制御を設定する
     *
     * @param val デフォルト制御
     */
    public void setDEFAULTCONTROL(String val) {
        set(Mbj34FunctionControlItem.DEFAULTCONTROL, val);
    }

    /**
     * フォームファイルIDを取得する
     *
     * @return フォームファイルID
     */
    public String getFORMID() {
        return (String) get(Mbj34FunctionControlItem.FORMID);
    }

    /**
     * フォームファイルIDを設定する
     *
     * @param val フォームファイルID
     */
    public void setFORMID(String val) {
        set(Mbj34FunctionControlItem.FORMID, val);
    }

    /**
     * オブジェクト名を取得する
     *
     * @return オブジェクト名
     */
    public String getOBJNAME() {
        return (String) get(Mbj34FunctionControlItem.OBJNAME);
    }

    /**
     * オブジェクト名を設定する
     *
     * @param val オブジェクト名
     */
    public void setOBJNAME(String val) {
        set(Mbj34FunctionControlItem.OBJNAME, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj34FunctionControlItem.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj34FunctionControlItem.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj34FunctionControlItem.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj34FunctionControlItem.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj34FunctionControlItem.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj34FunctionControlItem.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj34FunctionControlItem.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj34FunctionControlItem.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj34FunctionControlItem.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj34FunctionControlItem.UPDID, val);
    }

}
