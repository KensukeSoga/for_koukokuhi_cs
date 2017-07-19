package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataCondition;
import jp.co.isid.ham.common.model.Tbj21SeisakuhiCondition;
import jp.co.isid.ham.common.model.Tbj21SeisakuhiDAO;
import jp.co.isid.ham.common.model.Tbj21SeisakuhiDAOFactory;
import jp.co.isid.ham.common.model.Tbj21SeisakuhiVO;
import jp.co.isid.ham.common.model.Tbj22SeisakuhiSsCondition;
import jp.co.isid.ham.common.model.Tbj22SeisakuhiSsDAO;
import jp.co.isid.ham.common.model.Tbj22SeisakuhiSsDAOFactory;
import jp.co.isid.ham.common.model.Tbj22SeisakuhiSsVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 制作費設定データを管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class CostManagementSettingManager {

    /** シングルトンインスタンス */
    private static CostManagementSettingManager _manager = new CostManagementSettingManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private CostManagementSettingManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static CostManagementSettingManager getInstance() {
        return _manager;
    }

    /**
     * 制作費設定画面の表示データを取得します
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindCostManagementSettingResult findCostManagementSetting(FindCostManagementSettingCondition cond) throws HAMException {

        FindCostManagementSettingResult result = new FindCostManagementSettingResult();

        // 請求グループマスタ取得
        Mbj26BillGroupDAO billGroupDao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        result.setBillGroup(billGroupDao.selectVO(new Mbj26BillGroupCondition()));

        // 制作費取込データ取得
        FindCostManagementCaptureCondition findCMCaptureCond = new FindCostManagementCaptureCondition();
        findCMCaptureCond.setPhase(cond.getPhase());
        findCMCaptureCond.setYearMonth(cond.getYearMonth());
        findCMCaptureCond.setClassDiv("0");
        FindCostManagementCaptureDAO findCMCaptureDao = FindCostManagementSettingDAOFactory.createFindCMCaptureDao();
        result.setFindCMCapture(findCMCaptureDao.selectVO(findCMCaptureCond));

        // 制作費車種データ取得
        FindCostManagementCarCondition findCMCarCond = new FindCostManagementCarCondition();
        findCMCarCond.setPhase(cond.getPhase());
        findCMCarCond.setYearMonth(cond.getYearMonth());
        FindCostManagementCarDAO findCMCarDao = FindCostManagementSettingDAOFactory.createFindCMCarDao();
        result.setFindCMCar(findCMCarDao.selectVO(findCMCarCond));

        // 制作費車種出力設定データ取得
        FindCostManagementCaroutctrlCondition findCMCaroutctrlCond = new FindCostManagementCaroutctrlCondition();
        findCMCaroutctrlCond.setReportCd(cond.getReportCd());
        findCMCaroutctrlCond.setPhase(cond.getPhase());
        findCMCaroutctrlCond.setYearMonth(cond.getYearMonth());
        FindCostManagementCaroutctrlDAO findCMCaroutctrlDao = FindCostManagementSettingDAOFactory.createFindCMCaroutctrlDao();
        result.setFindCMCaroutctrl(findCMCaroutctrlDao.selectVO(findCMCaroutctrlCond));

        // 制作費(出力オプション以外)データ取得
        FindCostManagementExceptOptCondition findCMExceptOptCond = new FindCostManagementExceptOptCondition();
        findCMExceptOptCond.setReportCd(cond.getReportCd());
        findCMExceptOptCond.setPhase(cond.getPhase());
        findCMExceptOptCond.setYearMonth(cond.getYearMonth());
        FindCostManagementExceptOptDAO findCMExceptOptDao = FindCostManagementSettingDAOFactory.createFindCMExceptOptDao();
        result.setFindCMExceptOpt(findCMExceptOptDao.selectVO(findCMExceptOptCond));

        // 変更確認データ取得
        FindAfterUptakeCheckCondition findAUCheckCond = new FindAfterUptakeCheckCondition();
        findAUCheckCond.setPhase(cond.getPhase());
        findAUCheckCond.setYearMonth(cond.getYearMonth());
        findAUCheckCond.setClassDiv("0");
        FindAfterUptakeCheckDAO findAUCheckDao = FindCostManagementSettingDAOFactory.createFindAfterUptakeCheckDao();
        result.setFindAUCheck(findAUCheckDao.findFindAfterUptakeCheck(findAUCheckCond));

        // 機能制御Infoの取得
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // セキュリティInfoの取得
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        seccond.setHamid(cond.getHamId());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        result.setSecurityInfoVoList(secmanager.getSecurityInfo(seccond).getSecurityInfo());

        return result;
    }

    /**
     * 制作費設定画面の表示データを登録します
     * @param vo 登録データ
     * @return 登録結果
     * @throws HAMException
     */
    public RegisterCostManagementSettingResult registerCostManagementSetting(RegisterCostManagementSettingVO vo) throws HAMException {

        RegisterCostManagementSettingResult result = new RegisterCostManagementSettingResult();

        // 制作費車種データ取得
        FindCostManagementCarCondition findCMCarCond = new FindCostManagementCarCondition();
        findCMCarCond.setPhase(vo.getPhase());
        findCMCarCond.setYearMonth(vo.getYearMonth());
        FindCostManagementCarDAO findCMCarDao = FindCostManagementSettingDAOFactory.createFindCMCarDao();
        List<FindCostManagementCarVO> carVoList = findCMCarDao.selectVO(findCMCarCond);

        // 制作費更新チェック
        if (!checkUpdate(vo, carVoList)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        Tbj21SeisakuhiDAO seisakuhiDao = Tbj21SeisakuhiDAOFactory.createTbj21SeisakuhiDAO();
        Date dtYearMonth = null;
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM");
        try {
            dtYearMonth = sdf.parse(vo.getYearMonth());
        } catch (ParseException e) {
            new HAMException(e.getMessage(), "BJ-E0002");
        }

        if (vo.getLatestUpdDate() != null && vo.getLatestUpdId() != null) {
            // 制作費削除
            Tbj21SeisakuhiCondition seisakuhiCond = new Tbj21SeisakuhiCondition();
            seisakuhiCond.setPhase(BigDecimal.valueOf(vo.getPhase()));
            seisakuhiCond.setSeikyuym(dtYearMonth);
            seisakuhiDao.deleteSeisakuhi(seisakuhiCond);
        }

        // 制作費登録
        for (Tbj21SeisakuhiVO seisakuhiVo : vo.getSeisakuhiVo()) {
            seisakuhiDao.insertVo(seisakuhiVo);
        }

        // 制作費取込が行われた場合
        if (vo.getSeisakuhiSsVo() != null && vo.getSeisakuhiSsVo().size() > 0) {
            // 制作費取込削除
            Tbj22SeisakuhiSsDAO seisakuhiSsDao = Tbj22SeisakuhiSsDAOFactory.createTbj22SeisakuhiSsDAO();
            Tbj22SeisakuhiSsCondition seisakuhiSsCond = new Tbj22SeisakuhiSsCondition();
            seisakuhiSsCond.setPhase(BigDecimal.valueOf(vo.getPhase()));
            seisakuhiSsCond.setCrdate(dtYearMonth);
            seisakuhiSsDao.deleteSeisakuhiSs(seisakuhiSsCond);

            // 制作費取込登録
            for (Tbj22SeisakuhiSsVO seisakuhiSsVo : vo.getSeisakuhiSsVo()) {
                seisakuhiSsDao.insertVo(seisakuhiSsVo);
            }
        }

        return result;
    }

    /**
     * 制作費更新チェック
     * @param vo 登録データ
     * @param carVoList 制作費車種データ
     * @return true：チェックOK、false：チェックNG
     */
    private boolean checkUpdate(RegisterCostManagementSettingVO vo, List<FindCostManagementCarVO> carVoList) {

        // 件数チェック.
        if (carVoList.size() != vo.getDataCount()) {
            return false;
        }

        if (carVoList.size() > 0) {
            if (vo.getLatestUpdDate() != null && vo.getLatestUpdId() != null) {
                Date carVoUpdDate = null;
                String carVoUpdId = null;
                for (FindCostManagementCarVO carVo : carVoList) {
                    if (carVo.getUpdDate() == null || carVo.getUpdId() == null) {
                        continue;
                    }
                    if (carVoUpdDate == null) {
                        carVoUpdDate = carVo.getUpdDate();
                        carVoUpdId = carVo.getUpdId();
                    } else {
                        if (carVoUpdDate.compareTo(carVo.getUpdDate()) < 0) {
                            carVoUpdDate = carVo.getUpdDate();
                            carVoUpdId = carVo.getUpdId();
                        }
                    }
                }

                if (carVoUpdDate == null || carVoUpdId == null) {
                    return false;
                }

                // 最終更新日時チェック
                if (!vo.getLatestUpdDate().equals(carVoUpdDate)) {
                    return false;
                }

                // 最終更新者IDチェック
                if (!vo.getLatestUpdId().equals(carVoUpdId)) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * CR制作費管理(制作費設定用)を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindCrCreateDataForCmsResult findCrCreateDataForCms(FindCrCreateDataForCmsCondition cond) throws HAMException {

        FindCrCreateDataForCmsResult result = new FindCrCreateDataForCmsResult();

        // CR制作費管理(制作費設定用)データ取得
        Tbj11CrCreateDataCondition crCond = new Tbj11CrCreateDataCondition();
        crCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
        crCond.setCrdate(cond.getYearMonth());
        FindCrCreateDataForCmsDAO crDao = FindCrCreateDataForCmsDAOFactory.createFindCrCreateDataForCmsDAO();
        result.setCrCreateData(crDao.selectVO(crCond));

        return result;
    }

    /**
     * 制作請求表出力データ存在チェックをします
     * @param cond
     * @return
     * @throws HAMException
     */
    public void checkBillProductionOutput(CheckBillProductionOutputCondition cond) throws HAMException {

        // 制作請求表出力データ存在チェック（予定、請求の共通チェック）
        CheckBillProductionOutputDAO cbpoDao = CheckBillProductionOutputDAOFactory.createCheckBillProductionOutputDAO();
        cbpoDao.selectVO(cond);

        // 制作請求表出力データ存在チェック（請求のチェック）
        if (cond.getOutputFlg().equals("seikyu")) {
            CheckBillProductionOutputSeikyuDAO cbpoDao2 = CheckBillProductionOutputSeikyuDAOFactory.createCheckBillProductionOutputSeikyuDAO();
            cbpoDao2.selectVO(cond);
        }
    }

    /**
     * 制作請求表取得をします
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBillProductionOutputResult findBillProductionOutput(CheckBillProductionOutputCondition cond) throws HAMException {

        FindBillProductionOutputResult result = new FindBillProductionOutputResult();

        // 制作請求表取得DAO
        FindBillProductionOutputDAO dao = FindBillProductionOutputDAOFactory.createFindBillProductionOutputDAO();
        result.setFindBillProductionOutput(dao.selectVO(cond));

        return result;
    }
}
