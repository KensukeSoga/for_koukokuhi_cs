package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj50RdStationCondition;
import jp.co.isid.ham.common.model.Mbj50RdStationDAO;
import jp.co.isid.ham.common.model.Mbj50RdStationDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ラジオ局選択画面情報Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdStationSelectManager {

    /** シングルトンインスタンス */
    private static FindRdStationSelectManager _manager = new FindRdStationSelectManager();

    /***
     * シングルトンの為、インスタンス化を禁止します
     */
    public FindRdStationSelectManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindRdStationSelectManager getInstance() {
        return _manager;
    }

    /**
     * ラジオ局選択画面情報を検索する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException 例外発生時
     */
    public FindRdStationSelectResult findMediaPlanSelect(FindRdStationSelectCondition cond) throws HAMException {

        //検索結果
        FindRdStationSelectResult result = new FindRdStationSelectResult();

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO mbj37dao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition mbj37cond = new Mbj37DisplayControlCondition();
        mbj37cond.setFormid(cond.getFormID());
        result.setMbj37DisplayControl(mbj37dao.selectVO(mbj37cond));

        //ラジオ局マスタ取得
        Mbj50RdStationDAO mbj50dao = Mbj50RdStationDAOFactory.createMbj50RdStationDAO();
        Mbj50RdStationCondition mbj50Cond = new Mbj50RdStationCondition();
        result.setMbj50RdStation(mbj50dao.selectVO(mbj50Cond));

        return result;
    }

}
