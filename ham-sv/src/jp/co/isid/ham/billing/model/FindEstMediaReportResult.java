package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 見積、見積CSVファイル作成(媒体)検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/5/8 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstMediaReportResult extends AbstractServiceResult {

    /** 見積案件/見積明細 */
    private List<FindEstItemDtlVO> _estItemDtl;

    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add Start */
    /** 会社情報 */
    private List<Mbj12CodeVO> _companyInfo;
    /** 仕入消費税計算区分 */
    private List<Mbj12CodeVO> _calKbn;
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar;
    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add End */

    /**
     * 見積案件/見積明細を取得する
     * @return 見積案件/見積明細
     */
    public List<FindEstItemDtlVO> getEstItemDtl() {
        return _estItemDtl;
    }

    /**
     * 見積案件/見積明細を設定する
     * @param estItemDtl 見積案件/見積明細
     */
    public void setEstItemDtl(List<FindEstItemDtlVO> estItemDtl) {
        _estItemDtl = estItemDtl;
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
    /* 2015/08/31 請求業務変更対応 S.Fujimoto Add End */

}
