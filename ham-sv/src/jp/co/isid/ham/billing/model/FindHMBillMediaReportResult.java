package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM請求書作成(媒体)検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillMediaReportResult extends AbstractServiceResult {

    /** 見積案件/見積明細 */
    private List<FindHMBillMediaReportVO> _hmBillMedia = null;
    /** 合計請求書出力情報 */
    private List<FindHMBillTotalMediaReportVO> _hmBillTotalMedia = null;
    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo = null;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn = null;
    /** HM部門 */
    private List<Mbj12CodeVO> _hmDiv = null;
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar = null;
    /** 費用企画Noマスタ */
    private List<Mbj09HiyouVO> _hiyou = null;

    /**
     * 見積案件/見積明細を取得する
     * @return List<FindHMBillMediaReportVO> 見積案件/見積明細
     */
    public List<FindHMBillMediaReportVO> getHMBillMedia() {
        return _hmBillMedia;
    }

    /**
     * 見積案件/見積明細を設定する
     * @param vo List<FindHMBillMediaReportVO> 見積案件/見積明細
     */
    public void setHMBillMedia(List<FindHMBillMediaReportVO> vo) {
        _hmBillMedia = vo;
    }

    /**
     * 合計請求書出力情報を取得する
     * @return List<FindHMBillTotalMediaReportVO> 合計請求書出力情報
     */
    public List<FindHMBillTotalMediaReportVO> getHMBillTotalMedia() {
        return _hmBillTotalMedia;
    }

    /**
     * 合計請求書出力情報を設定する
     * @param vo List<FindHMBillTotalMediaReportVO> 合計請求書出力情報
     */
    public void setHMBillTotalMedia(List<FindHMBillTotalMediaReportVO> vo) {
        _hmBillTotalMedia = vo;
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
    public List<Mbj12CodeVO> getHmDiv() {
        return _hmDiv;
    }

    /**
     * HM部門を設定する
     * @param vo List<Mbj12CodeVO> HM部門
     */
    public void setHmDiv(List<Mbj12CodeVO> vo) {
        _hmDiv = vo;
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
