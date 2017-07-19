package jp.co.isid.ham.common.model;

import java.util.Date;
import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class ExcelOutSettingRegisterManager {

    /** �V���O���g���C���X�^���X */
    private static ExcelOutSettingRegisterManager _manager = new ExcelOutSettingRegisterManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private ExcelOutSettingRegisterManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static ExcelOutSettingRegisterManager getInstance() {
        return _manager;
    }

    /**
     * ���[�o�͐ݒ����o�^���܂�
     *
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public void excelOutSettingRegister(ExcelOutSettingRegisterVO vo)
            throws HAMException {
        exclusionCheck(vo);
        ExcelOutMediaRegisterDAO mediaDAO = ExcelOutSettingRegisterDAOFactory.createExcelOutMediaRegisterDAO();
        ExcelOutCarRegisterDAO carDAO = ExcelOutSettingRegisterDAOFactory.createExcelOutCarRegisterDAO();

        //��x�����̃f�[�^���폜����
        mediaDAO.delMediaOutCtrl(vo.getReportCd(), vo.getPhase());
        carDAO.delCarOutCtrl(vo.getReportCd(), vo.getPhase());

        for (Mbj13CarOutCtrlVO carvo : vo.getMbj13CarOutCtrlVO()) {
            carDAO.insCarOutCtrl(carvo);
        }
        for (Mbj14MediaOutCtrlVO mediavo : vo.getMbj14MediaOutCtrlVO()) {
            mediaDAO.insMediaOutCtrl(mediavo);
        }
    }

    /**
     * �r���`�F�b�N���s���܂�
     * @throws HAMException
     *
     */
    private  void exclusionCheck(ExcelOutSettingRegisterVO condVO) throws HAMException {

        //�Č���������.
        FindExcelOutSettingCondition cond = new FindExcelOutSettingCondition();
        cond.setPhase(condVO.getPhase());
        cond.setReportcd(condVO.getReportCd());
        // ******************************************************
        // �}�̏o�͐ݒ�̎擾
        // ******************************************************
        OutputMediaDAO mediadao = OutputMediaDAOFactory.createOutputMediaDAO();
        List<OutputMediaVO> list = mediadao.findOutputMediaList(cond);

        String dataCnt = Integer.toString(list.size());

        if (!dataCnt.equals(condVO.getDataCnt())) {
            throw new HAMException("�o�^","BJ-E0005");
        }

        if (list.size() > 0)
        {
            //�ŐV�������擾.
            OutputMediaVO result = new OutputMediaVO();
            int count = 0;
            for (OutputMediaVO vo : list) {
                if (count == 0) {
                    result = vo;
                    count++;
                    continue;
                }
                if (result.getUPDDATE().before(vo.getUPDDATE())) {
                    result = vo;
                }
                count++;
            }

            Date getDate = new Date(result.getUPDDATE().getTime());

            if (!getDate.equals(condVO.getLatestDate())) {
                throw new HAMException("�o�^","BJ-E0005");
            }

            if (!result.getUPDID().equals(condVO.getLatestID())) {
                throw new HAMException("�o�^","BJ-E0005");
            }
        }
    }
}

