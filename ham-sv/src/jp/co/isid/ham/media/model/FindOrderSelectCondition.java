package jp.co.isid.ham.media.model;

import java.io.Serializable;

public class FindOrderSelectCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ԊJ�n */
    private String _kikanFrom;

    /** ���ԏI�� */
    private String _kikanTo;

    /** �S����ID */
    private String _hamid;

    /** ���ID */
    private String _formID;

    /**
     * ���ԊJ�n�擾
     * @return ���ԊJ�n
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * ���ԊJ�n�ݒ�
     * @param kikanFrom
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * ���ԏI���擾
     * @return
     */
    public String getKikanTo() {
        return _kikanTo;
    }

    /**
     * ���ԏI���ݒ�
     * @param kikanTo
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * ���[�UID�擾
     * @return ���[�UID
     */
    public String getHamId() {
        return _hamid;
    }

    /**
     * ���[�UID�ݒ�
     * @param hamid
     */
    public void setHamId(String hamid) {
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

}
