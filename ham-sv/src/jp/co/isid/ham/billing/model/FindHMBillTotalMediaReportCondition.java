package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���v�������쐬(�}��)�擾��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillTotalMediaReportCondition implements Serializable {

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
     * @param val int �t�F�C�Y
     */
    public void setPhase(BigDecimal val) {
        _phase = val;
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
     * @param val String �N��
     */
    public void setYearMonth(String val) {
        _yearMonth = val;
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
     * @param val String ���ώ��
     */
    public void setEstimateClass(String val) {
        _estimateClass = val;
    }

}
