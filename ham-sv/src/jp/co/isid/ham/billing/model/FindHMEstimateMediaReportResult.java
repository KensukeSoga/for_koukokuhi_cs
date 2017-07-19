package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM見積書、請求書作成(媒体)検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/01/27 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateMediaReportResult extends AbstractServiceResult {

    /** 見積案件/見積明細 */
    private List<FindHMEstimateMediaReportVO> _hmEstimateMedia;

    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo = null;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn = null;
    /* 2016/01/22 請求業務変更対応 K.Soga ADD Start */
    /** HM部門 */
    private List<Mbj12CodeVO> _hmDiv = null;
    /* 2016/01/22 請求業務変更対応 K.Soga ADD End */
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar = null;
    /** 費用企画Noマスタ */
    private List<Mbj09HiyouVO> _hiyou = null;

    /**
     * 見積案件/見積明細を取得する
     * @return List<FindHMEstimateMediaVO> 見積案件/見積明細
     */
    public List<FindHMEstimateMediaReportVO> getHMEstimateMedia() {
        return _hmEstimateMedia;
    }

    /**
     * 見積案件/見積明細を設定する
     * @param vo List<FindHMEstimateMediaVO> 見積案件/見積明細
     */
    public void setHMEstimateMedia(List<FindHMEstimateMediaReportVO> vo) {
        _hmEstimateMedia = vo;
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

    /* 2016/01/22 請求業務変更対応 K.Soga ADD Start */
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
    /* 2016/01/22 請求業務変更対応 K.Soga ADD End */

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