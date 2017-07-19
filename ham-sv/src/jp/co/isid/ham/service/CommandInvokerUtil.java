package jp.co.isid.ham.service;

import jp.co.isid.ham.base.HAMParameter;
import jp.co.isid.nj.controller.command.CommandInvoker;
import jp.co.isid.nj.controller.command.CommandInvokerFactory;

/**
 * <p>
 * Service �w����R�}���h���Ăяo�����߂̃��[�e�B���e�B�N���X
 * </p>
 * <p>
 * <b>�C������</b><br />
 * �E�V�K�쐬(2011/11/02 HLC sonobe)<br />
 * </p>
 *
 * @author WT I.Kondo
 */
public final class CommandInvokerUtil {

    /** Singleton�C���X�^���X */
    private static CommandInvoker _invoker;

    static {
    	HAMParameter param = HAMParameter.getInstance();
        CommandInvokerFactory factory = CommandInvokerFactory.getFactory(param);
        _invoker =  factory.getCommandInvoker(param.getCommandInvokerName());
    }

    /**
     * ���[�e�B���e�B�N���X�̂��߃C���X�^���X�����֎~���܂�
     */
    private CommandInvokerUtil() {
    }

    /**
     * CommandInvoker ���擾���܂�
     *
     * @return CommandInvoker
     */
    public static CommandInvoker getCommandInvoker() {
        return _invoker;
    }

}
