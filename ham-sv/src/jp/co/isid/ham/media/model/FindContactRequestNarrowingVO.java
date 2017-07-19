package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 依頼先絞り込みVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/10/01 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestNarrowingVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindContactRequestNarrowingVO();
    }

    /**
     * 依頼先コード取得
     *
     * @return 依頼先コード
     */
    public String getIRAISAKICODE() {
        return (String) get("IRAISAKICODE");
    }

    /**
     * 依頼先コード設定
     *
     * @param val 依頼先コード
     */
    public void setIRAISAKICODE(String val) {
        set("IRAISAKICODE", val);
    }

    /**
     * 依頼先名取得
     *
     * @return 依頼先名
     */
    public String getIRAISAKINAME() {
        return (String) get("IRAISAKINAME");
    }

    /**
     * 依頼先名設定
     *
     * @param val 依頼先名
     */
    public void setIRAISAKINAME(String val) {
        set("IRAISAKINAME", val);
    }

    public String getDSIKKBNCD() {
        return (String) get("DSIKKBNCD");
    }

    public void setDSIKKBNCD(String val) {
        set("IRAISAKINAME", val);
    }

    public String getIRSKSHOWNO() {
        return (String) get("IRSKSHOWNO");
    }

    public void setIRSKSHOWNO(String val) {
        set("IRSKSHOWNO", val);
    }

    /**
     * 媒体種別コード取得
     *
     * @return 媒体種別コード
     */
    public String getMEDIASCD() {
        return (String) get("MEDIASCD");
    }

    /**
     * 媒体種別コード設定
     *
     * @param val 媒体種別コード
     */
    public void setMEDIASCD(String val) {
        set("MEDIASCD", val);
    }

    /**
     * ソート順取得
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get("SORTNO");
    }

    /**
     * ソート順設定
     * @param val ソート順
     */
    public void setSORTNO(BigDecimal val) {
        set("SORTNO", val);
    }
}
