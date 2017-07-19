package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * キャンペーン詳細データ更新コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class CampaignRegisterDetailsCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private CampaignRegisterDetailsCondition _condition;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    public void execute() throws HAMException {
        CampaignRegisterDetailsManager manager = CampaignRegisterDetailsManager.getInstance();
        manager.CampaignDetailsIUD(_condition);
        getResult().set(RESULT_KEY, new CampaignRegisterResult());
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignRegisterDetailsCondition 検索条件
     */
    public void setCampaignRegisterDetailsResult(CampaignRegisterDetailsCondition condition) {
        _condition = condition;
    }

    /**
     * キャンペーン詳細登録結果を返します
     *
     * @return CampaignRegisterResult 条件検索結果
     */
    public CampaignRegisterResult getCampaignRegisterDetailsResult() {
        return (CampaignRegisterResult) super.getResult().get(RESULT_KEY);
    }
}
