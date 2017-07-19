package jp.co.isid.ham.media.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj47Newspaper;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 送稿表(帳票)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/26 Fujiyoshi)<BR>
 * </P>
 * @author Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindDocTransReportVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 媒体略名称
     *
     * @return 媒体略名称
     */
    public String getRNAME() {
        return (String) get(Mbj47Newspaper.RNAME);
    }

    /**
     * 媒体略名称
     *
     * @param val 媒体略名称
     */
    public void setRNAME(String val) {
        set(Mbj47Newspaper.RNAME, val);
    }

    /**
     * エリア
     *
     * @return エリア
     */
    public String getAREA() {
        return (String) get(Mbj47Newspaper.AREA);
    }

    /**
     * エリア
     *
     * @param val エリア
     */
    public void setAREA(String val) {
        set(Mbj47Newspaper.AREA, val);
    }

    /**
     * 朝夕名
     *
     * @return 朝夕名
     */
    public String getNPDIVISIONNM() {
        return (String) get("NPDIVISIONNM");
    }

    /**
     * 朝夕名
     *
     * @param val 朝夕名
     */
    public void setNPDIVISIONNM(String val) {
        set("NPDIVISIONNM", val);
    }

    /**
     * 掲載版
     *
     * @return 掲載版
     */
    public String getPUBLISHVER() {
        return (String) get(Tbj02EigyoDaicho.PUBLISHVER);
    }

    /**
     * 掲載版
     *
     * @param val 掲載版
     */
    public void setPUBLISHVER(String val) {
        set(Tbj02EigyoDaicho.PUBLISHVER, val);
    }

    /**
     * 内容費目
     *
     * @return 内容費目
     */
    public String getNAIYOHIMOKU() {
        return (String) get(Tbj02EigyoDaicho.NAIYOHIMOKU);
    }

    /**
     * 内容費目
     *
     * @param val 内容費目
     */
    public void setNAIYOHIMOKU(String val) {
        set(Tbj02EigyoDaicho.NAIYOHIMOKU, val);
    }

    /**
     * スペース
     *
     * @return スペース
     */
    public String getSPACE() {
        return (String) get(Tbj02EigyoDaicho.SPACE);
    }

    /**
     * スペース
     *
     * @param val スペース
     */
    public void setSPACE(String val) {
        set(Tbj02EigyoDaicho.SPACE, val);
    }

    /**
     * 期間開始
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj02EigyoDaicho.KIKANFROM);
    }

    /**
     * 期間開始
     *
     * @param val 期間開始
     */
    public void setKIKANFROM(Date val) {
        set(Tbj02EigyoDaicho.KIKANFROM, val);
    }

    /**
     * 車種コード
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * 車種コード
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
    }

    /**
     * キャンペーン名
     *
     * @return キャンペーン名
     */
    public String getCAMPAIGN() {
        return (String) get(Tbj02EigyoDaicho.CAMPAIGN);
    }

    /**
     * キャンペーン名
     *
     * @param val キャンペーン名
     */
    public void setCAMPAIGN(String val) {
        set(Tbj02EigyoDaicho.CAMPAIGN, val);
    }

    /**
     * 媒体種別コード
     *
     * @return 媒体種別コード
     */
    public String getMEDIASCD() {
        return (String) get(Tbj02EigyoDaicho.MEDIASCD);
    }

    /**
     * 媒体種別コード
     *
     * @param val 媒体種別コード
     */
    public void setMEDIASCD(String val) {
        set(Tbj02EigyoDaicho.MEDIASCD, val);
    }
}
