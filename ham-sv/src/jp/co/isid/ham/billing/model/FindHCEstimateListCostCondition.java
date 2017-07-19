package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC���ψꗗ(���쌴��)��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListCostCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

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
    private String _classDiv = null;

    /**
     * HAM ID
     */
    private String _hamId = null;

    /**
     * ���[�U�[���
     */
    private String _userType = null;


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
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getClassDiv() {
        return _classDiv;
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param classDiv ��ʔ��f�t���O
     */
    public void setClassDiv(String classDiv) {
        _classDiv = classDiv;
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

    /**
     * ���[�U�[��ʂ��擾����
     *
     * @return ���[�U�[���
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ���[�U�[��ʂ�ݒ肷��
     *
     * @param userType ���[�U�[���
     */
    public void setUserType(String userType) {
        _userType = userType;
    }
}
