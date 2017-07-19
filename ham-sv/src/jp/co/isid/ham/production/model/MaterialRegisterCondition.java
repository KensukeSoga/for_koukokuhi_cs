package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <P>
 * 素材情報テーブル検索クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialRegisterCondition implements Serializable {

    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /**
     * 機能コード
     */
    private List<String> _functionCdList = null;

    /**
     * 10桁CMコード
     */
    private String _cmCd = null;

    /* 2015/11/24 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮10桁CMコード
     */
    private String _tempCmCd = null;
    /* 2015/11/24 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 10桁CMコードリスト
     */
    private List<String> _cmCdList = null;

    /** 画面ID */
    private String _formid = null;

    /**
     * 系統区分
     */
    private String _noKbn = null;

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
    public void setFunctionCdList(List<String> val) {
        _functionCdList = val;
    }

    /**
     * 機能コードを取得します
     * @return
     */
    public List<String> getFunctionCdList() {
        return _functionCdList;
    }

    /* 2015/11/24 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮10桁CMコードを設定します
     * @param val 仮10桁CMコード
     */
    public void setTempCmCd(String val) {
        _tempCmCd = val;
    }

    /**
     * 仮10桁CMコードを取得します
     * @return 仮10桁CMコード
     */
    public String getTempCmCd() {
        return _tempCmCd;
    }
    /* 2015/11/24 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 10桁CMコードを設定します
     * @param val 10桁CMコード
     */
    public void setCmCd(String val) {
        _cmCd = val;
    }

    /**
     * 10桁CMコードを取得します
     * @return 10桁CMコード
     */
    public String getCmCd() {
        return _cmCd;
    }

    /**
     * 10桁CMコードリストを設定します
     * @param val 10桁CMコードリスト
     */
    public void setCmCdList(List<String> val) {
        _cmCdList = val;
    }

    /**
     * 10桁CMコードリストを取得します
     * @return 10桁CMコードリスト
     */
    public List<String> getCmCdList() {
        return _cmCdList;
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
     * 系統区分を取得します
     * @return
     */
    public String getNoKbn() {
        return _noKbn;
    }

    /**
     * 系統区分を設定します
     * @param val
     * @return
     */
    public void setNoKbn(String val) {
        _noKbn = val;
    }
}
