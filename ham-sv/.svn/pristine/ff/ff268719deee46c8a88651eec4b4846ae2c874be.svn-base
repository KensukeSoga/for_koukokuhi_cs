package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 制作原価変更点取得
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindProductionChangeCheckResult extends AbstractServiceResult{

    /** 作成時データ */
    List<FindBeforeProductionVO> _bp;

    /** 現在データ */
    List<FindNowProductionVO> _np;

    /** 画面項目表示列制御マスタ */
    List<Mbj37DisplayControlVO> _dc;

    /**
     * 作成時データを取得
     * @return
     */
    public List<FindBeforeProductionVO> getBeforeProduction() {
        return _bp;
    }

    /**
     * 作成時データを設定
     * @param bp
     */
    public void setBeforeProduction(List<FindBeforeProductionVO> bp) {
        this._bp = bp;
    }

    /**
     * 現在データを取得
     * @return
     */
    public List<FindNowProductionVO> getNowProduction() {
        return _np;
    }

    /**
     * 現在データを設定
     * @param np
     */
    public void setNowProduction(List<FindNowProductionVO> np) {
        this._np = np;
    }

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
}
