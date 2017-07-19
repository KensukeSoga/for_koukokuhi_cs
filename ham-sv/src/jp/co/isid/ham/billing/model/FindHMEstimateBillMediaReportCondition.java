package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���Ϗ��A�������׏��A�������쐬(�}��)�擾��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateBillMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���Ϗ��A�������׏��������� */
    private FindHMEstimateMediaReportCondition _estimateCondition = null;
    /** �������������� */
    private FindHMBillMediaReportCondition _billCondition = null;
    /** ���Ϗ��o�̓t���O */
    private BigDecimal _estimateOutput = BigDecimal.valueOf(0);
    /** �������׏��o�̓t���O */
    private BigDecimal _billDetailOutput = BigDecimal.valueOf(0);
    /** �������o�̓t���O */
    private BigDecimal _billOutput = BigDecimal.valueOf(0);

    /**
     * ���Ϗ��A�������׏������������擾����
     * @return FindHMEstimateMediaReportCondition ���Ϗ��A�������׏���������
     */
    public FindHMEstimateMediaReportCondition getEstimateCondition() {
        return _estimateCondition;
    }

    /**
     * ���Ϗ��A�������׏�����������ݒ肷��
     * @param val FindHMEstimateMediaReportCondition ���Ϗ��A�������׏���������
     */
    public void setEstimateCondition(FindHMEstimateMediaReportCondition val) {
        _estimateCondition = val;
    }

    /**
     * �����������������擾����
     * @return FindHMBillMediaReportCondition ��������������
     */
    public FindHMBillMediaReportCondition getBillCondition() {
        return _billCondition;
    }

    /**
     * ����������������ݒ肷��
     * @param val FindHMBillMediaReportCondition ��������������
     */
    public void setBillCondition(FindHMBillMediaReportCondition val) {
        _billCondition = val;
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
     * �������׏��o�̓t���O���擾����
     * @return BigDecimal �������׏��o�̓t���O
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBillDetailOutput() {
        return _billDetailOutput;
    }

    /**
     * �������׏��o�̓t���O��ݒ肷��
     * @param val BigDecimal �������׏��o�̓t���O
     */
    public void setBillDetailOutput(BigDecimal val) {
        _billDetailOutput = val;
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
