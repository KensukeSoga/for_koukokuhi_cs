package jp.co.isid.ham.media.model;

import java.io.Serializable;

public class FindCampaignDetailsCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private String _campaignNo;

    /**�e�[�u���S�擾�t���O (true:�e�[�u������,false:�}�X�^�ƕR�t����)*/
    private boolean _tbj13AllSelectFlg;

    /**hamId*/
    private String _hamId;

    /**���ID*/
    private String _formId;

    /**FunctionType*/
    private String _functiontype;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �L�����y�[���̃Z�L�����e�B�R�[�h */
    private String _campseccd = null;

    /** �}�̏󋵊Ǘ��̃Z�L�����e�B�R�[�h */
    private String _mediaplanseccd = null;

    /** �_�~�[�v���p�e�B */
    private String _dummy;


    /**
     * @return _campaignNo
     */
    public String getCampaignNo() {
        return _campaignNo;
    }
    /**
     * @param campaignNo �Z�b�g���� campaignNo
     */
    public void setCampaignNo(String campaignNo) {
        this._campaignNo = campaignNo;
    }

    /**
     * @return _tbj13AllSelectFlg
     */
    public boolean getTbj13AllSelectFlg() {
        return _tbj13AllSelectFlg;
    }
    /**
     * @param tbj13AllSelectFlg �Z�b�g���� tbj13AllSelectFlg
     */
    public void setTbj13AllSelectFlg(boolean tbj13AllSelectFlg) {
        this._tbj13AllSelectFlg = tbj13AllSelectFlg;
    }


    /**
     * @return formId
     */
    public String getFormId() {
        return _formId;
    }
    /**
     * @param formId �Z�b�g���� formId
     */
    public void setFormId(String formId) {
        this._formId = formId;
    }

    /**
     * @return hamId
     */
    public String getHamId() {
        return _hamId;
    }
    /**
     * @param hamId �Z�b�g���� hamId
     */
    public void setHamId(String hamId) {
        this._hamId = hamId;
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
     * �L�����y�[���̃Z�L�����e�B�R�[�h���擾����
     *
     * @return �L�����y�[���̃Z�L�����e�B�R�[�h
     */
    public String getCampaignSecuritycd()
    {
        return _campseccd;
    }

    /**
     * �L�����y�[���̃Z�L�����e�B�R�[�h��ݒ肷��
     *
     * @param campseccd �L�����y�[���̃Z�L�����e�B�R�[�h
     */
    public void setCampaignSecuritycd(String campseccd)
    {
        this._campseccd = campseccd;
    }

    /**
     * �}�̏󋵊Ǘ��̃Z�L�����e�B�R�[�h���擾����
     *
     * @return �}�̏󋵊Ǘ��̃Z�L�����e�B�R�[�h
     */
    public String getMediaPlanSecuritycd()
    {
        return _mediaplanseccd;
    }

    /**
     * �}�̏󋵊Ǘ��̃Z�L�����e�B�R�[�h��ݒ肷��
     *
     * @param mediaplanseccd �}�̏󋵊Ǘ��̃Z�L�����e�B�R�[�h
     */
    public void setMediaPlanSecuritycd(String mediaplanseccd)
    {
        this._mediaplanseccd = mediaplanseccd;
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
}