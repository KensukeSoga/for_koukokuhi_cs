package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 終了処理管理
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class ShutDownManager {

    /** シングルトンインスタンス */
    private static ShutDownManager _manager = new ShutDownManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private ShutDownManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static ShutDownManager getInstance() {
        return _manager;
    }

    /**
     * 終了処理
     * @param tbj29vo
     * @return
     * @throws HAMException
     */
    public ShutDownResult shutDown(Tbj29LoginUserVO tbj29vo) throws HAMException {

        ShutDownResult result = new ShutDownResult();

        // ログインユーザー削除
        Tbj29LoginUserDAO dao = Tbj29LoginUserDAOFactory.createTbj29LoginUserDAO();
        Tbj29LoginUserCondition tbj29cond = new Tbj29LoginUserCondition();
        tbj29cond.setHamid(tbj29vo.getHAMID());
        List<Tbj29LoginUserVO> tbl29list = dao.selectVO(tbj29cond);
        if (tbl29list.size() > 0) {
            dao.deleteVO(tbj29vo);
        }

        return result;
    }

}
