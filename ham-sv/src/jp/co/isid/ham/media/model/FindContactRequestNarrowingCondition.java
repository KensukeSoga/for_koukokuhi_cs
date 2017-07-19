package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * àÀóäêÊåüçıèåè
 * </P>
 * <P>
 * <B>èCê≥óöó</B><BR>
 * ÅEêVãKçÏê¨(2013/10/01 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestNarrowingCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    private String _jyuctype = null;

    private String _alasuseflg = null;

    private String _atsegsyocd = null;

    private String _jyucflg = null;

    private String _codeTypeEgsyoCd = null;


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

    public String getCODETYPEEGSYOCD() {
        return _codeTypeEgsyoCd;
    }

    public void setCODETYPEEGSYOCD(String codeTypeEgsyoCd) {
        _codeTypeEgsyoCd = codeTypeEgsyoCd;
    }
}
