/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 制作請求表取得Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindBillProductionOutputResult extends AbstractServiceResult {

    /** 制作請求表VOリスト */
    List<FindBillProductionOutputVO> _findBillProductOutList;

    /**
     * 制作請求表VOリストを取得する
     *
     * @return 制作請求表VOリスト
     */
    public List<FindBillProductionOutputVO> getFindBillProductionOutput() {
        return _findBillProductOutList;
    }

    /**
     * 制作請求表VOリストを設定する
     *
     * @param fc 制作請求表VOリスト
     */
    public void setFindBillProductionOutput(List<FindBillProductionOutputVO> voList) {
    	_findBillProductOutList = voList;
    }
}