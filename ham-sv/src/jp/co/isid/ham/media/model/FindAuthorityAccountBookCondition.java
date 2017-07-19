package jp.co.isid.ham.media.model;

import java.io.Serializable;


public class FindAuthorityAccountBookCondition implements Serializable {

    /** serialVersionUID */
   private static final long serialVersionUID = 1L;

    /** �}�̃R�[�h */
    private String _mediaCd;

    /** �Ԏ�R�[�h */
    private String _dCarCd;

    /** ���ԊJ�n */
    private String _kikanFrom;

    /** ���ԏI�� */
    private String _kikanTo;

    /** �}�̎�� */
    private String _mediasNm;

    /** �L�����y�[���� */
    private String _campNm;

    /** �S����ID */
    private String _hamid = null;

    /** ���ID */
    private String _formID;

    /** �V�[�gID */
    private String _viewID;

    /** ��� */
    private String _functype;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;

    /** �c�Ə��R�[�h */
    private String _egsyocd = null;

    /** �R�[�h�^�C�v(�c�Ə��R�[�h) */
    private String _codeTypeEgsyoCd = null;


    /**
     * @return mediaCd
     */
    public String getMediaCd() {
        return _mediaCd;
    }
    /**
     * @param mediaCd �Z�b�g���� mediaCd
     */
    public void setMediaCd(String mediaCd) {
        this._mediaCd = mediaCd;
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
     * @return kikanFrom
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }
    /**
     * @param kikanFrom �Z�b�g���� kikanFrom
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * @return kikanTo
     */
    public String getKikanTo() {
        return _kikanTo;
    }
    /**
     * @param kikanTo �Z�b�g���� kikanTo
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * @return mediasNm
     */
    public String getMediasNm() {
        return _mediasNm;
    }
    /**
     * @param mediasNm �Z�b�g���� mediasNm
     */
    public void setMediasNm(String mediasNm) {
        this._mediasNm = mediasNm;
    }

    /**
     * @return campNm
     */
    public String getCampNm() {
        return _campNm;
    }
    /**
     * @param campNm �Z�b�g���� campNm
     */
    public void setCampNm(String campNm) {
        this._campNm = campNm;
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
     * @return �V�[�gID
     */
    public String getViewID() {
        return _viewID;
    }

    /**
     * @param formID �V�[�gID
     */
    public void setViewID(String viewID) {
        _viewID = viewID;
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

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return �c�Ə��R�[�h
     */
    public String getEgsyocd()
    {
        return this._egsyocd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     *
     * @param egsyocd �c�Ə��R�[�h
     */
    public void setEgsyocd(String egsyocd)
    {
        this._egsyocd = egsyocd;
    }

    /**
     * �R�[�h�^�C�v(�c�Ə��R�[�h)���擾����
     *
     * @return �R�[�h�^�C�v(�c�Ə��R�[�h)
     */
    public String getCodetypeegsyocd() {
        return _codeTypeEgsyoCd;
    }

    /**
     * �R�[�h�^�C�v(�c�Ə��R�[�h)��ݒ肷��
     *
     * @param codeTypeEgsyoCd �R�[�h�^�C�v(�c�Ə��R�[�h)
     */
    public void setCodetypeegsyocd(String codeTypeEgsyoCd) {
        _codeTypeEgsyoCd = codeTypeEgsyoCd;
    }

}
