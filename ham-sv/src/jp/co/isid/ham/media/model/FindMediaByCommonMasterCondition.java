package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

public class FindMediaByCommonMasterCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体フラグ */
    private String _mediaFlg;

    /** パターンNo */
    private BigDecimal _patternNo;

    /** 媒体コード */
    private String _mediaCd;

    /** 検索文字列 */
    private String _searchNm;

    /** 検索対象フラグ */
    private boolean _searchFlg;

    /** ダミープロパティ */
    private String _dummy;

    /**
     * 媒体フラグを取得
     * @return 媒体フラグ
     */
    public String getMediaFlg() {
        return _mediaFlg;
    }

    /**
     * 媒体フラグを設定
     * @param mediaFlg
     */
    public void setMediaFlg(String mediaFlg) {
        _mediaFlg = mediaFlg;
    }

    /**
     * パターン名を取得
     * @return パターン名
     */
    @XmlElement(required = true)
    public BigDecimal getPatternNo() {
        return _patternNo;
    }

    /**
     * パターン名を設定
     * @param patternNm
     */
    public void setPatternNo(BigDecimal patternNo) {
        _patternNo = patternNo;
    }

    /**
     * 媒体コードを取得
     * @return 媒体コード
     */
    public String getMediaCd() {
        return _mediaCd;
    }

    /**
     * 媒体コードを設定
     * @param mediaCd
     */
    public void setMediaCd(String mediaCd) {
        this._mediaCd = mediaCd;
    }

    /**
     * 検索文字列を取得
     * @return 検索文字列
     */
    public String getSearchNm() {
        return _searchNm;
    }

    /**
     * 検索文字列を設定
     * @param searchNm
     */
    public void setSearchNm(String searchNm) {
        _searchNm = searchNm;
    }

    /**
     * 検索フラグを取得
     * @return 検索フラグ
     */
    public boolean getSearchFlg() {
        return _searchFlg;
    }

    /**
     * 検索フラグを設定
     * @param searchFlg
     */
    public void setSearchFlg(boolean searchFlg) {
        _searchFlg = searchFlg;
    }

    /**
     * ダミープロパティを返します
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }
}
