package jp.co.isid.ham.operationLog.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.operationLog.model.OperationLogManager;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogResult;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 稼働ログ登録コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/06 新HAMチーム)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class RegisterOperationLogCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 処理結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterOperationLogVO _vo;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        OperationLogManager manager = OperationLogManager.getInstance();
        RegisterOperationLogResult result = manager.registerOperationLog(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 登録情報を設定します
     *
     * @param vo 登録情報
     */
    public void setRegisterOperationLogVO(RegisterOperationLogVO vo) {
        _vo = vo;
    }

    /**
     * 処理結果を返します
     *
     * @return 処理結果
     */
    public RegisterOperationLogResult getRegisterOperationLogResult() {
        return (RegisterOperationLogResult)super.getResult().get(RESULT_KEY);
    }
}
