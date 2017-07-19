package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���Ϗ��A�������쐬(�}��)�擾��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�Ή�(2016/02/04 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** �N�� */
    private String _yearMonth = null;
    /** ���ώ�� */
    private String _estimateClass = null;

    /* 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
    /** �O���[�v�R�[�h */
    private BigDecimal _groupCd = null;

    /** ����SEQNO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /* 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

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

    /* 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
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

    /**
     * ����SEQNO���擾����
     * @return BigDecimal
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * ����SEQNO��ݒ肷��
     * @param estSeqNo BigDecimal ����SEQNO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        _estSeqNo = estSeqNo;
    }
    /* 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
}