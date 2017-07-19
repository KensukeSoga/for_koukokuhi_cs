package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class FindExcelOutSettingManager {


    /** �V���O���g���C���X�^���X */
    private static FindExcelOutSettingManager _manager = new FindExcelOutSettingManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindExcelOutSettingManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindExcelOutSettingManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠�����������܂�
     *
     * @return FindCampaignListResult �c�ƍ�Ƒ䒠���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindExcelOutSettingResult findExcelOutSetting(FindExcelOutSettingCondition cond)
            throws HAMException {

        //��������
        FindExcelOutSettingResult result = new FindExcelOutSettingResult();

        // ******************************************************
        // �}�̏o�͐ݒ�̎擾
        // ******************************************************
        OutputMediaDAO mediadao = OutputMediaDAOFactory.createOutputMediaDAO();
        List<OutputMediaVO> medialist = mediadao.findOutputMediaList(cond);
        result.setOutputMedia(medialist);

        // ******************************************************
        // �Ԏ�o�͐ݒ�̎擾
        // ******************************************************
        OutputCarDAO cardao = OutputCarDAOFactory.createOutputCarDAO();
        List<OutputCarVO> carlist = cardao.findOutputCarList(cond);
        result.setOutputCar(carlist);

        // ******************************************************
        // �o�͂��Ȃ��}�̂̎擾
        // ******************************************************
        MediaNotOutDAO nooutmediadao = MediaNotOutDAOFactory.createMediaNotOutDAO();
        List<Mbj03MediaVO> nooutmedialist = nooutmediadao.findNotOutMediaList(cond);
        result.setMbj03Media(nooutmedialist);

        // ******************************************************
        // �o�͂��Ȃ��Ԏ�̎擾
        // ******************************************************
        CarNotOutDAO nooutcardao = CarNotOutDAOFactory.createCarNotOutDAO();
        List<Mbj05CarVO> nooutcarist = nooutcardao.findNotOutCarList(cond);
        result.setMbj05Car(nooutcarist);

        return result;
    }
}
