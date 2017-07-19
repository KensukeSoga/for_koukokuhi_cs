package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;

/**
 * <P>
 * 制作費明細書出力一覧(制作費取込)取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/9 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
public class FindWorkDetailGenkaVO extends
		FindHCEstimateCreationCaptureVO {

	/** serialVersionUID */
	private static final long serialVersionUID = 1L;

	/**
	 * デフォルトコンストラクタ
	 */
	public FindWorkDetailGenkaVO() {
	}

	/**
	 * 新規インスタンスを生成する
	 *
	 * @return 新規インスタンス
	 */
	@Override
	public Object newInstance() {
		return new FindWorkDetailGenkaVO();
	}

	/**
	 * 費用計画Noを取得する
	 *
	 * @return 費用計画No
	 */
	public String getHIYOUNO() {
		return (String) get(Mbj09Hiyou.HIYOUNO);
	}

	/**
	 * 費用計画Noを設定する
	 *
	 * @param val
	 *            費用計画No
	 */
	public void setHIYOUNO(String val) {
		set(Mbj09Hiyou.HIYOUNO, val);
	}
}