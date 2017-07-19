package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC商品選択マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCItemSelectionMstrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 使用部門コード */
    private String _usebumoncd = null;

    /** 画面ID */
    private String _formId;

    /** 種別 */
    private String _funcType;

    /** HAM ID */
    private String _hamId = null;

    /**
     * 使用部門コードを取得する
     *
     * @return 使用部門コード
     */
    public String getUsebumoncd() {
        return _usebumoncd;
    }

    /**
     * 使用部門コードを設定する
     *
     * @param usebumoncd 使用部門コード
     */
    public void setUsebumoncd(String usebumoncd) {
        this._usebumoncd = usebumoncd;
    }

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

}
