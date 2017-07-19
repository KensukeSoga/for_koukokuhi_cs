package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 契約情報登録画面起動時データ取得の条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractRegisterCondition implements Serializable {
    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 契約種類*/
    private String strCtrtKbn;
    /** 契約コード*/
    private String strCtrtNo;
    /** 担当者ID */
    private String _strHamid ;
    /** 機能コード*/
    private List<String> _strSecurityCdList;
    /** 契約種類*/
    //private boolean strContract;
    /** 画面ID */
    private String _formid = null;
    /** 担当者ID */
    private String _hamid = null;
    /** ユーザ種別 */
    private String _usertype = null;
    /** 局コード */
    private String _kksikognzuntcd = null;

    /** 契約種類*/
    public void setStrCtrtKbn(String strCtrtKbn) {
        this.strCtrtKbn = strCtrtKbn;
    }
    public String getStrCtrtKbn() {
        return strCtrtKbn;
    }

    /** 契約コード*/
    public void setStrCtrtNo(String strCtrtNo) {
        this.strCtrtNo = strCtrtNo;
    }
    public String getStrCtrtNo() {
        return strCtrtNo;
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getStrHamid() {
        return _strHamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param strHamid 担当者ID
     */
    public void setStrHamid(String strHamid) {
        this._strHamid = strHamid;
    }

    /** セキュリティコード*/
    public void setStrSecurityCdList(List<String> strSecurityCdList) {
        this._strSecurityCdList = strSecurityCdList;
    }
    public List<String> getStrSecurityCdList() {
        return _strSecurityCdList;
    }

//    /** 契約種類*/
//    public void setStrContract(boolean strContract) {
//        this.strContract = strContract;
//    }
//    public boolean getStrContract() {
//        return strContract;
//    }

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


}
