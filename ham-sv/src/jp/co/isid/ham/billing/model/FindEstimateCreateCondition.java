package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * Œ©ÏˆÄŒCR§ì”ïŒŸõğŒ
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindEstimateCreateCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** Œ©Ï–¾×ŠÇ—NO */
    List<BigDecimal> _estDetailSeqNo;

    /**
     * Œ©Ï–¾×ŠÇ—NO‚ğæ“¾‚·‚é
     *
     * @return Œ©Ï–¾×ŠÇ—NO
     */
    public List<BigDecimal> getEstDetailSeqNo() {
        return _estDetailSeqNo;
    }

    /**
     * Œ©Ï–¾×ŠÇ—NO‚ğİ’è‚·‚é
     *
     * @param estDetailSeqNo Œ©Ï–¾×ŠÇ—NO
     */
    public void setEstDetailSeqNo(List<BigDecimal> estDetailSeqNo) {
        _estDetailSeqNo = estDetailSeqNo;
    }

}
