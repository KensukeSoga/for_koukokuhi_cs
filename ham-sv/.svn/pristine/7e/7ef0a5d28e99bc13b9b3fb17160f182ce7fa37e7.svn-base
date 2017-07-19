package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/20 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateCreationCrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** 現在のフェイズ */
    private int _currentPhase = 0;

    /** 年月 */
    private String _yearMonth;

    /** 電通車種コード */
    private String _dcarCd;

    /** 区分コード */
    private String _divCd;

    /** グループコード */
    private BigDecimal _groupCd;

    /** 種別判断フラグ */
    private String _classDiv;


    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * 現在のフェイズを取得する
     *
     * @return 現在のフェイズ
     */
    public int getCurrentPhase() {
        return _currentPhase;
    }

    /**
     * 現在のフェイズを設定する
     *
     * @param currentPhase 現在のフェイズ
     */
    public void setCurrentPhase(int currentPhase) {
        _currentPhase = currentPhase;
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarCd 電通車種コード
     */
    public void setDCarCd(String dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * 区分コードを取得する
     *
     * @return 区分コード
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * 区分コードを設定する
     *
     * @param divCd 区分コード
     */
    public void setDivCd(String divCd) {
        _divCd = divCd;
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * グループコードを設定する
     *
     * @param groupCd グループコード
     */
    public void setGroupCd(BigDecimal groupCd) {
        _groupCd = groupCd;
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getClassDiv() {
        return _classDiv;
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param classDiv 種別判断フラグ
     */
    public void setClassDiv(String classDiv) {
        _classDiv = classDiv;
    }

}
