package jp.co.isid.ham.media.model;

import java.io.Serializable;
public class FindInputRejectionCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**キャンペーンコード*/
    private String _campCd;

    /** ダミープロパティ */
    private String _dummy;
    /**
     * @return campCd
     */
    public String getCampCd() {
        return _campCd;
    }
    /**
     * @param campCd セットする campCd
     */
    public void setCampCd(String campCd) {
        this._campCd = campCd;
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