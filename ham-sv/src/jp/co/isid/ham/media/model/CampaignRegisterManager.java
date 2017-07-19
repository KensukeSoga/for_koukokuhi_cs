package jp.co.isid.ham.media.model;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class CampaignRegisterManager {

    /** �V���O���g���C���X�^���X */
    private static CampaignRegisterManager _manager = new CampaignRegisterManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private CampaignRegisterManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static CampaignRegisterManager getInstance() {
        return _manager;
    }

    /**
     * �L�����y�[���ꗗ����o�^���܂�
     *
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public void CampaignListIUD(CampaignRegisterCondition cond) throws HAMException {

        //�r���`�F�b�N
        if (!exclusionCheck(cond))
        {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        CampaignRegisterDAO dao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();

        //�폜.
        if (cond.getDelVo() == null || cond.getDelVo().size() == 0) {
        } else {
            for (Tbj12CampaignVO vo : cond.getDelVo()) {
                dao.delCampaignList(vo);
            }
        }
        //�o�^
        if (cond.getInsVo() == null || cond.getInsVo().size() == 0) {
        } else {
            //�L�����y�[��No�̍ő�l���擾���܂�.
            Tbj12CampaignDAO cadao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> campresult = cadao.findMaxCampCd();
            if (campresult.size() == 0) {
                throw new HAMException("�����G���[", "BJ-E0001");
            }
            String maxCampNo = campresult.get(0).getCAMPCD();
            maxCampNo =  maxCampNo.replace("CP", "");
            int count = Integer.parseInt( maxCampNo);
            count ++;
            for (Tbj12CampaignVO vo : cond.getInsVo()) {
                vo.setCAMPCD("CP" + String.format("%1$05d", count));
                dao.insCampaignList(vo);
                count ++;
            }
        }
        //�X�V
        if (cond.getUpdVo() == null || cond.getUpdVo().size() == 0) {
        } else {
            for (Tbj12CampaignVO vo : cond.getUpdVo()) {
                dao.updCampaignList(vo);
            }
        }
    }

    /**
     * �r���`�F�b�N���s���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    private boolean exclusionCheck(CampaignRegisterCondition cond) throws HAMException {

        FindCampaignListDAO dao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        FindCampaignListCondition toCond = new FindCampaignListCondition();

        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            toCond.setDCarCd(cond.getUpdVo().get(0).getDCARCD());
            toCond.setPhase(cond.getUpdVo().get(0).getPHASE().toString());
        } else if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            toCond.setDCarCd(cond.getDelVo().get(0).getDCARCD());
            toCond.setPhase(cond.getDelVo().get(0).getPHASE().toString());
        } else {
            return true;
        }

        //�Č���������.
        List<Tbj12CampaignVO> list = dao.findCampaignListByCond(toCond);

        // ��r���ȗ������邽�߂ɁAHashMap�Ɍ^��ϊ�
        HashMap<String, Date> hm = new HashMap<String, Date>();
        for (Tbj12CampaignVO cVo : list) {
            hm.put(cVo.getCAMPCD(), cVo.getUPDDATE());
        }

        boolean error = false;

        //�X�V�Ώ۔r���`�F�b�N
        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            for (Tbj12CampaignVO cVo : cond.getUpdVo()) {
                if (!hm.containsKey(cVo.getCAMPCD())) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(hm.get(cVo.getCAMPCD()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        //�폜�Ώ۔r���`�F�b�N
        if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            for (Tbj12CampaignVO cVo : cond.getDelVo()) {
                if (!hm.containsKey(cVo.getCAMPCD())) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(hm.get(cVo.getCAMPCD()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        return true;
    }

}
