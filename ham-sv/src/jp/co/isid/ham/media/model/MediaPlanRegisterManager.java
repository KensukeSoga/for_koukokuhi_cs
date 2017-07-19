package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailCondition;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class MediaPlanRegisterManager {

    /** ���ʃR�[�h��`�̃R�[�h�^�C�v(�������p) */
    private static final String COMMON_CODE_TYPE_TERM = "14";

    /** �V���O���g���C���X�^���X */
    private static MediaPlanRegisterManager _manager = new MediaPlanRegisterManager();

    private MediaPlanRegisterVO _vo;

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private MediaPlanRegisterManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static MediaPlanRegisterManager getInstance() {
        return _manager;
    }

    public void MediaPlanRegister(MediaPlanRegisterVO vo) throws HAMException {
        _vo = vo;

        //�o�^�pDAO���Ăт����D
        MediaPlanRegisterDAO mediaplanregdao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();

        //�r���`�F�b�N�D
        if (!exclusionCheck()) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }

        //�폜.
        if (vo.getDelVo() != null && !vo.getDelVo().equals("")) {

            //�폜�pVO��1�s���擾����D
            for (Tbj01MediaPlanVO delvo : vo.getDelVo()) {
                //�Z�b�g�������̂�o�^�pDAO�̍폜���\�b�h�ɓn���D
                mediaplanregdao.delMediaPlan(delvo);

                //�Ώۂ̔}�̏󋵊Ǘ�No�ɂ��āA�L�����y�[���ꗗ�E�ڍ׃f�[�^���X�V
                updateCampaign(delvo);
            }
        }

        //�o�^
        if (vo.getInsVo() != null && !vo.getInsVo().equals("")) {

            //�o�^�pVO��1�s���擾����D
            for (Tbj01MediaPlanVO insvo : vo.getInsVo()) {

                //---------------------�}�̏󋵊Ǘ�NO���擾����ׂ̏���-----------------//
                //DAO���Ăт����D
                Tbj01MediaPlanDAO mediaplanfinddao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
                //���ʗpVOList�ɔ}�̊Ǘ�No��MAX�l���Z�b�g����D
                List<Tbj01MediaPlanVO> result = mediaplanfinddao.findMediaPlanMaxCd();
                //�o�^�pVO�̔}�̊Ǘ�No�ɁA���ʗpVOList�̔}�̊Ǘ�No+1���Z�b�g����D
                insvo.setMEDIAPLANNO(result.get(0).getMEDIAPLANNO().add(BigDecimal.valueOf(1)));
                //---------------------�}�̏󋵊Ǘ�NO���擾����ׂ̏���-----------------//

                //---------------------��p�v��NO���擾����ׂ̏���-----------------//
                //���ʗpVOList�ɁA�擾������p�v��No���Z�b�g����.
                List<Mbj09HiyouVO> hiyouresult = getInsertHiyou(insvo);
                //��p�v��No����̏ꍇ��null���Z�b�g.
                if (hiyouresult.isEmpty())
                {
                    insvo.setHIYOUNO(null);
                }
                else
                {
                    insvo.setHIYOUNO(hiyouresult.get(0).getHIYOUNO());
                }
                //---------------------��p�v��NO���擾����ׂ̏���-----------------//

                //�ȉ��o�^
                mediaplanregdao.insMediaPlan(insvo);

                //�Ώۂ̔}�̏󋵊Ǘ�No�ɂ��āA�L�����y�[���ꗗ�E�ڍ׃f�[�^���X�V
                updateCampaign(insvo);

            }
        }

        //�X�V
        if (vo.getUpdVo() != null && !vo.getUpdVo().equals("")) {

            for (Tbj01MediaPlanVO updvo : vo.getUpdVo()) {

                //---------------------��p�v��NO���擾����ׂ̏���-----------------//
               //���ʗpVOList�ɁA�擾������p�v��No���Z�b�g����.
                List<Mbj09HiyouVO> hiyouresult = getInsertHiyou(updvo);

                //��p�v��No����̏ꍇ��null���Z�b�g.
                if (hiyouresult.isEmpty())
                {
                    updvo.setHIYOUNO(null);
                }
                else
                {
                    updvo.setHIYOUNO(hiyouresult.get(0).getHIYOUNO());
                }
                //---------------------��p�v��NO���擾����ׂ̏���-----------------//

                Tbj01MediaPlanDAO mpdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
                Tbj01MediaPlanCondition mpcond = new Tbj01MediaPlanCondition();
                mpcond.setMediaplanno(updvo.getMEDIAPLANNO());
                List<Tbj01MediaPlanVO> mpVoList = mpdao.findMediaPlanByMediaPlanNo(mpcond);
                Tbj01MediaPlanVO mpVo = mpVoList.get(0);

                if (mpVo.getCAMPCD().equals(updvo.getCAMPCD()))
                {
                    //�L�����y�[���R�[�h���ύX����Ă��Ȃ��ꍇ�́AUPDATE
                    mediaplanregdao.updMediaPlan(updvo);
                }
                else
                {
                    //�L�����y�[���R�[�h���ύX����Ă���ꍇ�́ADELETE/INSERT
                    mediaplanregdao.delMediaPlan(mpVo);
                    updateCampaign(mpVo);
                    mediaplanregdao.delinsMediaPlan(updvo);
                }

                //�Ώۂ̔}�̏󋵊Ǘ�No�ɂ��āA�L�����y�[���ꗗ�E�ڍ׃f�[�^���X�V
                updateCampaign(updvo);
            }
        }
    }

    /**
     * �L�����y�[���ꗗ�E�L�����y�[���ڍׂ̃f�[�^���X�V
     * @param mediavo �}�̏󋵊Ǘ��f�[�^
     * @throws HAMException
     */
    private void updateCampaign(Tbj01MediaPlanVO mediavo) throws HAMException {

        CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
        CampaignRegisterDetailsDAO campDetailRegistDAO = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

        //�X�V�Ώۂ̃L�����y�[���ꗗ�f�[�^�̎擾
        Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> campvolist = campdao.findCampaignListByCampCd(mediavo.getCAMPCD());
        Tbj12CampaignVO campvo = campvolist.get(0);

        //�X�V�p�̃L�����y�[��VO���쐬
        campvo = updateCampaignVO(mediavo,campvo);

        //�L�����y�[���f�[�^���X�V
        campRegistDAO.updCampaignList(campvo);

        Tbj13CampDetailCondition campcond = new Tbj13CampDetailCondition();
        campcond.setCampcd(mediavo.getCAMPCD());

        //�X�V�Ώۂ̃L�����y�[���ڍ׃f�[�^����x�폜���Ă���
        campDetailRegistDAO.delCampaignDetailsByCd(campcond);

        List<Tbj13CampDetailVO> campdetailvo = createCampDetailVO(mediavo);

        if (campdetailvo != null) {
            for (Tbj13CampDetailVO insvo : campdetailvo) {
                campDetailRegistDAO.insCampaignDetails(insvo);
            }
        }
    }

    /**
     * �L�����y�[���f�[�^�X�V�pVO�̍쐬
     * �i�R�Â��L�����y�[���f�[�^�����������ꍇ�̂ݎ��{�j
     * @param mediavo �}�̊Ǘ�VO
     * @param campvo �L�����y�[��VO
     * @return �X�V�pVO
     * @throws HAMException
     */
    private Tbj12CampaignVO updateCampaignVO(Tbj01MediaPlanVO mediavo,Tbj12CampaignVO campvo) throws HAMException {

        //�Ώۂ̃L�����y�[���R�[�h�����}�̏󋵊Ǘ��f�[�^�̍��v���擾
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanByCampCdSUM(campvo.getCAMPCD());
        List<Tbj01MediaPlanVO> mediaflgvolist = mediadao.findMediaPlanByCampCd(mediavo.getCAMPCD());

        if (mediavolist.size() == 1) {
            //�擾�ł������͎擾�����f�[�^�����Ă�����
            Tbj01MediaPlanVO summediavo = mediavolist.get(0);

            //�\�Z�Ǝ��т�vo�ɓ����
            campvo.setACTUAL(summediavo.getACTUAL());
            campvo.setACTUALHM(summediavo.getACTUALHM());
            campvo.setBUDGET(summediavo.getBUDGET());
            campvo.setBUDGETHM(summediavo.getBUDGETHM());
            campvo.setBAITAIFLG("1");
        }
        if (mediaflgvolist.size() == 0) {
            //�L�����y�[���R�[�h�Ŕ}�̏󋵊Ǘ����������A
            //�f�[�^���Ȃ����vo��0������
            campvo.setBAITAIFLG(String.valueOf(0));
        }

        return campvo;
    }

    /**
     * �o�^�p�L�����y�[���ڍ׃f�[�^���쐬
     * �iDelete��Insert����̂ŁA�K���S�f�[�^���쐬�j
     * @param mediavo
     * @return
     * @throws HAMException
     */
    private List<Tbj13CampDetailVO> createCampDetailVO(Tbj01MediaPlanVO mediavo) throws HAMException {
        List<Tbj13CampDetailVO> campdetailvo = new ArrayList<Tbj13CampDetailVO>();

        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> resistList = mediadao.findMediaPlanByCampCdDist(mediavo.getCAMPCD());

        for (Tbj01MediaPlanVO vo : resistList)
        {
            //���ԂƃL�����y�[���R�[�h�Ɣ}�̂Ō������A���������f�[�^�̍��v�l���擾

            Tbj01MediaPlanCondition mediacond = new Tbj01MediaPlanCondition();
            mediacond.setCampcd(vo.getCAMPCD());
            mediacond.setYoteiym(vo.getYOTEIYM());
            mediacond.setMediacd(vo.getMEDIACD());
            List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanSUMByCdAndMonth(mediacond);
            List<Tbj01MediaPlanVO> mediavolists = mediadao.findMediaPlanByCampCd(vo.getCAMPCD());

            //������Ȃ��������i�폜�������Ȃǁj��null�Ƃ��Ă���
            if (mediavolists.size() == 0) {
                campdetailvo = null;
            } else {
                //���鎞�͓o�^�p�f�[�^���쐬

                Tbj01MediaPlanVO summediavo = mediavolist.get(0);
                Tbj13CampDetailVO addvo = new Tbj13CampDetailVO();

                addvo.setCAMPCD(vo.getCAMPCD());
                addvo.setDCARCD(mediavo.getDCARCD());
                addvo.setMEDIACD(vo.getMEDIACD());
                addvo.setPHASE(mediavo.getPHASE());
                addvo.setYOTEIYM(vo.getYOTEIYM());
                addvo.setKIKANFROM(vo.getKIKANFROM());
                addvo.setKIKANTO(vo.getKIKANTO());
                addvo.setBUDGET(summediavo.getBUDGET());
                addvo.setBUDGETHM(summediavo.getBUDGETHM());
                addvo.setCRTAPL(mediavo.getCRTAPL());
                addvo.setCRTNM(mediavo.getCRTNM());
                addvo.setCRTID(mediavo.getCRTID());
                addvo.setUPDNM(mediavo.getUPDNM());
                addvo.setUPDAPL(mediavo.getUPDAPL());
                addvo.setUPDID(mediavo.getUPDID());

                campdetailvo.add(addvo);
            }
        }

        return campdetailvo;
    }

    /**
     * �X�V�E�o�^�Ώ�vo�̔�p�v������擾
     * @param vo �X�V�E�o�^�Ώ�vo
     * @return ��p�v����
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> getInsertHiyou(Tbj01MediaPlanVO vo) throws HAMException
    {
        //��p�v��No�̎擾
        Mbj09HiyouDAO hiyodao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyocond = new Mbj09HiyouCondition();
        hiyocond.setDcarcd(vo.getDCARCD());
        hiyocond.setMediacd(vo.getMEDIACD());
        hiyocond.setPhase(vo.getPHASE());
        hiyocond.setTerm(convertTerm2Code(vo.getTERM()));
        List<Mbj09HiyouVO> hiyoresult =hiyodao.selectVO(hiyocond);

        return hiyoresult;
    }

    /**
     * �R�[�h�}�X�^������̕�����ɑΉ������R�[�h�ɕϊ�����
     * @param str ���̕�����(��/��)
     * @return �ϊ������R�[�h
     */
    private String convertTerm2Code(String str) {
        // �R�[�h�}�X�^������ː����ɕϊ�����
        String retVal = "";
        Mbj12CodeDAO dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition cond = new Mbj12CodeCondition();
        cond.setCodetype(COMMON_CODE_TYPE_TERM);
        cond.setCodename(str);
        try {
            List<Mbj12CodeVO> result = dao.selectVO(cond);
            if (!result.isEmpty()) {
                Mbj12CodeVO vo = result.get(0);
                retVal = vo.getKEYCODE();
            }
        } catch (HAMException e) {
            // ���s�����ꍇ�͉������Ȃ�
        }

        return retVal;
    }

    /**
     * �r���`�F�b�N���s���܂�
     * @return �`�F�b�N����
     * @throws HAMException
     */
    private boolean exclusionCheck() throws HAMException {

        //�Č���
        FindMediaPlanDAO dao = FindMediaPlanDAOFactory.createFindMediaPlanDAO();
        FindMediaPlanCondition toCond = new FindMediaPlanCondition();

        //������ݒ肷��D
        toCond.setDcarcd(_vo.getDcarCd());
        toCond.setPhase(_vo.getPhase());
        toCond.setHamid(_vo.getHamId());

        List<FindMediaPlanVO> list = dao.findMediaPlanByCond(toCond);

        // ��r���ȗ������邽�߂ɁAHashMap�Ɍ^��ϊ�
        HashMap<BigDecimal, Date> hm = new HashMap<BigDecimal, Date>();
        for (FindMediaPlanVO mpVo : list) {
            hm.put(mpVo.getMEDIAPLANNO(), mpVo.getUPDDATE());
        }

        boolean error = false;

        //�X�V�Ώ۔r���`�F�b�N
        if (_vo.getUpdVo() != null && _vo.getUpdVo().size() > 0) {
            for (Tbj01MediaPlanVO mpVo : _vo.getUpdVo()) {
                if (!hm.containsKey(mpVo.getMEDIAPLANNO())) {
                    error = true;
                    break;
                }

                if (_vo.getLatestDate().before(hm.get(mpVo.getMEDIAPLANNO()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        //�폜�Ώ۔r���`�F�b�N
        if (_vo.getDelVo() != null && _vo.getDelVo().size() > 0) {
            for (Tbj01MediaPlanVO mpVo : _vo.getDelVo()) {
                if (!hm.containsKey(mpVo.getMEDIAPLANNO())) {
                    error = true;
                    break;
                }

                if (_vo.getLatestDate().before(hm.get(mpVo.getMEDIAPLANNO()))) {
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
