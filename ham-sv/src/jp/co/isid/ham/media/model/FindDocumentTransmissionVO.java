package jp.co.isid.ham.media.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 送稿表(画面)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/20 Fujiyoshi)<BR>
 * </P>
 * @author Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindDocumentTransmissionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;


    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
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

    /**
     * キャンペーン名を取得する
     *
     * @return キャンペーン名
     */
    public String getCAMPAIGN() {
        return (String) get(Tbj02EigyoDaicho.CAMPAIGN);
    }

    /**
     * キャンペーン名を設定する
     *
     * @param val キャンペーン名
     */
    public void setCAMPAIGN(String val) {
        set(Tbj02EigyoDaicho.CAMPAIGN, val);
    }

    /**
     * 期間開始(キャンペーン)を取得する
     *
     * @return 期間開始(キャンペーン)
     */
    @XmlElement(required = true, nillable = true)
    public Date getTERMSTART() {
        return (Date) get("TERMSTART");
    }

    /**
     * 期間開始(キャンペーン)を設定する
     *
     * @param val 期間開始(キャンペーン)
     */
    public void setTERMSTART(Date val) {
        set("TERMSTART", val);
    }

    /**
     * 期間終了(キャンペーン)を取得する
     *
     * @return 期間終了(キャンペーン)
     */
    @XmlElement(required = true, nillable = true)
    public Date getTERMEND() {
        return (Date) get("TERMEND");
    }

    /**
     * 期間終了(キャンペーン)を設定する
     *
     * @param val 期間終了(キャンペーン)
     */
    public void setTERMEND(Date val) {
        set("TERMEND", val);
    }
}
