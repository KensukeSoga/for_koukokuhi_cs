package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.RegisterThsResult;
import jp.co.isid.ham.production.model.RegisterThsVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * 請求先検索　登録実行時のコマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterThsCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private RegisterThsVO _vo;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    RegisterThsResult result = new RegisterThsResult();
		CostManager manager = CostManager.getInstance();
		result = manager.RegisterThs(_vo);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition RegisterThsVo 検索条件
     */
	public void setRegisterThsVO(RegisterThsVO vo) {
        _vo = vo;
	}

    /**
     * 結果を返します
     *
     * @return RegisterThsResult 結果
     */
	public RegisterThsResult  getRegisterThsResult() {
        return (RegisterThsResult) super.getResult().get(RESULT_KEY);
	}

}
