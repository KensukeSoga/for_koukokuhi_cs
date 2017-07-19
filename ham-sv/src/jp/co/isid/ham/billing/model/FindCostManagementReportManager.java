package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FindExcelOutSettingCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.OutputCarDAO;
import jp.co.isid.ham.common.model.OutputCarDAOFactory;
import jp.co.isid.ham.common.model.OutputMediaDAO;
import jp.co.isid.ham.common.model.OutputMediaDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj14FeeKanriCondition;
import jp.co.isid.ham.common.model.Tbj14FeeKanriDAO;
import jp.co.isid.ham.common.model.Tbj14FeeKanriDAOFactory;
import jp.co.isid.ham.common.model.Tbj34CutManagementCondition;
import jp.co.isid.ham.common.model.Tbj34CutManagementDAO;
import jp.co.isid.ham.common.model.Tbj34CutManagementDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * �R�X�g�Ǘ��\�o�̓f�[�^���擾
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindCostManagementReportManager {

    /** �V���O���g���C���X�^���X */
    private static FindCostManagementReportManager _manager = new FindCostManagementReportManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindCostManagementReportManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static FindCostManagementReportManager getInstance() {
        return _manager;
    }

    /**
     * �R�X�g�Ǘ��\�o�̓f�[�^����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindCostManagementReportResult ��indCostManagementReport(FindCostManagementReportCondition cond) throws HAMException {

        FindCostManagementReportResult result = new FindCostManagementReportResult();

        //�}�̃R�X�g�擾
        FindMediaCostDAO mediaDAO = FindCostManagementReportDAOFactory.createFindMediaCostDAO();
        List<FindMediaCostVO> mediaCostList = mediaDAO.findMediaCost(cond);
        result.setFindMediaCostVO(mediaCostList);

        //�����R�X�g�擾
        FindCreateCostDAO crDAO = FindCostManagementReportDAOFactory.createFindCreateCostDAO();
        List<FindCreateCostVO> createCostList = crDAO.findCreateCost(cond);
        result.setFindCreateCostVO(createCostList);

        List<FindCreateUptakeCostVO> createUpCostList = new ArrayList<FindCreateUptakeCostVO>();
        if (cond.getPhase() > 85) {
            //�����捞�R�X�g�擾
            FindCreateUptakeCostDAO crUpDAO = FindCostManagementReportDAOFactory.createFindCreateUptakeCostDAO();
            createUpCostList = crUpDAO.findCreateUptakeCost(cond);
            result.setFindCreateUptakeCostVO(createUpCostList);
        }

        //----------�o�͔}�́A�Ԏ�̎擾-----------//
        OutputMediaDAO outMediaDAO = OutputMediaDAOFactory.createOutputMediaDAO();
        OutputCarDAO outCarDAO = OutputCarDAOFactory.createOutputCarDAO();
        FindExcelOutSettingCondition settingCond = new FindExcelOutSettingCondition();
        settingCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
        settingCond.setReportcd("R05");
        //�o�͎Ԏ�A�o�͔}�̂��擾
        //\0�̎Ԏ�A�}�̂��\������ꍇ�͑S���擾
        if (!cond.getFeeGetFlg()) {
            result.setOutputCarVO(outCarDAO.findOutputCarList(settingCond));
            result.setOutputMediaVO(outMediaDAO.findOutputMediaList(settingCond));
        } else {
        //\0�̎Ԏ�A�}�̂�\�����Ȃ���

            //�}�́A�����A�����捞����擾�����Ԏ��}�̂��擾
            List<String> carList = new ArrayList<String>();
            List<String> mediaList = new ArrayList<String>();

            //�}�̃R�X�g���炮�邮��T��
            for (FindMediaCostVO mediaVO : mediaCostList) {
                //���X�g�Ɍ�����Ȃ���ΑΏۂ̎Ԏ��ǉ�
                if (carList.indexOf(mediaVO.getDCARCD()) == -1) {
                    carList.add(mediaVO.getDCARCD());
                }
                //���X�g�Ɍ�����Ȃ���ΑΏۂ̔}�̂�ǉ�
                if (mediaList.indexOf(mediaVO.getMEDIACD()) == -1) {
                    mediaList.add(mediaVO.getMEDIACD());
                }
            }
            //�����R�X�g���炮�邮��T��
            for (FindCreateCostVO createVO : createCostList) {
                //���X�g�Ɍ�����Ȃ���ΑΏۂ̎Ԏ��ǉ�
                if (carList.indexOf(createVO.getDCARCD()) == -1) {
                    carList.add(createVO.getDCARCD());
                }
            }
            if (cond.getPhase() > 85) {
                //�����R�X�g���炮�邮��T��
                for (FindCreateUptakeCostVO createUpVO : createUpCostList) {
                    //���X�g�Ɍ�����Ȃ���ΑΏۂ̎Ԏ��ǉ�
                    if (carList.indexOf(createUpVO.getDCARCD()) == -1) {
                        carList.add(createUpVO.getDCARCD());
                    }
                }
            }

            StringBuffer searchCar = new StringBuffer();
            StringBuffer searchMedia = new StringBuffer();
            int index = 0;
            for (String dCarCd : carList) {
                if (index != 0) {
                    searchCar.append(",");
                }
                searchCar.append("'");
                searchCar.append(dCarCd);
                searchCar.append("'");
                index++;
            }
            index = 0;
            for (String mediaCd : mediaList) {
                if (index != 0) {
                    searchMedia.append(",");
                }
                searchMedia.append("'");
                searchMedia.append(mediaCd);
                searchMedia.append("'");
                index++;
            }

            if (searchCar.length() != 0) {
                result.setOutputCarVO(outCarDAO.findOutputReportCarList(settingCond, searchCar.toString()));
            }
            if (searchMedia.length() != 0) {
                result.setOutputMediaVO(outMediaDAO.findOutputReportMediaList(settingCond, searchMedia.toString()));
            }
        }
        //----------�o�͔}�́A�Ԏ�̎擾-----------//

        //----------������O���[�v�̎擾-----------//
        Mbj26BillGroupDAO groupDAO = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        StringBuffer searchGroup = new StringBuffer();
        List<BigDecimal> groupList = new ArrayList<BigDecimal>();
        //�����R�X�g���炮�邮��T��
        for (FindCreateUptakeCostVO createUpVO : createUpCostList) {
            //���X�g�Ɍ�����Ȃ���ΑΏۂ̎Ԏ��ǉ�
            if (groupList.indexOf(createUpVO.getGROUPCD()) == -1) {
                groupList.add(createUpVO.getGROUPCD());
            }
        }
        int index = 0;
        for (BigDecimal groupCd : groupList) {
            if (index != 0) {
                searchGroup.append(",");
            }
            searchGroup.append(groupCd);
            index++;
        }
        if (searchGroup.length() != 0) {
            result.setMbj26BillGroupVO(groupDAO.selectIN(searchGroup.toString()));
        }

        //----------������O���[�v�̎擾-----------//
        //----------�t�B�[���̎擾-----------//
        Mbj12CodeDAO codeDAO = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("05");
        result.setMbj12CodeVO(codeDAO.selectVO(codeCond));


        //85���ȉ��̊��̏ꍇ�́A�t�B�[�Ǘ��A�팸���Ǘ����Q��
        if (cond.getPhase() < 86) {
            Tbj14FeeKanriDAO feeDAO = Tbj14FeeKanriDAOFactory.createTbj14FeeKanriDAO();
            Tbj14FeeKanriCondition feeCond = new Tbj14FeeKanriCondition();
            feeCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
            result.setTbj14FeeKanriVO(feeDAO.findPhaseFee(feeCond,cond.getKikanFrom(),cond.getKikanTo()));

            Tbj34CutManagementDAO cutDAO = Tbj34CutManagementDAOFactory.createTbj34CutManagementDAO();
            Tbj34CutManagementCondition cutCond = new Tbj34CutManagementCondition();
            cutCond.setDatefrom(cond.getKikanFrom());
            cutCond.setDateto(cond.getKikanTo());
            result.setTbj34CutManagementVO(cutDAO.selectVO(cutCond));
        }
        //----------�t�B�[���̎擾-----------//

        return result;
    }


    /**
     * �R�X�g�Ǘ��\�@�\���䌟��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindDispCostManagementReportResult ��indDispCostManagementReport(FindDispCostManagementReportCondition cond) throws HAMException {

        FindDispCostManagementReportResult result = new FindDispCostManagementReportResult();
        // ******************************************************
        // �@�\����Info�̎擾
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // ******************************************************
        // �Z�L�����e�BInfo�̎擾
        // ******************************************************
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        seccond.setHamid(cond.getHamid());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        result.setSecurityInfoVoList(secmanager.getSecurityInfo(seccond).getSecurityInfo());

        return result;
    }
}
