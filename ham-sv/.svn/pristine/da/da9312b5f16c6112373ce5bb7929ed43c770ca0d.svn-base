package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM請求書(見積案件出力順SEQNO)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillSeqNoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 更新フラグ */
    public static final String UPDATEFLG = "UPDATEFLG";

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
    /** シーケンスNo */
    public static final String ESTDETAILSEQNO = "ESTDETAILSEQNO";
    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillSeqNoVO() {
    }

    /**
     * 新規インスタンスを生成する
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHMBillSeqNoVO();
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * 年月を取得する
     * @return Date 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * 年月を設定する
     * @param val Date 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * 見積案件管理番号を取得する
     * @return BigDecimal 見積案件管理番号
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * 見積案件管理番号を設定する
     * @param val BigDecimal 見積案件管理番号
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    public String getESTIMATECLASS() {
        return (String) get(Tbj05EstimateItem.ESTIMATECLASS);
    }

    public void setESTIMATECLASS(String val) {
        set(Tbj05EstimateItem.ESTIMATECLASS, val);
    }

    /**
     * グループコードを取得する
     * @return BigDecimal グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj05EstimateItem.GROUPCD);
    }

    /**
     * グループコードを設定する
     * @param val BigDecimal グループコード
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj05EstimateItem.GROUPCD, val);
    }

    /**
     * 請求先グループマスタ請求先グループを取得する
     * @return String 請求先グループマスタ請求先グループ
     */
    public String getMBJ26HCBUMONCDBILL() {
        return (String) get(Mbj26BillGroup.HCBUMONCDBILL);
     }

    /**
     * 請求先グループマスタ請求先グループを設定する
     * @param val String 請求先グループマスタ請求先グループ
     */
    public void setMBJ26HCBUMONCDBILL(String val) {
        set(Mbj26BillGroup.HCBUMONCDBILL, val);
    }

    /**
     * 出力グループを取得する
     * @return String 出力グループ
     */
    public String getOUTPUTGROUP() {
        return (String) get(Tbj06EstimateDetail.OUTPUTGROUP);
    }

    /**
     * 出力グループを設定する
     * @param val String 出力グループ
     */
    public void setOUTPUTGROUP(String val) {
        set(Tbj06EstimateDetail.OUTPUTGROUP, val);
    }

    /**
     * 請求先グループを取得する
     * @return String 請求先グループ
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Tbj06EstimateDetail.HCBUMONCDBILL);
    }

    /**
     * 請求先グループを設定する
     * @param val String 請求先グループ
     */
    public void setHCBUMONCDBILL(String val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILL, val);
    }

    /**
     * 請求先グループ出力順SEQNOを取得する
     * @return BigDecimal 請求先グループ出力順SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHCBUMONCDBILLSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);
    }

    /**
     * 請求先グループ出力順SEQNOを設定する
     * @param val String 請求先グループ出力順SEQNO
     */
    public void setHCBUMONCDBILLSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }

    /**
     * 更新フラグを取得する
     * @return BigDecimal 更新フラグ
     */
    public BigDecimal getUPDATEFLG() {
        return (BigDecimal) get(UPDATEFLG);
    }

    /**
     * 更新フラグを設定する
     * @param val BigDecimal 更新フラグ
     */
    public void setUPDATEFLG(BigDecimal val) {
        set(UPDATEFLG, val);
    }

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
    /**
     * シーケンスNoを取得する
     * @return BigDecimal シーケンスNo
     */
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * シーケンスNoを設定する
     * @param val BigDecimal シーケンスNo
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
    }
    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */
}
