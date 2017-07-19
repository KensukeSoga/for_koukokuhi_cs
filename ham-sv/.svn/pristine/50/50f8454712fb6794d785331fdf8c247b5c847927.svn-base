package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM見積書作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateReportResult extends AbstractServiceResult {

    /** HM見積書(見積案件) */
    private List<FindHMEstimateItemVO> _estItem = null;
    /** HM見積書(見積明細) */
    private List<FindHMEstimateDetailVO> _estDetail = null;
    /** HM見積書(見積案件CR制作費) */
    private List<FindHMEstimateCreateVO> _estCreate = null;
    /** HM見積書(制作費取込) */
    private List<FindHMEstimateCreationCaptureVO> _estCapture = null;
    /** HM見積書(CR制作費) */
    private List<FindHMEstimateCreationCrVO> _estCrCreation = null;
    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo = null;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn = null;
    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29 = null;
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar = null;
    /** 費用企画Noマスタ */
    private List<Mbj09HiyouVO> _hiyou = null;

    /**
     * HM見積書(見積案件)を取得する
     * @return List<FindHCEstimateListItemVO> HM見積書(見積案件)
     */
    public List<FindHMEstimateItemVO> getEstItem() {
        return _estItem;
    }

    /**
     * HM見積書(見積案件)を設定する
     * @param vo List<FindHCEstimateListItemVO> HM見積書(見積案件)
     */
    public void setEstItem(List<FindHMEstimateItemVO> vo) {
        _estItem = vo;
    }

    /**
     * HM見積書(見積明細)を取得する
     * @return List<FindEstimateDetailVO> HM見積書(見積明細)
     */
    public List<FindHMEstimateDetailVO> getEstDetail() {
        return _estDetail;
    }

    /**
     * HM見積書(見積明細)を設定する
     * @param vo List<FindEstimateDetailVO> HM見積書(見積明細)
     */
    public void setEstDetail(List<FindHMEstimateDetailVO> vo) {
        _estDetail = vo;
    }

    /**
     * HM見積書(見積案件CR制作費)を取得する
     * @return List<FindHMEstimateCreateVO> HM見積書(見積案件CR制作費)
     */
    public List<FindHMEstimateCreateVO> getEstCreate() {
        return _estCreate;
    }

    /**
     * HM見積書(見積案件CR制作費)を設定する
     * @param vo List<FindHMEstimateCreateVO> HM見積書(見積案件CR制作費)
     */
    public void setEstCreate(List<FindHMEstimateCreateVO> vo) {
        _estCreate = vo;
    }

    /**
     * HM見積書(制作費取込)を取得する
     * @return List<FindHMEstimateCreationCaptureVO> HM見積書(制作費取込)
     */
    public List<FindHMEstimateCreationCaptureVO> getEstCapture() {
        return _estCapture;
    }

    /**
     * HM見積書(制作費取込)を設定する
     * @param vo List<FindHMEstimateCreationCaptureVO> HM見積書(制作費取込)
     */
    public void setEstCapture(List<FindHMEstimateCreationCaptureVO> vo) {
        _estCapture = vo;
    }

    /**
     * HM見積書(CR制作費)を取得する
     * @return List<FindHMEstimateCreationCrVO> HM見積書(CR制作費)
     */
    public List<FindHMEstimateCreationCrVO> getEstCrCreateData() {
        return _estCrCreation;
    }

    /**
     * HM見積書(CR制作費)を設定する
     * @param vo List<FindHMEstimateCreationCrVO> HM見積書(CR制作費)
     */
    public void setEstCrCreateData(List<FindHMEstimateCreationCrVO> vo) {
        _estCrCreation = vo;
    }

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

    /**
     * カレンダーマスタを取得する
     * @return List<Mbj21CalendarVO> カレンダーマスタ
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * カレンダーマスタを設定する
     * @param vo List<Mbj21CalendarVO> カレンダーマスタ
     */
    public void setCalendar(List<Mbj21CalendarVO> vo) {
        _calendar = vo;
    }

    /**
     * 費用企画Noマスタを取得する
     * @return List<Mbj09HiyouVO> 費用企画Noマスタ
     */
    public List<Mbj09HiyouVO> getHiyou() {
        return _hiyou;
    }

    /**
     * 費用企画Noマスタを設定する
     * @param vo List<Mbj09HiyouVO> 費用企画Noマスタ
     */
    public void setHiyou(List<Mbj09HiyouVO> vo) {
        _hiyou = vo;
    }

}
