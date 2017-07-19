package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.media.model.FindSozaiDataByRCodeManager;
import jp.co.isid.ham.media.model.FindSozaiDataByRCodeResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 素材管理リスト検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/05 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindSozaiDataByRCodeCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private Tbj20SozaiKanriListCondition _cond;

    /**
     * 素材管理データを検索する
     */
    @Override
    public void execute() throws UserException {
        FindSozaiDataByRCodeManager manager = FindSozaiDataByRCodeManager.getInstance();
        FindSozaiDataByRCodeResult result = manager.findSozaiDataByRCode(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定する
     * @param cond 検索条件
     */
    public void setSozaiKanriCondition(Tbj20SozaiKanriListCondition cond) {
        this._cond = cond;
    }

    /**
     * 検索結果を返す
     * @return 検索結果
     */
    public FindSozaiDataByRCodeResult getSozaiDataByRCodeResult() {
        return (FindSozaiDataByRCodeResult) super.getResult().get(RESULT_KEY);
    }

}
