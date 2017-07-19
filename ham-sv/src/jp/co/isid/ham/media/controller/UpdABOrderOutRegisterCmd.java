package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.UpdABOrderOutRegisterManager;
import jp.co.isid.ham.media.model.UpdABOrderOutRegisterResult;
import jp.co.isid.ham.media.model.UpdABOrderOutRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 営業作業台帳更新コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/28 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class UpdABOrderOutRegisterCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 更新結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 更新条件 */
    private UpdABOrderOutRegisterVO _vo;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        UpdABOrderOutRegisterManager manager = UpdABOrderOutRegisterManager.getInstance();
        manager.UpdAccountBookOutFlg(_vo);
        getResult().set(RESULT_KEY, new UpdABOrderOutRegisterResult());
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setUpdABOrderOutRegisterVO(UpdABOrderOutRegisterVO vo) {
        _vo = vo;
    }

    /**
     * キャンペーン一覧検索結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public UpdABOrderOutRegisterResult getUpdABOrderOutRegisterResult() {
        return (UpdABOrderOutRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
