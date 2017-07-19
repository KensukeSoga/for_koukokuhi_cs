package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * JASRAC請求明細書(ラジオタイム)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindJasracRadioTimeBillCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 開始年月 */
    private String  _startYearMonth = null;

    /** 終了年月 */
    private String _endYearMonth = null;

    /** コードリスト */
    private List<String> _codeList = null;

    /**
     * 開始年月を取得する
     * @return String 開始年月
     */
    public String getStartYearMonth() {
        return _startYearMonth;
    }

    /**
     * 開始年月を設定する
     * @param val String 開始年月
     */
    public void setStartYearMonth(String val) {
        _startYearMonth = val;
    }

    /**
     * 終了年月を取得する
     * @return String 終了年月
     */
    public String getEndYearMonth() {
        return _endYearMonth;
    }

    /**
     * 終了年月を設定する
     * @param val String 終了年月
     */
    public void setEndYearMonth(String val) {
        _endYearMonth = val;
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
