package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj43SecurityItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * セキュリティ情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class SecurityInfoVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public SecurityInfoVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new SecurityInfoVO();
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj42Security.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val)
    {
        set(Mbj42Security.HAMID, val);
    }

    /**
     * セキュリティコードを取得する
     *
     * @return セキュリティコード
     */
    public String getSECURITYCD()
    {
        return (String) get(Mbj42Security.SECURITYCD);
    }

    /**
     * セキュリティコードを設定する
     *
     * @param val セキュリティコード
     */
    public void setSECURITYCD(String val)
    {
        set(Mbj42Security.SECURITYCD, val);
    }

    /**
     * セキュリティ種別を取得する
     *
     * @return セキュリティ種別
     */
    public String getSECURITYTYPE()
    {
        return (String) get(Mbj42Security.SECURITYTYPE);
    }

    /**
     * セキュリティ種別を設定する
     *
     * @param val セキュリティ種別
     */
    public void setSECURITYTYPE(String val)
    {
        set(Mbj42Security.SECURITYTYPE, val);
    }

    /**
     * セキュリティ名を取得する
     *
     * @return セキュリティ名
     */
    public String getSECURITYNM()
    {
        return (String) get(Mbj43SecurityItem.SECURITYNM);
    }

    /**
     * セキュリティ名を設定する
     *
     * @param val セキュリティ名
     */
    public void setSECURITYNM(String val)
    {
        set(Mbj43SecurityItem.SECURITYNM, val);
    }

    /**
     * 登録・更新を取得する
     *
     * @return 登録・更新
     */
    public String getUPDATE()
    {
        return (String) get(Mbj42Security.UPDATE);
    }

    /**
     * 登録・更新を設定する
     *
     * @param val 登録・更新
     */
    public void setUPDATE(String val)
    {
        set(Mbj42Security.UPDATE, val);
    }

    /**
     * 確認を取得する
     *
     * @return 確認
     */
    public String getCHECK()
    {
        return (String) get(Mbj42Security.CHECK);
    }

    /**
     * 確認を設定する
     *
     * @param val 確認
     */
    public void setCHECK(String val)
    {
        set(Mbj42Security.CHECK, val);
    }

    /**
     * 参照を取得する
     *
     * @return 参照
     */
    public String getREFERENCE()
    {
        return (String) get(Mbj42Security.REFERENCE);
    }

    /**
     * 参照を設定する
     *
     * @param val 参照
     */
    public void setREFERENCE(String val)
    {
        set(Mbj42Security.REFERENCE, val);
    }

}
