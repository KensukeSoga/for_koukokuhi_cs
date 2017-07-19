package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <P>
 * 素材一覧検索クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * ・JASRAC対応(2015/12/9 HLC K.Soga)<BR>
 * ・HDX対応(2016/11/11 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListCondition implements Serializable {

    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 担当者ID */
    private String _hamNm = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** フェイズ */
    private String _phase = null;

    /** 機能コード */
    private String _functionCd = null;

    /** 画面ID */
    private String _formid = null;

    /** 対象年月 */
    private String _ymDate = null;

    /** コピーモード */
    private boolean _copyMode = false;

    /** 車種コード */
    private String _dCarCd = null;

    /** 作成区分 */
    private String _recKbn = null;

    /** 作成番号 */
    private String _recNo = null;

    /** 2015/12/9 JASRAC対応 HLC K.Soga ADD Start */
    /** 10桁CMコード */
    private String _cmCd = null;

    /** 仮10桁CMコード */
    private String _tempCmCd = null;

    /** タイトル */
    private String _title = null;
    /** 2015/12/9 JASRAC対応 HLC K.Soga ADD End */

    /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
    /** 素材登録データ全件表示フラグ */
    private boolean _dispAllList = false;

    /** 素材登録データ全件表示用、現在年月日 */
    private String _dispAllListYmDate = null;
    /** 2016/04/12 HDX対応 HLC K.Soga ADD End */

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
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getHamNm() {
        return _hamNm;
    }

    /**
     * 担当者名を設定する
     *
     * @param hamid 担当者名
     */
    public void setHamNm(String val) {
        this._hamNm = val;
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
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     *
     * @param kksikognzuntcd 局コード
     */
    public void setKksikognzuntcd(String kksikognzuntcd) {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * 機能コードを設定します
     * @param val
     */
    public void setFunctionCd(String val) {
        _functionCd = val;
    }

    /**
     * 機能コードを取得します
     * @return
     */
    public String getFunctionCd() {
        return _functionCd;
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * 画面IDを設定する
     *
     * @param formid 画面ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * フェイズを設定します
     * @param val フェイズ
     */
    public void setPhase(String val) {
        _phase = val;
    }

    /**
     * フェイズを取得します
     * @return フェイズ
     */
    public String getPhase() {
        return _phase;
    }

    /**
     * 対象年月を設定します
     * @param val 対象年月
     */
    public void setYmDate(String val) {
        _ymDate = val;
    }

    /**
     * 対象年月を取得します
     * @return 対象年月
     */
    public String getYmDate() {
        return _ymDate;
    }

    /**
     * コピーモードを設定します
     * @param val
     */
    public void setCopyMode(boolean val) {
        _copyMode = val;
    }

    /**
     * コピーモードを取得します
     * @return
     */
    public boolean getCopyMode() {
        return _copyMode;
    }

    /**
     * 車種コードを設定します
     * @param val
     */
    public void setDCarCd(String val) {
        _dCarCd = val;
    }

    /**
     * 車種コードを取得します
     * @return
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * 作成区分を設定します
     * @return
     */
    public void setRecKbn(String val) {
        _recKbn = val;
    }

    /**
     * 作成区分を取得します
     * @return
     */
    public String getRecKbn() {
        return _recKbn;
    }

    /**
     * 作成番号を設定します
     * @param val
     */
    public void setRecNo(String val) {
        _recNo = val;
    }

    /**
     * 作成番号を取得します
     * @return
     */
    public String getRecNo() {
        return _recNo;
    }

    /** 2015/12/9 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 10桁CMコードを設定します
     * @param val
     */
    public void setCmCd(String val) {
        _cmCd = val;
    }

    /**
     * 10桁CMコードを取得します
     * @return
     */
    public String getCmCd() {
        return _cmCd;
    }

    /**
     * 仮10桁CMコードを設定します
     * @param val
     */
    public void setTempCmCd(String val) {
        _tempCmCd = val;
    }

    /**
     * 仮10桁CMコードを取得します
     * @return
     */
    public String getTempCmCd() {
        return _tempCmCd;
    }

    /**
     * タイトルを設定します
     * @param val
     */
    public void setTitle(String val) {
        _title = val;
    }

    /**
     * タイトルを取得します
     * @return
     */
    public String getTitle() {
        return _title;
    }
    /** 2015/12/9 JASRAC対応 HLC K.Soga ADD End */

    /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材登録データの全件表示を設定します
     * @param val
     */
    public void setDispAllList(boolean val) {
        _dispAllList = val;
    }

    /**
     * 素材登録データの全件表示を取得します
     * @return
     */
    public boolean getDispAllList() {
        return _dispAllList;
    }

    /**
     * 対象年月を設定します
     * @param val 対象年月
     */
    public void setDispAllListYmDate(String val) {
        _dispAllListYmDate = val;
    }

    /**
     * 対象年月を取得します
     * @return 対象年月
     */
    public String getDispAllListYmDate() {
        return _dispAllListYmDate;
    }
    /** 2016/04/12 HDX対応 HLC K.Soga ADD End */
}
