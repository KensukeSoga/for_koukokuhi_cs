package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;

/**
 * <P>
 * 車種担当(素材)スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/16 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")

public class MasterMaintenanceCarUserSozaiSpreadVO extends AbstractModel
{
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceCarUserSozaiSpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceCarUserSozaiSpreadVO();
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
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD()
    {
        return (String) get(Mbj52SzTntUser.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @return 電通車種コード
     */
    public void setDCARCD(String val)
    {
        set(Mbj52SzTntUser.DCARCD, val);
    }

    /**
     * 担当者SEQを取得する
     *
     * @return 担当者SEQ
     */
    public BigDecimal getUSERSEQ()
    {
        return (BigDecimal) get(Mbj52SzTntUser.USERSEQ);
    }

    /**
     * 担当者SEQを設定する
     *
     * @return 担当者SEQ
     */
    public void setUSERSEQ(BigDecimal val)
    {
        set(Mbj52SzTntUser.USERSEQ, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    public BigDecimal getSORTNO()
    {
        return (BigDecimal) get(Mbj52SzTntUser.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @return ソートNo
     */
    public void setSORTNO(BigDecimal val)
    {
        set(Mbj52SzTntUser.SORTNO, val);
    }
}
