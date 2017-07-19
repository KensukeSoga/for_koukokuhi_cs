package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 制作費取込VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj22SeisakuhiSsVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj22SeisakuhiSsVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj22SeisakuhiSsVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj22SeisakuhiSs.PHASE, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj22SeisakuhiSs.CRDATE, val);
    }

    /**
     * 制作費管理NOを取得する
     *
     * @return 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.SEQUENCENO);
    }

    /**
     * 制作費管理NOを設定する
     *
     * @param val 制作費管理NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.SEQUENCENO, val);
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get(Tbj22SeisakuhiSs.CLASSDIV);
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param val 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set(Tbj22SeisakuhiSs.CLASSDIV, val);
    }

    /**
     * ソート順を取得する
     *
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.SORTNO);
    }

    /**
     * ソート順を設定する
     *
     * @param val ソート順
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.SORTNO, val);
    }

    /**
     * 予算分類コードを取得する
     *
     * @return 予算分類コード
     */
    public String getCLASSCD() {
        return (String) get(Tbj22SeisakuhiSs.CLASSCD);
    }

    /**
     * 予算分類コードを設定する
     *
     * @param val 予算分類コード
     */
    public void setCLASSCD(String val) {
        set(Tbj22SeisakuhiSs.CLASSCD, val);
    }

    /**
     * 予算表費目コードを取得する
     *
     * @return 予算表費目コード
     */
    public String getEXPCD() {
        return (String) get(Tbj22SeisakuhiSs.EXPCD);
    }

    /**
     * 予算表費目コードを設定する
     *
     * @param val 予算表費目コード
     */
    public void setEXPCD(String val) {
        set(Tbj22SeisakuhiSs.EXPCD, val);
    }

    /**
     * 費目を取得する
     *
     * @return 費目
     */
    public String getEXPENSE() {
        return (String) get(Tbj22SeisakuhiSs.EXPENSE);
    }

    /**
     * 費目を設定する
     *
     * @param val 費目
     */
    public void setEXPENSE(String val) {
        set(Tbj22SeisakuhiSs.EXPENSE, val);
    }

    /**
     * 詳細を取得する
     *
     * @return 詳細
     */
    public String getDETAIL() {
        return (String) get(Tbj22SeisakuhiSs.DETAIL);
    }

    /**
     * 詳細を設定する
     *
     * @param val 詳細
     */
    public void setDETAIL(String val) {
        set(Tbj22SeisakuhiSs.DETAIL, val);
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANS);
    }

    /**
     * 期間開始を設定する
     *
     * @param val 期間開始
     */
    public void setKIKANS(Date val) {
        set(Tbj22SeisakuhiSs.KIKANS, val);
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANE);
    }

    /**
     * 期間終了を設定する
     *
     * @param val 期間終了
     */
    public void setKIKANE(Date val) {
        set(Tbj22SeisakuhiSs.KIKANE, val);
    }

    /**
     * 契約開始年月日を取得する
     *
     * @return 契約開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONTRACTDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CONTRACTDATE);
    }

    /**
     * 契約開始年月日を設定する
     *
     * @param val 契約開始年月日
     */
    public void setCONTRACTDATE(Date val) {
        set(Tbj22SeisakuhiSs.CONTRACTDATE, val);
    }

    /**
     * 契約期間(ヶ月)を取得する
     *
     * @return 契約期間(ヶ月)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj22SeisakuhiSs.CONTRACTTERM);
    }

    /**
     * 契約期間(ヶ月)を設定する
     *
     * @param val 契約期間(ヶ月)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj22SeisakuhiSs.CONTRACTTERM, val);
    }

    /**
     * 請求先を取得する
     *
     * @return 請求先
     */
    public String getSEIKYU() {
        return (String) get(Tbj22SeisakuhiSs.SEIKYU);
    }

    /**
     * 請求先を設定する
     *
     * @param val 請求先
     */
    public void setSEIKYU(String val) {
        set(Tbj22SeisakuhiSs.SEIKYU, val);
    }

    /**
     * 受注NOを取得する
     *
     * @return 受注NO
     */
    public String getORDERNO() {
        return (String) get(Tbj22SeisakuhiSs.ORDERNO);
    }

    /**
     * 受注NOを設定する
     *
     * @param val 受注NO
     */
    public void setORDERNO(String val) {
        set(Tbj22SeisakuhiSs.ORDERNO, val);
    }

    /**
     * 支払先を取得する
     *
     * @return 支払先
     */
    public String getPAY() {
        return (String) get(Tbj22SeisakuhiSs.PAY);
    }

    /**
     * 支払先を設定する
     *
     * @param val 支払先
     */
    public void setPAY(String val) {
        set(Tbj22SeisakuhiSs.PAY, val);
    }

    /**
     * 担当者を取得する
     *
     * @return 担当者
     */
    public String getUSERNAME() {
        return (String) get(Tbj22SeisakuhiSs.USERNAME);
    }

    /**
     * 担当者を設定する
     *
     * @param val 担当者
     */
    public void setUSERNAME(String val) {
        set(Tbj22SeisakuhiSs.USERNAME, val);
    }

    /**
     * 取り金額を取得する
     *
     * @return 取り金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGETMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GETMONEY);
    }

    /**
     * 取り金額を設定する
     *
     * @param val 取り金額
     */
    public void setGETMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GETMONEY, val);
    }

    /**
     * 取り金額確認を取得する
     *
     * @return 取り金額確認
     */
    public String getGETCONF() {
        return (String) get(Tbj22SeisakuhiSs.GETCONF);
    }

    /**
     * 取り金額確認を設定する
     *
     * @param val 取り金額確認
     */
    public void setGETCONF(String val) {
        set(Tbj22SeisakuhiSs.GETCONF, val);
    }

    /**
     * 払い金額を取得する
     *
     * @return 払い金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPAYMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.PAYMONEY);
    }

    /**
     * 払い金額を設定する
     *
     * @param val 払い金額
     */
    public void setPAYMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.PAYMONEY, val);
    }

    /**
     * 払い金額確認を取得する
     *
     * @return 払い金額確認
     */
    public String getPAYCONF() {
        return (String) get(Tbj22SeisakuhiSs.PAYCONF);
    }

    /**
     * 払い金額確認を設定する
     *
     * @param val 払い金額確認
     */
    public void setPAYCONF(String val) {
        set(Tbj22SeisakuhiSs.PAYCONF, val);
    }

    /**
     * 見積金額を取得する
     *
     * @return 見積金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.ESTMONEY);
    }

    /**
     * 見積金額を設定する
     *
     * @param val 見積金額
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.ESTMONEY, val);
    }

    /**
     * 請求金額を取得する
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.CLMMONEY);
    }

    /**
     * 請求金額を設定する
     *
     * @param val 請求金額
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.CLMMONEY, val);
    }

    /**
     * 支払先納品日を取得する
     *
     * @return 支払先納品日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj22SeisakuhiSs.DELIVERDAY);
    }

    /**
     * 支払先納品日を設定する
     *
     * @param val 支払先納品日
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj22SeisakuhiSs.DELIVERDAY, val);
    }

    /**
     * 設定月を取得する
     *
     * @return 設定月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSETMONTH() {
        return (Date) get(Tbj22SeisakuhiSs.SETMONTH);
    }

    /**
     * 設定月を設定する
     *
     * @param val 設定月
     */
    public void setSETMONTH(Date val) {
        set(Tbj22SeisakuhiSs.SETMONTH, val);
    }

    /**
     * 区分コードを取得する
     *
     * @return 区分コード
     */
    public String getDIVCD() {
        return (String) get(Tbj22SeisakuhiSs.DIVCD);
    }

    /**
     * 区分コードを設定する
     *
     * @param val 区分コード
     */
    public void setDIVCD(String val) {
        set(Tbj22SeisakuhiSs.DIVCD, val);
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * グループコードを設定する
     *
     * @param val グループコード
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
    }

    /**
     * 設定局ナンバーを取得する
     *
     * @return 設定局ナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSTKYKNO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.STKYKNO);
    }

    /**
     * 設定局ナンバーを設定する
     *
     * @param val 設定局ナンバー
     */
    public void setSTKYKNO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.STKYKNO, val);
    }

    /**
     * 営直チェックを取得する
     *
     * @return 営直チェック
     */
    public String getEGTYKFLG() {
        return (String) get(Tbj22SeisakuhiSs.EGTYKFLG);
    }

    /**
     * 営直チェックを設定する
     *
     * @param val 営直チェック
     */
    public void setEGTYKFLG(String val) {
        set(Tbj22SeisakuhiSs.EGTYKFLG, val);
    }

    /**
     * 入力担当コードを取得する
     *
     * @return 入力担当コード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getINPUTTNTCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.INPUTTNTCD);
    }

    /**
     * 入力担当コードを設定する
     *
     * @param val 入力担当コード
     */
    public void setINPUTTNTCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.INPUTTNTCD, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getNOTE() {
        return (String) get(Tbj22SeisakuhiSs.NOTE);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setNOTE(String val) {
        set(Tbj22SeisakuhiSs.NOTE, val);
    }

    /**
     * 予算分類フラグを取得する
     *
     * @return 予算分類フラグ
     */
    public String getCLASSCDFLG() {
        return (String) get(Tbj22SeisakuhiSs.CLASSCDFLG);
    }

    /**
     * 予算分類フラグを設定する
     *
     * @param val 予算分類フラグ
     */
    public void setCLASSCDFLG(String val) {
        set(Tbj22SeisakuhiSs.CLASSCDFLG, val);
    }

    /**
     * 予算表費目フラグを取得する
     *
     * @return 予算表費目フラグ
     */
    public String getEXPCDFLG() {
        return (String) get(Tbj22SeisakuhiSs.EXPCDFLG);
    }

    /**
     * 予算表費目フラグを設定する
     *
     * @param val 予算表費目フラグ
     */
    public void setEXPCDFLG(String val) {
        set(Tbj22SeisakuhiSs.EXPCDFLG, val);
    }

    /**
     * 費目フラグを取得する
     *
     * @return 費目フラグ
     */
    public String getEXPENSEFLG() {
        return (String) get(Tbj22SeisakuhiSs.EXPENSEFLG);
    }

    /**
     * 費目フラグを設定する
     *
     * @param val 費目フラグ
     */
    public void setEXPENSEFLG(String val) {
        set(Tbj22SeisakuhiSs.EXPENSEFLG, val);
    }

    /**
     * 詳細フラグを取得する
     *
     * @return 詳細フラグ
     */
    public String getDETAILFLG() {
        return (String) get(Tbj22SeisakuhiSs.DETAILFLG);
    }

    /**
     * 詳細フラグを設定する
     *
     * @param val 詳細フラグ
     */
    public void setDETAILFLG(String val) {
        set(Tbj22SeisakuhiSs.DETAILFLG, val);
    }

    /**
     * 期間開始フラグを取得する
     *
     * @return 期間開始フラグ
     */
    public String getKIKANSFLG() {
        return (String) get(Tbj22SeisakuhiSs.KIKANSFLG);
    }

    /**
     * 期間開始フラグを設定する
     *
     * @param val 期間開始フラグ
     */
    public void setKIKANSFLG(String val) {
        set(Tbj22SeisakuhiSs.KIKANSFLG, val);
    }

    /**
     * 期間終了フラグを取得する
     *
     * @return 期間終了フラグ
     */
    public String getKIKANEFLG() {
        return (String) get(Tbj22SeisakuhiSs.KIKANEFLG);
    }

    /**
     * 期間終了フラグを設定する
     *
     * @param val 期間終了フラグ
     */
    public void setKIKANEFLG(String val) {
        set(Tbj22SeisakuhiSs.KIKANEFLG, val);
    }

    /**
     * 契約開始年月日フラグを取得する
     *
     * @return 契約開始年月日フラグ
     */
    public String getCONTRACTDATEFLG() {
        return (String) get(Tbj22SeisakuhiSs.CONTRACTDATEFLG);
    }

    /**
     * 契約開始年月日フラグを設定する
     *
     * @param val 契約開始年月日フラグ
     */
    public void setCONTRACTDATEFLG(String val) {
        set(Tbj22SeisakuhiSs.CONTRACTDATEFLG, val);
    }

    /**
     * 契約期間(ヶ月)フラグを取得する
     *
     * @return 契約期間(ヶ月)フラグ
     */
    public String getCONTRACTTERMFLG() {
        return (String) get(Tbj22SeisakuhiSs.CONTRACTTERMFLG);
    }

    /**
     * 契約期間(ヶ月)フラグを設定する
     *
     * @param val 契約期間(ヶ月)フラグ
     */
    public void setCONTRACTTERMFLG(String val) {
        set(Tbj22SeisakuhiSs.CONTRACTTERMFLG, val);
    }

    /**
     * 請求先フラグを取得する
     *
     * @return 請求先フラグ
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj22SeisakuhiSs.SEIKYUFLG);
    }

    /**
     * 請求先フラグを設定する
     *
     * @param val 請求先フラグ
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj22SeisakuhiSs.SEIKYUFLG, val);
    }

    /**
     * 受注NOフラグを取得する
     *
     * @return 受注NOフラグ
     */
    public String getORDERNOFLG() {
        return (String) get(Tbj22SeisakuhiSs.ORDERNOFLG);
    }

    /**
     * 受注NOフラグを設定する
     *
     * @param val 受注NOフラグ
     */
    public void setORDERNOFLG(String val) {
        set(Tbj22SeisakuhiSs.ORDERNOFLG, val);
    }

    /**
     * 支払先フラグを取得する
     *
     * @return 支払先フラグ
     */
    public String getPAYFLG() {
        return (String) get(Tbj22SeisakuhiSs.PAYFLG);
    }

    /**
     * 支払先フラグを設定する
     *
     * @param val 支払先フラグ
     */
    public void setPAYFLG(String val) {
        set(Tbj22SeisakuhiSs.PAYFLG, val);
    }

    /**
     * 担当者フラグを取得する
     *
     * @return 担当者フラグ
     */
    public String getUSERNAMEFLG() {
        return (String) get(Tbj22SeisakuhiSs.USERNAMEFLG);
    }

    /**
     * 担当者フラグを設定する
     *
     * @param val 担当者フラグ
     */
    public void setUSERNAMEFLG(String val) {
        set(Tbj22SeisakuhiSs.USERNAMEFLG, val);
    }

    /**
     * 取り金額フラグを取得する
     *
     * @return 取り金額フラグ
     */
    public String getGETMONEYFLG() {
        return (String) get(Tbj22SeisakuhiSs.GETMONEYFLG);
    }

    /**
     * 取り金額フラグを設定する
     *
     * @param val 取り金額フラグ
     */
    public void setGETMONEYFLG(String val) {
        set(Tbj22SeisakuhiSs.GETMONEYFLG, val);
    }

    /**
     * 払い金額フラグを取得する
     *
     * @return 払い金額フラグ
     */
    public String getPAYMONEYFLG() {
        return (String) get(Tbj22SeisakuhiSs.PAYMONEYFLG);
    }

    /**
     * 払い金額フラグを設定する
     *
     * @param val 払い金額フラグ
     */
    public void setPAYMONEYFLG(String val) {
        set(Tbj22SeisakuhiSs.PAYMONEYFLG, val);
    }

    /**
     * 見積金額フラグを取得する
     *
     * @return 見積金額フラグ
     */
    public String getESTMONEYFLG() {
        return (String) get(Tbj22SeisakuhiSs.ESTMONEYFLG);
    }

    /**
     * 見積金額フラグを設定する
     *
     * @param val 見積金額フラグ
     */
    public void setESTMONEYFLG(String val) {
        set(Tbj22SeisakuhiSs.ESTMONEYFLG, val);
    }

    /**
     * 請求金額フラグを取得する
     *
     * @return 請求金額フラグ
     */
    public String getCLMMONEYFLG() {
        return (String) get(Tbj22SeisakuhiSs.CLMMONEYFLG);
    }

    /**
     * 請求金額フラグを設定する
     *
     * @param val 請求金額フラグ
     */
    public void setCLMMONEYFLG(String val) {
        set(Tbj22SeisakuhiSs.CLMMONEYFLG, val);
    }

    /**
     * 支払先納品日フラグを取得する
     *
     * @return 支払先納品日フラグ
     */
    public String getDELIVERDAYFLG() {
        return (String) get(Tbj22SeisakuhiSs.DELIVERDAYFLG);
    }

    /**
     * 支払先納品日フラグを設定する
     *
     * @param val 支払先納品日フラグ
     */
    public void setDELIVERDAYFLG(String val) {
        set(Tbj22SeisakuhiSs.DELIVERDAYFLG, val);
    }

    /**
     * 設定月フラグを取得する
     *
     * @return 設定月フラグ
     */
    public String getSETMONTHFLG() {
        return (String) get(Tbj22SeisakuhiSs.SETMONTHFLG);
    }

    /**
     * 設定月フラグを設定する
     *
     * @param val 設定月フラグ
     */
    public void setSETMONTHFLG(String val) {
        set(Tbj22SeisakuhiSs.SETMONTHFLG, val);
    }

    /**
     * 区分フラグを取得する
     *
     * @return 区分フラグ
     */
    public String getDIVISIONFLG() {
        return (String) get(Tbj22SeisakuhiSs.DIVISIONFLG);
    }

    /**
     * 区分フラグを設定する
     *
     * @param val 区分フラグ
     */
    public void setDIVISIONFLG(String val) {
        set(Tbj22SeisakuhiSs.DIVISIONFLG, val);
    }

    /**
     * グループコードフラグを取得する
     *
     * @return グループコードフラグ
     */
    public String getGROUPCDFLG() {
        return (String) get(Tbj22SeisakuhiSs.GROUPCDFLG);
    }

    /**
     * グループコードフラグを設定する
     *
     * @param val グループコードフラグ
     */
    public void setGROUPCDFLG(String val) {
        set(Tbj22SeisakuhiSs.GROUPCDFLG, val);
    }

    /**
     * 設定局ナンバーフラグを取得する
     *
     * @return 設定局ナンバーフラグ
     */
    public String getSTKYKNOFLG() {
        return (String) get(Tbj22SeisakuhiSs.STKYKNOFLG);
    }

    /**
     * 設定局ナンバーフラグを設定する
     *
     * @param val 設定局ナンバーフラグ
     */
    public void setSTKYKNOFLG(String val) {
        set(Tbj22SeisakuhiSs.STKYKNOFLG, val);
    }

    /**
     * 入力担当コードフラグを取得する
     *
     * @return 入力担当コードフラグ
     */
    public String getINPUTTNTCDFLG() {
        return (String) get(Tbj22SeisakuhiSs.INPUTTNTCDFLG);
    }

    /**
     * 入力担当コードフラグを設定する
     *
     * @param val 入力担当コードフラグ
     */
    public void setINPUTTNTCDFLG(String val) {
        set(Tbj22SeisakuhiSs.INPUTTNTCDFLG, val);
    }

    /**
     * 備考フラグを取得する
     *
     * @return 備考フラグ
     */
    public String getNOTEFLG() {
        return (String) get(Tbj22SeisakuhiSs.NOTEFLG);
    }

    /**
     * 備考フラグを設定する
     *
     * @param val 備考フラグ
     */
    public void setNOTEFLG(String val) {
        set(Tbj22SeisakuhiSs.NOTEFLG, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj22SeisakuhiSs.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj22SeisakuhiSs.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj22SeisakuhiSs.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj22SeisakuhiSs.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj22SeisakuhiSs.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj22SeisakuhiSs.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj22SeisakuhiSs.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj22SeisakuhiSs.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj22SeisakuhiSs.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj22SeisakuhiSs.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj22SeisakuhiSs.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj22SeisakuhiSs.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj22SeisakuhiSs.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj22SeisakuhiSs.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj22SeisakuhiSs.UPDID, val);
    }

    /**
     * 制作費データ取得日時を取得する
     *
     * @return 制作費データ取得日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getGETTIME() {
        return (Date) get(Tbj22SeisakuhiSs.GETTIME);
    }

    /**
     * 制作費データ取得日時を設定する
     *
     * @param val 制作費データ取得日時
     */
    public void setGETTIME(Date val) {
        set(Tbj22SeisakuhiSs.GETTIME, val);
    }

    /**
     * タイムスタンプ（制作）を取得する
     *
     * @return タイムスタンプ（制作）
     */
    @XmlElement(required = true, nillable = true)
    public Date getTIMSTMPSS() {
        return (Date) get(Tbj22SeisakuhiSs.TIMSTMPSS);
    }

    /**
     * タイムスタンプ（制作）を設定する
     *
     * @param val タイムスタンプ（制作）
     */
    public void setTIMSTMPSS(Date val) {
        set(Tbj22SeisakuhiSs.TIMSTMPSS, val);
    }

    /**
     * 更新プログラム（制作）を取得する
     *
     * @return 更新プログラム（制作）
     */
    public String getUPDAPLSS() {
        return (String) get(Tbj22SeisakuhiSs.UPDAPLSS);
    }

    /**
     * 更新プログラム（制作）を設定する
     *
     * @param val 更新プログラム（制作）
     */
    public void setUPDAPLSS(String val) {
        set(Tbj22SeisakuhiSs.UPDAPLSS, val);
    }

    /**
     * 更新担当者ID（制作）を取得する
     *
     * @return 更新担当者ID（制作）
     */
    public String getUPDIDSS() {
        return (String) get(Tbj22SeisakuhiSs.UPDIDSS);
    }

    /**
     * 更新担当者ID（制作）を設定する
     *
     * @param val 更新担当者ID（制作）
     */
    public void setUPDIDSS(String val) {
        set(Tbj22SeisakuhiSs.UPDIDSS, val);
    }

}
