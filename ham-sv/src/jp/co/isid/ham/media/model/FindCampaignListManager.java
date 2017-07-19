package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCampaignListManager {

    /** �V���O���g���C���X�^���X */
    private static FindCampaignListManager _manager = new FindCampaignListManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindCampaignListManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindCampaignListManager getInstance() {
        return _manager;
    }

    /**
     * �L�����y�[���ꗗ�����������܂�
     *
     * @return FindCampaignListResult �L�����y�[���ꗗ���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindCampaignListResult findCampgaingList(FindCampaignListCondition cond)
            throws HAMException {

        //��������
        FindCampaignListResult result = new FindCampaignListResult();

        if (!cond.getCampaignFlg()) {
            result.setCarList(CarGet(cond));
            if (result.getCarList().size() == 0) {
                return result;
            }
            if (cond.getDCarCd() == null || cond.getDCarCd().trim().length() == 0) {

                cond.setDCarCd(result.getCarList().get(0).getDCARCD());
            }
        }
        // ******************************************************
        // �L�����y�[�����̎擾
        // ******************************************************
        FindCampaignListDAO campdao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        List<Tbj12CampaignVO>list =  campdao.findCampaignListByCond(cond);
        result.setCampaignList(list);
        //�L�����y�[���ڍׂ�����L�����y�[���R�[�h���擾����.
        List<Tbj12CampaignVO> camdetailList = campdao.findCampaignToDetailsByCond(cond);
        result.set_camDetail(camdetailList);

        return result;
    }

    /**
     * �Ԏ�擾.
     *
     * @return FindCampaignListResult �L�����y�[���ꗗ���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    private List<CarListVO> CarGet(FindCampaignListCondition cond) throws HAMException
    {

        if (!cond.getFullCar()) {
            FindCarListDAO cardao = FindCarCampaignListDAOFactory.createFindCarListDAO();
            List<CarListVO> carlist = cardao.findCarList(cond);
            return carlist;
        } else if (cond.getFullCar()) {
            CarListCondition carcond = new CarListCondition();
            carcond.setHamid(cond.getHamid());
            carcond.setSecType("0");
            CarListDAO dao = CarListDAOFactory.createCarListDAO();
            return dao.findCarList(carcond);
        }
        return null;
    }
}
