package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM請求書(CR制作費)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillCreationCrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillCreationCrVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillCreationCrVO();
    }

    /**
     * 電通車種コードを取得する
     * @return String 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     * @param val String 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj11CrCreateData.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj11CrCreateData.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj11CrCreateData.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val Date 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj11CrCreateData.CRDATE, val);
    }

    /**
     * 制作費管理NOを取得する
     * @return BigDecimal 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj11CrCreateData.SEQUENCENO);
    }

    /**
     * 制作費管理NOを設定する
     * @param val BigDecimal 制作費管理NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj11CrCreateData.SEQUENCENO, val);
    }

    /**
     * 種別判断フラグを取得する
     * @return String 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get(Tbj11CrCreateData.CLASSDIV);
    }

    /**
     * 種別判断フラグを設定する
     * @param val String 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set(Tbj11CrCreateData.CLASSDIV, val);
    }

    /**
     * ソート順を取得する
     * @return BigDecimal ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj11CrCreateData.SORTNO);
    }

    /**
     * ソート順を設定する
     * @param val BigDecimal ソート順
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj11CrCreateData.SORTNO, val);
    }

    /**
     * 予算分類コードを取得する
     * @return String 予算分類コード
     */
    public String getCLASSCD() {
        return (String) get(Tbj11CrCreateData.CLASSCD);
    }

    /**
     * 予算分類コードを設定する
     * @param val String 予算分類コード
     */
    public void setCLASSCD(String val) {
        set(Tbj11CrCreateData.CLASSCD, val);
    }

    /**
     * 予算表費目コードを取得する
     * @return String 予算表費目コード
     */
    public String getEXPCD() {
        return (String) get(Tbj11CrCreateData.EXPCD);
    }

    /**
     * 予算表費目コードを設定する
     * @param val String 予算表費目コード
     */
    public void setEXPCD(String val) {
        set(Tbj11CrCreateData.EXPCD, val);
    }

    /**
     * 費目を取得する
     * @return String 費目
     */
    public String getEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * 費目を設定する
     * @param val String 費目
     */
    public void setEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
    }

    /**
     * 詳細を取得する
     * @return String 詳細
     */
    public String getDETAIL() {
        return (String) get(Tbj11CrCreateData.DETAIL);
    }

    /**
     * 詳細を設定する
     * @param val String 詳細
     */
    public void setDETAIL(String val) {
        set(Tbj11CrCreateData.DETAIL, val);
    }

    /**
     * 期間開始を取得する
     * @return Date 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj11CrCreateData.KIKANS);
    }

    /**
     * 期間開始を設定する
     * @param val Date 期間開始
     */
    public void setKIKANS(Date val) {
        set(Tbj11CrCreateData.KIKANS, val);
    }

    /**
     * 期間終了を取得する
     * @return Date 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj11CrCreateData.KIKANE);
    }

    /**
     * 期間終了を設定する
     * @param val Date 期間終了
     */
    public void setKIKANE(Date val) {
        set(Tbj11CrCreateData.KIKANE, val);
    }

    /**
     * 契約開始年月日を取得する
     * @return Date 契約開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONTRACTDATE() {
        return (Date) get(Tbj11CrCreateData.CONTRACTDATE);
    }

    /**
     * 契約開始年月日を設定する
     * @param val Date 契約開始年月日
     */
    public void setCONTRACTDATE(Date val) {
        set(Tbj11CrCreateData.CONTRACTDATE, val);
    }

    /**
     * 契約期間(ヶ月)を取得する
     * @return String 契約期間(ヶ月)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERM);
    }

    /**
     * 契約期間(ヶ月)を設定する
     * @param val String 契約期間(ヶ月)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj11CrCreateData.CONTRACTTERM, val);
    }

    /**
     * 請求先を取得する
     * @return String 請求先
     */
    public String getSEIKYU() {
        return (String) get(Tbj11CrCreateData.SEIKYU);
    }

    /**
     * 請求先を設定する
     * @param val String 請求先
     */
    public void setSEIKYU(String val) {
        set(Tbj11CrCreateData.SEIKYU, val);
    }

    /**
     * 受注NOを取得する
     * @return String 受注NO
     */
    public String getORDERNO() {
        return (String) get(Tbj11CrCreateData.ORDERNO);
    }

    /**
     * 受注NOを設定する
     * @param val String 受注NO
     */
    public void setORDERNO(String val) {
        set(Tbj11CrCreateData.ORDERNO, val);
    }

    /**
     * 支払先を取得する
     * @return String 支払先
     */
    public String getPAY() {
        return (String) get(Tbj11CrCreateData.PAY);
    }

    /**
     * 支払先を設定する
     * @param val String 支払先
     */
    public void setPAY(String val) {
        set(Tbj11CrCreateData.PAY, val);
    }

    /**
     * 担当者を取得する
     * @return String 担当者
     */
    public String getUSERNAME() {
        return (String) get(Tbj11CrCreateData.USERNAME);
    }

    /**
     * 担当者を設定する
     * @param val String 担当者
     */
    public void setUSERNAME(String val) {
        set(Tbj11CrCreateData.USERNAME, val);
    }

    /**
     * 取り金額を取得する
     * @return BigDecimal 取り金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGETMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * 取り金額を設定する
     * @param val BigDecimal 取り金額
     */
    public void setGETMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * 取り金額確認を取得する
     * @return String 取り金額確認
     */
    public String getGETCONF() {
        return (String) get(Tbj11CrCreateData.GETCONF);
    }

    /**
     * 取り金額確認を設定する
     * @param val String 取り金額確認
     */
    public void setGETCONF(String val) {
        set(Tbj11CrCreateData.GETCONF, val);
    }

    /**
     * 払い金額を取得する
     * @return BigDecimal 払い金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPAYMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * 払い金額を設定する
     * @param val BigDecimal 払い金額
     */
    public void setPAYMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
    }

    /**
     * 払い金額確認を取得する
     * @return String 払い金額確認
     */
    public String getPAYCONF() {
        return (String) get(Tbj11CrCreateData.PAYCONF);
    }

    /**
     * 払い金額確認を設定する
     * @param val String 払い金額確認
     */
    public void setPAYCONF(String val) {
        set(Tbj11CrCreateData.PAYCONF, val);
    }

    /**
     * 見積金額を取得する
     * @return BigDecimal 見積金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.ESTMONEY);
    }

    /**
     * 見積金額を設定する
     * @param val BigDecimal 見積金額
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.ESTMONEY, val);
    }

    /**
     * 請求金額を取得する
     * @return BigDecimal 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.CLMMONEY);
    }

    /**
     * 請求金額を設定する
     * @param val BigDecimal 請求金額
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.CLMMONEY, val);
    }

    /**
     * 支払先納品日を取得する
     * @return Date 支払先納品日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * 支払先納品日を設定する
     * @param val Date 支払先納品日
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
    }

    /**
     * 設定月を取得する
     * @return Date 設定月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSETMONTH() {
        return (Date) get(Tbj11CrCreateData.SETMONTH);
    }

    /**
     * 設定月を設定する
     * @param val Date 設定月
     */
    public void setSETMONTH(Date val) {
        set(Tbj11CrCreateData.SETMONTH, val);
    }

    /**
     * 区分コードを取得する
     * @return String 区分コード
     */
    public String getDIVCD() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * 区分コードを設定する
     * @param val String 区分コード
     */
    public void setDIVCD(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
    }

    /**
     * グループコードを取得する
     * @return BigDecimal グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj11CrCreateData.GROUPCD);
    }

    /**
     * グループコードを設定する
     * @param val BigDecimal グループコード
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj11CrCreateData.GROUPCD, val);
    }

    /**
     * 設定局ナンバーを取得する
     * @return BigDecimal 設定局ナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSTKYKNO() {
        return (BigDecimal) get(Tbj11CrCreateData.STKYKNO);
    }

    /**
     * 設定局ナンバーを設定する
     * @param val BigDecimal 設定局ナンバー
     */
    public void setSTKYKNO(BigDecimal val) {
        set(Tbj11CrCreateData.STKYKNO, val);
    }

    /**
     * 営直チェックを取得する
     * @return String 営直チェック
     */
    public String getEGTYKFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLG);
    }

    /**
     * 営直チェックを設定する
     * @param val String 営直チェック
     */
    public void setEGTYKFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLG, val);
    }

    /**
     * 入力担当コードを取得する
     * @return BigDecimal 入力担当コード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getINPUTTNTCD() {
        return (BigDecimal) get(Tbj11CrCreateData.INPUTTNTCD);
    }

    /**
     * 入力担当コードを設定する
     * @param val BigDecimal 入力担当コード
     */
    public void setINPUTTNTCD(BigDecimal val) {
        set(Tbj11CrCreateData.INPUTTNTCD, val);
    }

    /**
     * CP担当者名を取得する
     * @return String CP担当者名
     */
    public String getCPTNTNM() {
        return (String) get(Tbj11CrCreateData.CPTNTNM);
    }

    /**
     * CP担当者名を設定する
     * @param val String CP担当者名
     */
    public void setCPTNTNM(String val) {
        set(Tbj11CrCreateData.CPTNTNM, val);
    }

    /**
     * 備考を取得する
     * @return String 備考
     */
    public String getNOTE() {
        return (String) get(Tbj11CrCreateData.NOTE);
    }

    /**
     * 備考を設定する
     * @param val String 備考
     */
    public void setNOTE(String val) {
        set(Tbj11CrCreateData.NOTE, val);
    }

    /**
     * 電通車種コードフラグを取得する
     * @return String 電通車種コードフラグ
     */
    public String getDCARCDFLG() {
        return (String) get(Tbj11CrCreateData.DCARCDFLG);
    }

    /**
     * 電通車種コードフラグを設定する
     * @param val String 電通車種コードフラグ
     */
    public void setDCARCDFLG(String val) {
        set(Tbj11CrCreateData.DCARCDFLG, val);
    }

    /**
     * 予算分類フラグを取得する
     * @return String 予算分類フラグ
     */
    public String getCLASSCDFLG() {
        return (String) get(Tbj11CrCreateData.CLASSCDFLG);
    }

    /**
     * 予算分類フラグを設定する
     * @param val String 予算分類フラグ
     */
    public void setCLASSCDFLG(String val) {
        set(Tbj11CrCreateData.CLASSCDFLG, val);
    }

    /**
     * 予算表費目フラグを取得する
     * @return String 予算表費目フラグ
     */
    public String getEXPCDFLG() {
        return (String) get(Tbj11CrCreateData.EXPCDFLG);
    }

    /**
     * 予算表費目フラグを設定する
     * @param val String 予算表費目フラグ
     */
    public void setEXPCDFLG(String val) {
        set(Tbj11CrCreateData.EXPCDFLG, val);
    }

    /**
     * 費目フラグを取得する
     * @return String 費目フラグ
     */
    public String getEXPENSEFLG() {
        return (String) get(Tbj11CrCreateData.EXPENSEFLG);
    }

    /**
     * 費目フラグを設定する
     * @param val String 費目フラグ
     */
    public void setEXPENSEFLG(String val) {
        set(Tbj11CrCreateData.EXPENSEFLG, val);
    }

    /**
     * 詳細フラグを取得する
     * @return String 詳細フラグ
     */
    public String getDETAILFLG() {
        return (String) get(Tbj11CrCreateData.DETAILFLG);
    }

    /**
     * 詳細フラグを設定する
     * @param val String 詳細フラグ
     */
    public void setDETAILFLG(String val) {
        set(Tbj11CrCreateData.DETAILFLG, val);
    }

    /**
     * 期間開始フラグを取得する
     * @return String 期間開始フラグ
     */
    public String getKIKANSFLG() {
        return (String) get(Tbj11CrCreateData.KIKANSFLG);
    }

    /**
     * 期間開始フラグを設定する
     * @param val String 期間開始フラグ
     */
    public void setKIKANSFLG(String val) {
        set(Tbj11CrCreateData.KIKANSFLG, val);
    }

    /**
     * 期間終了フラグを取得する
     * @return String 期間終了フラグ
     */
    public String getKIKANEFLG() {
        return (String) get(Tbj11CrCreateData.KIKANEFLG);
    }

    /**
     * 期間終了フラグを設定する
     * @param val String 期間終了フラグ
     */
    public void setKIKANEFLG(String val) {
        set(Tbj11CrCreateData.KIKANEFLG, val);
    }

    /**
     * 契約開始年月日フラグを取得する
     * @return String 契約開始年月日フラグ
     */
    public String getCONTRACTDATEFLG() {
        return (String) get(Tbj11CrCreateData.CONTRACTDATEFLG);
    }

    /**
     * 契約開始年月日フラグを設定する
     * @param val String 契約開始年月日フラグ
     */
    public void setCONTRACTDATEFLG(String val) {
        set(Tbj11CrCreateData.CONTRACTDATEFLG, val);
    }

    /**
     * 契約期間(ヶ月)フラグを取得する
     * @return String 契約期間(ヶ月)フラグ
     */
    public String getCONTRACTTERMFLG() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERMFLG);
    }

    /**
     * 契約期間(ヶ月)フラグを設定する
     * @param val String 契約期間(ヶ月)フラグ
     */
    public void setCONTRACTTERMFLG(String val) {
        set(Tbj11CrCreateData.CONTRACTTERMFLG, val);
    }

    /**
     * 請求先フラグを取得する
     * @return String 請求先フラグ
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj11CrCreateData.SEIKYUFLG);
    }

    /**
     * 請求先フラグを設定する
     * @param val String 請求先フラグ
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj11CrCreateData.SEIKYUFLG, val);
    }

    /**
     * 受注NOフラグを取得する
     * @return String 受注NOフラグ
     */
    public String getORDERNOFLG() {
        return (String) get(Tbj11CrCreateData.ORDERNOFLG);
    }

    /**
     * 受注NOフラグを設定する
     * @param val String 受注NOフラグ
     */
    public void setORDERNOFLG(String val) {
        set(Tbj11CrCreateData.ORDERNOFLG, val);
    }

    /**
     * 支払先フラグを取得する
     * @return String 支払先フラグ
     */
    public String getPAYFLG() {
        return (String) get(Tbj11CrCreateData.PAYFLG);
    }

    /**
     * 支払先フラグを設定する
     * @param val String 支払先フラグ
     */
    public void setPAYFLG(String val) {
        set(Tbj11CrCreateData.PAYFLG, val);
    }

    /**
     * 担当者フラグを取得する
     * @return String 担当者フラグ
     */
    public String getUSERNAMEFLG() {
        return (String) get(Tbj11CrCreateData.USERNAMEFLG);
    }

    /**
     * 担当者フラグを設定する
     * @param val String 担当者フラグ
     */
    public void setUSERNAMEFLG(String val) {
        set(Tbj11CrCreateData.USERNAMEFLG, val);
    }

    /**
     * 取り金額フラグを取得する
     * @return String 取り金額フラグ
     */
    public String getGETMONEYFLG() {
        return (String) get(Tbj11CrCreateData.GETMONEYFLG);
    }

    /**
     * 取り金額フラグを設定する
     * @param val String 取り金額フラグ
     */
    public void setGETMONEYFLG(String val) {
        set(Tbj11CrCreateData.GETMONEYFLG, val);
    }

    /**
     * 取り金額確認フラグを取得する
     * @return String 取り金額確認フラグ
     */
    public String getGETCONFIRMFLG() {
        return (String) get(Tbj11CrCreateData.GETCONFIRMFLG);
    }

    /**
     * 取り金額確認フラグを設定する
     * @param val String 取り金額確認フラグ
     */
    public void setGETCONFIRMFLG(String val) {
        set(Tbj11CrCreateData.GETCONFIRMFLG, val);
    }

    /**
     * 払い金額フラグを取得する
     * @return String 払い金額フラグ
     */
    public String getPAYMONEYFLG() {
        return (String) get(Tbj11CrCreateData.PAYMONEYFLG);
    }

    /**
     * 払い金額フラグを設定する
     * @param val String 払い金額フラグ
     */
    public void setPAYMONEYFLG(String val) {
        set(Tbj11CrCreateData.PAYMONEYFLG, val);
    }

    /**
     * 払い金額確認フラグを取得する
     * @return String 払い金額確認フラグ
     */
    public String getPAYCONFIRMFLG() {
        return (String) get(Tbj11CrCreateData.PAYCONFIRMFLG);
    }

    /**
     * 払い金額確認フラグを設定する
     * @param val String 払い金額確認フラグ
     */
    public void setPAYCONFIRMFLG(String val) {
        set(Tbj11CrCreateData.PAYCONFIRMFLG, val);
    }

    /**
     * 見積金額フラグを取得する
     * @return String 見積金額フラグ
     */
    public String getESTMONEYFLG() {
        return (String) get(Tbj11CrCreateData.ESTMONEYFLG);
    }

    /**
     * 見積金額フラグを設定する
     * @param val String 見積金額フラグ
     */
    public void setESTMONEYFLG(String val) {
        set(Tbj11CrCreateData.ESTMONEYFLG, val);
    }

    /**
     * 請求金額フラグを取得する
     * @return String 請求金額フラグ
     */
    public String getCLMMONEYFLG() {
        return (String) get(Tbj11CrCreateData.CLMMONEYFLG);
    }

    /**
     * 請求金額フラグを設定する
     * @param val String 請求金額フラグ
     */
    public void setCLMMONEYFLG(String val) {
        set(Tbj11CrCreateData.CLMMONEYFLG, val);
    }

    /**
     * 支払先納品日フラグを取得する
     * @return String 支払先納品日フラグ
     */
    public String getDELIVERDAYFLG() {
        return (String) get(Tbj11CrCreateData.DELIVERDAYFLG);
    }

    /**
     * 支払先納品日フラグを設定する
     * @param val String 支払先納品日フラグ
     */
    public void setDELIVERDAYFLG(String val) {
        set(Tbj11CrCreateData.DELIVERDAYFLG, val);
    }

    /**
     * 設定月フラグを取得する
     * @return String 設定月フラグ
     */
    public String getSETMONTHFLG() {
        return (String) get(Tbj11CrCreateData.SETMONTHFLG);
    }

    /**
     * 設定月フラグを設定する
     * @param val String 設定月フラグ
     */
    public void setSETMONTHFLG(String val) {
        set(Tbj11CrCreateData.SETMONTHFLG, val);
    }

    /**
     * 区分フラグを取得する
     * @return String 区分フラグ
     */
    public String getDIVISIONFLG() {
        return (String) get(Tbj11CrCreateData.DIVISIONFLG);
    }

    /**
     * 区分フラグを設定する
     * @param val String 区分フラグ
     */
    public void setDIVISIONFLG(String val) {
        set(Tbj11CrCreateData.DIVISIONFLG, val);
    }

    /**
     * グループコードフラグを取得する
     * @return String グループコードフラグ
     */
    public String getGROUPCDFLG() {
        return (String) get(Tbj11CrCreateData.GROUPCDFLG);
    }

    /**
     * グループコードフラグを設定する
     * @param val String グループコードフラグ
     */
    public void setGROUPCDFLG(String val) {
        set(Tbj11CrCreateData.GROUPCDFLG, val);
    }

    /**
     * 設定局コードフラグを取得する
     * @return String 設定局コードフラグ
     */
    public String getSTKYKNOFLG() {
        return (String) get(Tbj11CrCreateData.STKYKNOFLG);
    }

    /**
     * 設定局コードフラグを設定する
     * @param val String 設定局コードフラグ
     */
    public void setSTKYKNOFLG(String val) {
        set(Tbj11CrCreateData.STKYKNOFLG, val);
    }

    /**
     * 営直チェックフラグを取得する
     * @return String 営直チェックフラグ
     */
    public String getEGTYKFLGFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLGFLG);
    }

    /**
     * 営直チェックフラグを設定する
     * @param val String 営直チェックフラグ
     */
    public void setEGTYKFLGFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLGFLG, val);
    }

    /**
     * 入力担当コードフラグを取得する
     * @return String 入力担当コードフラグ
     */
    public String getINPUTTNTCDFLG() {
        return (String) get(Tbj11CrCreateData.INPUTTNTCDFLG);
    }

    /**
     * 入力担当コードフラグを設定する
     * @param val String 入力担当コードフラグ
     */
    public void setINPUTTNTCDFLG(String val) {
        set(Tbj11CrCreateData.INPUTTNTCDFLG, val);
    }

    /**
     * CP担当者フラグを取得する
     * @return String CP担当者フラグ
     */
    public String getCPTNTNMFLG() {
        return (String) get(Tbj11CrCreateData.CPTNTNMFLG);
    }

    /**
     * CP担当者フラグを設定する
     * @param val String CP担当者フラグ
     */
    public void setCPTNTNMFLG(String val) {
        set(Tbj11CrCreateData.CPTNTNMFLG, val);
    }

    /**
     * 備考フラグを取得する
     * @return String 備考フラグ
     */
    public String getNOTEFLG() {
        return (String) get(Tbj11CrCreateData.NOTEFLG);
    }

    /**
     * 備考フラグを設定する
     * @param val String 備考フラグ
     */
    public void setNOTEFLG(String val) {
        set(Tbj11CrCreateData.NOTEFLG, val);
    }

    /**
     * 電通車種コード確認フラグを取得する
     * @return String 電通車種コード確認フラグ
     */
    public String getDCARCDCONFFLG() {
        return (String) get(Tbj11CrCreateData.DCARCDCONFFLG);
    }

    /**
     * 電通車種コード確認フラグを設定する
     * @param val String 電通車種コード確認フラグ
     */
    public void setDCARCDCONFFLG(String val) {
        set(Tbj11CrCreateData.DCARCDCONFFLG, val);
    }

    /**
     * 電通車種コード確認組織コードを取得する
     * @return String 電通車種コード確認組織コード
     */
    public String getDCARCDCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.DCARCDCONFSIKCD);
    }

    /**
     * 電通車種コード確認組織コードを設定する
     * @param val String 電通車種コード確認組織コード
     */
    public void setDCARCDCONFSIKCD(String val) {
        set(Tbj11CrCreateData.DCARCDCONFSIKCD, val);
    }

    /**
     * 電通車種コード確認担当者コードを取得する
     * @return String 電通車種コード確認担当者コード
     */
    public String getDCARCDCONFHAMID() {
        return (String) get(Tbj11CrCreateData.DCARCDCONFHAMID);
    }

    /**
     * 電通車種コード確認担当者コードを設定する
     * @param val String 電通車種コード確認担当者コード
     */
    public void setDCARCDCONFHAMID(String val) {
        set(Tbj11CrCreateData.DCARCDCONFHAMID, val);
    }

    /**
     * 予算表分類確認フラグを取得する
     * @return String 予算表分類確認フラグ
     */
    public String getCLASSCDCONFFLG() {
        return (String) get(Tbj11CrCreateData.CLASSCDCONFFLG);
    }

    /**
     * 予算表分類確認フラグを設定する
     * @param val String 予算表分類確認フラグ
     */
    public void setCLASSCDCONFFLG(String val) {
        set(Tbj11CrCreateData.CLASSCDCONFFLG, val);
    }

    /**
     * 予算表分類確認組織コードを取得する
     * @return String 予算表分類確認組織コード
     */
    public String getCLASSCDCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.CLASSCDCONFSIKCD);
    }

    /**
     * 予算表分類確認組織コードを設定する
     * @param val String 予算表分類確認組織コード
     */
    public void setCLASSCDCONFSIKCD(String val) {
        set(Tbj11CrCreateData.CLASSCDCONFSIKCD, val);
    }

    /**
     * 予算表分類確認担当者コードを取得する
     * @return String 予算表分類確認担当者コード
     */
    public String getCLASSCDCONFHAMID() {
        return (String) get(Tbj11CrCreateData.CLASSCDCONFHAMID);
    }

    /**
     * 予算表分類確認担当者コードを設定する
     * @param val String 予算表分類確認担当者コード
     */
    public void setCLASSCDCONFHAMID(String val) {
        set(Tbj11CrCreateData.CLASSCDCONFHAMID, val);
    }

    /**
     * 予算表費目確認フラグを取得する
     * @return String 予算表費目確認フラグ
     */
    public String getEXPCDCONFFLG() {
        return (String) get(Tbj11CrCreateData.EXPCDCONFFLG);
    }

    /**
     * 予算表費目確認フラグを設定する
     * @param val String 予算表費目確認フラグ
     */
    public void setEXPCDCONFFLG(String val) {
        set(Tbj11CrCreateData.EXPCDCONFFLG, val);
    }

    /**
     * 予算表費目確認組織コードを取得する
     * @return String 予算表費目確認組織コード
     */
    public String getEXPCDCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.EXPCDCONFSIKCD);
    }

    /**
     * 予算表費目確認組織コードを設定する
     * @param val String 予算表費目確認組織コード
     */
    public void setEXPCDCONFSIKCD(String val) {
        set(Tbj11CrCreateData.EXPCDCONFSIKCD, val);
    }

    /**
     * 予算表費目確認担当者コードを取得する
     * @return String 予算表費目確認担当者コード
     */
    public String getEXPCDCONFHAMID() {
        return (String) get(Tbj11CrCreateData.EXPCDCONFHAMID);
    }

    /**
     * 予算表費目確認担当者コードを設定する
     * @param val String 予算表費目確認担当者コード
     */
    public void setEXPCDCONFHAMID(String val) {
        set(Tbj11CrCreateData.EXPCDCONFHAMID, val);
    }

    /**
     * 費目確認フラグを取得する
     * @return String 費目確認フラグ
     */
    public String getEXPENSECONFFLG() {
        return (String) get(Tbj11CrCreateData.EXPENSECONFFLG);
    }

    /**
     * 費目確認フラグを設定する
     * @param val String 費目確認フラグ
     */
    public void setEXPENSECONFFLG(String val) {
        set(Tbj11CrCreateData.EXPENSECONFFLG, val);
    }

    /**
     * 費目確認組織コードを取得する
     * @return String 費目確認組織コード
     */
    public String getEXPENSECONFSIKCD() {
        return (String) get(Tbj11CrCreateData.EXPENSECONFSIKCD);
    }

    /**
     * 費目確認組織コードを設定する
     * @param val String 費目確認組織コード
     */
    public void setEXPENSECONFSIKCD(String val) {
        set(Tbj11CrCreateData.EXPENSECONFSIKCD, val);
    }

    /**
     * 費目確認担当者コードを取得する
     * @return String 費目確認担当者コード
     */
    public String getEXPENSECONFHAMID() {
        return (String) get(Tbj11CrCreateData.EXPENSECONFHAMID);
    }

    /**
     * 費目確認担当者コードを設定する
     * @param val String 費目確認担当者コード
     */
    public void setEXPENSECONFHAMID(String val) {
        set(Tbj11CrCreateData.EXPENSECONFHAMID, val);
    }

    /**
     * 詳細確認フラグを取得する
     * @return String 詳細確認フラグ
     */
    public String getDETAILCONFFLG() {
        return (String) get(Tbj11CrCreateData.DETAILCONFFLG);
    }

    /**
     * 詳細確認フラグを設定する
     * @param val String 詳細確認フラグ
     */
    public void setDETAILCONFFLG(String val) {
        set(Tbj11CrCreateData.DETAILCONFFLG, val);
    }

    /**
     * 詳細確認組織コードを取得する
     * @return String 詳細確認組織コード
     */
    public String getDETAILCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.DETAILCONFSIKCD);
    }

    /**
     * 詳細確認組織コードを設定する
     * @param val String 詳細確認組織コード
     */
    public void setDETAILCONFSIKCD(String val) {
        set(Tbj11CrCreateData.DETAILCONFSIKCD, val);
    }

    /**
     * 詳細確認担当者コードを取得する
     * @return String 詳細確認担当者コード
     */
    public String getDETAILCONFHAMID() {
        return (String) get(Tbj11CrCreateData.DETAILCONFHAMID);
    }

    /**
     * 詳細確認担当者コードを設定する
     * @param val String 詳細確認担当者コード
     */
    public void setDETAILCONFHAMID(String val) {
        set(Tbj11CrCreateData.DETAILCONFHAMID, val);
    }

    /**
     * 期間開始確認フラグを取得する
     * @return String 期間開始確認フラグ
     */
    public String getKIKANSCONFFLG() {
        return (String) get(Tbj11CrCreateData.KIKANSCONFFLG);
    }

    /**
     * 期間開始確認フラグを設定する
     * @param val String 期間開始確認フラグ
     */
    public void setKIKANSCONFFLG(String val) {
        set(Tbj11CrCreateData.KIKANSCONFFLG, val);
    }

    /**
     * 期間開始確認組織コードを取得する
     * @return String 期間開始確認組織コード
     */
    public String getKIKANSCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.KIKANSCONFSIKCD);
    }

    /**
     * 期間開始確認組織コードを設定する
     * @param val String 期間開始確認組織コード
     */
    public void setKIKANSCONFSIKCD(String val) {
        set(Tbj11CrCreateData.KIKANSCONFSIKCD, val);
    }

    /**
     * 期間開始確認担当者コードを取得する
     * @return String 期間開始確認担当者コード
     */
    public String getKIKANSCONFHAMID() {
        return (String) get(Tbj11CrCreateData.KIKANSCONFHAMID);
    }

    /**
     * 期間開始確認担当者コードを設定する
     * @param val String 期間開始確認担当者コード
     */
    public void setKIKANSCONFHAMID(String val) {
        set(Tbj11CrCreateData.KIKANSCONFHAMID, val);
    }

    /**
     * 期間終了確認フラグを取得する
     * @return String 期間終了確認フラグ
     */
    public String getKIKANECONFFLG() {
        return (String) get(Tbj11CrCreateData.KIKANECONFFLG);
    }

    /**
     * 期間終了確認フラグを設定する
     * @param val String 期間終了確認フラグ
     */
    public void setKIKANECONFFLG(String val) {
        set(Tbj11CrCreateData.KIKANECONFFLG, val);
    }

    /**
     * 期間終了確認組織コードを取得する
     * @return String 期間終了確認組織コード
     */
    public String getKIKANECONFSIKCD() {
        return (String) get(Tbj11CrCreateData.KIKANECONFSIKCD);
    }

    /**
     * 期間終了確認組織コードを設定する
     * @param val String 期間終了確認組織コード
     */
    public void setKIKANECONFSIKCD(String val) {
        set(Tbj11CrCreateData.KIKANECONFSIKCD, val);
    }

    /**
     * 期間終了確認担当者コードを取得する
     * @return String 期間終了確認担当者コード
     */
    public String getKIKANECONFHAMID() {
        return (String) get(Tbj11CrCreateData.KIKANECONFHAMID);
    }

    /**
     * 期間終了確認担当者コードを設定する
     * @param val String 期間終了確認担当者コード
     */
    public void setKIKANECONFHAMID(String val) {
        set(Tbj11CrCreateData.KIKANECONFHAMID, val);
    }

    /**
     * 契約開始年月日確認フラグを取得する
     * @return String 契約開始年月日確認フラグ
     */
    public String getCONTRACTDATECONFFLG() {
        return (String) get(Tbj11CrCreateData.CONTRACTDATECONFFLG);
    }

    /**
     * 契約開始年月日確認フラグを設定する
     * @param val String 契約開始年月日確認フラグ
     */
    public void setCONTRACTDATECONFFLG(String val) {
        set(Tbj11CrCreateData.CONTRACTDATECONFFLG, val);
    }

    /**
     * 契約開始年月日確認組織コードを取得する
     * @return String 契約開始年月日確認組織コード
     */
    public String getCONTRACTDATECONFSIKCD() {
        return (String) get(Tbj11CrCreateData.CONTRACTDATECONFSIKCD);
    }

    /**
     * 契約開始年月日確認組織コードを設定する
     * @param val String 契約開始年月日確認組織コード
     */
    public void setCONTRACTDATECONFSIKCD(String val) {
        set(Tbj11CrCreateData.CONTRACTDATECONFSIKCD, val);
    }

    /**
     * 契約開始年月日確認担当者コードを取得する
     * @return String 契約開始年月日確認担当者コード
     */
    public String getCONTRACTDATECONFHAMID() {
        return (String) get(Tbj11CrCreateData.CONTRACTDATECONFHAMID);
    }

    /**
     * 契約開始年月日確認担当者コードを設定する
     * @param val String 契約開始年月日確認担当者コード
     */
    public void setCONTRACTDATECONFHAMID(String val) {
        set(Tbj11CrCreateData.CONTRACTDATECONFHAMID, val);
    }

    /**
     * 契約期間(ヶ月)確認フラグを取得する
     * @return String 契約期間(ヶ月)確認フラグ
     */
    public String getCONTRACTTERMCONFFLG() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERMCONFFLG);
    }

    /**
     * 契約期間(ヶ月)確認フラグを設定する
     * @param val String 契約期間(ヶ月)確認フラグ
     */
    public void setCONTRACTTERMCONFFLG(String val) {
        set(Tbj11CrCreateData.CONTRACTTERMCONFFLG, val);
    }

    /**
     * 契約期間(ヶ月)確認組織コードを取得する
     * @return String 契約期間(ヶ月)確認組織コード
     */
    public String getCONTRACTTERMCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERMCONFSIKCD);
    }

    /**
     * 契約期間(ヶ月)確認組織コードを設定する
     * @param val String 契約期間(ヶ月)確認組織コード
     */
    public void setCONTRACTTERMCONFSIKCD(String val) {
        set(Tbj11CrCreateData.CONTRACTTERMCONFSIKCD, val);
    }

    /**
     * 契約期間(ヶ月)確認担当者コードを取得する
     * @return String 契約期間(ヶ月)確認担当者コード
     */
    public String getCONTRACTTERMCONFHAMID() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERMCONFHAMID);
    }

    /**
     * 契約期間(ヶ月)確認担当者コードを設定する
     *
     * @param val 契約期間(ヶ月)確認担当者コード
     */
    public void setCONTRACTTERMCONFHAMID(String val) {
        set(Tbj11CrCreateData.CONTRACTTERMCONFHAMID, val);
    }

    /**
     * 請求先確認フラグを取得する
     * @return String 請求先確認フラグ
     */
    public String getSEIKYUCONFFLG() {
        return (String) get(Tbj11CrCreateData.SEIKYUCONFFLG);
    }

    /**
     * 請求先確認フラグを設定する
     * @param val String 請求先確認フラグ
     */
    public void setSEIKYUCONFFLG(String val) {
        set(Tbj11CrCreateData.SEIKYUCONFFLG, val);
    }

    /**
     * 請求先確認組織コードを取得する
     * @return String 請求先確認組織コード
     */
    public String getSEIKYUCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.SEIKYUCONFSIKCD);
    }

    /**
     * 請求先確認組織コードを設定する
     * @param val String 請求先確認組織コード
     */
    public void setSEIKYUCONFSIKCD(String val) {
        set(Tbj11CrCreateData.SEIKYUCONFSIKCD, val);
    }

    /**
     * 請求先確認担当者コードを取得する
     * @return String 請求先確認担当者コード
     */
    public String getSEIKYUCONFHAMID() {
        return (String) get(Tbj11CrCreateData.SEIKYUCONFHAMID);
    }

    /**
     * 請求先確認担当者コードを設定する
     * @param val String 請求先確認担当者コード
     */
    public void setSEIKYUCONFHAMID(String val) {
        set(Tbj11CrCreateData.SEIKYUCONFHAMID, val);
    }

    /**
     * 受注NO確認フラグを取得する
     * @return String 受注NO確認フラグ
     */
    public String getORDERNOCONFFLG() {
        return (String) get(Tbj11CrCreateData.ORDERNOCONFFLG);
    }

    /**
     * 受注NO確認フラグを設定する
     * @param val String 受注NO確認フラグ
     */
    public void setORDERNOCONFFLG(String val) {
        set(Tbj11CrCreateData.ORDERNOCONFFLG, val);
    }

    /**
     * 受注NO確認組織コードを取得する
     * @return String 受注NO確認組織コード
     */
    public String getORDERNOCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.ORDERNOCONFSIKCD);
    }

    /**
     * 受注NO確認組織コードを設定する
     * @param val String 受注NO確認組織コード
     */
    public void setORDERNOCONFSIKCD(String val) {
        set(Tbj11CrCreateData.ORDERNOCONFSIKCD, val);
    }

    /**
     * 受注NO確認担当者コードを取得する
     * @return String 受注NO確認担当者コード
     */
    public String getORDERNOCONFHAMID() {
        return (String) get(Tbj11CrCreateData.ORDERNOCONFHAMID);
    }

    /**
     * 受注NO確認担当者コードを設定する
     * @param val String 受注NO確認担当者コード
     */
    public void setORDERNOCONFHAMID(String val) {
        set(Tbj11CrCreateData.ORDERNOCONFHAMID, val);
    }

    /**
     * 支払先確認フラグを取得する
     * @return String 支払先確認フラグ
     */
    public String getPAYCONFFLG() {
        return (String) get(Tbj11CrCreateData.PAYCONFFLG);
    }

    /**
     * 支払先確認フラグを設定する
     * @param val String 支払先確認フラグ
     */
    public void setPAYCONFFLG(String val) {
        set(Tbj11CrCreateData.PAYCONFFLG, val);
    }

    /**
     * 支払先確認組織コードを取得する
     * @return String 支払先確認組織コード
     */
    public String getPAYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.PAYCONFSIKCD);
    }

    /**
     * 支払先確認組織コードを設定する
     * @param val String 支払先確認組織コード
     */
    public void setPAYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.PAYCONFSIKCD, val);
    }

    /**
     * 支払先確認担当者コードを取得する
     * @return String 支払先確認担当者コード
     */
    public String getPAYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.PAYCONFHAMID);
    }

    /**
     * 支払先確認担当者コードを設定する
     * @param val String 支払先確認担当者コード
     */
    public void setPAYCONFHAMID(String val) {
        set(Tbj11CrCreateData.PAYCONFHAMID, val);
    }

    /**
     * 担当者確認フラグを取得する
     * @return String 担当者確認フラグ
     */
    public String getUSERNAMECONFFLG() {
        return (String) get(Tbj11CrCreateData.USERNAMECONFFLG);
    }

    /**
     * 担当者確認フラグを設定する
     * @param val String 担当者確認フラグ
     */
    public void setUSERNAMECONFFLG(String val) {
        set(Tbj11CrCreateData.USERNAMECONFFLG, val);
    }

    /**
     * 担当者確認組織コードを取得する
     * @return String 担当者確認組織コード
     */
    public String getUSERNAMECONFSIKCD() {
        return (String) get(Tbj11CrCreateData.USERNAMECONFSIKCD);
    }

    /**
     * 担当者確認組織コードを設定する
     * @param val String 担当者確認組織コード
     */
    public void setUSERNAMECONFSIKCD(String val) {
        set(Tbj11CrCreateData.USERNAMECONFSIKCD, val);
    }

    /**
     * 担当者確認担当者コードを取得する
     * @return String 担当者確認担当者コード
     */
    public String getUSERNAMECONFHAMID() {
        return (String) get(Tbj11CrCreateData.USERNAMECONFHAMID);
    }

    /**
     * 担当者確認担当者コードを設定する
     * @param val String 担当者確認担当者コード
     */
    public void setUSERNAMECONFHAMID(String val) {
        set(Tbj11CrCreateData.USERNAMECONFHAMID, val);
    }

    /**
     * 取り金額確認フラグを取得する
     * @return String 取り金額確認フラグ
     */
    public String getGETMONEYCONFFLG() {
        return (String) get(Tbj11CrCreateData.GETMONEYCONFFLG);
    }

    /**
     * 取り金額確認フラグを設定する
     * @param val String取り金額確認フラグ
     */
    public void setGETMONEYCONFFLG(String val) {
        set(Tbj11CrCreateData.GETMONEYCONFFLG, val);
    }

    /**
     * 取り金額確認組織コードを取得する
     * @return String取り金額確認組織コード
     */
    public String getGETMONEYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.GETMONEYCONFSIKCD);
    }

    /**
     * 取り金額確認組織コードを設定する
     * @param val String取り金額確認組織コード
     */
    public void setGETMONEYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.GETMONEYCONFSIKCD, val);
    }

    /**
     * 取り金額確認担当者コードを取得する
     * @return String取り金額確認担当者コード
     */
    public String getGETMONEYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.GETMONEYCONFHAMID);
    }

    /**
     * 取り金額確認担当者コードを設定する
     * @param val String取り金額確認担当者コード
     */
    public void setGETMONEYCONFHAMID(String val) {
        set(Tbj11CrCreateData.GETMONEYCONFHAMID, val);
    }

    /**
     * 取り金額確認確認フラグを取得する
     * @return String取り金額確認確認フラグ
     */
    public String getGETCONFCONFFLG() {
        return (String) get(Tbj11CrCreateData.GETCONFCONFFLG);
    }

    /**
     * 取り金額確認確認フラグを設定する
     * @param val String取り金額確認確認フラグ
     */
    public void setGETCONFCONFFLG(String val) {
        set(Tbj11CrCreateData.GETCONFCONFFLG, val);
    }

    /**
     * 取り金額確認確認組織コードを取得する
     * @return String 取り金額確認確認組織コード
     */
    public String getGETCONFCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.GETCONFCONFSIKCD);
    }

    /**
     * 取り金額確認確認組織コードを設定する
     * @param val String取り金額確認確認組織コード
     */
    public void setGETCONFCONFSIKCD(String val) {
        set(Tbj11CrCreateData.GETCONFCONFSIKCD, val);
    }

    /**
     * 取り金額確認確認担当者コードを取得する
     * @return String 取り金額確認確認担当者コード
     */
    public String getGETCONFCONFHAMID() {
        return (String) get(Tbj11CrCreateData.GETCONFCONFHAMID);
    }

    /**
     * 取り金額確認確認担当者コードを設定する
     * @param val String取り金額確認確認担当者コード
     */
    public void setGETCONFCONFHAMID(String val) {
        set(Tbj11CrCreateData.GETCONFCONFHAMID, val);
    }

    /**
     * 払い金額確認フラグを取得する
     * @return String払い金額確認フラグ
     */
    public String getPAYMONEYCONFFLG() {
        return (String) get(Tbj11CrCreateData.PAYMONEYCONFFLG);
    }

    /**
     * 払い金額確認フラグを設定する
     * @param val String払い金額確認フラグ
     */
    public void setPAYMONEYCONFFLG(String val) {
        set(Tbj11CrCreateData.PAYMONEYCONFFLG, val);
    }

    /**
     * 払い金額確認組織コードを取得する
     * @return String払い金額確認組織コード
     */
    public String getPAYMONEYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.PAYMONEYCONFSIKCD);
    }

    /**
     * 払い金額確認組織コードを設定する
     * @param val String払い金額確認組織コード
     */
    public void setPAYMONEYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.PAYMONEYCONFSIKCD, val);
    }

    /**
     * 払い金額確認担当者コードを取得する
     * @return String払い金額確認担当者コード
     */
    public String getPAYMONEYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.PAYMONEYCONFHAMID);
    }

    /**
     * 払い金額確認担当者コードを設定する
     * @param val String 払い金額確認担当者コード
     */
    public void setPAYMONEYCONFHAMID(String val) {
        set(Tbj11CrCreateData.PAYMONEYCONFHAMID, val);
    }

    /**
     * 払い金額確認確認フラグを取得する
     * @return String 払い金額確認確認フラグ
     */
    public String getPAYCONFCONFFLG() {
        return (String) get(Tbj11CrCreateData.PAYCONFCONFFLG);
    }

    /**
     * 払い金額確認確認フラグを設定する
     * @param val String 払い金額確認確認フラグ
     */
    public void setPAYCONFCONFFLG(String val) {
        set(Tbj11CrCreateData.PAYCONFCONFFLG, val);
    }

    /**
     * 払い金額確認確認組織コードを取得する
     * @return String払い金額確認確認組織コード
     */
    public String getPAYCONFCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.PAYCONFCONFSIKCD);
    }

    /**
     * 払い金額確認確認組織コードを設定する
     * @param val String 払い金額確認確認組織コード
     */
    public void setPAYCONFCONFSIKCD(String val) {
        set(Tbj11CrCreateData.PAYCONFCONFSIKCD, val);
    }

    /**
     * 払い金額確認確認担当者コードを取得する
     * @return String払い金額確認確認担当者コード
     */
    public String getPAYCONFCONFHAMID() {
        return (String) get(Tbj11CrCreateData.PAYCONFCONFHAMID);
    }

    /**
     * 払い金額確認確認担当者コードを設定する
     * @param val String 払い金額確認確認担当者コード
     */
    public void setPAYCONFCONFHAMID(String val) {
        set(Tbj11CrCreateData.PAYCONFCONFHAMID, val);
    }

    /**
     * 見積金額確認フラグを取得する
     * @return String 見積金額確認フラグ
     */
    public String getESTMONEYCONFFLG() {
        return (String) get(Tbj11CrCreateData.ESTMONEYCONFFLG);
    }

    /**
     * 見積金額確認フラグを設定する
     * @param val String 見積金額確認フラグ
     */
    public void setESTMONEYCONFFLG(String val) {
        set(Tbj11CrCreateData.ESTMONEYCONFFLG, val);
    }

    /**
     * 見積金額確認組織コードを取得する
     * @return String 見積金額確認組織コード
     */
    public String getESTMONEYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.ESTMONEYCONFSIKCD);
    }

    /**
     * 見積金額確認組織コードを設定する
     * @param val String 見積金額確認組織コード
     */
    public void setESTMONEYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.ESTMONEYCONFSIKCD, val);
    }

    /**
     * 見積金額確認担当者コードを取得する
     * @return String 見積金額確認担当者コード
     */
    public String getESTMONEYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.ESTMONEYCONFHAMID);
    }

    /**
     * 見積金額確認担当者コードを設定する
     * @param val String 見積金額確認担当者コード
     */
    public void setESTMONEYCONFHAMID(String val) {
        set(Tbj11CrCreateData.ESTMONEYCONFHAMID, val);
    }

    /**
     * 請求金額確認フラグを取得する
     * @return String 請求金額確認フラグ
     */
    public String getCLMMONEYCONFFLG() {
        return (String) get(Tbj11CrCreateData.CLMMONEYCONFFLG);
    }

    /**
     * 請求金額確認フラグを設定する
     * @param val String 請求金額確認フラグ
     */
    public void setCLMMONEYCONFFLG(String val) {
        set(Tbj11CrCreateData.CLMMONEYCONFFLG, val);
    }

    /**
     * 請求金額確認組織コードを取得する
     * @return String 請求金額確認組織コード
     */
    public String getCLMMONEYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.CLMMONEYCONFSIKCD);
    }

    /**
     * 請求金額確認組織コードを設定する
     * @param val String 請求金額確認組織コード
     */
    public void setCLMMONEYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.CLMMONEYCONFSIKCD, val);
    }

    /**
     * 請求金額確認担当者コードを取得する
     * @return String 請求金額確認担当者コード
     */
    public String getCLMMONEYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.CLMMONEYCONFHAMID);
    }

    /**
     * 請求金額確認担当者コードを設定する
     * @param val String 請求金額確認担当者コード
     */
    public void setCLMMONEYCONFHAMID(String val) {
        set(Tbj11CrCreateData.CLMMONEYCONFHAMID, val);
    }

    /**
     * 支払先納品日確認フラグを取得する
     * @return String 支払先納品日確認フラグ
     */
    public String getDELIVERDAYCONFFLG() {
        return (String) get(Tbj11CrCreateData.DELIVERDAYCONFFLG);
    }

    /**
     * 支払先納品日確認フラグを設定する
     * @param val String 支払先納品日確認フラグ
     */
    public void setDELIVERDAYCONFFLG(String val) {
        set(Tbj11CrCreateData.DELIVERDAYCONFFLG, val);
    }

    /**
     * 支払先納品日確認組織コードを取得する
     * @return String 支払先納品日確認組織コード
     */
    public String getDELIVERDAYCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.DELIVERDAYCONFSIKCD);
    }

    /**
     * 支払先納品日確認組織コードを設定する
     * @param val String 支払先納品日確認組織コード
     */
    public void setDELIVERDAYCONFSIKCD(String val) {
        set(Tbj11CrCreateData.DELIVERDAYCONFSIKCD, val);
    }

    /**
     * 支払先納品日確認担当者コードを取得する
     * @return String 支払先納品日確認担当者コード
     */
    public String getDELIVERDAYCONFHAMID() {
        return (String) get(Tbj11CrCreateData.DELIVERDAYCONFHAMID);
    }

    /**
     * 支払先納品日確認担当者コードを設定する
     * @param val String 支払先納品日確認担当者コード
     */
    public void setDELIVERDAYCONFHAMID(String val) {
        set(Tbj11CrCreateData.DELIVERDAYCONFHAMID, val);
    }

    /**
     * 設定月確認フラグを取得する
     * @return String 設定月確認フラグ
     */
    public String getSETMONTHCONFFLG() {
        return (String) get(Tbj11CrCreateData.SETMONTHCONFFLG);
    }

    /**
     * 設定月確認フラグを設定する
     * @param val String 設定月確認フラグ
     */
    public void setSETMONTHCONFFLG(String val) {
        set(Tbj11CrCreateData.SETMONTHCONFFLG, val);
    }

    /**
     * 設定月確認組織コードを取得する
     * @return String 設定月確認組織コード
     */
    public String getSETMONTHCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.SETMONTHCONFSIKCD);
    }

    /**
     * 設定月確認組織コードを設定する
     * @param val 設定月確認組織コード
     */
    public void setSETMONTHCONFSIKCD(String val) {
        set(Tbj11CrCreateData.SETMONTHCONFSIKCD, val);
    }

    /**
     * 設定月確認担当者コードを取得する
     * @return String 設定月確認担当者コード
     */
    public String getSETMONTHCONFHAMID() {
        return (String) get(Tbj11CrCreateData.SETMONTHCONFHAMID);
    }

    /**
     * 設定月確認担当者コードを設定する
     * @param val String 設定月確認担当者コード
     */
    public void setSETMONTHCONFHAMID(String val) {
        set(Tbj11CrCreateData.SETMONTHCONFHAMID, val);
    }

    /**
     * 区分コード確認フラグを取得する
     * @return String 区分コード確認フラグ
     */
    public String getDIVISIONCONFFLG() {
        return (String) get(Tbj11CrCreateData.DIVISIONCONFFLG);
    }

    /**
     * 区分コード確認フラグを設定する
     * @param val String 区分コード確認フラグ
     */
    public void setDIVISIONCONFFLG(String val) {
        set(Tbj11CrCreateData.DIVISIONCONFFLG, val);
    }

    /**
     * 区分コード確認組織コードを取得する
     * @return String 区分コード確認組織コード
     */
    public String getDIVISIONCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.DIVISIONCONFSIKCD);
    }

    /**
     * 区分コード確認組織コードを設定する
     * @param val String 区分コード確認組織コード
     */
    public void setDIVISIONCONFSIKCD(String val) {
        set(Tbj11CrCreateData.DIVISIONCONFSIKCD, val);
    }

    /**
     * 区分コード確認担当者コードを取得する
     * @return String 区分コード確認担当者コード
     */
    public String getDIVISIONCONFHAMID() {
        return (String) get(Tbj11CrCreateData.DIVISIONCONFHAMID);
    }

    /**
     * 区分コード確認担当者コードを設定する
     * @param val String 区分コード確認担当者コード
     */
    public void setDIVISIONCONFHAMID(String val) {
        set(Tbj11CrCreateData.DIVISIONCONFHAMID, val);
    }

    /**
     * グループコード確認フラグを取得する
     * @return String グループコード確認フラグ
     */
    public String getGROUPCDCONFFLG() {
        return (String) get(Tbj11CrCreateData.GROUPCDCONFFLG);
    }

    /**
     * グループコード確認フラグを設定する
     * @param val String グループコード確認フラグ
     */
    public void setGROUPCDCONFFLG(String val) {
        set(Tbj11CrCreateData.GROUPCDCONFFLG, val);
    }

    /**
     * グループコード確認組織コードを取得する
     * @return String グループコード確認組織コード
     */
    public String getGROUPCDCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.GROUPCDCONFSIKCD);
    }

    /**
     * グループコード確認組織コードを設定する
     * @param val String グループコード確認組織コード
     */
    public void setGROUPCDCONFSIKCD(String val) {
        set(Tbj11CrCreateData.GROUPCDCONFSIKCD, val);
    }

    /**
     * グループコード確認担当者コードを取得する
     * @return String グループコード確認担当者コード
     */
    public String getGROUPCDCONFHAMID() {
        return (String) get(Tbj11CrCreateData.GROUPCDCONFHAMID);
    }

    /**
     * グループコード確認担当者コードを設定する
     * @param val String グループコード確認担当者コード
     */
    public void setGROUPCDCONFHAMID(String val) {
        set(Tbj11CrCreateData.GROUPCDCONFHAMID, val);
    }

    /**
     * 設定局ナンバー確認フラグを取得する
     * @return String 設定局ナンバー確認フラグ
     */
    public String getSTKYKNOCONFFLG() {
        return (String) get(Tbj11CrCreateData.STKYKNOCONFFLG);
    }

    /**
     * 設定局ナンバー確認フラグを設定する
     * @param val String 設定局ナンバー確認フラグ
     */
    public void setSTKYKNOCONFFLG(String val) {
        set(Tbj11CrCreateData.STKYKNOCONFFLG, val);
    }

    /**
     * 設定局ナンバー確認組織コードを取得する
     * @return 設定局ナンバー確認組織コード
     */
    public String getSTKYKNOCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.STKYKNOCONFSIKCD);
    }

    /**
     * 設定局ナンバー確認組織コードを設定する
     * @param val String 設定局ナンバー確認組織コード
     */
    public void setSTKYKNOCONFSIKCD(String val) {
        set(Tbj11CrCreateData.STKYKNOCONFSIKCD, val);
    }

    /**
     * 設定局ナンバー確認担当者コードを取得する
     * @return String 設定局ナンバー確認担当者コード
     */
    public String getSTKYKNOCONFHAMID() {
        return (String) get(Tbj11CrCreateData.STKYKNOCONFHAMID);
    }

    /**
     * 設定局ナンバー確認担当者コードを設定する
     * @param val String 設定局ナンバー確認担当者コード
     */
    public void setSTKYKNOCONFHAMID(String val) {
        set(Tbj11CrCreateData.STKYKNOCONFHAMID, val);
    }

    /**
     * 営直チェック確認フラグを取得する
     * @return String 営直チェック確認フラグ
     */
    public String getEGTYKCONFFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKCONFFLG);
    }

    /**
     * 営直チェック確認フラグを設定する
     * @param val 営直チェック確認フラグ
     */
    public void setEGTYKCONFFLG(String val) {
        set(Tbj11CrCreateData.EGTYKCONFFLG, val);
    }

    /**
     * 営直チェック確認組織コードを取得する
     * @return String 営直チェック確認組織コード
     */
    public String getEGTYKCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.EGTYKCONFSIKCD);
    }

    /**
     * 営直チェック確認組織コードを設定する
     * @param val String 営直チェック確認組織コード
     */
    public void setEGTYKCONFSIKCD(String val) {
        set(Tbj11CrCreateData.EGTYKCONFSIKCD, val);
    }

    /**
     * 営直チェック確認担当者コードを取得する
     * @return String 営直チェック確認担当者コード
     */
    public String getEGTYKCONFHAMID() {
        return (String) get(Tbj11CrCreateData.EGTYKCONFHAMID);
    }

    /**
     * 営直チェック確認担当者コードを設定する
     * @param val String 営直チェック確認担当者コード
     */
    public void setEGTYKCONFHAMID(String val) {
        set(Tbj11CrCreateData.EGTYKCONFHAMID, val);
    }

    /**
     * 入力担当コード確認フラグを取得する
     * @return String 入力担当コード確認フラグ
     */
    public String getINPUTTNTCDCONFFLG() {
        return (String) get(Tbj11CrCreateData.INPUTTNTCDCONFFLG);
    }

    /**
     * 入力担当コード確認フラグを設定する
     * @param val String 入力担当コード確認フラグ
     */
    public void setINPUTTNTCDCONFFLG(String val) {
        set(Tbj11CrCreateData.INPUTTNTCDCONFFLG, val);
    }

    /**
     * 入力担当コード確認組織コードを取得する
     * @return String 入力担当コード確認組織コード
     */
    public String getINPUTTNTCDCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.INPUTTNTCDCONFSIKCD);
    }

    /**
     * 入力担当コード確認組織コードを設定する
     * @param val String 入力担当コード確認組織コード
     */
    public void setINPUTTNTCDCONFSIKCD(String val) {
        set(Tbj11CrCreateData.INPUTTNTCDCONFSIKCD, val);
    }

    /**
     * 入力担当コード確認担当者コードを取得する
     * @return String 入力担当コード確認担当者コード
     */
    public String getINPUTTNTCDCONFHAMID() {
        return (String) get(Tbj11CrCreateData.INPUTTNTCDCONFHAMID);
    }

    /**
     * 入力担当コード確認担当者コードを設定する
     * @param val String 入力担当コード確認担当者コード
     */
    public void setINPUTTNTCDCONFHAMID(String val) {
        set(Tbj11CrCreateData.INPUTTNTCDCONFHAMID, val);
    }

    /**
     * CP担当者確認フラグを取得する
     * @return String CP担当者確認フラグ
     */
    public String getCPTNTNMCONFFLG() {
        return (String) get(Tbj11CrCreateData.CPTNTNMCONFFLG);
    }

    /**
     * CP担当者確認フラグを設定する
     * @param val String CP担当者確認フラグ
     */
    public void setCPTNTNMCONFFLG(String val) {
        set(Tbj11CrCreateData.CPTNTNMCONFFLG, val);
    }

    /**
     * CP担当者確認組織コードを取得する
     * @return String CP担当者確認組織コード
     */
    public String getCPTNTNMCONFSIKCD() {
        return (String) get(Tbj11CrCreateData.CPTNTNMCONFSIKCD);
    }

    /**
     * CP担当者確認組織コードを設定する
     * @param val String CP担当者確認組織コード
     */
    public void setCPTNTNMCONFSIKCD(String val) {
        set(Tbj11CrCreateData.CPTNTNMCONFSIKCD, val);
    }

    /**
     * CP担当者確認担当者コードを取得する
     * @return String CP担当者確認担当者コード
     */
    public String getCPTNTNMCONFHAMID() {
        return (String) get(Tbj11CrCreateData.CPTNTNMCONFHAMID);
    }

    /**
     * CP担当者確認担当者コードを設定する
     * @param val String CP担当者確認担当者コード
     */
    public void setCPTNTNMCONFHAMID(String val) {
        set(Tbj11CrCreateData.CPTNTNMCONFHAMID, val);
    }

    /**
     * 備考確認フラグを取得する
     * @return String 備考確認フラグ
     */
    public String getNOTECONFFLG() {
        return (String) get(Tbj11CrCreateData.NOTECONFFLG);
    }

    /**
     * 備考確認フラグを設定する
     * @param val String 備考確認フラグ
     */
    public void setNOTECONFFLG(String val) {
        set(Tbj11CrCreateData.NOTECONFFLG, val);
    }

    /**
     * 備考確認組織コードを取得する
     * @return String 備考確認組織コード
     */
    public String getNOTECONFSIKCD() {
        return (String) get(Tbj11CrCreateData.NOTECONFSIKCD);
    }

    /**
     * 備考確認組織コードを設定する
     * @param val String 備考確認組織コード
     */
    public void setNOTECONFSIKCD(String val) {
        set(Tbj11CrCreateData.NOTECONFSIKCD, val);
    }

    /**
     * 備考確認担当者コードを取得する
     * @return String 備考確認担当者コード
     */
    public String getNOTECONFHAMID() {
        return (String) get(Tbj11CrCreateData.NOTECONFHAMID);
    }

    /**
     * 備考確認担当者コードを設定する
     * @param val String 備考確認担当者コード
     */
    public void setNOTECONFHAMID(String val) {
        set(Tbj11CrCreateData.NOTECONFHAMID, val);
    }

    /**
     * データ作成日時を取得する
     * @return Date データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj11CrCreateData.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     * @param val Date データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj11CrCreateData.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     * @return String データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj11CrCreateData.CRTNM);
    }

    /**
     * データ作成者を設定する
     * @param val String データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj11CrCreateData.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     * @return String 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj11CrCreateData.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     * @param val String 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj11CrCreateData.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     * @return String 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj11CrCreateData.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     * @param val String 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj11CrCreateData.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     * @return Date データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj11CrCreateData.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     * @param val Date データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj11CrCreateData.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj11CrCreateData.UPDNM);
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj11CrCreateData.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj11CrCreateData.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj11CrCreateData.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj11CrCreateData.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj11CrCreateData.UPDID, val);
    }

    /**
     * 分類名を取得する
     * @return String 分類名
     */
    public String getCLASSNM() {
        return (String) get(Mbj15CrClass.CLASSNM);
    }

    /**
     * 分類名を設定する
     * @param val String 分類名
     */
    public void setCLASSNM(String val) {
        set(Mbj15CrClass.CLASSNM, val);
    }

    /**
     * 費目名を取得する
     * @return String 費目名
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * 費目名を設定する
     * @param val String 費目名
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * 区分名を取得する
     * @return String 区分名
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分名を設定する
     * @param val String 区分名
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * グループ名を取得する
     * @return グループ名
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * グループ名を設定する
     * @param val String グループ名
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * グループ名(帳票)を取得する
     * @return String グループ名(帳票)
     */
    public String getGROUPNMRPT() {
        return (String) get(Mbj26BillGroup.GROUPNMRPT);
    }

    /**
     * グループ名(帳票)を設定する
     * @param val String グループ名(帳票)
     */
    public void setGROUPNMRPT(String val) {
        set(Mbj26BillGroup.GROUPNMRPT, val);
    }

    /**
     * 設定局名を取得する
     * @return String 設定局名
     */
    public String getSTKYKNM() {
        return (String) get(Mbj29SetteiKyk.STKYKNM);
    }

    /**
     * 設定局名を設定する
     * @param val String 設定局名
     */
    public void setSTKYKNM(String val) {
        set(Mbj29SetteiKyk.STKYKNM, val);
    }

    /**
     * 入力担当を取得する
     * @return String 入力担当
     */
    public String getINPUTTNT() {
        return (String) get(Mbj30InputTnt.INPUTTNT);
    }

    /**
     * 入力担当を設定する
     * @param val String 入力担当
     */
    public void setINPUTTNT(String val) {
        set(Mbj30InputTnt.INPUTTNT, val);
    }

}
