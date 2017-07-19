package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 見積作成時VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/12 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindNowExpenseVO extends AbstractModel{


    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindNowExpenseVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindNowExpenseVO();
    }


    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj11CrCreateData.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj11CrCreateData.CRDATE, val);
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get(Tbj11CrCreateData.CLASSDIV);
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param val 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set(Tbj11CrCreateData.CLASSDIV, val);
    }

    /**
     * 費目名を取得する
     *
     * @return 費目名
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * 費目名を設定する
     *
     * @param val 費目名
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * 費目を取得する
     *
     * @return 費目
     */
    public String getEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * 費目を設定する
     *
     * @param val 費目
     */
    public void setEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
    }

    /**
     * 詳細を取得する
     *
     * @return 詳細
     */
    public String getDETAIL() {
        return (String) get(Tbj11CrCreateData.DETAIL);
    }

    /**
     * 詳細を設定する
     *
     * @param val 詳細
     */
    public void setDETAIL(String val) {
        set(Tbj11CrCreateData.DETAIL, val);
    }

    /**
     * 請求先を取得する
     *
     * @return 請求先
     */
    public String getSEIKYU() {
        return (String) get(Tbj11CrCreateData.SEIKYU);
    }

    /**
     * 請求先を設定する
     *
     * @param val 請求先
     */
    public void setSEIKYU(String val) {
        set(Tbj11CrCreateData.SEIKYU, val);
    }

    /**
     * 受注NOを取得する
     *
     * @return 受注NO
     */
    public String getORDERNO() {
        return (String) get(Tbj11CrCreateData.ORDERNO);
    }

    /**
     * 受注NOを設定する
     *
     * @param val 受注NO
     */
    public void setORDERNO(String val) {
        set(Tbj11CrCreateData.ORDERNO, val);
    }

    /**
     * 支払先を取得する
     *
     * @return 支払先
     */
    public String getPAY() {
        return (String) get(Tbj11CrCreateData.PAY);
    }

    /**
     * 支払先を設定する
     *
     * @param val 支払先
     */
    public void setPAY(String val) {
        set(Tbj11CrCreateData.PAY, val);
    }

    /**
     * 担当者を取得する
     *
     * @return 担当者
     */
    public String getUSERNAME() {
        return (String) get(Tbj11CrCreateData.USERNAME);
    }

    /**
     * 担当者を設定する
     *
     * @param val 担当者
     */
    public void setUSERNAME(String val) {
        set(Tbj11CrCreateData.USERNAME, val);
    }

    /**
     * 取り金額を取得する
     *
     * @return 取り金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGETMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * 取り金額を設定する
     *
     * @param val 取り金額
     */
    public void setGETMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * 取り金額確認を取得する
     *
     * @return 取り金額確認
     */
    public String getGETCONF() {
        return (String) get(Tbj11CrCreateData.GETCONF);
    }

    /**
     * 取り金額確認を設定する
     *
     * @param val 取り金額確認
     */
    public void setGETCONF(String val) {
        set(Tbj11CrCreateData.GETCONF, val);
    }

    /**
     * 払い金額を取得する
     *
     * @return 払い金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPAYMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * 払い金額を設定する
     *
     * @param val 払い金額
     */
    public void setPAYMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
    }

    /**
     * 払い金額確認を取得する
     *
     * @return 払い金額確認
     */
    public String getPAYCONF() {
        return (String) get(Tbj11CrCreateData.PAYCONF);
    }

    /**
     * 払い金額確認を設定する
     *
     * @param val 払い金額確認
     */
    public void setPAYCONF(String val) {
        set(Tbj11CrCreateData.PAYCONF, val);
    }

    /**
     * 支払先納品日を取得する
     *
     * @return 支払先納品日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * 支払先納品日を設定する
     *
     * @param val 支払先納品日
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
    }

    /**
     * 設定月を取得する
     *
     * @return 設定月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSETMONTH() {
        return (Date) get(Tbj11CrCreateData.SETMONTH);
    }

    /**
     * 設定月を設定する
     *
     * @param val 設定月
     */
    public void setSETMONTH(Date val) {
        set(Tbj11CrCreateData.SETMONTH, val);
    }

    /**
     * 区分名を取得する
     *
     * @return 区分名
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分名を設定する
     *
     * @param val 区分名
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
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
     * 設定局名を取得する
     *
     * @return 設定局名
     */
    public String getSTKYKNM() {
        return (String) get(Mbj29SetteiKyk.STKYKNM);
    }

    /**
     * 設定局名を設定する
     *
     * @param val 設定局名
     */
    public void setSTKYKNM(String val) {
        set(Mbj29SetteiKyk.STKYKNM, val);
    }

    /**
     * 営直チェックを取得する
     *
     * @return 営直チェック
     */
    public String getEGTYKFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLG);
    }

    /**
     * 営直チェックを設定する
     *
     * @param val 営直チェック
     */
    public void setEGTYKFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLG, val);
    }

    /**
     * 入力担当を取得する
     *
     * @return 入力担当
     */
    public String getINPUTTNT() {
        return (String) get(Mbj30InputTnt.INPUTTNT);
    }

    /**
     * 入力担当を設定する
     *
     * @param val 入力担当
     */
    public void setINPUTTNT(String val) {
        set(Mbj30InputTnt.INPUTTNT, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getNOTE() {
        return (String) get(Tbj11CrCreateData.NOTE);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setNOTE(String val) {
        set(Tbj11CrCreateData.NOTE, val);
    }

    /**
     * 制作費管理NOを取得する
     *
     * @return 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj11CrCreateData.SEQUENCENO);
    }

    /**
     * 制作費管理NOを設定する
     *
     * @param val 制作費管理NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj11CrCreateData.SEQUENCENO, val);
    }
}
