package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC���ψꗗ(���ψČ�)��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListItemCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �R�[�h�^�C�v
     */
    private String _codeType = null;

    /**
     * �t�F�C�Y
     */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /**
     * �N��
     */
    private String _yearMonth = null;

    /**
     * ��ʔ��f�t���O
     */
    private String _estimateClass = null;

    /**
     * ���ψČ��Ǘ�NO
     */
    private BigDecimal _estSeqNo = null;

    /**
     * HAM ID
     */
    private String _hamId = null;


    /**
     * �R�[�h�^�C�v���擾���܂�
     *
     * @return �R�[�h�^�C�v
     */
    public String getCodeType() {
        return _codeType;
    }

    /**
     * �R�[�h�^�C�v��ݒ肵�܂�
     *
     * @param codeType �R�[�h�^�C�v
     */
    public void setCodeType(String codeType) {
        _codeType = codeType;
    }

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
     * ���ώ�ʂ��擾����
     *
     * @return ���ώ�ʃt���O
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * ���ώ�ʃt���O��ݒ肷��
     *
     * @param estimateClass ���ώ�ʃt���O
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
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
     * HAM ID���擾����
     *
     * @return HAM ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * HAM ID��ݒ肷��
     *
     * @param hamId HAM ID
     */
    public void setHamId(String hamId) {
        _hamId = hamId;
    }
}
