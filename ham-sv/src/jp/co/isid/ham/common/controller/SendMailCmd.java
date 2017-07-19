package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.SendMailManager;
import jp.co.isid.ham.common.model.SendMailResult;
import jp.co.isid.ham.common.model.SendMailVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class SendMailCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 登録データ */
    private SendMailVO _vo;

    /**
     * メール送信
     */
    @Override
    public void execute() throws UserException {
        SendMailManager manager = SendMailManager.getInstance();
        manager.sendMail(_vo);
        getResult().set(RESULT_KEY, new SendMailResult());
    }

    /**
     * メール送信データを設定します
     * @param vo メール送信データ
     */
    public void setSendMailVO(SendMailVO vo) {
        _vo = vo;
    }

    /**
     * メール送信結果を返します
     * @return メール送信結果
     */
    public SendMailResult getSendMailResult() {
        return (SendMailResult) super.getResult().get(RESULT_KEY);
    }
}
