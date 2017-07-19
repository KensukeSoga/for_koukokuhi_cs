package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj28BillDaysVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC見積一覧検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** 請求書出力年月マスタ */
    private List<Mbj28BillDaysVO> _billVoList;

    /** HC見積一覧(制作原価)取得VO */
    private List<FindHCEstimateListCostVO> _costVoList;

    /** HC見積一覧(制作費)取得VO */
    private List<FindHCEstimateListTotalVO> _totalVoList;

    /** HC見積一覧(見積案件)(制作原価)取得VO */
    private List<FindHCEstimateListItemVO> _costItemVoList;

    /** HC見積一覧(見積案件)(制作費)取得VO */
    private List<FindHCEstimateListItemVO> _totalItemVoList;

    /** 変更確認データ(制作原価) */
    private List<FindHCEstimateListDiffVO> _costDiffVoList;

    /** 変更確認データ(制作費) */
    private List<FindHCEstimateListDiffTotalVO> _totalDiffVoList;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * 請求書出力年月マスタを取得する
     *
     * @return 請求書出力年月マスタ
     */
    public List<Mbj28BillDaysVO> getBillDays() {
        return _billVoList;
    }

    /**
     * 請求書出力年月マスタを設定する
     *
     * @param billVoList 請求書出力年月マスタ
     */
    public void setBillDays(List<Mbj28BillDaysVO> billVoList) {
        _billVoList = billVoList;
    }

    /**
     * HC見積一覧(制作原価)取得VOを取得
     *
     * @return HC見積一覧(制作原価)取得VO
     */
    public List<FindHCEstimateListCostVO> getCostVoList() {
        return _costVoList;
    }

    /**
     * HC見積一覧(制作原価)取得VOを設定
     *
     * @param costVoList HC見積一覧(制作原価)取得VO
     */
    public void setCostVoList(List<FindHCEstimateListCostVO>  costVoList) {
        _costVoList = costVoList;
    }

    /**
     * HC見積一覧(制作費)取得VOを設定
     *
     * @return HC見積一覧(制作費)取得VO
     */
    public List<FindHCEstimateListTotalVO> getTotalVoList() {
        return _totalVoList;
    }

    /**
     * HC見積一覧(制作費)取得VOを設定
     *
     * @param totalVoList HC見積一覧(制作費)取得VO
     */
    public void setTotalVoList(List<FindHCEstimateListTotalVO> totalVoList) {
        _totalVoList = totalVoList;
    }

    /**
     * HC見積一覧(見積案件)(制作原価)取得VOを取得
     *
     * @return HC見積一覧(見積案件)取得VO
     */
    public List<FindHCEstimateListItemVO> getCostItemVoList() {
        return _costItemVoList;
    }

    /**
     * HC見積一覧(見積案件)(制作原価)取得VOを設定
     *
     * @param costItemVoList HC見積一覧(見積案件)取得VO
     */
    public void setCostItemVoList(List<FindHCEstimateListItemVO> costItemVoList) {
        _costItemVoList = costItemVoList;
    }

    /**
     * HC見積一覧(見積案件)(制作費)取得VOを取得
     *
     * @return HC見積一覧(見積案件)取得VO
     */
    public List<FindHCEstimateListItemVO> getTotalItemVoList() {
        return _totalItemVoList;
    }

    /**
     * HC見積一覧(見積案件)(制作費)取得VOを設定
     *
     * @param totalItemVoList HC見積一覧(見積案件)取得VO
     */
    public void setTotalItemVoList(List<FindHCEstimateListItemVO> totalItemVoList) {
        _totalItemVoList = totalItemVoList;
    }

    /**
     *  変更確認データ(制作原価)取得VOを取得
     *
     * @return  変更確認データ(制作原価)取得VO
     */
    public List<FindHCEstimateListDiffVO> getCostDiffVoList() {
        return _costDiffVoList;
    }

    /**
     * 変更確認データ(制作原価)取得VOを設定
     *
     * @param costDiffVo 変更確認データ(制作原価)取得VO
     */
    public void setCostDiffVoList(List<FindHCEstimateListDiffVO> costDiffVo) {
        _costDiffVoList = costDiffVo;
    }

    /**
     *  変更確認データ(制作費)取得VOを取得
     *
     * @return  変更確認データ(制作費)取得VO
     */
    public List<FindHCEstimateListDiffTotalVO> getTotalDiffVoList() {
        return _totalDiffVoList;
    }

    /**
     * 変更確認データ(制作費)取得VOを設定
     *
     * @param totalDiffVo 変更確認データ(制作費)取得VO
     */
    public void setTotalDiffVoList(List<FindHCEstimateListDiffTotalVO> totalDiffVo) {
        _totalDiffVoList = totalDiffVo;
    }

    /**
     * セキュリティInfoVOリストを取得する
     * @return セキュリティInfoVOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * セキュリティInfoVOリストを設定する
     * @param secinfo セキュリティInfoVOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }
}
