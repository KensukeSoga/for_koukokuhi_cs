package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM請求データ取得検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェーズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** コードリスト */
    private List<String> _codeList = null;

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
     * @param val BigDecimal フェーズ
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
     * コードリストを取得する
     * @return List<String> コードリスト
     */
    public List<String> getCodeList() {
        return _codeList;
    }

    /**
     * コードリストを設定する
     * @param val List<String> コードリスト
     */
    public void setCodeList(List<String> val) {
        _codeList = val;
    }

}
