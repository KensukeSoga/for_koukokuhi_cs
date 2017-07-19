package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;

/**
 * <P>
 * 媒体権限スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMediaAuthoritySpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceMediaAuthoritySpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceMediaAuthoritySpreadVO();
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj10MediaSec.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val)
    {
        set(Mbj10MediaSec.HAMID, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD()
    {
        return (String) get(Mbj10MediaSec.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val)
    {
        set(Mbj10MediaSec.MEDIACD, val);
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMEDIANM()
    {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体名を設定する
     *
     * @param val 媒体名
     */
    public void setMEDIANM(String val)
    {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAUTHORITY()
    {
        return (String) get(Mbj10MediaSec.AUTHORITY);
    }

    /**
     * 権限を設定する
     *
     * @param val 権限
     */
    public void setAUTHORITY(String val)
    {
        set(Mbj10MediaSec.AUTHORITY, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj10MediaSec.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj10MediaSec.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM()
    {
        return (String) get(Mbj10MediaSec.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val)
    {
        set(Mbj10MediaSec.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj10MediaSec.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val)
    {
        set(Mbj10MediaSec.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj10MediaSec.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val)
    {
        set(Mbj10MediaSec.UPDID, val);
    }

}
