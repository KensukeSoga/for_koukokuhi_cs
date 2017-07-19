package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 制作費変更点取得
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/12 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExpenseChangeCheckResult extends AbstractServiceResult{

    /** 作成時データ */
    List<FindBeforeExpenseVO> _be;

    /** 現在データ */
    List<FindNowExpenseVO> _ne;

    /** 画面項目表示列制御マスタ */
    List<Mbj37DisplayControlVO> _dc;

    /**
     * 作成時データを取得
     * @return
     */
    public List<FindBeforeExpenseVO> getBeforeExpense() {
        return _be;
    }

    /**
     * 作成時データを設定
     * @param bp
     */
    public void setBeforeExpense(List<FindBeforeExpenseVO> be) {
        this._be = be;
    }

    /**
     * 現在データを取得
     * @return
     */
    public List<FindNowExpenseVO> getNowExpense() {
        return _ne;
    }

    /**
     * 現在データを設定
     * @param np
     */
    public void setNowExpense(List<FindNowExpenseVO> ne) {
        this._ne = ne;
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
