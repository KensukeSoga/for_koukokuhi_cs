package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC見積一覧変更確認(制作費)データ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/21 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListDiffTotalCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 見積案件管理NO
     */
    private List<BigDecimal> _estSeqNoList;

    /**
     * フェイズ
     */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /**
     * 年月
     */
    private String _yearMonth = null;


    /**
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public List<BigDecimal> getEstSeqNoList() {
        return _estSeqNoList;
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param estSeqNo 見積案件管理NO
     */
    public void setEstSeqNoList(List<BigDecimal> estSeqNo) {
        _estSeqNoList = estSeqNo;
    }

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
}
