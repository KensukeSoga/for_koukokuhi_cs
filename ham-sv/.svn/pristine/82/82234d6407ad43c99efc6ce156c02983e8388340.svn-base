package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * チェックリスト　データ取得の条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForChkListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 【業務会計】得意先コード */
    private String[] _tokuisakiCdList = null;

    /** 【業務会計】出力順（0:受注No、1:担当者） */
    private int _orderKbn = 0;

    /** 【業務会計】期間From */
    private Date _fromDate = null;

    /** 【業務会計】期間To */
    private Date _toDate = null;

    /** 【業務会計】発注局コード */
    private String[] _kyokuCdList = null;

    /** 【業務会計】担当者コード */
    private String[] _tntCdList = null;

    /** 【業務会系】営業日 */
    private String _eigyobi = null;


    /** フェイズ */
    private int _phase = 0;

    /** 年月(From) */
    private Date _fromSeikyuDate = null;

    /** 年月(To) */
    private Date _toSeikyuDate = null;

    /** 車種リスト */
    private String[] _carList = null;

    /**
     * 営業所コード
     */
    private String _egsCd = null;

    /**
     * 得意先コードを取得する
     *
     * @return 得意先コード
     */
    @XmlElement(required = true)
    public String[] getTokuisakiCdList() {
        return _tokuisakiCdList;
    }

    /**
     * 得意先コードを設定する
     *
     * @param tokuisakiCd 得意先コード
     */
    public void setTokuisakiCdList(String[] tokuisakiCdList) {
        this._tokuisakiCdList = tokuisakiCdList;
    }

    /**
     * 出力順を取得する
     *
     * @return 出力順
     */
    public int getOrderKbn() {
        return _orderKbn;
    }

    /**
     * 出力順を設定する
     *
     * @param orderKbn 出力順
     */
    public void setOrderKbn(int orderKbn) {
        this._orderKbn = orderKbn;
    }

    /**
     * 期間Fromを取得する
     *
     * @return 期間From
     */
    @XmlElement(required = true)
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * 期間Fromを設定する
     *
     * @param fromDate 期間From
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * 期間Toを取得する
     *
     * @return 期間To
     */
    @XmlElement(required = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * 期間Toを設定する
     *
     * @param toDate 期間To
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * 発注局コードを取得する
     *
     * @return 発注局コード
     */
    @XmlElement(required = true)
    public String[] getKyokuCdList() {
        return _kyokuCdList;
    }

    /**
     * 発注局コードを設定する
     *
     * @param kyokuCdList 発注局コード
     */
    public void setKyokuCdList(String[] kyokuCdList) {
        this._kyokuCdList = kyokuCdList;
    }

    /**
     * 担当者コードを取得する
     *
     * @return 担当者コード
     */
    @XmlElement(required = true)
    public String[] getTntCdList() {
        return _tntCdList;
    }

    /**
     * 担当者コードを設定する
     *
     * @param tntCdList 担当者コード
     */
    public void setTntCdList(String[] tntCdList) {
        this._tntCdList = tntCdList;
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
        _eigyobi = eigyobi;
    }

    /**
     * フェイズを取得する
     *
     * @return phase
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     * @param phase phase
     */
    public void setPhase(int phase) {
        this._phase = phase;
    }

    /**
     * 年月(From)を取得する
     *
     * @return fromDate
     */
    @XmlElement(required = true, nillable = true)
    public Date getFromSeikyuDate() {
        return _fromSeikyuDate;
    }

    /**
     * 年月(From)を設定する
     * @param fromDate 年月(From)
     */
    public void setFromSeikyuDate(Date fromSeikyuDate) {
        this._fromSeikyuDate = fromSeikyuDate;
    }

    /**
     * 年月(To)を取得する
     *
     * @return 年月(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getToSeikyuDate() {
        return _toSeikyuDate;
    }

    /**
     * 年月(To)を設定する
     * @param toDate 年月(To)
     */
    public void setToSeikyuDate(Date toSeikyuDate) {
        this._toSeikyuDate = toSeikyuDate;
    }

    /**
     * 車種リストを取得する
     *
     * @return carList
     */
    public String[] getCarList() {
        return _carList;
    }

    /**
     * 車種リストを設定する
     * @param carList 車種リスト
     */
    public void setCarList(String[] carList) {
        this._carList = carList;
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
