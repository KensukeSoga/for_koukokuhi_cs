package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj02User;

/**
 * <P>
 * 担当者スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceUserSpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ログイン担当者ID */
    private String _LOGINHAMID = null;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceUserSpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceUserSpreadVO();
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj02User.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val)
    {
        set(Mbj02User.HAMID, val);
    }

    /**
     * 担当者姓を取得する
     *
     * @return 担当者姓
     */
    public String getUSERNAME1()
    {
        return (String) get(Mbj02User.USERNAME1);
    }

    /**
     * 担当者姓を設定する
     *
     * @param val 担当者姓
     */
    public void setUSERNAME1(String val)
    {
        set(Mbj02User.USERNAME1, val);
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getUSERNAME2()
    {
        return (String) get(Mbj02User.USERNAME2);
    }

    /**
     * 担当者名を設定する
     *
     * @param val 担当者名
     */
    public void setUSERNAME2(String val)
    {
        set(Mbj02User.USERNAME2, val);
    }

    /**
     * ログイン担当者IDを取得する
     *
     * @return ログイン担当者ID
     */
    public String getLOGINHAMID()
    {
        return _LOGINHAMID;
    }

    /**
     * ログイン担当者IDを設定する
     *
     * @param val ログイン担当者ID
     */
    public void setLOGINHAMID(String val)
    {
        _LOGINHAMID = val;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUSERTYPE()
    {
        return (String) get(Mbj02User.USERTYPE);
    }

    /**
     * ユーザ種別を設定する
     *
     * @param val ユーザ種別
     */
    public void setUSERTYPE(String val)
    {
        set(Mbj02User.USERTYPE, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj02User.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj02User.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM()
    {
        return (String) get(Mbj02User.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val)
    {
        set(Mbj02User.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj02User.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val)
    {
        set(Mbj02User.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj02User.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val)
    {
        set(Mbj02User.UPDID, val);
    }

}
