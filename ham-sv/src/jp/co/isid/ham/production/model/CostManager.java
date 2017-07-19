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
 * ����\�����Ǘ���Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
public class CostManager {

    /** �V���O���g���C���X�^���X */
    private static CostManager _manager = new CostManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private CostManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static CostManager getInstance() {
        return _manager;
    }

    /**
     * CR�����̏����N�����f�[�^�̎擾���s��
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    public GetIniDataForCostManageResult getIniDataForCostManage(GetIniDataForCostManageCondition cond) throws HAMException {
        GetIniDataForCostManageResult result = new GetIniDataForCostManageResult();

        //**********************************
        //�V�X�e���g�p�󋵃}�X�^
        //**********************************
        Mbj01SysStsDAO sysStsDao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();
        Mbj01SysStsVO sysStsCond = new Mbj01SysStsVO();
        sysStsCond.setLOCKTYPE("1");
        sysStsCond.setLOCKDATESTS("1");
        Mbj01SysStsVO sysStsVo = sysStsDao.loadVO(sysStsCond);
        result.setMbj01SysStsVo(sysStsVo);

        //**********************************
        //�S���҃}�X�^�擾
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
            c.setPoststate("0");//�喱�̃f�[�^�̂ݑΏ�
            accUserConds.add(c);
        }
        List<Vbj01AccUserVO> accUserVoList = accUserDao.selectForEachKK(accUserConds);

        for (int i = 0; i < userVoList.size(); i++) {
            Mbj02UserVO mbj02UserVo = userVoList.get(i);
            List<Vbj01AccUserVO> removeDataList = new ArrayList<Vbj01AccUserVO>();
            for (int j = 0; j < accUserVoList.size(); j++) {
                if (accUserVoList.get(j).getESQID().equals(mbj02UserVo.getHAMID())) {
                    //�S���҃}�X�^����擾�����l���ڑ�.
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
                    //��x�q�b�g�����f�[�^�͕s�v�Ȃ̂ō폜�ΏۂƂ���(������Ƃ������X�|���X�΍�)
                    removeDataList.add(accUserVo);
                }
            }

            //�폜�ΏۂƂȂ����l���View�̃f�[�^���폜����(������Ƃ������X�|���X�΍�)
            accUserVoList.removeAll(removeDataList);
        }

        result.setUserVoList(userVoList2);

        //**********************************
        //�敪�}�X�^�擾
        //**********************************
        Mbj17CrDivisionDAO scrDivisionDao = Mbj17CrDivisionDAOFactory.createMbj17CrDivisionDAO();
        Mbj17CrDivisionVO crDivisionCond = new Mbj17CrDivisionVO();
        List<Mbj17CrDivisionVO> crDivisionVoList = scrDivisionDao.selectVO(crDivisionCond);
        result.setMbj17CrDivisionVoList(crDivisionVoList);

        //**********************************
        //�����O���[�v�}�X�^�擾
        //**********************************
        Mbj26BillGroupDAO billGroupDao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        //Mbj26BillGroupVO billGroupCond = new Mbj26BillGroupVO();
        Mbj26BillGroupCondition billGroupCond = new Mbj26BillGroupCondition();
        List<Mbj26BillGroupVO> billGroupVoList = billGroupDao.selectVO(billGroupCond);
        result.setMbj26BillGroupVoList(billGroupVoList);

        //�Ԏ���ёւ��Ή� 2013/12/12 HLC H.Watabe update start
        //**********************************
        //�Ԏ�}�X�^�擾(�����t��)
        //**********************************
        //CarListDAO carDao = CarListDAOFactory.createCarListDAO();
        //CarListCondition carCond = new CarListCondition();
        //carCond.setSecType("1"); //1:CR�Ԏ팠��
        //carCond.setHamid(cond.getUserid());
        //List<CarListVO> carVoList = carDao.findCarList(carCond);
        //result.setCarListVoList(carVoList);

        //**********************************
        //�Ԏ�}�X�^�擾(�����t��)
        //**********************************
        FindCarSortedByNameDAO carDao =FindCarSortedByNameDAOFactory.createFindCarSortedByNameDAO();
        CarListCondition carCond = new CarListCondition();
        carCond.setSecType("1"); //1:CR�Ԏ팠��
        carCond.setHamid(cond.getUserid());
        List<CarListVO> carVoList = carDao.findCarList(carCond);
        result.setCarListVoList(carVoList);
        //�Ԏ���ёւ��Ή� 2013/12/12 HLC H.Watabe update end

        //**********************************
        //CR�\�Z���ރ}�X�^�擾
        //**********************************
        Mbj15CrClassDAO crClassDao = Mbj15CrClassDAOFactory.createMbj15CrClassDAO();
        Mbj15CrClassVO crClassCond = new Mbj15CrClassVO();
        List<Mbj15CrClassVO> crClassVoList = crClassDao.selectVO(crClassCond);
        result.setMbj15CrClassVoList(crClassVoList);

        //**********************************
        //CR�\�Z��ڃ}�X�^�擾
        //**********************************
        Mbj16CrExpenceDAO crExpenceDao = Mbj16CrExpenceDAOFactory.createMbj16CrExpenceDAO();
        Mbj16CrExpenceVO crExpenceCond = new Mbj16CrExpenceVO();
        List<Mbj16CrExpenceVO> crExpenceVoList = crExpenceDao.selectVO(crExpenceCond);
        result.setMbj16CrExpenceVoList(crExpenceVoList);

        //**********************************
        //�ݒ�ǃ}�X�^�擾
        //**********************************
        Mbj29SetteiKykDAO setteiKykDao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();
        //Mbj29SetteiKykVO setteiKykCond = new Mbj29SetteiKykVO();
        Mbj29SetteiKykCondition setteiKykCond = new Mbj29SetteiKykCondition();
        List<Mbj29SetteiKykVO> setteiKykVoList = setteiKykDao.selectVO(setteiKykCond);
        result.setMbj29SetteiKykVoList(setteiKykVoList);

        //**********************************
        //���͒S���}�X�^�擾
        //**********************************
        Mbj30InputTntDAO inputTntDao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        //Mbj30InputTntVO inputTntCond = new Mbj30InputTntVO();
        Mbj30InputTntCondition inputTntCond = new Mbj30InputTntCondition();
        List<Mbj30InputTntVO> inputTntVoList = inputTntDao.selectVO(inputTntCond);
        result.setMbj30InputTntVoList(inputTntVoList);

        //**********************************
        //��ʍ��ڕ\���񐧌�}�X�^�擾
        //**********************************
        Mbj37DisplayControlDAO displayControlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        //Mbj37DisplayControlVO displayControlCond = new Mbj37DisplayControlVO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> displayControlVoList = displayControlDao.selectVO(displayControlCond);
        result.setMbj37DisplayControlVoList(displayControlVoList);

        //**********************************
        //�ꗗ�\���p�^�[���擾
        //**********************************
        Tbj30DisplayPatternDAO displayPatternDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition displayPatternCond = new Tbj30DisplayPatternCondition();
        displayPatternCond.setHamid(cond.getUserid());
        displayPatternCond.setFormid(cond.getFormid());
        List<Tbj30DisplayPatternVO> displayPatternVoList = displayPatternDao.selectVO(displayPatternCond);
        result.setTbj30DisplayPatternVoList(displayPatternVoList);

        //**********************************
        //�R�[�h�}�X�^�擾
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
        //�@�\����Info�̎擾
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
        //�Z�L�����e�B���擾
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
        //�A���[�g�\������}�X�^�擾
        //**********************************
        Mbj41AlertDispControlDAO alertDao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();
        Mbj41AlertDispControlCondition alertCondition = new Mbj41AlertDispControlCondition();
        alertCondition.setSikognzuntcd(cond.getKksikognzuntcd());
        List<Mbj41AlertDispControlWithUserVO> alertVoList = alertDao.selectVOWithUserNm(alertCondition);
        result.setMbj41AlertDispControlVoList(alertVoList);

        return result;
    }

    /**
     * CR�����̌������̃f�[�^�擾�������s��
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
        //������擾
        //**********************************
        FindSeikyuDataCondition seikyuCond = new FindSeikyuDataCondition();
        seikyuCond.setBaseDate(cond.getEigyobi());
        seikyuCond.setEgsCd(cond.getEgsCd());
        List<SeikyuDataVO> seikyuDataVoList = seikyuDao.findSeikyuDataH(seikyuCond);
        result.setSeikyuDataVoList(seikyuDataVoList);

        //**********************************
        //�x����擾
        //**********************************
        FindPayDataCondition payCond = new FindPayDataCondition();
        payCond.setBaseDate(cond.getEigyobi());
        payCond.setEgsCd(cond.getEgsCd());
        List<PayDataVO> payDataVoList = payDao.findPayDataH(payCond);
        result.setPayDataVoList(payDataVoList);

        //****************************************
        //CR�Ԏ���擾
        //****************************************
        //�r�������p�̍ŏI�X�V�����擾
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
        //CR�����Ǘ��擾
        //****************************************
        //�r�������p�̍ŏI�X�V�����擾
        List<Tbj11CrCreateDataVO> tmpCrCreateDataVoList = dao.findMaxTimeStamp(cond);
        result.setMaxDateTimeForCrCreateData(tmpCrCreateDataVoList.get(0).getUPDDATE());

        List<Tbj11CrCreateDataVO> crCreateDataVoList = dao.selectListData(cond);
        result.setTbj11CrCreateDataVoList(crCreateDataVoList);

        return result;
    }

    /**
     * CR�����̓o�^���̔r���`�F�b�N�������s��
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForRegisterCrCreateData(RegisterCrCreateDataVO vo) throws HAMException {

        //****************************************
        //CR�Ԏ���̓o�^�^�X�V
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
                        //�X�V���悤�Ƃ��Ă���f�[�^���Ȃ���Δr���G���[
                        return false;
                    }
                    if (vo.getMaxDateTimeForCrCarInfo().before(tempVoList.get(0).getUPDDATE())) {
                        //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
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
                        //�o�^���悤�Ƃ��Ă���f�[�^�����ɑ��݂��Ă�����r���G���[
                        return false;
                    }
                }
            }
        }

        //****************************************
        //CR�����Ǘ��̓o�^�^�X�V�^�폜
        //****************************************
        if (vo.getMaxDateTimeForCrCreateData() != null) {
            if (vo.getFindCrCreateDataCondition() != null) {
                CostManagementDAO crCreateDataDao = CostManagementDAOFactory.createCostManagementDAO();
                List<Tbj11CrCreateDataVO> tempVoList = crCreateDataDao.selectListData(vo.getFindCrCreateDataCondition());
                //�擾�����f�[�^��Map�֊i�[���Ȃ���
                Map<String, Date> tempVoMap = new HashMap<String, Date>();
                for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : tempVoList) {
                    tempVoMap.put(getKeyForCrCreateData(tbj11CrCreateDataVO), tbj11CrCreateDataVO.getUPDDATE());
                }
                //�X�V�f�[�^
                if (vo.getTbj11CrCreateDataVoListUpd() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListUpd()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //�擾�����f�[�^�̒��ɍX�V���悤�Ƃ��Ă���f�[�^���Ȃ���Δr���G���[
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
                            return false;
                        }
                    }
                }
                //�폜�f�[�^
                if (vo.getTbj11CrCreateDataVoListDel() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListDel()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //�擾�����f�[�^�̒��ɍX�V���悤�Ƃ��Ă���f�[�^���Ȃ���Δr���G���[
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
                            return false;
                        }
                    }
                }
                //���~�f�[�^
                if (vo.getTbj11CrCreateDataVoListStp() != null) {
                    for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : vo.getTbj11CrCreateDataVoListStp()) {
                        if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                            //�擾�����f�[�^�̒��ɍX�V���悤�Ƃ��Ă���f�[�^���Ȃ���Δr���G���[
                            return false;
                        }
                        if (vo.getMaxDateTimeForCrCreateData().before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                            //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

//    /**
//     * VO�̒l����f�[�^����ӂɔ��ʂ���L�[�l���擾����(CR�Ԏ���)
//     * @param vo
//     * @return
//     */
//    private String getKeyForCrCarInfo(Tbj10CrCarInfoVO vo) {
//        SimpleDateFormat format = new SimpleDateFormat("yyyyMMddHHmmssSSS");
//        return vo.getDCARCD() + "|" + String.format("%1$03d", vo.getPHASE()) + "|" + format.format(vo.getCRDATE());
//    }

