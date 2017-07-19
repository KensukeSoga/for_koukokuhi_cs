package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC媒体費作成検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCMediaCreationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 画面ID */
    private String _formId;

    /** 種別 */
    private String _funcType;

    /** HAM ID */
    private String _hamId = null;

    /** コードタイプ */
    private List<String> _codeType = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 年月 */
    private String _yearMonth;

    /** 見積種別 */
    private String _estimateClass = null;

    /** データ更新者 */
    private String _updNm = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** セキュリティコード */
    private String _securitycd = null;


    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormId() {
        return _formId;
    }

    /**
     * 画面IDを設定する
     *
     * @param formID 画面ID
     */
    public void setFormId(String formId) {
        _formId = formId;
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getFuncType() {
        return _funcType;
    }

    /**
     * 種別を設定する
     *
     * @param funcid 種別
     */
    public void setFuncType(String functype) {
        _funcType = functype;
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
     * コードタイプを取得します
     *
     * @return コードタイプ
     */
    public List<String> getCodeType() {
        return _codeType;
    }

    /**
     * コードタイプを設定します
     *
     * @param codeType コードタイプ
     */
    public void setCodeType(List<String> codeType) {
        _codeType = codeType;
    }

    /**
     * フェイズを取得します
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定します
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * 年月を取得します
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定します
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * 見積種別を取得する
     *
     * @return 見積種別
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別を設定する
     *
     * @param estimateClass 見積種別
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUpdNm() {
        return _updNm;
    }

    /**
     * データ更新者を設定する
     *
     * @param updNm データ更新者
     */
    public void setUpdNm(String updNm) {
        _updNm = updNm;
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     *
     * @param kksikognzuntcd 局コード
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ユーザ種別を設定する
     *
     * @param usertype ユーザ種別
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * セキュリティコードを取得する
     *
     * @return セキュリティコード
     */
    public String getSecuritycd()
    {
        return _securitycd;
    }

    /**
     * セキュリティコードを設定する
     *
     * @param securitycd セキュリティコード
     */
    public void setSecuritycd(String securitycd)
    {
        this._securitycd = securitycd;
    }
}
