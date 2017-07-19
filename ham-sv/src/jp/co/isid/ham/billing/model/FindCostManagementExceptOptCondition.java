package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 制作費取得条件(出力オプション以外)
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCostManagementExceptOptCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * フェイズ
     */
    private int _phase = 0;

    /**
     * 年月
     */
    private String _yearMonth = null;

    /**
     * 帳票コード
     */
    private String _reportCd = null;


    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
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
     * 帳票コード
     *
     * @return 帳票コード
     */
    public String getReportCd() {
        return _reportCd;
    }

    /**
     * 帳票コード
     *
     * @param reportCd 帳票コード
     */
    public void setReportCd(String reportCd) {
        _reportCd = reportCd;
    }

}
