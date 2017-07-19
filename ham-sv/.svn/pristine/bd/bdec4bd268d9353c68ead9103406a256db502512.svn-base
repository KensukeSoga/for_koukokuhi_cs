package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj23CarTanto;
import jp.co.isid.ham.integ.tbl.Mbj05Car;

/**
 * <P>
 * 車種担当スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceCarUserSpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceCarUserSpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceCarUserSpreadVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD()
    {
        return (String) get(Mbj05Car.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val)
    {
        set(Mbj05Car.DCARCD, val);
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
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(nillable=true)
    public BigDecimal getSORTNO()
    {
        return (BigDecimal) get(Mbj05Car.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val)
    {
        set(Mbj05Car.SORTNO, val);
    }

    /**
     * 媒体担当者を取得する
     *
     * @return 媒体担当者
     */
    public String getMEDIATANTO()
    {
        return (String) get(Mbj23CarTanto.MEDIATANTO);
    }

    /**
     * 媒体担当者を設定する
     *
     * @param val 媒体担当者
     */
    public void setMEDIATANTO(String val)
    {
        set(Mbj23CarTanto.MEDIATANTO, val);
    }

    /**
     * 制作担当者を取得する
     *
     * @return 制作担当者
     */
    public String getCRTANTO()
    {
        return (String) get(Mbj23CarTanto.CRTANTO);
    }

    /**
     * 制作担当者を設定する
     *
     * @param val 制作担当者
     */
    public void setCRTANTO(String val)
    {
        set(Mbj23CarTanto.CRTANTO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj23CarTanto.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj23CarTanto.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM()
    {
        return (String) get(Mbj23CarTanto.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val)
    {
        set(Mbj23CarTanto.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj23CarTanto.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val)
    {
        set(Mbj23CarTanto.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj23CarTanto.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val)
    {
        set(Mbj23CarTanto.UPDID, val);
    }

}
