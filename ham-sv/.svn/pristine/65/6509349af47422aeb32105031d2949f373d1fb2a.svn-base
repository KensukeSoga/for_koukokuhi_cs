package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * メールアドレス検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/28 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindMailInfoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /* ============================================================================= */
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     *
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     *
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

    /* ============================================================================= */

    /** 担当者 */
    private List<String> _hamIdList = null;

    /**
     * 担当者を取得する
     *
     * @return 担当者
     */
    public List<String> getHamIdList() {
        return _hamIdList;
    }

    /**
     * 担当者を設定する
     *
     * @param tantoName 担当者
     */
    public void setHamIdList(List<String> hamIdList) {
        this._hamIdList = hamIdList;
    }
}
