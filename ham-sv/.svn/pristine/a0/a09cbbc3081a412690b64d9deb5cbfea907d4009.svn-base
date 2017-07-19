package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC見積一覧(制作原価)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListCostCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * フェイズ
     */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /**
     * 年月
     */
    private String _yearMonth = null;

    /**
     * 種別判断フラグ
     */
    private String _classDiv = null;

    /**
     * HAM ID
     */
    private String _hamId = null;

    /**
     * ユーザー種別
     */
    private String _userType = null;


    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
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

    /**
     * HAM IDを取得する
     *
     * @return HAM ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * HAM IDを設定する
     *
     * @param hamId HAM ID
     */
    public void setHamId(String hamId) {
        _hamId = hamId;
    }

    /**
     * ユーザー種別を取得する
     *
     * @return ユーザー種別
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ユーザー種別を設定する
     *
     * @param userType ユーザー種別
     */
    public void setUserType(String userType) {
        _userType = userType;
    }
}
