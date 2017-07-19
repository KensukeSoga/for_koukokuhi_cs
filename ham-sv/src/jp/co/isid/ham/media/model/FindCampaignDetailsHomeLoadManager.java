package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignDetailsHomeLoadManager {

    /** �V���O���g���C���X�^���X */
    private static FindCampaignDetailsHomeLoadManager _manager = new FindCampaignDetailsHomeLoadManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindCampaignDetailsHomeLoadManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindCampaignDetailsHomeLoadManager getInstance() {
        return _manager;
    }

    /**
     * �L�����y�[���ڍ׏����������܂�
     *
     * @return FindCampaignListResult �L�����y�[���ڍ׏��
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindCampaignDetailsResult findCampgaingDetail(FindCampaignDetailsCondition cond)
    throws HAMException {

        //��������
        FindCampaignDetailsResult result = new FindCampaignDetailsResult();

        //**************************************************
        //�}�̃}�X�^�̎擾.
        //**************************************************
        MediaListCondition mcond = new MediaListCondition();
        mcond.setHamid(cond.getHamId());
        MediaListDAO dao = MediaListDAOFactory.createMediaListDAO();
        List<MediaListVO> medialist = dao.findMediaList(mcond);
        result.setMediaList(medialist);


        //**************************************************
        //�L�����y�[���ڍׂ̎擾.
        //**************************************************
        FindCampaignDetailsDAO campdao = Tbj13CampDetailDAOFactory.createFindCampaignDetailsDAO();
        List<FindCampaignDetailstVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);

        // ******************************************************
        // �}�̏󋵊Ǘ��擾
        // ******************************************************
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        result.setMediaPlan(mediadao.findMediaPlanByCampCd(cond.getCampaignNo()));


        //**************************************************
        //�X�v���b�h����̎擾.
        //**************************************************
        Mbj37DisplayControlCondition discond = new Mbj37DisplayControlCondition();
        discond.setFormid(cond.getFormId());
        Mbj37DisplayControlDAO disDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        List<Mbj37DisplayControlVO> disList = disDao.selectVO(discond);
        result.setSpdCont(disList);

        //--���ʂ̎擾����--//
        // ******************************************************
        // �@�\����Info�̎擾
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFunctionType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());


        // ******************************************************
        // �Z�L�����e�BInfo�̎擾
        // ******************************************************
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        List<SecurityInfoVO> secvolist = new ArrayList<SecurityInfoVO>();
        List<SecurityInfoVO> tempvolist = new ArrayList<SecurityInfoVO>();
        seccond.setHamid(cond.getHamId());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getCampaignSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        secvolist = secmanager.getSecurityInfo(seccond).getSecurityInfo();

        //�L�����y�[�������łȂ��A�}�̏󋵊Ǘ����o�^���邨���ꂪ����̂ŁA�������̃Z�L�����e�B���擾����
        seccond.setSecuritycd(cond.getMediaPlanSecuritycd());
        tempvolist = secmanager.getSecurityInfo(seccond).getSecurityInfo();

        //secvolist�ɒǉ����Ă�����
        for (SecurityInfoVO vo : tempvolist) {
            secvolist.add(vo);
        }
        result.setSecurityInfoVoList(secvolist);

        return result;
    }

}
