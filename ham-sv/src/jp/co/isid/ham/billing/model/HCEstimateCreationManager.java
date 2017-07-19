package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonDAO;
import jp.co.isid.ham.common.model.Mbj06HcBumonDAOFactory;
import jp.co.isid.ham.common.model.Mbj07HcUserCondition;
import jp.co.isid.ham.common.model.Mbj07HcUserDAO;
import jp.co.isid.ham.common.model.Mbj07HcUserDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceDAO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceDAOFactory;
import jp.co.isid.ham.common.model.Mbj16CrExpenceVO;
import jp.co.isid.ham.common.model.Mbj21CalendarCondition;
import jp.co.isid.ham.common.model.Mbj21CalendarDAO;
import jp.co.isid.ham.common.model.Mbj21CalendarDAOFactory;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj48HmUserCondition;
import jp.co.isid.ham.common.model.Mbj48HmUserDAO;
import jp.co.isid.ham.common.model.Mbj48HmUserDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj05EstimateItemCondition;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAO;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAOFactory;
import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateCondition;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateDAO;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateDAOFactory;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * HC���ύ쐬�f�[�^���Ǘ�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/13 T.Fujiyoshi)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/02/02 HLC K.Soga)<BR>
 * �E�����Ɩ��ύX�s��Ή�(2016/03/16 HLC K.Soga)<BR>
 * �EHDX�Ή�(2016/04/20 HLC K.Soga)<BR>
 * @author T.Fujiyoshi
 */
public class HCEstimateCreationManager {

    /** �V���O���g���C���X�^���X */
    private static HCEstimateCreationManager _manager = new HCEstimateCreationManager();

    /** �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂� */
    private HCEstimateCreationManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static HCEstimateCreationManager getInstance() {
        return _manager;
    }

    /**
     * HC���ύ쐬����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindHCEstimateCreationResult findHCEstimateCreation(FindHCEstimateCreationCondition cond) throws HAMException {

        FindHCEstimateCreationResult result = new FindHCEstimateCreationResult();

        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // �R�[�h�}�X�^�擾
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        List<Mbj12CodeVO> codeVoList = new ArrayList<Mbj12CodeVO>();
        for (String codeType : cond.getCodeType()) {
           Mbj12CodeCondition codecond = new Mbj12CodeCondition();
           codecond.setCodetype(codeType);
           codeVoList.addAll(codedao.selectVO(codecond));
        }
        result.setCode(codeVoList);

        // ����}�X�^�擾
        Mbj06HcBumonDAO bumondao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();
        Mbj06HcBumonCondition bumoncond = new Mbj06HcBumonCondition();
        result.setBumon(bumondao.selectVO(bumoncond));

        // �J�����_�[�}�X�^�擾(����)
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        List<Mbj21CalendarVO> mbj21VoList = new ArrayList<Mbj21CalendarVO>();
        Mbj21CalendarCondition calendarcond = new Mbj21CalendarCondition();
        calendarcond.setDatakbn("01");
        calendarcond.setCalendarym(cond.getYearMonth().replaceAll("/", ""));
        /** 2016/03/15 �����Ɩ��ύX�s��Ή� HLC K.Soga MOD Start */
        //result.setCalendar(calendarDao.selectVO(calendarcond));
        mbj21VoList.addAll(calendarDao.selectVO(calendarcond));

        // �J�����_�[�}�X�^�擾(�O��)
        calendarcond.setCalendarym(cond.getPrevYearMonth());
        mbj21VoList.addAll(calendarDao.selectVO(calendarcond));
        result.setCalendar(mbj21VoList);
        /** 2016/03/15 �����Ɩ��ύX�s��Ή� HLC K.Soga MOD End */

        if (cond.getGroupCd() != null) {
            // �����O���[�v�}�X�^�擾
            Mbj26BillGroupDAO groupdao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
            Mbj26BillGroupCondition groupcond = new Mbj26BillGroupCondition();
            groupcond.setGroupcd(cond.getGroupCd());
            result.setGroup(groupdao.selectVO(groupcond));
        }

        // HC���[�U�}�X�^�擾
        Mbj07HcUserDAO userdao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();
        Mbj07HcUserCondition usercond = new Mbj07HcUserCondition();
        result.setUser(userdao.selectVO(usercond));

