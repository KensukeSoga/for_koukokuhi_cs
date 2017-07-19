package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAO;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class CampaignRegisterDetailsManager {

    /** �V���O���g���C���X�^���X */
    private static CampaignRegisterDetailsManager _manager = new CampaignRegisterDetailsManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private CampaignRegisterDetailsManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static CampaignRegisterDetailsManager getInstance() {
        return _manager;
    }

    /**
     * �L�����y�[���ڍ׃f�[�^����o�^���܂�
     *
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    public void CampaignDetailsIUD(CampaignRegisterDetailsCondition cond) throws HAMException {

        //�r���`�F�b�N
        if (!exclusionCheck(cond)) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        /**�L�����y�[���ڍ׈ꗗ�X�V*/
        CampaignRegisterDetailsDAO dao = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

        //�L�����y�[���ꗗ��UPDATE���邽�߂ɕێ�.
        String campaignCd = "";


        //*************************************************
        //�X�V����(�L�����y�[���ڍ�)
        //*************************************************
        //�폜.
        if (cond.getDelVo() == null || cond.getDelVo().size() == 0) {
        } else {
            campaignCd = cond.getDelVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getDelVo()) {
                dao.delCampaignDetails(vo);
            }
        }
        //�o�^.
        if (cond.getInsVo() == null || cond.getInsVo().size() == 0) {
        } else {
            campaignCd = cond.getInsVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getInsVo()) {
                dao.insCampaignDetails(vo);
            }
        }
        //�X�V.
        if (cond.getUpdVo() == null || cond.getUpdVo().size() == 0) {
        } else {
            campaignCd = cond.getUpdVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getUpdVo()) {
                dao.updCampaignDetails(vo);
            }
        }


        //*************************************************
        //�X�V����(�L�����y�[���ꗗ)
        //*************************************************

        //�ێ������L�����y�[�����g���A�L�����y�[���ꗗ���X�V����.
        Tbj13CampDetailDAO ddao = Tbj13CampDetailDAOFactory.createTbj13CampDetailDAO();
        //�ڍ׍��v���擾
        List<Tbj13CampDetailVO> sumBud =  ddao.findCampaignDetailsSumBudget(campaignCd);

        //�ڍׂ̊��Ԃ��擾
        List<Tbj13CampDetailVO> kikan =  ddao.findCampaignDetailsKikan(campaignCd);

        //�ڍ׃f�[�^�����݂��Ȃ��ꍇ.
        if (sumBud.size() == 0) {
            return;
        }

        //�X�V�Ώۂ̍s���擾
        Tbj12CampaignDAO ldao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> camlist =  ldao.findCampaignListByCampCd(campaignCd);

        Tbj12CampaignVO updVo = camlist.get(0);
        //�ύX�����������̃`�F�b�N.
        boolean upCheck = false;
        //�X�V�Ώۍs�Əڍׂ̍��v�������ꍇ�͍X�V���Ȃ�
        if (updVo.getBUDGET().equals(sumBud.get(0).getBUDGET()) && updVo.getBUDGETHM().equals(sumBud.get(0).getBUDGETHM())) {
        } else {
            updVo.setBUDGET(sumBud.get(0).getBUDGET());
            updVo.setBUDGETHM(sumBud.get(0).getBUDGETHM());
            updVo.setACTUAL(BigDecimal.valueOf(0));
            updVo.setACTUALHM(BigDecimal.valueOf(0));
            updVo.setUPDID(cond.getHamId());
            updVo.setUPDNM(cond.getHamNm());
            updVo.setUPDAPL(cond.getUpdApl());
            upCheck = true;
        }

        //���Ԃ̔�r
        Calendar deKikanFrom = Calendar.getInstance();
        deKikanFrom.setTime(kikan.get(0).getKIKANFROM());
        Calendar deKikanTo = Calendar.getInstance();
        deKikanTo.setTime(kikan.get(0).getKIKANTO());
        Calendar liKikanFrom = Calendar.getInstance();
        liKikanFrom.setTime(updVo.getKIKANFROM());
        Calendar liKikanTo = Calendar.getInstance();
        liKikanTo.setTime(updVo.getKIKANTO());

        //�����������J�n���Ԃ����ւ���
        if (liKikanFrom.get(Calendar.MONTH) != deKikanFrom.get(Calendar.MONTH)) {
            updVo.setKIKANFROM(kikan.get(0).getKIKANFROM());
            upCheck = true;
        }

        if (liKikanTo.get(Calendar.MONTH) != deKikanTo.get(Calendar.MONTH)) {
            updVo.setKIKANTO(kikan.get(0).getKIKANTO());
            upCheck = true;
        }

        //�X�V.
        if (upCheck) {
            CampaignRegisterDAO rdao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
            rdao.updCampaignList(updVo);
        }
    }

    /**
     * �r���`�F�b�N
     * @param cond
     * @return
     * @throws HAMException
     */
    private boolean exclusionCheck(CampaignRegisterDetailsCondition cond) throws HAMException {

        Tbj13CampDetailDAO dao = Tbj13CampDetailDAOFactory.createTbj13CampDetailDAO();
        FindCampaignDetailsCondition fcdCond = new FindCampaignDetailsCondition();

        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            fcdCond.setCampaignNo(cond.getUpdVo().get(0).getCAMPCD());
        }
        else if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            fcdCond.setCampaignNo(cond.getDelVo().get(0).getCAMPCD());
        }
        else
        {
            return true;
        }

        //�L�����y�[���ڍ׎擾
        List<Tbj13CampDetailVO> list13 = dao.findCampaignDetailsByCond(fcdCond);

        boolean error = false;

        //�X�V�Ώ۔r���`�F�b�N
        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            for (Tbj13CampDetailVO cdVo : cond.getUpdVo()) {
                //���݃`�F�b�N
                boolean exist = false;
                Date updDate = null;
                for (Tbj13CampDetailVO cdVoNow : list13) {
                    if (cdVo.getCAMPCD().equals(cdVoNow.getCAMPCD())
                      && cdVo.getMEDIACD().equals(cdVoNow.getMEDIACD())
                      && cdVo.getPHASE().equals(cdVoNow.getPHASE())
                      && cdVo.getYOTEIYM().equals(cdVoNow.getYOTEIYM())) {
                        exist = true;
                        updDate = cdVoNow.getUPDDATE();
                        break;
                    }
                }

                if (!exist) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(updDate)) {
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
            for (Tbj13CampDetailVO cdVo : cond.getDelVo()) {
                //���݃`�F�b�N
                boolean exist = false;
                Date updDate = null;
                for (Tbj13CampDetailVO cdVoNow : list13) {
                    if (cdVo.getCAMPCD().equals(cdVoNow.getCAMPCD())
                      && cdVo.getMEDIACD().equals(cdVoNow.getMEDIACD())
                      && cdVo.getPHASE().equals(cdVoNow.getPHASE())
                      && cdVo.getYOTEIYM().equals(cdVoNow.getYOTEIYM())) {
                        exist = true;
                        updDate = cdVoNow.getUPDDATE();
                        break;
                    }
                }

                if (!exist) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(updDate)) {
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
