package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

/**
 * <P>
 * ラジオ番組一覧表示情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 担当者ID */
    private String _hamid = null;
    /** ユーザ種別 */
    private String _userType = null;
    /** 画面ID */
    private String _formId = null;
    /** 機能種別 */
    private String _functionType = null;
    /** 一覧ID */
    private String _viewId = null;
    /** 局コード */
    private String _kksikognzuntcd = null;
    /** セキュリティコード */
    private String _securitycd = null;
    /** コードリスト */
    private List<String> _codeList = null;

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPhase(BigDecimal val) {
        _phase = val;
    }

    /**
     * 担当者IDを取得する
     * @return String 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     * @param val String 担当者ID
     */
    public void setHamid(String val) {
        _hamid = val;
    }

    /**
     * ユーザ種別を取得する
     * @return String ユーザ種別
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ユーザ種別を設定する
     * @param val String ユーザ種別
     */
    public void setUserType(String val) {
        _userType = val;
    }

    /**
     * 画面IDを取得する
     * @return String 画面ID
     */
    public String getFormID() {
        return _formId;
    }

    /**
     * 画面IDを設定する
     * @param val String 画面ID
     */
    public void setFormID(String val) {
        _formId = val;
    }

    /**
     * 機能種別を取得する
     * @return String 機能種別
     */
    public String getFunctionType() {
        return _functionType;
    }

    /**
     * 機能種別を設定する
     * @param val String 機能種別
     */
    public void setFunctionType(String val) {
        _functionType = val;
    }

    /**
     * 一覧IDを取得する
     * @return String 一覧ID
     */
    public String getViewID() {
        return _viewId;
    }

    /**
     * 一覧IDを設定する
     * @param val String 一覧ID
     */
    public void setViewID(String val) {
        _viewId = val;
    }

    /**
     * 局コードを取得する
     * @return String 局コード
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     * @param val String 局コード
     */
    public void setKksikognzuntcd(String val) {
        _kksikognzuntcd = val;
    }

    /**
     * セキュリティコードを取得する
     * @return String セキュリティコード
     */
    public String getSecuritycd() {
        return _securitycd;
    }

    /**
     * セキュリティコードを設定する
     * @param val String セキュリティコード
     */
    public void setSecuritycd(String val) {
        _securitycd = val;
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