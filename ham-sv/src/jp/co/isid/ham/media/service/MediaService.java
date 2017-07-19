package jp.co.isid.ham.media.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.media.controller.AccountBookRegisterCmd;
import jp.co.isid.ham.media.controller.CampaignRegisterCmd;
import jp.co.isid.ham.media.controller.CampaignRegisterDetailsCmd;
import jp.co.isid.ham.media.controller.FindAccountBookCmd;
import jp.co.isid.ham.media.controller.FindAccountBookLogCmd;
import jp.co.isid.ham.media.controller.FindAccountBookOutPutDataCmd;
import jp.co.isid.ham.media.controller.FindAccountBookOutputCmd;
import jp.co.isid.ham.media.controller.FindAuthorityAccountBookCmd;
import jp.co.isid.ham.media.controller.FindBillStatementCmd;
import jp.co.isid.ham.media.controller.FindBillStatementDataCmd;
import jp.co.isid.ham.media.controller.FindCampaignDetailsCmd;
import jp.co.isid.ham.media.controller.FindCampaignDetailsHomeLoadCmd;
import jp.co.isid.ham.media.controller.FindCampaignListCmd;
import jp.co.isid.ham.media.controller.FindCampaignListHomeLoadCmd;
import jp.co.isid.ham.media.controller.FindCooperationDataCmd;
import jp.co.isid.ham.media.controller.FindDocTransReportCmd;
import jp.co.isid.ham.media.controller.FindDocumentTransmissionCmd;
import jp.co.isid.ham.media.controller.FindExcelInputErrorCmd;
import jp.co.isid.ham.media.controller.FindGrossSumCmd;
import jp.co.isid.ham.media.controller.FindInputRejectionCmd;
import jp.co.isid.ham.media.controller.FindMediaByCommonMasterCmd;
import jp.co.isid.ham.media.controller.FindMediaPatternCmd;
import jp.co.isid.ham.media.controller.FindMediaPlanCmd;
import jp.co.isid.ham.media.controller.FindMediaPlanSelectCmd;
import jp.co.isid.ham.media.controller.FindOrderSelectCmd;
import jp.co.isid.ham.media.controller.FindRdAllocationPictureCmd;
import jp.co.isid.ham.media.controller.FindRdProgramCmd;
import jp.co.isid.ham.media.controller.FindRdProgramRegisterCmd;
import jp.co.isid.ham.media.controller.FindRdStationSelectCmd;
import jp.co.isid.ham.media.controller.FindSozaiDataByRCodeCmd;
import jp.co.isid.ham.media.controller.FindSumCarCmd;
import jp.co.isid.ham.media.controller.FindTimeExcelImportCmd;
import jp.co.isid.ham.media.controller.MediaPlanRegisterCmd;
import jp.co.isid.ham.media.controller.MepiaPlanRegisterByCampDetailsCmd;
import jp.co.isid.ham.media.controller.RegisterRdProgramInfoCmd;
import jp.co.isid.ham.media.controller.RegisterRdTime2AccountBookCmd;
import jp.co.isid.ham.media.controller.TVTImportRegisterCmd;
import jp.co.isid.ham.media.controller.UpdABOrderOutRegisterCmd;
import jp.co.isid.ham.media.model.AccountBookRegisterResult;
import jp.co.isid.ham.media.model.AccountBookRegisterVO;
import jp.co.isid.ham.media.model.CampaignRegisterCondition;
import jp.co.isid.ham.media.model.CampaignRegisterDetailsCondition;
import jp.co.isid.ham.media.model.CampaignRegisterResult;
import jp.co.isid.ham.media.model.FindAccountBookCondition;
import jp.co.isid.ham.media.model.FindAccountBookLogCondition;
import jp.co.isid.ham.media.model.FindAccountBookLogResult;
import jp.co.isid.ham.media.model.FindAccountBookOutPutDataCondition;
import jp.co.isid.ham.media.model.FindAccountBookOutPutDataResult;
import jp.co.isid.ham.media.model.FindAccountBookOutputCondition;
import jp.co.isid.ham.media.model.FindAccountBookOutputResult;
import jp.co.isid.ham.media.model.FindAccountBookResult;
import jp.co.isid.ham.media.model.FindAuthorityAccountBookCondition;
import jp.co.isid.ham.media.model.FindAuthorityAccountBookResult;
import jp.co.isid.ham.media.model.FindBillStatementCondition;
import jp.co.isid.ham.media.model.FindBillStatementDataCondition;
import jp.co.isid.ham.media.model.FindBillStatementDataResult;
import jp.co.isid.ham.media.model.FindBillStatementResult;
import jp.co.isid.ham.media.model.FindCampaignDetailsCondition;
import jp.co.isid.ham.media.model.FindCampaignDetailsResult;
import jp.co.isid.ham.media.model.FindCampaignListCondition;
import jp.co.isid.ham.media.model.FindCampaignListResult;
import jp.co.isid.ham.media.model.FindCooperationDataCondition;
import jp.co.isid.ham.media.model.FindCooperationDataResult;
import jp.co.isid.ham.media.model.FindDocTransReportCondition;
import jp.co.isid.ham.media.model.FindDocTransReportResult;
import jp.co.isid.ham.media.model.FindDocumentTransmissionCondition;
import jp.co.isid.ham.media.model.FindDocumentTransmissionResult;
import jp.co.isid.ham.media.model.FindExcelInputErrorCondition;
import jp.co.isid.ham.media.model.FindExcelInputErrorResult;
import jp.co.isid.ham.media.model.FindGrossSumResult;
import jp.co.isid.ham.media.model.FindInputRejectionCondition;
import jp.co.isid.ham.media.model.FindInputRejectionResult;
import jp.co.isid.ham.media.model.FindMediaByCommonMasterCondition;
import jp.co.isid.ham.media.model.FindMediaByCommonMasterResult;
import jp.co.isid.ham.media.model.FindMediaPatternCondition;
import jp.co.isid.ham.media.model.FindMediaPatternResult;
import jp.co.isid.ham.media.model.FindMediaPlanCondition;
import jp.co.isid.ham.media.model.FindMediaPlanResult;
import jp.co.isid.ham.media.model.FindMediaPlanSelectCondition;
import jp.co.isid.ham.media.model.FindMediaPlanSelectResult;
import jp.co.isid.ham.media.model.FindOrderSelectCondition;
import jp.co.isid.ham.media.model.FindOrderSelectResult;
import jp.co.isid.ham.media.model.FindRdAllocationPictureCondition;
import jp.co.isid.ham.media.model.FindRdAllocationPictureResult;
import jp.co.isid.ham.media.model.FindRdProgramCondition;
import jp.co.isid.ham.media.model.FindRdProgramRegisterCondition;
import jp.co.isid.ham.media.model.FindRdProgramRegisterResult;
import jp.co.isid.ham.media.model.FindRdProgramResult;
import jp.co.isid.ham.media.model.FindRdStationSelectCondition;
import jp.co.isid.ham.media.model.FindRdStationSelectResult;
import jp.co.isid.ham.media.model.FindRdTime2AccountBookCondition;
import jp.co.isid.ham.media.model.FindSozaiDataByRCodeResult;
import jp.co.isid.ham.media.model.FindSumCarResult;
import jp.co.isid.ham.media.model.FindTimeExcelImportCondition;
import jp.co.isid.ham.media.model.FindTimeExcelImportResult;
import jp.co.isid.ham.media.model.MediaPlanRegisterCondition;
import jp.co.isid.ham.media.model.MediaPlanRegisterResult;
import jp.co.isid.ham.media.model.MediaPlanRegisterVO;
import jp.co.isid.ham.media.model.RdTime2AccountBookRegisterResult;
import jp.co.isid.ham.media.model.RegisterRdProgramInfoResult;
import jp.co.isid.ham.media.model.RegisterRdProgramInfoVO;
import jp.co.isid.ham.media.model.TVTImportRegisterResult;
import jp.co.isid.ham.media.model.TVTImportRegisterVO;
import jp.co.isid.ham.media.model.UpdABOrderOutRegisterResult;
import jp.co.isid.ham.media.model.UpdABOrderOutRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * 媒体サービス
 * </P>
 * <P>
 * 媒体サービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/10/04 JSE H.Abe)<BR>
 * ・JASRAC対応(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "mediaService", targetNamespace = "http://media.service.ham.isid.co.jp/")
