package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ƒZƒLƒ…ƒŠƒeƒBƒXƒvƒŒƒbƒhCondition
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/02/19 X)<BR>
 * </P>
 * @author X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceSecuritySpreadCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ’S“–ÒID */
    private String _HAMID = null;

    /**
     * ’S“–ÒID‚ğæ“¾‚·‚é
     *
     * @return ’S“–ÒID
     */
    public String getHAMID()
    {
        return _HAMID;
    }

    /**
     * ’S“–ÒID‚ğİ’è‚·‚é
     *
     * @param val ’S“–ÒID
     */
    public void setHAMID(String val)
    {
        _HAMID = val;
    }

}
