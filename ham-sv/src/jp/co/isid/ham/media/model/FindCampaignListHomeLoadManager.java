package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignListHomeLoadManager {

    /** �V���O���g���C���X�^���X */
    private static FindCampaignListHomeLoadManager _manager = new FindCampaignListHomeLoadManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindCampaignListHomeLoadManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindCampaignListHomeLoadManager getInstance() {
        return _manager;
    }

    /**
     * �L�����y�[���ꗗ�����������܂�
     *
     * @return FindCampaignListResult �L�����y�[���ꗗ���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindCampaignListResult findCampgaingList(FindCampaignListCondition cond) throws HAMException {

        //��������
        FindCampaignListResult result = new FindCampaignListResult();

        //�Ԏ�擾.
        result.setCarList(CarGet(cond));
        if (result.getCarList().size() != 0) {
            cond.setDCarCd(result.getCarList().get(0).getDCARCD());
        }

        Mbj37DisplayControlCondition discond = new Mbj37DisplayControlCondition();
        discond.setFormid(cond.getFormID());
        Mbj37DisplayControlDAO disDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        List<Mbj37DisplayControlVO> disList = disDao.selectVO(discond);
        result.setSpdControl(disList);

        // ******************************************************
        // �L�����y�[�����̎擾
        // ******************************************************
        FindCampaignListDAO campdao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        List<Tbj12CampaignVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);
        //�L�����y�[���ڍׂ�����L�����y�[���R�[�h���擾����.
        List<Tbj12CampaignVO> camdetailList = campdao.findCampaignToDetailsByCond(cond);
        result.set_camDetail(camdetailList);

        //--���ʂ̎擾����--//
        // ******************************************************
        // �@�\����Info�̎擾
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFunctionType());
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

    /**
     * �Ԏ���擾
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    private List<CarListVO> CarGet(FindCampaignListCondition cond) throws HAMException {

        FindCarListDAO cardao = FindCarCampaignListDAOFactory.createFindCarListDAO();
        List<CarListVO> carlist = cardao.findCarList(cond);

        return carlist;
    }

}
