package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;


public class RegisterListColumnSettingManager {

    /** �V���O���g���C���X�^���X */
    private static RegisterListColumnSettingManager _manager = new RegisterListColumnSettingManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private RegisterListColumnSettingManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static RegisterListColumnSettingManager getInstance() {
        return _manager;
    }

    /**
     * ��ݒ�o�^
     * @param vo ��ݒ�
     * @throws HAMException
     */
    public void registerListColumnSetting(RegisterListColumnSettingVO vo) throws HAMException {
        // �\���p�^�[���o�^
        Tbj30DisplayPatternDAO dpDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition cond = new Tbj30DisplayPatternCondition();
        Tbj30DisplayPatternVO dpvo = vo.getDisplayPattern();
        cond.setHamid(dpvo.getHAMID());
        cond.setFormid(dpvo.getFORMID());
        cond.setViewid(dpvo.getVIEWID());
        List<Tbj30DisplayPatternVO> voList = dpDao.selectVO(cond);
        if (voList.size() > 0) {
            dpDao.deleteVO(dpvo);
        }
        dpDao.insertVO(dpvo);
    }
}
