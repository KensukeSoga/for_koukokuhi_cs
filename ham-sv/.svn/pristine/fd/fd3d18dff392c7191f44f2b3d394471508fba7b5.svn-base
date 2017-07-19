package jp.co.isid.ham.menu.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * メインメニュー検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.menu.ham.isid.co.jp/")
@XmlType(namespace = "http://model.menu.ham.isid.co.jp/")
public class FindMainMenuCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HAMID */
    private String _hamid;

    /** 画面ID */
    private String _formid;

    /** 種別 */
    private String _functype;

    /** 名 */
    private String _firstname = null;

    /** 姓 */
    private String _lastname = null;

    /** 入力担当者 */
    private String _inputtntnm = null;

    /** 組織コード */
    private String _sikcd = null;

    /** フェイズ */
    private int _phase;

    /** 電通車種コード[全て] */
    private String _dcarcdAll = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** AM局判別フラグ(局コードがAM局のものかどうか) */
    private boolean _isAmKyk = false;


    /**
     * 担当者IDを取得する
     *
     * @return HAMID
     */
    public String getHamID() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamID HAMID
     */
    public void setHamID(String hamid) {
        _hamid = hamid;
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormID() {
        return _formid;
    }

    /**
     * 画面IDを設定する
     *
     * @param formID 画面ID
     */
    public void setFormID(String formid) {
        _formid = formid;
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getFuncType() {
        return _functype;
    }

    /**
     * 種別を設定する
     *
     * @param funcid 種別
     */
    public void setFuncType(String functype) {
        _functype = functype;
    }

    /**
     * 名を取得する
     *
     * @return 名
     */
    public String getFirstName() {
        return _firstname;
    }

    /**
     * 名を設定する
     *
     * @param firstname 名
     */
    public void setFirstName(String firstname) {
        _firstname = firstname;
    }

    /**
     * 姓を取得する
     *
     * @return 姓
     */
    public String getLastName() {
        return _lastname;
    }

    /**
     * 姓を設定する
     *
     * @param lastname 姓
     */
    public void setLastName(String lastname) {
        _lastname = lastname;
    }

    /**
     * 入力担当者名を取得する
     *
     * @return 入力担当者名
     */
    public String getInputIntNm() {
        return _inputtntnm;
    }

    /**
     * 入力担当者名を設定する
     *
     * @param inputtntnm 入力担当者名
     */
    public void setInputIntNm(String inputtntnm) {
        _inputtntnm = inputtntnm;
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
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 電通車種コード[全て]取得
     *
     * @return 電通車種コード[全て]
     */
    public String getDCarCdAll() {
        return _dcarcdAll;
    }

    /**
     * 電通車種コード[全て]設定
     *
     * @param dcarCdAll 電通車種コード[全て]
     */
    public void setDCarCdAll(String dcarCdAll) {
        _dcarcdAll = dcarCdAll;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ユーザ種別を設定する
     *
     * @param usertype ユーザ種別
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     *
     * @param kksikognzuntcd 局コード
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * AM局判別フラグを取得する
     *
     * @return AM局判別フラグ
     */
    @XmlTransient
    public boolean getIsAmKyk()
    {
        return _isAmKyk;
    }

    /**
     * AM局判別フラグを設定する
     *
     * @param isAmKyk AM局判別フラグ
     */
    public void setIsAmKyk(boolean isAmKyk)
    {
        this._isAmKyk = isAmKyk;
    }
}
