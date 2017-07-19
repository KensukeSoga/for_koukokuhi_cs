package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 担当者マスタManager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/25 藤吉)<BR>
 * </P>
 * @author 藤吉
 */
public class FindMbj02UserManager {

    /** シングルトンインスタンス */
    private static FindMbj02UserManager _manager = new FindMbj02UserManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindMbj02UserManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindMbj02UserManager getInstance() {
        return _manager;
    }

    /**
     * 担当者マスタを検索します
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindMbj02UserResult findMbj02User(Mbj02UserCondition cond) throws HAMException {

        FindMbj02UserResult result = new FindMbj02UserResult();

        // ******************************************************
        // 担当者マスタの取得
        // ******************************************************
        Mbj02UserDAO userDao = Mbj02UserDAOFactory.createMbj02UserDAO();
        result.setUserVo(userDao.selectVO(cond));

        return result;
    }
}
