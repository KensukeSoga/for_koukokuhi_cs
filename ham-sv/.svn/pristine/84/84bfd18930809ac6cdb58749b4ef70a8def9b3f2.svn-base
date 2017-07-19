package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.ExcelOutSettingRegisterManager;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterResult;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 帳票出力設定更新コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class ExcelOutSettingRegisterCmd extends Command{

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private ExcelOutSettingRegisterVO _vo;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    public void execute() throws HAMException {
        ExcelOutSettingRegisterManager manager = ExcelOutSettingRegisterManager.getInstance();
        manager.excelOutSettingRegister(_vo);
        getResult().set(RESULT_KEY, new ExcelOutSettingRegisterResult());
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setExcelOutSettingRegisterResult(ExcelOutSettingRegisterVO vo) {
        _vo = vo;
    }

    /**
     * キャンペーン一覧検索結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public ExcelOutSettingRegisterResult getExcelOutSettingRegisterResultt() {
        return (ExcelOutSettingRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
