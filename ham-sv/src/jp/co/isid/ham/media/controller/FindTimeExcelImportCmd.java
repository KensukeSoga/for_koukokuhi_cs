package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindTimeExcelImportCondition;
import jp.co.isid.ham.media.model.FindTimeExcelImportManager;
import jp.co.isid.ham.media.model.FindTimeExcelImportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * TVTime取込みに必要なデータ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/22 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindTimeExcelImportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindTimeExcelImportCondition _condition;

    /**
     * 検索条件を使用し、 営業作業台帳データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindTimeExcelImportManager manager = FindTimeExcelImportManager.getInstance();
        FindTimeExcelImportResult result = manager.findTimeExcelImport(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindTimeExcelImportCondition(FindTimeExcelImportCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindTimeExcelImportResult 条件検索結果
     */
    public FindTimeExcelImportResult getTimeExcelImportResult() {
        return (FindTimeExcelImportResult) super.getResult().get(RESULT_KEY);
    }
}
