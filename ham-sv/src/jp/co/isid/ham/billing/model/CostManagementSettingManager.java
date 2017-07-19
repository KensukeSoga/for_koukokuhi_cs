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
 * �����ݒ�f�[�^���Ǘ�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class CostManagementSettingManager {

    /** �V���O���g���C���X�^���X */
    private static CostManagementSettingManager _manager = new CostManagementSettingManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private CostManagementSettingManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static CostManagementSettingManager getInstance() {
        return _manager;
    }

    /**
     * �����ݒ��ʂ̕\���f�[�^���擾���܂�
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindCostManagementSettingResult findCostManagementSetting(FindCostManagementSettingCondition cond) throws HAMException {

        FindCostManagementSettingResult result = new FindCostManagementSettingResult();

        // �����O���[�v�}�X�^�擾
        Mbj26BillGroupDAO billGroupDao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        result.setBillGroup(billGroupDao.selectVO(new Mbj26BillGroupCondition()));

        // �����捞�f�[�^�擾
        FindCostManagementCaptureCondition findCMCaptureCond = new FindCostManagementCaptureCondition();
        findCMCaptureCond.setPhase(cond.getPhase());
        findCMCaptureCond.setYearMonth(cond.getYearMonth());
        findCMCaptureCond.setClassDiv("0");
        FindCostManagementCaptureDAO findCMCaptureDao = FindCostManagementSettingDAOFactory.createFindCMCaptureDao();
        result.setFindCMCapture(findCMCaptureDao.selectVO(findCMCaptureCond));

        // �����Ԏ�f�[�^�擾
        FindCostManagementCarCondition findCMCarCond = new FindCostManagementCarCondition();
        findCMCarCond.setPhase(cond.getPhase());
        findCMCarCond.setYearMonth(cond.getYearMonth());
        FindCostManagementCarDAO findCMCarDao = FindCostManagementSettingDAOFactory.createFindCMCarDao();
        result.setFindCMCar(findCMCarDao.selectVO(findCMCarCond));

        // �����Ԏ�o�͐ݒ�f�[�^�擾
        FindCostManagementCaroutctrlCondition findCMCaroutctrlCond = new FindCostManagementCaroutctrlCondition();
        findCMCaroutctrlCond.setReportCd(cond.getReportCd());
        findCMCaroutctrlCond.setPhase(cond.getPhase());
        findCMCaroutctrlCond.setYearMonth(cond.getYearMonth());
        FindCostManagementCaroutctrlDAO findCMCaroutctrlDao = FindCostManagementSettingDAOFactory.createFindCMCaroutctrlDao();
        result.setFindCMCaroutctrl(findCMCaroutctrlDao.selectVO(findCMCaroutctrlCond));

        // �����(�o�̓I�v�V�����ȊO)�f�[�^�擾
        FindCostManagementExceptOptCondition findCMExceptOptCond = new FindCostManagementExceptOptCondition();
        findCMExceptOptCond.setReportCd(cond.getReportCd());
        findCMExceptOptCond.setPhase(cond.getPhase());
        findCMExceptOptCond.setYearMonth(cond.getYearMonth());
        FindCostManagementExceptOptDAO findCMExceptOptDao = FindCostManagementSettingDAOFactory.createFindCMExceptOptDao();
        result.setFindCMExceptOpt(findCMExceptOptDao.selectVO(findCMExceptOptCond));

        // �ύX�m�F�f�[�^�擾
        FindAfterUptakeCheckCondition findAUCheckCond = new FindAfterUptakeCheckCondition();
        findAUCheckCond.setPhase(cond.getPhase());
        findAUCheckCond.setYearMonth(cond.getYearMonth());
        findAUCheckCond.setClassDiv("0");
        FindAfterUptakeCheckDAO findAUCheckDao = FindCostManagementSettingDAOFactory.createFindAfterUptakeCheckDao();
        result.setFindAUCheck(findAUCheckDao.findFindAfterUptakeCheck(findAUCheckCond));

        // �@�\����Info�̎擾
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // �Z�L�����e�BInfo�̎擾
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
     * �����ݒ��ʂ̕\���f�[�^��o�^���܂�
     * @param vo �o�^�f�[�^
     * @return �o�^����
     * @throws HAMException
     */
    public RegisterCostManagementSettingResult registerCostManagementSetting(RegisterCostManagementSettingVO vo) throws HAMException {

        RegisterCostManagementSettingResult result = new RegisterCostManagementSettingResult();

        // �����Ԏ�f�[�^�擾
        FindCostManagementCarCondition findCMCarCond = new FindCostManagementCarCondition();
        findCMCarCond.setPhase(vo.getPhase());
        findCMCarCond.setYearMonth(vo.getYearMonth());
        FindCostManagementCarDAO findCMCarDao = FindCostManagementSettingDAOFactory.createFindCMCarDao();
        List<FindCostManagementCarVO> carVoList = findCMCarDao.selectVO(findCMCarCond);

        // �����X�V�`�F�b�N
        if (!checkUpdate(vo, carVoList)) {
            throw new HAMException("�r���G���[", "BJ-E0005");
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
            // �����폜
            Tbj21SeisakuhiCondition seisakuhiCond = new Tbj21SeisakuhiCondition();
            seisakuhiCond.setPhase(BigDecimal.valueOf(vo.getPhase()));
            seisakuhiCond.setSeikyuym(dtYearMonth);
            seisakuhiDao.deleteSeisakuhi(seisakuhiCond);
        }

        // �����o�^
        for (Tbj21SeisakuhiVO seisakuhiVo : vo.getSeisakuhiVo()) {
            seisakuhiDao.insertVo(seisakuhiVo);
        }

        // �����捞���s��ꂽ�ꍇ
        if (vo.getSeisakuhiSsVo() != null && vo.getSeisakuhiSsVo().size() > 0) {
            // �����捞�폜
            Tbj22SeisakuhiSsDAO seisakuhiSsDao = Tbj22SeisakuhiSsDAOFactory.createTbj22SeisakuhiSsDAO();
            Tbj22SeisakuhiSsCondition seisakuhiSsCond = new Tbj22SeisakuhiSsCondition();
            seisakuhiSsCond.setPhase(BigDecimal.valueOf(vo.getPhase()));
            seisakuhiSsCond.setCrdate(dtYearMonth);
            seisakuhiSsDao.deleteSeisakuhiSs(seisakuhiSsCond);

            // �����捞�o�^
            for (Tbj22SeisakuhiSsVO seisakuhiSsVo : vo.getSeisakuhiSsVo()) {
                seisakuhiSsDao.insertVo(seisakuhiSsVo);
            }
        }

        return result;
    }

    /**
     * �����X�V�`�F�b�N
     * @param vo �o�^�f�[�^
     * @param carVoList �����Ԏ�f�[�^
     * @return true�F�`�F�b�NOK�Afalse�F�`�F�b�NNG
     */
    private boolean checkUpdate(RegisterCostManagementSettingVO vo, List<FindCostManagementCarVO> carVoList) {

        // �����`�F�b�N.
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

                // �ŏI�X�V�����`�F�b�N
                if (!vo.getLatestUpdDate().equals(carVoUpdDate)) {
                    return false;
                }

                // �ŏI�X�V��ID�`�F�b�N
                if (!vo.getLatestUpdId().equals(carVoUpdId)) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * CR�����Ǘ�(�����ݒ�p)���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindCrCreateDataForCmsResult findCrCreateDataForCms(FindCrCreateDataForCmsCondition cond) throws HAMException {

        FindCrCreateDataForCmsResult result = new FindCrCreateDataForCmsResult();

        // CR�����Ǘ�(�����ݒ�p)�f�[�^�擾
        Tbj11CrCreateDataCondition crCond = new Tbj11CrCreateDataCondition();
        crCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
        crCond.setCrdate(cond.getYearMonth());
        FindCrCreateDataForCmsDAO crDao = FindCrCreateDataForCmsDAOFactory.createFindCrCreateDataForCmsDAO();
        result.setCrCreateData(crDao.selectVO(crCond));

        return result;
    }

    /**
     * ���쐿���\�o�̓f�[�^���݃`�F�b�N�����܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    public void checkBillProductionOutput(CheckBillProductionOutputCondition cond) throws HAMException {

        // ���쐿���\�o�̓f�[�^���݃`�F�b�N�i�\��A�����̋��ʃ`�F�b�N�j
        CheckBillProductionOutputDAO cbpoDao = CheckBillProductionOutputDAOFactory.createCheckBillProductionOutputDAO();
        cbpoDao.selectVO(cond);

        // ���쐿���\�o�̓f�[�^���݃`�F�b�N�i�����̃`�F�b�N�j
        if (cond.getOutputFlg().equals("seikyu")) {
            CheckBillProductionOutputSeikyuDAO cbpoDao2 = CheckBillProductionOutputSeikyuDAOFactory.createCheckBillProductionOutputSeikyuDAO();
            cbpoDao2.selectVO(cond);
        }
    }

    /**
     * ���쐿���\�擾�����܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindBillProductionOutputResult findBillProductionOutput(CheckBillProductionOutputCondition cond) throws HAMException {

        FindBillProductionOutputResult result = new FindBillProductionOutputResult();

        // ���쐿���\�擾DAO
        FindBillProductionOutputDAO dao = FindBillProductionOutputDAOFactory.createFindBillProductionOutputDAO();
        result.setFindBillProductionOutput(dao.selectVO(cond));

        return result;
    }
}
