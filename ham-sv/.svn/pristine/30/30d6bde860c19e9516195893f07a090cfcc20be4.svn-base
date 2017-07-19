package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費　検索実行時のデータ取得条件クラス
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
public class FindCrCreateDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 組織コード */
    private String _sikcd = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 年月 */
    private Date _crDate = null;

    /** 入力担当名 */
    private String _inputTntNm = null;

    /** 納品日(From) */
    private String _deliverDayFrom = null;

    /** 納品日(To) */
    private String _deliverDayTo = null;

    /** 受注未入力出力フラグ(True:未入力も出力 False：未入力は対象外) */
    private boolean _inputOrderFlg;

    /** 中止データ出力フラグ(True:中止データも出力 False:中止データは対象外) */
    private boolean _stpFlg;

    /** 未確認データのみ出力フラグ(True:未確認データのみ出力 False:未確認データ以外も出力) */
    private boolean _unConfFlg;

    /** 営業日 */
    private String _eigyobi = null;

    /**
     * 営業所コード
     */
    private String _egsCd = null;

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
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSikCd() {
        return _sikcd;
    }

    /**
     * 組織コードを設定する
     *
     * @param sikcd 組織コード
     */
    public void setSikCd(String sikcd) {
        _sikcd = sikcd;
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
     * @param dcarcd 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
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
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true)
    public Date getCrDate() {
        return _crDate;
    }

    /**
     * 年月を設定する
     *
     * @param crdate 年月
     */
    public void setCrDate(Date crDate) {
        this._crDate = crDate;
    }

    /**
     * 入力担当名を取得する
     *
     * @return 入力担当名
     */
    @XmlElement(required = true)
    public String getInputTntCd() {
        return _inputTntNm;
    }

    /**
     * 入力担当名を設定する
     *
     * @param inputTntNm 入力担当名
     */
    public void setInputTntCd(String inputTntNm) {
        this._inputTntNm = inputTntNm;
    }

    /**
     * 納品日(From)を取得する
     *
     * @return 納品日(From)
     */
    @XmlElement(required = true)
    public String getDeliverDayFrom() {
        return _deliverDayFrom;
    }

    /**
     * 納品日(From)を設定する
     *
     * @param deliverDayFrom 納品日(From)
     */
    public void setDeliverDayFrom(String deliverDayFrom) {
        this._deliverDayFrom = deliverDayFrom;
    }

    /**
     * 納品日(To)を取得する
     *
     * @return 納品日(To)
     */
    @XmlElement(required = true)
    public String getDeliverDayTo() {
        return _deliverDayTo;
    }

    /**
     * 納品日(To)を設定する
     *
     * @param deliverDayTo 納品日(To)
     */
    public void setDeliverDayTo(String deliverDayTo) {
        this._deliverDayTo = deliverDayTo;
    }

    /**
     * 受注未入力出力フラグを取得する
     *
     * @return 受注未入力出力フラグ
     */
    public boolean getInputOrderFlg() {
        return _inputOrderFlg;
    }

    /**
     * 受注未入力出力フラグを設定する
     *
     * @param inputorderflg 受注未入力出力フラグ
     */
    public void setInputOrderFlg(boolean inputOrderFlg) {
        this._inputOrderFlg = inputOrderFlg;
    }

    /**
     * 中止データ出力フラグを取得する
     *
     * @return 中止データ出力フラグ
     */
    public boolean getStpFlg() {
        return _stpFlg;
    }

    /**
     * 中止データ出力フラグを設定する
     *
     * @param stpFlg 中止データ出力フラグ
     */
    public void setStpFlg(boolean stpFlg) {
        this._stpFlg = stpFlg;
    }

    /**
     * 未確認データのみ出力フラグを取得する
     *
     * @return 未確認データのみ出力フラグ
     */
    public boolean getUnConfFlg() {
        return _unConfFlg;
    }

    /**
     * 未確認データのみ出力フラグを設定する
     *
     * @param unConfFlg 未確認データのみ出力フラグ
     */
    public void setUnConfFlg(boolean unConfFlg) {
        this._unConfFlg = unConfFlg;
    }

    /**
     * 営業日を取得する
     *
     * @return 営業日
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * 営業日を設定する
     *
     * @param eigyobi 営業日
     */
    public void setEigyobi(String eigyobi) {
        this._eigyobi = eigyobi;
    }

    /**
     * 営業所コードを取得する
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * 営業所コードを設定する
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }
}
