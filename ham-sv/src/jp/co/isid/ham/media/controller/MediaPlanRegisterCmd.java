package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.MediaPlanRegisterManager;
import jp.co.isid.ham.media.model.MediaPlanRegisterResult;
import jp.co.isid.ham.media.model.MediaPlanRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

public class MediaPlanRegisterCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MediaPlanRegisterVO _vo;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        MediaPlanRegisterManager manager = MediaPlanRegisterManager.getInstance();
        manager.MediaPlanRegister(_vo);
        getResult().set(RESULT_KEY, new MediaPlanRegisterResult());
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setMediaPlanRegisterResult(MediaPlanRegisterVO vo) {
        _vo = vo;
    }

    /**
     * キャンペーン一覧検索結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public MediaPlanRegisterResult getMediaPlanRegisterResult() {
        return (MediaPlanRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
