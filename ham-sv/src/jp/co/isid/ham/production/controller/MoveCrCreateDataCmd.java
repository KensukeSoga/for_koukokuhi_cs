package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.MoveCrCreateDataResult;
import jp.co.isid.ham.production.model.MoveCrCreateDataVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * CR制作費―データ移動／コピー　登録実行時のコマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class MoveCrCreateDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MoveCrCreateDataVO _vo;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    MoveCrCreateDataResult result = new MoveCrCreateDataResult();
		CostManager manager = CostManager.getInstance();
		result = manager.MoveCrCreateData(_vo);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition MoveCrCreateDataCondition 検索条件
     */
	public void setMoveCrCreateDataCondition(MoveCrCreateDataVO condition) {
        _vo = condition;
	}

    /**
     * 結果を返します
     *
     * @return MoveCrCreateDataResult 結果
     */
	public MoveCrCreateDataResult  getMoveCrCreateDataResult() {
        return (MoveCrCreateDataResult) super.getResult().get(RESULT_KEY);
	}

}
