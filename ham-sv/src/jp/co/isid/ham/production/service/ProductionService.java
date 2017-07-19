package jp.co.isid.ham.production.service;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.controller.ConfirmCrCreateDataCmd;
import jp.co.isid.ham.production.controller.ContractDeleteCmd;
import jp.co.isid.ham.production.controller.FindBudgetCmd;
import jp.co.isid.ham.production.controller.FindBudgetDetailsCmd;
import jp.co.isid.ham.production.controller.FindBudgetHistoryCmd;
import jp.co.isid.ham.production.controller.FindCarListCmd;
import jp.co.isid.ham.production.controller.FindChangeNoticeDataCmd;
import jp.co.isid.ham.production.controller.FindCheckListTantoCmd;
import jp.co.isid.ham.production.controller.FindContractListForReportCmd;
import jp.co.isid.ham.production.controller.FindContractSearchCmd;
import jp.co.isid.ham.production.controller.FindCrCreateDataCmd;
import jp.co.isid.ham.production.controller.FindJasracCmd;
import jp.co.isid.ham.production.controller.FindLogContractInfoCmd;
import jp.co.isid.ham.production.controller.FindLogCrCreateDataCmd;
import jp.co.isid.ham.production.controller.FindLogMaterialListCmd;
import jp.co.isid.ham.production.controller.FindLogMaterialRegisterCmd;
import jp.co.isid.ham.production.controller.FindMailInfoCmd;
import jp.co.isid.ham.production.controller.FindMaterialEncodeListCmd;
import jp.co.isid.ham.production.controller.FindMaterialListCmd;
import jp.co.isid.ham.production.controller.FindMaterialRegisterListCmd;
import jp.co.isid.ham.production.controller.FindPayDataCmd;
import jp.co.isid.ham.production.controller.FindSeikyuDataCmd;
import jp.co.isid.ham.production.controller.FindTVCMMaterialListCmd;
import jp.co.isid.ham.production.controller.GetContractInfoCmd;
import jp.co.isid.ham.production.controller.GetIniDataForCheckListCmd;
import jp.co.isid.ham.production.controller.GetIniDataForCostManageCmd;
import jp.co.isid.ham.production.controller.GetIniDataForMaterialSearchCmd;
import jp.co.isid.ham.production.controller.GetInitCmCodeIssueDocsCmd;
import jp.co.isid.ham.production.controller.GetInitContractRegisterCmd;
import jp.co.isid.ham.production.controller.GetInitMaterialListCmd;
import jp.co.isid.ham.production.controller.GetInitMaterialRegisterCmd;
import jp.co.isid.ham.production.controller.GetRepDataForChkListCmd;
import jp.co.isid.ham.production.controller.GetRepDataForCostMngCmd;
import jp.co.isid.ham.production.controller.MoveCrCreateDataCmd;
import jp.co.isid.ham.production.controller.RegisterBudgetCmd;
import jp.co.isid.ham.production.controller.RegisterContentMaterialCmd;
import jp.co.isid.ham.production.controller.RegisterCrCreateDataCmd;
import jp.co.isid.ham.production.controller.RegisterMaterialListCmd;
import jp.co.isid.ham.production.controller.RegisterRealMaterialFromTempMaterialCmd;
import jp.co.isid.ham.production.controller.RegisterThsCmd;
import jp.co.isid.ham.production.controller.RegistJasracCmd;
import jp.co.isid.ham.production.controller.UpdateContractInfoCmd;
import jp.co.isid.ham.production.model.ConfirmCrCreateDataResult;
import jp.co.isid.ham.production.model.ConfirmCrCreateDataVO;
import jp.co.isid.ham.production.model.Contract4ReportCondition;
import jp.co.isid.ham.production.model.Contract4ReportResult;
import jp.co.isid.ham.production.model.ContractDeleteCondition;
import jp.co.isid.ham.production.model.ContractDeleteResult;
import jp.co.isid.ham.production.model.ContractRegisterCondition;
import jp.co.isid.ham.production.model.ContractRegisterResult;
import jp.co.isid.ham.production.model.ContractSearchCondition;
import jp.co.isid.ham.production.model.ContractSearchResult;
import jp.co.isid.ham.production.model.FindBudgetCondition;
import jp.co.isid.ham.production.model.FindBudgetDetailsCondition;
import jp.co.isid.ham.production.model.FindBudgetDetailsResult;
import jp.co.isid.ham.production.model.FindBudgetHistoryCondition;
import jp.co.isid.ham.production.model.FindBudgetHistoryResult;
import jp.co.isid.ham.production.model.FindBudgetResult;
import jp.co.isid.ham.production.model.FindCarListCondition;
import jp.co.isid.ham.production.model.FindCarListResult;
import jp.co.isid.ham.production.model.FindChangeNoticeCondition;
import jp.co.isid.ham.production.model.FindChangeNoticeResult;
import jp.co.isid.ham.production.model.FindCheckListTantoCondition;
import jp.co.isid.ham.production.model.FindCheckListTantoResult;
import jp.co.isid.ham.production.model.FindCrCreateDataCondition;
import jp.co.isid.ham.production.model.FindCrCreateDataResult;
import jp.co.isid.ham.production.model.FindJasracCondition;
import jp.co.isid.ham.production.model.FindJasracResult;
import jp.co.isid.ham.production.model.FindLogContractInfoCondition;
import jp.co.isid.ham.production.model.FindLogContractInfoResult;
import jp.co.isid.ham.production.model.FindLogCrCreateDataCondition;
import jp.co.isid.ham.production.model.FindLogCrCreateDataResult;
import jp.co.isid.ham.production.model.FindMailInfoCondition;
import jp.co.isid.ham.production.model.FindMailInfoResult;
import jp.co.isid.ham.production.model.FindPayDataCondition;
import jp.co.isid.ham.production.model.FindPayDataResult;
import jp.co.isid.ham.production.model.FindSeikyuDataCondition;
import jp.co.isid.ham.production.model.FindSeikyuDataResult;
import jp.co.isid.ham.production.model.FindTVCMMaterialListCondition;
import jp.co.isid.ham.production.model.FindTVCMMaterialListResult;
import jp.co.isid.ham.production.model.GetContractInfoListCondition;
import jp.co.isid.ham.production.model.GetContractInfoListResult;
import jp.co.isid.ham.production.model.GetIniDataForCheckListCondition;
import jp.co.isid.ham.production.model.GetIniDataForCheckListResult;
import jp.co.isid.ham.production.model.GetIniDataForCostManageCondition;
import jp.co.isid.ham.production.model.GetIniDataForCostManageResult;
import jp.co.isid.ham.production.model.GetRepDataForChkListCondition;
import jp.co.isid.ham.production.model.GetRepDataForChkListResult;
import jp.co.isid.ham.production.model.GetRepDataForCostMngCondition;
import jp.co.isid.ham.production.model.GetRepDataForCostMngResult;
import jp.co.isid.ham.production.model.MaterialEncodeListCondition;
import jp.co.isid.ham.production.model.MaterialListCondition;
import jp.co.isid.ham.production.model.MaterialListResult;
import jp.co.isid.ham.production.model.MaterialRegisterCondition;
import jp.co.isid.ham.production.model.MaterialRegisterResult;
import jp.co.isid.ham.production.model.MaterialSearchCondition;
import jp.co.isid.ham.production.model.MaterialSearchResult;
import jp.co.isid.ham.production.model.MoveCrCreateDataResult;
import jp.co.isid.ham.production.model.MoveCrCreateDataVO;
import jp.co.isid.ham.production.model.RegisterBudgetResult;
import jp.co.isid.ham.production.model.RegisterBudgetVO;
import jp.co.isid.ham.production.model.RegisterCrCreateDataResult;
import jp.co.isid.ham.production.model.RegisterCrCreateDataVO;
import jp.co.isid.ham.production.model.RegisterMaterialListVO;
import jp.co.isid.ham.production.model.RegisterMaterialVO;
import jp.co.isid.ham.production.model.RegisterRealMaterialFromTempMaterialResult;
import jp.co.isid.ham.production.model.RegisterRealMaterialFromTempMaterialVO;
import jp.co.isid.ham.production.model.RegisterThsResult;
import jp.co.isid.ham.production.model.RegisterThsVO;
import jp.co.isid.ham.production.model.UpdateContractInfoResult;
import jp.co.isid.ham.production.model.UpdateContractInfoVO;
import jp.co.isid.ham.production.model.RegistJasracVO;
import jp.co.isid.ham.production.model.RegistJasracResult;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.ham.util.HAMLogUtility;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;
/**
 *
 * <P>
 * 制作サービス
 * </P>
 * <P>
 * 制作サービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/10/04 JSE H.Abe)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "productionService", targetNamespace = "http://production.service.ham.isid.co.jp/")
public class ProductionService {

    /**
     * 契約情報登録画面の起動時データを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ContractRegisterResult")
    public ContractRegisterResult getContractRegisterList(
            @WebParam(name = "condition")
            ContractRegisterCondition condition) throws ServiceException {
        try {
            GetInitContractRegisterCmd cmd = new GetInitContractRegisterCmd();
            cmd.setContractRegisterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getContractRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            ContractRegisterResult result = new ContractRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * CR制作費の起動時データを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "getIniDataForCostManageResult")
    public GetIniDataForCostManageResult getIniDataForCostManage(
            @WebParam(name = "condtion") GetIniDataForCostManageCondition condition) throws ServiceException {

        try {
            GetIniDataForCostManageCmd cmd = new GetIniDataForCostManageCmd();
            cmd.setGetIniDataForCostManageCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getGetIniDataForCostManageResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            GetIniDataForCostManageResult result = new GetIniDataForCostManageResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * CR制作費の検索時のデータを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findCrCreateDataResult")
    public FindCrCreateDataResult findCrCreateData(
            @WebParam(name = "condtion") FindCrCreateDataCondition condition) throws ServiceException {

        try {
            FindCrCreateDataCmd cmd = new FindCrCreateDataCmd();
            cmd.setFindCrCreateDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindCrCreateDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCrCreateDataResult result = new FindCrCreateDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * CR制作費の登録時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "registerCrCreateDataResult")
    public RegisterCrCreateDataResult registerCrCreateData(
            @WebParam(name = "vo") RegisterCrCreateDataVO vo) throws ServiceException {

        try {
            RegisterCrCreateDataCmd cmd = new RegisterCrCreateDataCmd();
            cmd.setRegisterCrCreateDataVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterCrCreateDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterCrCreateDataResult result = new RegisterCrCreateDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * CR制作費の確認／確認取消時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "confirmCrCreateDataResult")
    public ConfirmCrCreateDataResult confirmCrCreateData(
            @WebParam(name = "vo") ConfirmCrCreateDataVO vo) throws ServiceException {

        try {
            ConfirmCrCreateDataCmd cmd = new ConfirmCrCreateDataCmd();
            cmd.setConfirmCrCreateDataVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getConfirmCrCreateDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            ConfirmCrCreateDataResult result = new ConfirmCrCreateDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 素材登録画面の一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialRegisterResult getInitMaterialRegister(
            @WebParam(name = "condtion") MaterialRegisterCondition condition) throws ServiceException {

        try {
            GetInitMaterialRegisterCmd cmd = new GetInitMaterialRegisterCmd();
            cmd.setMaterialRegisterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialRegisterResult result = new MaterialRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材登録ログ一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialRegisterResult findLogMaterialRegister(
            @WebParam(name = "condtion") MaterialRegisterCondition condition) throws ServiceException {

        try {
            FindLogMaterialRegisterCmd cmd = new FindLogMaterialRegisterCmd();
            cmd.setMaterialRegisterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialRegisterResult result = new MaterialRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * CMコード発行書出力画面のデータを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialRegisterResult getInitCmCodeIssueDocs(
            @WebParam(name = "condtion") MaterialRegisterCondition condition) throws ServiceException {

        try {
            GetInitCmCodeIssueDocsCmd cmd = new GetInitCmCodeIssueDocsCmd();
            cmd.setMaterialRegisterCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialRegisterResult result = new MaterialRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材エンコード表のデータを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialRegisterResult findMaterialEncodeList(
            @WebParam(name = "condtion") MaterialEncodeListCondition condition) throws ServiceException {

        try {
            FindMaterialEncodeListCmd cmd = new FindMaterialEncodeListCmd();
            cmd.setMaterialEncodeCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialRegisterResult result = new MaterialRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材登録その他情報を登録します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialRegisterResult registContentMaterial(
            @WebParam(name = "vo") RegisterMaterialVO vo) throws ServiceException {

        try {
            RegisterContentMaterialCmd cmd = new RegisterContentMaterialCmd();
            cmd.setRegisterContentMaterialVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialRegisterResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialRegisterResult result = new MaterialRegisterResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 契約検索画面の一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ContractSearchResult")
    public ContractSearchResult findContractSearchList(
            @WebParam(name = "condtion") ContractSearchCondition condition) throws ServiceException {

        try {
            FindContractSearchCmd cmd = new FindContractSearchCmd();
            cmd.setContractSearchCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getContractSearchResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            ContractSearchResult result = new ContractSearchResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材一覧画面の一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialListResult")
    public MaterialListResult getInitMaterialList(
            @WebParam(name = "condtion") MaterialListCondition condition) throws ServiceException {

        try {
            GetInitMaterialListCmd cmd = new GetInitMaterialListCmd();
            cmd.setMaterialListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialListResult result = new MaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材一覧画面のうち、素材一覧データと素材登録データを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialListResult")
    public MaterialListResult findMaterialRegisterList(
            @WebParam(name = "condtion") MaterialListCondition condition) throws ServiceException {

        try {
            FindMaterialRegisterListCmd cmd = new FindMaterialRegisterListCmd();
            cmd.setMaterialListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialListResult result = new MaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材一覧画面のうち、素材一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialListResult")
    public MaterialListResult findMaterialList(
            @WebParam(name = "condtion") MaterialListCondition condition) throws ServiceException {

        try {
            FindMaterialListCmd cmd = new FindMaterialListCmd();
            cmd.setMaterialListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialListResult result = new MaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材一覧ログ一覧を取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialListResult")
    public MaterialListResult findLogMaterialList(
            @WebParam(name = "condtion") MaterialListCondition condition) throws ServiceException {

        try {
            FindLogMaterialListCmd cmd = new FindLogMaterialListCmd();
            cmd.setMaterialListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialListResult result = new MaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 素材一覧情報を登録します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "MaterialRegisterResult")
    public MaterialListResult registMaterialList(
            @WebParam(name = "vo") RegisterMaterialListVO vo) throws ServiceException {

        try {
            RegisterMaterialListCmd cmd = new RegisterMaterialListCmd();
            cmd.setRegisterMaterialListVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialListResult result = new MaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 本素材登録を行います
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegisterRealMaterialFromTempMaterialResult")
    public RegisterRealMaterialFromTempMaterialResult registRealMaterialFromTempMaterial(@WebParam(name = "vo") RegisterRealMaterialFromTempMaterialVO vo) throws ServiceException {

        try {
            RegisterRealMaterialFromTempMaterialCmd cmd = new RegisterRealMaterialFromTempMaterialCmd();
            cmd.setRegisterRealMaterialFromTempMaterialVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterRealMaterialFromTempMaterialResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterRealMaterialFromTempMaterialResult result = new RegisterRealMaterialFromTempMaterialResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 契約情報登録画面の削除ボタン押下時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ContractDeleteResult")
    public ContractDeleteResult getContractDeleteList(
            @WebParam(name = "condition")
            ContractDeleteCondition condition) throws ServiceException {
        try {
            ContractDeleteCmd cmd = new ContractDeleteCmd();
            cmd.setContractDeleteCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getContractDeleteResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            ContractDeleteResult result = new ContractDeleteResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 契約情報登録画面の登録ボタン押下時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "UpdateContractInfoResult")
    public UpdateContractInfoResult getContractUpdateList(
            @WebParam(name = "condition")
            UpdateContractInfoVO condition) throws ServiceException {
        try {
            UpdateContractInfoCmd cmd = new UpdateContractInfoCmd();
            cmd.setUpdateContractInfoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getUpdateContractInfoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            UpdateContractInfoResult result = new UpdateContractInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /**
     * 契約情報テーブルを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "ContractRegisterResult")
    public GetContractInfoListResult getContractInfoList(
            @WebParam(name = "condition")
            GetContractInfoListCondition condition) throws ServiceException {
        try {
            GetContractInfoCmd cmd = new GetContractInfoCmd();
            cmd.setContractInfoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getContractInfoListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            GetContractInfoListResult result = new GetContractInfoListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * CR制作費―データ移動／コピーの登録時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "moveCrCreateDataResult")
    public MoveCrCreateDataResult moveCrCreateData(
            @WebParam(name = "vo") MoveCrCreateDataVO vo) throws ServiceException {

        try {
            MoveCrCreateDataCmd cmd = new MoveCrCreateDataCmd();
            cmd.setMoveCrCreateDataCondition(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMoveCrCreateDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MoveCrCreateDataResult result = new MoveCrCreateDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 契約情報登録画面のセル編集時、Jasracテーブルのカウントを行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "JasracCountResult")
    public ContractDeleteResult getJasracCount(
            @WebParam(name = "condition")
            ContractDeleteCondition condition) throws ServiceException {
        try {
            ContractDeleteCmd cmd = new ContractDeleteCmd();
            cmd.setContractDeleteCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getContractDeleteResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            ContractDeleteResult result = new ContractDeleteResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 車種別予算表―表示データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findBudgetResult")
    public FindBudgetResult findBudget(
            @WebParam(name = "condition") FindBudgetCondition condition) throws ServiceException {

        try {
            FindBudgetCmd cmd = new FindBudgetCmd();
            cmd.setFindBudgetCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindBudgetResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindBudgetResult result = new FindBudgetResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 車種別予算表(詳細)―表示データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findBudgetDetailsResult")
    public FindBudgetDetailsResult findBudgetDetails(
            @WebParam(name = "condition") FindBudgetDetailsCondition condition) throws ServiceException {

        try {
            FindBudgetDetailsCmd cmd = new FindBudgetDetailsCmd();
            cmd.setFindBudgetDetailsCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindBudgetDetailsResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindBudgetDetailsResult result = new FindBudgetDetailsResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 車種別予算(詳細)の登録時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "registerBudgetResult")
    public RegisterBudgetResult registerBudget(
            @WebParam(name = "vo") RegisterBudgetVO vo) throws ServiceException {

        try {
            RegisterBudgetCmd cmd = new RegisterBudgetCmd();
            cmd.setRegisterBudgetVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterBudgetResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterBudgetResult result = new RegisterBudgetResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 車種別予算表―表示データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findBudgetHistoryResult")
    public FindBudgetHistoryResult findBudgetHistory(
            @WebParam(name = "condition") FindBudgetHistoryCondition condition) throws ServiceException {

        try {
            FindBudgetHistoryCmd cmd = new FindBudgetHistoryCmd();
            cmd.setFindBudgetHistoryCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindBudgetHistoryResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindBudgetHistoryResult result = new FindBudgetHistoryResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 更新履歴(契約情報登録)―表示データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findLogContractInfoResult")
    public FindLogContractInfoResult findLogContractInfo(
            @WebParam(name = "condition") FindLogContractInfoCondition condition) throws ServiceException {

        try {
            FindLogContractInfoCmd cmd = new FindLogContractInfoCmd();
            cmd.setFindLogContractInfoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindLogContractInfoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindLogContractInfoResult result = new FindLogContractInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 更新履歴(CR制作費)―表示データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findLogCrCreateDataResult")
    public FindLogCrCreateDataResult findLogCrCreateData(
            @WebParam(name = "condition") FindLogCrCreateDataCondition condition) throws ServiceException {

        try {
            FindLogCrCreateDataCmd cmd = new FindLogCrCreateDataCmd();
            cmd.setFindLogCrCreateDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindLogCrCreateDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindLogCrCreateDataResult result = new FindLogCrCreateDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 制作原価表／制作費表　出力データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "getRepDataForCostMngResult")
    public GetRepDataForCostMngResult getRepDataForCostMng(
            @WebParam(name = "condition") GetRepDataForCostMngCondition condition) throws ServiceException {

        try {
            GetRepDataForCostMngCmd cmd = new GetRepDataForCostMngCmd();
            cmd.setGetRepDataForCostMngCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getGetRepDataForCostMngResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            GetRepDataForCostMngResult result = new GetRepDataForCostMngResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * チェックリスト出力画面　初期データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "getIniDataForCheckListResult")
    public GetIniDataForCheckListResult getIniDataForCheckList(
            @WebParam(name = "condition") GetIniDataForCheckListCondition condition) throws ServiceException {

        try {
            GetIniDataForCheckListCmd cmd = new GetIniDataForCheckListCmd();
            cmd.setGetIniDataForCheckListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getGetIniDataForCheckListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            GetIniDataForCheckListResult result = new GetIniDataForCheckListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * チェックリスト出力画面　初期データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findCheckListTantoResult")
    public FindCheckListTantoResult findCheckListTanto(
            @WebParam(name = "condition") FindCheckListTantoCondition condition) throws ServiceException {

        try {
            FindCheckListTantoCmd cmd = new FindCheckListTantoCmd();
            cmd.setFindCheckListTantoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindCheckListTantoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCheckListTantoResult result = new FindCheckListTantoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * チェックリスト　出力データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "getRepDataForChkListResult")
    public GetRepDataForChkListResult getRepDataForChkList(
            @WebParam(name = "condition") GetRepDataForChkListCondition condition) throws ServiceException {

        try {
            GetRepDataForChkListCmd cmd = new GetRepDataForChkListCmd();
            cmd.setGetRepDataForChkListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getGetRepDataForChkListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            GetRepDataForChkListResult result = new GetRepDataForChkListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * JASRAC登録画面のデータを取得します
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "FindJasracResult")
    public FindJasracResult getJasrac(@WebParam(name = "condition") FindJasracCondition condition) throws ServiceException
    {
        try
        {
            FindJasracCmd cmd = new FindJasracCmd();
            cmd.setFindContractCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindContractResult();
        }
        catch (HAMException e)
        {
            HAMLogUtility.outLog(e);
            FindJasracResult result = new FindJasracResult();
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
     * JASRAC管理表の登録時の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "RegistJasracResult")
    public RegistJasracResult registJasrac(@WebParam(name = "vo") RegistJasracVO vo) throws ServiceException
    {
        try
        {
            RegistJasracCmd cmd = new RegistJasracCmd();
            cmd.setRegistVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegistResult();
        }
        catch (HAMException e)
        {
            HAMLogUtility.outLog(e);
            RegistJasracResult result = new RegistJasracResult();
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
     * タレント・ナレーター・楽曲契約表(帳票用)取得の処理を行います
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException サービス例外
     */
    @WebMethod
    @WebResult(name = "findContractForReportResult")
    public Contract4ReportResult findContractForReport(
            @WebParam(name = "condition") Contract4ReportCondition condition) throws ServiceException {

        try {
            FindContractListForReportCmd cmd = new FindContractListForReportCmd();
            cmd.setCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getReportResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            Contract4ReportResult result = new Contract4ReportResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 車種一覧を検索します
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException サービス例外
     */
    @WebMethod
    @WebResult(name = "findCarListForContractReport")
    public FindCarListResult findCarListForContractReport(
            @WebParam(name = "condition") FindCarListCondition condition) throws ServiceException {

        try {
            FindCarListCmd cmd = new FindCarListCmd();
            cmd.setCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getCarResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindCarListResult result = new FindCarListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }



    /**
     * 支払先一覧を検索します
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException サービス例外
     */
    @WebMethod
    @WebResult(name = "findPayDataResult")
    public FindPayDataResult findPayData(
            @WebParam(name = "condition") FindPayDataCondition condition) throws ServiceException {

        try {
            FindPayDataCmd cmd = new FindPayDataCmd();
            cmd.setFindPayDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindPayDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindPayDataResult result = new FindPayDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 請求先一覧を検索します
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException サービス例外
     */
    @WebMethod
    @WebResult(name = "findSeikyuDataResult")
    public FindSeikyuDataResult findSeikyuData(
            @WebParam(name = "condition") FindSeikyuDataCondition condition) throws ServiceException {

        try {
            FindSeikyuDataCmd cmd = new FindSeikyuDataCmd();
            cmd.setFindSeikyuDataCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindSeikyuDataResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindSeikyuDataResult result = new FindSeikyuDataResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /**
     * 変更通知(CR制作費)データ取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findChangeNoticeResult")
    public FindChangeNoticeResult findChangeNotice(
            @WebParam(name = "condition") FindChangeNoticeCondition condition) throws ServiceException {

        try {
            FindChangeNoticeDataCmd cmd = new FindChangeNoticeDataCmd();
            cmd.setFindChangeNoticeCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindChangeNoticeResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindChangeNoticeResult result = new FindChangeNoticeResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * メールアドレス取得の処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findMailInfoResult")
    public FindMailInfoResult findMailInfo(
            @WebParam(name = "condition") FindMailInfoCondition condition) throws ServiceException {

        try {
            FindMailInfoCmd cmd = new FindMailInfoCmd();
            cmd.setFindMailInfoCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindMailInfoResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindMailInfoResult result = new FindMailInfoResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * HAM取引マスタの登録処理を行います
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "registerThsResult")
    public RegisterThsResult registerThs(
            @WebParam(name = "vo") RegisterThsVO vo) throws ServiceException {

        try {
            RegisterThsCmd cmd = new RegisterThsCmd();
            cmd.setRegisterThsVO(vo);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getRegisterThsResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            RegisterThsResult result = new RegisterThsResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }

    }

    /**
     * 素材検索画面の起動時データを取得します
     *
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "materialSearchResult")
    public MaterialSearchResult getIniDataForMaterialSearch(
            @WebParam(name = "condition")
            MaterialSearchCondition condition) throws ServiceException {
        try {
            GetIniDataForMaterialSearchCmd cmd = new GetIniDataForMaterialSearchCmd();
            cmd.setMaterialSearchCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMaterialSearchResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            MaterialSearchResult result = new MaterialSearchResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }

    /* 2016/03/10 HDX対応 HLC K.Oki ADD Start */
    /**
     * TVCM素材一覧出力情報を検索する
     * @param condition 検索条件
     * @return 検索結果
     * @throws ServiceException
     */
    @WebMethod
    @WebResult(name = "findTVCMMaterialListResult")
    public FindTVCMMaterialListResult findTVCMMaterialList(
            @WebParam(name = "condition")
            FindTVCMMaterialListCondition condition) throws ServiceException {
        try {
            FindTVCMMaterialListCmd cmd = new FindTVCMMaterialListCmd();
            cmd.setFindTVCMMaterialListCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getFindTVCMMaterialListResult();
        } catch (HAMException e) {
            HAMLogUtility.outLog(e);
            FindTVCMMaterialListResult result = new FindTVCMMaterialListResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
    /* 2016/03/10 HDX対応 HLC K.Oki ADD End */
}
