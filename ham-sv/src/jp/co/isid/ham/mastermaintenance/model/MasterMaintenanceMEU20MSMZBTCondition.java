package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * VG”}‘Ìƒ}ƒXƒ^Condition
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/11 X)<BR>
 * </P>
 * @author X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMEU20MSMZBTCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** VG‹æ•ª */
    private String _SZKBN = null;

    /**
     * VG‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return VG‹æ•ª
     */
    public String getSZKBN()
    {
        return _SZKBN;
    }

    /**
     * VG‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val VG‹æ•ª
     */
    public void setSZKBN(String val)
    {
        _SZKBN = val;
    }

}
