package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.model.base.HAMException;

public class FindAccountBookLogManager {

    /** シングルトンインスタンス */
    private static FindAccountBookLogManager _manager = new FindAccountBookLogManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindAccountBookLogManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindAccountBookLogManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳情報を検索します
     *
     * @return FindCampaignListResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindAccountBookLogResult findAccountBookLog(FindAccountBookLogCondition cond)
            throws HAMException {

        //検索結果
        FindAccountBookLogResult result = new FindAccountBookLogResult();

        // ******************************************************
        // 営業作業台帳変更ログ情報の取得
        // ******************************************************
        FindAccountBookLogDAO dao = FindAccountBookLogDAOFactory.createFindAccountBookLogDAO();
        List<FindAccountBookLogVO> list = dao.FindEigyoDaichoHistory(cond.getDaichono());
        result.setLogAccountBook(list);

        return result;
    }

}
