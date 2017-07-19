package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 機能制御検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/17 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class StartUpCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** コード種別(フェイズ) */
    private String _codetypephase = null;

    /** コード種別(帳票ディレクトリ) */
    private String _codetypereport = null;

    /** ユーザ名 */
    private String _usernm = null;

    /** 担当者ID */
    private String _hamid = null;

    /** 更新プログラム */
    private String _updapl = null;

    /** 組織コード */
    private String _sikcd = null;

    /** 所属 */
    private String _affiliation = null;

    /** ログイン情報を作成するかどうか */
    private boolean _createLoginInfo = false;

    /**
     * コード種別(フェイズ)を取得する
     *
     * @return コード種別
     */
    public String getCodetypePhase() {
        return _codetypephase;
    }

    /**
     * コード種別(フェイズ)を設定する
     *
     * @param codetype コード種別
     */
    public void setCodetypePhase(String codetype) {
        this._codetypephase = codetype;
    }

    /**
     * コード種別(帳票)を取得する
     *
     * @return コード種別
     */
    public String getCodetypeReport() {
        return _codetypereport;
    }

    /**
     * コード種別(帳票)を設定する
     *
     * @param codetype コード種別
     */
    public void setCodetypeReport(String codetype) {
        this._codetypereport = codetype;
    }

    /**
     * ユーザー名を取得する
     *
     * @return ユーザー名
     */
    public String getUserNm() {
        return _usernm;
    }

    /**
     * ユーザー名を設定する
     *
     * @param usernm ユーザー名
     */
    public void setUserNm(String usernm) {
        _usernm = usernm;
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * 更新プログラムを設定する
     *
     * @param updapl 更新プログラム
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * 組織コードを設定する
     *
     * @param sikcd 組織コード
     */
    public void setSikcd(String sikcd) {
        _sikcd = sikcd;
    }

    /**
     * 所属を取得する
     *
     * @return 所属
     */
    public String getAffiliation() {
        return _affiliation;
    }

    /**
     * 所属を設定する
     *
     * @param affiliation 所属
     */
    public void setAffiliation(String affiliation) {
        _affiliation = affiliation;
    }

    /**
     * ログイン情報を作成するかどうかを取得する
     *
     * @return ログイン情報を作成するかどうか
     */
    public boolean getCreateLoginInfo() {
        return _createLoginInfo;
    }

    /**
     * ログイン情報を作成するかどうかを設定する
     *
     * @param createdLoginInfo ログイン情報を作成するかどうか
     */
    public void setCreateLoginInfo(boolean createLoginInfo) {
        _createLoginInfo = createLoginInfo;
    }
}
