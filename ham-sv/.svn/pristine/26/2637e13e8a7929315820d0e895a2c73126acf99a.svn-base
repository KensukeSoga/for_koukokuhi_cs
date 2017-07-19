package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj23CarTantoCondition;
import jp.co.isid.ham.common.model.Mbj23CarTantoDAO;
import jp.co.isid.ham.common.model.Mbj23CarTantoDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 制作費明細書出力データを管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/4 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class WorkDetailManager {

    /** シングルトンインスタンス */
    private static WorkDetailManager _manager = new WorkDetailManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private WorkDetailManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static WorkDetailManager getInstance() {
        return _manager;
    }

    /**
     * 制作費明細書出力検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindWorkDetailResult findWorkDetail(FindWorkDetailCondition cond) throws HAMException {

    	FindWorkDetailResult result = new FindWorkDetailResult();

        // 制作費明細書出力取得
        FindWorkDetailListItemDAO itemDao = FindWorkDetailCreationDAOFactory.createFindWorkDetailListItemDao();

        // 制作費明細書出力一覧取得
        result.setEstDetail(itemDao.getWorkDetailListItem(cond));
        // 制作原価取得
        result.setItem(itemDao.getWorkGenka(cond));

        // 車種担当者マスタ取得
        Mbj23CarTantoDAO carTantoDao = Mbj23CarTantoDAOFactory.createMbj23CarTantoDAO();

        // 車種担当者マスタ検索条件設定
        Mbj23CarTantoCondition carTantoCond = new Mbj23CarTantoCondition();
        carTantoCond.setDcarcd(cond.getDCarCd());

        // 車種担当者取得
        result.setCarTanto(carTantoDao.selectVO(carTantoCond));

        return result;
    }
}
