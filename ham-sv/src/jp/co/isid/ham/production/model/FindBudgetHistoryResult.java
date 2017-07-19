package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　検索実行時のデータ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindBudgetHistoryResult extends AbstractServiceResult {

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

    /** FindBudgetHistoryVOリスト */
    private List<FindBudgetHistoryVO> _findBudgetHistoryVoList = null;

    /**
     * FindBudgetHistoryVOリストを取得する
     *
     * @return FindBudgetHistoryVOリスト
     */
    public List<FindBudgetHistoryVO> getFindBudgetHistoryVoList() {
        return _findBudgetHistoryVoList;
    }

    /**
     * FindBudgetHistoryVOリストを設定する
     *
     * @param findBudgetVoList FindBudgetHistoryVOリスト
     */
    public void setFindBudgetHistoryVoList(List<FindBudgetHistoryVO> findBudgetHistoryVoList) {
        this._findBudgetHistoryVoList = findBudgetHistoryVoList;
    }

}
