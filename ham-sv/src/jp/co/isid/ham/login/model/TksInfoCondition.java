package jp.co.isid.ham.login.model;

import java.io.Serializable;

public class TksInfoCondition implements Serializable{

	private static final long serialVersionUID = 4082004138863641700L;

    /** 営業所コード */
    private String _egsCd = null;

    /** 得意先企業コード */
    private String _tksKgyCd = null;

    /** 得意先部門SEQNO */
    private String _tksBmnSeqNo = null;

	/** 営業日 */
	private String _eigyobi = null;

    /** 組織コード */
    private String _sikcd = null;

    /**
     * 営業所コードを取得する
     * @return 営業所コード
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * 営業所コードを設定する
     * @param egsCd 営業所コード
     */
    public void setEgsCd(String egsCd) {
        this._egsCd = egsCd;
    }

    /**
     * 得意先企業コードを取得する
     * @return 得意先企業コード
     */
    public String getTksKgyCd() {
        return _tksKgyCd;
    }

    /**
     * 得意先企業コードを設定する
     * @param tksKgyCd 得意先企業コード
     */
    public void setTksKgyCd(String tksKgyCd) {
        this._tksKgyCd = tksKgyCd;
    }

    /**
     * 得意先部門SEQNOを取得する
     * @return 得意先部門SEQNO
     */
    public String getTksBmnSeqNo() {
        return _tksBmnSeqNo;
    }

    /**
     * 得意先部門SEQNOを設定する
     * @param tksBmnSeqNo 得意先部門SEQNO
     */
    public void setTksBmnSeqNo(String tksBmnSeqNo) {
        this._tksBmnSeqNo = tksBmnSeqNo;
    }

	/**
	 * 営業日を取得する
	 * @return 営業日
	 */
	public String getEigyobi() {
	    return _eigyobi;
	}

	/**
	 * 営業日を設定する
	 * @param eigyobi 営業日
	 */
	public void setEigyobi(String eigyobi) {
	    this._eigyobi = eigyobi;
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
        this._sikcd = sikcd;
    }
}
