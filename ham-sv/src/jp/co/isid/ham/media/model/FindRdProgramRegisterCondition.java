package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

/**
 * <P>
 * ラジオ番組登録表示情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ラジオ番組SEQNO */
    private BigDecimal _rdProgramSeqNo = BigDecimal.valueOf(0);
    /** フェイズ開始日 */
    private String _phaseStart = null;
    /** フェイズ終了日 */
    private String _phaseEnd = null;
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
     * ラジオ番組SEQNOを取得する
     * @return BigDecimal ラジオ番組SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRdProgramSeqNo() {
        return _rdProgramSeqNo;
    }

    /**
     * ラジオ番組SEQNOを設定する
     * @param val BigDecimal ラジオ番組SEQNO
     */
    public void setRdProgramSeqNo(BigDecimal val) {
        _rdProgramSeqNo = val;
    }

    /**
     * フェイズ開始日を取得する
     * @return Date フェイズ開始日
     */
    public String getPhaseStart() {
        return _phaseStart;
    }

    /**
     * フェイズ開始日を設定する
     * @param val Date フェイズ開始日
     */
    public void setPhaseStart(String val) {
        _phaseStart = val;
    }

    /**
     * フェイズ終了日を取得する
     * @return Date フェイズ終了日
     */
    public String getPhaseEnd() {
        return _phaseEnd;
    }

    /**
     * フェイズ終了日を設定する
     * @param val Date フェイズ終了日
     */
    public void setPhaseEnd(String val) {
        _phaseEnd = val;
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