package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.*;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class MediaPlanRegisterByCampDetailsManager {

    /** �V���O���g���C���X�^���X */
    private static MediaPlanRegisterByCampDetailsManager _manager = new MediaPlanRegisterByCampDetailsManager();

    private MediaPlanRegisterCondition _cond;


    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private MediaPlanRegisterByCampDetailsManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static MediaPlanRegisterByCampDetailsManager getInstance() {
        return _manager;
    }

    /**
     * �}�̏󋵊Ǘ��f�[�^����o�^���܂�
     *
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public void MediaPlanRegister(MediaPlanRegisterCondition cond)
            throws HAMException {
        _cond = cond;

        if (cond.getInsOnlyFlg()) {
            insOnly();
        } else {
            //�L�����y�[���ڍׂ̍X�V.
            CampaignRegisterDetailsCondition crdCond = new CampaignRegisterDetailsCondition();
            crdCond.setDelVo(cond.getDeDelVo());
            crdCond.setInsVo(cond.getDeInsVo());
            crdCond.setUpdVo(cond.getDeUpdVo());
            crdCond.setHamId(cond.getHamId());
            crdCond.setHamNm(cond.getHamNm());
            crdCond.setUpdApl(cond.getUpdApl());
            crdCond.setDataCount(cond.getDataCount());
            crdCond.setLatestDate(cond.getLatestDate());
            crdCond.setLatestPel(cond.getLatestUpdId());
            CampaignRegisterDetailsManager mane = CampaignRegisterDetailsManager.getInstance();
            mane.CampaignDetailsIUD(crdCond);
            saiSakusei();
        }

        //*************************************************
        //�L�����y�[���ꗗ�̔}�̏󋵓o�^�t���O�̍X�V
        //*************************************************
        Tbj12CampaignDAO camDao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        String cCampCd = null;
        String BaitaiFlg = null;
        //�o�^������ꍇ.
        if (_cond.getInsVo() != null && !_cond.getInsVo().equals("")) {
            cCampCd = _cond.getInsVo().get(0).getCAMPCD();
        }
        if (_cond.getDeUpdVo() != null && !_cond.getDeUpdVo().equals("")) {
            cCampCd = _cond.getDeUpdVo().get(0).getCAMPCD();
        }
        if (_cond.getDeDelVo() != null && !_cond.getDeDelVo().equals("")) {
            cCampCd = _cond.getDeDelVo().get(0).getCAMPCD();
        }

        //�L�����y�[���̔}�̏󋵃f�[�^���������邩���m�F0���̏ꍇ�͔}�̃t���O��0�ɂ���.
        Tbj01MediaPlanDAO mmdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mmlist = mmdao.findMediaPlanByCampCd(cCampCd);

        if (mmlist.size() == 0) {
            BaitaiFlg = "0";
        } else {
            BaitaiFlg = "1";
        }

        List<Tbj12CampaignVO> camList =  camDao.findCampaignListByCampCd(cCampCd);
        if (camList.size() == 0) {
            //�L�����y�[���擾�G���[.
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        //�L�����y�[���R�[�h�͎�L�[�̈�1�s�������Ȃ�.
        Tbj12CampaignVO camVo = camList.get(0);
        camVo.setBAITAIFLG(BaitaiFlg);
        CampaignRegisterDAO reDao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
        reDao.updCampaignList(camVo);
    }

    /**
     *�}�̏󋵊Ǘ��ɏ��߂ēo�^����ꍇ.
     * @throws HAMException
     */
    private void insOnly() throws HAMException {
        Tbj01MediaPlanDAO mediaDao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> maxList = mediaDao.findMediaPlanMaxCd();
        if (maxList.size() == 0) {
            //Max�l�擾�G���[
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        BigDecimal maxCd = maxList.get(0).getMEDIAPLANNO();
        int imaxcd =maxCd.intValue();

        //�P�����o�^���Ă���.
        for (Tbj01MediaPlanVO vo : _cond.getInsVo()) {
            //�}�̊Ǘ�No�̉��Z
            imaxcd++;
            //��p���No���擾
            List<Mbj09HiyouVO> hiList = findHiyou(vo);
            //��p���No��insertVo�ɐݒ肷��
            if (hiList.size() == 0) {
                vo.setHIYOUNO("");
            } else {
                vo.setHIYOUNO( hiList.get(0).getHIYOUNO());
            }
            //�}�̊Ǘ�No��ݒ肷��
            vo.setMEDIAPLANNO(new BigDecimal(imaxcd));
            MediaPlanRegisterDAO mpdao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
            mpdao.insMediaPlan(vo);
        }
    }

    /**
     * �}�̏󋵊Ǘ��č쐬�̏ꍇ
     * @throws HAMException
     */
    private void saiSakusei() throws HAMException {

        //�}�̏󋵊Ǘ�
        Tbj01MediaPlanDAO mDao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        MediaPlanRegisterDAO mrDao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();

        //�폜VO�����݂��邩
        if (_cond.getDeDelVo() != null && !_cond.getDeDelVo().equals("")) {

            for (Tbj13CampDetailVO dedVo : _cond.getDeDelVo()) {
                //�}�̊Ǘ�No�̎擾
                List<Tbj01MediaPlanVO> mediaCdlist = mDao.findMediaPlanByCond(dedVo);
                if (mediaCdlist.size() == 0) {
                    throw new HAMException("�����G���[", "BJ-E0001");
                }

                //�}�̏󋵊Ǘ����폜.
                mrDao.delMediaPlan(mediaCdlist.get(0));
            }
        }

        //�o�^�pVO�����݂��邩
        if (_cond.getDeInsVo() != null && !_cond.getDeInsVo().equals("")) {

            //�}�̏󋵊Ǘ�No�̍ő�l���擾
            List<Tbj01MediaPlanVO> maxlist =  mDao.findMediaPlanMaxCd();
            BigDecimal max = maxlist.get(0).getMEDIAPLANNO();
            int imax =0;
            if (maxlist.size() == 0) {
                imax = 1;
            } else {
                imax = max.intValue();
            }

            for (Tbj01MediaPlanVO insVo : _cond.getInsVo()) {
                imax++;
                //��p���No���擾
                List<Mbj09HiyouVO> hiList = findHiyou(insVo);
                //��p���No��insertVo�ɐݒ肷��
                if (hiList.size() == 0) {
                    insVo.setHIYOUNO("");
                } else {
                    insVo.setHIYOUNO( hiList.get(0).getHIYOUNO());
                }
                //�}�̊Ǘ�No��ݒ肷��
                insVo.setMEDIAPLANNO(new BigDecimal(imax));
                //�o�^
                mrDao.insMediaPlan(insVo);
            }
        }

        if (_cond.getDeUpdVo() != null && !_cond.getDeUpdVo().equals("")) {

            for (Tbj13CampDetailVO updVo : _cond.getDeUpdVo()) {
                //�}�̏󋵊Ǘ�No�̎擾
                List<Tbj01MediaPlanVO> mplist = mDao.findMediaPlanByCond(updVo);
                if (mplist.size() == 0) {
                    throw new HAMException("�����G���[", "BJ-E0001");
                }
                Tbj01MediaPlanVO addVo = mplist.get(0);
                //�\�Z�̍X�V.
                addVo.setBUDGET(updVo.getBUDGET());
                addVo.setBUDGETHM(updVo.getBUDGETHM());
                //���z�̍X�V.
                addVo.setDIFAMT(updVo.getBUDGET().subtract(addVo.getACTUAL()));
                addVo.setDIFAMTHM(updVo.getBUDGETHM().subtract(addVo.getACTUALHM()));
                //�X�V
                mrDao.updMediaPlan(addVo);
            }
        }
    }

    /**
     *
     * ��p���No�̎擾���s��.
     * @param �}�̏󋵊Ǘ�No.
     * @return ��p�}�X�^�̃��X�g
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> findHiyou(Tbj01MediaPlanVO vo) throws HAMException {

        //��p���No���}�X�^����擾����
        Mbj09HiyouCondition hiCond = new  Mbj09HiyouCondition();
        hiCond.setMediacd(vo.getMEDIACD());
        hiCond.setDcarcd(vo.getDCARCD());
        hiCond.setPhase(vo.getPHASE());
        hiCond.setTerm(vo.getTERM());
        Mbj09HiyouDAO hiDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();

        return hiDao.selectVO(hiCond);
    }

}
