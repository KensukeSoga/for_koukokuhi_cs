package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新雑媒体マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu20MsMzBtVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu20MsMzBtVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu20MsMzBtVO();
    }

    /**
     * 新雑区分を取得する
     *
     * @return 新雑区分
     */
    public String getSZKBN() {
        return (String) get(RepaVbjaMeu20MsMzBt.SZKBN);
    }

    /**
     * 新雑区分を設定する
     *
     * @param val 新雑区分
     */
    public void setSZKBN(String val) {
        set(RepaVbjaMeu20MsMzBt.SZKBN, val);
    }

    /**
     * 新雑媒体コードを取得する
     *
     * @return 新雑媒体コード
     */
    public String getSINZATSUBTAICD() {
        return (String) get(RepaVbjaMeu20MsMzBt.SINZATSUBTAICD);
    }

    /**
     * 新雑媒体コードを設定する
     *
     * @param val 新雑媒体コード
     */
    public void setSINZATSUBTAICD(String val) {
        set(RepaVbjaMeu20MsMzBt.SINZATSUBTAICD, val);
    }

    /**
     * 県版コードを取得する
     *
     * @return 県版コード
     */
    public String getKBANCD() {
        return (String) get(RepaVbjaMeu20MsMzBt.KBANCD);
    }

    /**
     * 県版コードを設定する
     *
     * @param val 県版コード
     */
    public void setKBANCD(String val) {
        set(RepaVbjaMeu20MsMzBt.KBANCD, val);
    }

    /**
     * 新雑媒体名（漢字）を取得する
     *
     * @return 新雑媒体名（漢字）
     */
    public String getSINZATSUBTAINMJ() {
        return (String) get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ);
    }

    /**
     * 新雑媒体名（漢字）を設定する
     *
     * @param val 新雑媒体名（漢字）
     */
    public void setSINZATSUBTAINMJ(String val) {
        set(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ, val);
    }

    /**
     * 新雑媒体名（カナ）を取得する
     *
     * @return 新雑媒体名（カナ）
     */
    public String getSINZATSUBTAINMK() {
        return (String) get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK);
    }

    /**
     * 新雑媒体名（カナ）を設定する
     *
     * @param val 新雑媒体名（カナ）
     */
    public void setSINZATSUBTAINMK(String val) {
        set(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK, val);
    }

    /**
     * 媒体社企業コードを取得する
     *
     * @return 媒体社企業コード
     */
    public String getBTAISYAKCD() {
        return (String) get(RepaVbjaMeu20MsMzBt.BTAISYAKCD);
    }

    /**
     * 媒体社企業コードを設定する
     *
     * @param val 媒体社企業コード
     */
    public void setBTAISYAKCD(String val) {
        set(RepaVbjaMeu20MsMzBt.BTAISYAKCD, val);
    }

    /**
     * 媒体社ＳＥＱＮＯを取得する
     *
     * @return 媒体社ＳＥＱＮＯ
     */
    public String getBTAISYASEQNO() {
        return (String) get(RepaVbjaMeu20MsMzBt.BTAISYASEQNO);
    }

    /**
     * 媒体社ＳＥＱＮＯを設定する
     *
     * @param val 媒体社ＳＥＱＮＯ
     */
    public void setBTAISYASEQNO(String val) {
        set(RepaVbjaMeu20MsMzBt.BTAISYASEQNO, val);
    }

    /**
     * 旧取引先コードを取得する
     *
     * @return 旧取引先コード
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu20MsMzBt.KYUTRCD);
    }

    /**
     * 旧取引先コードを設定する
     *
     * @param val 旧取引先コード
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu20MsMzBt.KYUTRCD, val);
    }

    /**
     * 起票年月日を取得する
     *
     * @return 起票年月日
     */
    public String getKHYOYMD() {
        return (String) get(RepaVbjaMeu20MsMzBt.KHYOYMD);
    }

    /**
     * 起票年月日を設定する
     *
     * @param val 起票年月日
     */
    public void setKHYOYMD(String val) {
        set(RepaVbjaMeu20MsMzBt.KHYOYMD, val);
    }

    /**
     * ジャンル（１）を取得する
     *
     * @return ジャンル（１）
     */
    public String getJANR1() {
        return (String) get(RepaVbjaMeu20MsMzBt.JANR1);
    }

    /**
     * ジャンル（１）を設定する
     *
     * @param val ジャンル（１）
     */
    public void setJANR1(String val) {
        set(RepaVbjaMeu20MsMzBt.JANR1, val);
    }

    /**
     * ジャンル（２）を取得する
     *
     * @return ジャンル（２）
     */
    public String getJANR2() {
        return (String) get(RepaVbjaMeu20MsMzBt.JANR2);
    }

    /**
     * ジャンル（２）を設定する
     *
     * @param val ジャンル（２）
     */
    public void setJANR2(String val) {
        set(RepaVbjaMeu20MsMzBt.JANR2, val);
    }

    /**
     * ジャンル（３）を取得する
     *
     * @return ジャンル（３）
     */
    public String getJANR3() {
        return (String) get(RepaVbjaMeu20MsMzBt.JANR3);
    }

    /**
     * ジャンル（３）を設定する
     *
     * @param val ジャンル（３）
     */
    public void setJANR3(String val) {
        set(RepaVbjaMeu20MsMzBt.JANR3, val);
    }

    /**
     * 中央地方紙区分を取得する
     *
     * @return 中央地方紙区分
     */
    public String getCHUCHIKBN() {
        return (String) get(RepaVbjaMeu20MsMzBt.CHUCHIKBN);
    }

    /**
     * 中央地方紙区分を設定する
     *
     * @param val 中央地方紙区分
     */
    public void setCHUCHIKBN(String val) {
        set(RepaVbjaMeu20MsMzBt.CHUCHIKBN, val);
    }

    /**
     * 新聞題号コードを取得する
     *
     * @return 新聞題号コード
     */
    public String getSINBUNDAIGOCD() {
        return (String) get(RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD);
    }

    /**
     * 新聞題号コードを設定する
     *
     * @param val 新聞題号コード
     */
    public void setSINBUNDAIGOCD(String val) {
        set(RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD, val);
    }

}
