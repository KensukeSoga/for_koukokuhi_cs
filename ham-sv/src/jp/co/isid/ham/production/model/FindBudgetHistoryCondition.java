package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 車種別予算表　検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindBudgetHistoryCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** (フェイズの)開始日付 */
    private Date _sDate = null;

    /** (フェイズの)終了日付 */
    private Date _eDate = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** 予算分類コード */
    private String _classcd = null;

    /** 予算表費目コード */
    private String _expcd = null;

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true)
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
     * (フェイズの)開始日付を取得する
     *
     * @return (フェイズの)開始日付
     */
    @XmlElement(required = true)
    public Date getSDate() {
        return _sDate;
    }

    /**
     * (フェイズの)開始日付を設定する
     *
     * @param sDate (フェイズの)開始日付
     */
    public void setSDate(Date sDate) {
        this._sDate = sDate;
    }

    /**
     * (フェイズの)終了日付を取得する
     *
     * @return (フェイズの)終了日付
     */
    @XmlElement(required = true)
    public Date getEDate() {
        return _eDate;
    }

    /**
     * (フェイズの)終了日付を設定する
     *
     * @param phase (フェイズの)終了日付
     */
    public void setEDate(Date eDate) {
        this._eDate = eDate;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dCar 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * 予算分類コードを取得する
     *
     * @return 予算分類コード
     */
    public String getClasscd() {
        return _classcd;
    }

    /**
     * 予算分類コードを設定する
     *
     * @param classcd 予算分類コード
     */
    public void setClasscd(String classcd) {
        this._classcd = classcd;
    }

    /**
     * 予算表費目コードを取得する
     *
     * @return 予算表費目コード
     */
    public String getExpcd() {
        return _expcd;
    }

    /**
     * 予算表費目コードを設定する
     *
     * @param expcd 予算表費目コード
     */
    public void setExpcd(String expcd) {
        this._expcd = expcd;
    }
}
