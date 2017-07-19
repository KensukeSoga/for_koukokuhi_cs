package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindSeikyuDataCondition;
import jp.co.isid.ham.production.model.FindSeikyuDataResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * 請求先一覧検索実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindSeikyuDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindSeikyuDataCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    FindSeikyuDataResult result = new FindSeikyuDataResult();
		CostManager manager = CostManager.getInstance();
		result = manager.findSeikyuData(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition FindSeikyuDataCondition 検索条件
     */
	public void setFindSeikyuDataCondition(FindSeikyuDataCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return FindSeikyuDataResult 結果
     */
	public FindSeikyuDataResult  getFindSeikyuDataResult() {
        return (FindSeikyuDataResult) super.getResult().get(RESULT_KEY);
	}

}
