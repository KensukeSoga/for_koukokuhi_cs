package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class FindListColumnSettingManager {

    /** �V���O���g���C���X�^���X */
    private static FindListColumnSettingManager _manager = new FindListColumnSettingManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindListColumnSettingManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static FindListColumnSettingManager getInstance() {
        return _manager;
    }

    /**
     * �ꗗ��ݒ���擾
     * @param cond ��������
     * @return �擾����
     * @throws HAMException
     */
    public FindListColumnSettingResult findListColumnSetting(FindListColumnSettingCondition cond) throws HAMException {
        FindListColumnSettingResult result = new FindListColumnSettingResult();

        // ��ʍ��ڕ\���񐧌�}�X�^�擾(��ݒ���)
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> mbj37List = dcdao.selectVO(dccond);

        // ��ʍ��ڕ\���񐧌�}�X�^�擾(�Ăяo�������)
        Mbj37DisplayControlDAO callingdcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition callingdccond = new Mbj37DisplayControlCondition();
        callingdccond.setFormid(cond.getCallingFormid());
        callingdccond.setViewid(cond.getCallingViewid());
        mbj37List.addAll(callingdcdao.selectVO(callingdccond));

        result.setDisplayControl(mbj37List);

        // �ꗗ�\���p�^�[���擾
        Tbj30DisplayPatternDAO dpdao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition dpcond = new Tbj30DisplayPatternCondition();
        dpcond.setHamid(cond.getHamid());
        dpcond.setFormid(cond.getCallingFormid());
        dpcond.setViewid(cond.getCallingViewid());
        result.setDisplayPattern(dpdao.selectVO(dpcond));

        return result;
    }
}
