package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 請求先データを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class SeikyuDataVO extends AbstractModel {

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public SeikyuDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new SeikyuDataVO();
    }

    /**
     * 取引先企業コードを取得する
     *
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get("THSKGYCD");
    }

    /**
     * 取引先企業コードを設定する
     *
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set("THSKGYCD", val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get("SEQNO");
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set("SEQNO", val);
    }

    /**
     * 担当ＳＥＱＮＯを取得する
     *
     * @return 担当ＳＥＱＮＯ
     */
    public String getTNTSEQNO() {
        return (String) get("TNTSEQNO");
    }

    /**
     * 担当ＳＥＱＮＯを設定する
     *
     * @param val 担当ＳＥＱＮＯ
     */
    public void setTNTSEQNO(String val) {
        set("TNTSEQNO", val);
    }

    /**
     * 取引先企業名（表示用漢字）を取得する
     *
     * @return 取引先企業名（表示用漢字）
     */
    public String getTHSKGYDISPKJ() {
        return (String) get("THSKGYDISPKJ");
    }

    /**
     * 取引先企業名（表示用漢字）を設定する
     *
     * @param val 取引先企業名（表示用漢字）
     */
    public void setTHSKGYDISPKJ(String val) {
        set("THSKGYDISPKJ", val);
    }

    /**
     * 取引先企業名（正式漢字）を取得する
     *
     * @return 取引先企業名（正式漢字）
     */
    public String getTHSKGYLNGKJ() {
        return (String) get("THSKGYLNGKJ");
    }

    /**
     * 取引先企業名（正式漢字）を設定する
     *
     * @param val 取引先企業名（正式漢字）
     */
    public void setTHSKGYLNGKJ(String val) {
        set("THSKGYLNGKJ", val);
    }

    /**
     * サブ名を取得する
     *
     * @return サブ名
     */
    public String getSUBMEI() {
        return (String) get("SUBMEI");
    }

    /**
     * サブ名を設定する
     *
     * @param val サブ名
     */
    public void setSUBMEI(String val) {
        set("SUBMEI", val);
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSIKCD() {
        return (String) get("SIKCD");
    }

    /**
     * 組織コードを設定する
     *
     * @param val 組織コード
     */
    public void setSIKCD(String val) {
        set("SIKCD", val);
    }

    /**
     * [組織]表示名（漢字）を取得する
     *
     * @return [組織]表示名（漢字）
     */
    public String getHYOJIKJ() {
        return (String) get("HYOJIKJ");
    }

    /**
     * [組織]表示名（漢字）を設定する
     *
     * @param val [組織]表示名（漢字）
     */
    public void setHYOJIKJ(String val) {
        set("HYOJIKJ", val);
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get("CLASSDIV");
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param val 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set("CLASSDIV", val);
    }

}
