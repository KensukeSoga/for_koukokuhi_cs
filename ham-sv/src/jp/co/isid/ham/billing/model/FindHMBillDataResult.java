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
 * HM請求データ検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillDataResult extends AbstractServiceResult {

    /** HM請求データ */
    private List<FindHMBillDataVO> _billData = null;
    /**
     * コードマスタ
     *  - 仕入消費税計算区分、HM担当部門、請求データ作成情報、請求データ出力項目
     */
    private List<Mbj12CodeVO> _code = null;
    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29 = null;
    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar;
    /** 費用企画Noマスタ */
    private List<Mbj09HiyouVO> _hiyou;
    /** HM担当者マスタ */
    private List<Mbj48HmUserVO> _hmUser = null;

    /**
     * HM請求データを取得する
     * @return List<FindHMBillDataVO> HM請求データ
     */
    public List<FindHMBillDataVO> getBillData() {
        return _billData;
    }

    /**
     * HM請求データを設定する
     * @param vo List<FindHMBillDataVO> HM請求データ
     */
    public void setBillData(List<FindHMBillDataVO> vo) {
        _billData = vo;
    }

    /**
     * コードマスタを取得する
     * @return List<Mbj12CodeVO> コードマスタ
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * コードマスタを設定する
     * @param vo List<Mbj12CodeVO> 仕入消費税計算区分
     */
    public void setCode(List<Mbj12CodeVO> vo) {
        _code = vo;
    }

    /**
     * 全社コードマスタを取得する
     * @return List<RepaVbjaMeu29CcVO> 全社コードマスタ
     */
    public List<RepaVbjaMeu29CcVO> getMenu29() {
        return _menu29;
    }

    /**
     * 全社コードマスタを設定する
     * @param vo List<RepaVbjaMeu29CcVO> 全社コードマスタ
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

}