    /**
     * VO�̒l����f�[�^����ӂɔ��ʂ���L�[�l���擾����(CR�����Ǘ�)
     * @param vo
     * @return
     */
    private String getKeyForCrCreateData(Tbj11CrCreateDataVO vo) {
        NumberFormat nf = new DecimalFormat("0");
        nf.setMinimumIntegerDigits(10);
        return nf.format(vo.getSEQUENCENO());
    }

    /**
     * CR�����̓o�^���̃f�[�^�X�V�������s��
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
        //�r���`�F�b�N
        //****************************************
        if (!checkExclusionForRegisterCrCreateData(vo)) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        //****************************************
        //CR�Ԏ���̓o�^�^�X�V
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
        //CR�����Ǘ��̓o�^�^�X�V�^�폜
        //****************************************
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        //�폜�f�[�^������ꍇ�͍폜���������s
        if (vo.getTbj11CrCreateDataVoListDel() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListDel().size(); i++) {
                //�����̓o�^
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
//                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
//                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListDel().get(i).getDCARCD());
//                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListDel().get(i).getPHASE());
//                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListDel().get(i).getCRDATE());
//                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListDel().get(i).getSEQUENCENO());
//                logCrCreateDataVo.setRIREKINM("�폜");
//                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListDel().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListDel().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListDel().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListDel().get(i).getSEQUENCENO());
                costManageDao.deleteHistoryForCrCreate(logCrCreateDataVo);

                //CR�����Ǘ��̍폜
                crCreateDataDao.deleteVO(vo.getTbj11CrCreateDataVoListDel().get(i));
            }
        }
        //���~�f�[�^������ꍇ�͒��~(�X�V)���������s
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

                //CR�����Ǘ��̍X�V
                crCreateDataDao.updateVO(crCreateDataVo);

                //�����̓o�^
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
        //�X�V�f�[�^������ꍇ�͍X�V���������s
        if (vo.getTbj11CrCreateDataVoListUpd() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListUpd().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListUpd().get(i);

                //���͒S���̃R�[�h���ݒ肳��Ă��Ȃ��Ŗ��̂��ݒ肳��Ă���ꍇ�͐V�K���͒S���Ƃ��ă}�X�^�ւ̓o�^���s��
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

                //CR�����Ǘ��̍X�V
                crCreateDataDao.updateVO(crCreateDataVo);

                //�����̓o�^
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
        //�o�^�f�[�^������ꍇ�͓o�^���������s
        if (vo.getTbj11CrCreateDataVoListReg() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListReg().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListReg().get(i);

                //���͒S���̃R�[�h���ݒ肳��Ă��Ȃ��Ŗ��̂��ݒ肳��Ă���ꍇ�͐V�K���͒S���Ƃ��ă}�X�^�ւ̓o�^���s��
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

                //SEQNO�̎擾�E�ݒ�
                crCreateDataVo.setSEQUENCENO(GetSequenceNo(crCreateDataVo.getDCARCD(), crCreateDataVo.getPHASE(), crCreateDataVo.getCRDATE()));
                //CR�����Ǘ��ւ̓o�^���s
                crCreateDataDao.insertVO(crCreateDataVo);

                //�����̓o�^
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(vo.getTbj11CrCreateDataVoListReg().get(i).getDCARCD());
                logCrCreateDataVo.setPHASE(vo.getTbj11CrCreateDataVoListReg().get(i).getPHASE());
                logCrCreateDataVo.setCRDATE(vo.getTbj11CrCreateDataVoListReg().get(i).getCRDATE());
                logCrCreateDataVo.setSEQUENCENO(vo.getTbj11CrCreateDataVoListReg().get(i).getSEQUENCENO());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);

                //�o�^�����f�[�^�̐����Ǘ�No��ێ�.
                lstSeqNo.add(crCreateDataVo.getSEQUENCENO());
            }
        }
        //�\�[�g���̍X�V�Ώۃf�[�^������ꍇ�͍X�V���������s
        if (vo.getTbj11CrCreateDataVoListSort() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoListSort().size(); i++) {
                Tbj11CrCreateDataForUpdVO crCreateDataVo = vo.getTbj11CrCreateDataVoListSort().get(i);

                //CR�����Ǘ��̍X�V
                crCreateDataDao.updateSortNo(crCreateDataVo);
            }
        }

        //**********************************
        //�ԋp�p�����[�^�̎擾�E�ݒ�
        //**********************************
        //���͒S���}�X�^
        Mbj30InputTntDAO inputTntDao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        Mbj30InputTntCondition inputTntCond = new Mbj30InputTntCondition();
        List<Mbj30InputTntVO> inputTntVoList = inputTntDao.selectVO(inputTntCond);
        result.setMbj30InputTntVoList(inputTntVoList);

        //�o�^�����f�[�^�̃L�[���.
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
     * SortNo�̌��ő�l���擾����
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
     * SEQNo�̍̔Ԃ��s��
     *
     * @param dcar
     * @param phase
     * @param crDate
     * @return
     * @throws HAMException
     */
    private BigDecimal GetSequenceNo(String dcar, BigDecimal phase, Date crDate) throws HAMException {

        //�i��MAX�l+1�j
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        Tbj11CrCreateDataCondition crCreateDataCond = new Tbj11CrCreateDataCondition();
        //�����Ȃ�(�S����MAX�l���擾����)
        List<Tbj11CrCreateDataVO> maxSeqList = crCreateDataDao.findMaxSeqNo(crCreateDataCond);
        return maxSeqList.get(0).getSEQUENCENO().add(BigDecimal.ONE);
    }

