package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

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
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCostManagementCaptureVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCostManagementCaptureVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindCostManagementCaptureVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * グループコードを設定する
     *
     * @param val グループコード
     */
    public void setGroupCd(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
    }

    /**
     * 請求金額を取得する
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMoney() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.CLMMONEY);
    }

    /**
     * 請求金額を設定する
     *
     * @param val 請求金額
     */
    public void setClmMoney(BigDecimal val) {
        set(Tbj22SeisakuhiSs.CLMMONEY, val);
    }

}
