package jp.co.isid.ham.operationLog.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 稼働ログ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/15 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.operationLog.ham.isid.co.jp/")
@XmlType(namespace = "http://model.operationLog.ham.isid.co.jp/")
public class FindOperationLogCondition implements Serializable {

    /** serialVersionUID */
	private static final long serialVersionUID = 1L;

    /** 集計フラグ */
	// 対象期間,ESQID,担当者名,組織名,画面名,機能名,操作名
	// の順番に設定
	// (0:集計対象外,1:集計対象)
	//
	// ex) 0,1,1,0,0,0,0 の場合、ESQID,担当者名が集計対象
    private String _TotalFlg;

	/** データ作成日時(FROM) */
    private String _CrtDateFrom;

	/** データ作成日時(TO) */
    private String _CrtDateTo;

    /** 担当者ID(ESQID) */
    private String _hamId;

    /** 担当者名(HAMNM) */
    private String _hamNm;

    /** 組織コード(本部) */
    private String _SikCdHonb;

    /** 本部表示名(漢字) */
    private String _SikNmHonb;

    /** 組織コード(局) */
    private String _SikCdKyk;

    /** 局表示名(漢字) */
    private String _SikNmKyk;

    /** 組織コード(室) */
    private String _SikCdSitu;

    /** 室表示名(漢字) */
    private String _SikNmSitu;

    /** 組織コード(部) */
    private String _SikCdBu;

    /** 部表示名(漢字) */
    private String _SikNmBu;

    /** 組織コード(課) */
    private String _SikCdKa;

    /** 課表示名(漢字) */
    private String _SikNmKa;

    /** 画面ID */
    private String _FormId;

    /** 画面名 */
    private String _FormNm;

    /** 機能ID */
    private String _KnoId;

    /** 機能名 */
    private String _KnoNm;

    /** 操作ID */
    private String _DsmId;

    /** 操作名 */
    private String _DsmNm;

    /**
     * 集計フラグを取得します
     *
     * @return 集計フラグ
     */
    public String getTotalFlg() {
        return _TotalFlg;
    }

    /**
     * 集計フラグを設定します
     *
     * @param val 集計フラグ
     */
    public void setTotalFlg(String val) {
    	_TotalFlg = val;
    }

    /**
     * データ作成日時(FROM)を取得する
     *
     * @return データ作成日時(FROM)
     */
    public String getCrtDateFrom() {
        return _CrtDateFrom;
    }

    /**
     * データ作成日時(FROM)を設定する
     *
     * @param val データ作成日時(FROM)
     */
    public void setCrtDateFrom(String val) {
    	_CrtDateFrom = val;
    }

    /**
     * データ作成日時(TO)を取得する
     *
     * @return データ作成日時(TO)
     */
    public String getCrtDateTo() {
        return _CrtDateTo;
    }

    /**
     * データ作成日時(TO)を設定する
     *
     * @param val データ作成日時(TO)
     */
    public void setCrtDateTo(String val) {
    	_CrtDateTo = val;
    }

    /**
     * 担当者ID(ESQID)を取得します
     *
     * @return 担当者ID(ESQID)
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * 担当者ID(ESQID)を設定します
     *
     * @param val 担当者ID(ESQID)
     */
    public void setHamId(String val) {
    	_hamId = val;
    }

    /**
     * 担当者名(HAMNM)を取得します
     *
     * @return 担当者名(HAMNM)
     */
    public String getHamNm() {
        return _hamNm;
    }

    /**
     * 担当者名(HAMNM)を設定します
     *
     * @param val 担当者名(HAMNM)
     */
    public void setHamNm(String val) {
    	_hamNm = val;
    }

    /**
     * 組織コード(本部)を取得します
     *
     * @return 組織コード(本部)
     */
    public String getSikCdHonb() {
        return _SikCdHonb;
    }

    /**
     * 組織コード(本部)を設定します
     *
     * @param val 組織コード(本部)
     */
    public void setSikCdHonb(String val) {
    	_SikCdHonb = val;
    }

    /**
     * 本部表示名(漢字)を取得します
     *
     * @return 本部表示名(漢字)
     */
    public String getSikNmHonb() {
        return _SikNmHonb;
    }

    /**
     * 本部表示名(漢字)を設定します
     *
     * @param val 本部表示名(漢字)
     */
    public void setSikNmHonb(String val) {
    	_SikNmHonb = val;
    }

    /**
     * 組織コード(局)を取得します
     *
     * @return 組織コード(局)
     */
    public String getSikCdKyk() {
        return _SikCdKyk;
    }