    /**
     * CR�����ɓo�^������͒S�����V�K�̏ꍇ�A�}�X�^�ւ̓o�^���s��
     *
     * @param crCreateDataVo
     * @return �o�^�����f�[�^��SEQNO�̒l
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
     * CR�����Ǘ��e�[�u���ɑ΂��Ĕr���`�F�b�N���s��
     * @param voList CR�����f�[�^(PK�ɒl�̐ݒ肪�K�{)
     * @param compDate �X�V���̔�r���s���ۂ̊�ƂȂ����
     * @return
     * @throws HAMException
     */
    private boolean checkExclusionForCrCreateData(List<Tbj11CrCreateDataVO> voList, Date compDate) throws HAMException {
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        List<Tbj11CrCreateDataVO> lockData = crCreateDataDao.selectByPkWithLock(voList);
        //�擾�����f�[�^��Map�֊i�[���Ȃ���
        Map<String, Date> tempVoMap = new HashMap<String, Date>();
        for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : lockData) {
            tempVoMap.put(getKeyForCrCreateData(tbj11CrCreateDataVO), tbj11CrCreateDataVO.getUPDDATE());
        }
        for (Tbj11CrCreateDataVO tbj11CrCreateDataVO : voList) {
            if (!tempVoMap.containsKey(getKeyForCrCreateData(tbj11CrCreateDataVO))) {
                //�擾�����f�[�^�̒��ɍX�V���悤�Ƃ��Ă���f�[�^���Ȃ���Δr���G���[
                return false;
            }
            if (compDate.before(tempVoMap.get(getKeyForCrCreateData(tbj11CrCreateDataVO)))) {
                //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
                return false;
            }
        }

