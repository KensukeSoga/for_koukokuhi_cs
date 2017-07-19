package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM������(���ϖ��׏o�͏�SEQNO)�擾��������
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
public class FindHMBillSeqNoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** �N�� */
    private String _yearMonth = null;

    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
    /** �O���[�v�R�[�h */
    private BigDecimal _groupCd = null;

    /** �����敔��R�[�h */
    private String _hcbumoncdbill = null;

    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

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

    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
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
     * ������O���[�v���擾����
     *
     * @return ������O���[�v
     */
    public String getHcbumoncdbill() {
        return _hcbumoncdbill;
    }

    /**
     * ������O���[�v��ݒ肷��
     *
     * @param hcbumoncdbill ������O���[�v
     */
    public void setHcbumoncdbill(String hcbumoncdbill) {
        this._hcbumoncdbill = hcbumoncdbill;
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
    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
}