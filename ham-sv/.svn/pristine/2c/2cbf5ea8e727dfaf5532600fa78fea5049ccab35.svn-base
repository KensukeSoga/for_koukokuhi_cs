package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費　起動時データ取得の条件クラス
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
public class GetRepDataForCostMngCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 制作原価表(制作費明細)の出力有無(true:出力する、false:出力しない) */
    private boolean _outFlgGenkaMeisai = false;

    /** 制作原価表(統計情報)の出力有無(true:出力する、false:出力しない) */
    private boolean _outFlgGenkaToukei = false;

    /** 制作費表(制作費明細)の出力有無(true:出力する、false:出力しない) */
    private boolean _outFlgSeisakuMeisai = false;

    /** 制作費表(統計情報)の出力有無(true:出力する、false:出力しない) */
    private boolean _outFlgSeisakuToukei = false;

    /** フェイズ */
    private int _phase = 0;

    /** 年月(From) */
    private Date _fromDate = null;

    /** 年月(To) */
    private Date _toDate = null;

    /** 分類  */
    private String _classCd = null;

    /** 費目  */
    private String _exp = null;

    /** 車種リスト */
    private List<String> _carList = null;

    /** 入力担当者リスト */
    private List<String> _inputTntList = null;

    /** 入力担当者未入力対象フラグ */
    private boolean _inputTntNullFlg = false;

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
     * 制作原価表(制作費明細)の出力有無フラグを取得する
     *
     * @return outFlgGenkaMeisai
     */
    public boolean getOutFlgGenkaMeisai() {
        return _outFlgGenkaMeisai;
    }

    /**
     * 制作原価表(制作費明細)の出力有無フラグを設定する
     * @param outFlgGenkaMeisai 制作原価表(制作費明細)の出力有無フラグ
     */
    public void setOutFlgGenkaMeisai(boolean outFlgGenkaMeisai) {
        this._outFlgGenkaMeisai = outFlgGenkaMeisai;
    }

    /**
     * 制作原価表(統計情報)の出力有無フラグを取得する
     *
     * @return outFlgGenkaToukei
     */
    public boolean getOutFlgGenkaToukei() {
        return _outFlgGenkaToukei;
    }

    /**
     * 制作原価表(統計情報)の出力有無フラグを設定する
     * @param outFlgGenkaToukei 制作原価表(統計情報)の出力有無フラグ
     */
    public void setOutFlgGenkaToukei(boolean outFlgGenkaToukei) {
        this._outFlgGenkaToukei = outFlgGenkaToukei;
    }

    /**
     * 制作費表(制作費明細)の出力有無フラグを取得する
     *
     * @return outFlgSeisakuMeisai
     */
    public boolean getOutFlgSeisakuMeisai() {
        return _outFlgSeisakuMeisai;
    }

    /**
     * 制作費表(制作費明細)の出力有無フラグを設定する
     * @param outFlgSeisakuMeisai 制作費表(制作費明細)の出力有無フラグ
     */
    public void setOutFlgSeisakuMeisai(boolean outFlgSeisakuMeisai) {
        this._outFlgSeisakuMeisai = outFlgSeisakuMeisai;
    }

    /**
     * 制作費表(統計情報)の出力有無フラグを取得する
     *
     * @return outFlgSeisakuToukei
     */
    public boolean getOutFlgSeisakuToukei() {
        return _outFlgSeisakuToukei;
    }

    /**
     * 制作費表(統計情報)の出力有無フラグを設定する
     * @param outFlgSeisakuToukei 制作費表(統計情報)の出力有無フラグ
     */
    public void setOutFlgSeisakuToukei(boolean outFlgSeisakuToukei) {
        this._outFlgSeisakuToukei = outFlgSeisakuToukei;
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
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * 年月(From)を設定する
     * @param fromDate 年月(From)
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * 年月(To)を取得する
     *
     * @return 年月(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * 年月(To)を設定する
     * @param toDate 年月(To)
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * 分類を取得する
     *
     * @return classCd
     */
    public String getClassCd() {
        return _classCd;
    }

    /**
     * 分類を設定する
     * @param classCd 分類
     */
    public void setClassCd(String classCd) {
        this._classCd = classCd;
    }

    /**
     * 費目を取得する
     *
     * @return exp
     */
    public String getExp() {
        return _exp;
    }

    /**
     * 費目を設定する
     * @param exp 費目
     */
    public void setExp(String exp) {
        this._exp = exp;
    }

    /**
     * 車種リストを取得する
     *
     * @return carList
     */
    public List<String> getCarList() {
        return _carList;
    }

    /**
     * 車種リストを設定する
     * @param carList 車種リスト
     */
    public void setCarList(List<String> carList) {
        this._carList = carList;
    }

    /**
     * 入力担当者リストを取得する
     *
     * @return inputTntList
     */
    public List<String> getInputTntList() {
        return _inputTntList;
    }

    /**
     * 入力担当者リストを設定する
     * @param inputTntList 入力担当者リスト
     */
    public void setInputTntList(List<String> inputTntList) {
        this._inputTntList = inputTntList;
    }

    /**
     * 入力担当者未入力対象フラグを取得する
     *
     * @return inputTntList
     */
    public boolean getInputTntNullFlg() {
        return _inputTntNullFlg;
    }

    /**
     * 入力担当者未入力対象フラグを設定する
     * @param inputTntList 入力担当者未入力対象フラグ
     */
    public void setInputTntNullFlg(boolean inputTntNullFlg) {
        this._inputTntNullFlg =  inputTntNullFlg;
    }

}
