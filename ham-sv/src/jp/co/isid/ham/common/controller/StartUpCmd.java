package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.StartUpCondition;
import jp.co.isid.ham.common.model.StartUpManager;
import jp.co.isid.ham.common.model.StartUpResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 起動処理コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class StartUpCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private StartUpCondition _startupcond = null;


    /**
     * 開始処理を実行
     */
    @Override
    public void execute() throws UserException {
        StartUpManager manager = StartUpManager.getInstance();
        StartUpResult result = manager.startUp(_startupcond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * パラメータを設定
     * @param startupcond
     */
    public void setParameter(StartUpCondition startupcond) {
        _startupcond = startupcond;
    }

    /**
     * 実行結果を返す
     * @return 実行結果
     */
    public StartUpResult getStartUpResult() {
        return (StartUpResult)super.getResult().get(RESULT_KEY);
    }

}
