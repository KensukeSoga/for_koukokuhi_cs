package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;

public class UpdABOrderOutRegisterVO implements Serializable{


    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �X�V�pVO */
    private List<Tbj02EigyoDaichoVO> _updVo;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /**
     * @return updVo
     */
    public List<Tbj02EigyoDaichoVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo �Z�b�g���� updVo
     */
    public void setUpdVo(List<Tbj02EigyoDaichoVO> updVo) {
        this._updVo = updVo;
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
