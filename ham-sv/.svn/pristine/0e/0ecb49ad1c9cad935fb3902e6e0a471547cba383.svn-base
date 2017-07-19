package jp.co.isid.ham.common.service;

import java.util.List;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.common.controller.ExcelOutSettingRegisterCmd;
import jp.co.isid.ham.common.controller.FindExcelOutSettingCmd;
import jp.co.isid.ham.common.controller.FindFunctionControlInfoCmd;
import jp.co.isid.ham.common.controller.FindListColumnSettingCmd;
import jp.co.isid.ham.common.controller.FindMbj02UserCmd;
import jp.co.isid.ham.common.controller.FindSecurityInfoCmd;
import jp.co.isid.ham.common.controller.FindTbj30DisplayPatternCmd;
import jp.co.isid.ham.common.controller.RegisterListColumnSettingCmd;
import jp.co.isid.ham.common.controller.RegisterTbj30DisplayPatternCmd;
import jp.co.isid.ham.common.controller.SendMailCmd;
import jp.co.isid.ham.common.controller.ShutDownCmd;
import jp.co.isid.ham.common.controller.StartUpCmd;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterResult;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterVO;
import jp.co.isid.ham.common.model.FindExcelOutSettingCondition;
import jp.co.isid.ham.common.model.FindExcelOutSettingResult;
import jp.co.isid.ham.common.model.FindListColumnSettingCondition;
import jp.co.isid.ham.common.model.FindListColumnSettingResult;
import jp.co.isid.ham.common.model.FindMbj02UserResult;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoResult;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.RegisterListColumnSettingResult;
import jp.co.isid.ham.common.model.RegisterListColumnSettingVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoResult;
import jp.co.isid.ham.common.model.SendMailResult;
import jp.co.isid.ham.common.model.SendMailVO;
import jp.co.isid.ham.common.model.ShutDownResult;
import jp.co.isid.ham.common.model.StartUpCondition;
import jp.co.isid.ham.common.model.StartUpResult;
import jp.co.isid.ham.common.model.Tbj29LoginUserVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternResult;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.ham.util.HAMLogUtility;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
*
* <P>
* 共通サービス
* </P>
* <P>
* 共通サービスクラスです
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/10/04 JSE H.Abe)<BR>
* </P>
*
* @author JSE H.Abe
*/
@WebService(serviceName = "commonService", targetNamespace = "http://common.service.ham.isid.co.jp/")
public class CommonService {

