package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���ϖ��׎擾��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindEstimateDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** �N�� */
    private String _yearMonth = null;

    /** HC����R�[�h */
    private String _hcBumonCd = null;

    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estSeqNo = null;


    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     *
     * @param yearMonth �N��
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     *
     * @param estSeqNo ���ψČ��Ǘ�NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        this._estSeqNo = estSeqNo;
    }

    /**
     * HC����R�[�h���擾����
     *
     * @return HC����R�[�h
     */
    public String getHcBumonCd() {
        return _hcBumonCd;
    }

    /**
     * HC����R�[�h��ݒ肷��
     *
     * @param hcBumonCd HC����R�[�h
     */
    public void setHcBumonCd(String hcBumonCd) {
        _hcBumonCd = hcBumonCd;
    }
}
