package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 共通コードマスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu29CcCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** コード種別 */
    private String _kycdknd = null;

    /** コード */
    private String _kycd = null;

    /** 発行年月日 */
    private String _hkymd = null;

    /** 廃止年月日 */
    private String _haisymd = null;

    /** 内容（カナ） */
    private String _naiykn = null;

    /** 内容（漢字） */
    private String _naiyj = null;

    /** 予備（１） */
    private String _yobi1 = null;

    /** 補足 */
    private String _hosok = null;

    /** 予備（２） */
    private String _yobi2 = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu29CcCondition() {
    }

    /**
     * コード種別を取得する
     *
     * @return コード種別
     */
    public String getKycdknd() {
        return _kycdknd;
    }

    /**
     * コード種別を設定する
     *
     * @param kycdknd コード種別
     */
    public void setKycdknd(String kycdknd) {
        this._kycdknd = kycdknd;
    }

    /**
     * コードを取得する
     *
     * @return コード
     */
    public String getKycd() {
        return _kycd;
    }

    /**
     * コードを設定する
     *
     * @param kycd コード
     */
    public void setKycd(String kycd) {
        this._kycd = kycd;
    }

    /**
     * 発行年月日を取得する
     *
     * @return 発行年月日
     */
    public String getHkymd() {
        return _hkymd;
    }

    /**
     * 発行年月日を設定する
     *
     * @param hkymd 発行年月日
     */
    public void setHkymd(String hkymd) {
        this._hkymd = hkymd;
    }

    /**
     * 廃止年月日を取得する
     *
     * @return 廃止年月日
     */
    public String getHaisymd() {
        return _haisymd;
    }

    /**
     * 廃止年月日を設定する
     *
     * @param haisymd 廃止年月日
     */
    public void setHaisymd(String haisymd) {
        this._haisymd = haisymd;
    }

    /**
     * 内容（カナ）を取得する
     *
     * @return 内容（カナ）
     */
    public String getNaiykn() {
        return _naiykn;
    }

    /**
     * 内容（カナ）を設定する
     *
     * @param naiykn 内容（カナ）
     */
    public void setNaiykn(String naiykn) {
        this._naiykn = naiykn;
    }

    /**
     * 内容（漢字）を取得する
     *
     * @return 内容（漢字）
     */
    public String getNaiyj() {
        return _naiyj;
    }

    /**
     * 内容（漢字）を設定する
     *
     * @param naiyj 内容（漢字）
     */
    public void setNaiyj(String naiyj) {
        this._naiyj = naiyj;
    }

    /**
     * 予備（１）を取得する
     *
     * @return 予備（１）
     */
    public String getYobi1() {
        return _yobi1;
    }

    /**
     * 予備（１）を設定する
     *
     * @param yobi1 予備（１）
     */
    public void setYobi1(String yobi1) {
        this._yobi1 = yobi1;
    }

    /**
     * 補足を取得する
     *
     * @return 補足
     */
    public String getHosok() {
        return _hosok;
    }

    /**
     * 補足を設定する
     *
     * @param hosok 補足
     */
    public void setHosok(String hosok) {
        this._hosok = hosok;
    }

    /**
     * 予備（２）を取得する
     *
     * @return 予備（２）
     */
    public String getYobi2() {
        return _yobi2;
    }

    /**
     * 予備（２）を設定する
     *
     * @param yobi2 予備（２）
     */
    public void setYobi2(String yobi2) {
        this._yobi2 = yobi2;
    }

}
