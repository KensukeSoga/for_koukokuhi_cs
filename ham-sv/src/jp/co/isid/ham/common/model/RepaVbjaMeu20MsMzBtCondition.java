package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 新雑媒体マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu20MsMzBtCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 新雑区分 */
    private String _szkbn = null;

    /** 新雑媒体コード */
    private String _sinzatsubtaicd = null;

    /** 県版コード */
    private String _kbancd = null;

    /** 新雑媒体名（漢字） */
    private String _sinzatsubtainmj = null;

    /** 新雑媒体名（カナ） */
    private String _sinzatsubtainmk = null;

    /** 媒体社企業コード */
    private String _btaisyakcd = null;

    /** 媒体社ＳＥＱＮＯ */
    private String _btaisyaseqno = null;

    /** 旧取引先コード */
    private String _kyutrcd = null;

    /** 起票年月日 */
    private String _khyoymd = null;

    /** ジャンル（１） */
    private String _janr1 = null;

    /** ジャンル（２） */
    private String _janr2 = null;

    /** ジャンル（３） */
    private String _janr3 = null;

    /** 中央地方紙区分 */
    private String _chuchikbn = null;

    /** 新聞題号コード */
    private String _sinbundaigocd = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu20MsMzBtCondition() {
    }

    /**
     * 新雑区分を取得する
     *
     * @return 新雑区分
     */
    public String getSzkbn() {
        return _szkbn;
    }

    /**
     * 新雑区分を設定する
     *
     * @param szkbn 新雑区分
     */
    public void setSzkbn(String szkbn) {
        this._szkbn = szkbn;
    }

    /**
     * 新雑媒体コードを取得する
     *
     * @return 新雑媒体コード
     */
    public String getSinzatsubtaicd() {
        return _sinzatsubtaicd;
    }

    /**
     * 新雑媒体コードを設定する
     *
     * @param sinzatsubtaicd 新雑媒体コード
     */
    public void setSinzatsubtaicd(String sinzatsubtaicd) {
        this._sinzatsubtaicd = sinzatsubtaicd;
    }

    /**
     * 県版コードを取得する
     *
     * @return 県版コード
     */
    public String getKbancd() {
        return _kbancd;
    }

    /**
     * 県版コードを設定する
     *
     * @param kbancd 県版コード
     */
    public void setKbancd(String kbancd) {
        this._kbancd = kbancd;
    }

    /**
     * 新雑媒体名（漢字）を取得する
     *
     * @return 新雑媒体名（漢字）
     */
    public String getSinzatsubtainmj() {
        return _sinzatsubtainmj;
    }

    /**
     * 新雑媒体名（漢字）を設定する
     *
     * @param sinzatsubtainmj 新雑媒体名（漢字）
     */
    public void setSinzatsubtainmj(String sinzatsubtainmj) {
        this._sinzatsubtainmj = sinzatsubtainmj;
    }

    /**
     * 新雑媒体名（カナ）を取得する
     *
     * @return 新雑媒体名（カナ）
     */
    public String getSinzatsubtainmk() {
        return _sinzatsubtainmk;
    }

    /**
     * 新雑媒体名（カナ）を設定する
     *
     * @param sinzatsubtainmk 新雑媒体名（カナ）
     */
    public void setSinzatsubtainmk(String sinzatsubtainmk) {
        this._sinzatsubtainmk = sinzatsubtainmk;
    }

    /**
     * 媒体社企業コードを取得する
     *
     * @return 媒体社企業コード
     */
    public String getBtaisyakcd() {
        return _btaisyakcd;
    }

    /**
     * 媒体社企業コードを設定する
     *
     * @param btaisyakcd 媒体社企業コード
     */
    public void setBtaisyakcd(String btaisyakcd) {
        this._btaisyakcd = btaisyakcd;
    }

    /**
     * 媒体社ＳＥＱＮＯを取得する
     *
     * @return 媒体社ＳＥＱＮＯ
     */
    public String getBtaisyaseqno() {
        return _btaisyaseqno;
    }

    /**
     * 媒体社ＳＥＱＮＯを設定する
     *
     * @param btaisyaseqno 媒体社ＳＥＱＮＯ
     */
    public void setBtaisyaseqno(String btaisyaseqno) {
        this._btaisyaseqno = btaisyaseqno;
    }

    /**
     * 旧取引先コードを取得する
     *
     * @return 旧取引先コード
     */
    public String getKyutrcd() {
        return _kyutrcd;
    }

    /**
     * 旧取引先コードを設定する
     *
     * @param kyutrcd 旧取引先コード
     */
    public void setKyutrcd(String kyutrcd) {
        this._kyutrcd = kyutrcd;
    }

    /**
     * 起票年月日を取得する
     *
     * @return 起票年月日
     */
    public String getKhyoymd() {
        return _khyoymd;
    }

    /**
     * 起票年月日を設定する
     *
     * @param khyoymd 起票年月日
     */
    public void setKhyoymd(String khyoymd) {
        this._khyoymd = khyoymd;
    }

    /**
     * ジャンル（１）を取得する
     *
     * @return ジャンル（１）
     */
    public String getJanr1() {
        return _janr1;
    }

    /**
     * ジャンル（１）を設定する
     *
     * @param janr1 ジャンル（１）
     */
    public void setJanr1(String janr1) {
        this._janr1 = janr1;
    }

    /**
     * ジャンル（２）を取得する
     *
     * @return ジャンル（２）
     */
    public String getJanr2() {
        return _janr2;
    }

    /**
     * ジャンル（２）を設定する
     *
     * @param janr2 ジャンル（２）
     */
    public void setJanr2(String janr2) {
        this._janr2 = janr2;
    }

    /**
     * ジャンル（３）を取得する
     *
     * @return ジャンル（３）
     */
    public String getJanr3() {
        return _janr3;
    }

    /**
     * ジャンル（３）を設定する
     *
     * @param janr3 ジャンル（３）
     */
    public void setJanr3(String janr3) {
        this._janr3 = janr3;
    }

    /**
     * 中央地方紙区分を取得する
     *
     * @return 中央地方紙区分
     */
    public String getChuchikbn() {
        return _chuchikbn;
    }

    /**
     * 中央地方紙区分を設定する
     *
     * @param chuchikbn 中央地方紙区分
     */
    public void setChuchikbn(String chuchikbn) {
        this._chuchikbn = chuchikbn;
    }

    /**
     * 新聞題号コードを取得する
     *
     * @return 新聞題号コード
     */
    public String getSinbundaigocd() {
        return _sinbundaigocd;
    }

    /**
     * 新聞題号コードを設定する
     *
     * @param sinbundaigocd 新聞題号コード
     */
    public void setSinbundaigocd(String sinbundaigocd) {
        this._sinbundaigocd = sinbundaigocd;
    }

}
