package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC商品選択検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/26 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionResult extends AbstractServiceResult {

    /** HC商品選択 */
    List<FindHCItemSelectionVO> _hcItemSelection;


    /**
     * HC商品選択を取得する
     *
     * @return HC商品選択
     */
    public List<FindHCItemSelectionVO> getHCItemSelection() {
        return _hcItemSelection;
    }

    /**
     * HC商品選択を設定する
     *
     * @param hcItemSelection HC商品選択
     */
    public void setHCItemSelection(List<FindHCItemSelectionVO> hcItemSelection) {
        _hcItemSelection = hcItemSelection;
    }

}
