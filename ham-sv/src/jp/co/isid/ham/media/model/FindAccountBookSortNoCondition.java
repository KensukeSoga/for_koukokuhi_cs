package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlElement;

public class FindAccountBookSortNoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ”}‘ÌŠÇ—No */
    private BigDecimal _mediaplanno;


    /**
     * @return ”}‘ÌŠÇ—No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAPLANNO() {
        return _mediaplanno;
    }
    /**
     * @param ”}‘ÌŠÇ—No
     */
    public void setMEDIAPLANNO(BigDecimal mediaplanno) {
        this._mediaplanno = mediaplanno;
    }
}
