package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * セキュリティ情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class SecurityInfoCondition
{
    /** 担当者ID */
    private String _hamid = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** セキュリティコード */
    private String _securitycd = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /**
     * デフォルトコンストラクタ
     */
    public SecurityInfoCondition()
    {
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid()
    {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid)
    {
        this._hamid = hamid;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUsertype()
    {
        return _usertype;
    }

    /**
     * ユーザ種別を設定する
     *
     * @param usertype ユーザ種別
     */
    public void setUsertype(String usertype)
    {
        this._usertype = usertype;
    }

    /**
     * セキュリティコードを取得する
     *
     * @return セキュリティコード
     */
    public String getSecuritycd()
    {
        return _securitycd;
    }

    /**
     * セキュリティコードを設定する
     *
     * @param securitycd セキュリティコード
     */
    public void setSecuritycd(String securitycd)
    {
        this._securitycd = securitycd;
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
