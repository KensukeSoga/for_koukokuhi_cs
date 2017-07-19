package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj23CarTantoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 制作費明細書出力検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/4 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindWorkDetailResult extends AbstractServiceResult {

    /** 制作費明細書出力一覧(制作費取込)リスト */
    List<FindWorkDetailGenkaVO> _item;

    /** 制作費明細書出力一覧 */
    List<FindWorkDetailListItemVO> _estDetail;

    /** 車種担当者マスタ */
    List<Mbj23CarTantoVO> _carTanto;

    /**
     * 制作費明細書出力一覧(制作費取込)を取得する
     *
     * @return 制作費明細書出力一覧(制作費取込)
     */
    public List<FindWorkDetailGenkaVO> getItem() {
        return _item;
    }

    /**
     * 制作費明細書出力一覧(制作費取込)を設定する
     *
     * @param item 制作費明細書出力一覧(制作費取込)
     */
    public void setItem(List<FindWorkDetailGenkaVO> item) {
        _item = item;
    }

    /**
     * 制作費明細書出力一覧を取得する
     *
     * @return 制作費明細書出力一覧
     */
    public List<FindWorkDetailListItemVO> getEstDetail() {
        return _estDetail;
    }

    /**
     * 制作費明細書出力一覧を設定する
     *
     * @param estDetail 制作費明細書出力一覧
     */
    public void setEstDetail(List<FindWorkDetailListItemVO> estDetail) {
        _estDetail = estDetail;
    }

    /**
     * 車種担当者マスタを取得する
     *
     * @return 制作費明細書出力一覧
     */
    public List<Mbj23CarTantoVO> getCarTanto() {
        return _carTanto;
    }

    /**
     * 車種担当者マスタを設定する
     *
     * @param estDetail 制作費明細書出力一覧
     */
    public void setCarTanto(List<Mbj23CarTantoVO> CarTantoVO) {
    	_carTanto = CarTantoVO;
    }
}
