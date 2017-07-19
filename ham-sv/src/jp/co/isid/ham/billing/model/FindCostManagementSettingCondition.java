package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �����ݒ茟������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCostManagementSettingCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private int _phase = 0;

    /** �N�� */
    private String _yearMonth = null;

    /** ���[�R�[�h */
    private String _reportCd = null;

    /** HAM ID */
    private String _hamId = null;

    /** ���ID */
    private String _formId;

    /** ��� */
    private String _funcType;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** ���[�U��� */
    private String _usertype = null;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;


    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(int phase) {
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
     * ���[�R�[�h���擾����
     *
     * @return ���[�R�[�h
     */
    public String getReportCd() {
        return _reportCd;
    }

    /**
     * ���[�R�[�h��ݒ肷��
     *
     * @param reportCd ���[�R�[�h
     */
    public void setReportCd(String reportCd) {
        _reportCd = reportCd;
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
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormId() {
        return _formId;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formID ���ID
     */
    public void setFormId(String formId) {
        _formId = formId;
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getFuncType() {
        return _funcType;
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param funcid ���
     */
    public void setFuncType(String functype) {
        _funcType = functype;
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param usertype ���[�U���
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * �Z�L�����e�B�R�[�h���擾����
     *
     * @return �Z�L�����e�B�R�[�h
     */
    public String getSecuritycd()
    {
        return _securitycd;
    }

    /**
     * �Z�L�����e�B�R�[�h��ݒ肷��
     *
     * @param securitycd �Z�L�����e�B�R�[�h
     */
    public void setSecuritycd(String securitycd)
    {
        this._securitycd = securitycd;
    }
}
