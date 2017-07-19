package jp.co.isid.ham.production.model;

import java.io.Serializable;

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
public class GetIniDataForCostManageCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** 担当者ID */
    private String _userid = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 画面ID */
    private String _formid = null;

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
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getUserid() {
        return _userid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param userid 担当者ID
     */
    public void setUserid(String userid) {
        this._userid = userid;
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

}
