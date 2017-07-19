package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.DocumentTransmissionManager;
import jp.co.isid.ham.media.model.FindDocumentTransmissionCondition;
import jp.co.isid.ham.media.model.FindDocumentTransmissionResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class FindDocumentTransmissionCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    private FindDocumentTransmissionCondition _cond;

    /**
     * 検索条件を使用し、 送稿表データ検索処理を実行します
     *
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        DocumentTransmissionManager manager = DocumentTransmissionManager.getInstance();
        FindDocumentTransmissionResult result = manager.findDocumentTransmission(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param cond 検索条件
     */
    public void setFindDocumentTransmissionCondition(FindDocumentTransmissionCondition cond) {
        _cond = cond;
    }

    /**
     * 送稿表の取得結果を返します
     *
     * @return 送稿表の取得結果
     */
    public FindDocumentTransmissionResult getFindDocumentTransmissionResult() {
        return (FindDocumentTransmissionResult) super.getResult().get(RESULT_KEY);
    }

}
