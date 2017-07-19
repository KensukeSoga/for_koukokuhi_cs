package jp.co.isid.ham.billing.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.billing.controller.CheckBillProductionOutputCmd;
import jp.co.isid.ham.billing.controller.FindBillGroupCmd;
import jp.co.isid.ham.billing.controller.FindBillProductionOutputCmd;
import jp.co.isid.ham.billing.controller.FindCostManagementReportCmd;
import jp.co.isid.ham.billing.controller.FindCostManagementSettingCmd;
import jp.co.isid.ham.billing.controller.FindCrCreateDataForCmsCmd;
import jp.co.isid.ham.billing.controller.FindDispCostManagementReportCmd;
import jp.co.isid.ham.billing.controller.FindEstMediaReportCmd;
import jp.co.isid.ham.billing.controller.FindEstimateReportCmd;
import jp.co.isid.ham.billing.controller.FindExpenseChangeCheckCmd;
import jp.co.isid.ham.billing.controller.FindHCEstimateCreationCmd;
import jp.co.isid.ham.billing.controller.FindHCEstimateListCmd;
import jp.co.isid.ham.billing.controller.FindHCItemSelectionCmd;
import jp.co.isid.ham.billing.controller.FindHCItemSelectionMstrCmd;
import jp.co.isid.ham.billing.controller.FindHCMediaCreationCmd;
import jp.co.isid.ham.billing.controller.FindHCProductCmd;
import jp.co.isid.ham.billing.controller.FindHMBillDataCmd;
import jp.co.isid.ham.billing.controller.FindHMEstimateBillReportCmd;
import jp.co.isid.ham.billing.controller.FindHMEstimateBillMediaReportCmd;
import jp.co.isid.ham.billing.controller.FindJasracRadioTimeBillCmd;
import jp.co.isid.ham.billing.controller.FindJasracRadioTimeCmd;
import jp.co.isid.ham.billing.controller.FindMstrHCProductCmd;
import jp.co.isid.ham.billing.controller.FindProductionChangeCheckCmd;
import jp.co.isid.ham.billing.controller.FindWorkDetailCmd;
import jp.co.isid.ham.billing.controller.RegisterBillDaysCmd;
import jp.co.isid.ham.billing.controller.RegisterCostManagementSettingCmd;
import jp.co.isid.ham.billing.controller.RegisterHCEstimateCreationCmd;
import jp.co.isid.ham.billing.controller.RegisterHCEstimateListCmd;
import jp.co.isid.ham.billing.controller.RegisterHCMediaCreationCmd;
import jp.co.isid.ham.billing.controller.RegisterOutputFileInfoCmd;
import jp.co.isid.ham.billing.controller.RegisterOutputFileInfoMediaCmd;
import jp.co.isid.ham.billing.model.CheckBillProductionOutputCondition;
import jp.co.isid.ham.billing.model.CheckBillProductionOutputResult;
import jp.co.isid.ham.billing.model.FindBillGroupResult;
import jp.co.isid.ham.billing.model.FindBillProductionOutputResult;
import jp.co.isid.ham.billing.model.FindCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindCostManagementReportResult;
import jp.co.isid.ham.billing.model.FindCostManagementSettingCondition;
import jp.co.isid.ham.billing.model.FindCostManagementSettingResult;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsCondition;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsResult;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportResult;
import jp.co.isid.ham.billing.model.FindEstMediaReportCondition;
import jp.co.isid.ham.billing.model.FindEstMediaReportResult;
import jp.co.isid.ham.billing.model.FindEstimateReportCondition;
import jp.co.isid.ham.billing.model.FindEstimateReportResult;
import jp.co.isid.ham.billing.model.FindExpenseChangeCheckCondition;
import jp.co.isid.ham.billing.model.FindExpenseChangeCheckResult;
import jp.co.isid.ham.billing.model.FindHCEstimateCreationCondition;
import jp.co.isid.ham.billing.model.FindHCEstimateCreationResult;
import jp.co.isid.ham.billing.model.FindHCEstimateListCondition;
import jp.co.isid.ham.billing.model.FindHCEstimateListResult;
import jp.co.isid.ham.billing.model.FindHCItemSelectionCondition;
import jp.co.isid.ham.billing.model.FindHCItemSelectionMstrCondition;
import jp.co.isid.ham.billing.model.FindHCItemSelectionMstrResult;
import jp.co.isid.ham.billing.model.FindHCItemSelectionResult;
import jp.co.isid.ham.billing.model.FindHCMediaCreationCondition;
import jp.co.isid.ham.billing.model.FindHCMediaCreationResult;
import jp.co.isid.ham.billing.model.FindHCProductCondition;
import jp.co.isid.ham.billing.model.FindHCProductResult;
import jp.co.isid.ham.billing.model.FindHMBillDataCondition;
import jp.co.isid.ham.billing.model.FindHMBillDataResult;
import jp.co.isid.ham.billing.model.FindHMEstimateBillMediaReportCondition;
import jp.co.isid.ham.billing.model.FindHMEstimateBillMediaReportResult;
import jp.co.isid.ham.billing.model.FindHMEstimateBillReportCondition;
import jp.co.isid.ham.billing.model.FindHMEstimateBillReportResult;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeBillResult;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeCondition;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeResult;
import jp.co.isid.ham.billing.model.FindMstrHCProductResult;
import jp.co.isid.ham.billing.model.FindProductionChangeCheckCondition;
import jp.co.isid.ham.billing.model.FindProductionChangeCheckResult;
import jp.co.isid.ham.billing.model.FindWorkDetailCondition;
import jp.co.isid.ham.billing.model.FindWorkDetailResult;
import jp.co.isid.ham.billing.model.RegisterBillDaysResult;
import jp.co.isid.ham.billing.model.RegisterCostManagementSettingResult;
import jp.co.isid.ham.billing.model.RegisterCostManagementSettingVO;
import jp.co.isid.ham.billing.model.RegisterHCEstimateCreationResult;
import jp.co.isid.ham.billing.model.RegisterHCEstimateCreationVO;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListResult;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListVO;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationResult;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationVO;
import jp.co.isid.ham.billing.model.RegisterOutputFileInfoResult;
import jp.co.isid.ham.billing.model.RegisterOutputFileInfoVO;
import jp.co.isid.ham.common.model.Mbj08HcProductCondition;
import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj28BillDaysVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.ham.util.HAMLogUtility;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * 請求サービス
 * </P>
 * <P>
 * 請求サービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/10/04 JSE H.Abe)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * ・JASRAC対応(2015/11/18 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "billingService", targetNamespace = "http://billing.service.ham.isid.co.jp/")
