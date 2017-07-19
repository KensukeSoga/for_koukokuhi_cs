package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC見積一覧登録結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCEstimateListResult extends AbstractServiceResult {

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
