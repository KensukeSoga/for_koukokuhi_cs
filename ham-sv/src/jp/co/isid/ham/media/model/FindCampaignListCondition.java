package jp.co.isid.ham.media.model;

import java.io.Serializable;

public class FindCampaignListCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private String _phase;

    /** �Ԏ� */
    private String _dCarCd;

    /**�Ԏ�̌�������(true:�S�Ԏ팟��.false:�쐬�ςݎԎ팟��) */
    private boolean _fullCar;

    /** �S����ID */
    private String _hamid = null;

    /** �L�����y�[���̂ݎ擾���邩�̔��f(true:�L�����y�[���̂�.false:�S��) */
    private boolean _campaignFlg;

    /**���ID*/
    private String _formId;

    /**FunctionType*/
    private String _functiontype;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;


    /**
     * @return phase
     */
    public String getPhase() {
        return _phase;
    }
    /**
     * @param phase �Z�b�g���� phase
     */
    public void setPhase(String phase) {
        this._phase = phase;
    }

    /**
     * @return dCarCd
     */
    public String getDCarCd() {
        return _dCarCd;
    }
    /**
     * @param dCarCd �Z�b�g���� dCarCd
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * @return _fullCar
     */
    public boolean getFullCar() {
        return _fullCar;
    }
    /**
     * @param fullCar �Z�b�g���� fullCar
     */
    public void setFullCar(boolean fullCar) {
        this._fullCar = fullCar;
    }

    /**
     * @return _campaignFlg
     */
    public boolean getCampaignFlg() {
        return _campaignFlg;
    }
    /**
     * @param campaignFlg �Z�b�g���� campaignFlg
     */
    public void setCampaignFlg(boolean campaignFlg) {
        this._campaignFlg = campaignFlg;
    }

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
     * @return formId
     */
    public String getFormID() {
        return _formId;
    }
    /**
     * @param formId �Z�b�g���� formId
     */
    public void setFormID(String formId) {
        this._formId = formId;
    }

    /**
     * @return FunctionType���擾����
     */
    public String getFunctionType() {
        return _functiontype;
    }
    /**
     * @param formId FunctionType���擾����
     */
    public void setFunctionType(String functiontype) {
        this._functiontype = functiontype;
    }

    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
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