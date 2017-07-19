package jp.co.isid.ham.operationLog.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.operationLog.controller.FindOperationLogCmd;
import jp.co.isid.ham.operationLog.controller.RegisterOperationLogCmd;
import jp.co.isid.ham.operationLog.model.FindOperationLogCondition;
import jp.co.isid.ham.operationLog.model.FindOperationLogResult;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogResult;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogVO;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.ham.util.HAMLogUtility;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * 稼働ログサービス
 * </P>
 * <P>
 * 稼働ログサービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/15 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
@WebService(serviceName = "operationLogService", targetNamespace = "http://operationLog.service.ham.isid.co.jp/")
public class OperationLogService {

    /**
     * 稼働ログを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindOperationLogResult findOperationLog(
            @WebParam(name = "cond") FindOperationLogCondition cond)
            throws ServiceException {

        try {
            FindOperationLogCmd cmd = new FindOperationLogCmd();
            cmd.setFindOperationLogCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getOperationLogResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindOperationLogResult result = new FindOperationLogResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 稼働ログを登録する
     * @param vo 登録情報
     * @return 処理結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "registerOperationLogResult")
    public RegisterOperationLogResult registerOperationLog(
            @WebParam(name = "vo") RegisterOperationLogVO vo)
            throws ServiceException {

        try {
            RegisterOperationLogCmd cmd = new RegisterOperationLogCmd();
            cmd.setRegisterOperationLogVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterOperationLogResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterOperationLogResult result = new RegisterOperationLogResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
}