        if (cond.getEstSeqNo() != null && !cond.getEstSeqNo().equals(BigDecimal.valueOf(0))) {
            // ���ψČ��擾
            FindHCEstimateListItemDAO itemDao = FindHCEstimateCreationDAOFactory.createFindHCEstimateListItemDao();
            FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
            costItemCond.setPhase(cond.getPhase());
            costItemCond.setYearMonth(cond.getYearMonth());
            costItemCond.setEstimateClass(cond.getEstimateClass());
            costItemCond.setEstSeqNo(cond.getEstSeqNo());
            costItemCond.setCodeType("07");
            costItemCond.setHamId(cond.getHamId());
            result.setItem(itemDao.selectVO(costItemCond));

            if (cond.getEstimateClass().equals("0")) {
                // �ύX�m�F�f�[�^�擾
                FindHCEstimateListDiffDAO diffDao = new FindHCEstimateListDiffDAO();
                FindHCEstimateListDiffCondition diffCostCond = new FindHCEstimateListDiffCondition();
                List<BigDecimal> estSeqNoCost = new ArrayList<BigDecimal>();
                for (FindHCEstimateListItemVO itemVo : result.getItem()) {
                    estSeqNoCost.add(itemVo.getESTSEQNO());
                }
                diffCostCond.setEstSeqNoList(estSeqNoCost);
                diffCostCond.setPhase(cond.getPhase());
                diffCostCond.setYearMonth(cond.getYearMonth());
                result.setCostDiffVoList(diffDao.selectVO(diffCostCond));
            }
            else {
                // �ύX�m�F�f�[�^(�����)�擾
                FindHCEstimateListDiffTotalDAO diffTotalDao = new FindHCEstimateListDiffTotalDAO();
                FindHCEstimateListDiffTotalCondition diffTotalCond = new FindHCEstimateListDiffTotalCondition();
                List<BigDecimal> estSeqNoTotal = new ArrayList<BigDecimal>();
                for (FindHCEstimateListItemVO itemVo : result.getItem()) {
                    estSeqNoTotal.add(itemVo.getESTSEQNO());
                }
                diffTotalCond.setEstSeqNoList(estSeqNoTotal);
                diffTotalCond.setPhase(cond.getPhase());
                diffTotalCond.setYearMonth(cond.getYearMonth());
                result.setTotalDiffVoList(diffTotalDao.selectVO(diffTotalCond));
            }

            // ���ϖ��׃f�[�^�擾
            FindEstimateDetailDAO detailDao = FindHCEstimateCreationDAOFactory.createFindEstimateDetailDao();
            FindEstimateDetailCondition detailCond = new FindEstimateDetailCondition();
            detailCond.setPhase(cond.getPhase());
            detailCond.setYearMonth(cond.getYearMonth());
            detailCond.setEstSeqNo(cond.getEstSeqNo());
            if (result.getItem().size() > 0) {
                detailCond.setHcBumonCd(result.getItem().get(0).getHCBUMONCD());
            }
            result.setEstDetail(detailDao.selectVO(detailCond));

            // ���ϖ��׃f�[�^���擾�ł����ꍇ
            if (result.getEstDetail().size() > 0) {
                List<BigDecimal> estDetailSeqNo = new ArrayList<BigDecimal>();
                List<String> productCd = new ArrayList<String>();
                for (FindEstimateDetailVO detailVo : result.getEstDetail()) {
                    estDetailSeqNo.add(detailVo.getESTDETAILSEQNO());

                    if (detailVo.getPRODUCTCD() != null && !detailVo.getPRODUCTCD().equals("")) {
                        productCd.add(detailVo.getPRODUCTCD());
                    }
                }

                // ���ψČ�CR�����f�[�^�擾
                FindEstimateCreateDAO createDao = FindHCEstimateCreationDAOFactory.createFindEstimateCreateDao();
                FindEstimateCreateCondition createCond = new FindEstimateCreateCondition();
                createCond.setEstDetailSeqNo(estDetailSeqNo);
                result.setEstCreate(createDao.selectVO(createCond));

                // HC���i�}�X�^�擾
                if (productCd.size() > 0) {
                    FindHCProductDAO productDao = FindHCEstimateCreationDAOFactory.createFindHCProductDao();
                    FindHCProductCondition productCond = new FindHCProductCondition();
                    List<String> hcbumon = new LinkedList<String>();
                    hcbumon.add(result.getItem().get(0).getHCBUMONCD());
                    productCond.setHCBumonCd(hcbumon);
                    productCond.setProductCd(productCd);
                    result.setProduct(productDao.selectVO(productCond));
                }
            }
        }

        if (cond.getEstimateClass().equals("0")) {
            // ���ώ�ʂ����쌴���\�x�[�X�̏ꍇ�AHC���ύ쐬(�����捞)�擾
            FindHCEstimateCreationCaptureDAO captureDao = FindHCEstimateCreationDAOFactory.createFindHCEstimateCreationCaptureDao();
            FindHCEstimateCreationCaptureCondition captureCond = new FindHCEstimateCreationCaptureCondition();
            captureCond.setPhase(cond.getPhase());
            captureCond.setYearMonth(cond.getYearMonth());
            captureCond.setDCarCd(cond.getDCarCd());
            captureCond.setDivCd(cond.getDivCd());
            captureCond.setGroupCd(cond.getGroupCd());
            captureCond.setClassDiv("0");
            result.setCapture(captureDao.selectVO(captureCond));

            // CR�\�Z��ڃ}�X�^�擾
            Mbj16CrExpenceDAO crExpenceDao = Mbj16CrExpenceDAOFactory.createMbj16CrExpenceDAO();
            result.setCrExpence(crExpenceDao.selectVO(new Mbj16CrExpenceVO()));
        }
        else {
            // ���ώ�ʂ�CR�����̏ꍇ�ACR�����Ǘ��擾
            FindHCEstimateCreationCrDAO crCreateDataDao = FindHCEstimateCreationDAOFactory.createFindCrCreateDataDao();
            FindHCEstimateCreationCrCondition crCreateDataCond = new FindHCEstimateCreationCrCondition();
            crCreateDataCond.setPhase(cond.getPhase());
            crCreateDataCond.setYearMonth(cond.getYearMonth());
            crCreateDataCond.setDCarCd(cond.getDCarCd());
            crCreateDataCond.setDivCd(cond.getDivCd());
            crCreateDataCond.setGroupCd(cond.getGroupCd());
            crCreateDataCond.setClassDiv("1");
            result.setCrCreateData(crCreateDataDao.selectVO(crCreateDataCond));
        }

