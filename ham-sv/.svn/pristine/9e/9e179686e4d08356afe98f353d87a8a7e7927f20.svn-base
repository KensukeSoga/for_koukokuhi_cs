package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj06HcBumonVO;
import jp.co.isid.ham.common.model.Mbj07HcUserVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC見積作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateCreationResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** コードマスタ */
    private List<Mbj12CodeVO> _code;

    /** 部門マスタ */
    private List<Mbj06HcBumonVO> _bumon;

    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar;

    /** 請求グループマスタ */
    private List<Mbj26BillGroupVO> _group;

    /** HCユーザマスタ */
    private List<Mbj07HcUserVO> _user;

    /** HC見積一覧(見積案件) */
    private List<FindHCEstimateListItemVO> _item;

    /** 変更確認データ(制作原価) */
    private List<FindHCEstimateListDiffVO> _costDiffVoList;

    /** 変更確認データ(制作費) */
    private List<FindHCEstimateListDiffTotalVO> _totalDiffVoList;

    /** 見積明細 */
    private List<FindEstimateDetailVO> _estDetail;

    /** 見積案件CR制作費 */
    private List<FindEstimateCreateVO> _estCreate;

    /** HC見積作成(制作費取込) */
    private List<FindHCEstimateCreationCaptureVO> _capture;

    /** HC商品マスタ */
    private List<FindHCProductVO> _product;

    /** CR予算費目マスタ */
    private List<Mbj16CrExpenceVO> _crExpence;

    /** CR制作費 */
    private List<FindHCEstimateCreationCrVO> _crCreateData;

    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29;

    /** 一覧表示パターン */
    private List<Tbj30DisplayPatternVO> _dp;

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
     * コードマスタを取得する
     *
     * @return コードマスタ
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * コードマスタを設定する
     *
     * @param code コードマスタ
     */
    public void setCode(List<Mbj12CodeVO> code) {
        _code = code;
    }

    /**
     * 部門マスタを取得する
     *
     * @return 部門マスタ
     */
    public List<Mbj06HcBumonVO> getBumon() {
        return _bumon;
    }

    /**
     * 部門マスタを設定する
     *
     * @param bumon 部門マスタ
     */
    public void setBumon(List<Mbj06HcBumonVO> bumon) {
        _bumon = bumon;
    }

    /**
     * カレンダーマスタを取得する
     *
     * @return カレンダーマスタ
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * カレンダーマスタを設定する
     *
     * @param calendar カレンダーマスタ
     */
    public void setCalendar(List<Mbj21CalendarVO> calendar) {
        _calendar = calendar;
    }

    /**
     * 請求グループマスタを取得する
     *
     * @return 請求グループマスタ
     */
    public List<Mbj26BillGroupVO> getGroup() {
        return _group;
    }

    /**
     * 請求グループマスタを設定する
     *
     * @param group 請求グループマスタ
     */
    public void setGroup(List<Mbj26BillGroupVO> group) {
        _group = group;
    }

    /**
     * HCユーザマスタを取得する
     *
     * @return HCユーザマスタ
     */
    public List<Mbj07HcUserVO> getUser() {
        return _user;
    }

    /**
     * HCユーザマスタを取得する
     *
     * @param user HCユーザマスタ
     */
    public void setUser(List<Mbj07HcUserVO> user) {
        _user = user;
    }

    /**
     * HC見積一覧(見積案件)を取得する
     *
     * @return HC見積一覧(見積案件)
     */
    public List<FindHCEstimateListItemVO> getItem() {
        return _item;
    }

    /**
     * HC見積一覧(見積案件)を設定する
     *
     * @param item HC見積一覧(見積案件)
     */
    public void setItem(List<FindHCEstimateListItemVO> item) {
        _item = item;
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
     * 見積明細を取得する
     *
     * @return 見積明細
     */
    public List<FindEstimateDetailVO> getEstDetail() {
        return _estDetail;
    }

    /**
     * 見積明細を設定する
     *
     * @param estDetail 見積明細
     */
    public void setEstDetail(List<FindEstimateDetailVO> estDetail) {
        _estDetail = estDetail;
    }

    /**
     * 見積案件CR制作費を取得する
     *
     * @return 見積案件CR制作費
     */
    public List<FindEstimateCreateVO> getEstCreate() {
        return _estCreate;
    }

    /**
     * 見積案件CR制作費を設定する
     *
     * @param estCreate 見積案件CR制作費
     */
    public void setEstCreate(List<FindEstimateCreateVO> estCreate) {
        _estCreate = estCreate;
    }

    /**
     * HC見積作成(制作費取込)を取得する
     *
     * @return HC見積作成(制作費取込)
     */
    public List<FindHCEstimateCreationCaptureVO> getCapture() {
        return _capture;
    }

    /**
     * HC見積作成(制作費取込)を設定する
     *
     * @param capture HC見積作成(制作費取込)
     */
    public void setCapture(List<FindHCEstimateCreationCaptureVO> capture) {
        _capture = capture;
    }

    /**
     * HC商品マスタを取得する
     *
     * @return HC商品マスタ
     */
    public List<FindHCProductVO> getProduct() {
        return _product;
    }

    /**
     * HC商品マスタを設定する
     *
     * @param product HC商品マスタ
     */
    public void setProduct(List<FindHCProductVO> product) {
        _product = product;
    }

    /**
     * CR予算費目マスタを取得する
     *
     * @return CR予算費目マスタ
     */
    public List<Mbj16CrExpenceVO> getCrExpence() {
        return _crExpence;
    }

    /**
     * CR予算費目マスタを設定する
     *
     * @param crExpence CR予算費目マスタ
     */
    public void setCrExpence(List<Mbj16CrExpenceVO> crExpence) {
        _crExpence = crExpence;
    }

    /**
     * CR制作費を取得する
     *
     * @return CR制作費
     */
    public List<FindHCEstimateCreationCrVO> getCrCreateData() {
        return _crCreateData;
    }

    /**
     * CR制作費を設定する
     *
     * @param crCreateData CR制作費
     */
    public void setCrCreateData(List<FindHCEstimateCreationCrVO> crCreateData) {
        _crCreateData = crCreateData;
    }

    /**
     * 全社コードマスタを取得する
     *
     * @return 全社コードマスタ
     */
    public List<RepaVbjaMeu29CcVO>  getMenu29() {
        return _menu29;
    }

    /**
     * 全社コードマスタを設定する
     *
     * @param menu29 全社コードマスタ
     */
    public void setMenu29(List<RepaVbjaMeu29CcVO> menu29) {
        _menu29 = menu29;
    }

    /**
     * 一覧表示パターンを取得する
     *
     * @return 一覧表示パターン
     */
    public List<Tbj30DisplayPatternVO> getDisplayPattern() {
        return _dp;
    }

    /**
     * 一覧表示パターンを設定する
     *
     * @param dp 一覧表示パターン
     */
    public void setDisplayPattern(List<Tbj30DisplayPatternVO> dp) {
        _dp = dp;
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
