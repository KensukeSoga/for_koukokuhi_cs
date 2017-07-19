package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体コストデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindMediaCostVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaCostVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMediaCostVO();
    }

    /**
     * グロス料金の合計を取得します
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMGROSS() {
        return (BigDecimal) get("SUMGROSS");
    }

    /**
     * グロス料金の合計を設定します
     */
    public void setSUMGROSS(BigDecimal val) {
        set("SUMGROSS", val);
    }

    /**
     * 新料金（HMコスト）の合計を取得します
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMHMCOST() {
        return (BigDecimal) get("SUMHMCOST");
    }

    /**
     * 新料金（HMコスト）の合計を設定します
     */
    public void setSUMHMCOST(BigDecimal val) {
        set("SUMHMCOST", val);
    }

    /**
     * 請求年月を取得する
     *
     * @return 請求年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj02EigyoDaicho.SEIKYUYM);
    }

    /**
     * 請求年月を設定する
     *
     * @param val 請求年月
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj02EigyoDaicho.SEIKYUYM, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj02EigyoDaicho.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj02EigyoDaicho.MEDIACD, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体名を設定する
     *
     * @param val 媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
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
