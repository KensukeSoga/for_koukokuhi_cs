package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積一覧変更確認データ取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDiffVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListDiffVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListDiffVO();
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
     * 電通車種コード(制作費取込)を取得する
     *
     * @return 電通車種コード(制作費取込)
     */
    public String getCptDCARCD() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * 電通車種コード(制作費取込)を設定する
     *
     * @param val 電通車種コード(制作費取込)
     */
    public void setCptDCARCD(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
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
     * 年月(制作費取込)を取得する
     *
     * @return 年月(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptCRDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CRDATE);
    }

    /**
     * 年月(制作費取込)を設定する
     *
     * @param val 年月(制作費取込)
     */
    public void setCptCRDATE(Date val) {
        set(Tbj22SeisakuhiSs.CRDATE, val);
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
     * 種別判断フラグ(制作費取込)を取得する
     *
     * @return 種別判断フラグ(制作費取込)
     */
    public String getCptCLASSDIV() {
        return (String) get(Tbj22SeisakuhiSs.CLASSDIV);
    }

    /**
     * 種別判断フラグ(制作費取込)を設定する
     *
     * @param val 種別判断フラグ(制作費取込)
     */
    public void setCptCLASSDIV(String val) {
        set(Tbj22SeisakuhiSs.CLASSDIV, val);
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
     * 予算分類コード(制作費取込)を取得する
     *
     * @return 予算分類コード(制作費取込)
     */
    public String getCptCLASSCD() {
        return (String) get(Tbj22SeisakuhiSs.CLASSCD);
    }

    /**
     * 予算分類コード(制作費取込)を設定する
     *
     * @param val 予算分類コード(制作費取込)
     */
    public void setCptCLASSCD(String val) {
        set(Tbj22SeisakuhiSs.CLASSCD, val);
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
     * 予算表費目コード(制作費取込)を取得する
     *
     * @return 予算表費目コード
     */
    public String getCptEXPCD() {
        return (String) get(Tbj22SeisakuhiSs.EXPCD);
    }

    /**
     * 予算表費目コード(制作費取込)を設定する
     *
     * @param val 予算表費目コード
     */
    public void setCptEXPCD(String val) {
        set(Tbj22SeisakuhiSs.EXPCD, val);
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
     * 費目(制作費取込)を取得する
     *
     * @return 費目(制作費取込)
     */
    public String getCptEXPENSE() {
        return (String) get(Tbj22SeisakuhiSs.EXPENSE);
    }

    /**
     * 費目(制作費取込)を設定する
     *
     * @param val 費目(制作費取込)
     */
    public void setCptEXPENSE(String val) {
        set(Tbj22SeisakuhiSs.EXPENSE, val);
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
     * 見積金額(制作費取込)を取得する
     *
     * @return 見積金額(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptESTMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.ESTMONEY);
    }

    /**
     * 見積金額(制作費取込)を設定する
     *
     * @param val 見積金額(制作費取込)
     */
    public void setCptESTMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.ESTMONEY, val);
    }

    /**
     * 見積金額(見積案件CR制作費)を取得する
     *
     * @return 見積金額(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstESTMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.ESTMONEY);
    }

    /**
     * 見積金額(見積案件CR制作費)を設定する
     *
     * @param val 見積金額(見積案件CR制作費)
     */
    public void setEstESTMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.ESTMONEY, val);
    }

    /**
     * 請求金額(制作費取込)を取得する
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptCLMMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.CLMMONEY);
    }

    /**
     * 請求金額(制作費取込)を設定する
     *
     * @param val 請求金額
     */
    public void setCptCLMMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.CLMMONEY, val);
    }

    /**
     * 請求金額(見積案件CR制作費)を取得する
     *
     * @return 請求金額(見積案件CR制作費)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstCLMMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.CLMMONEY);
    }

    /**
     * 請求金額(見積案件CR制作費)を設定する
     *
     * @param val 請求金額(見積案件CR制作費)
     */
    public void setEstCLMMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.CLMMONEY, val);
    }

    /**
     * 区分コード(制作費取込)を取得する
     *
     * @return 区分コード(制作費取込)
     */
    public String getCptDIVCD() {
        return (String) get(Tbj22SeisakuhiSs.DIVCD);
    }

    /**
     * 区分コード(制作費取込)を設定する
     *
     * @param val 区分コード(制作費取込)
     */
    public void setCptDIVCD(String val) {
        set(Tbj22SeisakuhiSs.DIVCD, val);
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
     * グループコード(制作費取込)を取得する
     *
     * @return グループコード(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptGROUPCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * グループコード(制作費取込)を設定する
     *
     * @param val グループコード(制作費取込)
     */
    public void setCptGROUPCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
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
     * 期間開始(制作費取込)を取得する
     *
     * @return 期間開始(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptKIKANS() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANS);
    }

    /**
     * 期間開始(制作費取込)を設定する
     *
     * @param val 期間開始(制作費取込)
     */
    public void setCptKIKANS(Date val) {
        set(Tbj22SeisakuhiSs.KIKANS, val);
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
     * 期間終了(制作費取込)を取得する
     *
     * @return 期間終了(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptKIKANE() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANE);
    }

    /**
     * 期間終了(制作費取込)を設定する
     *
     * @param val 期間終了(制作費取込)
     */
    public void setCptKIKANE(Date val) {
        set(Tbj22SeisakuhiSs.KIKANE, val);
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
     * 支払先納品日(制作費取込)を取得する
     *
     * @return 支払先納品日(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptDELIVERDAY() {
        return (Date) get(Tbj22SeisakuhiSs.DELIVERDAY);
    }

    /**
     * 支払先納品日(制作費取込)を設定する
     *
     * @param val 支払先納品日(制作費取込)
     */
    public void setCptDELIVERDAY(Date val) {
        set(Tbj22SeisakuhiSs.DELIVERDAY, val);
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
     * 設定月(制作費取込)を取得する
     *
     * @return 設定月(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptSETMONTH() {
        return (Date) get(Tbj22SeisakuhiSs.SETMONTH);
    }

    /**
     * 設定月(制作費取込)を設定する
     *
     * @param val 設定月(制作費取込)
     */
    public void setCptSETMONTH(Date val) {
        set(Tbj22SeisakuhiSs.SETMONTH, val);
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
     * 設定局ナンバー(制作費取込)を取得する
     *
     * @return 設定局ナンバー(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptSTKYKNO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.STKYKNO);
    }

    /**
     * 設定局ナンバー(制作費取込)を設定する
     *
     * @param val 設定局ナンバー(制作費取込)
     */
    public void setCptSTKYKNO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.STKYKNO, val);
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
     * 設定局名(制作費取込)を取得する
     *
     * @return 設定局名(制作費取込)
     */
    public String getCptSTKYKNM() {
        return (String) get("CPTSTKYKNM");
    }

    /**
     * 設定局名(制作費取込)を設定する
     *
     * @param val 設定局名(制作費取込)
     */
    public void setCptSTKYKNM(String val) {
        set("CPTSTKYKNM", val);
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
     * 営直チェック(制作費取込)を取得する
     *
     * @return 営直チェック(制作費取込)
     */
    public String getCptEGTYKFLG() {
        return (String) get(Tbj22SeisakuhiSs.EGTYKFLG);
    }

    /**
     * 営直チェック(制作費取込)を設定する
     *
     * @param val 営直チェック(制作費取込)
     */
    public void setCptEGTYKFLG(String val) {
        set(Tbj22SeisakuhiSs.EGTYKFLG, val);
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
     * 入力担当コード(制作費取込)を取得する
     *
     * @return 入力担当コード(制作費取込)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptINPUTTNTCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.INPUTTNTCD);
    }

    /**
     * 入力担当コード(制作費取込)を設定する
     *
     * @param val 入力担当コード(制作費取込)
     */
    public void setCptINPUTTNTCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.INPUTTNTCD, val);
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
     * 入力担当者名(制作費取込)を取得する
     *
     * @return 入力担当者名(制作費取込)
     */
    public String getCptINPUTTNTNM() {
        return (String) get("CPTINPUTTNT");
    }

    /**
     * 入力担当者名(制作費取込)を設定する
     *
     * @param val 入力担当者名(制作費取込)
     */
    public void setCptINPUTTNTNM(String val) {
        set("CPTINPUTTNT", val);
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
