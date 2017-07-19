package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

public class FindListColumnSettingResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    List<Mbj37DisplayControlVO> _dc;

    /** 一覧表示パターン */
    List<Tbj30DisplayPatternVO> _dp;

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
     * 一覧表示パターンを取得する
     *
     * @return 一覧表示パターン
     */
    public List<Tbj30DisplayPatternVO> getDisplayPattern() {
        return _dp;
    }

    /**
     * 一覧表示パターンを設定する
     *
     * @param dp 一覧表示パターン
     */
    public void setDisplayPattern(List<Tbj30DisplayPatternVO> dp) {
        _dp = dp;
    }

}
