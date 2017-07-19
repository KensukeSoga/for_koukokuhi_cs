package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 制作原価変更点取得
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindProductionChangeCheckCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase;

    /** 期間開始 */
    private Date _dateS;

    /** 期間終了 */
    private Date _dateE;

    /** 制作費管理No */
    private BigDecimal _estDetailSeqNo;

    /** 画面ID */
    private String _formID;

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * 期間開始を取得する
     * @return
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateS() {
        return _dateS;
    }

    /**
     * 期間開始を設定する
     * @param phase
     */
    public void setDateS(Date dateS) {
        this._dateS = dateS;
    }

    /**
     * 期間終了を取得する
     * @return
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateE() {
        return _dateE;
    }

    /**
     * 期間終了を設定する
     * @param phase
     */
    public void setDateE(Date dateE) {
        this._dateE = dateE;
    }

    /**
     * 制作費管理NOを取得する
     * @return
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstDetailSeqNo() {
        return _estDetailSeqNo;
    }

    /**
     * 制作費管理NOを設定する
     * @param estDetailSeqNo
     */
    public void setEstDetailSeqNo(BigDecimal estDetailSeqNo) {
        this._estDetailSeqNo = estDetailSeqNo;
    }

    /**
     * @return 画面ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * @param formID 画面ID
     */
    public void setFormID(String formID) {
        _formID = formID;
    }
}
