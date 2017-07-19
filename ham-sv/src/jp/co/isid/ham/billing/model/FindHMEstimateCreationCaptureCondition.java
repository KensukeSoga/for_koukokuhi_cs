package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM見積作成(制作費取込)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateCreationCaptureCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private int _phase = 0;
    /** 現在のフェイズ */
    private int _currentPhase = 0;
    /** 年月 */
    private String _yearMonth = null;
    /** 電通車種コード */
    private String _dcarCd = null;
    /** 区分コード */
    private String _divCd = null;
    /** グループコード */
    private BigDecimal _groupCd = null;
    /** 種別判断フラグ */
    private String _classDiv = null;

    /**
     * フェイズを取得する
     * @return int フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     * @param phase int フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 現在のフェイズを取得する
     * @return int 現在のフェイズ
     */
    public int getCurrentPhase() {
        return _currentPhase;
    }

    /**
     * 現在のフェイズを設定する
     * @param currentPhase int 現在のフェイズ
     */
    public void setCurrentPhase(int currentPhase) {
        _currentPhase = currentPhase;
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
     * @param yearMonth String 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * 電通車種コードを取得する
     * @return String 電通車種コード
     */
    public String getDCarCd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     * @param dcarCd String 電通車種コード
     */
    public void setDCarCd(String dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * 区分コードを取得する
     * @return String 区分コード
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * 区分コードを設定する
     * @param divCd String 区分コード
     */
    public void setDivCd(String divCd) {
        _divCd = divCd;
    }

    /**
     * グループコードを取得する
     * @return BigDecimal グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * グループコードを設定する
     * @param groupCd BigDecimal グループコード
     */
    public void setGroupCd(BigDecimal groupCd) {
        _groupCd = groupCd;
    }

    /**
     * 種別判断フラグを取得する
     * @return String 種別判断フラグ
     */
    public String getClassDiv() {
        return _classDiv;
    }

    /**
     * 種別判断フラグを設定する
     * @param classDiv String 種別判断フラグ
     */
    public void setClassDiv(String classDiv) {
        _classDiv = classDiv;
    }

}
