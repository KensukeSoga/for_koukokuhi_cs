package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���Ϗ�(����)�쐬��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateBillReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���Ϗ��������� */
    private FindHMEstimateReportCondition _hmEstimateCondition = null;
    /** �������������� */
    private FindHMBillReportCondition _hmBillCondition = null;
    /** ���Ϗ��o�̓t���O */
    private BigDecimal _estimateOutput = BigDecimal.valueOf(0);
    /** �������o�̓t���O */
    private BigDecimal _billOutput = BigDecimal.valueOf(0);

    /**
     * ���Ϗ������������擾����
     * @return FindHMEstimateReportCondition ���Ϗ���������
     */
    public FindHMEstimateReportCondition getHMEstimateCondition() {
        return _hmEstimateCondition;
    }

    /**
     * ���Ϗ�����������ݒ肷��
     * @param val FindHMEstimateReportCondition ���Ϗ���������
     */
    public void setHMEstimateCondition(FindHMEstimateReportCondition val) {
        _hmEstimateCondition = val;
    }

    /**
     * �����������������擾����
     * @return FindHMBillReportCondition ��������������
     */
    public FindHMBillReportCondition getHMBillCondition() {
        return _hmBillCondition;
    }

    /**
     * ����������������ݒ肷��
     * @param val FindHMBillReportCondition ��������������
     */
    public void setHMBillCondition(FindHMBillReportCondition val) {
        _hmBillCondition = val;
    }

    /**
     * ���Ϗ��o�̓t���O���擾����
     * @return BigDecimal ���Ϗ��o�̓t���O
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstimateOutput() {
        return _estimateOutput;
    }

    /**
     * ���Ϗ��o�̓t���O��ݒ肷��
     * @param val BigDecimal ���Ϗ��o�̓t���O
     */
    public void setEstimateOutput(BigDecimal val) {
        _estimateOutput = val;
    }

    /**
     * �������o�̓t���O���擾����
     * @return BigDecimal �������o�̓t���O
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBillOutput() {
        return _billOutput;
    }

    /**
     * �������o�̓t���O��ݒ肷��
     * @param val BigDecimal �������o�̓t���O
     */
    public void setBillOutput(BigDecimal val) {
        _billOutput = val;
    }

}
