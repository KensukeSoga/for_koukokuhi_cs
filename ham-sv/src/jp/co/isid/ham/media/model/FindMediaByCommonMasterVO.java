package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.nj.model.AbstractModel;

public class FindMediaByCommonMasterVO extends AbstractModel{


    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaByCommonMasterVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMediaByCommonMasterVO();
    }

    /**
     * 行番号
     */
    private BigDecimal _ROWNO = null;

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

    /**
     * 行番号を取得します
     * @param val
     */
    @XmlElement(required = true)
    public BigDecimal getROWNO() {
        return _ROWNO;
    }

    /**
     * 行番号を設定します
     */
    public void setROWNO(BigDecimal val) {
        _ROWNO = val;
    }
}
