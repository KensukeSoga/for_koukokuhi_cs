package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC商品選択マスタ検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionMstrResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    List<Mbj37DisplayControlVO> _dc;

    /** HC商品マスタ */
    List<FindHCProductVO> _product;


    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

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
