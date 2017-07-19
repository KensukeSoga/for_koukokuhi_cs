package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindExcelInputErrorManager {

    /** シングルトンインスタンス */
    private static FindExcelInputErrorManager _manager = new FindExcelInputErrorManager();

    /***
     * シングルトンの為、インスタンス化を禁止します
     */
    public FindExcelInputErrorManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindExcelInputErrorManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindExcelInputErrorResult findExcelInputError(FindExcelInputErrorCondition cond)
            throws HAMException {


        //検索結果
        FindExcelInputErrorResult result = new FindExcelInputErrorResult();

        // ******************************************************
        // 画面項目表示列制御マスタ取得
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setMbj37DisplayControl(dcdao.selectVO(dccond));

        return result;
    }
}
