package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj48HmUserVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM請求書(制作)作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillReportResult extends AbstractServiceResult {

    /** HM請求書(見積案件) */
    private List<FindHMBillItemVO> _billItem = null;
    /** HM請求書(見積明細) */
    private List<FindHMBillDetailVO> _billDetail = null;
    /** HM請求書(CR制作費) */
    private List<FindHMBillCreateVO> _billCreate = null;
    /** HM請求書(制作費取込) */
    private List<FindHMBillCreationCaptureVO> _billCapture = null;
    /** HM請求書(CR制作費) */
    private List<FindHMBillCreationCrVO> _billCrCreation = null;
    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo = null;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn = null;
    /** HM部門 */
    private List<Mbj12CodeVO> _hmBumon = null;
    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29 = null;
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar;
    /** HM担当者マスタ */
    private List<Mbj48HmUserVO> _hmUser = null;
    /** 費用企画Noマスタ */
    private List<Mbj09HiyouVO> _hiyou = null;

    /**
     * HM請求書(見積案件)を取得する
     * @return List<FindHMBillItemVO> HM請求書(見積案件)
     */
    public List<FindHMBillItemVO> getBillItem() {
        return _billItem;
    }

    /**
     * HM請求書(見積案件)を設定する
     * @param vo List<FindHMBillItemVO> HM請求書(見積案件)
     */
    public void setBillItem(List<FindHMBillItemVO> vo) {
        _billItem = vo;
    }

    /**
     * HM請求書(見積明細)を取得する
     * @return List<FindEstimateDetailVO> HM請求書(見積明細)
     */
    public List<FindHMBillDetailVO> getBillDetail() {
        return _billDetail;
    }

    /**
     * HM請求書(見積明細)を設定する
     * @param vo List<FindEstimateDetailVO> HM請求書(見積明細)
     */
    public void setBillDetail(List<FindHMBillDetailVO> vo) {
        _billDetail = vo;
    }

    /**
     * HM請求書(CR制作費)を取得する
     * @return List<FindHMBillCreateVO> HM請求書(CR制作費)
     */
    public List<FindHMBillCreateVO> getBillCreate() {
        return _billCreate;
    }

    /**
     * HM請求書(CR制作費)を設定する
     * @param vo List<FindHMBillCreateVO> HM請求書(CR制作費)
     */
    public void setBillCreate(List<FindHMBillCreateVO> vo) {
        _billCreate = vo;
    }

    /**
     * HM請求書(制作費取込)を取得する
     * @return List<FindHMEstimateCreationCaptureVO> HM請求書(制作費取込)
     */
    public List<FindHMBillCreationCaptureVO> getBillCapture() {
        return _billCapture;
    }

    /**
     * HM請求書(制作費取込)を設定する
     * @param vo List<FindHMEstimateCreationCaptureVO> HM請求書(制作費取込))
     */
    public void setBillCapture(List<FindHMBillCreationCaptureVO> vo) {
        _billCapture = vo;
    }

    /**
     * HM請求書(CR制作費)を取得する
     * @return List<FindHMBillCreationCrVO> HM請求書(CR制作費)
     */
    public List<FindHMBillCreationCrVO> getBillCrCreateData() {
        return _billCrCreation;
    }

    /**
     * HM請求書(CR制作費)を設定する
     * @param vo List<FindHMBillCreationCrVO> HM請求書(CR制作費)
     */
    public void setBillCrCreateData(List<FindHMBillCreationCrVO> vo) {
        _billCrCreation = vo;
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
     * HM部門を取得する
     * @return List<Mbj12CodeVO> HM部門
     */
    public List<Mbj12CodeVO> getHmBumon() {
        return _hmBumon;
    }

    /**
     * HM部門を設定する
     * @param vo List<Mbj12CodeVO> HM部門
     */
    public void setHmBumon(List<Mbj12CodeVO> vo) {
        _hmBumon = vo;
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
     * HM担当者マスタを取得する
     * @return List<Mbj48HmUserVO> HM担当者マスタ
     */
    public List<Mbj48HmUserVO> getHmUser() {
        return _hmUser;
    }

    /**
     * HM担当者マスタを設定する
     * @param vo List<Mbj48HmUserVO> HM担当者マスタ
     */
    public void setHmUser(List<Mbj48HmUserVO> vo) {
        _hmUser = vo;
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
