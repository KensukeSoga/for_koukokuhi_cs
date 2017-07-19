package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.sql.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 請求先Grコード更新チェック用VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/04/20 K.Soga)<BR>
 * </P>
 * @author K.Soga
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class CheckUpdateHCBumonCdBillVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /** デフォルトコンストラクタ */
    public CheckUpdateHCBumonCdBillVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new CheckUpdateHCBumonCdBillVO();
    }

    /**
     * 見積明細管理NOを取得する
     *
     * @return 見積明細管理NO
     */
    public BigDecimal getEstDetailSeqNo() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * 見積明細管理NOを設定する
     *
     * @param val 見積明細管理NO
     */
    public void setEstDetailSeqNo(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public BigDecimal getPhase() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPhase(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    public Date getCrDate() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCrDate(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    public BigDecimal getEstSeqNo() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param val 見積案件管理NO
     */
    public void setEstSeqNo(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Tbj03MediaMng.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Tbj03MediaMng.DCARCD, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMediaCd() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMediaCd(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

    /**
     * 出力グループを取得する
     *
     * @return 出力グループ
     */
    public String getOutputGroup() {
        return (String) get(Tbj06EstimateDetail.OUTPUTGROUP);
    }

    /**
     * 出力グループを設定する
     *
     * @param val 出力グループ
     */
    public void setOutputGroup(String val) {
        set(Tbj06EstimateDetail.OUTPUTGROUP, val);
    }

    /**
     * 請求先グループを取得する
     *
     * @return 請求先グループ
     */
    public String getHcBumonCdBill() {
        return (String) get(Tbj06EstimateDetail.HCBUMONCDBILL);
    }

    /**
     * 請求先グループを設定する
     *
     * @param val 請求先グループ
     */
    public void setHcBumonCdBill(String val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILL, val);
    }



    /**
     * 請求先グループ出力順SEQNOを取得する
     *
     * @return 請求先グループ出力順SEQNO
     */
    public BigDecimal getHcBumonCdBillSeqNo() {
        return (BigDecimal) get(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);
    }

    /**
     * 請求先グループ出力順SEQNOを設定する
     *
     * @param val 請求先グループ出力順SEQNO
     */
    public void setHcBumonCdBillSeqNo(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }
}