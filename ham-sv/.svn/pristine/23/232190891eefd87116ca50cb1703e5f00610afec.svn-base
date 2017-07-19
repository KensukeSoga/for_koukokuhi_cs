package jp.co.isid.ham.login.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.login.controller.AccountSecurityRoleGetCmd;
import jp.co.isid.ham.login.controller.MprKengenCheckCmd;
import jp.co.isid.ham.login.model.AccountSecurityRoleCondition;
import jp.co.isid.ham.login.model.AccountSecurityRoleResult;
import jp.co.isid.ham.login.model.MprKengenCheckCondition;
import jp.co.isid.ham.login.model.MprKengenCheckResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.ham.util.HAMLogUtility;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * ログインサービス
 * </P>
 * <P>
 * ログインサービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/05/21 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
@WebService(serviceName = "loginService", targetNamespace = "http://service.login.ham.isid.co.jp/")
public class LoginService {

    /**
     * 業務会計セキュリティロールを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "accountSecurityRoleResult")
    public AccountSecurityRoleResult getAccountSecurityRole(
            @WebParam(name = "condition") AccountSecurityRoleCondition condition) throws ServiceException {

        try {
            AccountSecurityRoleGetCmd cmd = new AccountSecurityRoleGetCmd();
            cmd.setAccountSecurityRoleCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getAccountSecurityRoleResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            AccountSecurityRoleResult result = new AccountSecurityRoleResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 業務会計セキュリティロールを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "mprKengenCheckResult")
    public MprKengenCheckResult mprKengenCheck(
            @WebParam(name = "condition") MprKengenCheckCondition condition) throws ServiceException {

        try {
            MprKengenCheckCmd cmd = new MprKengenCheckCmd();
            cmd.setMprKengenCheckCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMprKengenCheckResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MprKengenCheckResult result = new MprKengenCheckResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

}