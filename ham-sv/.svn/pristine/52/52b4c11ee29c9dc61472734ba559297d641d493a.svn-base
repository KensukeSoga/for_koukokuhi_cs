package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdTime2AccountBookCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェーズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** 開始日付 */
    private String _startDate = null;
    /** 終了日付 */
    private String _endDate = null;
    /** データ更新者 */
    private String _updNm = null;
    /** 更新プログラム */
    private String _updApl = null;
    /** 更新担当者ID */
    private String _updId = null;

    /**
     * フェーズを取得する
     * @return BigDecimal フェーズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェーズを設定する
     * @param val String フェーズ
     */
    public void setPhase(BigDecimal val) {
        _phase = val;
    }

    /**
     * 年月を取得する
     * @return String 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     * @param val String 年月
     */
    public void setYearMonth(String val) {
        _yearMonth = val;
    }

    /**
     * 開始日付を取得する
     * @return String 開始日付
     */
    public String getStartDate() {
        return _startDate;
    }

    /**
     * 開始日付を設定する
     * @param val String 開始日付
     */
    public void setStartDate(String val) {
        _startDate = val;
    }

    /**
     * 終了日付を取得する
     * @return String 終了日付
     */
    public String getEndDate() {
        return _endDate;
    }

    /**
     * 終了日付を設定する
     * @param val String 終了日付
     */
    public void setEndDate(String val) {
        _endDate = val;
    }

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUpdNm() {
        return _updNm;
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUpdNm(String val) {
        _updNm = val;
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUpdApl() {
        return _updApl;
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUpdApl(String val) {
        _updApl = val;
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者
     */
    public String getUpdId() {
        return _updId;
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者
     */
    public void setUpdId(String val) {
        _updId = val;
    }

}