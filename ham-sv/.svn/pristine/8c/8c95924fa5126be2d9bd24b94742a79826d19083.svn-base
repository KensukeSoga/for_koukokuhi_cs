package jp.co.isid.ham.operationLog.model;

import jp.co.isid.ham.common.model.Tbj28WorkLogDAO;
import jp.co.isid.ham.common.model.Tbj28WorkLogDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
*
* <P>
* 稼働ログデータを管理する
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/05/15 T.Kobayashi)<BR>
* </P>
*
* @author T.Kobayashi
*/
public class OperationLogManager {

    /** シングルトンインスタンス */
    private static OperationLogManager _manager = new OperationLogManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private OperationLogManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static OperationLogManager getInstance() {
        return _manager;
    }

    /**
     * 稼働ログの表示データを取得します
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindOperationLogResult findOperationLog(FindOperationLogCondition cond) throws HAMException {

    	FindOperationLogResult result = new FindOperationLogResult();

        // 稼働ログ取得DAO
    	FindOperationLogDAO dao = FindOperationLogDAOFactory.createFindOperationLogDAO();
    	result.setFindOperationLog(dao.selectVO(cond));

        return result;
    }

    /**
     * 稼働ログを登録します
     * @param vo 登録情報
     * @return 処理結果
     * @throws HAMException
     */
    public RegisterOperationLogResult registerOperationLog(RegisterOperationLogVO vo) throws HAMException {

        RegisterOperationLogResult result = new RegisterOperationLogResult();

        // 稼働ログ登録
        Tbj28WorkLogDAO dao = Tbj28WorkLogDAOFactory.createTbj28WorkLogDAO();
        dao.insertVO(vo.getWorkLogVo());

        return result;
    }
}
