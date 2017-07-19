package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ˆË—ŠæŒŸõğŒ
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/08/02 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    private String _jyuctype = null;

    private String _alasuseflg = null;

    private String _atsegsyocd = null;

    private String _jyucflg = null;


    public String getJYUCTYPE() {
        return _jyuctype;
    }

    public void setJYUCTYPE(String jyuctype) {
        _jyuctype = jyuctype;
    }

    public String getALASUSEFLG() {
        return _alasuseflg;
    }

    public void setALASUSEFLG(String alasuseflg) {
        _alasuseflg = alasuseflg;
    }

    public String getATSEGSYOCD() {
        return _atsegsyocd;
    }

    public void setATSEGSYOCD(String atsegsyocd) {
        _atsegsyocd = atsegsyocd;
    }

    public String getJYUCFLG() {
        return _jyucflg;
    }

    public void setJYUCFLG(String jyucflg) {
        _jyucflg = jyucflg;
    }
}
