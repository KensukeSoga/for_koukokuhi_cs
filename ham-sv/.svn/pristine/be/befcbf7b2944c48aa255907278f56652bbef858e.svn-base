package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.RegisterCrCreateDataResult;
import jp.co.isid.ham.production.model.RegisterCrCreateDataVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR制作費　登録実行時のコマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterCrCreateDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private RegisterCrCreateDataVO _vo;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        RegisterCrCreateDataResult result = new RegisterCrCreateDataResult();
        CostManager manager = CostManager.getInstance();
        result = manager.registerCrCreateData(_vo);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition RegisterCrCreateDataVO
     */
    public void setRegisterCrCreateDataVO(RegisterCrCreateDataVO vo) {
        _vo = vo;
    }

    /**
     * 結果を返します
     *
     * @return RegisterCrCreateDataResult 結果
     */
    public RegisterCrCreateDataResult  getRegisterCrCreateDataResult() {
        return (RegisterCrCreateDataResult) super.getResult().get(RESULT_KEY);
    }

}
