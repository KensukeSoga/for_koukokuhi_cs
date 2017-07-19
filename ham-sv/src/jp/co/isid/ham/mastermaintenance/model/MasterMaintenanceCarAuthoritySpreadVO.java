package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;

/**
 * <P>
 * 車種権限スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceCarAuthoritySpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceCarAuthoritySpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceCarAuthoritySpreadVO();
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getSECTYPE()
    {
        return (String) get(Mbj11CarSec.SECTYPE);
    }

    /**
     * 種別を設定する
     *
     * @param val 種別
     */
    public void setSECTYPE(String val)
    {
        set(Mbj11CarSec.SECTYPE, val);
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj11CarSec.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val)
    {
        set(Mbj11CarSec.HAMID, val);
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD()
    {
        return (String) get(Mbj11CarSec.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val)
    {
        set(Mbj11CarSec.DCARCD, val);
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM()
    {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val)
    {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAUTHORITY()
    {
        return (String) get(Mbj11CarSec.AUTHORITY);
    }

    /**
     * 権限を設定する
     *
     * @param val 権限
     */
    public void setAUTHORITY(String val)
    {
        set(Mbj11CarSec.AUTHORITY, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj11CarSec.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj11CarSec.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM()
    {
        return (String) get(Mbj11CarSec.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val)
    {
        set(Mbj11CarSec.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj11CarSec.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val)
    {
        set(Mbj11CarSec.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj11CarSec.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val)
    {
        set(Mbj11CarSec.UPDID, val);
    }

}
