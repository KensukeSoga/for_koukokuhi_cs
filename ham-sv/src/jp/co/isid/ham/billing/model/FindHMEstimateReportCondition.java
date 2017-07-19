package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���Ϗ��쐬��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private int _phase = 0;
    /** �N�� */
    private String _yearMonth = null;
    /** ���ώ�� */
    private String _estimateClass = null;
    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /** �J�n�� */
    private Date _startDate = null;
    /** �I���� */
    private Date _endDate = null;
    /** �d�ʎԎ�R�[�h */
    private String _dcarCd = null;
    /** �敪�R�[�h */
    private String _divCd = null;
    /** �O���[�v�R�[�h */
    private BigDecimal _groupCd = null;

    /**
     * �t�F�C�Y���擾����
     * @return int �t�F�C�Y
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param phase int �t�F�C�Y
     */
    public void setPhase(int phase) {
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

    /**
     * ���ψČ��Ǘ�NO���擾����
     * @return BigDecimal ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     * @param estSeqNo BigDecimal ���ψČ��Ǘ�NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        _estSeqNo = estSeqNo;
    }

    /**
     * �J�n�����擾����
     * @return Date �J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getStartDate() {
        return _startDate;
    }

    /**
     * �J�n����ݒ肷��
     * @param startDate Date �I����
     */
    public void setStartDate(Date startDate) {
        _startDate = startDate;
    }

    /**
     * �I�������擾����
     * @return Date �I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getEndDate() {
        return _endDate;
    }

    /**
     * �I������ݒ肷��
     * @param endDate Date �I����
     */
    public void setEndDate(Date endDate) {
        _endDate = endDate;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     * @return String �d�ʎԎ�R�[�h
     */
    public String getDCarCd() {
        return _dcarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     * @param dcarCd String �d�ʎԎ�R�[�h
     */
    public void setDCarCd(String dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * �敪�R�[�h���擾����
     * @return String �敪�R�[�h
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * �敪�R�[�h��ݒ肷��
     * @param divCd String �敪�R�[�h
     */
    public void setDivCd(String divCd) {
        _divCd = divCd;
    }

    /**
     * �O���[�v�R�[�h���擾����
     * @return BigDecimal �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     * @param groupCd BigDecimal �O���[�v�R�[�h
     */
    public void setGroupCd(BigDecimal groupCd) {
        _groupCd = groupCd;
    }

}
