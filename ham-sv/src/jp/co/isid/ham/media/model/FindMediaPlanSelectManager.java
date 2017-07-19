package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 媒体状況管理データ選択画面Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPlanSelectManager {

    /** シングルトンインスタンス */
    private static FindMediaPlanSelectManager _manager = new FindMediaPlanSelectManager();

    /***
     * シングルトンの為、インスタンス化を禁止します
     */
    public FindMediaPlanSelectManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindMediaPlanSelectManager getInstance() {
        return _manager;
    }

    /**
     * 媒体状況管理データ選択画面情報を検索します
     *
     * @return FindMediaPlanSelectResult 媒体状況管理データ選択画面情報
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public FindMediaPlanSelectResult findMediaPlanSelect(FindMediaPlanSelectCondition cond) throws HAMException {

        //検索結果
        FindMediaPlanSelectResult result = new FindMediaPlanSelectResult();

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
