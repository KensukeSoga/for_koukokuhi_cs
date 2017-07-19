package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 制作費データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCreateCostVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCreateCostVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindCreateCostVO();
    }

    /**
     * 制作費の合計を取得します
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMSEISAKUHIS() {
        return (BigDecimal) get("SUMSEISAKUHIS");
    }

    /**
     * 制作費の合計を設定します
     */
    public void setSUMSEISAKUHIS(BigDecimal val) {
        set("SUMSEISAKUHIS", val);
    }

    /**
     * 請求月を取得する
     *
     * @return 請求月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj21Seisakuhi.SEIKYUYM);
    }

    /**
     * 請求月を設定する
     *
     * @param val 請求月
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj21Seisakuhi.SEIKYUYM, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj21Seisakuhi.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj21Seisakuhi.DCARCD, val);
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
}
