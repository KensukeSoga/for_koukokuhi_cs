package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;

public class UpdABOrderOutRegisterVO implements Serializable{


    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 更新用VO */
    private List<Tbj02EigyoDaichoVO> _updVo;

    /** ダミープロパティ */
    private String _dummy;

    /**
     * @return updVo
     */
    public List<Tbj02EigyoDaichoVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo セットする updVo
     */
    public void setUpdVo(List<Tbj02EigyoDaichoVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * ダミープロパティを返します
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }
}
