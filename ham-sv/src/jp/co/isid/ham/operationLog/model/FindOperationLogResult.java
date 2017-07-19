package jp.co.isid.ham.operationLog.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 稼働ログ結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/15 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindOperationLogResult extends AbstractServiceResult {

    /** 稼働ログVOリスト */
    List<FindOperationLogVO> _findOperationLogList;

    /**
     * 稼働ログVOリストを取得する
     *
     * @return 稼働ログVOリスト
     */
    public List<FindOperationLogVO> getFindOperationLog() {
        return _findOperationLogList;
    }

    /**
     * 稼働ログVOリストを設定する
     *
     * @param fc 稼働ログVOリスト
     */
    public void setFindOperationLog(List<FindOperationLogVO> voList) {
    	_findOperationLogList = voList;
    }
}
