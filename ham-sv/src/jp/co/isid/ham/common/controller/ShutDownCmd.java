package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.ShutDownManager;
import jp.co.isid.ham.common.model.ShutDownResult;
import jp.co.isid.ham.common.model.Tbj29LoginUserVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 終了処理コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class ShutDownCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ログインユーザー削除 */
    private Tbj29LoginUserVO _tbj29vo;


    /**
     * 終了処理を実行
     */
    @Override
    public void execute() throws UserException {
        ShutDownManager manager = ShutDownManager.getInstance();
        ShutDownResult result = manager.shutDown(_tbj29vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * パラメータを設定
     * @param tbj29vo
     */
    public void setParameter(Tbj29LoginUserVO tbj29vo) {
        _tbj29vo = tbj29vo;
    }

    /**
     * 実行結果を返す
     * @return 実行結果
     */
    public ShutDownResult getShutDownResult() {
        return (ShutDownResult)super.getResult().get(RESULT_KEY);
    }

}
