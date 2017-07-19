package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積一覧(制作費)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListTotalVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListTotalVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListTotalVO();
    }

    /**
     * 電通車種コードを取得します
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * 電通車種コードを設定します
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
    }

    /**
     * 区分コードを取得します
     *
     * @return 区分コード
     */
    public String getDivCd() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * 区分コードを設定します
     *
     * @param val 区分コード
     */
    public void setDivCd(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
    }

    /**
     * グループコードを取得します
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return (BigDecimal) get(Tbj11CrCreateData.GROUPCD);
    }

    /**
     * グループコードを設定します
     *
     * @param val グループコード
     */
    public void setGroupCd(BigDecimal val) {
        set(Tbj11CrCreateData.GROUPCD, val);
    }

    /**
     * 取り金額金額を取得します
     *
     * @return 取り金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGetMoney() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * 取り金額金額を設定します
     *
     * @param val 取り金額金額
     */
    public void setGetMonty(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * 払い金額を取得します
     *
     * @return 払い金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPayMoney() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * 払い金額を取得します
     *
     * @param val 払い金額
     */
    public void setPayMoney(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
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
