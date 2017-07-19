package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * Œ ŒÀ•t‚«Ôíƒ}ƒXƒ^æ“¾ğŒƒNƒ‰ƒX
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/03/27 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCarListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = -1626802308467753490L;

    /** ’S“–ÒID */
    private String _hamid = null;

    /** í•Ê */
    private String _secType = null;

    /**
     * ’S“–ÒID‚ğæ“¾‚·‚é.
     * @return ’S“–ÒID
     */
    @XmlElement(required = true)
    public String get_hamid() {
        return _hamid;
    }

    /**
     * ’S“–ÒID‚ğİ’è‚·‚é.
     * @param hamid ’S“–ÒID
     */
    public void set_hamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * í•Ê‚ğæ“¾‚·‚é.
     * @return í•Ê
     */
    @XmlElement(required = true)
    public String get_secType() {
        return _secType;
    }

    /**
     * í•Ê‚ğİ’è‚·‚é.
     * @param secType í•Ê
     */
    public void set_secType(String secType) {
        this._secType = secType;
    }


}
