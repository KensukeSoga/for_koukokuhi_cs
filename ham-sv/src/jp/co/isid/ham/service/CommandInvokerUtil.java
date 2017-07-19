package jp.co.isid.ham.service;

import jp.co.isid.ham.base.HAMParameter;
import jp.co.isid.nj.controller.command.CommandInvoker;
import jp.co.isid.nj.controller.command.CommandInvokerFactory;

/**
 * <p>
 * Service 層からコマンドを呼び出すためのユーティリティクラス
 * </p>
 * <p>
 * <b>修正履歴</b><br />
 * ・新規作成(2011/11/02 HLC sonobe)<br />
 * </p>
 *
 * @author WT I.Kondo
 */
public final class CommandInvokerUtil {

    /** Singletonインスタンス */
    private static CommandInvoker _invoker;

    static {
    	HAMParameter param = HAMParameter.getInstance();
        CommandInvokerFactory factory = CommandInvokerFactory.getFactory(param);
        _invoker =  factory.getCommandInvoker(param.getCommandInvokerName());
    }

    /**
     * ユーティリティクラスのためインスタンス化を禁止します
     */
    private CommandInvokerUtil() {
    }

    /**
     * CommandInvoker を取得します
     *
     * @return CommandInvoker
     */
    public static CommandInvoker getCommandInvoker() {
        return _invoker;
    }

}
