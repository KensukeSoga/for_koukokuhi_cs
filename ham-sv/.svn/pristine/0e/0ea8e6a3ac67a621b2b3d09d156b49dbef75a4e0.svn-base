package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
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
 * BudgetDAO.findBudgetで取得したデータを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RepDataForCostMngDetailsVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepDataForCostMngDetailsVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepDataForCostMngDetailsVO();
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
     * 分類名を取得する
     *
     * @return 分類名
     */
    public String getCLASSNM() {
        return (String) get(Mbj15CrClass.CLASSNM);
    }

    /**
     * 分類名を設定する
     *
     * @param val 分類名
     */
    public void setCLASSNM(String val) {
        set(Mbj15CrClass.CLASSNM, val);
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
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj11CrCreateData.KIKANS);
    }

    /**
     * 期間開始を設定する
     *
     * @param val 期間開始
     */
    public void setKIKANS(Date val) {
        set(Tbj11CrCreateData.KIKANS, val);
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj11CrCreateData.KIKANE);
    }

    /**
     * 期間終了を設定する
     *
     * @param val 期間終了
     */
    public void setKIKANE(Date val) {
        set(Tbj11CrCreateData.KIKANE, val);
    }

    /**
     * 契約期間(ヶ月)を取得する
     *
     * @return 契約期間(ヶ月)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERM);
    }

    /**
     * 契約期間(ヶ月)を設定する
     *
     * @param val 契約期間(ヶ月)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj11CrCreateData.CONTRACTTERM, val);
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
     * 見積金額を取得する
     *
     * @return 見積金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.ESTMONEY);
    }

    /**
     * 見積金額を設定する
     *
     * @param val 見積金額
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.ESTMONEY, val);
    }

    /**
     * 請求金額を取得する
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.CLMMONEY);
    }

    /**
     * 請求金額を設定する
     *
     * @param val 請求金額
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.CLMMONEY, val);
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
        return (String) get(Mbj26BillGroup.GROUPNMRPT);
    }

    /**
     * グループ名を設定する
     *
     * @param val グループ名
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNMRPT, val);
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
     * CP担当者名を取得する
     *
     * @return CP担当者名
     */
    public String getCPTNTNM() {
        return (String) get(Tbj11CrCreateData.CPTNTNM);
    }

    /**
     * CP担当者名を設定する
     *
     * @param val CP担当者名
     */
    public void setCPTNTNM(String val) {
        set(Tbj11CrCreateData.CPTNTNM, val);
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
     * 電通車種コードフラグを取得する
     *
     * @return 電通車種コードフラグ
     */
    public String getDCARCDFLG() {
        return (String) get(Tbj11CrCreateData.DCARCDFLG);
    }

    /**
     * 電通車種コードフラグを設定する
     *
     * @param val 電通車種コードフラグ
     */
    public void setDCARCDFLG(String val) {
        set(Tbj11CrCreateData.DCARCDFLG, val);
    }

    /**
     * 予算分類フラグを取得する
     *
     * @return 予算分類フラグ
     */
    public String getCLASSCDFLG() {
        return (String) get(Tbj11CrCreateData.CLASSCDFLG);
    }

    /**
     * 予算分類フラグを設定する
     *
     * @param val 予算分類フラグ
     */
    public void setCLASSCDFLG(String val) {
        set(Tbj11CrCreateData.CLASSCDFLG, val);
    }

    /**
     * 予算表費目フラグを取得する
     *
     * @return 予算表費目フラグ
     */
    public String getEXPCDFLG() {
        return (String) get(Tbj11CrCreateData.EXPCDFLG);
    }

    /**
     * 予算表費目フラグを設定する
     *
     * @param val 予算表費目フラグ
     */
    public void setEXPCDFLG(String val) {
        set(Tbj11CrCreateData.EXPCDFLG, val);
    }

    /**
     * 費目フラグを取得する
     *
     * @return 費目フラグ
     */
    public String getEXPENSEFLG() {
        return (String) get(Tbj11CrCreateData.EXPENSEFLG);
    }

    /**
     * 費目フラグを設定する
     *
     * @param val 費目フラグ
     */
    public void setEXPENSEFLG(String val) {
        set(Tbj11CrCreateData.EXPENSEFLG, val);
    }

    /**
     * 詳細フラグを取得する
     *
     * @return 詳細フラグ
     */
    public String getDETAILFLG() {
        return (String) get(Tbj11CrCreateData.DETAILFLG);
    }

    /**
     * 詳細フラグを設定する
     *
     * @param val 詳細フラグ
     */
    public void setDETAILFLG(String val) {
        set(Tbj11CrCreateData.DETAILFLG, val);
    }

    /**
     * 期間開始フラグを取得する
     *
     * @return 期間開始フラグ
     */
    public String getKIKANSFLG() {
        return (String) get(Tbj11CrCreateData.KIKANSFLG);
    }

    /**
     * 期間開始フラグを設定する
     *
     * @param val 期間開始フラグ
     */
    public void setKIKANSFLG(String val) {
        set(Tbj11CrCreateData.KIKANSFLG, val);
    }

    /**
     * 期間終了フラグを取得する
     *
     * @return 期間終了フラグ
     */
    public String getKIKANEFLG() {
        return (String) get(Tbj11CrCreateData.KIKANEFLG);
    }

    /**
     * 期間終了フラグを設定する
     *
     * @param val 期間終了フラグ
     */
    public void setKIKANEFLG(String val) {
        set(Tbj11CrCreateData.KIKANEFLG, val);
    }

    /**
     * 契約期間(ヶ月)フラグを取得する
     *
     * @return 契約期間(ヶ月)フラグ
     */
    public String getCONTRACTTERMFLG() {
        return (String) get(Tbj11CrCreateData.CONTRACTTERMFLG);
    }

    /**
     * 契約期間(ヶ月)フラグを設定する
     *
     * @param val 契約期間(ヶ月)フラグ
     */
    public void setCONTRACTTERMFLG(String val) {
        set(Tbj11CrCreateData.CONTRACTTERMFLG, val);
    }

    /**
     * 請求先フラグを取得する
     *
     * @return 請求先フラグ
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj11CrCreateData.SEIKYUFLG);
    }

    /**
     * 請求先フラグを設定する
     *
     * @param val 請求先フラグ
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj11CrCreateData.SEIKYUFLG, val);
    }

    /**
     * 受注NOフラグを取得する
     *
     * @return 受注NOフラグ
     */
    public String getORDERNOFLG() {
        return (String) get(Tbj11CrCreateData.ORDERNOFLG);
    }

    /**
     * 受注NOフラグを設定する
     *
     * @param val 受注NOフラグ
     */
    public void setORDERNOFLG(String val) {
        set(Tbj11CrCreateData.ORDERNOFLG, val);
    }

    /**
     * 支払先フラグを取得する
     *
     * @return 支払先フラグ
     */
    public String getPAYFLG() {
        return (String) get(Tbj11CrCreateData.PAYFLG);
    }

    /**
     * 支払先フラグを設定する
     *
     * @param val 支払先フラグ
     */
    public void setPAYFLG(String val) {
        set(Tbj11CrCreateData.PAYFLG, val);
    }

    /**
     * 担当者フラグを取得する
     *
     * @return 担当者フラグ
     */
    public String getUSERNAMEFLG() {
        return (String) get(Tbj11CrCreateData.USERNAMEFLG);
    }

    /**
     * 担当者フラグを設定する
     *
     * @param val 担当者フラグ
     */
    public void setUSERNAMEFLG(String val) {
        set(Tbj11CrCreateData.USERNAMEFLG, val);
    }

    /**
     * 取り金額フラグを取得する
     *
     * @return 取り金額フラグ
     */
    public String getGETMONEYFLG() {
        return (String) get(Tbj11CrCreateData.GETMONEYFLG);
    }

    /**
     * 取り金額フラグを設定する
     *
     * @param val 取り金額フラグ
     */
    public void setGETMONEYFLG(String val) {
        set(Tbj11CrCreateData.GETMONEYFLG, val);
    }

    /**
     * 取り金額確認フラグを取得する
     *
     * @return 取り金額確認フラグ
     */
    public String getGETCONFIRMFLG() {
        return (String) get(Tbj11CrCreateData.GETCONFIRMFLG);
    }

    /**
     * 取り金額確認フラグを設定する
     *
     * @param val 取り金額確認フラグ
     */
    public void setGETCONFIRMFLG(String val) {
        set(Tbj11CrCreateData.GETCONFIRMFLG, val);
    }

    /**
     * 払い金額フラグを取得する
     *
     * @return 払い金額フラグ
     */
    public String getPAYMONEYFLG() {
        return (String) get(Tbj11CrCreateData.PAYMONEYFLG);
    }

    /**
     * 払い金額フラグを設定する
     *
     * @param val 払い金額フラグ
     */
    public void setPAYMONEYFLG(String val) {
        set(Tbj11CrCreateData.PAYMONEYFLG, val);
    }

    /**
     * 払い金額確認フラグを取得する
     *
     * @return 払い金額確認フラグ
     */
    public String getPAYCONFIRMFLG() {
        return (String) get(Tbj11CrCreateData.PAYCONFIRMFLG);
    }

    /**
     * 払い金額確認フラグを設定する
     *
     * @param val 払い金額確認フラグ
     */
    public void setPAYCONFIRMFLG(String val) {
        set(Tbj11CrCreateData.PAYCONFIRMFLG, val);
    }

    /**
     * 見積金額フラグを取得する
     *
     * @return 見積金額フラグ
     */
    public String getESTMONEYFLG() {
        return (String) get(Tbj11CrCreateData.ESTMONEYFLG);
    }

    /**
     * 見積金額フラグを設定する
     *
     * @param val 見積金額フラグ
     */
    public void setESTMONEYFLG(String val) {
        set(Tbj11CrCreateData.ESTMONEYFLG, val);
    }

    /**
     * 請求金額フラグを取得する
     *
     * @return 請求金額フラグ
     */
    public String getCLMMONEYFLG() {
        return (String) get(Tbj11CrCreateData.CLMMONEYFLG);
    }

    /**
     * 請求金額フラグを設定する
     *
     * @param val 請求金額フラグ
     */
    public void setCLMMONEYFLG(String val) {
        set(Tbj11CrCreateData.CLMMONEYFLG, val);
    }

    /**
     * 支払先納品日フラグを取得する
     *
     * @return 支払先納品日フラグ
     */
    public String getDELIVERDAYFLG() {
        return (String) get(Tbj11CrCreateData.DELIVERDAYFLG);
    }

    /**
     * 支払先納品日フラグを設定する
     *
     * @param val 支払先納品日フラグ
     */
    public void setDELIVERDAYFLG(String val) {
        set(Tbj11CrCreateData.DELIVERDAYFLG, val);
    }

    /**
     * 設定月フラグを取得する
     *
     * @return 設定月フラグ
     */
    public String getSETMONTHFLG() {
        return (String) get(Tbj11CrCreateData.SETMONTHFLG);
    }

    /**
     * 設定月フラグを設定する
     *
     * @param val 設定月フラグ
     */
    public void setSETMONTHFLG(String val) {
        set(Tbj11CrCreateData.SETMONTHFLG, val);
    }

    /**
     * 区分フラグを取得する
     *
     * @return 区分フラグ
     */
    public String getDIVISIONFLG() {
        return (String) get(Tbj11CrCreateData.DIVISIONFLG);
    }

    /**
     * 区分フラグを設定する
     *
     * @param val 区分フラグ
     */
    public void setDIVISIONFLG(String val) {
        set(Tbj11CrCreateData.DIVISIONFLG, val);
    }

    /**
     * グループコードフラグを取得する
     *
     * @return グループコードフラグ
     */
    public String getGROUPCDFLG() {
        return (String) get(Tbj11CrCreateData.GROUPCDFLG);
    }

    /**
     * グループコードフラグを設定する
     *
     * @param val グループコードフラグ
     */
    public void setGROUPCDFLG(String val) {
        set(Tbj11CrCreateData.GROUPCDFLG, val);
    }

    /**
     * 設定局コードフラグを取得する
     *
     * @return 設定局コードフラグ
     */
    public String getSTKYKNOFLG() {
        return (String) get(Tbj11CrCreateData.STKYKNOFLG);
    }

    /**
     * 設定局コードフラグを設定する
     *
     * @param val 設定局コードフラグ
     */
    public void setSTKYKNOFLG(String val) {
        set(Tbj11CrCreateData.STKYKNOFLG, val);
    }

    /**
     * 営直チェックフラグを取得する
     *
     * @return 営直チェックフラグ
     */
    public String getEGTYKFLGFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLGFLG);
    }

    /**
     * 営直チェックフラグを設定する
     *
     * @param val 営直チェックフラグ
     */
    public void setEGTYKFLGFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLGFLG, val);
    }

    /**
     * 入力担当コードフラグを取得する
     *
     * @return 入力担当コードフラグ
     */
    public String getINPUTTNTCDFLG() {
        return (String) get(Tbj11CrCreateData.INPUTTNTCDFLG);
    }

    /**
     * 入力担当コードフラグを設定する
     *
     * @param val 入力担当コードフラグ
     */
    public void setINPUTTNTCDFLG(String val) {
        set(Tbj11CrCreateData.INPUTTNTCDFLG, val);
    }

    /**
     * CP担当者フラグを取得する
     *
     * @return CP担当者フラグ
     */
    public String getCPTNTNMFLG() {
        return (String) get(Tbj11CrCreateData.CPTNTNMFLG);
    }

    /**
     * CP担当者フラグを設定する
     *
     * @param val CP担当者フラグ
     */
    public void setCPTNTNMFLG(String val) {
        set(Tbj11CrCreateData.CPTNTNMFLG, val);
    }

    /**
     * 備考フラグを取得する
     *
     * @return 備考フラグ
     */
    public String getNOTEFLG() {
        return (String) get(Tbj11CrCreateData.NOTEFLG);
    }

    /**
     * 備考フラグを設定する
     *
     * @param val 備考フラグ
     */
    public void setNOTEFLG(String val) {
        set(Tbj11CrCreateData.NOTEFLG, val);
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
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
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
     * 予算分類コードを取得する
     *
     * @return 予算分類コード
     */
    public String getCLASSCD() {
        return (String) get(Tbj11CrCreateData.CLASSCD);
    }

    /**
     * 予算分類コードを設定する
     *
     * @param val 予算分類コード
     */
    public void setCLASSCD(String val) {
        set(Tbj11CrCreateData.CLASSCD, val);
    }

    /**
     * 予算表費目コードを取得する
     *
     * @return 予算表費目コード
     */
    public String getEXPCD() {
        return (String) get(Tbj11CrCreateData.EXPCD);
    }

    /**
     * 予算表費目コードを設定する
     *
     * @param val 予算表費目コード
     */
    public void setEXPCD(String val) {
        set(Tbj11CrCreateData.EXPCD, val);
    }

    /**
     * 区分コードを取得する
     *
     * @return 区分コード
     */
    public String getDIVCD() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * 区分コードを設定する
     *
     * @param val 区分コード
     */
    public void setDIVCD(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
    }

    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAUTHORITY() {
        return (String) get(Mbj11CarSec.AUTHORITY);
    }

    /**
     * 権限を設定する
     *
     * @param val 権限
     */
    public void setAUTHORITY(String val) {
        set(Mbj11CarSec.AUTHORITY, val);
    }



}
