package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 稼働ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj28WorkLogCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データ作成日時 */
    private Date _crtdate = null;

    /** 担当者ID(ESQID) */
    private String _hamid = null;

    /** 担当者名 */
    private String _hamnm = null;

    /** 組織コード（本部） */
    private String _sikcdhonb = null;

    /** 本部表示名（漢字） */
    private String _siknmhonb = null;

    /** 組織コード（局） */
    private String _sikcdkyk = null;

    /** 局表示名（漢字） */
    private String _siknmkyk = null;

    /** 組織コード（室） */
    private String _sikcdsitu = null;

    /** 室表示名（漢字） */
    private String _siknmsitu = null;

    /** 組織コード（部） */
    private String _sikcdbu = null;

    /** 部表示名（漢字） */
    private String _siknmbu = null;

    /** 組織コード（課） */
    private String _sikcdka = null;

    /** 課表示名（漢字） */
    private String _siknmka = null;

    /** 画面ID */
    private String _formid = null;

    /** 画面名 */
    private String _formnm = null;

    /** 機能ID */
    private String _knoid = null;

    /** 機能名 */
    private String _knonm = null;

    /** 操作ID */
    private String _dsmid = null;

    /** 操作名 */
    private String _dsmnm = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj28WorkLogCondition() {
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * データ作成日時を設定する
     *
     * @param crtdate データ作成日時
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * 担当者ID(ESQID)を取得する
     *
     * @return 担当者ID(ESQID)
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者ID(ESQID)を設定する
     *
     * @param hamid 担当者ID(ESQID)
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getHamnm() {
        return _hamnm;
    }

    /**
     * 担当者名を設定する
     *
     * @param hamnm 担当者名
     */
    public void setHamnm(String hamnm) {
        this._hamnm = hamnm;
    }

    /**
     * 組織コード（本部）を取得する
     *
     * @return 組織コード（本部）
     */
    public String getSikcdhonb() {
        return _sikcdhonb;
    }

    /**
     * 組織コード（本部）を設定する
     *
     * @param sikcdhonb 組織コード（本部）
     */
    public void setSikcdhonb(String sikcdhonb) {
        this._sikcdhonb = sikcdhonb;
    }

    /**
     * 本部表示名（漢字）を取得する
     *
     * @return 本部表示名（漢字）
     */
    public String getSiknmhonb() {
        return _siknmhonb;
    }

    /**
     * 本部表示名（漢字）を設定する
     *
     * @param siknmhonb 本部表示名（漢字）
     */
    public void setSiknmhonb(String siknmhonb) {
        this._siknmhonb = siknmhonb;
    }

    /**
     * 組織コード（局）を取得する
     *
     * @return 組織コード（局）
     */
    public String getSikcdkyk() {
        return _sikcdkyk;
    }

    /**
     * 組織コード（局）を設定する
     *
     * @param sikcdkyk 組織コード（局）
     */
    public void setSikcdkyk(String sikcdkyk) {
        this._sikcdkyk = sikcdkyk;
    }

    /**
     * 局表示名（漢字）を取得する
     *
     * @return 局表示名（漢字）
     */
    public String getSiknmkyk() {
        return _siknmkyk;
    }

    /**
     * 局表示名（漢字）を設定する
     *
     * @param siknmkyk 局表示名（漢字）
     */
    public void setSiknmkyk(String siknmkyk) {
        this._siknmkyk = siknmkyk;
    }

    /**
     * 組織コード（室）を取得する
     *
     * @return 組織コード（室）
     */
    public String getSikcdsitu() {
        return _sikcdsitu;
    }

    /**
     * 組織コード（室）を設定する
     *
     * @param sikcdsitu 組織コード（室）
     */
    public void setSikcdsitu(String sikcdsitu) {
        this._sikcdsitu = sikcdsitu;
    }

    /**
     * 室表示名（漢字）を取得する
     *
     * @return 室表示名（漢字）
     */
    public String getSiknmsitu() {
        return _siknmsitu;
    }

    /**
     * 室表示名（漢字）を設定する
     *
     * @param siknmsitu 室表示名（漢字）
     */
    public void setSiknmsitu(String siknmsitu) {
        this._siknmsitu = siknmsitu;
    }

    /**
     * 組織コード（部）を取得する
     *
     * @return 組織コード（部）
     */
    public String getSikcdbu() {
        return _sikcdbu;
    }

    /**
     * 組織コード（部）を設定する
     *
     * @param sikcdbu 組織コード（部）
     */
    public void setSikcdbu(String sikcdbu) {
        this._sikcdbu = sikcdbu;
    }

    /**
     * 部表示名（漢字）を取得する
     *
     * @return 部表示名（漢字）
     */
    public String getSiknmbu() {
        return _siknmbu;
    }

    /**
     * 部表示名（漢字）を設定する
     *
     * @param siknmbu 部表示名（漢字）
     */
    public void setSiknmbu(String siknmbu) {
        this._siknmbu = siknmbu;
    }

    /**
     * 組織コード（課）を取得する
     *
     * @return 組織コード（課）
     */
    public String getSikcdka() {
        return _sikcdka;
    }

    /**
     * 組織コード（課）を設定する
     *
     * @param sikcdka 組織コード（課）
     */
    public void setSikcdka(String sikcdka) {
        this._sikcdka = sikcdka;
    }

    /**
     * 課表示名（漢字）を取得する
     *
     * @return 課表示名（漢字）
     */
    public String getSiknmka() {
        return _siknmka;
    }

    /**
     * 課表示名（漢字）を設定する
     *
     * @param siknmka 課表示名（漢字）
     */
    public void setSiknmka(String siknmka) {
        this._siknmka = siknmka;
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * 画面IDを設定する
     *
     * @param formid 画面ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * 画面名を取得する
     *
     * @return 画面名
     */
    public String getFormnm() {
        return _formnm;
    }

    /**
     * 画面名を設定する
     *
     * @param formnm 画面名
     */
    public void setFormnm(String formnm) {
        this._formnm = formnm;
    }

    /**
     * 機能IDを取得する
     *
     * @return 機能ID
     */
    public String getKnoid() {
        return _knoid;
    }

    /**
     * 機能IDを設定する
     *
     * @param knoid 機能ID
     */
    public void setKnoid(String knoid) {
        this._knoid = knoid;
    }

    /**
     * 機能名を取得する
     *
     * @return 機能名
     */
    public String getKnonm() {
        return _knonm;
    }

    /**
     * 機能名を設定する
     *
     * @param knonm 機能名
     */
    public void setKnonm(String knonm) {
        this._knonm = knonm;
    }

    /**
     * 操作IDを取得する
     *
     * @return 操作ID
     */
    public String getDsmid() {
        return _dsmid;
    }

    /**
     * 操作IDを設定する
     *
     * @param dsmid 操作ID
     */
    public void setDsmid(String dsmid) {
        this._dsmid = dsmid;
    }

    /**
     * 操作名を取得する
     *
     * @return 操作名
     */
    public String getDsmnm() {
        return _dsmnm;
    }

    /**
     * 操作名を設定する
     *
     * @param dsmnm 操作名
     */
    public void setDsmnm(String dsmnm) {
        this._dsmnm = dsmnm;
    }

}
