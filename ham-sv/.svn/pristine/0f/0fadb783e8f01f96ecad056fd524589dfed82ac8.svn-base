package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 見積、見積CSVファイル作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/6 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstimateReportResult extends AbstractServiceResult {

    /** HC見積一覧(見積案件) */
    private List<FindHCEstimateListItemVO> _item;

    /** 見積明細 */
    private List<FindEstimateDetailVO> _estDetail;

    /** 見積案件CR制作費 */
    private List<FindEstimateCreateVO> _estCreate;

    /** HC見積作成(制作費取込) */
    private List<FindHCEstimateCreationCaptureVO> _capture;

    /** CR制作費 */
    private List<FindHCEstimateCreationCrVO> _crCreateData;

    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add Start */
    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn;
    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29;
    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add End */

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

    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add Start */
    /**
     * 会社情報を取得する
     * @return List<Mbj12CodeVO> 会社情報
     */
    public List<Mbj12CodeVO> getCompanyInfo() {
        return _companyInfo;
    }

    /**
     * 会社情報を設定する
     * @param vo List<Mbj12CodeVO> 会社情報
     */
    public void setCompanyInfo(List<Mbj12CodeVO> vo) {
        _companyInfo = vo;
    }

    /**
     * 仕入消費税計算区分を取得する
     * @return List<Mbj12CodeVO> 仕入消費税計算区分
     */
    public List<Mbj12CodeVO> getCalKbn() {
        return _calKbn;
    }

    /**
     * 仕入消費税計算区分を設定する
     * @param vo List<Mbj12CodeVO> 仕入消費税計算区分
     */
    public void setCalKbn(List<Mbj12CodeVO> vo) {
        _calKbn = vo;
    }

    /**
     * 全社マスタを取得する
     * @return List<RepaVbjaMeu29CcVO> 全社マスタ
     */
    public List<RepaVbjaMeu29CcVO> getMenu29() {
        return _menu29;
    }

    /**
     * 全社マスタを設定する
     * @param vo List<RepaVbjaMeu29CcVO> 全社マスタ
     */
    public void setMenu29(List<RepaVbjaMeu29CcVO> vo) {
        _menu29 = vo;
    }
    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add End */

}
