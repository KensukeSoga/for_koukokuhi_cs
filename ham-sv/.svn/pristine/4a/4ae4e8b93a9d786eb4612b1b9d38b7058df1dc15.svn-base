package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj01SysStsDAO;
import jp.co.isid.ham.common.model.Mbj01SysStsDAOFactory;
import jp.co.isid.ham.common.model.Mbj01SysStsVO;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj02UserDAO;
import jp.co.isid.ham.common.model.Mbj02UserDAOFactory;
import jp.co.isid.ham.common.model.Mbj02UserVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj15CrClassDAO;
import jp.co.isid.ham.common.model.Mbj15CrClassDAOFactory;
import jp.co.isid.ham.common.model.Mbj15CrClassVO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceDAO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceDAOFactory;
import jp.co.isid.ham.common.model.Mbj16CrExpenceVO;
import jp.co.isid.ham.common.model.Mbj17CrDivisionDAO;
import jp.co.isid.ham.common.model.Mbj17CrDivisionDAOFactory;
import jp.co.isid.ham.common.model.Mbj17CrDivisionVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj29SetteiKykCondition;
import jp.co.isid.ham.common.model.Mbj29SetteiKykDAO;
import jp.co.isid.ham.common.model.Mbj29SetteiKykDAOFactory;
import jp.co.isid.ham.common.model.Mbj29SetteiKykVO;
import jp.co.isid.ham.common.model.Mbj30InputTntCondition;
import jp.co.isid.ham.common.model.Mbj30InputTntDAO;
import jp.co.isid.ham.common.model.Mbj30InputTntDAOFactory;
import jp.co.isid.ham.common.model.Mbj30InputTntVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlCondition;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlDAO;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlWithUserVO;
import jp.co.isid.ham.common.model.Mbj45CrExpConvertDAO;
import jp.co.isid.ham.common.model.Mbj45CrExpConvertDAOFactory;
import jp.co.isid.ham.common.model.Mbj45CrExpConvertVO;
import jp.co.isid.ham.common.model.Mbj46ThsDAO;
import jp.co.isid.ham.common.model.Mbj46ThsDAOFactory;
import jp.co.isid.ham.common.model.Mbj46ThsVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj10CrCarInfoCondition;
import jp.co.isid.ham.common.model.Tbj10CrCarInfoDAO;
import jp.co.isid.ham.common.model.Tbj10CrCarInfoDAOFactory;
import jp.co.isid.ham.common.model.Tbj10CrCarInfoVO;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataCondition;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataDAO;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataDAOFactory;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.common.model.Tbj27LogCrCreateDataVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanDAO;
import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanVO;
import jp.co.isid.ham.common.model.Tbj32CompurposeDAO;
import jp.co.isid.ham.common.model.Tbj32CompurposeDAOFactory;
import jp.co.isid.ham.common.model.Tbj32CompurposeVO;
import jp.co.isid.ham.common.model.Tbj33CrBudgetUpdHisDAO;
import jp.co.isid.ham.common.model.Tbj33CrBudgetUpdHisDAOFactory;
import jp.co.isid.ham.common.model.Tbj33CrBudgetUpdHisVO;
import jp.co.isid.ham.common.model.UserVO;
import jp.co.isid.ham.common.model.Vbj01AccUserCondition;
import jp.co.isid.ham.common.model.Vbj01AccUserDAO;
import jp.co.isid.ham.common.model.Vbj01AccUserDAOFactory;
import jp.co.isid.ham.common.model.Vbj01AccUserVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
/**
 * <P>
 * 制作―制作費管理のManager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
public class CostManager {

    /** シングルトンインスタンス */
    private static CostManager _manager = new CostManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private CostManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static CostManager getInstance() {
        return _manager;
    }

    /**
     * CR制作費の初期起動時データの取得を行う
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    public GetIniDataForCostManageResult getIniDataForCostManage(GetIniDataForCostManageCondition cond) throws HAMException {
        GetIniDataForCostManageResult result = new GetIniDataForCostManageResult();

        //**********************************
        //システム使用状況マスタ
        //**********************************
        Mbj01SysStsDAO sysStsDao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();
        Mbj01SysStsVO sysStsCond = new Mbj01SysStsVO();
        sysStsCond.setLOCKTYPE("1");
        sysStsCond.setLOCKDATESTS("1");
        Mbj01SysStsVO sysStsVo = sysStsDao.loadVO(sysStsCond);
        result.setMbj01SysStsVo(sysStsVo);

        //**********************************
        //担当者マスタ取得
        //**********************************
        Mbj02UserDAO userDao = Mbj02UserDAOFactory.createMbj02UserDAO();
        Mbj02UserCondition userCond = new Mbj02UserCondition();
        List<Mbj02UserVO> userVoList = userDao.selectVO(userCond);
        //result.setMbj02UserVoList(userVoList);

        List<UserVO> userVoList2 = new ArrayList<UserVO>();

        Vbj01AccUserDAO accUserDao = Vbj01AccUserDAOFactory.createVbj01AccUserDAO();
        List<Vbj01AccUserCondition> accUserConds = new ArrayList<Vbj01AccUserCondition>();
        for (int i = 0; i < userVoList.size(); i++) {
            Mbj02UserVO mbj02UserVo = userVoList.get(i);

            Vbj01AccUserCondition c = new Vbj01AccUserCondition();
            c.setEsqid(mbj02UserVo.getHAMID());
            c.setPoststate("0");//主務のデータのみ対象
            accUserConds.add(c);
        }
        List<Vbj01AccUserVO> accUserVoList = accUserDao.selectForEachKK(accUserConds);

        for (int i = 0; i < userVoList.size(); i++) {
            Mbj02UserVO mbj02UserVo = userVoList.get(i);
            List<Vbj01AccUserVO> removeDataList = new ArrayList<Vbj01AccUserVO>();
            for (int j = 0; j < accUserVoList.size(); j++) {
                if (accUserVoList.get(j).getESQID().equals(mbj02UserVo.getHAMID())) {
                    //担当者マスタから取得した値を移送.
                    UserVO userVo = new UserVO();
                    userVo.setHAMID(mbj02UserVo.getHAMID());
                    userVo.setUPDAPL(mbj02UserVo.getUPDAPL());
                    userVo.setUPDDATE(mbj02UserVo.getUPDDATE());
                    userVo.setUPDID(mbj02UserVo.getUPDID());
                    userVo.setUPDNM(mbj02UserVo.getUPDNM());
                    userVo.setUSERNAME1(mbj02UserVo.getUSERNAME1());
                    userVo.setUSERNAME2(mbj02UserVo.getUSERNAME2());
                    userVo.setUSERTYPE(mbj02UserVo.getUSERTYPE());
                    Vbj01AccUserVO accUserVo = accUserVoList.get(j);
//                    userVo.setBUOU(accUserVo.getBUOU());
//                    userVo.setBUSIKOGNZUNTCD(accUserVo.getBUSIKOGNZUNTCD());
                    userVo.setCN(accUserVo.getCN());
//                    userVo.setHBOU(accUserVo.getHBOU());
//                    userVo.setHBSIKOGNZUNTCD(accUserVo.getHBSIKOGNZUNTCD());
//                    userVo.setHTOU(accUserVo.getHTOU());
//                    userVo.setHTSIKOGNZUNTCD(accUserVo.getHTSIKOGNZUNTCD());
//                    userVo.setKAOU(accUserVo.getKAOU());
//                    userVo.setKASIKOGNZUNTCD(accUserVo.getKASIKOGNZUNTCD());
                    userVo.setKKOU(accUserVo.getKKOU());
                    userVo.setKKSIKOGNZUNTCD(accUserVo.getKKSIKOGNZUNTCD());
                    userVo.setMAIL(accUserVo.getMAIL());
//                    userVo.setPOSTSTATE(accUserVo.getPOSTSTATE());
//                    userVo.setSIKOGNZUNTCD(accUserVo.getSIKOGNZUNTCD());

                    userVoList2.add(userVo);
                    //一度ヒットしたデータは不要なので削除対象とする(ちょっとだけレスポンス対策)
                    removeDataList.add(accUserVo);
                }
            }

            //削除対象となった個人情報Viewのデータを削除する(ちょっとだけレスポンス対策)
            accUserVoList.removeAll(removeDataList);
        }

        result.setUserVoList(userVoList2);

        //**********************************
        //区分マスタ取得
        //**********************************
        Mbj17CrDivisionDAO scrDivisionDao = Mbj17CrDivisionDAOFactory.createMbj17CrDivisionDAO();
        Mbj17CrDivisionVO crDivisionCond = new Mbj17CrDivisionVO();
        List<Mbj17CrDivisionVO> crDivisionVoList = scrDivisionDao.selectVO(crDivisionCond);
        result.setMbj17CrDivisionVoList(crDivisionVoList);

        //**********************************
        //請求グループマスタ取得
        //**********************************
        Mbj26BillGroupDAO billGroupDao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        //Mbj26BillGroupVO billGroupCond = new Mbj26BillGroupVO();
        Mbj26BillGroupCondition billGroupCond = new Mbj26BillGroupCondition();
        List<Mbj26BillGroupVO> billGroupVoList = billGroupDao.selectVO(billGroupCond);
        result.setMbj26BillGroupVoList(billGroupVoList);

        //車種並び替え対応 2013/12/12 HLC H.Watabe update start
        //**********************************
        //車種マスタ取得(権限付き)
        //**********************************
        //CarListDAO carDao = CarListDAOFactory.createCarListDAO();
        //CarListCondition carCond = new CarListCondition();
        //carCond.setSecType("1"); //1:CR車種権限
        //carCond.setHamid(cond.getUserid());
        //List<CarListVO> carVoList = carDao.findCarList(carCond);
        //result.setCarListVoList(carVoList);

        //**********************************
        //車種マスタ取得(権限付き)
        //**********************************
        FindCarSortedByNameDAO carDao =FindCarSortedByNameDAOFactory.createFindCarSortedByNameDAO();
        CarListCondition carCond = new CarListCondition();
        carCond.setSecType("1"); //1:CR車種権限
        carCond.setHamid(cond.getUserid());
        List<CarListVO> carVoList = carDao.findCarList(carCond);
        result.setCarListVoList(carVoList);
        //車種並び替え対応 2013/12/12 HLC H.Watabe update end

        //**********************************
        //CR予算分類マスタ取得
        //**********************************
        Mbj15CrClassDAO crClassDao = Mbj15CrClassDAOFactory.createMbj15CrClassDAO();
        Mbj15CrClassVO crClassCond = new Mbj15CrClassVO();
        List<Mbj15CrClassVO> crClassVoList = crClassDao.selectVO(crClassCond);
        result.setMbj15CrClassVoList(crClassVoList);

        //**********************************
        //CR予算費目マスタ取得
        //**********************************
        Mbj16CrExpenceDAO crExpenceDao = Mbj16CrExpenceDAOFactory.createMbj16CrExpenceDAO();
        Mbj16CrExpenceVO crExpenceCond = new Mbj16CrExpenceVO();
        List<Mbj16CrExpenceVO> crExpenceVoList = crExpenceDao.selectVO(crExpenceCond);
        result.setMbj16CrExpenceVoList(crExpenceVoList);

        //**********************************
        //設定局マスタ取得
        //**********************************
        Mbj29SetteiKykDAO setteiKykDao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();
        //Mbj29SetteiKykVO setteiKykCond = new Mbj29SetteiKykVO();
        Mbj29SetteiKykCondition setteiKykCond = new Mbj29SetteiKykCondition();
        List<Mbj29SetteiKykVO> setteiKykVoList = setteiKykDao.selectVO(setteiKykCond);
        result.setMbj29SetteiKykVoList(setteiKykVoList);

        //**********************************
        //入力担当マスタ取得
        //**********************************
        Mbj30InputTntDAO inputTntDao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        //Mbj30InputTntVO inputTntCond = new Mbj30InputTntVO();
        Mbj30InputTntCondition inputTntCond = new Mbj30InputTntCondition();
        List<Mbj30InputTntVO> inputTntVoList = inputTntDao.selectVO(inputTntCond);
        result.setMbj30InputTntVoList(inputTntVoList);

        //**********************************
        //画面項目表示列制御マスタ取得
        //**********************************
        Mbj37DisplayControlDAO displayControlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        //Mbj37DisplayControlVO displayControlCond = new Mbj37DisplayControlVO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> displayControlVoList = displayControlDao.selectVO(displayControlCond);
        result.setMbj37DisplayControlVoList(displayControlVoList);

        //**********************************
        //一覧表示パターン取得
        //**********************************
        Tbj30DisplayPatternDAO displayPatternDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition displayPatternCond = new Tbj30DisplayPatternCondition();
        displayPatternCond.setHamid(cond.getUserid());
        displayPatternCond.setFormid(cond.getFormid());
        List<Tbj30DisplayPatternVO> displayPatternVoList = displayPatternDao.selectVO(displayPatternCond);
        result.setTbj30DisplayPatternVoList(displayPatternVoList);

        //**********************************
        //コードマスタ取得
        //**********************************
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        List<Mbj12CodeVO> codeVoList = new ArrayList<Mbj12CodeVO>();
        Mbj12CodeCondition codeCondition = new Mbj12CodeCondition();
//        codeCondition.setCodetype("24");
//        codeVoList.addAll(codeDao.selectVO(codeCondition));
//        codeCondition.setCodetype("31");
//        codeVoList.addAll(codeDao.selectVO(codeCondition));
//        codeCondition.setCodetype("34");
//        codeVoList.addAll(codeDao.selectVO(codeCondition));
//        codeCondition.setCodetype("35");
//        codeVoList.addAll(codeDao.selectVO(codeCondition));
//        codeCondition.setCodetype("36");
//        codeVoList.addAll(codeDao.selectVO(codeCondition));
        codeCondition.setCodetype("'24', '31', '34', '35', '36'");
        codeVoList = codeDao.FindManyCd(codeCondition);
        result.setMbj12CodeVoList(codeVoList);

        //******************************************************
        //機能制御Infoの取得
        //******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormid());
        funccond.setFunctype("2");
        funccond.setHamid(cond.getUserid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        //******************************************************
        //セキュリティ情報取得
        //******************************************************
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        List<SecurityInfoVO> secVolist = new ArrayList<SecurityInfoVO>();
        secCond.setHamid(cond.getUserid());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setSecuritycd("S000000104");
        secCond.setUsertype(cond.getUsertype());
        secVolist = secManager.getSecurityInfo(secCond).getSecurityInfo();
        result.setSecurityInfoVoList(secVolist);

        //**********************************
        //アラート表示制御マスタ取得
        //**********************************
        Mbj41AlertDispControlDAO alertDao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();
        Mbj41AlertDispControlCondition alertCondition = new Mbj41AlertDispControlCondition();
        alertCondition.setSikognzuntcd(cond.getKksikognzuntcd());
        List<Mbj41AlertDispControlWithUserVO> alertVoList = alertDao.selectVOWithUserNm(alertCondition);
        result.setMbj41AlertDispControlVoList(alertVoList);

        return result;
    }

    /**
     * CR制作費の検索時のデータ取得処理を行う
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindCrCreateDataResult findCrCreateData(FindCrCreateDataCondition cond) throws HAMException {

        FindCrCreateDataResult result = new FindCrCreateDataResult();

        CostManagementDAO dao = CostManagementDAOFactory.createCostManagementDAO();
        FindSeikyuDataDAO seikyuDao = FindSeikyuDataDAOFactory.createFindSeikyuDataDAO();
        FindPayDataDAO payDao = FindPayDataDAOFactory.createFindPayDataDAO();

        //**********************************
        //請求先取得
        //**********************************
        FindSeikyuDataCondition seikyuCond = new FindSeikyuDataCondition();
        seikyuCond.setBaseDate(cond.getEigyobi());
        seikyuCond.setEgsCd(cond.getEgsCd());
        List<SeikyuDataVO> seikyuDataVoList = seikyuDao.findSeikyuDataH(seikyuCond);
        result.setSeikyuDataVoList(seikyuDataVoList);

        //**********************************
        //支払先取得
        //**********************************
        FindPayDataCondition payCond = new FindPayDataCondition();
        payCond.setBaseDate(cond.getEigyobi());
        payCond.setEgsCd(cond.getEgsCd());
        List<PayDataVO> payDataVoList = payDao.findPayDataH(payCond);
        result.setPayDataVoList(payDataVoList);

        //****************************************
        //CR車種情報取得
        //****************************************
        //排他処理用の最終更新情報を取得
        Tbj10CrCarInfoDAO crCarInfoDao = Tbj10CrCarInfoDAOFactory.createTbj10CrCarInfoDAO();
        Tbj10CrCarInfoCondition crCarInfoCond = new Tbj10CrCarInfoCondition();
        List<Tbj10CrCarInfoVO> tmpCrCarInfoVoList = crCarInfoDao.findMaxTimeStamp(crCarInfoCond);
        result.setMaxDateTimeForCrCarInfo(tmpCrCarInfoVoList.get(0).getUPDDATE());

        Tbj10CrCarInfoVO crCarInfoVo = new Tbj10CrCarInfoVO();
        //crCarInfoVo.setPHASE(cond.getPhase());
        //crCarInfoVo.setCRDATE(cond.getCrDate());
        List<Tbj10CrCarInfoVO> crCarInfoVoList = crCarInfoDao.selectVO(crCarInfoVo);
        result.setTbj10CrCarInfoVoList(crCarInfoVoList);

        //****************************************
        //CR制作費管理取得
        //****************************************
        //排他処理用の最終更新情報を取得
        List<Tbj11CrCreateDataVO> tmpCrCreateDataVoList = dao.findMaxTimeStamp(cond);
        result.setMaxDateTimeForCrCreateData(tmpCrCreateDataVoList.get(0).getUPDDATE());

        List<Tbj11CrCreateDataVO> crCreateDataVoList = dao.selectListData(cond);
        result.setTbj11CrCreateDataVoList(crCreateDataVoList);

        return result;
    }

    /**
     * CR制作費の登録時の排他チェック処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForRegisterCrCreateData(RegisterCrCreateDataVO vo) throws HAMException {

        //****************************************
        //CR車種情報の登録／更新
        //****************************************
        if (vo.getMaxDateTimeForCrCarInfo() != null) {
            Tbj10CrCarInfoDAO crCarInfoDao = Tbj10CrCarInfoDAOFactory.createTbj10CrCarInfoDAO();

            if (vo.getTbj10CrCarInfoVoListUpd() != null) {
                for (Tbj10CrCarInfoVO tbj10CrCarInfoVO : vo.getTbj10CrCarInfoVoListUpd()) {
                    Tbj10CrCarInfoVO cond = new Tbj10CrCarInfoVO();
                    cond.setDCARCD(tbj10CrCarInfoVO.getDCARCD());
                    cond.setPHASE(tbj10CrCarInfoVO.getPHASE());
                    cond.setCRDATE(tbj10CrCarInfoVO.getCRDATE());
                    List<Tbj10CrCarInfoVO> tempVoList = crCarInfoDao.selectVO(cond);
                    if (tempVoList.size() == 0) {
                        //更新しようとしているデータがなければ排他エラー
                        return false;
                    }
                    if (vo.getMaxDateTimeForCrCarInfo().before(tempVoList.get(0).getUPDDATE())) {
                        //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                        return false;
                    }
                }
            }
            if (vo.getTbj10CrCarInfoVoListReg() != null) {
                for (Tbj10CrCarInfoVO tbj10CrCarInfoVO : vo.getTbj10CrCarInfoVoListReg()) {
                    Tbj10CrCarInfoVO cond = new Tbj10CrCarInfoVO();
                    cond.setDCARCD(tbj10CrCarInfoVO.getDCARCD());
                    cond.setPHASE(tbj10CrCarInfoVO.getPHASE());
                    cond.setCRDATE(tbj10CrCarInfoVO.getCRDATE());
                    List<Tbj10CrCarInfoVO> tempVoList = crCarInfoDao.selectVO(cond);
                    if (tempVoList.size() > 0) {
                        //登録しようとしているデータが既に存在していたら排他エラー
                        return false;
                    }
                }
            }
        }

        //****************************************
        //CR制作費管理の登録／更新／削除
        //****************************************
        if (vo.getMaxDateTimeForCrCreateData() != null) {
            if (vo.getFindCrCreateDataCondition() != null) {
                CostManagementDAO crCreateDataDao = CostManagementDAOFactory.createCostManagementDAO();
                List<Tbj11CrCreateDataVO> tempVoList = crCreateDataDao.selectListData(vo.getFindCrCreateDataCondition());
                //取得したデータをMapへ格納しなおす
                Map<String, Date> tempVoMap = new HashMap<String, Date>();
                for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : tempVoList) {
                    tempVoMap.put(getKeyForCrCreateData(tbj11CrCreateDataVO), tbj11CrCreateDataVO.getUPDDATE());
                }
                //更新データ
                if (vo.getTbj11CrCreateDataVoListUpd() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListUpd()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //取得したデータの中に更新しようとしているデータがなければ排他エラー
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                            return false;
                        }
                    }
                }
                //削除データ
                if (vo.getTbj11CrCreateDataVoListDel() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListDel()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //取得したデータの中に更新しようとしているデータがなければ排他エラー
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                            return false;
                        }
                    }
                }
                //中止データ
                if (vo.getTbj11CrCreateDataVoListStp() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListStp()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //取得したデータの中に更新しようとしているデータがなければ排他エラー
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

//    /**
//     * VOの値からデータを一意に判別するキー値を取得する(CR車種情報)
//     * @param vo
//     * @return
//     */
//    private String getKeyForCrCarInfo(Tbj10CrCarInfoVO vo) {
//        SimpleDateFormat format = new SimpleDateFormat("yyyyMMddHHmmssSSS");
//        return vo.getDCARCD() + "|" + String.format("%1$03d", vo.getPHASE()) + "|" + format.format(vo.getCRDATE());
//    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(CR制作費管理)
     * @param vo
     * @return
     */
    private String getKeyForCrCreateData(Tbj11CrCreateDataVO vo) {
        NumberFormat nf = new DecimalFormat("0");
        nf.setMinimumIntegerDigits(10);
        return nf.format(vo.getSEQUENCENO());
    }

    /**
     * CR制作費の登録時のデータ更新処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public RegisterCrCreateDataResult registerCrCreateData(RegisterCrCreateDataVO vo) throws HAMException {
        HashSet<String> trThsCdList = new HashSet<String>();

        RegisterCrCreateDataResult result = new RegisterCrCreateDataResult();
        List<BigDecimal> lstSeqNo = new ArrayList<BigDecimal>();

        //****************************************
        //排他チェック
        //****************************************
        if (!checkExclusionForRegisterCrCreateData(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        //****************************************
        //CR車種情報の登録／更新
        //****************************************
        Tbj10CrCarInfoDAO crCarInfoDao = Tbj10CrCarInfoDAOFactory.createTbj10CrCarInfoDAO();
        if (vo.getTbj10CrCarInfoVoListUpd() != null) {
            for (int i = 0; i < vo.getTbj10CrCarInfoVoListUpd().size(); i++) {
                crCarInfoDao.updateVO(vo.getTbj10CrCarInfoVoListUpd().get(i));
            }
        }
        if (vo.getTbj10CrCarInfoVoListReg() != null) {
            for (int i = 0; i < vo.getTbj10CrCarInfoVoListReg().size(); i++) {
                crCarInfoDao.insertVO(vo.getTbj10CrCarInfoVoListReg().get(i));
            }
        }

        //****************************************
        //CR制作費管理の登録／更新／削除
        //****************************************
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        //削除データがある場合は削除処理を実行
        if (vo.getTbj11CrCreateDataVoListDel() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListDel().size(); i++) {
                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
//                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
//                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListDel().get(i).getDCARCD());
//                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListDel().get(i).getPHASE());
//                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListDel().get(i).getCRDATE());
//                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListDel().get(i).getSEQUENCENO());
//                logCrCreateDataVo.setRIREKINM("削除");
//                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListDel().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListDel().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListDel().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListDel().get(i).getSEQUENCENO());
                costManageDao.deleteHistoryForCrCreate(logCrCreateDataVo);

                //CR制作費管理の削除
                crCreateDataDao.deleteVO(vo.getTbj11CrCreateDataVoListDel().get(i));
            }
        }
        //中止データがある場合は中止(更新)処理を実行
        if (vo.getTbj11CrCreateDataVoListStp() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListStp().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = new Tbj11CrCreateDataForUpdVO();
                crCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListStp().get(i).getDCARCD());
                crCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListStp().get(i).getPHASE());
                crCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListStp().get(i).getCRDATE());
                crCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListStp().get(i).getSEQUENCENO());
                crCreateDataVo.setRSTATUS(vo.getTbj11CrCreateDataVoListStp().get(i).getRSTATUS());
                crCreateDataVo.setSTPKBN(vo.getTbj11CrCreateDataVoListStp().get(i).getSTPKBN());
                crCreateDataVo.setUPDAPL(vo.getTbj11CrCreateDataVoListStp().get(i).getUPDAPL());
                crCreateDataVo.setUPDID(vo.getTbj11CrCreateDataVoListStp().get(i).getUPDID());
                crCreateDataVo.setUPDNM(vo.getTbj11CrCreateDataVoListStp().get(i).getUPDNM());

                //CR制作費管理の更新
                crCreateDataDao.updateVO(crCreateDataVo);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListStp().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListStp().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListStp().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListStp().get(i).getSEQUENCENO());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_STOP);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            }
        }
        //更新データがある場合は更新処理を実行
        if (vo.getTbj11CrCreateDataVoListUpd() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListUpd().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListUpd().get(i);

                //入力担当のコードが設定されていないで名称が設定されている場合は新規入力担当としてマスタへの登録を行う
                if ((crCreateDataVo.getINPUTTNTCD() == null || crCreateDataVo.getINPUTTNTCD().equals(BigDecimal.ZERO))
                        && crCreateDataVo.getInputTntNm() != null) {
                    BigDecimal newInputTntCd = RegisterInputTntMaster(crCreateDataVo);
                    crCreateDataVo.setINPUTTNTCD(newInputTntCd);
                }

                if (!StringUtil.isBlank(crCreateDataVo.getTRTHSKGYCD())
                    && !trThsCdList.contains(crCreateDataVo.getTRTHSKGYCD() + "|" + crCreateDataVo.getTRSEQNO() + "|" + crCreateDataVo.getCLASSDIV())) {

                    trThsCdList.add(crCreateDataVo.getTRTHSKGYCD() + "|" + crCreateDataVo.getTRSEQNO() + "|" + crCreateDataVo.getCLASSDIV());

                    Mbj46ThsVO insThsVo = new Mbj46ThsVO();
                    insThsVo.setTHSKGYCD(crCreateDataVo.getTRTHSKGYCD());
                    insThsVo.setSEQNO(crCreateDataVo.getTRSEQNO());
                    insThsVo.setTRTHKBN("0");
                    insThsVo.setCLASSDIV(crCreateDataVo.getCLASSDIV());
                    insThsVo.setSORTNO(BigDecimal.ZERO);
                    //insThsVo.setUPDDATE();
                    insThsVo.setUPDNM(crCreateDataVo.getUPDNM());
                    insThsVo.setUPDAPL(crCreateDataVo.getUPDAPL());
                    insThsVo.setUPDID(crCreateDataVo.getUPDID());
                    RegisterThs(insThsVo);
                }

                //CR制作費管理の更新
                crCreateDataDao.updateVO(crCreateDataVo);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListUpd().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListUpd().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListUpd().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListUpd().get(i).getSEQUENCENO());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            }
        }
        //登録データがある場合は登録処理を実行
        if (vo.getTbj11CrCreateDataVoListReg() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListReg().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListReg().get(i);

                //入力担当のコードが設定されていないで名称が設定されている場合は新規入力担当としてマスタへの登録を行う
                if ((crCreateDataVo.getINPUTTNTCD() == null || crCreateDataVo.getINPUTTNTCD().equals(BigDecimal.ZERO))
                        && crCreateDataVo.getInputTntNm() != null) {
                    BigDecimal newInputTntCd = RegisterInputTntMaster(crCreateDataVo);
                    crCreateDataVo.setINPUTTNTCD(newInputTntCd);
                }

                if (!StringUtil.isBlank(crCreateDataVo.getTRTHSKGYCD())
                    && !trThsCdList.contains(crCreateDataVo.getTRTHSKGYCD() + "|" + crCreateDataVo.getTRSEQNO() + "|" + crCreateDataVo.getCLASSDIV())) {

                    trThsCdList.add(crCreateDataVo.getTRTHSKGYCD() + "|" + crCreateDataVo.getTRSEQNO() + "|" + crCreateDataVo.getCLASSDIV());

                    Mbj46ThsVO insThsVo = new Mbj46ThsVO();
                    insThsVo.setTHSKGYCD(crCreateDataVo.getTRTHSKGYCD());
                    insThsVo.setSEQNO(crCreateDataVo.getTRSEQNO());
                    insThsVo.setTRTHKBN("0");
                    insThsVo.setCLASSDIV(crCreateDataVo.getCLASSDIV());
                    insThsVo.setSORTNO(BigDecimal.ZERO);
                    //insThsVo.setUPDDATE();
                    insThsVo.setUPDNM(crCreateDataVo.getUPDNM());
                    insThsVo.setUPDAPL(crCreateDataVo.getUPDAPL());
                    insThsVo.setUPDID(crCreateDataVo.getUPDID());
                    RegisterThs(insThsVo);
                }

                //SEQNOの取得・設定
                crCreateDataVo.setSEQUENCENO(GetSequenceNo(crCreateDataVo.getDCARCD(), crCreateDataVo.getPHASE(), crCreateDataVo.getCRDATE()));
                //CR制作費管理への登録実行
                crCreateDataDao.insertVO(crCreateDataVo);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListReg().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListReg().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListReg().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListReg().get(i).getSEQUENCENO());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);

                //登録したデータの制作費管理Noを保持.
                lstSeqNo.add(crCreateDataVo.getSEQUENCENO());
            }
        }
        //ソート順の更新対象データがある場合は更新処理を実行
        if (vo.getTbj11CrCreateDataVoListSort() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListSort().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListSort().get(i);

                //CR制作費管理の更新
                crCreateDataDao.updateSortNo(crCreateDataVo);
            }
        }

        //**********************************
        //返却パラメータの取得・設定
        //**********************************
        //入力担当マスタ
        Mbj30InputTntDAO inputTntDao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        Mbj30InputTntCondition inputTntCond = new Mbj30InputTntCondition();
        List<Mbj30InputTntVO> inputTntVoList = inputTntDao.selectVO(inputTntCond);
        result.setMbj30InputTntVoList(inputTntVoList);

        //登録したデータのキー情報.
        List<Tbj11CrCreateDataVO> retVoList = new ArrayList<Tbj11CrCreateDataVO>();
        if (lstSeqNo != null) {
            for (int i = 0; i < lstSeqNo.size(); i++) {
                Tbj11CrCreateDataVO retVo = new Tbj11CrCreateDataVO();
                retVo.setSEQUENCENO(lstSeqNo.get(i));
                retVoList.add(retVo);
            }
        }

        result.setTbj11CrCreateDataVoList(retVoList);
        return result;
    }

    /**
     * SortNoの現最大値を取得する
     *
     * @param dcar
     * @param phase
     * @param crDate
     * @return
     * @throws HAMException
     */
    private BigDecimal GetMaxSortNo(String dcarcd, BigDecimal phase, Date crDate, String classDiv) throws HAMException {

        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        Tbj11CrCreateDataCondition crCreateDataCond = new Tbj11CrCreateDataCondition();
        crCreateDataCond.setDcarcd(dcarcd);
        crCreateDataCond.setPhase(phase);
        crCreateDataCond.setCrdate(crDate);
        crCreateDataCond.setClassdiv(classDiv);
        List<Tbj11CrCreateDataVO> maxSortList = crCreateDataDao.findMaxSortNo(crCreateDataCond);
        return maxSortList.get(0).getSORTNO();
    }

    /**
     * SEQNoの採番を行う
     *
     * @param dcar
     * @param phase
     * @param crDate
     * @return
     * @throws HAMException
     */
    private BigDecimal GetSequenceNo(String dcar, BigDecimal phase, Date crDate) throws HAMException {

        //（現MAX値+1）
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        Tbj11CrCreateDataCondition crCreateDataCond = new Tbj11CrCreateDataCondition();
        //条件なし(全件のMAX値を取得する)
        List<Tbj11CrCreateDataVO> maxSeqList = crCreateDataDao.findMaxSeqNo(crCreateDataCond);
        return maxSeqList.get(0).getSEQUENCENO().add(BigDecimal.ONE);
    }

    /**
     * CR制作費に登録する入力担当が新規の場合、マスタへの登録を行う
     *
     * @param crCreateDataVo
     * @return 登録したデータのSEQNOの値
     * @throws Exception
     */
    public BigDecimal RegisterInputTntMaster(Tbj11CrCreateDataForUpdVO crCreateDataVo) throws HAMException {

        Mbj30InputTntCondition condition = new Mbj30InputTntCondition();
        condition.setPhase(crCreateDataVo.getPHASE());
        condition.setClassdiv(crCreateDataVo.getCLASSCD());
        condition.setDcarcd(crCreateDataVo.getDCARCD());
        condition.setInputtnt(crCreateDataVo.getInputTntNm());
        Mbj30InputTntDAO inputTntDao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        List<Mbj30InputTntVO> voList = inputTntDao.selectVO(condition);

        if (voList != null && voList.size() > 0 && voList.get(0).getSEQNO() != null) {
            return voList.get(0).getSEQNO();
        }
        else {
            List<Mbj30InputTntVO> seqList = inputTntDao.findMaxSeqNo();

            condition = new Mbj30InputTntCondition();
            condition.setPhase(crCreateDataVo.getPHASE());
            condition.setClassdiv(crCreateDataVo.getCLASSDIV());
            List<Mbj30InputTntVO> sortNoList = inputTntDao.findMaxSortNo(condition);

            Mbj30InputTntVO insVo = new Mbj30InputTntVO();
            insVo.setPHASE(crCreateDataVo.getPHASE());
            insVo.setCLASSDIV(crCreateDataVo.getCLASSDIV());
            insVo.setSEQNO(seqList.get(0).getSEQNO().add(BigDecimal.ONE));
            insVo.setDCARCD(crCreateDataVo.getDCARCD());
            insVo.setINPUTTNT(crCreateDataVo.getInputTntNm());
            insVo.setSORTNO(sortNoList.get(0).getSORTNO().add(BigDecimal.ONE));
            insVo.setUPDAPL(crCreateDataVo.getUPDAPL());
            insVo.setUPDID(crCreateDataVo.getUPDID());
            insVo.setUPDNM(crCreateDataVo.getUPDNM());
            inputTntDao.insertVO(insVo);

            return insVo.getSEQNO();
        }
    }

    /**
     * CR制作費管理テーブルに対して排他チェックを行う
     * @param voList CR制作費データ(PKに値の設定が必須)
     * @param compDate 更新日の比較を行う際の基準となる日時
     * @return
     * @throws HAMException
     */
    private boolean checkExclusionForCrCreateData(List<Tbj11CrCreateDataVO> voList, Date compDate) throws HAMException {
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        List<Tbj11CrCreateDataVO> lockData = crCreateDataDao.selectByPkWithLock(voList);
        //取得したデータをMapへ格納しなおす
        Map<String, Date> tempVoMap = new HashMap<String, Date>();
        for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : lockData) {
            tempVoMap.put(getKeyForCrCreateData(tbj11CrCreateDataVO), tbj11CrCreateDataVO.getUPDDATE());
        }
        for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : voList) {
            if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                //取得したデータの中に更新しようとしているデータがなければ排他エラー
                return false;
            }
            if (compDate.before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                return false;
            }
        }

        return true;
    }

    /**
     * データ移動／コピー画面の登録処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public MoveCrCreateDataResult MoveCrCreateData(MoveCrCreateDataVO vo) throws HAMException {

        MoveCrCreateDataResult result = new MoveCrCreateDataResult();

        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        //************************************
        //排他チェック
        //************************************
        //CR制作費管理テーブル
        if (!checkExclusionForCrCreateData(vo.getTbj11CrCreateDataVoList(), vo.getMaxDateTimeForCrCreateData())) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        //************************************
        //移動／コピー先のデータをINSERT
        //************************************
        BigDecimal sortNo = null;
        for (int i = 0; i < vo.getTbj11CrCreateDataVoList().size(); i++) {
            Tbj11CrCreateDataVO condVo = vo.getTbj11CrCreateDataVoList().get(i);
            Tbj11CrCreateDataVO sakiDataVo = new Tbj11CrCreateDataVO();

            //移送元データを取得する
            Tbj11CrCreateDataVO motoDataVo = crCreateDataDao.loadVO(condVo);
            if (vo.getExecKind() == 1) {
                //コピーの場合元データの値を全て移送
                sakiDataVo.getOriginalMember().putAll(motoDataVo.getOriginalMember());
            }
            //変更内容に関係ない更新項目を編集------------------------
            sakiDataVo.setDCARCD(vo.getDCarCd());                               //電通車種コード
            sakiDataVo.setPHASE(vo.getPhase());                                 //フェイズ
            sakiDataVo.setCRDATE(vo.getCrDate());                               //年月
            if (vo.getExecKind() == 1) {
                //コピーの場合SEQを採番
                sakiDataVo.setSEQUENCENO(GetSequenceNo(vo.getDCarCd(), vo.getPhase(), vo.getCrDate()));// SEQUENCENO
                //コピー先は新規登録データとして
                sakiDataVo.setCRTNM(vo.getUsernm());                                //登録者
                sakiDataVo.setCRTID(vo.getUserid());                                //登録者ID
                sakiDataVo.setCRTAPL(vo.getFormid());                               //作成プログラム
            }
            sakiDataVo.setCLASSDIV(vo.getClassDiv());                           //データ種別
            if (sortNo == null) {
                sortNo = GetMaxSortNo(vo.getDCarCd(), vo.getPhase(), vo.getCrDate(), vo.getClassDiv()).add(BigDecimal.ONE);
            } else {
                sortNo = sortNo.add(BigDecimal.ONE);
            }
            sakiDataVo.setSORTNO(sortNo);                                       //ソートNo
            sakiDataVo.setUPDNM(vo.getUsernm());                                //更新者
            sakiDataVo.setUPDAPL(vo.getFormid());                               //更新APP
            sakiDataVo.setUPDID(vo.getUserid());                                //更新者ID

            //変更前後のデータ種別によって編集内容を変更する----------
            if (motoDataVo.getCLASSDIV().equals(vo.getClassDiv())) {
                //データ種別の変更がない場合
                sakiDataVo.setCLASSCD(ChangeClassCdByMove(motoDataVo, sakiDataVo)); //予算表分類
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //予算表費目
                if (!motoDataVo.getDCARCD().equals(vo.getDCarCd()) || !motoDataVo.getPHASE().equals(vo.getPhase())) {
                    //車種orフェイズが変更になっている場合
                    sakiDataVo.setINPUTTNTCD(null);                                     //入力担当者コード
                    sakiDataVo.setINPUTTNTCDFLG("0");                                   //入力担当者フラグ
                }
            } else if (motoDataVo.getCLASSDIV().equals("0")) {
                //制作原価表→制作費表の場合
                sakiDataVo.setCLASSCD(""); //予算表分類
                sakiDataVo.setCLASSCDFLG("0");                                      //予算表分類フラグ
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //予算表費目
                sakiDataVo.setKIKANS(null);                                         //期間From
                sakiDataVo.setKIKANSFLG("0");                                       //期間Fromフラグ
                sakiDataVo.setKIKANE(null);                                         //期間To
                sakiDataVo.setKIKANEFLG("0");                                       //期間Toフラグ
                sakiDataVo.setCONTRACTDATE(null);                                   //契約日
                sakiDataVo.setCONTRACTDATEFLG("0");                                 //契約日フラグ
                sakiDataVo.setCONTRACTTERM("");                                     //契約期間
                sakiDataVo.setCONTRACTTERMFLG("0");                                 //契約期間フラグ
                sakiDataVo.setSEIKYU("");                                           //請求先
                sakiDataVo.setSEIKYUFLG("0");                                       //請求先フラグ
                sakiDataVo.setGETMONEY(BigDecimal.valueOf(0));                      //取り金額
                sakiDataVo.setGETMONEYFLG("0");                                     //取り金額フラグ
                sakiDataVo.setGETCONF("0");                                         //取り金額確認
                sakiDataVo.setGETCONFIRMFLG("0");                                   //取り金額確認フラグ
                sakiDataVo.setPAYMONEY(motoDataVo.getESTMONEY());                   //払い金額
                sakiDataVo.setPAYMONEYFLG(motoDataVo.getESTMONEYFLG());             //払い金額フラグ
                sakiDataVo.setPAYCONF("0");                                         //払い金額確認
                sakiDataVo.setPAYCONFIRMFLG("0");                                   //払い金額確認フラグ
                sakiDataVo.setESTMONEY(BigDecimal.valueOf(0));                      //見積金額
                sakiDataVo.setESTMONEYFLG("0");                                     //見積金額フラグ
                sakiDataVo.setCLMMONEY(BigDecimal.valueOf(0));                      //請求金額
                sakiDataVo.setCLMMONEYFLG("0");                                     //請求金額フラグ
                sakiDataVo.setINPUTTNTCD(null);                                     //入力担当者コード
                sakiDataVo.setINPUTTNTCDFLG("0");                                   //入力担当者フラグ
            } else if (motoDataVo.getCLASSDIV().equals("1")) {
                //制作費表→制作原価表の場合
                sakiDataVo.setCLASSCD("0");                                         //予算表分類
                sakiDataVo.setCLASSCDFLG("0");                                      //予算表分類フラグ
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //予算表費目
                sakiDataVo.setKIKANS(null);                                         //期間From
                sakiDataVo.setKIKANSFLG("0");                                       //期間Fromフラグ
                sakiDataVo.setKIKANE(null);                                         //期間To
                sakiDataVo.setKIKANEFLG("0");                                       //期間Toフラグ
                sakiDataVo.setCONTRACTDATE(null);                                   //契約日
                sakiDataVo.setCONTRACTDATEFLG("0");                                 //契約日フラグ
                sakiDataVo.setCONTRACTTERM("");                                     //契約期間
                sakiDataVo.setCONTRACTTERMFLG("0");                                 //契約期間フラグ
                sakiDataVo.setSEIKYU("");                                           //請求先
                sakiDataVo.setSEIKYUFLG("0");                                       //請求先フラグ
                sakiDataVo.setGETMONEY(BigDecimal.valueOf(0));                      //取り金額
                sakiDataVo.setGETMONEYFLG("0");                                     //取り金額フラグ
                sakiDataVo.setGETCONF("0");                                         //取り金額確認
                sakiDataVo.setGETCONFIRMFLG("0");                                   //取り金額確認フラグ
                sakiDataVo.setPAYMONEY(BigDecimal.valueOf(0));                      //払い金額
                sakiDataVo.setPAYMONEYFLG("0");                                     //払い金額フラグ
                sakiDataVo.setPAYCONF("0");                                         //払い金額確認
                sakiDataVo.setPAYCONFIRMFLG("0");                                   //払い金額確認フラグ
                sakiDataVo.setESTMONEY(motoDataVo.getPAYMONEY());                   //見積金額
                sakiDataVo.setESTMONEYFLG(motoDataVo.getPAYMONEYFLG());             //見積金額フラグ
                sakiDataVo.setCLMMONEY(BigDecimal.valueOf(0));                      //請求金額
                sakiDataVo.setCLMMONEYFLG("0");                                     //請求金額フラグ
                sakiDataVo.setINPUTTNTCD(null);                                     //入力担当者コード
                sakiDataVo.setINPUTTNTCDFLG("0");                                   //入力担当者フラグ
            }

            if (vo.getExecKind() == 0) {
                //移動の場合は移動元を移動先にUPDATE
                Tbj11CrCreateDataCondition updCond = new Tbj11CrCreateDataCondition();
                updCond.setDcarcd(condVo.getDCARCD());                              //[更新条件]電通車種コード
                updCond.setPhase(condVo.getPHASE());                                //[更新条件]フェイズ
                updCond.setCrdate(condVo.getCRDATE());                              //[更新条件]年月
                updCond.setSequenceno(condVo.getSEQUENCENO());                      //[更新条件]SEQNO
                crCreateDataDao.updateVOByCond(sakiDataVo, updCond);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(updCond.getDcarcd());
                logCrCreateDataVo.setPHASE(updCond.getPhase());
                logCrCreateDataVo.setCRDATE(updCond.getCrdate());
                logCrCreateDataVo.setSEQUENCENO(updCond.getSequenceno());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DATAMOVE);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            } else if (vo.getExecKind() == 1) {
                //コピーの場合はコピー先をINSERT
                crCreateDataDao.insertVO(sakiDataVo);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(sakiDataVo.getDCARCD());
                logCrCreateDataVo.setPHASE(sakiDataVo.getPHASE());
                logCrCreateDataVo.setCRDATE(sakiDataVo.getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(sakiDataVo.getSEQUENCENO());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DATACOPY);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            }
        }

        return result;
    }

    /**
     * 予算表分類を移動(コピー)元のコードから先のコードに変換する
     * @param motoDataVo
     * @param sakiDataVo
     * @return
     */
    private String ChangeClassCdByMove(Tbj11CrCreateDataVO motoDataVo, Tbj11CrCreateDataVO sakiDataVo) {
        //83期以降→82期以前
        if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
            if (motoDataVo.getCLASSCD().equals("2")) {
                //"想定外"の場合、"HM都合"に置き換え
                return "1";
            } else {
                //上記以外はそのままをセット
                return motoDataVo.getCLASSCD();
            }
        } else if (sakiDataVo.getPHASE().intValue() >= 83 && motoDataVo.getPHASE().intValue() <= 82) {
            //82期以前→83期以降
            return motoDataVo.getCLASSCD();
        } else {
            return motoDataVo.getCLASSCD();
        }
    }

    /**
     * 予算表費目を移動(コピー)元のコードから先のコードに変換する
     * @param motoDataVo
     * @param sakiDataVo
     * @return
     * @throws HAMException
     */
    private String ChangeExpCdByMove(Tbj11CrCreateDataVO motoDataVo, Tbj11CrCreateDataVO sakiDataVo) throws HAMException {

//        //★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
//        //全てべた書きでやっているので変換マスタか何かで管理するように変更することを検討
//        //そうしないと費目が増減するたびにコードの修正が必要に・・・
//        //★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
//
//        if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //制作原価表⇒制作原価表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前
//                if (motoDataVo.getEXPCD().equals("30")) {return "01"; }          //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("31")) {return "02"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("32")) {return "03"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("33")) {return "04"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("34")) {return "05"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("35")) {return "06"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("36")) {return "07"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("37")) {return "08"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("38")) {return "09"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("39")) {return "10"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("40")) {return "11"; }     //契約（音楽）                ⇒契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）
//                else if (motoDataVo.getEXPCD().equals("41")) {return "11"; }     //契約（ﾀﾚﾝﾄ）                ⇒契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）
//                else if (motoDataVo.getEXPCD().equals("42")) {return "11"; }     //契約（ﾅﾚｰﾀｰ）               ⇒契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）
//                else if (motoDataVo.getEXPCD().equals("67")) {return "11"; }     //契約（ﾓﾃﾞﾙ）                ⇒契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）
//                else if (motoDataVo.getEXPCD().equals("68")) {return "11"; }     //契約（その他）              ⇒契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）
//                else if (motoDataVo.getEXPCD().equals("43")) {return "12"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("44")) {return "13"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("45")) {return "14"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("46")) {return "15"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("47")) {return "15"; }     //調査費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("63")) {return "15"; }     //フィー                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("64")) {return "15"; }     //運営費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("65")) {return "15"; }     //メディア                    ⇒その他
//                else if (motoDataVo.getEXPCD().equals("66")) {return "15"; }     //Web制作費                   ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降
//                if (motoDataVo.getEXPCD().equals("01")) {return "30"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("02")) {return "31"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("03")) {return "32"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("04")) {return "33"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("05")) {return "34"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("06")) {return "35"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("07")) {return "36"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("08")) {return "37"; }     //雑誌制作・製版              ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("09")) {return "38"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("10")) {return "39"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("11")) {return "40"; }     //契約（音楽・ﾀﾚﾝﾄ・ﾅﾚｰﾀｰ）   ⇒契約（音楽）
//                else if (motoDataVo.getEXPCD().equals("12")) {return "43"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("13")) {return "44"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("14")) {return "45"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("15")) {return "46"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降
//                return motoDataVo.getEXPCD();
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前
//                return motoDataVo.getEXPCD();
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //制作原価表⇒制作費表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前
//                if (motoDataVo.getEXPCD().equals("30")) {return "16"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("31")) {return "17"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("32")) {return "18"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("33")) {return "19"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("34")) {return "20"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("35")) {return "21"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("36")) {return "22"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("37")) {return "23"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("38")) {return "24"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("39")) {return "25"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("43")) {return "26"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("44")) {return "27"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("45")) {return "28"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("46")) {return "29"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("47")) {return "29"; }     //調査費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("63")) {return "29"; }     //フィー                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("64")) {return "29"; }     //運営費                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降
//                if (motoDataVo.getEXPCD().equals("01")) {return "48"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("02")) {return "49"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("03")) {return "50"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("04")) {return "51"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("05")) {return "52"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("06")) {return "53"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("07")) {return "54"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("08")) {return "55"; }     //雑誌制作・製版              ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("09")) {return "56"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("10")) {return "57"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("12")) {return "58"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("13")) {return "59"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("14")) {return "60"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("15")) {return "61"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降
//                if (motoDataVo.getEXPCD().equals("30")) {return "48"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("31")) {return "49"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("32")) {return "50"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("33")) {return "51"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("34")) {return "52"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("35")) {return "53"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("36")) {return "54"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("37")) {return "55"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("38")) {return "56"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("39")) {return "57"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("43")) {return "58"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("44")) {return "59"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("45")) {return "60"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("46")) {return "61"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("47")) {return "62"; }     //調査費                      ⇒調査費
//                else if (motoDataVo.getEXPCD().equals("63")) {return "69"; }     //フィー                      ⇒フィー
//                else if (motoDataVo.getEXPCD().equals("64")) {return "70"; }     //運営費                      ⇒運営費
//                else if (motoDataVo.getEXPCD().equals("65")) {return "71"; }     //メディア                    ⇒メディア
//                else if (motoDataVo.getEXPCD().equals("66")) {return "72"; }     //Web制作費                   ⇒Web制作費
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前
//                if (motoDataVo.getEXPCD().equals("01")) {return "16"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("02")) {return "17"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("03")) {return "18"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("04")) {return "19"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("05")) {return "20"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("06")) {return "21"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("07")) {return "22"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("08")) {return "23"; }     //雑誌制作・製版              ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("09")) {return "24"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("10")) {return "25"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("12")) {return "26"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("13")) {return "27"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("14")) {return "28"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("15")) {return "29"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //制作費表⇒制作原価表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前
//                if (motoDataVo.getEXPCD().equals("48")) {return "01"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("49")) {return "02"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("50")) {return "03"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("51")) {return "04"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("52")) {return "05"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("53")) {return "06"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("54")) {return "07"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("55")) {return "08"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("56")) {return "09"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("57")) {return "10"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("58")) {return "12"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("59")) {return "13"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("60")) {return "14"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("61")) {return "15"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("62")) {return "15"; }     //調査費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("69")) {return "15"; }     //フィー                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("70")) {return "15"; }     //運営費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("71")) {return "15"; }     //メディア                    ⇒その他
//                else if (motoDataVo.getEXPCD().equals("72")) {return "15"; }     //Web制作費                   ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降
//                if (motoDataVo.getEXPCD().equals("16")) {return "30"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("17")) {return "31"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("18")) {return "32"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("19")) {return "33"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("20")) {return "34"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("21")) {return "35"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("22")) {return "36"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("23")) {return "37"; }     //雑誌制作・製版              ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("24")) {return "38"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("25")) {return "39"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("26")) {return "43"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("27")) {return "44"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("28")) {return "45"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("29")) {return "46"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降
//                if (motoDataVo.getEXPCD().equals("48")) {return "30"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("49")) {return "31"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("50")) {return "32"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("51")) {return "33"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("52")) {return "34"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("53")) {return "35"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("54")) {return "36"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("55")) {return "37"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("56")) {return "38"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("57")) {return "39"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("58")) {return "43"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("59")) {return "44"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("60")) {return "45"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("61")) {return "46"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("62")) {return "47"; }     //調査費                      ⇒調査費
//                else if (motoDataVo.getEXPCD().equals("69")) {return "63"; }     //フィー                      ⇒フィー
//                else if (motoDataVo.getEXPCD().equals("70")) {return "64"; }     //運営費                      ⇒運営費
//                else if (motoDataVo.getEXPCD().equals("71")) {return "65"; }     //メディア                    ⇒メディア
//                else if (motoDataVo.getEXPCD().equals("72")) {return "66"; }     //Web制作費                   ⇒Web制作費
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前
//                if (motoDataVo.getEXPCD().equals("16")) {return "01"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("17")) {return "02"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("18")) {return "03"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("19")) {return "04"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("20")) {return "05"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("21")) {return "06"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("22")) {return "07"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("23")) {return "08"; }     //雑誌制作・製版              ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("24")) {return "09"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("25")) {return "10"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("26")) {return "12"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("27")) {return "13"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("28")) {return "14"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("29")) {return "15"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //制作費表⇒制作費表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前
//                if (motoDataVo.getEXPCD().equals("48")) {return "16"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("49")) {return "17"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("50")) {return "18"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("51")) {return "19"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("52")) {return "20"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("53")) {return "21"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("54")) {return "22"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("55")) {return "23"; }     //雑誌制作・Ｄ校了費          ⇒雑誌制作・製版
//                else if (motoDataVo.getEXPCD().equals("56")) {return "24"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("57")) {return "25"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("58")) {return "26"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("59")) {return "27"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("60")) {return "28"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("61")) {return "29"; }     //その他                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("62")) {return "29"; }     //調査費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("69")) {return "29"; }     //フィー                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("70")) {return "29"; }     //運営費                      ⇒その他
//                else if (motoDataVo.getEXPCD().equals("71")) {return "29"; }     //メディア                    ⇒その他
//                else if (motoDataVo.getEXPCD().equals("72")) {return "29"; }     //Web制作費                   ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降
//                if (motoDataVo.getEXPCD().equals("16")) {return "48"; }     //TV-CM制作                   ⇒TV-CM制作
//                else if (motoDataVo.getEXPCD().equals("17")) {return "49"; }     //プリント                    ⇒プリント
//                else if (motoDataVo.getEXPCD().equals("18")) {return "50"; }     //R-CM制作                    ⇒R-CM制作
//                else if (motoDataVo.getEXPCD().equals("19")) {return "51"; }     //JASRAC放送使用料            ⇒JASRAC放送使用料
//                else if (motoDataVo.getEXPCD().equals("20")) {return "52"; }     //GR撮影                      ⇒GR撮影
//                else if (motoDataVo.getEXPCD().equals("21")) {return "53"; }     //新聞制作                    ⇒新聞制作
//                else if (motoDataVo.getEXPCD().equals("22")) {return "54"; }     //新聞製版                    ⇒新聞製版
//                else if (motoDataVo.getEXPCD().equals("23")) {return "55"; }     //雑誌制作・製版              ⇒雑誌制作・Ｄ校了費
//                else if (motoDataVo.getEXPCD().equals("24")) {return "56"; }     //OOH制作・製版・印刷         ⇒OOH制作・製版・印刷
//                else if (motoDataVo.getEXPCD().equals("25")) {return "57"; }     //車両輸送・保管              ⇒車両輸送・保管
//                else if (motoDataVo.getEXPCD().equals("26")) {return "58"; }     //WEBバナー                   ⇒WEBバナー
//                else if (motoDataVo.getEXPCD().equals("27")) {return "59"; }     //イベント                    ⇒イベント
//                else if (motoDataVo.getEXPCD().equals("28")) {return "60"; }     //イントラ作業他              ⇒イントラ作業他
//                else if (motoDataVo.getEXPCD().equals("29")) {return "61"; }     //その他                      ⇒その他
//                else { throw new HAMException("予算表費目変換エラー", "BJ-W0175"); } //想定外の予算表費目
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降
//                return motoDataVo.getEXPCD();
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前
//                return motoDataVo.getEXPCD();
//            }
//        }

//        if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //制作原価表⇒制作原価表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降・・・○変換は行わない
//                return motoDataVo.getEXPCD();
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前・・・○変換は行わない
//                return motoDataVo.getEXPCD();
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //制作原価表⇒制作費表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前・・・○変換マスタで費目変換へ
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //制作費表⇒制作原価表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前・・・○変換マスタで費目変換へ
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //制作費表⇒制作費表
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83期以降⇒82期以前・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82期以前⇒83期以降・・・○変換マスタで費目変換へ
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83期以降⇒83期以降・・・○変換は行わない
//                return motoDataVo.getEXPCD();
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82期以前⇒82期以前・・・○変換は行わない
//                return motoDataVo.getEXPCD();
//            }
//        }

        Mbj45CrExpConvertDAO dao = Mbj45CrExpConvertDAOFactory.createMbj45CrExpConvertDAO();
        Mbj45CrExpConvertVO vo = new Mbj45CrExpConvertVO();
        vo.setEXPCD(motoDataVo.getEXPCD());
        vo.setCLASSDIV(motoDataVo.getCLASSDIV());
        vo.setDATEFROM(motoDataVo.getCRDATE());
        vo.setDATETO(motoDataVo.getCRDATE());
        vo.setNEWCLASSDIV(sakiDataVo.getCLASSDIV());
        vo.setNEWDATEFROM(sakiDataVo.getCRDATE());
        vo.setNEWDATETO(sakiDataVo.getCRDATE());

        List<Mbj45CrExpConvertVO> voList = dao.selectVOForCNV(vo);
        if (voList.size() > 0) {
            return voList.get(0).getNEWEXPCD();
        }

        throw new HAMException("予算表費目変換エラー", "BJ-W0175");
    }

    /**
     * CR制作費の確認／確認取消時の排他チェック処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForConfirmCrCreateData(ConfirmCrCreateDataVO vo) throws HAMException {

        //****************************************
        //CR制作費管理の確認／確認取消
        //****************************************
        if (vo.getMaxDateTimeForCrCreateData() != null) {
            if (vo.getFindCrCreateDataCondition() != null) {
                CostManagementDAO crCreateDataDao = CostManagementDAOFactory.createCostManagementDAO();
                List<Tbj11CrCreateDataVO> tempVoList = crCreateDataDao.findMaxTimeStamp(vo.getFindCrCreateDataCondition());
                if (tempVoList.get(0).getUPDDATE().compareTo(vo.getMaxDateTimeForCrCreateData()) > 0) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * CR制作費の確認／確認取消時のデータ更新処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public ConfirmCrCreateDataResult ConfirmCrCreateData(ConfirmCrCreateDataVO vo) throws HAMException {

        ConfirmCrCreateDataResult result = new ConfirmCrCreateDataResult();

        //****************************************
        //排他チェック
        //****************************************
        if (!checkExclusionForCrCreateData(vo.getTbj11CrCreateDataVoList(), vo.getMaxDateTimeForCrCreateData())) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        //****************************************
        //CR制作費管理の更新
        //****************************************
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        if (vo.getTbj11CrCreateDataVoList() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoList().size(); i++) {
                Tbj11CrCreateDataVO crCreateDataVo = vo.getTbj11CrCreateDataVoList().get(i);

                //CR制作費管理の更新
                //crCreateDataDao.updateVO(crCreateDataVo);
                Tbj11CrCreateDataCondition crCreateDataCond = new Tbj11CrCreateDataCondition();
                crCreateDataCond.setDcarcd(crCreateDataVo.getDCARCD());
                crCreateDataCond.setPhase(crCreateDataVo.getPHASE());
                crCreateDataCond.setCrdate(crCreateDataVo.getCRDATE());
                crCreateDataCond.setSequenceno(crCreateDataVo.getSEQUENCENO());
                crCreateDataDao.updateVOByCond(crCreateDataVo, crCreateDataCond);

                //履歴の登録
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoList().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoList().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoList().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoList().get(i).getSEQUENCENO());
                if ("1".equals(vo.getConfKbn())) {
                    logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_CONFIRM);
                } else {
                    logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_CONFCANCEL);
                }
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            }
        }

        return result;
    }

    /**
     * 更新履歴画面(CR制作費)の表示データを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindLogCrCreateDataResult findLogCrCreateData(FindLogCrCreateDataCondition cond) throws HAMException {

        FindLogCrCreateDataResult result = new FindLogCrCreateDataResult();

        CostManagementDAO costManagementDao = CostManagementDAOFactory.createCostManagementDAO();
        List<FindLogCrCreateDataVO> findLogCrCreateDataVoList = costManagementDao.findLogCrCreateData(cond);
        result.setFindLogCrCreateDataVoList(findLogCrCreateDataVoList);

        return result;
    }

    /**
     * 車種別予算表のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBudgetResult findBudget(FindBudgetCondition cond) throws HAMException {

        FindBudgetResult result = new FindBudgetResult();

        BudgetDAO dao = BudgetDAOFactory.createBudgetDAO();
        List<FindBudgetVO> voList = dao.findBudget(cond);
        result.setFindBudgetVoList(voList);

        return result;
    }

    /**
     * 車種別予算表(詳細)のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBudgetDetailsResult findBudgetDetails(FindBudgetDetailsCondition cond) throws HAMException {

        FindBudgetDetailsResult result = new FindBudgetDetailsResult();

        //汎用コメントデータの取得
        Tbj32CompurposeDAO compurposeDao = Tbj32CompurposeDAOFactory.createTbj32CompurposeDAO();
        Tbj32CompurposeVO compurposeVoCond = new Tbj32CompurposeVO();
        compurposeVoCond.setCODETYPE("COM");
        compurposeVoCond.setFORMID(cond.getFormid());
        compurposeVoCond.setPHASE(cond.getPhase());
        compurposeVoCond.setKEYCODE1(cond.getDCarCd());
        compurposeVoCond.setKEYCODE2(cond.getDCarCd());
        compurposeVoCond.setKEYCODE3(cond.getDCarCd());
        Tbj32CompurposeVO compurposeVo = compurposeDao.loadVO(compurposeVoCond);
        result.setTbj32CompurposeVO(compurposeVo);

        //最終更新者・日時の取得
        BudgetDetailsDAO budgetDetailsDao = BudgetDetailsDAOFactory.createBudgetDetailsDAO();
        List<Tbj33CrBudgetUpdHisVO> crBudgetUpdHisVoList = budgetDetailsDao.findLastUpdInfoFromHistory(cond);

        if (crBudgetUpdHisVoList == null || crBudgetUpdHisVoList.size() == 0) {
            //履歴から取得できない場合はCR予算からの取得を行う.
            List<Tbj31CrBudgetPlanVO> crBudgetPlanVoList = budgetDetailsDao.findLastUpdInfoFromBudget(cond);
            if (crBudgetPlanVoList != null && crBudgetPlanVoList.size() > 0) {
                Tbj33CrBudgetUpdHisVO crBudgetUpdHisVo = new Tbj33CrBudgetUpdHisVO();
                crBudgetUpdHisVo.setUPDDATE(crBudgetPlanVoList.get(0).getUPDDATE());
                crBudgetUpdHisVo.setUPDNM(crBudgetPlanVoList.get(0).getUPDNM());
                result.setTbj33CrBudgetUpdHisVO(crBudgetUpdHisVo);
            }
        } else {
            result.setTbj33CrBudgetUpdHisVO(crBudgetUpdHisVoList.get(0));
        }

        //実績・予算データの取得(過去ロック以前⇒CR制作費から実績データ、過去ロックより後⇒CR予算から予算データ)
        BudgetDAO dao = BudgetDAOFactory.createBudgetDAO();
        FindBudgetCondition findBudgetCond = new FindBudgetCondition();
        findBudgetCond.setPhase(cond.getPhase());
        findBudgetCond.setHamid(cond.getHamid());
        findBudgetCond.setDCarCd(cond.getDCarCd());
        findBudgetCond.setLockDate(cond.getLockDate());
        List<FindBudgetVO> voList = dao.findBudget(findBudgetCond);
        result.setFindBudgetVoList(voList);

        return result;
    }

    /**
     * 車種別予算表(詳細)の登録処理を行う
     * @param vo
     * @return
     * @throws HAMException
     */
    public RegisterBudgetResult registerBudget(RegisterBudgetVO vo) throws HAMException {
        RegisterBudgetResult result = new RegisterBudgetResult();

        if (vo.getTbj32CompurposeVo() != null) {
            Tbj32CompurposeDAO compurposeDao = Tbj32CompurposeDAOFactory.createTbj32CompurposeDAO();
            //データの有無に関係なく削除.
            compurposeDao.deleteVO(vo.getTbj32CompurposeVo());
            //登録処理.
            compurposeDao.insertVO(vo.getTbj32CompurposeVo());
        }

        //****************************************
        //排他チェック
        //****************************************
        if (!checkExclusionForRegisterBudget(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        if (vo.getTbj31CrBudgetPlanVoList() != null) {
            Tbj31CrBudgetPlanDAO crBudgetPlanDao = Tbj31CrBudgetPlanDAOFactory.createTbj31CrBudgetPlanDAO();
            Tbj33CrBudgetUpdHisDAO crBudgetUpdHisDao = Tbj33CrBudgetUpdHisDAOFactory.createTbj33CrBudgetUpdHisDAO();

            String oldKey = "";
            String newKey = "";

            for (int i = 0; i < vo.getTbj31CrBudgetPlanVoList().size(); i++) {
                Tbj31CrBudgetPlanVO crBudgetPlanVo = vo.getTbj31CrBudgetPlanVoList().get(i);
                if (!crBudgetPlanDao.updateVO(crBudgetPlanVo)) {
                    //更新がされなかった場合は登録処理を実行
                    crBudgetPlanDao.insertVO(crBudgetPlanVo);
                }
                newKey = crBudgetPlanVo.getPHASE() + crBudgetPlanVo.getDCARCD() + crBudgetPlanVo.getCLASSCD() + crBudgetPlanVo.getEXPCD();
                if (!oldKey.equals(newKey)) {
                    Tbj33CrBudgetUpdHisVO crBudgetUpdHisVo = new Tbj33CrBudgetUpdHisVO();
                    crBudgetUpdHisVo.setPHASE(crBudgetPlanVo.getPHASE());
                    crBudgetUpdHisVo.setDCARCD(crBudgetPlanVo.getDCARCD());
                    crBudgetUpdHisVo.setCLASSCD(crBudgetPlanVo.getCLASSCD());
                    crBudgetUpdHisVo.setEXPCD(crBudgetPlanVo.getEXPCD());
                    crBudgetUpdHisVo.setCRTDATE(crBudgetPlanVo.getCRTDATE());
                    crBudgetUpdHisVo.setCRTNM(crBudgetPlanVo.getCRTNM());
                    crBudgetUpdHisVo.setCRTAPL(crBudgetPlanVo.getCRTAPL());
                    crBudgetUpdHisVo.setCRTID(crBudgetPlanVo.getCRTID());
                    crBudgetUpdHisVo.setUPDDATE(crBudgetPlanVo.getUPDDATE());
                    crBudgetUpdHisVo.setUPDNM(crBudgetPlanVo.getUPDNM());
                    crBudgetUpdHisVo.setUPDAPL(crBudgetPlanVo.getUPDAPL());
                    crBudgetUpdHisVo.setUPDID(crBudgetPlanVo.getUPDID());
                    crBudgetUpdHisDao.insertVO(crBudgetUpdHisVo);

                    oldKey = crBudgetPlanVo.getPHASE() + crBudgetPlanVo.getDCARCD() + crBudgetPlanVo.getCLASSCD() + crBudgetPlanVo.getEXPCD();
                }
            }
        }

        return result;
    }

    /**
     * CR制作費の登録時の排他チェック処理を行う
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForRegisterBudget(RegisterBudgetVO vo) throws HAMException {

        //==============================================================
        //排他チェック対象のデータを一つのリストにまとめる
        //==============================================================
        List<Tbj31CrBudgetPlanVO> lst = new ArrayList<Tbj31CrBudgetPlanVO>();

        if (vo.getTbj31CrBudgetPlanVoList() != null) {
            lst.addAll(vo.getTbj31CrBudgetPlanVoList());
        }

        if (lst != null && lst.size() > 0) {
            //==============================================================
            //排他チェック対象のデータの最新の状態を取得する
            //==============================================================
            Tbj31CrBudgetPlanDAO crBudgetPlanDao = Tbj31CrBudgetPlanDAOFactory.createTbj31CrBudgetPlanDAO();
            List<Tbj31CrBudgetPlanVO> lockDatas = crBudgetPlanDao.selectByMultiPk(lst);

            if (vo.getMaxDateTime() == null && lockDatas.size() > 0) {
                //最大更新日付がない(=登録済みデータなし)場合にデータが取得出来ている場合はその時点でエラー
                return false;
            }

            //==============================================================
            //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
            //==============================================================
            //取得したデータをMapへ格納しなおす
            Map<String, Date> tempVoMap = new HashMap<String, Date>();
            for (Tbj31CrBudgetPlanVO lockData : lockDatas) {
                tempVoMap.put(getKeyForCrBudgetPlan(lockData), lockData.getUPDDATE());
            }
            for (Tbj31CrBudgetPlanVO tbj31CrBudgetPlan : lst) {
                if (!tempVoMap.containsKey(getKeyForCrBudgetPlan(tbj31CrBudgetPlan))) {
                    continue;
                }
                if (vo.getMaxDateTime().before(tempVoMap.get(getKeyForCrBudgetPlan(tbj31CrBudgetPlan)))) {
                    //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(CR予算)
     * @param vo
     * @return
     */
    private String getKeyForCrBudgetPlan(Tbj31CrBudgetPlanVO vo) {
        return vo.getDCARCD() + "|" + vo.getPHASE() + "|" + vo.getCRDATE() + "|" + vo.getCLASSCD() + "|" + vo.getEXPCD();
    }

    /**
     * 車種別予算表履歴のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBudgetHistoryResult findBudgetHistory(FindBudgetHistoryCondition cond) throws HAMException {
        FindBudgetHistoryResult result = new FindBudgetHistoryResult();

        BudgetHistoryDAO budgetHistoryDao = BudgetHistoryDAOFactory.createBudgetHistoryDAO();
        List<FindBudgetHistoryVO> findBudgetHistoryVoList = budgetHistoryDao.findBudgetHistory(cond);
        result.setFindBudgetHistoryVoList(findBudgetHistoryVoList);

        return result;
    }

    /**
     * 制作原価表／制作費表に出力するデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public GetRepDataForCostMngResult getRepDataForCostMng(GetRepDataForCostMngCondition cond) throws HAMException {

        GetRepDataForCostMngResult result = new GetRepDataForCostMngResult();
        GetRepDataForCostMngDAO dao = GetRepDataForCostMngDAOFactory.createGetRepDataForCostMngDAO();
        List<RepDataForCostMngHeaderVO> headerVoList = dao.findRepDataForCostMngHeader(cond);
        result.setRepDataForCostMngHeader(headerVoList);

        List<RepDataForCostMngDetailsVO> detailsVoList = dao.findRepDataForCostMngDetails(cond);
        result.setRepDataForCostMngDetails(detailsVoList);

        return result;
    }

    /**
     * 請求先一覧のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindSeikyuDataResult findSeikyuData(FindSeikyuDataCondition cond) throws HAMException {

        FindSeikyuDataResult result = new FindSeikyuDataResult();
        FindSeikyuDataDAO dao = FindSeikyuDataDAOFactory.createFindSeikyuDataDAO();

        //**********************************
        //請求先取得
        //**********************************
        List<SeikyuDataVO> seikyuDataVoList = dao.findSeikyuData(cond);
        result.setSeikyuDataVoList(seikyuDataVoList);

        return result;
    }

    /**
     * 支払先一覧のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindPayDataResult findPayData(FindPayDataCondition cond) throws HAMException {

        FindPayDataResult result = new FindPayDataResult();
        FindPayDataDAO dao = FindPayDataDAOFactory.createFindPayDataDAO();

        //**********************************
        //支払先取得
        //**********************************
        List<PayDataVO> payDataVoList = dao.findPayData(cond);
        result.setPayDataVoList(payDataVoList);

        return result;
    }

    /**
     * 変更内容通知(CR制作費)のデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindChangeNoticeResult findFindChangeNoticeData(FindChangeNoticeCondition cond) throws HAMException {

        FindChangeNoticeResult result = new FindChangeNoticeResult();

        CostManagementDAO costManagementDao = CostManagementDAOFactory.createCostManagementDAO();
        List<FindChangeNoticeVO> findChangeNoticeVoList = costManagementDao.findChangeNoticeData(cond);
        result.setFindChangeNoticeVoList(findChangeNoticeVoList);

        return result;
    }

    /**
     * 指定した名前からメールアドレスを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindMailInfoResult findMailInfo(FindMailInfoCondition cond) throws HAMException {

        FindMailInfoResult result = new FindMailInfoResult();
        Vbj01AccUserDAO accUserDao = Vbj01AccUserDAOFactory.createVbj01AccUserDAO();
        List<Vbj01AccUserCondition> accUserCond = new ArrayList<Vbj01AccUserCondition>();
        for (int i = 0; i < cond.getHamIdList().size(); i++) {
            Vbj01AccUserCondition c = new Vbj01AccUserCondition();
            c.setEsqid(cond.getHamIdList().get(i));
            accUserCond.add(c);
        }
        List<Vbj01AccUserVO> accUserVoList = accUserDao.selectMail(accUserCond);
        result.setAccUserList(accUserVoList);

        return result;
    }

    /**
     * HAM取引先マスタにデータを追加する
     * @param vo
     * @return
     * @throws HAMException
     */
    public RegisterThsResult RegisterThs(RegisterThsVO vo) throws HAMException {
        RegisterThsResult result = new RegisterThsResult();
        Mbj46ThsDAO dao = Mbj46ThsDAOFactory.createMbj46ThsDAO();
        for (Mbj46ThsVO thsVo : vo.getMbj46ThsVoList()) {
            dao.insertVO(thsVo);
        }

        return result;
    }

    /**
     * HAM取引先マスタにデータを追加する
     * @param vo
     * @return
     * @throws HAMException
     */
    public void RegisterThs(Mbj46ThsVO vo) throws HAMException {
        Mbj46ThsDAO dao = Mbj46ThsDAOFactory.createMbj46ThsDAO();
        Mbj46ThsVO cond = new Mbj46ThsVO();
        cond.setTHSKGYCD(vo.getTHSKGYCD());
        cond.setSEQNO(vo.getSEQNO());
        cond.setTRTHKBN(vo.getTRTHKBN());
        cond.setCLASSDIV(vo.getCLASSDIV());
        List<Mbj46ThsVO> voList = dao.selectVO(cond);
        if (voList == null || voList.size() == 0) {
            dao.insertVO(vo);
        }
    }

}
