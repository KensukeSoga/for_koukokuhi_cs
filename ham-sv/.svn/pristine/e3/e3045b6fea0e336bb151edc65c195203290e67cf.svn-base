package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 車種一覧検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/27 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
public class FindCarListManager {

    /** シングルトンインスタンス */
    private static FindCarListManager _manager = new FindCarListManager();

    /**
     * コンストラクタ
     */
    private FindCarListManager() {
    }

    /**
     * インスタンスを取得する.
     *
     * @return インスタンス
     */
    public static FindCarListManager getInstance() {
        return _manager;
    }

    /**
     * 車種一覧を検索する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindCarListResult findCarList(FindCarListCondition cond) throws HAMException {
        //検索結果
        FindCarListResult result = new FindCarListResult();

        FindCarListDAO dao = FindCarListDAOFactory.createFindCarListDAO();
        List<CarListVO> list = dao.findCarList(cond);
        result.setCarList(list);

        return result;
    }
}
