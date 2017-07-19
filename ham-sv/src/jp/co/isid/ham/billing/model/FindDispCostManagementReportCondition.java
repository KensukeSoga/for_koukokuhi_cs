package jp.co.isid.ham.billing.model;

import java.io.Serializable;

public class FindDispCostManagementReportCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** ���ID */
    private String _formID;

    /** ��� */
    private String _functype;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;


    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * @return ���ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * @param formID ���ID
     */
    public void setFormID(String formID) {
        _formID = formID;
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getFuncType() {
        return _functype;
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param funcid ���
     */
    public void setFuncType(String functype) {
        _functype = functype;
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
