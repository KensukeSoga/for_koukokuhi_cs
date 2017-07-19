package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;


public class RegisterListColumnSettingManager {

    /** シングルトンインスタンス */
    private static RegisterListColumnSettingManager _manager = new RegisterListColumnSettingManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private RegisterListColumnSettingManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static RegisterListColumnSettingManager getInstance() {
        return _manager;
    }

    /**
     * 列設定登録
     * @param vo 列設定
     * @throws HAMException
     */
    public void registerListColumnSetting(RegisterListColumnSettingVO vo) throws HAMException {
        // 表示パターン登録
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