public class MediaService {

    /**
     * キャンペーン一覧データを取得する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCampaignListResult")
    public FindCampaignListResult findCampaignList(
            @WebParam(name = "condition") FindCampaignListCondition condition)
            throws ServiceException {

        try {
            FindCampaignListCmd cmd = new FindCampaignListCmd();
            cmd.setCampaignListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignListResult();
        } catch (HAMException e) {
            FindCampaignListResult result = new FindCampaignListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * キャンペーン一覧データを取得する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCampaignListResult")
    public FindCampaignListResult findCampaignListHomeLoad(
            @WebParam(name = "condition") FindCampaignListCondition condition)
            throws ServiceException {

        try {
            FindCampaignListHomeLoadCmd cmd = new FindCampaignListHomeLoadCmd();
            cmd.setCampaignListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignListResult();
        } catch (HAMException e) {
            FindCampaignListResult result = new FindCampaignListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳データを取得する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindAuthorityAccountBookResult")
    public FindAuthorityAccountBookResult FindAuthorityAccountBook(
            @WebParam(name = "condition") FindAuthorityAccountBookCondition condition)
            throws ServiceException {

        try {
            FindAuthorityAccountBookCmd cmd = new FindAuthorityAccountBookCmd();
            cmd.setAuthorityAccountBookCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getAuthorityAccountBookResult();
        } catch (HAMException e) {
            FindAuthorityAccountBookResult result = new FindAuthorityAccountBookResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳変更ログデータを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindAccountBookLogResult")
    public FindAccountBookLogResult FindAccountBookLog(
            @WebParam(name = "condition") FindAccountBookLogCondition condition)
            throws ServiceException {
        try {
            FindAccountBookLogCmd cmd = new FindAccountBookLogCmd();
            cmd.setAccountBookLogCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getAccountBookLogResult();
        } catch (HAMException e) {
            FindAccountBookLogResult result = new FindAccountBookLogResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * キャンペーン内容データを取得する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCampaignDetailsResult")
    public FindCampaignDetailsResult findCampaignDetails(
            @WebParam(name = "condition") FindCampaignDetailsCondition condition)
            throws ServiceException {

        try {
            FindCampaignDetailsCmd cmd = new FindCampaignDetailsCmd();
            cmd.setCampaignDetailsCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignDetailsResult();
        } catch (HAMException e) {
            FindCampaignDetailsResult result = new FindCampaignDetailsResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * キャンペーン内容データを取得する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCampaignDetailsResult")
    public FindCampaignDetailsResult findCampaignDetailsHomeLoad(
            @WebParam(name = "condition") FindCampaignDetailsCondition condition)
            throws ServiceException {

        try {
            FindCampaignDetailsHomeLoadCmd cmd = new FindCampaignDetailsHomeLoadCmd();
            cmd.setCampaignDetailsCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignDetailsResult();
        } catch (HAMException e) {
            FindCampaignDetailsResult result = new FindCampaignDetailsResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * キャンペー一覧を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "CampaignRegisterResult")
    public CampaignRegisterResult CampaignListRegister(
            @WebParam(name = "condition") CampaignRegisterCondition condition)
            throws ServiceException {

        try {
            CampaignRegisterCmd cmd = new CampaignRegisterCmd();
            cmd.setCampaignRegisterResult(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignRegisterResult();
        } catch (HAMException e) {
            CampaignRegisterResult result = new CampaignRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * キャンペー詳細を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "CampaignRegisterResult")
    public CampaignRegisterResult CampaignDetailsRegister(
            @WebParam(name = "condition") CampaignRegisterDetailsCondition condition)
            throws ServiceException {

        try {
            CampaignRegisterDetailsCmd cmd = new CampaignRegisterDetailsCmd();
            cmd.setCampaignRegisterDetailsResult(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCampaignRegisterDetailsResult();
        } catch (HAMException e) {
            CampaignRegisterResult result = new CampaignRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "AccountBookRegisterResult")
    public AccountBookRegisterResult AccountBookRegister(
            @WebParam(name = "vo")AccountBookRegisterVO vo)
            throws ServiceException {

        try {
            AccountBookRegisterCmd cmd = new AccountBookRegisterCmd();
            cmd.setAccountBookegisterResult(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getAccountBookRegisterResult();
        } catch (HAMException e) {
            AccountBookRegisterResult result = new AccountBookRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 媒体状況管理を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MepiaPlanRegisterResult")
    public MediaPlanRegisterResult MediaPlanRegisterByCampDetails(
            @WebParam(name = "condition") MediaPlanRegisterCondition condition)
            throws ServiceException {

        try {
            MepiaPlanRegisterByCampDetailsCmd cmd = new MepiaPlanRegisterByCampDetailsCmd();
            cmd.setMepiaPlanRegisterResult(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMepiaPlanRegisterResult();
        } catch (HAMException e) {
            MediaPlanRegisterResult result = new MediaPlanRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 入力拒否データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindInputRejectionResult")
    public FindInputRejectionResult FindInputRejection(
            @WebParam(name = "condition") FindInputRejectionCondition condition)
            throws ServiceException {

        try {
            FindInputRejectionCmd cmd = new FindInputRejectionCmd();
            cmd.setInputRejectionCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindInputRejectionResult();
        } catch (HAMException e) {
            FindInputRejectionResult result = new FindInputRejectionResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 車種合計金額データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindSumCarResult")
    public FindSumCarResult FindSumCar(
            @WebParam(name = "condition") Tbj01MediaPlanCondition condition)
            throws ServiceException {
        try {
            FindSumCarCmd cmd = new FindSumCarCmd();
            cmd.setTbj01MediaPlanCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindSumCarResult();
        } catch (HAMException e) {
            FindSumCarResult result = new FindSumCarResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳帳票画面表示データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindAccountBookOutputResult")
    public FindAccountBookOutputResult FindAccountBookOutput(
            @WebParam(name = "condition") FindAccountBookOutputCondition condition)
            throws ServiceException {
        try {
            FindAccountBookOutputCmd cmd = new FindAccountBookOutputCmd();
            cmd.setAccountBookOutputCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getAccountBookOutpurResult();
        } catch (HAMException e) {
            FindAccountBookOutputResult result = new FindAccountBookOutputResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳帳票出力データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindAccountBookOutputDataResult")
    public FindAccountBookOutPutDataResult FindAccountBookOutputData(
            @WebParam(name = "condition") FindAccountBookOutPutDataCondition condition)
            throws ServiceException {
        try {
            FindAccountBookOutPutDataCmd cmd = new FindAccountBookOutPutDataCmd();
            cmd.setAccountBookOutPutDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindAccountBookOutPutDataResult();
        } catch (HAMException e) {
            FindAccountBookOutPutDataResult result = new FindAccountBookOutPutDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 請求明細書画面表示データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindBillStatementResult")
    public FindBillStatementResult FindBillStatement(
            @WebParam(name = "condition") FindBillStatementCondition condition)
            throws ServiceException {
        try {
            FindBillStatementCmd cmd = new FindBillStatementCmd();
            cmd.setBillStatementCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getBillStatementResult();
        } catch (HAMException e) {
            FindBillStatementResult result = new FindBillStatementResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 請求明細書出力データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindBillStatementDataResult")
    public FindBillStatementDataResult FindBillStatementData(
            @WebParam(name = "condition") FindBillStatementDataCondition condition)
            throws ServiceException {
        try {
            FindBillStatementDataCmd cmd = new FindBillStatementDataCmd();
            cmd.setBillStatementDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getBillStatementDataResult();
        } catch (HAMException e) {
            FindBillStatementDataResult result = new FindBillStatementDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 媒体状況管理画面表示データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMediaPlanResult")
    public FindMediaPlanResult FindMediaPlan(
            @WebParam(name = "condition") FindMediaPlanCondition condition)
            throws ServiceException {
        try {
            FindMediaPlanCmd cmd = new FindMediaPlanCmd();
            cmd.setFindMediaPlanCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMediaPlanResult();
        } catch (HAMException e) {
            FindMediaPlanResult result = new FindMediaPlanResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * TimeExcel取込に必要なデータを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindTimeExcelImportResult")
    public FindTimeExcelImportResult FindTimeExcelImport(
            @WebParam(name = "condition") FindTimeExcelImportCondition condition)
            throws ServiceException {
        try {
            FindTimeExcelImportCmd cmd = new FindTimeExcelImportCmd();
            cmd.setFindTimeExcelImportCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getTimeExcelImportResult();
        } catch (HAMException e) {
            FindTimeExcelImportResult result = new FindTimeExcelImportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "TVTImportRegisterResult")
    public TVTImportRegisterResult TVTImportRegister(
            @WebParam(name = "vo")TVTImportRegisterVO vo)
            throws ServiceException {

        try {
            TVTImportRegisterCmd cmd = new TVTImportRegisterCmd();
            cmd.setTVTImportRegisterCondition(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getTVTImportRegisterResult();
        } catch (HAMException e) {
            TVTImportRegisterResult result = new TVTImportRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * Excel取込エラー画面の表示データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindExcelInputErrorResult")
    public FindExcelInputErrorResult FindExcelInputError(
            @WebParam(name = "condition") FindExcelInputErrorCondition condition)
            throws ServiceException {
        try {
            FindExcelInputErrorCmd cmd = new FindExcelInputErrorCmd();
            cmd.setFindExcelInputErrorCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindExcelInputErrorResult();
        } catch (HAMException e) {
            FindExcelInputErrorResult result = new FindExcelInputErrorResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MediaPlanRegisterResult")
    public MediaPlanRegisterResult MediaPlanRegister(
            @WebParam(name = "vo") MediaPlanRegisterVO vo)
            throws ServiceException {

        try {
            MediaPlanRegisterCmd cmd = new MediaPlanRegisterCmd();
            cmd.setMediaPlanRegisterResult(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMediaPlanRegisterResult();
        } catch (HAMException e) {
            MediaPlanRegisterResult result = new MediaPlanRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * Excel取込エラー画面の表示データを検索する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMediaPlanSelectResult")
    public FindMediaPlanSelectResult FindMediaPlanSelect(
            @WebParam(name = "condition") FindMediaPlanSelectCondition condition)
            throws ServiceException {
        try {
            FindMediaPlanSelectCmd cmd = new FindMediaPlanSelectCmd();
            cmd.setFindMediaPlanSelectCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindMediaPlanSelectResult();
        } catch (HAMException e) {
            FindMediaPlanSelectResult result = new FindMediaPlanSelectResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * グロス料金合計を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException エラー内容
     */
    @WebMethod
    @WebResult(name = "FindGrossSumResult")
    public FindGrossSumResult FindGrossSum(
            @WebParam(name = "condition") Tbj02EigyoDaichoCondition condition)
            throws ServiceException{
        try {
            FindGrossSumCmd cmd = new FindGrossSumCmd();
            cmd.setTbj02EigyoDaichoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindGrossSumResult();
        } catch (HAMException e) {
            FindGrossSumResult result = new FindGrossSumResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材管理リストを検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindSozaiDataByRCodeResult")
    public FindSozaiDataByRCodeResult FindSozaiDataByRCode(
            @WebParam(name = "condition") Tbj20SozaiKanriListCondition condition)
            throws ServiceException{
        try {
            FindSozaiDataByRCodeCmd cmd = new FindSozaiDataByRCodeCmd();
            cmd.setSozaiKanriCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getSozaiDataByRCodeResult();
        } catch (HAMException e) {
            FindSozaiDataByRCodeResult result = new FindSozaiDataByRCodeResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 媒体パターンリストを検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMediaPatternResult")
    public FindMediaPatternResult FindMediaPattern(
            @WebParam(name = "condition") FindMediaPatternCondition condition)
            throws ServiceException{
        try {
            FindMediaPatternCmd cmd = new FindMediaPatternCmd();
            cmd.setFindMediaPatternCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMediaPatternResult();
        } catch (HAMException e) {
            FindMediaPatternResult result = new FindMediaPatternResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 媒体を全社マスタから検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMediaByCommonMaster")
    public FindMediaByCommonMasterResult FindMediaByCommonMaster(
            @WebParam(name = "condition") FindMediaByCommonMasterCondition condition)
            throws ServiceException{
        try {
            FindMediaByCommonMasterCmd cmd = new FindMediaByCommonMasterCmd();
            cmd.setFindMediaByCommonMasterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindMediaByCommonMasterResult();
        } catch (HAMException e) {
            FindMediaByCommonMasterResult result = new FindMediaByCommonMasterResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * DKB連携用データを検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindCooperationData")
    public FindCooperationDataResult FindCooperationData(
            @WebParam(name = "condition") FindCooperationDataCondition condition)
            throws ServiceException{
        try {
            FindCooperationDataCmd cmd = new FindCooperationDataCmd();
            cmd.setCooperationDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCooperationDataResult();
        } catch (HAMException e) {
            FindCooperationDataResult result = new FindCooperationDataResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 受注ファイル検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindOrderSelect")
    public FindOrderSelectResult FindOrderSelect(
            @WebParam(name = "condition") FindOrderSelectCondition condition)
            throws ServiceException{
        try {
            FindOrderSelectCmd cmd = new FindOrderSelectCmd();
            cmd.setFindOrderSelectCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getOrderSelectResult();
        } catch (HAMException e) {
            FindOrderSelectResult result = new FindOrderSelectResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳を更新する
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "UpdABOrderOutRegisterResult")
    public UpdABOrderOutRegisterResult UpdABOrderRegister(
            @WebParam(name = "vo")UpdABOrderOutRegisterVO vo)
            throws ServiceException {

        try {
            UpdABOrderOutRegisterCmd cmd = new UpdABOrderOutRegisterCmd();
            cmd.setUpdABOrderOutRegisterVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getUpdABOrderOutRegisterResult();
        } catch (HAMException e) {
            UpdABOrderOutRegisterResult result = new UpdABOrderOutRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindAccountBookResult findAccountBook(
            @WebParam(name = "condition") FindAccountBookCondition condition)
            throws ServiceException{
        try {
            FindAccountBookCmd cmd = new FindAccountBookCmd();
            cmd.setFindAccountBookCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindAccountBookResult();
        } catch (HAMException e) {
            FindAccountBookResult result = new FindAccountBookResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 送稿表の画面表示データを検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindDocumentTransmissionResult findDocumentTransmission(
            @WebParam(name = "condition") FindDocumentTransmissionCondition condition)
            throws ServiceException{
        try {
            FindDocumentTransmissionCmd cmd = new FindDocumentTransmissionCmd();
            cmd.setFindDocumentTransmissionCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindDocumentTransmissionResult ftResult = cmd.getFindDocumentTransmissionResult();
            return ftResult;
        } catch (HAMException e) {
            FindDocumentTransmissionResult result = new FindDocumentTransmissionResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 送稿表の帳票出力データを検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindDocTransReportResult findFindDocTransReport(
            @WebParam(name = "condition") FindDocTransReportCondition condition)
            throws ServiceException{
        try {
            FindDocTransReportCmd cmd = new FindDocTransReportCmd();
            cmd.setFindDocTransReportCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindDocTransReportResult ftResult = cmd.getFindDocTransReportResult();
            return ftResult;
        } catch (HAMException e) {
            FindDocTransReportResult result = new FindDocTransReportResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2015/10/31 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * ラジオ番組登録画面登録情報を登録する
     * @param vo 登録情報
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterRdProgramInfoResult")
    public RegisterRdProgramInfoResult registerRdProgramRegister(@WebParam(name = "vo")RegisterRdProgramInfoVO vo) throws ServiceException {

        try {
            RegisterRdProgramInfoCmd cmd = new RegisterRdProgramInfoCmd();
            cmd.setRegisterRdProgramInfoVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterRdProgramInfoResult();
        } catch (HAMException e) {
            RegisterRdProgramInfoResult result = new RegisterRdProgramInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * ラジオ番組一覧画面表示情報を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindRdProgramResult")
    public FindRdProgramResult findRdProgram(@WebParam(name = "condition") FindRdProgramCondition condition) throws ServiceException {

        try {
            FindRdProgramCmd cmd = new FindRdProgramCmd();
            cmd.setFindRdProgramCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindRdProgramResult result = cmd.getFindRdProgramResult();
            return result;
        } catch (HAMException e) {
            FindRdProgramResult result = new FindRdProgramResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * ラジオ番組登録画面表示情報を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindRdProgramRegisterResult")
    public FindRdProgramRegisterResult findRdProgramRegister(@WebParam(name = "condition") FindRdProgramRegisterCondition condition) throws ServiceException {

        try {
            FindRdProgramRegisterCmd cmd = new FindRdProgramRegisterCmd();
            cmd.setFindRdProgramRegisterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindRdProgramRegisterResult result = cmd.getFindRdProgramResult();
            return result;
        } catch (HAMException e) {
            FindRdProgramRegisterResult result = new FindRdProgramRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * ラジオ局選択画面表示情報を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindRdStationSelectResult")
    public FindRdStationSelectResult findRdStationSelect(@WebParam(name = "condition") FindRdStationSelectCondition condition) throws ServiceException {

        try {
            FindRdStationSelectCmd cmd = new FindRdStationSelectCmd();
            cmd.setFindRdStationSelectCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindRdStationSelectResult result = cmd.getFindRdStationSelectResult();
            return result;
        } catch (HAMException e) {
            FindRdStationSelectResult result = new FindRdStationSelectResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * ラジオ版AllocationPicture出力情報を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindRdAllocationPictureResult")
    public FindRdAllocationPictureResult findRdAllocationPicture(@WebParam(name = "condition") FindRdAllocationPictureCondition condition) throws ServiceException {

        try {
            FindRdAllocationPictureCmd cmd = new FindRdAllocationPictureCmd();
            cmd.setFindRdAllocationPictureCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            FindRdAllocationPictureResult result = cmd.getFindRdAllocationPictureResult();
            return result;
        } catch (HAMException e) {
            FindRdAllocationPictureResult result = new FindRdAllocationPictureResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 営業作業台帳ラジオタイムインポート情報を登録する
     * @param condition 検索条件
     * @return 実行結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RdTime2AccountBookRegisterResult")
    public RdTime2AccountBookRegisterResult registerRdTime2AccountBook(@WebParam(name = "condition") FindRdTime2AccountBookCondition condition) throws ServiceException {

        try {
            RegisterRdTime2AccountBookCmd cmd = new RegisterRdTime2AccountBookCmd();
            cmd.setFindRdTime2AccountBookCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            RdTime2AccountBookRegisterResult result = cmd.getRdTimeImportRegisterResult();
            return result;
        } catch (HAMException e) {
            RdTime2AccountBookRegisterResult result = new RdTime2AccountBookRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch(Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2015/10/31 JASRAC対応 HLC S.Fujimoto ADD End */

}