        return true;
    }

    /**
     * �f�[�^�ړ��^�R�s�[��ʂ̓o�^�������s��
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
        //�r���`�F�b�N
        //************************************
        //CR�����Ǘ��e�[�u��
        if (!checkExclusionForCrCreateData(vo.getTbj11CrCreateDataVoList(), vo.getMaxDateTimeForCrCreateData())) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        //************************************
        //�ړ��^�R�s�[��̃f�[�^��INSERT
        //************************************
        BigDecimal sortNo = null;
        for (int i = 0; i < vo.getTbj11CrCreateDataVoList().size(); i++) {
            Tbj11CrCreateDataVO condVo = vo.getTbj11CrCreateDataVoList().get(i);
            Tbj11CrCreateDataVO sakiDataVo = new Tbj11CrCreateDataVO();

            //�ڑ����f�[�^���擾����
            Tbj11CrCreateDataVO motoDataVo = crCreateDataDao.loadVO(condVo);
            if (vo.getExecKind() == 1) {
                //�R�s�[�̏ꍇ���f�[�^�̒l��S�Ĉڑ�
                sakiDataVo.getOriginalMember().putAll(motoDataVo.getOriginalMember());
            }
            //�ύX���e�Ɋ֌W�Ȃ��X�V���ڂ�ҏW------------------------
            sakiDataVo.setDCARCD(vo.getDCarCd());                               //�d�ʎԎ�R�[�h
            sakiDataVo.setPHASE(vo.getPhase());                                 //�t�F�C�Y
            sakiDataVo.setCRDATE(vo.getCrDate());                               //�N��
            if (vo.getExecKind() == 1) {
                //�R�s�[�̏ꍇSEQ���̔�
                sakiDataVo.setSEQUENCENO(GetSequenceNo(vo.getDCarCd(), vo.getPhase(), vo.getCrDate()));// SEQUENCENO
                //�R�s�[��͐V�K�o�^�f�[�^�Ƃ���
                sakiDataVo.setCRTNM(vo.getUsernm());                                //�o�^��
                sakiDataVo.setCRTID(vo.getUserid());                                //�o�^��ID
                sakiDataVo.setCRTAPL(vo.getFormid());                               //�쐬�v���O����
            }
            sakiDataVo.setCLASSDIV(vo.getClassDiv());                           //�f�[�^���
            if (sortNo == null) {
                sortNo = GetMaxSortNo(vo.getDCarCd(), vo.getPhase(), vo.getCrDate(), vo.getClassDiv()).add(BigDecimal.ONE);
            } else {
                sortNo = sortNo.add(BigDecimal.ONE);
            }
            sakiDataVo.setSORTNO(sortNo);                                       //�\�[�gNo
            sakiDataVo.setUPDNM(vo.getUsernm());                                //�X�V��
            sakiDataVo.setUPDAPL(vo.getFormid());                               //�X�VAPP
            sakiDataVo.setUPDID(vo.getUserid());                                //�X�V��ID

            //�ύX�O��̃f�[�^��ʂɂ���ĕҏW���e��ύX����----------
            if (motoDataVo.getCLASSDIV().equals(vo.getClassDiv())) {
                //�f�[�^��ʂ̕ύX���Ȃ��ꍇ
                sakiDataVo.setCLASSCD(ChangeClassCdByMove(motoDataVo, sakiDataVo)); //�\�Z�\����
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //�\�Z�\���
                if (!motoDataVo.getDCARCD().equals(vo.getDCarCd()) || !motoDataVo.getPHASE().equals(vo.getPhase())) {
                    //�Ԏ�or�t�F�C�Y���ύX�ɂȂ��Ă���ꍇ
                    sakiDataVo.setINPUTTNTCD(null);                                     //���͒S���҃R�[�h
                    sakiDataVo.setINPUTTNTCDFLG("0");                                   //���͒S���҃t���O
                }
            } else if (motoDataVo.getCLASSDIV().equals("0")) {
                //���쌴���\�������\�̏ꍇ
                sakiDataVo.setCLASSCD(""); //�\�Z�\����
                sakiDataVo.setCLASSCDFLG("0");                                      //�\�Z�\���ރt���O
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //�\�Z�\���
                sakiDataVo.setKIKANS(null);                                         //����From
                sakiDataVo.setKIKANSFLG("0");                                       //����From�t���O
                sakiDataVo.setKIKANE(null);                                         //����To
                sakiDataVo.setKIKANEFLG("0");                                       //����To�t���O
                sakiDataVo.setCONTRACTDATE(null);                                   //�_���
                sakiDataVo.setCONTRACTDATEFLG("0");                                 //�_����t���O
                sakiDataVo.setCONTRACTTERM("");                                     //�_�����
                sakiDataVo.setCONTRACTTERMFLG("0");                                 //�_����ԃt���O
                sakiDataVo.setSEIKYU("");                                           //������
                sakiDataVo.setSEIKYUFLG("0");                                       //������t���O
                sakiDataVo.setGETMONEY(BigDecimal.valueOf(0));                      //�����z
                sakiDataVo.setGETMONEYFLG("0");                                     //�����z�t���O
                sakiDataVo.setGETCONF("0");                                         //�����z�m�F
                sakiDataVo.setGETCONFIRMFLG("0");                                   //�����z�m�F�t���O
                sakiDataVo.setPAYMONEY(motoDataVo.getESTMONEY());                   //�������z
                sakiDataVo.setPAYMONEYFLG(motoDataVo.getESTMONEYFLG());             //�������z�t���O
                sakiDataVo.setPAYCONF("0");                                         //�������z�m�F
                sakiDataVo.setPAYCONFIRMFLG("0");                                   //�������z�m�F�t���O
                sakiDataVo.setESTMONEY(BigDecimal.valueOf(0));                      //���ϋ��z
                sakiDataVo.setESTMONEYFLG("0");                                     //���ϋ��z�t���O
                sakiDataVo.setCLMMONEY(BigDecimal.valueOf(0));                      //�������z
                sakiDataVo.setCLMMONEYFLG("0");                                     //�������z�t���O
                sakiDataVo.setINPUTTNTCD(null);                                     //���͒S���҃R�[�h
                sakiDataVo.setINPUTTNTCDFLG("0");                                   //���͒S���҃t���O
            } else if (motoDataVo.getCLASSDIV().equals("1")) {
                //�����\�����쌴���\�̏ꍇ
                sakiDataVo.setCLASSCD("0");                                         //�\�Z�\����
                sakiDataVo.setCLASSCDFLG("0");                                      //�\�Z�\���ރt���O
                sakiDataVo.setEXPCD(ChangeExpCdByMove(motoDataVo, sakiDataVo));     //�\�Z�\���
                sakiDataVo.setKIKANS(null);                                         //����From
                sakiDataVo.setKIKANSFLG("0");                                       //����From�t���O
                sakiDataVo.setKIKANE(null);                                         //����To
                sakiDataVo.setKIKANEFLG("0");                                       //����To�t���O
                sakiDataVo.setCONTRACTDATE(null);                                   //�_���
                sakiDataVo.setCONTRACTDATEFLG("0");                                 //�_����t���O
                sakiDataVo.setCONTRACTTERM("");                                     //�_�����
                sakiDataVo.setCONTRACTTERMFLG("0");                                 //�_����ԃt���O
                sakiDataVo.setSEIKYU("");                                           //������
                sakiDataVo.setSEIKYUFLG("0");                                       //������t���O
                sakiDataVo.setGETMONEY(BigDecimal.valueOf(0));                      //�����z
                sakiDataVo.setGETMONEYFLG("0");                                     //�����z�t���O
                sakiDataVo.setGETCONF("0");                                         //�����z�m�F
                sakiDataVo.setGETCONFIRMFLG("0");                                   //�����z�m�F�t���O
                sakiDataVo.setPAYMONEY(BigDecimal.valueOf(0));                      //�������z
                sakiDataVo.setPAYMONEYFLG("0");                                     //�������z�t���O
                sakiDataVo.setPAYCONF("0");                                         //�������z�m�F
                sakiDataVo.setPAYCONFIRMFLG("0");                                   //�������z�m�F�t���O
                sakiDataVo.setESTMONEY(motoDataVo.getPAYMONEY());                   //���ϋ��z
                sakiDataVo.setESTMONEYFLG(motoDataVo.getPAYMONEYFLG());             //���ϋ��z�t���O
                sakiDataVo.setCLMMONEY(BigDecimal.valueOf(0));                      //�������z
                sakiDataVo.setCLMMONEYFLG("0");                                     //�������z�t���O
                sakiDataVo.setINPUTTNTCD(null);                                     //���͒S���҃R�[�h
                sakiDataVo.setINPUTTNTCDFLG("0");                                   //���͒S���҃t���O
            }

            if (vo.getExecKind() == 0) {
                //�ړ��̏ꍇ�͈ړ������ړ����UPDATE
                Tbj11CrCreateDataCondition updCond = new Tbj11CrCreateDataCondition();
                updCond.setDcarcd(condVo.getDCARCD());                              //[�X�V����]�d�ʎԎ�R�[�h
                updCond.setPhase(condVo.getPHASE());                                //[�X�V����]�t�F�C�Y
                updCond.setCrdate(condVo.getCRDATE());                              //[�X�V����]�N��
                updCond.setSequenceno(condVo.getSEQUENCENO());                      //[�X�V����]SEQNO
                crCreateDataDao.updateVOByCond(sakiDataVo, updCond);

                //�����̓o�^
                CostManagementDAO costManageDao = CostManagementDAOFactory.createCostManagementDAO();
                Tbj27LogCrCreateDataVO logCrCreateDataVo = new Tbj27LogCrCreateDataVO();
                logCrCreateDataVo.setDCARCD(updCond.getDcarcd());
                logCrCreateDataVo.setPHASE(updCond.getPhase());
                logCrCreateDataVo.setCRDATE(updCond.getCrdate());
                logCrCreateDataVo.setSEQUENCENO(updCond.getSequenceno());
                logCrCreateDataVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DATAMOVE);
                costManageDao.insertHistoryForCrCreate(logCrCreateDataVo);
            } else if (vo.getExecKind() == 1) {
                //�R�s�[�̏ꍇ�̓R�s�[���INSERT
                crCreateDataDao.insertVO(sakiDataVo);

                //�����̓o�^
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
     * �\�Z�\���ނ��ړ�(�R�s�[)���̃R�[�h�����̃R�[�h�ɕϊ�����
     * @param motoDataVo
     * @param sakiDataVo
     * @return
     */
    private String ChangeClassCdByMove(Tbj11CrCreateDataVO motoDataVo, Tbj11CrCreateDataVO sakiDataVo) {
        //83���ȍ~��82���ȑO
        if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
            if (motoDataVo.getCLASSCD().equals("2")) {
                //"�z��O"�̏ꍇ�A"HM�s��"�ɒu������
                return "1";
            } else {
                //��L�ȊO�͂��̂܂܂��Z�b�g
                return motoDataVo.getCLASSCD();
            }
        } else if (sakiDataVo.getPHASE().intValue() >= 83 && motoDataVo.getPHASE().intValue() <= 82) {
            //82���ȑO��83���ȍ~
            return motoDataVo.getCLASSCD();
        } else {
            return motoDataVo.getCLASSCD();
        }
    }

    /**
     * �\�Z�\��ڂ��ړ�(�R�s�[)���̃R�[�h�����̃R�[�h�ɕϊ�����
     * @param motoDataVo
     * @param sakiDataVo
     * @return
     * @throws HAMException
     */
    private String ChangeExpCdByMove(Tbj11CrCreateDataVO motoDataVo, Tbj11CrCreateDataVO sakiDataVo) throws HAMException {

//        //����������������������������������������������������������������������������������
//        //�S�Ăׂ������ł���Ă���̂ŕϊ��}�X�^�������ŊǗ�����悤�ɕύX���邱�Ƃ�����
//        //�������Ȃ��Ɣ�ڂ��������邽�тɃR�[�h�̏C�����K�v�ɁE�E�E
//        //����������������������������������������������������������������������������������
//
//        if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //���쌴���\�ː��쌴���\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO
//                if (motoDataVo.getEXPCD().equals("30")) {return "01"; }          //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("31")) {return "02"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("32")) {return "03"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("33")) {return "04"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("34")) {return "05"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("35")) {return "06"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("36")) {return "07"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("37")) {return "08"; }     //�G������E�c�Z����          �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("38")) {return "09"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("39")) {return "10"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("40")) {return "11"; }     //�_��i���y�j                �ˌ_��i���y�E���āE�ڰ���j
//                else if (motoDataVo.getEXPCD().equals("41")) {return "11"; }     //�_��i���āj                �ˌ_��i���y�E���āE�ڰ���j
//                else if (motoDataVo.getEXPCD().equals("42")) {return "11"; }     //�_��i�ڰ���j               �ˌ_��i���y�E���āE�ڰ���j
//                else if (motoDataVo.getEXPCD().equals("67")) {return "11"; }     //�_��i���فj                �ˌ_��i���y�E���āE�ڰ���j
//                else if (motoDataVo.getEXPCD().equals("68")) {return "11"; }     //�_��i���̑��j              �ˌ_��i���y�E���āE�ڰ���j
//                else if (motoDataVo.getEXPCD().equals("43")) {return "12"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("44")) {return "13"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("45")) {return "14"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("46")) {return "15"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("47")) {return "15"; }     //������                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("63")) {return "15"; }     //�t�B�[                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("64")) {return "15"; }     //�^�c��                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("65")) {return "15"; }     //���f�B�A                    �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("66")) {return "15"; }     //Web�����                   �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("01")) {return "30"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("02")) {return "31"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("03")) {return "32"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("04")) {return "33"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("05")) {return "34"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("06")) {return "35"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("07")) {return "36"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("08")) {return "37"; }     //�G������E����              �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("09")) {return "38"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("10")) {return "39"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("11")) {return "40"; }     //�_��i���y�E���āE�ڰ���j   �ˌ_��i���y�j
//                else if (motoDataVo.getEXPCD().equals("12")) {return "43"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("13")) {return "44"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("14")) {return "45"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("15")) {return "46"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~
//                return motoDataVo.getEXPCD();
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO
//                return motoDataVo.getEXPCD();
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //���쌴���\�ː����\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO
//                if (motoDataVo.getEXPCD().equals("30")) {return "16"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("31")) {return "17"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("32")) {return "18"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("33")) {return "19"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("34")) {return "20"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("35")) {return "21"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("36")) {return "22"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("37")) {return "23"; }     //�G������E�c�Z����          �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("38")) {return "24"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("39")) {return "25"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("43")) {return "26"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("44")) {return "27"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("45")) {return "28"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("46")) {return "29"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("47")) {return "29"; }     //������                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("63")) {return "29"; }     //�t�B�[                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("64")) {return "29"; }     //�^�c��                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("01")) {return "48"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("02")) {return "49"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("03")) {return "50"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("04")) {return "51"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("05")) {return "52"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("06")) {return "53"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("07")) {return "54"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("08")) {return "55"; }     //�G������E����              �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("09")) {return "56"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("10")) {return "57"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("12")) {return "58"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("13")) {return "59"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("14")) {return "60"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("15")) {return "61"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("30")) {return "48"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("31")) {return "49"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("32")) {return "50"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("33")) {return "51"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("34")) {return "52"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("35")) {return "53"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("36")) {return "54"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("37")) {return "55"; }     //�G������E�c�Z����          �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("38")) {return "56"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("39")) {return "57"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("43")) {return "58"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("44")) {return "59"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("45")) {return "60"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("46")) {return "61"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("47")) {return "62"; }     //������                      �˒�����
//                else if (motoDataVo.getEXPCD().equals("63")) {return "69"; }     //�t�B�[                      �˃t�B�[
//                else if (motoDataVo.getEXPCD().equals("64")) {return "70"; }     //�^�c��                      �ˉ^�c��
//                else if (motoDataVo.getEXPCD().equals("65")) {return "71"; }     //���f�B�A                    �˃��f�B�A
//                else if (motoDataVo.getEXPCD().equals("66")) {return "72"; }     //Web�����                   ��Web�����
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO
//                if (motoDataVo.getEXPCD().equals("01")) {return "16"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("02")) {return "17"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("03")) {return "18"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("04")) {return "19"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("05")) {return "20"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("06")) {return "21"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("07")) {return "22"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("08")) {return "23"; }     //�G������E����              �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("09")) {return "24"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("10")) {return "25"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("12")) {return "26"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("13")) {return "27"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("14")) {return "28"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("15")) {return "29"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //�����\�ː��쌴���\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO
//                if (motoDataVo.getEXPCD().equals("48")) {return "01"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("49")) {return "02"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("50")) {return "03"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("51")) {return "04"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("52")) {return "05"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("53")) {return "06"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("54")) {return "07"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("55")) {return "08"; }     //�G������E�c�Z����          �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("56")) {return "09"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("57")) {return "10"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("58")) {return "12"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("59")) {return "13"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("60")) {return "14"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("61")) {return "15"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("62")) {return "15"; }     //������                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("69")) {return "15"; }     //�t�B�[                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("70")) {return "15"; }     //�^�c��                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("71")) {return "15"; }     //���f�B�A                    �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("72")) {return "15"; }     //Web�����                   �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("16")) {return "30"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("17")) {return "31"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("18")) {return "32"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("19")) {return "33"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("20")) {return "34"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("21")) {return "35"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("22")) {return "36"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("23")) {return "37"; }     //�G������E����              �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("24")) {return "38"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("25")) {return "39"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("26")) {return "43"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("27")) {return "44"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("28")) {return "45"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("29")) {return "46"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("48")) {return "30"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("49")) {return "31"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("50")) {return "32"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("51")) {return "33"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("52")) {return "34"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("53")) {return "35"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("54")) {return "36"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("55")) {return "37"; }     //�G������E�c�Z����          �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("56")) {return "38"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("57")) {return "39"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("58")) {return "43"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("59")) {return "44"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("60")) {return "45"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("61")) {return "46"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("62")) {return "47"; }     //������                      �˒�����
//                else if (motoDataVo.getEXPCD().equals("69")) {return "63"; }     //�t�B�[                      �˃t�B�[
//                else if (motoDataVo.getEXPCD().equals("70")) {return "64"; }     //�^�c��                      �ˉ^�c��
//                else if (motoDataVo.getEXPCD().equals("71")) {return "65"; }     //���f�B�A                    �˃��f�B�A
//                else if (motoDataVo.getEXPCD().equals("72")) {return "66"; }     //Web�����                   ��Web�����
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO
//                if (motoDataVo.getEXPCD().equals("16")) {return "01"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("17")) {return "02"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("18")) {return "03"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("19")) {return "04"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("20")) {return "05"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("21")) {return "06"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("22")) {return "07"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("23")) {return "08"; }     //�G������E����              �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("24")) {return "09"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("25")) {return "10"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("26")) {return "12"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("27")) {return "13"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("28")) {return "14"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("29")) {return "15"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//            }
//
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //�����\�ː����\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO
//                if (motoDataVo.getEXPCD().equals("48")) {return "16"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("49")) {return "17"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("50")) {return "18"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("51")) {return "19"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("52")) {return "20"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("53")) {return "21"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("54")) {return "22"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("55")) {return "23"; }     //�G������E�c�Z����          �ˎG������E����
//                else if (motoDataVo.getEXPCD().equals("56")) {return "24"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("57")) {return "25"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("58")) {return "26"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("59")) {return "27"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("60")) {return "28"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("61")) {return "29"; }     //���̑�                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("62")) {return "29"; }     //������                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("69")) {return "29"; }     //�t�B�[                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("70")) {return "29"; }     //�^�c��                      �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("71")) {return "29"; }     //���f�B�A                    �˂��̑�
//                else if (motoDataVo.getEXPCD().equals("72")) {return "29"; }     //Web�����                   �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~
//                if (motoDataVo.getEXPCD().equals("16")) {return "48"; }     //TV-CM����                   ��TV-CM����
//                else if (motoDataVo.getEXPCD().equals("17")) {return "49"; }     //�v�����g                    �˃v�����g
//                else if (motoDataVo.getEXPCD().equals("18")) {return "50"; }     //R-CM����                    ��R-CM����
//                else if (motoDataVo.getEXPCD().equals("19")) {return "51"; }     //JASRAC�����g�p��            ��JASRAC�����g�p��
//                else if (motoDataVo.getEXPCD().equals("20")) {return "52"; }     //GR�B�e                      ��GR�B�e
//                else if (motoDataVo.getEXPCD().equals("21")) {return "53"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("22")) {return "54"; }     //�V������                    �ːV������
//                else if (motoDataVo.getEXPCD().equals("23")) {return "55"; }     //�G������E����              �ˎG������E�c�Z����
//                else if (motoDataVo.getEXPCD().equals("24")) {return "56"; }     //OOH����E���ŁE���         ��OOH����E���ŁE���
//                else if (motoDataVo.getEXPCD().equals("25")) {return "57"; }     //�ԗ��A���E�ۊ�              �ˎԗ��A���E�ۊ�
//                else if (motoDataVo.getEXPCD().equals("26")) {return "58"; }     //WEB�o�i�[                   ��WEB�o�i�[
//                else if (motoDataVo.getEXPCD().equals("27")) {return "59"; }     //�C�x���g                    �˃C�x���g
//                else if (motoDataVo.getEXPCD().equals("28")) {return "60"; }     //�C���g����Ƒ�              �˃C���g����Ƒ�
//                else if (motoDataVo.getEXPCD().equals("29")) {return "61"; }     //���̑�                      �˂��̑�
//                else { throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175"); } //�z��O�̗\�Z�\���
//
//            } else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~
//                return motoDataVo.getEXPCD();
//            } else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO
//                return motoDataVo.getEXPCD();
//            }
//        }

//        if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //���쌴���\�ː��쌴���\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~�E�E�E���ϊ��͍s��Ȃ�
//                return motoDataVo.getEXPCD();
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO�E�E�E���ϊ��͍s��Ȃ�
//                return motoDataVo.getEXPCD();
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("0") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //���쌴���\�ː����\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("0")) {
//            //************************************
//            //�����\�ː��쌴���\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//        } else if (motoDataVo.getCLASSDIV().equals("1") && sakiDataVo.getCLASSDIV().equals("1")) {
//            //************************************
//            //�����\�ː����\
//            //************************************
//            if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //83���ȍ~��82���ȑO�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //82���ȑO��83���ȍ~�E�E�E���ϊ��}�X�^�Ŕ�ڕϊ���
//            }
//            else if (motoDataVo.getPHASE().intValue() >= 83 && sakiDataVo.getPHASE().intValue() >= 83) {
//                //83���ȍ~��83���ȍ~�E�E�E���ϊ��͍s��Ȃ�
//                return motoDataVo.getEXPCD();
//            }
//            else if (motoDataVo.getPHASE().intValue() <= 82 && sakiDataVo.getPHASE().intValue() <= 82) {
//                //82���ȑO��82���ȑO�E�E�E���ϊ��͍s��Ȃ�
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

        throw new HAMException("�\�Z�\��ڕϊ��G���[", "BJ-W0175");
    }

    /**
     * CR�����̊m�F�^�m�F������̔r���`�F�b�N�������s��
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForConfirmCrCreateData(ConfirmCrCreateDataVO vo) throws HAMException {

        //****************************************
        //CR�����Ǘ��̊m�F�^�m�F���
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
     * CR�����̊m�F�^�m�F������̃f�[�^�X�V�������s��
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public ConfirmCrCreateDataResult ConfirmCrCreateData(ConfirmCrCreateDataVO vo) throws HAMException {

        ConfirmCrCreateDataResult result = new ConfirmCrCreateDataResult();

        //****************************************
        //�r���`�F�b�N
        //****************************************
        if (!checkExclusionForCrCreateData(vo.getTbj11CrCreateDataVoList(), vo.getMaxDateTimeForCrCreateData())) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        //****************************************
        //CR�����Ǘ��̍X�V
        //****************************************
        Tbj11CrCreateDataDAO crCreateDataDao = Tbj11CrCreateDataDAOFactory.createTbj11CrCreateDataDAO();
        if (vo.getTbj11CrCreateDataVoList() != null) {
            for (int i = 0; i < vo.getTbj11CrCreateDataVoList().size(); i++) {
                Tbj11CrCreateDataVO crCreateDataVo = vo.getTbj11CrCreateDataVoList().get(i);

                //CR�����Ǘ��̍X�V
                //crCreateDataDao.updateVO(crCreateDataVo);
                Tbj11CrCreateDataCondition crCreateDataCond = new Tbj11CrCreateDataCondition();
                crCreateDataCond.setDcarcd(crCreateDataVo.getDCARCD());
                crCreateDataCond.setPhase(crCreateDataVo.getPHASE());
                crCreateDataCond.setCrdate(crCreateDataVo.getCRDATE());
                crCreateDataCond.setSequenceno(crCreateDataVo.getSEQUENCENO());
                crCreateDataDao.updateVOByCond(crCreateDataVo, crCreateDataCond);

                //�����̓o�^
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
     * �X�V�������(CR�����)�̕\���f�[�^���擾����
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
     * �Ԏ�ʗ\�Z�\�̃f�[�^���擾����
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
     * �Ԏ�ʗ\�Z�\(�ڍ�)�̃f�[�^���擾����
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBudgetDetailsResult findBudgetDetails(FindBudgetDetailsCondition cond) throws HAMException {

        FindBudgetDetailsResult result = new FindBudgetDetailsResult();

        //�ėp�R�����g�f�[�^�̎擾
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

        //�ŏI�X�V�ҁE�����̎擾
        BudgetDetailsDAO budgetDetailsDao = BudgetDetailsDAOFactory.createBudgetDetailsDAO();
        List<Tbj33CrBudgetUpdHisVO> crBudgetUpdHisVoList = budgetDetailsDao.findLastUpdInfoFromHistory(cond);

        if (crBudgetUpdHisVoList == null || crBudgetUpdHisVoList.size() == 0) {
            //��������擾�ł��Ȃ��ꍇ��CR�\�Z����̎擾���s��.
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

        //���сE�\�Z�f�[�^�̎擾(�ߋ����b�N�ȑO��CR��������уf�[�^�A�ߋ����b�N�����CR�\�Z����\�Z�f�[�^)
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
     * �Ԏ�ʗ\�Z�\(�ڍ�)�̓o�^�������s��
     * @param vo
     * @return
     * @throws HAMException
     */
    public RegisterBudgetResult registerBudget(RegisterBudgetVO vo) throws HAMException {
        RegisterBudgetResult result = new RegisterBudgetResult();

        if (vo.getTbj32CompurposeVo() != null) {
            Tbj32CompurposeDAO compurposeDao = Tbj32CompurposeDAOFactory.createTbj32CompurposeDAO();
            //�f�[�^�̗L���Ɋ֌W�Ȃ��폜.
            compurposeDao.deleteVO(vo.getTbj32CompurposeVo());
            //�o�^����.
            compurposeDao.insertVO(vo.getTbj32CompurposeVo());
        }

        //****************************************
        //�r���`�F�b�N
        //****************************************
        if (!checkExclusionForRegisterBudget(vo)) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        if (vo.getTbj31CrBudgetPlanVoList() != null) {
            Tbj31CrBudgetPlanDAO crBudgetPlanDao = Tbj31CrBudgetPlanDAOFactory.createTbj31CrBudgetPlanDAO();
            Tbj33CrBudgetUpdHisDAO crBudgetUpdHisDao = Tbj33CrBudgetUpdHisDAOFactory.createTbj33CrBudgetUpdHisDAO();

            String oldKey = "";
            String newKey = "";

            for (int i = 0; i < vo.getTbj31CrBudgetPlanVoList().size(); i++) {
                Tbj31CrBudgetPlanVO crBudgetPlanVo = vo.getTbj31CrBudgetPlanVoList().get(i);
                if (!crBudgetPlanDao.updateVO(crBudgetPlanVo)) {
                    //�X�V������Ȃ������ꍇ�͓o�^���������s
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
     * CR�����̓o�^���̔r���`�F�b�N�������s��
     *
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean checkExclusionForRegisterBudget(RegisterBudgetVO vo) throws HAMException {

        //==============================================================
        //�r���`�F�b�N�Ώۂ̃f�[�^����̃��X�g�ɂ܂Ƃ߂�
        //==============================================================
        List<Tbj31CrBudgetPlanVO> lst = new ArrayList<Tbj31CrBudgetPlanVO>();

        if (vo.getTbj31CrBudgetPlanVoList() != null) {
            lst.addAll(vo.getTbj31CrBudgetPlanVoList());
        }

        if (lst != null && lst.size() > 0) {
            //==============================================================
            //�r���`�F�b�N�Ώۂ̃f�[�^�̍ŐV�̏�Ԃ��擾����
            //==============================================================
            Tbj31CrBudgetPlanDAO crBudgetPlanDao = Tbj31CrBudgetPlanDAOFactory.createTbj31CrBudgetPlanDAO();
            List<Tbj31CrBudgetPlanVO> lockDatas = crBudgetPlanDao.selectByMultiPk(lst);

            if (vo.getMaxDateTime() == null && lockDatas.size() > 0) {
                //�ő�X�V���t���Ȃ�(=�o�^�ς݃f�[�^�Ȃ�)�ꍇ�Ƀf�[�^���擾�o���Ă���ꍇ�͂��̎��_�ŃG���[
                return false;
            }

            //==============================================================
            //�擾�����ŐV�f�[�^�ƌ������_�̏����r���Č���������ɍX�V����Ă��Ȃ����`�F�b�N
            //==============================================================
            //�擾�����f�[�^��Map�֊i�[���Ȃ���
            Map<String, Date> tempVoMap = new HashMap<String, Date>();
            for (Tbj31CrBudgetPlanVO lockData : lockDatas) {
                tempVoMap.put(getKeyForCrBudgetPlan(lockData), lockData.getUPDDATE());
            }
            for (Tbj31CrBudgetPlanVO tbj31CrBudgetPlan : lst) {
                if (!tempVoMap.containsKey(getKeyForCrBudgetPlan(tbj31CrBudgetPlan))) {
                    continue;
                }
                if (vo.getMaxDateTime().before(tempVoMap.get(getKeyForCrBudgetPlan(tbj31CrBudgetPlan)))) {
                    //�X�V���悤�Ƃ��Ă���f�[�^�̍X�V���t���������_�̍ő�X�V���t����̏ꍇ�͔r���G���[
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * VO�̒l����f�[�^����ӂɔ��ʂ���L�[�l���擾����(CR�\�Z)
     * @param vo
     * @return
     */
    private String getKeyForCrBudgetPlan(Tbj31CrBudgetPlanVO vo) {
        return vo.getDCARCD() + "|" + vo.getPHASE() + "|" + vo.getCRDATE() + "|" + vo.getCLASSCD() + "|" + vo.getEXPCD();
    }

    /**
     * �Ԏ�ʗ\�Z�\�����̃f�[�^���擾����
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
     * ���쌴���\�^�����\�ɏo�͂���f�[�^���擾����
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
     * ������ꗗ�̃f�[�^���擾����
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindSeikyuDataResult findSeikyuData(FindSeikyuDataCondition cond) throws HAMException {

        FindSeikyuDataResult result = new FindSeikyuDataResult();
        FindSeikyuDataDAO dao = FindSeikyuDataDAOFactory.createFindSeikyuDataDAO();

        //**********************************
        //������擾
        //**********************************
        List<SeikyuDataVO> seikyuDataVoList = dao.findSeikyuData(cond);
        result.setSeikyuDataVoList(seikyuDataVoList);

        return result;
    }

    /**
     * �x����ꗗ�̃f�[�^���擾����
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindPayDataResult findPayData(FindPayDataCondition cond) throws HAMException {

        FindPayDataResult result = new FindPayDataResult();
        FindPayDataDAO dao = FindPayDataDAOFactory.createFindPayDataDAO();

        //**********************************
        //�x����擾
        //**********************************
        List<PayDataVO> payDataVoList = dao.findPayData(cond);
        result.setPayDataVoList(payDataVoList);

        return result;
    }

    /**
     * �ύX���e�ʒm(CR�����)�̃f�[�^���擾����
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
     * �w�肵�����O���烁�[���A�h���X���擾���܂�
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
     * HAM�����}�X�^�Ƀf�[�^��ǉ�����
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
     * HAM�����}�X�^�Ƀf�[�^��ǉ�����
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
