package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC���i�I���}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCItemSelectionMstrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �g�p����R�[�h */
    private String _usebumoncd = null;

    /** ���ID */
    private String _formId;

    /** ��� */
    private String _funcType;

    /** HAM ID */
    private String _hamId = null;

    /**
     * �g�p����R�[�h���擾����
     *
     * @return �g�p����R�[�h
     */
    public String getUsebumoncd() {
        return _usebumoncd;
    }

    /**
     * �g�p����R�[�h��ݒ肷��
     *
     * @param usebumoncd �g�p����R�[�h
     */
    public void setUsebumoncd(String usebumoncd) {
        this._usebumoncd = usebumoncd;
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
