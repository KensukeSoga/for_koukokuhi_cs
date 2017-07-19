package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 業務区分費目対応マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu2LGKbnHmokCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 業務区分 */
    private String _gyomkbn = null;

    /** 費目コード */
    private String _hmokcd = null;

    /** 発行年月日 */
    private String _hkymd = null;

    /** 費目表示順 */
    private String _hmokseq = null;

    /** 廃止年月日 */
    private String _haisymd = null;

    /** 海外区分 */
    private String _kaigaikbn = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu2LGKbnHmokCondition() {
    }

    /**
     * 業務区分を取得する
     *
     * @return 業務区分
     */
    public String getGyomkbn() {
        return _gyomkbn;
    }

    /**
     * 業務区分を設定する
     *
     * @param gyomkbn 業務区分
     */
    public void setGyomkbn(String gyomkbn) {
        this._gyomkbn = gyomkbn;
    }

    /**
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getHmokcd() {
        return _hmokcd;
    }

    /**
     * 費目コードを設定する
     *
     * @param hmokcd 費目コード
     */
    public void setHmokcd(String hmokcd) {
        this._hmokcd = hmokcd;
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
     * 費目表示順を取得する
     *
     * @return 費目表示順
     */
    public String getHmokseq() {
        return _hmokseq;
    }

    /**
     * 費目表示順を設定する
     *
     * @param hmokseq 費目表示順
     */
    public void setHmokseq(String hmokseq) {
        this._hmokseq = hmokseq;
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
     * 海外区分を取得する
     *
     * @return 海外区分
     */
    public String getKaigaikbn() {
        return _kaigaikbn;
    }

    /**
     * 海外区分を設定する
     *
     * @param kaigaikbn 海外区分
     */
    public void setKaigaikbn(String kaigaikbn) {
        this._kaigaikbn = kaigaikbn;
    }

}
