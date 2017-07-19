package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.billing.model.RegisterOutputFileInfoResult;
import jp.co.isid.ham.billing.model.RegisterOutputFileInfoVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 見積ファイル出力情報登録コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/5/8 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterOutputFileInfoMediaCmd extends Command  {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterOutputFileInfoVO _vo;

    /**
     * 見積ファイル出力情報登録処理実行
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager manager = HCMediaCreationManager.getInstance();
        RegisterOutputFileInfoResult result = manager.registerOutputFileInfo(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 登録データを設定します
     *
     * @param vo 登録データ
     */
    public void setRegisterOutputFileInfoVO(RegisterOutputFileInfoVO vo) {
        _vo = vo;
    }

    /**
     * 登録結果を取得します
     *
     * @return 登録結果
     */
    public RegisterOutputFileInfoResult getRegisterOutputFileInfoResult() {
        return (RegisterOutputFileInfoResult) super.getResult().get(RESULT_KEY);
    }

}
