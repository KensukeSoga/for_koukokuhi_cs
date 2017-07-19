package jp.co.isid.ham.login.model;

import java.io.Serializable;

public class SyokuiGrpInfoCondition implements Serializable{

	private static final long serialVersionUID = 4082004138863641700L;

	/** ESQID */
	private String _esqId = null;

	/** ‰c‹Æ“ú */
	private String _eigyobi = null;

	/**
	 * ESQID‚ğæ“¾‚·‚é
	 * @return ESQID
	 */
	public String getEsqId() {
	    return _esqId;
	}

	/**
	 * ESQID‚ğİ’è‚·‚é
	 * @param esqId ESQID
	 */
	public void setEsqId(String esqId) {
	    this._esqId = esqId;
	}

	/**
	 * ‰c‹Æ“ú‚ğæ“¾‚·‚é
	 * @return ‰c‹Æ“ú
	 */
	public String getEigyobi() {
	    return _eigyobi;
	}

	/**
	 * ‰c‹Æ“ú‚ğİ’è‚·‚é
	 * @param eigyobi ‰c‹Æ“ú
	 */
	public void setEigyobi(String eigyobi) {
	    this._eigyobi = eigyobi;
	}
}
