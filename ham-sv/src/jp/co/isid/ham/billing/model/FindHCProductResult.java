package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC商品マスタ検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/27 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCProductResult extends AbstractServiceResult {

    /** HC商品マスタ */
    List<FindHCProductVO> _product;

    /**
     * HC商品マスタを取得する
     *
     * @return HC商品マスタ
     */
    public List<FindHCProductVO> getProduct() {
        return _product;
    }

    /**
     * HC商品マスタを設定する
     *
     * @param product HC商品マスタ
     */
    public void setProduct(List<FindHCProductVO> product) {
        _product = product;
    }
}
