package jp.co.isid.ham.mastermaintenance.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.mastermaintenance.controller.*;
import jp.co.isid.ham.mastermaintenance.model.*;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * マスタメンテナンスサービス
 * </P>
 * <P>
 * マスタメンテナンスサービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/10/04 JSE H.Abe)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * ・HDX対応(2016/02/17 HLC K.Oki)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "mastermaintenanceService", targetNamespace = "http://mastermaintenance.service.ham.isid.co.jp/")
public class MasterMaintenanceService
{
    /**
     * MasterForm表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMasterFormDispResult 表示情報
     * @throws ServiceException
     */
    @WebResult(name = "FindMasterMaintenanceMasterFormDispResult")
    public FindMasterMaintenanceMasterFormDispResult findMasterFormByCondition(@WebParam(name = "condtion") FindMasterMaintenanceMasterFormDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMasterFormCmd cmd = new FindMasterMaintenanceMasterFormCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMasterFormDispResult result = new FindMasterMaintenanceMasterFormDispResult();
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
     * 過去ロック表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registLockData(@WebParam(name = "vo") RegistMasterMaintenanceLockDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceLockCmd cmd = new RegistMasterMaintenanceLockCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 過去ロック表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceLockDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceLockDispResult")
    public FindMasterMaintenanceLockDispResult findLockByCondition(@WebParam(name = "condtion") FindMasterMaintenanceLockDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceLockCmd cmd = new FindMasterMaintenanceLockCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceLockDispResult result = new FindMasterMaintenanceLockDispResult();
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
     * 担当者表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registUserData(@WebParam(name = "vo") RegistMasterMaintenanceUserDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceUserCmd cmd = new RegistMasterMaintenanceUserCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 担当者表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceUserDispResult")
    public FindMasterMaintenanceUserDispResult findUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceUserDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceUserCmd cmd = new FindMasterMaintenanceUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceUserDispResult result = new FindMasterMaintenanceUserDispResult();
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
     * 権限表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registAuthorityData(@WebParam(name = "vo") RegistMasterMaintenanceAuthorityDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceAuthorityCmd cmd = new RegistMasterMaintenanceAuthorityCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 権限表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceAuthorityDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceAuthorityDispResult")
    public FindMasterMaintenanceAuthorityDispResult findAuthorityByCondition(@WebParam(name = "condtion") FindMasterMaintenanceAuthorityDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceAuthorityCmd cmd = new FindMasterMaintenanceAuthorityCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceAuthorityDispResult result = new FindMasterMaintenanceAuthorityDispResult();
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
     * 系列表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registSeriesData(@WebParam(name = "vo") RegistMasterMaintenanceSeriesDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceSeriesCmd cmd = new RegistMasterMaintenanceSeriesCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 系列表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceSeriesDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceSeriesDispResult")
    public FindMasterMaintenanceSeriesDispResult findSeriesByCondition(@WebParam(name = "condtion") FindMasterMaintenanceSeriesDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceSeriesCmd cmd = new FindMasterMaintenanceSeriesCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceSeriesDispResult result = new FindMasterMaintenanceSeriesDispResult();
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
     * 系列情報をチェックします
     *
     * @param vo 対象データ
     * @return ChackRegistMasterMaintenanceResult チェック結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ChackRegistMasterMaintenanceResult")
    public CheckRegistMasterMaintenanceResult checkSeries(@WebParam(name = "vo") RegistMbj04KeiretsuVO vo) throws ServiceException
    {
        try
        {
            CheckRegistMasterMaintenanceSeriesCmd cmd = new CheckRegistMasterMaintenanceSeriesCmd();
            cmd.setCheckRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckRegistResult();
        }
        catch (HAMException e)
        {
            CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
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
     * 車種表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCarData(@WebParam(name = "vo") RegistMasterMaintenanceCarDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCarCmd cmd = new RegistMasterMaintenanceCarCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 車種表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCarDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCarDispResult")
    public FindMasterMaintenanceCarDispResult findCarByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCarDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCarCmd cmd = new FindMasterMaintenanceCarCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCarDispResult result = new FindMasterMaintenanceCarDispResult();
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
     * 媒体表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registMediaData(@WebParam(name = "vo") RegistMasterMaintenanceMediaDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceMediaCmd cmd = new RegistMasterMaintenanceMediaCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 媒体表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMediaDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceMediaDispResult")
    public FindMasterMaintenanceMediaDispResult findMediaByCondition(@WebParam(name = "condtion") FindMasterMaintenanceMediaDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMediaCmd cmd = new FindMasterMaintenanceMediaCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMediaDispResult result = new FindMasterMaintenanceMediaDispResult();
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
     * 費用企画No表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCostPlanData(@WebParam(name = "vo") RegistMasterMaintenanceCostPlanDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCostPlanCmd cmd = new RegistMasterMaintenanceCostPlanCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 費用企画No表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCostPlanDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCostPlanDispResult")
    public FindMasterMaintenanceCostPlanDispResult findCostPlanByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCostPlanDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCostPlanCmd cmd = new FindMasterMaintenanceCostPlanCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCostPlanDispResult result = new FindMasterMaintenanceCostPlanDispResult();
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
     * 車種カテゴリ表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCarCategoryData(@WebParam(name = "vo") RegistMasterMaintenanceCarCategoryDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCarCategoryCmd cmd = new RegistMasterMaintenanceCarCategoryCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 車種カテゴリ表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCarCategoryDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCarCategoryDispResult")
    public FindMasterMaintenanceCarCategoryDispResult findCarCategoryByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCarCategoryDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCarCategoryCmd cmd = new FindMasterMaintenanceCarCategoryCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCarCategoryDispResult result = new FindMasterMaintenanceCarCategoryDispResult();
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
     * 車種カテゴリ紐付表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCarCategoryContentData(@WebParam(name = "vo") RegistMasterMaintenanceCarCategoryContentDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCarCategoryContentCmd cmd = new RegistMasterMaintenanceCarCategoryContentCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 車種カテゴリ紐付表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCarCategoryContentDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCarCategoryContentDispResult")
    public FindMasterMaintenanceCarCategoryContentDispResult findCarCategoryContentByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCarCategoryContentDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCarCategoryContentCmd cmd = new FindMasterMaintenanceCarCategoryContentCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCarCategoryContentDispResult result = new FindMasterMaintenanceCarCategoryContentDispResult();
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
     * 車種担当表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCarUserData(@WebParam(name = "vo") RegistMasterMaintenanceCarUserDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCarUserCmd cmd = new RegistMasterMaintenanceCarUserCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 車種担当表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCarUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCarUserDispResult")
    public FindMasterMaintenanceCarUserDispResult findCarUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCarUserDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCarUserCmd cmd = new FindMasterMaintenanceCarUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCarUserDispResult result = new FindMasterMaintenanceCarUserDispResult();
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
     * 請求先グループ表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registDemandGroupData(@WebParam(name = "vo") RegistMasterMaintenanceDemandGroupDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceDemandGroupCmd cmd = new RegistMasterMaintenanceDemandGroupCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 請求先グループ表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceDemandGroupDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceDemandGroupDispResult")
    public FindMasterMaintenanceDemandGroupDispResult findDemandGroupByCondition(@WebParam(name = "condtion") FindMasterMaintenanceDemandGroupDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceDemandGroupCmd cmd = new FindMasterMaintenanceDemandGroupCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceDemandGroupDispResult result = new FindMasterMaintenanceDemandGroupDispResult();
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
     * 請求先グループ情報をチェックします
     *
     * @param vo 対象データ
     * @return ChackRegistMasterMaintenanceResult チェック結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ChackRegistMasterMaintenanceResult")
    public CheckRegistMasterMaintenanceResult checkDemandGroup(@WebParam(name = "vo") RegistMbj26BillGroupVO vo) throws ServiceException
    {
        try
        {
            CheckRegistMasterMaintenanceDemandGroupCmd cmd = new CheckRegistMasterMaintenanceDemandGroupCmd();
            cmd.setCheckRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckRegistResult();
        }
        catch (HAMException e)
        {
            CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
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
     * HC部門表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registHCSectionData(@WebParam(name = "vo") RegistMasterMaintenanceHCSectionDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceHCSectionCmd cmd = new RegistMasterMaintenanceHCSectionCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * HC部門表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceHCSectionDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceHCSectionDispResult")
    public FindMasterMaintenanceHCSectionDispResult findHCSectionByCondition(@WebParam(name = "condtion") FindMasterMaintenanceHCSectionDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceHCSectionCmd cmd = new FindMasterMaintenanceHCSectionCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceHCSectionDispResult result = new FindMasterMaintenanceHCSectionDispResult();
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
     * HC部門情報をチェックします
     *
     * @param vo 対象データ
     * @return ChackRegistMasterMaintenanceResult チェック結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ChackRegistMasterMaintenanceResult")
    public CheckRegistMasterMaintenanceResult checkHCSection(@WebParam(name = "vo") RegistMbj06HcBumonVO vo) throws ServiceException
    {
        try
        {
            CheckRegistMasterMaintenanceHCSectionCmd cmd = new CheckRegistMasterMaintenanceHCSectionCmd();
            cmd.setCheckRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckRegistResult();
        }
        catch (HAMException e)
        {
            CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
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
     * HC担当者表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registHCUserData(@WebParam(name = "vo") RegistMasterMaintenanceHCUserDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceHCUserCmd cmd = new RegistMasterMaintenanceHCUserCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * HC担当者表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceHCUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceHCUserDispResult")
    public FindMasterMaintenanceHCUserDispResult findHCUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceHCUserDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceHCUserCmd cmd = new FindMasterMaintenanceHCUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceHCUserDispResult result = new FindMasterMaintenanceHCUserDispResult();
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
     * HC商品表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registHCProductData(@WebParam(name = "vo") RegistMasterMaintenanceHCProductDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceHCProductCmd cmd = new RegistMasterMaintenanceHCProductCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * HC商品表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceHCProductDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceHCProductDispResult")
    public FindMasterMaintenanceHCProductDispResult findHCProductByCondition(@WebParam(name = "condtion") FindMasterMaintenanceHCProductDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceHCProductCmd cmd = new FindMasterMaintenanceHCProductCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceHCProductDispResult result = new FindMasterMaintenanceHCProductDispResult();
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
     * 媒体・商品紐付表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registMediaProductData(@WebParam(name = "vo") RegistMasterMaintenanceMediaProductDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceMediaProductCmd cmd = new RegistMasterMaintenanceMediaProductCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 媒体・商品紐付表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMediaProductDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceMediaProductDispResult")
    public FindMasterMaintenanceMediaProductDispResult findMediaProductByCondition(@WebParam(name = "condtion") FindMasterMaintenanceMediaProductDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMediaProductCmd cmd = new FindMasterMaintenanceMediaProductCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMediaProductDispResult result = new FindMasterMaintenanceMediaProductDispResult();
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
     * 設定局表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registEstablishmentOfficeData(@WebParam(name = "vo") RegistMasterMaintenanceEstablishmentOfficeDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceEstablishmentOfficeCmd cmd = new RegistMasterMaintenanceEstablishmentOfficeCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 設定局表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceEstablishmentOfficeDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceEstablishmentOfficeDispResult")
    public FindMasterMaintenanceEstablishmentOfficeDispResult findEstablishmentOfficeByCondition(@WebParam(name = "condtion") FindMasterMaintenanceEstablishmentOfficeDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceEstablishmentOfficeCmd cmd = new FindMasterMaintenanceEstablishmentOfficeCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceEstablishmentOfficeDispResult result = new FindMasterMaintenanceEstablishmentOfficeDispResult();
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
     * 設定局情報をチェックします
     *
     * @param vo 対象データ
     * @return ChackRegistMasterMaintenanceResult チェック結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ChackRegistMasterMaintenanceResult")
    public CheckRegistMasterMaintenanceResult checkEstablishmentOffice(@WebParam(name = "vo") RegistMbj29SetteiKykVO vo) throws ServiceException
    {
        try
        {
            CheckRegistMasterMaintenanceEstablishmentOfficeCmd cmd = new CheckRegistMasterMaintenanceEstablishmentOfficeCmd();
            cmd.setCheckRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckRegistResult();
        }
        catch (HAMException e)
        {
            CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
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
     * 入力担当表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registInputUserData(@WebParam(name = "vo") RegistMasterMaintenanceInputUserDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceInputUserCmd cmd = new RegistMasterMaintenanceInputUserCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 入力担当表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceInputUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceInputUserDispResult")
    public FindMasterMaintenanceInputUserDispResult findInputUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceInputUserDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceInputUserCmd cmd = new FindMasterMaintenanceInputUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceInputUserDispResult result = new FindMasterMaintenanceInputUserDispResult();
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
     * 入力担当情報をチェックします
     *
     * @param vo 対象データ
     * @return ChackRegistMasterMaintenanceResult チェック結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ChackRegistMasterMaintenanceResult")
    public CheckRegistMasterMaintenanceResult checkInputUser(@WebParam(name = "vo") RegistMbj30InputTntVO vo) throws ServiceException
    {
        try
        {
            CheckRegistMasterMaintenanceInputUserCmd cmd = new CheckRegistMasterMaintenanceInputUserCmd();
            cmd.setCheckRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCheckRegistResult();
        }
        catch (HAMException e)
        {
            CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
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
     * 機能制御表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registFunctionControlData(@WebParam(name = "vo") RegistMasterMaintenanceFunctionControlDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceFunctionControlCmd cmd = new RegistMasterMaintenanceFunctionControlCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 機能制御表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceFunctionControlDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceFunctionControlDispResult")
    public FindMasterMaintenanceFunctionControlDispResult findFunctionControlByCondition(@WebParam(name = "condtion") FindMasterMaintenanceFunctionControlDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceFunctionControlCmd cmd = new FindMasterMaintenanceFunctionControlCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceFunctionControlDispResult result = new FindMasterMaintenanceFunctionControlDispResult();
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
     * インフォメーション表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registInformationData(@WebParam(name = "vo") RegistMasterMaintenanceInformationDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceInformationCmd cmd = new RegistMasterMaintenanceInformationCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * インフォメーション表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceInformationDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceInformationDispResult")
    public FindMasterMaintenanceInformationDispResult findInformationByCondition(@WebParam(name = "condtion") FindMasterMaintenanceInformationDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceInformationCmd cmd = new FindMasterMaintenanceInformationCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceInformationDispResult result = new FindMasterMaintenanceInformationDispResult();
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
     * 部署表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registDepartmentData(@WebParam(name = "vo") RegistMasterMaintenanceDepartmentDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceDepartmentCmd cmd = new RegistMasterMaintenanceDepartmentCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 部署表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceDepartmentDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceDepartmentDispResult")
    public FindMasterMaintenanceDepartmentDispResult findDepartmentByCondition(@WebParam(name = "condtion") FindMasterMaintenanceDepartmentDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceDepartmentCmd cmd = new FindMasterMaintenanceDepartmentCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceDepartmentDispResult result = new FindMasterMaintenanceDepartmentDispResult();
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
     * 媒体パターン表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registMediaPatternData(@WebParam(name = "vo") RegistMasterMaintenanceMediaPatternDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceMediaPatternCmd cmd = new RegistMasterMaintenanceMediaPatternCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 媒体パターン表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMediaPatternDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceMediaPatternDispResult")
    public FindMasterMaintenanceMediaPatternDispResult findMediaPatternByCondition(@WebParam(name = "condtion") FindMasterMaintenanceMediaPatternDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMediaPatternCmd cmd = new FindMasterMaintenanceMediaPatternCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMediaPatternDispResult result = new FindMasterMaintenanceMediaPatternDispResult();
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
     * メール配信先表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registAlertMailAddressData(@WebParam(name = "vo") RegistMasterMaintenanceAlertMailAddressDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceAlertMailAddressCmd cmd = new RegistMasterMaintenanceAlertMailAddressCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * メール配信先表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceAlertMailAddressDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceAlertMailAddressDispResult")
    public FindMasterMaintenanceAlertMailAddressDispResult findAlertMailAddressByCondition(@WebParam(name = "condtion") FindMasterMaintenanceAlertMailAddressDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceAlertMailAddressCmd cmd = new FindMasterMaintenanceAlertMailAddressCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceAlertMailAddressDispResult result = new FindMasterMaintenanceAlertMailAddressDispResult();
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
     * アラート表示制御表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registAlertDispControlData(@WebParam(name = "vo") RegistMasterMaintenanceAlertDispControlDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceAlertDispControlCmd cmd = new RegistMasterMaintenanceAlertDispControlCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * アラート表示制御表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceAlertDispControlDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceAlertDispControlDispResult")
    public FindMasterMaintenanceAlertDispControlDispResult findAlertDispControlByCondition(@WebParam(name = "condtion") FindMasterMaintenanceAlertDispControlDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceAlertDispControlCmd cmd = new FindMasterMaintenanceAlertDispControlCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceAlertDispControlDispResult result = new FindMasterMaintenanceAlertDispControlDispResult();
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
     * 新聞マスタ表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registNewspaperData(@WebParam(name = "vo") RegistMasterMaintenanceNewspaperDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceNewspaperCmd cmd = new RegistMasterMaintenanceNewspaperCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 新聞マスタ表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceNewspaperDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceNewspaperDispResult")
    public FindMasterMaintenanceNewspaperDispResult findNewspaperByCondition(@WebParam(name = "condtion") FindMasterMaintenanceNewspaperDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceNewspaperCmd cmd = new FindMasterMaintenanceNewspaperCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceNewspaperDispResult result = new FindMasterMaintenanceNewspaperDispResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e)
        {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM担当者表示情報を登録する
     * @param vo 登録データ
     * @return 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registHMUserData(@WebParam(name = "vo") RegistMasterMaintenanceHMUserDispVO vo) throws ServiceException {

        try {
            RegistMasterMaintenanceHMUserCmd cmd = new RegistMasterMaintenanceHMUserCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e) {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * HM担当者表示情報を取得する
     * @param condition 検索条件
     * @return FindMasterMaintenanceHMUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceHMUserDispResult")
    public FindMasterMaintenanceHMUserDispResult findHMUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceHMUserDispCondition condition) throws ServiceException {

        try {
            FindMasterMaintenanceHMUserCmd cmd = new FindMasterMaintenanceHMUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e) {
            FindMasterMaintenanceHMUserDispResult result = new FindMasterMaintenanceHMUserDispResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /**
     * 個人情報View表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceAccUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceAccUserDispResult")
    public FindMasterMaintenanceAccUserDispResult findAccUserByCondition(@WebParam(name = "condtion") FindMasterMaintenanceAccUserDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceAccUserCmd cmd = new FindMasterMaintenanceAccUserCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceAccUserDispResult result = new FindMasterMaintenanceAccUserDispResult();
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
     * 個人情報View表示情報を取得します（含む検索）
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceAccUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceAccUserDispResult")
    public FindMasterMaintenanceAccUserDispResult findAccUserByLikeCondition(@WebParam(name = "condtion") FindMasterMaintenanceAccUserDispLikeCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceAccUserLikeCmd cmd = new FindMasterMaintenanceAccUserLikeCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceAccUserDispResult result = new FindMasterMaintenanceAccUserDispResult();
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
     * 経理組織展開テーブル表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMEU07SIKKRSPRDDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceMEU07SIKKRSPRDDispResult")
    public FindMasterMaintenanceMEU07SIKKRSPRDDispResult findMEU07SIKKRSPRDByCondition(@WebParam(name = "condtion") FindMasterMaintenanceMEU07SIKKRSPRDDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMEU07SIKKRSPRDCmd cmd = new FindMasterMaintenanceMEU07SIKKRSPRDCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMEU07SIKKRSPRDDispResult result = new FindMasterMaintenanceMEU07SIKKRSPRDDispResult();
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
     * 経理組織展開テーブル表示情報を取得します（含む検索）
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceMEU07SIKKRSPRDDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceMEU07SIKKRSPRDDispResult")
    public FindMasterMaintenanceMEU07SIKKRSPRDDispResult findMEU07SIKKRSPRDByLikeCondition(@WebParam(name = "condtion") FindMasterMaintenanceMEU07SIKKRSPRDDispLikeCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceMEU07SIKKRSPRDLikeCmd cmd = new FindMasterMaintenanceMEU07SIKKRSPRDLikeCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceMEU07SIKKRSPRDDispResult result = new FindMasterMaintenanceMEU07SIKKRSPRDDispResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e)
        {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2016/02/17 HDX対応 HLC K.Oki ADD Start */
    /**
     * 車種担当者(素材)表示情報を登録します
     *
     * @param vo 登録データ
     * @return RegistMasterMaintenanceDispResult 登録結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistMasterMaintenanceDispResult")
    public RegistMasterMaintenanceDispResult registCarUserSozaiData(@WebParam(name = "vo") RegistMasterMaintenanceCarUserSozaiDispVO vo) throws ServiceException
    {
        try
        {
            RegistMasterMaintenanceCarUserSozaiCmd cmd = new RegistMasterMaintenanceCarUserSozaiCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
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
     * 車種担当者(素材)表示情報を取得します
     *
     * @param condition 検索条件
     * @return FindMasterMaintenanceCarUserDispResult 表示情報
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindMasterMaintenanceCarUserSozaiDispResult")
    public FindMasterMaintenanceCarUserSozaiDispResult findCarUserSozaiByCondition(@WebParam(name = "condtion") FindMasterMaintenanceCarUserSozaiDispCondition condition) throws ServiceException
    {
        try
        {
            FindMasterMaintenanceCarUserSozaiCmd cmd = new FindMasterMaintenanceCarUserSozaiCmd();
            cmd.setFindCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindResult();
        }
        catch (HAMException e)
        {
            FindMasterMaintenanceCarUserSozaiDispResult result = new FindMasterMaintenanceCarUserSozaiDispResult();
            result.toErrorInfo(e);
            return result;
        }
        catch (Throwable e)
        {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2016/02/17 HDX対応 HLC K.Oki ADD End */

}