    /**
     * 組織コード(局)を設定します
     *
     * @param val 組織コード(局)
     */
    public void setSikCdKyk(String val) {
    	_SikCdKyk = val;
    }

    /**
     * 局表示名(漢字)を取得します
     *
     * @return 局表示名(漢字)
     */
    public String getSikNmKyk() {
        return _SikNmKyk;
    }

    /**
     * 局表示名(漢字)を設定します
     *
     * @param val 局表示名(漢字)
     */
    public void setSikNmKyk(String val) {
    	_SikNmKyk = val;
    }

    /**
     * 組織コード(室)を取得します
     *
     * @return 組織コード(室)
     */
    public String getSikCdSitu() {
        return _SikCdSitu;
    }

    /**
     * 組織コード(室)を設定します
     *
     * @param val 組織コード(室)
     */
    public void setSikCdSitu(String val) {
    	_SikCdSitu = val;
    }

    /**
     * 室表示名(漢字)を取得します
     *
     * @return 室表示名(漢字)
     */
    public String getSikNmSitu() {
        return _SikNmSitu;
    }

    /**
     * 室表示名(漢字)を設定します
     *
     * @param val 室表示名(漢字)
     */
    public void setSikNmSitu(String val) {
    	_SikNmSitu = val;
    }

    /**
     * 組織コード(部)を取得します
     *
     * @return 組織コード(部)
     */
    public String getSikCdBu() {
        return _SikCdBu;
    }

    /**
     * 組織コード(部)を設定します
     *
     * @param val 組織コード(部)
     */
    public void setSikCdBu(String val) {
    	_SikCdBu = val;
    }

    /**
     * 部表示名(漢字)を取得します
     *
     * @return 部表示名(漢字)
     */
    public String getSikNmBu() {
        return _SikNmBu;
    }

    /**
     * 部表示名(漢字)を設定します
     *
     * @param val 部表示名(漢字)
     */
    public void setSikNmBu(String val) {
    	_SikNmBu = val;
    }

    /**
     * 組織コード(課)を取得します
     *
     * @return 組織コード(課)
     */
    public String getSikCdKa() {
        return _SikCdKa;
    }

    /**
     * 組織コード(課)を設定します
     *
     * @param val 組織コード(課)
     */
    public void setSikCdKa(String val) {
    	_SikCdKa = val;
    }

    /**
     * 課表示名(漢字)を取得します
     *
     * @return 課表示名(漢字)
     */
    public String getSikNmKa() {
        return _SikNmKa;
    }

    /**
     * 課表示名(漢字)を設定します
     *
     * @param val 課表示名(漢字)
     */
    public void setSikNmKa(String val) {
    	_SikNmKa = val;
    }

    /**
     * 画面IDを取得します
     *
     * @return 画面ID
     */
    public String getFormId() {
        return _FormId;
    }

    /**
     * 画面IDを設定します
     *
     * @param val 画面ID
     */
    public void setFormId(String val) {
    	_FormId = val;
    }

    /**
     * 画面名を取得します
     *
     * @return 画面名
     */
    public String getFormNm() {
        return _FormNm;
    }

    /**
     * 画面名を設定します
     *
     * @param val 画面名
     */
    public void setFormNm(String val) {
    	_FormNm = val;
    }

    /**
     * 機能IDを取得します
     *
     * @return 機能ID
     */
    public String getKnoId() {
        return _KnoId;
    }

    /**
     * 機能IDを設定します
     *
     * @param val 機能ID
     */
    public void setKnoId(String val) {
    	_KnoId = val;
    }

    /**
     * 機能名を取得します
     *
     * @return 機能名
     */
    public String getKnoNm() {
        return _KnoNm;
    }

    /**
     * 機能名を設定します
     *
     * @param val 機能名
     */
    public void setKnoNm(String val) {
    	_KnoNm = val;
    }

    /**
     * 操作IDを取得します
     *
     * @return 操作ID
     */
    public String getDsmId() {
        return _DsmId;
    }

    /**
     * 操作IDを設定します
     *
     * @param val 操作ID
     */
    public void setDsmId(String val) {
    	_DsmId = val;
    }

    /**
     * 操作名を取得します
     *
     * @return 操作名
     */
    public String getDsmNm() {
        return _DsmNm;
    }

    /**
     * 操作名を設定します
     *
     * @param val 操作名
     */
    public void setDsmNm(String val) {
    	_DsmNm = val;
    }
}
