package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
/**
 * <P>
 * 営業作業台帳帳票検索クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/20 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindBillStatementCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 期間開始 */
    private String _kikanFrom = null;

    /** 期間終了 */
    private String _kikanTo = null;

    /** 担当者ID */
    private String _hamid = null;

    /** 取得フラグ */
    private boolean _loadFlg;

    /** 種別 */
    private String _functype;

    /** 画面ID */
    private String _formID;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * 期間開始を設定する
     *
     * @param seikyuym 期間開始
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    public String getKikanTo() {
        return _kikanTo;
    }

    /**
     * 期間終了を設定する
     *
     * @param seikyuym 期間終了
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

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
     * フォームロードフラグを取得
     * @return
     */
    public boolean getLoadFlg() {
        return _loadFlg;
    }

    /**
     * フォームロードフラグを設定
     * @param loadFlg
     */
    public void setLoadFlg(boolean loadFlg) {
        this._loadFlg = loadFlg;
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

}
