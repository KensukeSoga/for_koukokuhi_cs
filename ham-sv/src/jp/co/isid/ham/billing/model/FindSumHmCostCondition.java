package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * H新モデルコスト合計検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindSumHmCostCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 年月
     */
    private String _yearMonth = null;

    /**
     * 電通車種コード
     */
    private List<String> _dcarCd;

    /**
     * 媒体コード
     */
    private List<String> _mediaCd;


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
    public List<String> getDCarCd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarCd 電通車種コード
     */
    public void setDCarCd(List<String> dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public List<String> getMediaCd() {
        return _mediaCd;
    }

    /**
     * 媒体コードを設定する
     *
     * @param mediaCd 媒体コード
     */
    public void setMediaCd(List<String> mediaCd) {
        _mediaCd = mediaCd;
    }
}
