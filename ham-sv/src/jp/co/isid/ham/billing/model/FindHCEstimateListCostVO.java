package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積一覧(制作原価)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListCostVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListCostVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListCostVO();
    }

    /**
     * 電通車種コードを取得します
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * 電通車種コードを設定します
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
    }

    /**
     * 区分コードを取得します
     *
     * @return 区分コード
     */
    public String getDivCd() {
        return (String) get(Tbj22SeisakuhiSs.DIVCD);
    }

    /**
     * 区分コードを設定します
     *
     * @param val 区分コード
     */
    public void setDivCd(String val) {
        set(Tbj22SeisakuhiSs.DIVCD, val);
    }

    /**
     * グループコードを取得します
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * グループコードを設定します
     *
     * @param val グループコード
     */
    public void setGroupCd(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
    }

    /**
     * 見積り金額を取得します
     *
     * @return 見積り金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstMoney() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.ESTMONEY);
    }

    /**
     * 見積り金額を設定します
     *
     * @param val 見積り金額
     */
    public void setEstMonty(BigDecimal val) {
        set(Tbj22SeisakuhiSs.ESTMONEY, val);
    }

    /**
     * 請求金額を取得します
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getClmMoney() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.CLMMONEY);
    }

    /**
     * 請求金額を取得します
     *
     * @param val 請求金額
     */
    public void setClmMoney(BigDecimal val) {
        set(Tbj22SeisakuhiSs.CLMMONEY, val);
    }

    /**
     * 車種名を取得します
     *
     * @return 車種名
     */
    public String getCarNm() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定します
     *
     * @param val 車種名
     */
    public void setCarNm(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 区分名を取得します
     *
     * @return 区分名
     */
    public String getDivNm() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分名を設定します
     *
     * @param val 区分名
     */
    public void setDivNm(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * グループ名を取得します
     *
     * @return グループ名
     */
    public String getGroupNm() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * グループ名を設定します
     *
     * @param val グループ名
     */
    public void setGroupNm(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

}
