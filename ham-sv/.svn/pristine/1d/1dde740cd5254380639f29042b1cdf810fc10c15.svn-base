package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積一覧変更確認(制作費)データ取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/21 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDiffTotalVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListDiffTotalVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListDiffTotalVO();
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param val 見積案件管理NO
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj05EstimateItem.ESTSEQNO, val);
    }

    /**
     * 見積明細管理NOを取得する
     *
     * @return 見積明細管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * 見積明細管理NOを設定する
     *
     * @param val 見積明細管理NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
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

    /**
     * 電通車種コード(CR制作費管理)を取得する
     *
     * @return 電通車種コード(CR制作費管理)
     */
    public String getCrDCARCD() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * 電通車種コード(CR制作費管理)を設定する
     *
     * @param val 電通車種コード(CR制作費管理)
     */
    public void setCrDCARCD(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
    }

    /**
     * 電通車種コード(見積案件CR制作費)を取得する
     *
     * @return 電通車種コード(見積案件CR制作費)
     */
    public String getEstDCARCD() {
        return (String) get(Tbj07EstimateCreate.DCARCD);
    }

    /**
     * 電通車種コード(見積案件CR制作費)を設定する
     *
     * @param val 電通車種コード(見積案件CR制作費)
     */
    public void setEstDCARCD(String val) {
        set(Tbj07EstimateCreate.DCARCD, val);
    }

    /**
     * 年月(CR制作費管理)を取得する
     *
     * @return 年月(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrCRDATE() {
        return (Date) get(Tbj11CrCreateData.CRDATE);
    }

    /**
     * 年月(CR制作費管理)を設定する
     *
     * @param val 年月(CR制作費管理)
     */
    public void setCrCRDATE(Date val) {
        set(Tbj11CrCreateData.CRDATE, val);
    }

    /**
     * 年月(見積案件CR制作費)を取得する
     *
     * @return 年月(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstCRDATE() {
        return (Date) get(Tbj07EstimateCreate.CRDATE);
    }

    /**
     * 年月(見積案件CR制作費)を設定する
     *
     * @param val 年月(見積案件CR制作費)
     */
    public void setEstCRDATE(Date val) {
        set(Tbj07EstimateCreate.CRDATE, val);
    }

    /**
     * 種別判断フラグ(CR制作費管理)を取得する
     *
     * @return 種別判断フラグ(CR制作費管理)
     */
    public String getCrCLASSDIV() {
        return (String) get(Tbj11CrCreateData.CLASSDIV);
    }

    /**
     * 種別判断フラグ(CR制作費管理)を設定する
     *
     * @param val 種別判断フラグ(CR制作費管理)
     */
    public void setCrCLASSDIV(String val) {
        set(Tbj11CrCreateData.CLASSDIV, val);
    }

    /**
     * 種別判断フラグ(見積案件CR制作費)を取得する
     *
     * @return 種別判断フラグ(見積案件CR制作費)
     */
    public String getEstCLASSDIV() {
        return (String) get(Tbj07EstimateCreate.CLASSDIV);
    }

    /**
     * 種別判断フラグ(見積案件CR制作費)を設定する
     *
     * @param val 種別判断フラグ(見積案件CR制作費)
     */
    public void setEstCLASSDIV(String val) {
        set(Tbj07EstimateCreate.CLASSDIV, val);
    }

    /**
     * 予算分類コード(CR制作費管理)を取得する
     *
     * @return 予算分類コード(CR制作費管理)
     */
    public String getCrCLASSCD() {
        return (String) get(Tbj11CrCreateData.CLASSCD);
    }

    /**
     * 予算分類コード(CR制作費管理)を設定する
     *
     * @param val 予算分類コード(CR制作費管理)
     */
    public void setCrCLASSCD(String val) {
        set(Tbj11CrCreateData.CLASSCD, val);
    }

    /**
     * 予算分類コード(見積案件CR制作費)を取得する
     *
     * @return 予算分類コード(見積案件CR制作費)
     */
    public String getEstCLASSCD() {
        return (String) get(Tbj07EstimateCreate.CLASSCD);
    }

    /**
     * 予算分類コード(見積案件CR制作費)を設定する
     *
     * @param val 予算分類コード(見積案件CR制作費)
     */
    public void setEstCLASSCD(String val) {
        set(Tbj07EstimateCreate.CLASSCD, val);
    }

    /**
     * 予算表費目コード(CR制作費管理)を取得する
     *
     * @return 予算表費目コード
     */
    public String getCrEXPCD() {
        return (String) get(Tbj11CrCreateData.EXPCD);
    }

    /**
     * 予算表費目コード(CR制作費管理)を設定する
     *
     * @param val 予算表費目コード
     */
    public void setCrEXPCD(String val) {
        set(Tbj11CrCreateData.EXPCD, val);
    }

    /**
     * 予算表費目コード(見積案件CR制作費)を取得する
     *
     * @return 予算表費目コード(見積案件CR制作費)
     */
    public String getEstEXPCD() {
        return (String) get(Tbj07EstimateCreate.EXPCD);
    }

    /**
     * 予算表費目コード(見積案件CR制作費)を設定する
     *
     * @param val 予算表費目コード(見積案件CR制作費)
     */
    public void setEstEXPCD(String val) {
        set(Tbj07EstimateCreate.EXPCD, val);
    }

    /**
     * 費目(CR制作費管理)を取得する
     *
     * @return 費目(CR制作費管理)
     */
    public String getCrEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * 費目(CR制作費管理)を設定する
     *
     * @param val 費目(CR制作費管理)
     */
    public void setCrEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
    }

    /**
     * 費目(見積案件CR制作費)を取得する
     *
     * @return 費目(見積案件CR制作費)
     */
    public String getEstEXPENSE() {
        return (String) get(Tbj07EstimateCreate.EXPENSE);
    }

    /**
     * 費目(見積案件CR制作費)を設定する
     *
     * @param val 費目(見積案件CR制作費)
     */
    public void setEstEXPENSE(String val) {
        set(Tbj07EstimateCreate.EXPENSE, val);
    }

    /**
     * 取り金額(CR制作費管理)を取得する
     *
     * @return 取り金額(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrGETMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * 取り金額(CR制作費管理)を設定する
     *
     * @param val 見積金額(CR制作費管理)
     */
    public void setCrGETMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * 取り金額(見積案件CR制作費)を取得する
     *
     * @return 取り金額(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstGETMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.GETMONEY);
    }

    /**
     * 取り金額(見積案件CR制作費)を設定する
     *
     * @param val 取り金額(見積案件CR制作費)
     */
    public void setEstGETMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.GETMONEY, val);
    }

    /**
     * 取り金額確認(CR制作費管理)を取得する
     *
     * @return 取り金額確認(CR制作費管理)
     */
    public String getCrGETCONF() {
        return (String) get(Tbj11CrCreateData.GETCONF);
    }

    /**
     * 取り金額確認(CR制作費管理)を設定する
     *
     * @param val 見積金額確認(CR制作費管理)
     */
    public void setCrGETCONF(String val) {
        set(Tbj11CrCreateData.GETCONF, val);
    }

    /**
     * 取り金額確認(見積案件CR制作費)を取得する
     *
     * @return 取り金額確認(見積案件CR制作費)
     */
    public String getEstGETCONF() {
        return (String) get(Tbj07EstimateCreate.GETCONF);
    }

    /**
     * 取り金額確認(見積案件CR制作費)を設定する
     *
     * @param val 取り金額確認(見積案件CR制作費)
     */
    public void setEstGETCONF(String val) {
        set(Tbj07EstimateCreate.GETCONF, val);
    }

    /**
     * 払い金額(CR制作費管理)を取得する
     *
     * @return 払い金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrPAYMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * 払い金額(CR制作費管理)を設定する
     *
     * @param val 払い金額
     */
    public void setCrPAYMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
    }

    /**
     * 払い金額(見積案件CR制作費)を取得する
     *
     * @return 払い金額(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstPAYMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.PAYMONEY);
    }

    /**
     * 払い金額(見積案件CR制作費)を設定する
     *
     * @param val 払い金額(見積案件CR制作費)
     */
    public void setEstPAYMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.PAYMONEY, val);
    }

    /**
     * 払い金額確認(CR制作費管理)を取得する
     *
     * @return 払い金額確認
     */
    public String getCrPAYCONF() {
        return (String) get(Tbj11CrCreateData.PAYCONF);
    }

    /**
     * 払い金額確認(CR制作費管理)を設定する
     *
     * @param val 払い金額確認
     */
    public void setCrPAYCONF(String val) {
        set(Tbj11CrCreateData.PAYCONF, val);
    }

    /**
     * 払い金額確認(見積案件CR制作費)を取得する
     *
     * @return 払い金額確認(見積案件CR制作費)
     */
    public String getEstPAYCONF() {
        return (String) get(Tbj07EstimateCreate.PAYCONF);
    }

    /**
     * 払い金額確認(見積案件CR制作費)を設定する
     *
     * @param val 払い金額確認(見積案件CR制作費)
     */
    public void setEstPAYCONF(String val) {
        set(Tbj07EstimateCreate.PAYCONF, val);
    }

    /**
     * 区分コード(CR制作費管理)を取得する
     *
     * @return 区分コード(CR制作費管理)
     */
    public String getCrDIVCD() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * 区分コード(CR制作費管理)を設定する
     *
     * @param val 区分コード(CR制作費管理)
     */
    public void setCrDIVCD(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
    }

    /**
     * 区分コード(見積案件CR制作費)を取得する
     *
     * @return 区分コード(見積案件CR制作費)
     */
    public String getEstDIVCD() {
        return (String) get(Tbj07EstimateCreate.DIVCD);
    }

    /**
     * 区分コード(見積案件CR制作費)を設定する
     *
     * @param val 区分コード(見積案件CR制作費)
     */
    public void setEstDIVCD(String val) {
        set(Tbj07EstimateCreate.DIVCD, val);
    }

    /**
     * グループコード(CR制作費管理)を取得する
     *
     * @return グループコード(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrGROUPCD() {
        return (BigDecimal) get(Tbj11CrCreateData.GROUPCD);
    }

    /**
     * グループコード(CR制作費管理)を設定する
     *
     * @param val グループコード(CR制作費管理)
     */
    public void setCrGROUPCD(BigDecimal val) {
        set(Tbj11CrCreateData.GROUPCD, val);
    }

    /**
     * グループコード(見積案件CR制作費)を取得する
     *
     * @return グループコード(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstGROUPCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.GROUPCD);
    }

    /**
     * グループコード(見積案件CR制作費)を設定する
     *
     * @param val グループコード(見積案件CR制作費)
     */
    public void setEstGROUPCD(BigDecimal val) {
        set(Tbj07EstimateCreate.GROUPCD, val);
    }

    /**
     * 期間開始(CR制作費管理)を取得する
     *
     * @return 期間開始(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrKIKANS() {
        return (Date) get(Tbj11CrCreateData.KIKANS);
    }

    /**
     * 期間開始(CR制作費管理)を設定する
     *
     * @param val 期間開始(CR制作費管理)
     */
    public void setCrKIKANS(Date val) {
        set(Tbj11CrCreateData.KIKANS, val);
    }

    /**
     * 期間開始(見積案件CR制作費)を取得する
     *
     * @return 期間開始(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstKIKANS() {
        return (Date) get(Tbj07EstimateCreate.KIKANS);
    }

    /**
     * 期間開始(見積案件CR制作費)を設定する
     *
     * @param val 期間開始(見積案件CR制作費)
     */
    public void setEstKIKANS(Date val) {
        set(Tbj07EstimateCreate.KIKANS, val);
    }

    /**
     * 期間終了(CR制作費管理)を取得する
     *
     * @return 期間終了(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrKIKANE() {
        return (Date) get(Tbj11CrCreateData.KIKANE);
    }

    /**
     * 期間終了(CR制作費管理)を設定する
     *
     * @param val 期間終了(CR制作費管理)
     */
    public void setCrKIKANE(Date val) {
        set(Tbj11CrCreateData.KIKANE, val);
    }

    /**
     * 期間終了(見積案件CR制作費)を取得する
     *
     * @return 期間終了(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstKIKANE() {
        return (Date) get(Tbj07EstimateCreate.KIKANE);
    }

    /**
     * 期間終了(見積案件CR制作費)を設定する
     *
     * @param val 期間終了(見積案件CR制作費)
     */
    public void setEstKIKANE(Date val) {
        set(Tbj07EstimateCreate.KIKANE, val);
    }

    /**
     * 支払先納品日(CR制作費管理)を取得する
     *
     * @return 支払先納品日(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * 支払先納品日(CR制作費管理)を設定する
     *
     * @param val 支払先納品日(CR制作費管理)
     */
    public void setCrDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
    }

    /**
     * 支払先納品日(見積案件CR制作費)を取得する
     *
     * @return 支払先納品日(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstDELIVERDAY() {
        return (Date) get(Tbj07EstimateCreate.DELIVERDAY);
    }

    /**
     * 支払先納品日(見積案件CR制作費)を設定する
     *
     * @param val 支払先納品日(見積案件CR制作費)
     */
    public void setEstDELIVERDAY(Date val) {
        set(Tbj07EstimateCreate.DELIVERDAY, val);
    }

    /**
     * 設定月(CR制作費管理)を取得する
     *
     * @return 設定月(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrSETMONTH() {
        return (Date) get(Tbj11CrCreateData.SETMONTH);
    }

    /**
     * 設定月(CR制作費管理)を設定する
     *
     * @param val 設定月(CR制作費管理)
     */
    public void setCrSETMONTH(Date val) {
        set(Tbj11CrCreateData.SETMONTH, val);
    }

    /**
     * 設定月(見積案件CR制作費)を取得する
     *
     * @return 設定月(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstSETMONTH() {
        return (Date) get(Tbj07EstimateCreate.SETMONTH);
    }

    /**
     * 設定月(見積案件CR制作費)を設定する
     *
     * @param val 設定月(見積案件CR制作費)
     */
    public void setEstSETMONTH(Date val) {
        set(Tbj07EstimateCreate.SETMONTH, val);
    }

    /**
     * 設定局ナンバー(CR制作費管理)を取得する
     *
     * @return 設定局ナンバー(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrSTKYKNO() {
        return (BigDecimal) get(Tbj11CrCreateData.STKYKNO);
    }

    /**
     * 設定局ナンバー(CR制作費管理)を設定する
     *
     * @param val 設定局ナンバー(CR制作費管理)
     */
    public void setCrSTKYKNO(BigDecimal val) {
        set(Tbj11CrCreateData.STKYKNO, val);
    }

    /**
     * 設定局ナンバー(見積案件CR制作費)を取得する
     *
     * @return 設定局ナンバー(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSTKYKNO() {
        return (BigDecimal) get(Tbj07EstimateCreate.STKYKNO);
    }

    /**
     * 設定局ナンバー(見積案件CR制作費)を設定する
     *
     * @param val 設定局ナンバー(見積案件CR制作費)
     */
    public void setEstSTKYKNO(BigDecimal val) {
        set(Tbj07EstimateCreate.STKYKNO, val);
    }

    /**
     * 設定局名(CR制作費管理)を取得する
     *
     * @return 設定局名(CR制作費管理)
     */
    public String getCrSTKYKNM() {
        return (String) get("CRSTKYKNM");
    }

    /**
     * 設定局名(CR制作費管理)を設定する
     *
     * @param val 設定局名(CR制作費管理)
     */
    public void setCrSTKYKNM(String val) {
        set("CRSTKYKNM", val);
    }

    /**
     * 設定局名(見積案件CR制作費)を取得する
     *
     * @return 設定局名(見積案件CR制作費)
     */
    public String getEstSTKYKNM() {
        return (String) get("ESTSTKYKNM");
    }

    /**
     * 設定局名(見積案件CR制作費)を設定する
     *
     * @param val 設定局名(見積案件CR制作費)
     */
    public void setEstSTKYKNM(String val) {
        set("ESTSTKYKNM", val);
    }

    /**
     * 営直チェック(CR制作費管理)を取得する
     *
     * @return 営直チェック(CR制作費管理)
     */
    public String getCrEGTYKFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLG);
    }

    /**
     * 営直チェック(CR制作費管理)を設定する
     *
     * @param val 営直チェック(CR制作費管理)
     */
    public void setCrEGTYKFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLG, val);
    }

    /**
     * 営直チェック(見積案件CR制作費)を取得する
     *
     * @return 営直チェック(見積案件CR制作費)
     */
    public String getEstEGTYKFLG() {
        return (String) get(Tbj07EstimateCreate.EGTYKFLG);
    }

    /**
     * 営直チェック(見積案件CR制作費)を設定する
     *
     * @param val 営直チェック(見積案件CR制作費)
     */
    public void setEstEGTYKFLG(String val) {
        set(Tbj07EstimateCreate.EGTYKFLG, val);
    }

    /**
     * 入力担当コード(CR制作費管理)を取得する
     *
     * @return 入力担当コード(CR制作費管理)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrINPUTTNTCD() {
        return (BigDecimal) get(Tbj11CrCreateData.INPUTTNTCD);
    }

    /**
     * 入力担当コード(CR制作費管理)を設定する
     *
     * @param val 入力担当コード(CR制作費管理)
     */
    public void setCrINPUTTNTCD(BigDecimal val) {
        set(Tbj11CrCreateData.INPUTTNTCD, val);
    }

    /**
     * 入力担当コード(見積案件CR制作費)を取得する
     *
     * @return 入力担当コード(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstINPUTTNTCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.INPUTTNTCD);
    }

    /**
     * 入力担当コード(見積案件CR制作費)を設定する
     *
     * @param val 入力担当コード(見積案件CR制作費)
     */
    public void setEstINPUTTNTCD(BigDecimal val) {
        set(Tbj07EstimateCreate.INPUTTNTCD, val);
    }

    /**
     * 入力担当者名(CR制作費管理)を取得する
     *
     * @return 入力担当者名(CR制作費管理)
     */
    public String getCrINPUTTNTNM() {
        return (String) get("CRINPUTTNT");
    }

    /**
     * 入力担当者名(CR制作費管理)を設定する
     *
     * @param val 入力担当者名(CR制作費管理)
     */
    public void setCrINPUTTNTNM(String val) {
        set("CRINPUTTNT", val);
    }

    /**
     * 入力担当者名(見積案件CR制作費)を取得する
     *
     * @return 入力担当者名(見積案件CR制作費)
     */
    public String getEstINPUTTNTNM() {
        return (String) get("ESTINPUTTNT");
    }

    /**
     * 入力担当者名(見積案件CR制作費)を設定する
     *
     * @param val 入力担当者名(見積案件CR制作費)
     */
    public void setEstINPUTTNTNM(String val) {
        set("ESTINPUTTNT", val);
    }


}
