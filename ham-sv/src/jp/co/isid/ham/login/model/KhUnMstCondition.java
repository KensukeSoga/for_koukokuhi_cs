package jp.co.isid.ham.login.model;

public class KhUnMstCondition {

	/** 上位組織コード */
	private String _jSikCd = null;

	/** 運用No. */
	private String _operationNo = null;

	/** 職位等級グループ */
	private String _syokuiGrpCd = null;

	/** 担当者コード */
	private String _tntCd = null;

	/** 営業日 */
	private String _eigyobi = null;

	/** 得意先コード */
	private String _tksCd = null;

	/** 期首 */
	private String _termBegin = null;

	/** 期末 */
	private String _termEnd = null;

	/**
	 * 上位組織コードを取得する
	 * @return 上位組織コード
	 */
	public String getJSikCd() {
	    return _jSikCd;
	}

	/**
	 * 上位組織コードを設定する
	 * @param jSikCd 上位組織コード
	 */
	public void setJSikCd(String jSikCd) {
	    this._jSikCd = jSikCd;
	}

	/**
	 * 運用No.を取得する
	 * @return 運用No.
	 */
	public String getOperationNo() {
	    return _operationNo;
	}

	/**
	 * 運用No.を設定する
	 * @param operationNo 運用No.
	 */
	public void setOperationNo(String operationNo) {
	    this._operationNo = operationNo;
	}

	/**
	 * 職位等級グループを取得する
	 * @return 職位等級グループ
	 */
	public String getSyokuiGrpCd() {
	    return _syokuiGrpCd;
	}

	/**
	 * 職位等級グループを設定する
	 * @param syokuiGrpCd 職位等級グループ
	 */
	public void setSyokuiGrpCd(String syokuiGrpCd) {
	    this._syokuiGrpCd = syokuiGrpCd;
	}

	/**
	 * 担当者コードを取得する
	 * @return 担当者コード
	 */
	public String getTntCd() {
	    return _tntCd;
	}

	/**
	 * 担当者コードを設定する
	 * @param tntCd 担当者コード
	 */
	public void setTntCd(String tntCd) {
	    this._tntCd = tntCd;
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
	 * 得意先コードを取得する
	 * @return 得意先コード
	 */
	public String getTksCd() {
	    return _tksCd;
	}

	/**
	 * 得意先コードを設定する
	 * @param tksCd 得意先コード
	 */
	public void setTksCd(String tksCd) {
	    this._tksCd = tksCd;
	}

	/**
	 * 期首を取得する
	 * @return 期首
	 */
	public String getTermBegin() {
	    return _termBegin;
	}

	/**
	 * 期首を設定する
	 * @param termBegin 期首
	 */
	public void setTermBegin(String termBegin) {
	    this._termBegin = termBegin;
	}

	/**
	 * 期末を取得する
	 * @return 期末
	 */
	public String getTermEnd() {
	    return _termEnd;
	}

	/**
	 * 期末を設定する
	 * @param termEnd 期末
	 */
	public void setTermEnd(String termEnd) {
	    this._termEnd = termEnd;
	}
}
