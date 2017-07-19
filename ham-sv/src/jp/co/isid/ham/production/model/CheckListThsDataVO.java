package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
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
public class CheckListThsDataVO extends AbstractModel {

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public CheckListThsDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new CheckListThsDataVO();
    }

    /**
     * 取引先企業コードを取得する
     *
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYCD);
    }

    /**
     * 取引先企業コードを設定する
     *
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYCD, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.ENDYMD, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.STARTYMD, val);
    }

    /**
     * 取引先企業名（正式漢字）を取得する
     *
     * @return 取引先企業名（正式漢字）
     */
    public String getTHSKGYLNGKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
    }

    /**
     * 取引先企業名（正式漢字）を設定する
     *
     * @param val 取引先企業名（正式漢字）
     */
    public void setTHSKGYLNGKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ, val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SEQNO);
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SEQNO, val);
    }

    /**
     * サブ名を取得する
     *
     * @return サブ名
     */
    public String getSUBMEI() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBMEI);
    }

    /**
     * サブ名を設定する
     *
     * @param val サブ名
     */
    public void setSUBMEI(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBMEI, val);
    }
}
