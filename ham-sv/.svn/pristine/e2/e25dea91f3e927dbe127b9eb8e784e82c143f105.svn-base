package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.DocumentTransmissionManager;
import jp.co.isid.ham.media.model.FindDocTransReportCondition;
import jp.co.isid.ham.media.model.FindDocTransReportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class FindDocTransReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    private FindDocTransReportCondition _cond = null;

    /**
     * 検索条件を使用し、 送稿表データ検索処理を実行します
     *
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        DocumentTransmissionManager manager = DocumentTransmissionManager.getInstance();
        FindDocTransReportResult result = manager.findDocTransReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param cond 検索条件
     */
    public void setFindDocTransReportCondition(FindDocTransReportCondition cond) {
        _cond = cond;
    }

    /**
     * 送稿表帳票の取得結果を返します
     *
     * @return 送稿表帳票の取得結果
     */
    public FindDocTransReportResult getFindDocTransReportResult() {
        return (FindDocTransReportResult) super.getResult().get(RESULT_KEY);
    }

}
