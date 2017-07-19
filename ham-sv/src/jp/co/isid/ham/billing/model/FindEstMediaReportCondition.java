package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���Ϗ��A����CSV�t�@�C���쐬(�}��)��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/5/8 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindEstMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** �N�� */
    private String _yearMonth = null;
    /** ���ώ�� */
    private String _estimateClass = null;

    /**
     * �t�F�C�Y���擾����
     * @return int �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param phase int �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * �N�����擾����
     * @return String �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     * @param yearMonth String �N��
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * ���ώ�ʂ��擾����
     * @return String ���ώ��
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * ���ώ�ʂ�ݒ肷��
     * @param estimateClass String ���ώ��
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
    }

}
