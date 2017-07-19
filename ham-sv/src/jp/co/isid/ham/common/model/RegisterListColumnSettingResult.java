package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.AbstractServiceResult;

public class RegisterListColumnSettingResult extends AbstractServiceResult {

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加
     * @return String ダミー
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加
     * @param dummy ダミー
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