public class BillingService {

    /**
     * 制作費設定表示データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCostManagementSettingResult")
    public FindCostManagementSettingResult findCostManagementSetting(
            @WebParam(name = "cond") FindCostManagementSettingCondition cond) throws ServiceException {

        try {
            FindCostManagementSettingCmd cmd = new FindCostManagementSettingCmd();
            cmd.setCostManagementSettingCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCostManagementSettingResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCostManagementSettingResult result = new FindCostManagementSettingResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作費設定表示データを登録する
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterCostManagementSettingResult")
    public RegisterCostManagementSettingResult registerCostManagementSetting(
            @WebParam(name = "vo") RegisterCostManagementSettingVO vo) throws ServiceException {

        try {
            RegisterCostManagementSettingCmd cmd = new RegisterCostManagementSettingCmd();
            cmd.setRegisterCostManagementSettingVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterCostManagementSettingResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterCostManagementSettingResult result = new RegisterCostManagementSettingResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * CR制作費管理(制作費設定用)データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCrCreateDataForCmsResult")
    public FindCrCreateDataForCmsResult findCrCreateDataForCms(
            @WebParam(name = "cond") FindCrCreateDataForCmsCondition cond) throws ServiceException {

        try {
            FindCrCreateDataForCmsCmd cmd = new FindCrCreateDataForCmsCmd();
            cmd.setFindCrCreateDataForCmsCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindCrCreateDataForCmsResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCrCreateDataForCmsResult result = new FindCrCreateDataForCmsResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC見積一覧データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCEstimateListResult")
    public FindHCEstimateListResult findHCEstimateListCost(
            @WebParam(name = "cond") FindHCEstimateListCondition cond) throws ServiceException {

        try {
            FindHCEstimateListCmd cmd = new FindHCEstimateListCmd();
            cmd.setFindHCEstimateListCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCEstimateListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCEstimateListResult result = new FindHCEstimateListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC見積一覧データを登録する
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterHCEstimateListResult")
    public RegisterHCEstimateListResult registerHCEstimateList(
            @WebParam(name = "vo") RegisterHCEstimateListVO vo) throws ServiceException {

        try {
            RegisterHCEstimateListCmd cmd = new RegisterHCEstimateListCmd();
            cmd.setRegisterHCEstimateListVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterHCEstimateListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterHCEstimateListResult result = new RegisterHCEstimateListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC見積作成データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCEstimateCreationResult")
    public FindHCEstimateCreationResult findHCEstimateCreation(
            @WebParam(name = "cond") FindHCEstimateCreationCondition cond) throws ServiceException {

        try {
            FindHCEstimateCreationCmd cmd = new FindHCEstimateCreationCmd();
            cmd.setFindHCEstimateCreationCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCEstimateCreationResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCEstimateCreationResult result = new FindHCEstimateCreationResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC商品選択マスタ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCItemSelectionMstrResult")
    public FindHCItemSelectionMstrResult findHCItemSelectionMstr(
            @WebParam(name = "cond") FindHCItemSelectionMstrCondition cond) throws ServiceException {

        try {
            FindHCItemSelectionMstrCmd cmd = new FindHCItemSelectionMstrCmd();
            cmd.setFindHCItemSelectionMstrCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCItemSelectionMstrResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCItemSelectionMstrResult result = new FindHCItemSelectionMstrResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC商品選択検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCItemSelectionResult")
    public FindHCItemSelectionResult findHCItemSelection(
            @WebParam(name = "cond") FindHCItemSelectionCondition cond) throws ServiceException {

        try {
            FindHCItemSelectionCmd cmd = new FindHCItemSelectionCmd();
            cmd.setFindHCItemSelectionCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCItemSelectionResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCItemSelectionResult result = new FindHCItemSelectionResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC商品マスタ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCProductResult")
    public FindHCProductResult findHCProduct(
            @WebParam(name = "cond") FindHCProductCondition cond) throws ServiceException {

        try {
            FindHCProductCmd cmd = new FindHCProductCmd();
            cmd.setFindHCProductCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCProductResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCProductResult result = new FindHCProductResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC見積作成登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterHCEstimateCreationResult")
    public RegisterHCEstimateCreationResult registerHCEstimateCreation(
            @WebParam(name = "vo") RegisterHCEstimateCreationVO vo) throws ServiceException {

        try {
            RegisterHCEstimateCreationCmd cmd = new RegisterHCEstimateCreationCmd();
            cmd.setRegisterHCEstimateCreationVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterHCEstimateCreationResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterHCEstimateCreationResult result = new RegisterHCEstimateCreationResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 見積書、見積CSVファイル作成検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindEstimateReportResult")
    public FindEstimateReportResult findEstimateReport(
            @WebParam(name = "cond") FindEstimateReportCondition cond) throws ServiceException {

        try {
            FindEstimateReportCmd cmd = new FindEstimateReportCmd();
            cmd.setFindEstimateReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindEstimateReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindEstimateReportResult result = new FindEstimateReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作費明細書検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindWorkDetailResult")
    public FindWorkDetailResult findWorkDetailReport(
            @WebParam(name = "cond") FindWorkDetailCondition cond) throws ServiceException {

        try {
            FindWorkDetailCmd cmd = new FindWorkDetailCmd();
            cmd.setFindWorkDetailCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindWorkDetailResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindWorkDetailResult result = new FindWorkDetailResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 請求書出力年月マスタ登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterBillDaysResult")
    public RegisterBillDaysResult registerBillDays(
            @WebParam(name = "vo") Mbj28BillDaysVO vo) throws ServiceException {

        try {
            RegisterBillDaysCmd cmd = new RegisterBillDaysCmd();
            cmd.setMbj28BillDaysVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterBillDaysResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterBillDaysResult result = new RegisterBillDaysResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC商品マスタ検索(商品コード手入力時)
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMstrHCProductResult")
    public FindMstrHCProductResult findMstrHCProduct(
            @WebParam(name = "cond") Mbj08HcProductCondition cond) throws ServiceException {

        try {
            FindMstrHCProductCmd cmd = new FindMstrHCProductCmd();
            cmd.setMbj08HcProductCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindMstrHCProductResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindMstrHCProductResult result = new FindMstrHCProductResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 請求先グループ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindBillGroupResult")
    public FindBillGroupResult findBillGroup(
            @WebParam(name = "cond") Mbj26BillGroupCondition cond) throws ServiceException {

        try {
            FindBillGroupCmd cmd = new FindBillGroupCmd();
            cmd.setBillGroupCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getBillGroupResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindBillGroupResult result = new FindBillGroupResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作原価変更データ取得検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindProductionChangeCheckResult")
    public FindProductionChangeCheckResult findProductionChangeCheck(
            @WebParam(name = "cond") FindProductionChangeCheckCondition cond) throws ServiceException {

        try {
            FindProductionChangeCheckCmd cmd = new FindProductionChangeCheckCmd();
            cmd.setProductionChangeCheckCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getProductionChangeCheckResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindProductionChangeCheckResult result = new FindProductionChangeCheckResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作費変更データ取得検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindExpenseChangeCheckResult")
    public FindExpenseChangeCheckResult findExpenseChangeCheck(
            @WebParam(name = "cond") FindExpenseChangeCheckCondition cond) throws ServiceException {

        try {
            FindExpenseChangeCheckCmd cmd = new FindExpenseChangeCheckCmd();
            cmd.setEsxpenseChangeCheckCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getExpenseChangeCheckResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindExpenseChangeCheckResult result = new FindExpenseChangeCheckResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 見積ファイル出力情報登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterOutputFileInfoResult")
    public RegisterOutputFileInfoResult registerOutputFileInfo(
            @WebParam(name = "vo") RegisterOutputFileInfoVO vo) throws ServiceException {

        try {
            RegisterOutputFileInfoCmd cmd = new RegisterOutputFileInfoCmd();
            cmd.setRegisterOutputFileInfoVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterOutputFileInfoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterOutputFileInfoResult result = new RegisterOutputFileInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作請求表出力データ存在チェック
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "CheckBillProductionOutputResult")
    public CheckBillProductionOutputResult checkBillProductionOutput(
            @WebParam(name = "cond") CheckBillProductionOutputCondition cond) throws ServiceException {

        try {
            CheckBillProductionOutputCmd cmd = new CheckBillProductionOutputCmd();
            cmd.setCheckBillProductionOutputCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckBillProductionOutputResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            CheckBillProductionOutputResult result = new CheckBillProductionOutputResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 制作請求表取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindBillProductionOutputResult")
    public FindBillProductionOutputResult findBillProductionOutput(
            @WebParam(name = "cond") CheckBillProductionOutputCondition cond) throws ServiceException {

        try {
            FindBillProductionOutputCmd cmd = new FindBillProductionOutputCmd();
            cmd.setCheckBillProductionOutputCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindBillProductionOutputResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindBillProductionOutputResult result = new FindBillProductionOutputResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * コスト管理表出力データ取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCostManagementReportResult")
    public FindCostManagementReportResult findCostManagementOutput(
            @WebParam(name = "cond") FindCostManagementReportCondition cond) throws ServiceException {

        try {
            FindCostManagementReportCmd cmd = new FindCostManagementReportCmd();
            cmd.setCostManagementReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCostManagementReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCostManagementReportResult result = new FindCostManagementReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * コスト管理表機能制御データ取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindDispCostManagementReportResult")
    public FindDispCostManagementReportResult findDispCostManagementOutput(
            @WebParam(name = "cond") FindDispCostManagementReportCondition cond) throws ServiceException {

        try {
            FindDispCostManagementReportCmd cmd = new FindDispCostManagementReportCmd();
            cmd.setCostManagementReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCostManagementReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindDispCostManagementReportResult result = new FindDispCostManagementReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * HC媒体費作成検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHCMediaCreationResult")
    public FindHCMediaCreationResult findHCMediaCreation(
            @WebParam(name = "cond") FindHCMediaCreationCondition cond) throws ServiceException {

        try {
            FindHCMediaCreationCmd cmd = new FindHCMediaCreationCmd();
            cmd.setFindHCMediaCreationCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHCMediaCreationResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHCMediaCreationResult result = new FindHCMediaCreationResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HC媒体費作成登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterHCMediaCreationResult")
    public RegisterHCMediaCreationResult registerHCMediaCreation(
            @WebParam(name = "vo") RegisterHCMediaCreationVO vo) throws ServiceException {

        try {
            RegisterHCMediaCreationCmd cmd = new RegisterHCMediaCreationCmd();
            cmd.setRegisterHCMediaCreationVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterHCMediaCreationResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterHCMediaCreationResult result = new RegisterHCMediaCreationResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 見積書、見積CSVファイル作成(媒体)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindEstMediaReportResult")
    public FindEstMediaReportResult findEstMediaReport(
            @WebParam(name = "cond") FindEstMediaReportCondition cond) throws ServiceException {

        try {
            FindEstMediaReportCmd cmd = new FindEstMediaReportCmd();
            cmd.setFindEstMediaReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindEstMediaReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindEstMediaReportResult result = new FindEstMediaReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM見積書、請求明細書、請求書作成(媒体)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHMEstimateBillMediaReportResult")
    public FindHMEstimateBillMediaReportResult findHMEstimateBillMediaReport(
            @WebParam(name = "cond") FindHMEstimateBillMediaReportCondition cond) throws ServiceException {

        try {
            FindHMEstimateBillMediaReportCmd cmd = new FindHMEstimateBillMediaReportCmd();
            cmd.setFindHMEstimateBillMediaReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHMEstimateBillMediaReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHMEstimateBillMediaReportResult result = new FindHMEstimateBillMediaReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HM見積書・請求書(制作)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHMEstimateBillReportResult")
    public FindHMEstimateBillReportResult findHMEstimateBillReport(
            @WebParam(name = "cond") FindHMEstimateBillReportCondition cond) throws ServiceException {

        try {
            FindHMEstimateBillReportCmd cmd = new FindHMEstimateBillReportCmd();
            cmd.setFindHMEstimateBillReportCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHMEstimateBillReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHMEstimateBillReportResult result = new FindHMEstimateBillReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HM請求データ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindHMBillDataResult")
    public FindHMBillDataResult findHMBillData(
            @WebParam(name = "cond") FindHMBillDataCondition cond) throws ServiceException {

        try {
            FindHMBillDataCmd cmd = new FindHMBillDataCmd();
            cmd.setFindHMBillDataCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindHMBillDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindHMBillDataResult result = new FindHMBillDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /**
     * 見積ファイル出力情報(媒体)登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterOutputFileInfoResult")
    public RegisterOutputFileInfoResult registerOutputFileInfoMedia(
            @WebParam(name = "vo") RegisterOutputFileInfoVO vo) throws ServiceException {

        try {
            RegisterOutputFileInfoMediaCmd cmd = new RegisterOutputFileInfoMediaCmd();
            cmd.setRegisterOutputFileInfoVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterOutputFileInfoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterOutputFileInfoResult result = new RegisterOutputFileInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2015/11/18 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * JASRAC申請書出力情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindJasracRadioTimeResult")
    public FindJasracRadioTimeResult findJasracRadioTimeOutputInfo(@WebParam(name = "cond") FindJasracRadioTimeCondition cond) throws ServiceException {

        try {
            FindJasracRadioTimeCmd cmd = new FindJasracRadioTimeCmd();
            cmd.setFindJasracRadioTimeCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindJasracRadioTimeResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindJasracRadioTimeResult result = new FindJasracRadioTimeResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * JASRAC請求明細書出力情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindJasracRadioTimeBillResult")
    public FindJasracRadioTimeBillResult findJasracRadioTimeBillOutputInfo(@WebParam(name = "cond") FindJasracRadioTimeCondition cond) throws ServiceException {

        try {
            FindJasracRadioTimeBillCmd cmd = new FindJasracRadioTimeBillCmd();
            cmd.setFindJasracRadioTimeCondition(cond);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindJasracRadioTimeBillResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindJasracRadioTimeBillResult result = new FindJasracRadioTimeBillResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2015/11/18 JASRAC対応 HLC S.Fujimoto ADD End */

}