        // �S�ЃR�[�h�}�X�^�擾
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));

        // �ꗗ�\���p�^�[���擾
        Tbj30DisplayPatternDAO dpdao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition dpcond = new Tbj30DisplayPatternCondition();
        dpcond.setHamid(cond.getHamId());
        dpcond.setFormid(cond.getFormId());
        dpcond.setViewid(cond.getViewID());
        result.setDisplayPattern(dpdao.selectVO(dpcond));

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
     * HC���ύ쐬�o�^
     * @param vo �o�^�f�[�^
     * @return �o�^����
     * @throws HAMException
     */
    public RegisterHCEstimateCreationResult registerHCEstimateCreation(RegisterHCEstimateCreationVO vo) throws HAMException {

        RegisterHCEstimateCreationResult result = new RegisterHCEstimateCreationResult();

        List<Tbj05EstimateItemVO> updItemVo = vo.getUpdEstimateListItem();
        List<Tbj05EstimateItemVO> insItemVo = vo.getInsEstimateListItem();
        Tbj05EstimateItemDAO tbj05Dao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
        FindHCEstimateListItemDAO itemDao = FindHCEstimateCreationDAOFactory.createFindHCEstimateListItemDao();
        FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
        BigDecimal insEstSeqNo = BigDecimal.valueOf(0);

        if (updItemVo != null && updItemVo.size() > 0) {
            // ���ψČ��擾
            costItemCond.setPhase(vo.getPhase());
            costItemCond.setYearMonth(vo.getYearMonth());
            costItemCond.setEstimateClass(vo.getEstimateClass());
            costItemCond.setEstSeqNo(updItemVo.get(0).getESTSEQNO());
            costItemCond.setCodeType("07");
            costItemCond.setHamId(vo.getHamId());
            List<FindHCEstimateListItemVO> itemVo = itemDao.selectVO(costItemCond);

            // �r���`�F�b�N
            if (!checkUpdate(vo, itemVo))
            {
                throw new HAMException("�r���G���[", "BJ-E0005");
            }

            /** 2015/10/05 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
            //�������׏��o�͓����A�������o�͓����A�����f�[�^�o�͓������擾
            Tbj05EstimateItemCondition tbj05Cond = new Tbj05EstimateItemCondition();
            tbj05Cond.setPhase(updItemVo.get(0).getPHASE());
            tbj05Cond.setCrdate(updItemVo.get(0).getCRDATE());
            tbj05Cond.setEstseqno(updItemVo.get(0).getESTSEQNO());
            List<Tbj05EstimateItemVO> findItemVoList = tbj05Dao.selectVO(tbj05Cond);

            if (updItemVo.get(0).getLASTOUTPUTDATE() == null) {
                updItemVo.get(0).setLASTOUTPUTDATE(findItemVoList.get(0).getLASTOUTPUTDATE());
                updItemVo.get(0).setLASTOUTPUTNM(findItemVoList.get(0).getLASTOUTPUTNM());
                updItemVo.get(0).setOUTPUTFILENM(findItemVoList.get(0).getOUTPUTFILENM());
            }
            updItemVo.get(0).setBILLDTLLASTOUTPUTDATE(findItemVoList.get(0).getBILLDTLLASTOUTPUTDATE());
            updItemVo.get(0).setBILLLASTOUTPUTDATE(findItemVoList.get(0).getBILLLASTOUTPUTDATE());
            updItemVo.get(0).setBILLEXLLASTOUTPUTDATE(findItemVoList.get(0).getBILLEXLLASTOUTPUTDATE());
            /** 2015/10/05 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

            // ���ψČ��X�V
            tbj05Dao.updateVO(updItemVo.get(0));
        } else if (insItemVo != null && insItemVo.size() > 0) {
            if (insItemVo.get(0).getESTSEQNO().compareTo(BigDecimal.valueOf(0)) > 0) {
                // �󂯎�������ψČ��Ǘ�NO��ێ�
                insEstSeqNo = insItemVo.get(0).getESTSEQNO();
            } else {
                // ���ψČ��Ǘ�NO�擾
                costItemCond.setPhase(vo.getPhase());
                costItemCond.setYearMonth(vo.getYearMonth());
                List<FindHCEstimateListItemVO> itemVo = itemDao.getEstSeqNo(costItemCond);

                // �t�Ԃ������ψČ��Ǘ�NO��ێ�
                insEstSeqNo = itemVo.get(0).getESTSEQNO();

                // ���ψČ��V�K�o�^
                Tbj05EstimateItemVO tbj05Vo = vo.getInsEstimateListItem().get(0);
                tbj05Vo.setESTSEQNO(insEstSeqNo);
                tbj05Dao.insertVO(tbj05Vo);
            }
        }

        // �N���̌^�ϊ�.
        Date dtYearMonth = null;
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM");
        try {
            dtYearMonth = sdf.parse(vo.getYearMonth());
        } catch (ParseException e) {
            new HAMException(e.getMessage(), "BJ-E0002");
        }

        Tbj06EstimateDetailDAO tbj06Dao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
        Tbj06EstimateDetailCondition tbj06Cond = new Tbj06EstimateDetailCondition();
        Tbj07EstimateCreateDAO tbj07Dao = Tbj07EstimateCreateDAOFactory.createTbj07EstimateCreateDAO();
        Tbj07EstimateCreateCondition tbj07Cond = new Tbj07EstimateCreateCondition();
        List<BigDecimal> delEstDetailSeqNo = vo.getDelEstimateDetail();
        if (delEstDetailSeqNo != null && delEstDetailSeqNo.size() > 0) {
            for (BigDecimal estDetailSeqNo : delEstDetailSeqNo) {
                // ���ϖ��׍폜
                tbj06Cond.setEstdetailseqno(estDetailSeqNo);
                tbj06Dao.deleteEstimateDetail(tbj06Cond);

                // ���ψČ�CR�����폜
                tbj07Cond.setEstdetailseqno(estDetailSeqNo);
                tbj07Dao.deleteEstimateCreate(tbj07Cond);
            }
        }

        if (vo.getInsEstimateDetail() != null && vo.getInsEstimateDetail().size() > 0) {
            for (Tbj06EstimateDetailVO tbj06Vo : vo.getInsEstimateDetail()) {
                // ���ϖ��אV�K�o�^
                FindEstimateDetailDAO detailDao = FindHCEstimateCreationDAOFactory.createFindEstimateDetailDao();
                List<FindEstimateDetailVO> detailVo = detailDao.getEstDetailSeqNo();
                tbj06Vo.setESTDETAILSEQNO(detailVo.get(0).getESTDETAILSEQNO());
                if (!insEstSeqNo.equals(BigDecimal.valueOf(0)))
                {
                    tbj06Vo.setESTSEQNO(insEstSeqNo);
                }
                tbj06Dao.insertVO(tbj06Vo);

                // �֘A���鐧���Ǘ�NO���ݒ肳��Ă���ꍇ
                if (vo.getRelationSeqNo() != null && vo.getRelationSeqNo().size() > 0) {
                    // ���ψČ�CR�������쐬
                    for (RelationSeqNoVO relationVo : vo.getRelationSeqNo()) {
                        if (relationVo.getSortNo().equals(tbj06Vo.getSORTNO())) {
                            relationVo.setEstimateDetail(detailVo.get(0).getESTDETAILSEQNO());
                            insEstimateCreate(vo, relationVo, dtYearMonth);
                            break;
                        }
                    }
                }
            }
        }

        if (vo.getUpdEstimateDetail() != null && vo.getUpdEstimateDetail().size() > 0) {
            for (Tbj06EstimateDetailVO tbj06Vo : vo.getUpdEstimateDetail()) {
                /* 2015/09/14 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
                //������O���[�v���擾
                Tbj06EstimateDetailCondition tbj06BillSeqCond = new Tbj06EstimateDetailCondition();
                tbj06BillSeqCond.setEstdetailseqno(tbj06Vo.getESTDETAILSEQNO());
                List<Tbj06EstimateDetailVO> tbj06BillSeqVoList = tbj06Dao.selectVO(tbj06BillSeqCond);

                //�X�VVO�ɐ�����O���[�v���Z�b�g
                tbj06Vo.setHCBUMONCDBILL(tbj06BillSeqVoList.get(0).getHCBUMONCDBILL());
                tbj06Vo.setHCBUMONCDBILLSEQNO(tbj06BillSeqVoList.get(0).getHCBUMONCDBILLSEQNO());
                /* 2015/09/14 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

                // ���ϖ��׍X�V
                tbj06Dao.updateVO(tbj06Vo);

                // ���ψČ�CR�����폜
                tbj07Cond.setEstdetailseqno(tbj06Vo.getESTDETAILSEQNO());
                tbj07Dao.deleteEstimateCreate(tbj07Cond);

                // �֘A���鐧���Ǘ�NO���ݒ肳��Ă���ꍇ
                if (vo.getRelationSeqNo() != null && vo.getRelationSeqNo().size() > 0) {
                    // ���ψČ�CR�������쐬
                    for (RelationSeqNoVO relationVo : vo.getRelationSeqNo()) {
                        if (relationVo.getEstimateDetail().equals(tbj06Vo.getESTDETAILSEQNO())) {
                            insEstimateCreate(vo, relationVo, dtYearMonth);
                            break;
                        }
                    }
                }
            }
        }

        // �ǉ��p���ψČ�NO��ݒ�
        result.setEstSeqNo(insEstSeqNo);

        return result;
    }

    /**
     * ���ψČ�CR�������쐬����
     * @param vo �o�^�f�[�^
     * @param relationVo �֘A���鐧���Ǘ�NO
     * @param dtYearMonth Date�^�̔N��
     * @throws HAMException
     */
    private void insEstimateCreate(RegisterHCEstimateCreationVO vo, RelationSeqNoVO relationVo, Date dtYearMonth) throws HAMException {

        // ���ψČ�CR�����o�^
        for (BigDecimal seqNo : relationVo.getSeqNoList()) {
            Tbj07EstimateCreateCondition tbj07CostCond = new Tbj07EstimateCreateCondition();
            tbj07CostCond.setPhase(vo.getPhase());
            tbj07CostCond.setDcarcd(vo.getDCarCd());
            tbj07CostCond.setCrdate(dtYearMonth);
            tbj07CostCond.setSequenceno(seqNo);
            tbj07CostCond.setEstdetailseqno(relationVo.getEstimateDetail());

            if (vo.getEstimateClass().equals("0")) {
                Tbj07EstimateCreateCostDAO costDao =  RegisterHCEstimateCreationDAOFactory.createTbj07EstimateCreateCostDao();
                costDao.insertEstimateCreate(tbj07CostCond);
            }
            else {
                Tbj07EstimateCreateCrDAO crDao =  RegisterHCEstimateCreationDAOFactory.createTbj07EstimateCreateCrDao();
                crDao.insertEstimateCreate(tbj07CostCond);
            }
        }
    }

    /**
     * �����X�V�`�F�b�N
     * @param vo �o�^�f�[�^
     * @param carVoList �����Ԏ�f�[�^
     * @return true�F�`�F�b�NOK�Afalse�F�`�F�b�NNG
     */
    private boolean checkUpdate(RegisterHCEstimateCreationVO vo, List<FindHCEstimateListItemVO> itemVo) {

        // �����`�F�b�N.
        if (vo.getDataCount() != itemVo.size()) {
            return false;
        }

        // �ŏI�X�V�����`�F�b�N
        if (!vo.getLatestUpdDate().equals(itemVo.get(0).getUPDDATE())) {
            return false;
        }

        // �ŏI�X�V��ID�`�F�b�N
        if (!vo.getLatestUpdId().equals(itemVo.get(0).getUPDID())) {
            return false;
        }

        return true;
    }

    /**
     * ���Ϗ��A����CSV�t�@�C���쐬����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindEstimateReportResult findEstimateReport(FindEstimateReportCondition cond) throws HAMException {

        FindEstimateReportResult result = new FindEstimateReportResult();

        // ���ψČ��擾
        FindHCEstimateListItemDAO itemDao = FindHCEstimateCreationDAOFactory.createFindHCEstimateListItemDao();
        FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
        costItemCond.setPhase(cond.getPhase());
        costItemCond.setYearMonth(cond.getYearMonth());
        costItemCond.setEstimateClass(cond.getEstimateClass());
        costItemCond.setEstSeqNo(cond.getEstSeqNo());
        costItemCond.setCodeType("07");
        costItemCond.setHamId(cond.getHamId());
        result.setItem(itemDao.selectVO(costItemCond));

        // ���ϖ��׃f�[�^�擾
        FindEstimateDetailDAO detailDao = FindHCEstimateCreationDAOFactory.createFindEstimateDetailDao();
        FindEstimateDetailCondition detailCond = new FindEstimateDetailCondition();
        detailCond.setPhase(cond.getPhase());
        detailCond.setYearMonth(cond.getYearMonth());
        detailCond.setEstSeqNo(cond.getEstSeqNo());
        if (result.getItem().size() > 0) {
            detailCond.setHcBumonCd(result.getItem().get(0).getHCBUMONCD());
        }
        result.setEstDetail(detailDao.selectVO(detailCond));

        // ���ϖ��׃f�[�^���擾�ł����ꍇ
        if (result.getEstDetail().size() > 0) {
            List<BigDecimal> estDetailSeqNo = new ArrayList<BigDecimal>();
            for (FindEstimateDetailVO detailVo : result.getEstDetail()) {
                estDetailSeqNo.add(detailVo.getESTDETAILSEQNO());
            }

            // ���ψČ�CR�����f�[�^�擾
            FindEstimateCreateDAO createDao = FindHCEstimateCreationDAOFactory.createFindEstimateCreateDao();
            FindEstimateCreateCondition createCond = new FindEstimateCreateCondition();
            createCond.setEstDetailSeqNo(estDetailSeqNo);
            result.setEstCreate(createDao.selectVO(createCond));
        }

        if (cond.getEstimateClass().equals("0")) {
            // ���ώ�ʂ����쌴���\�x�[�X�̏ꍇ�AHC���ύ쐬(�����捞)�擾
            FindHCEstimateCreationCaptureDAO captureDao = FindHCEstimateCreationDAOFactory.createFindHCEstimateCreationCaptureDao();
            FindHCEstimateCreationCaptureCondition captureCond = new FindHCEstimateCreationCaptureCondition();
            captureCond.setPhase(cond.getPhase());
            captureCond.setYearMonth(cond.getYearMonth());
            captureCond.setDCarCd(cond.getDCarCd());
            captureCond.setDivCd(cond.getDivCd());
            captureCond.setGroupCd(cond.getGroupCd());
            captureCond.setClassDiv("0");
            result.setCapture(captureDao.selectVO(captureCond));
        }
        else {
            // ���ώ�ʂ�CR�����̏ꍇ�ACR�����Ǘ��擾
            FindHCEstimateCreationCrDAO crCreateDataDao = FindHCEstimateCreationDAOFactory.createFindCrCreateDataDao();
            FindHCEstimateCreationCrCondition crCreateDataCond = new FindHCEstimateCreationCrCondition();
            crCreateDataCond.setPhase(cond.getPhase());
            crCreateDataCond.setYearMonth(cond.getYearMonth());
            crCreateDataCond.setDCarCd(cond.getDCarCd());
            crCreateDataCond.setDivCd(cond.getDivCd());
            crCreateDataCond.setGroupCd(cond.getGroupCd());
            crCreateDataCond.setClassDiv("1");
            result.setCrCreateData(crCreateDataDao.selectVO(crCreateDataCond));
        }

        /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
        //��Џ��擾
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //�d������Ōv�Z�敪�擾
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        // �S�ЃR�[�h�}�X�^�擾
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));
        /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */
        return result;
    }

    /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /**
     * HM���Ϗ��쐬����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindHMEstimateReportResult findHMEstimateReport(FindHMEstimateReportCondition cond) throws HAMException {

        FindHMEstimateReportResult result = new FindHMEstimateReportResult();

        //���ψČ��擾
        FindHMEstimateItemDAO itemDao = FindHCEstimateCreationDAOFactory.createFindHMEstimateItemListDao();
        FindHMEstimateItemCondition costItemCond = new FindHMEstimateItemCondition();
        costItemCond.setPhase(cond.getPhase());
        costItemCond.setYearMonth(cond.getYearMonth());
        costItemCond.setEstimateClass(cond.getEstimateClass());
        costItemCond.setEstSeqNo(cond.getEstSeqNo());
        costItemCond.setCodeType(HAMConstants.CODETYPE_COOPKBN);
        result.setEstItem(itemDao.selectVO(costItemCond));

        //���ϖ��׃f�[�^�擾
        FindHMEstimateDetailDAO detailDao = FindHCEstimateCreationDAOFactory.createFindHMEstimateDetailDao();
        FindHMEstimateDetailCondition detailCond = new FindHMEstimateDetailCondition();
        detailCond.setPhase(cond.getPhase());
        detailCond.setYearMonth(cond.getYearMonth());
        detailCond.setEstSeqNo(cond.getEstSeqNo());
        if (result.getEstItem().size() > 0) {
            detailCond.setHcBumonCd(result.getEstItem().get(0).getHCBUMONCD());
        }
        result.setEstDetail(detailDao.selectVO(detailCond));

        //���ϖ��׃f�[�^���擾�ł����ꍇ
        if (result.getEstDetail().size() > 0) {
            List<BigDecimal> estSeqNoList = new ArrayList<BigDecimal>();
            for (FindHMEstimateDetailVO detailVo : result.getEstDetail()) {
                estSeqNoList.add(detailVo.getESTDETAILSEQNO());
            }

            //���ψČ�CR�����f�[�^�擾
            FindHMEstimateCreateDAO createDao = FindHCEstimateCreationDAOFactory.createFindHMEstimateCreateDao();
            FindHMEstimateCreateCondition createCond = new FindHMEstimateCreateCondition();
            createCond.setEstSeqNoList(estSeqNoList);
            result.setEstCreate(createDao.selectVO(createCond));
        }

        //���쌴���\�x�[�X�̏ꍇ
        if (cond.getEstimateClass().equals(HAMConstants.ESTIMATE_CLASS_PRODUCTION)) {

            //HC���ύ쐬(�����捞)�擾
            FindHMEstimateCreationCaptureDAO captureDao = FindHCEstimateCreationDAOFactory.createFindHMEstimateCreationCaptureDao();
            FindHMEstimateCreationCaptureCondition captureCond = new FindHMEstimateCreationCaptureCondition();
            captureCond.setPhase(cond.getPhase());
            captureCond.setYearMonth(cond.getYearMonth());
            captureCond.setDCarCd(cond.getDCarCd());
            captureCond.setDivCd(cond.getDivCd());
            captureCond.setGroupCd(cond.getGroupCd());
            captureCond.setClassDiv(HAMConstants.SEISAKUHI_CLASSDIV_PRODUCTION);
            result.setEstCapture(captureDao.selectVO(captureCond));
        }
        else {
            //���ώ�ʂ�CR�����̏ꍇ

            //CR�����Ǘ��擾
            FindHMEstimateCreationCrDAO crCreateDataDao = FindHCEstimateCreationDAOFactory.createFindHMEstimateCreationCrDao();
            FindHMEstimateCreationCrCondition crCreateDataCond = new FindHMEstimateCreationCrCondition();
            crCreateDataCond.setPhase(cond.getPhase());
            crCreateDataCond.setYearMonth(cond.getYearMonth());
            crCreateDataCond.setDCarCd(cond.getDCarCd());
            crCreateDataCond.setDivCd(cond.getDivCd());
            crCreateDataCond.setGroupCd(cond.getGroupCd());
            crCreateDataCond.setClassDiv(HAMConstants.SEISAKUHI_CLASSDIV_CRPRODUCTION);
            result.setEstCrCreateData(crCreateDataDao.selectVO(crCreateDataCond));
        }

        //��Џ��擾
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //�d������Ōv�Z�敪�擾
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        //�S�ЃR�[�h�}�X�^�擾
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));

        //�����J�����_�[�擾
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarCond = new Mbj21CalendarCondition();
        calendarCond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        calendarCond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        List<Mbj21CalendarVO> calendarVoList = calendarDao.selectVO(calendarCond);

        //�O���Z�o
        String year = cond.getYearMonth().substring(0, 4);
        String month = cond.getYearMonth().substring(5, 7);
        String newYearMonth = null;

        //1���̏ꍇ.
        if (Integer.parseInt(month) == 1) {
            //�O�N12���ɃZ�b�g
            newYearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //�O���ɃZ�b�g.
            newYearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }

        //�O���J�����_�[�擾
        List<Mbj21CalendarVO> prevCalendarVoList = new ArrayList<Mbj21CalendarVO>();
        calendarCond.setCalendarym(newYearMonth);
        prevCalendarVoList = calendarDao.selectVO(calendarCond);

        //�擾�����J�����_�[���}�[�W
        for (int i = 0; i < prevCalendarVoList.size(); i++) {
            Mbj21CalendarVO prevCalendarVo = prevCalendarVoList.get(i);
            calendarVoList.add(prevCalendarVo);
        }
        result.setCalendar(calendarVoList);

        //��p���No�擾
        Mbj09HiyouDAO hiyouDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyouCond = new Mbj09HiyouCondition();
        result.setHiyou(hiyouDao.selectVO(hiyouCond));

        return result;
    }

    /**
     * HM�������쐬����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindHMBillReportResult findHMBillReport(FindHMBillReportCondition cond) throws HAMException {

        FindHMBillReportResult result = new FindHMBillReportResult();

        //HC����R�[�h(Fee�Č������p)�擾
        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga MOD Start */
        //List<Mbj26BillGroupVO> mbj26VoList = EstimateBillUtil.getHCBumonCdBillList();
        List<Mbj26BillGroupVO> mbj26VoList = EstimateBillUtil.getHCBumonCdBillList(cond.getGroupCd().toString());
        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga MOD End */

        HashMap<String, BigDecimal> outputGrpMap = new HashMap<String, BigDecimal>();
        for (Mbj26BillGroupVO mbj26Vo : mbj26VoList) {
            outputGrpMap.put(mbj26Vo.getHCBUMONCDBILL(), BigDecimal.valueOf(0));
        }

        //HM������(���ϖ��׏o�͏�SEQNO)�W�v�L�[�擾
        List<FindHMBillSeqNoVO> billDtlSeqNoSummaryVoList = new ArrayList<FindHMBillSeqNoVO>();
        List<Mbj26BillGroupVO> billSeqNoList = new ArrayList<Mbj26BillGroupVO>();
        FindHMBillSeqNoCondition billDtlSeqNoCond = new FindHMBillSeqNoCondition();


        billDtlSeqNoCond.setPhase(cond.getPhase());
        billDtlSeqNoCond.setYearMonth(cond.getYearMonth());

        /** 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
        billDtlSeqNoCond.setGroupCd(cond.getGroupCd());
        billDtlSeqNoCond.setEstSeqNo(cond.getEstSeqNo());
        billDtlSeqNoCond.setHcbumoncdbill(cond.getHcbumoncdbill());
        /** 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

        billSeqNoList = EstimateBillUtil.getBillList(cond.getGroupCd().toString());
        for (int i = 0; i < billSeqNoList.size(); i++) {
            billDtlSeqNoCond.setHcbumoncdbill(billSeqNoList.get(i).getHCBUMONCDBILL());
        }

        billDtlSeqNoSummaryVoList = EstimateBillUtil.getHMBillSeqNoSummary(billDtlSeqNoCond);

        /** 2016/04/20 HDX�Ή� K.Soga ADD Start */
        //�����Z���^No�����݂��Ȃ��ꍇ�AHC����R�[�h���X�V���Ȃ�
        Boolean flg = false;

        //������Gr�R�[�h�X�V�`�F�b�N
        //�����Z���^No�擾
        Mbj09HiyouDAO mbj09dao = new Mbj09HiyouDAO();
        Mbj09HiyouCondition mbj09cond = new Mbj09HiyouCondition();
        mbj09cond.setDcarcd(cond.getDCarCd());
        mbj09cond.setPhase(cond.getPhase());
        mbj09cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
        List<Mbj09HiyouVO> mbj09VOList = mbj09dao.selectVO(mbj09cond);
        //�����Z���^No�����݂��Ȃ��ꍇ�A�t���O��true�ɐݒ�(true:�X�V�����Ȃ�)
        if(mbj09VOList.size() == 0){
            flg = true;
        }
        /** 2016/04/20 HDX�Ή� K.Soga ADD Start */

        //������O���[�v�o�͏�SEQNO�X�V
        if(!flg){
            if (!EstimateBillUtil.updateHCBumonCdBill(billDtlSeqNoSummaryVoList, outputGrpMap, cond.getEstSeqNo(), HAMConstants.PRODUCTION)) {
                return result;
            }
        }

        //���ψČ��擾
        FindHMBillItemDAO itemDao = FindHCEstimateCreationDAOFactory.createFindHMBillItemDao();
        FindHMBillItemCondition itemCond = new FindHMBillItemCondition();
        itemCond.setPhase(cond.getPhase());
        itemCond.setYearMonth(cond.getYearMonth());
        itemCond.setEstimateClass(cond.getEstimateClass());
        itemCond.setEstSeqNo(cond.getEstSeqNo());
        itemCond.setCodeType(HAMConstants.CODETYPE_COOPKBN);
        result.setBillItem(itemDao.selectVO(itemCond));

        //���ϖ��׃f�[�^�擾
        FindHMBillDetailDAO detailDao = FindHCEstimateCreationDAOFactory.createFindHMBillDetailDao();
        FindHMBillDetailCondition detailCond = new FindHMBillDetailCondition();
        detailCond.setPhase(cond.getPhase());
        detailCond.setYearMonth(cond.getYearMonth());
        detailCond.setEstSeqNo(cond.getEstSeqNo());
        if (result.getBillItem().size() > 0) {
            detailCond.setHcBumonCd(result.getBillItem().get(0).getHCBUMONCD());
        }
        result.setBillDetail(detailDao.selectVO(detailCond));

        //���ϖ��׃f�[�^���擾�ł����ꍇ
        if (result.getBillDetail().size() > 0) {
            List<BigDecimal> estSeqNoList = new ArrayList<BigDecimal>();
            for (FindHMBillDetailVO detailVo : result.getBillDetail()) {
                estSeqNoList.add(detailVo.getESTDETAILSEQNO());
            }

            //���ψČ�CR�����f�[�^�擾
            FindHMBillCreateDAO createDao = FindHCEstimateCreationDAOFactory.createFindHMBillCreateDao();
            FindHMBillCreateCondition createCond = new FindHMBillCreateCondition();
            createCond.setEstSeqNoList(estSeqNoList);
            result.setBillCreate(createDao.selectVO(createCond));
        }

        //���쌴���\�x�[�X�̏ꍇ
        if (cond.getEstimateClass().equals(HAMConstants.ESTIMATE_CLASS_PRODUCTION)) {

            //HC���ύ쐬(�����捞)�擾
            FindHMBillCreationCaptureDAO captureDao = FindHCEstimateCreationDAOFactory.createFindHMBillCreationCaptureDao();
            FindHMBillCreationCaptureCondition captureCond = new FindHMBillCreationCaptureCondition();
            captureCond.setPhase(cond.getPhase());
            captureCond.setYearMonth(cond.getYearMonth());
            captureCond.setDCarCd(cond.getDCarCd());
            captureCond.setDivCd(cond.getDivCd());
            captureCond.setGroupCd(cond.getGroupCd());
            captureCond.setClassDiv(HAMConstants.SEISAKUHI_CLASSDIV_PRODUCTION);
            result.setBillCapture(captureDao.selectVO(captureCond));
        }
        else {
            //���ώ�ʂ�CR�����̏ꍇ

            //CR�����Ǘ��擾
            FindHMBillCreationCrDAO crCreateDataDao = FindHCEstimateCreationDAOFactory.createFindHMBillCreationCrDao();
            FindHMBillCreationCrCondition crCreateDataCond = new FindHMBillCreationCrCondition();
            crCreateDataCond.setPhase(cond.getPhase());
            crCreateDataCond.setYearMonth(cond.getYearMonth());
            crCreateDataCond.setDCarCd(cond.getDCarCd());
            crCreateDataCond.setDivCd(cond.getDivCd());
            crCreateDataCond.setGroupCd(cond.getGroupCd());
            crCreateDataCond.setClassDiv(HAMConstants.SEISAKUHI_CLASSDIV_CRPRODUCTION);
            result.setBillCrCreateData(crCreateDataDao.selectVO(crCreateDataCond));
        }

        //��Џ��擾
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //�d������Ōv�Z�敪�擾
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        //HM����擾
        codeCond.setCodetype(HAMConstants.CODETYPE_HMDIV);
        result.setHmBumon(codeDao.selectVO(codeCond));

        //�S�ЃR�[�h�擾
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));

        //�����J�����_�[�擾
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarCond = new Mbj21CalendarCondition();
        calendarCond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        calendarCond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        List<Mbj21CalendarVO> calendarVoList = calendarDao.selectVO(calendarCond);

        //�O���Z�o
        String year = cond.getYearMonth().substring(0, 4);
        String month = cond.getYearMonth().substring(5, 7);
        String newYearMonth = null;

        //1���̏ꍇ.
        if (Integer.parseInt(month) == 1) {
            //�O�N12���ɃZ�b�g
            newYearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //�O���ɃZ�b�g.
            newYearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }

        //�O���J�����_�[�擾
        List<Mbj21CalendarVO> prevCalendarVoList = new ArrayList<Mbj21CalendarVO>();
        calendarCond.setCalendarym(newYearMonth);
        prevCalendarVoList = calendarDao.selectVO(calendarCond);

        //�擾�����J�����_�[���}�[�W
        for (int i = 0; i < prevCalendarVoList.size(); i++) {
            Mbj21CalendarVO prevCalendarVo = prevCalendarVoList.get(i);
            calendarVoList.add(prevCalendarVo);
        }
        result.setCalendar(calendarVoList);

        //HM�S���Ҏ擾
        Mbj48HmUserDAO hmUserDao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();
        Mbj48HmUserCondition hmUserCond = new Mbj48HmUserCondition();
        result.setHmUser(hmUserDao.selectVO(hmUserCond));

        //��p���No�擾
        Mbj09HiyouDAO hiyouDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyouCond = new Mbj09HiyouCondition();
        result.setHiyou(hiyouDao.selectVO(hiyouCond));

        return result;
    }

    /**
     * HM�����f�[�^�쐬����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindHMBillDataResult findHMBillData(FindHMBillDataCondition cond) throws HAMException {

        FindHMBillDataResult result = new FindHMBillDataResult();

        //�����f�[�^(�}�́{����)
        FindHMBillDataDAO billDataDao = FindHCEstimateCreationDAOFactory.createFindHMBillDataDao();
        FindHMBillDataCondition billDataCond = new FindHMBillDataCondition();
        billDataCond.setPhase(cond.getPhase());
        billDataCond.setYearMonth(cond.getYearMonth());
        result.setBillData(billDataDao.selectVO(billDataCond));

        //�R�[�h�}�X�^
        StringBuilder codeType = new StringBuilder();
        for (int i = 0; i < cond.getCodeList().size(); i++) {
            codeType.append("'" + cond.getCodeList().get(i) + "',");
        }

        Mbj12CodeDAO mbj12Dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12Cond = new Mbj12CodeCondition();
        mbj12Cond.setCodetype(codeType.toString().substring(0, codeType.toString().length() - 1));
        result.setCode(mbj12Dao.FindManyCd(mbj12Cond));

        //�S�ЃR�[�h�擾
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));

        //�����J�����_�[�擾
        Mbj21CalendarDAO mbj21Dao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition mbj21Cond = new Mbj21CalendarCondition();
        mbj21Cond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        mbj21Cond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        result.setCalendar(mbj21Dao.selectVO(mbj21Cond));

        //��p���No�}�X�^�擾
        Mbj09HiyouDAO mbj09Dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition mbj09Cond = new Mbj09HiyouCondition();
        mbj09Cond.setPhase(cond.getPhase());
        mbj09Cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
        result.setHiyou(mbj09Dao.selectVO(mbj09Cond));

        //HM�S���҃}�X�^�擾
        Mbj48HmUserDAO mbj48Dao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();
        Mbj48HmUserCondition mbj48Cond = new Mbj48HmUserCondition();
        mbj48Cond.setPhase(cond.getPhase());
        mbj48Cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
        result.setHmUser(mbj48Dao.selectVO(mbj48Cond));

        return result;
    }
    /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

    /**
     * ���σt�@�C���o�͏��o�^
     * @param vo ���σt�@�C�����
     * @return �o�^����
     * @throws HAMException
     */
    public RegisterOutputFileInfoResult registerOutputFileInfo(RegisterOutputFileInfoVO vo) throws HAMException {

        RegisterOutputFileInfoResult result = new RegisterOutputFileInfoResult();

        if (vo.getEstimateItem() != null && vo.getEstimateItem().size() > 0) {
            for (Tbj05EstimateItemVO tbj05Vo : vo.getEstimateItem()) {
                Tbj05EstimateItemDAO tbj05Dao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
                tbj05Dao.updateOutputInfo(tbj05Vo);
            }
        }

        return result;
    }
}