package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * 営業作業台帳一覧データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class AccountBookRegisterCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private AccountBookRegisterVO _vo;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        AccountBookRegisterManager manager = AccountBookRegisterManager.getInstance();
        manager.AccountBookIUD(_vo);
        getResult().set(RESULT_KEY, new AccountBookRegisterResult());
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setAccountBookegisterResult(AccountBookRegisterVO vo) {
        _vo = vo;
    }

    /**
     * キャンペーン一覧検索結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public AccountBookRegisterResult getAccountBookRegisterResult() {
        return (AccountBookRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
