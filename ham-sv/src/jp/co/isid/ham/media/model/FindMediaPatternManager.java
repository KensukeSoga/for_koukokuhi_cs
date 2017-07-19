package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj35MediaPatternCondition;
import jp.co.isid.ham.common.model.Mbj35MediaPatternDAO;
import jp.co.isid.ham.common.model.Mbj35MediaPatternDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindMediaPatternManager {

    /** シングルトンインスタンス */
    private static FindMediaPatternManager _manager = new FindMediaPatternManager();

    /** インスタンス化の禁止 */
    private FindMediaPatternManager() {
    }

    /** インスタンスの取得 */
    public static FindMediaPatternManager getInstance() {
        return _manager;
    }

    /**
     * 媒体パターンを取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindMediaPatternResult findMediaPattern(FindMediaPatternCondition cond) throws HAMException {

        //検索結果
        FindMediaPatternResult result = new FindMediaPatternResult();

        // ******************************************************
        // 媒体パターン情報を取得
        // ******************************************************
        Mbj35MediaPatternDAO mpdao = Mbj35MediaPatternDAOFactory.createMbj35MediaPatternDAO();
        Mbj35MediaPatternCondition mpcond = new Mbj35MediaPatternCondition();
        result.setMbj35MediaPattern(mpdao.selectVO(mpcond));

        return result;

    }
}
