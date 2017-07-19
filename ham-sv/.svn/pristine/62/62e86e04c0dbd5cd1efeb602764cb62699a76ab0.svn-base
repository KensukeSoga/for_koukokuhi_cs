package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class FindListColumnSettingManager {

    /** シングルトンインスタンス */
    private static FindListColumnSettingManager _manager = new FindListColumnSettingManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindListColumnSettingManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static FindListColumnSettingManager getInstance() {
        return _manager;
    }

    /**
     * 一覧列設定情報取得
     * @param cond 検索条件
     * @return 取得結果
     * @throws HAMException
     */
    public FindListColumnSettingResult findListColumnSetting(FindListColumnSettingCondition cond) throws HAMException {
        FindListColumnSettingResult result = new FindListColumnSettingResult();

        // 画面項目表示列制御マスタ取得(列設定画面)
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> mbj37List = dcdao.selectVO(dccond);

        // 画面項目表示列制御マスタ取得(呼び出し元画面)
        Mbj37DisplayControlDAO callingdcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition callingdccond = new Mbj37DisplayControlCondition();
        callingdccond.setFormid(cond.getCallingFormid());
        callingdccond.setViewid(cond.getCallingViewid());
        mbj37List.addAll(callingdcdao.selectVO(callingdccond));

        result.setDisplayControl(mbj37List);

        // 一覧表示パターン取得
        Tbj30DisplayPatternDAO dpdao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition dpcond = new Tbj30DisplayPatternCondition();
        dpcond.setHamid(cond.getHamid());
        dpcond.setFormid(cond.getCallingFormid());
        dpcond.setViewid(cond.getCallingViewid());
        result.setDisplayPattern(dpdao.selectVO(dpcond));

        return result;
    }
}