    /**
     * 開始処理
     * @param mbj12cond
     * @param tbj29vo
     * @return
     * @throws ServiceException
     */
    public StartUpResult startUp(
            @WebParam(name = "startupcond") StartUpCondition startupcond)
            throws ServiceException {

        try {
            StartUpCmd cmd = new StartUpCmd();
            cmd.setParameter(startupcond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getStartUpResult();
        } catch (HAMException e) {
            StartUpResult result = new StartUpResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 終了処理
     * @param tbj29vo
     * @return
     * @throws ServiceException
     */
    public ShutDownResult shutDown(
            @WebParam(name = "tbj29vo") Tbj29LoginUserVO tbj29vo)
            throws ServiceException {

        try {
            ShutDownCmd cmd = new ShutDownCmd();
            cmd.setParameter(tbj29vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getShutDownResult();
        } catch (HAMException e) {
            ShutDownResult result = new ShutDownResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 一覧表示パターンを取得する
     *
     * @param condition 条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "tbj30DisplayPatternResult")
    public Tbj30DisplayPatternResult findTbj30DisplayPattern(
            @WebParam(name = "condition") Tbj30DisplayPatternCondition condition)
            throws ServiceException {

        try {
            FindTbj30DisplayPatternCmd cmd = new FindTbj30DisplayPatternCmd();
            cmd.setTbj30DisplayPatternCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getTbj30DisplayPatternResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            Tbj30DisplayPatternResult result = new Tbj30DisplayPatternResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 一覧表示パターンを登録する
     *
     * @param voList 登録データ
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "tbj30DisplayPatternResult")
    public Tbj30DisplayPatternResult registerTbj30DisplayPattern(
            @WebParam(name = "voList") List<Tbj30DisplayPatternVO> voList)
            throws ServiceException {

        try {
            RegisterTbj30DisplayPatternCmd cmd = new RegisterTbj30DisplayPatternCmd();
            cmd.setTbj30DisplayPatternVoList(voList);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getTbj30DisplayPatternResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            Tbj30DisplayPatternResult result = new Tbj30DisplayPatternResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 帳票出力設定を取得する
     *
     * @param condition 条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "excelOutSettingResult")
    public FindExcelOutSettingResult findExcelOutSetting(
            @WebParam(name = "cond") FindExcelOutSettingCondition cond)
            throws ServiceException {

        try {
            FindExcelOutSettingCmd cmd = new FindExcelOutSettingCmd();
            cmd.setExcelOutSettingCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getExcelOutSettingResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindExcelOutSettingResult result = new FindExcelOutSettingResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 帳票出力設定を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "excelOutSettingRegisterResult")
    public ExcelOutSettingRegisterResult excelOutSettingRegister(
            @WebParam(name = "vo")ExcelOutSettingRegisterVO vo)
            throws ServiceException {

        try {
            ExcelOutSettingRegisterCmd cmd = new ExcelOutSettingRegisterCmd();
            cmd.setExcelOutSettingRegisterResult(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getExcelOutSettingRegisterResultt();
        } catch (HAMException e) {
            ExcelOutSettingRegisterResult result = new ExcelOutSettingRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 列設定情報を取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindListColumnSettingResult findListColumnSetting(
            @WebParam(name = "cond") FindListColumnSettingCondition cond)
            throws ServiceException {

        try {
            FindListColumnSettingCmd cmd = new FindListColumnSettingCmd();
            cmd.setListColumnSettingCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getListColumnSettingResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindListColumnSettingResult result = new FindListColumnSettingResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 列設定情報を登録する
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    public RegisterListColumnSettingResult registerListColumnSetting(
            @WebParam(name = "vo") RegisterListColumnSettingVO vo)
            throws ServiceException {

        try {
            RegisterListColumnSettingCmd cmd = new RegisterListColumnSettingCmd();
            cmd.setRegisterListColumnSettingVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterListColumnSettingResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterListColumnSettingResult result = new RegisterListColumnSettingResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 機能制御情報を取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FunctionControlInfoResult findFunctionControlInfo(@WebParam(name = "cond") FunctionControlInfoCondition cond) throws ServiceException
    {
        try
        {
            FindFunctionControlInfoCmd cmd = new FindFunctionControlInfoCmd();
            cmd.setFindCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            HAMLogUtility.outLog(e);
            FunctionControlInfoResult result = new FunctionControlInfoResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e)
        {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * セキュリティ情報を取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public SecurityInfoResult findSecurityInfo(@WebParam(name = "cond") SecurityInfoCondition cond) throws ServiceException
    {
        try
        {
            FindSecurityInfoCmd cmd = new FindSecurityInfoCmd();
            cmd.setFindCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            HAMLogUtility.outLog(e);
            SecurityInfoResult result = new SecurityInfoResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e)
        {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }



    /**
     * メール送信を実行する
     * @param vo メール送信データ
     * @return メール送信結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "sendMailResult")
    public SendMailResult sendMail(
            @WebParam(name = "vo") SendMailVO vo)
            throws ServiceException {

        try {
            SendMailCmd cmd = new SendMailCmd();
            cmd.setSendMailVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getSendMailResult();
        } catch (HAMException e) {
            HAMLogUtility.error(e);
            SendMailResult result = new SendMailResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            HAMLogUtility.error(e.getMessage());
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 担当者マスタを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindMbj02UserResult findMbj02User(
            @WebParam(name = "cond") Mbj02UserCondition cond)
            throws ServiceException {

        try {
            FindMbj02UserCmd cmd = new FindMbj02UserCmd();
            cmd.setMbj02UserCondition(null);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindMbj02UserResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindMbj02UserResult result = new FindMbj02UserResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

}
