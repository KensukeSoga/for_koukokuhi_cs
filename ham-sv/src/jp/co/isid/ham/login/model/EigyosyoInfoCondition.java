package jp.co.isid.ham.login.model;

public class EigyosyoInfoCondition {

	/** 担当者組織コード(運用No.) */
	private String _tntSikCd = null;

	/** 営業日 */
	private String _eigyobi = null;

	/**
	 * 担当者組織コード(運用No.)を取得する
	 * @return 担当者組織コード(運用No.)
	 */
	public String getTntSikCd() {
	    return _tntSikCd;
	}

	/**
	 * 担当者組織コード(運用No.)を設定する
	 * @param tntSikCd 担当者組織コード(運用No.)
	 */
	public void setTntSikCd(String tntSikCd) {
	    this._tntSikCd = tntSikCd;
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
}
