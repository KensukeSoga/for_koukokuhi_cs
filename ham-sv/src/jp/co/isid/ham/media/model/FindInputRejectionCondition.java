package jp.co.isid.ham.media.model;

import java.io.Serializable;
public class FindInputRejectionCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**�L�����y�[���R�[�h*/
    private String _campCd;

    /** �_�~�[�v���p�e�B */
    private String _dummy;
    /**
     * @return campCd
     */
    public String getCampCd() {
        return _campCd;
    }
    /**
     * @param campCd �Z�b�g���� campCd
     */
    public void setCampCd(String campCd) {
        this._campCd = campCd;
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