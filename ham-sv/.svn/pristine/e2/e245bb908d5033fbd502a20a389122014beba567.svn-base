package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 媒体パターンマスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj35MediaPatternCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 新雑区分 */
    private String _szkbn = null;

    /** 媒体パターンNo */
    private BigDecimal _baitaipatnno = null;

    /** 媒体パターン名 */
    private String _baitaipatnname = null;

    /** データ更新日時 */
    private Date _upddate = null;

    /** データ更新者 */
    private String _updnm = null;

    /** 更新プログラム */
    private String _updapl = null;

    /** 更新担当者ID */
    private String _updid = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj35MediaPatternCondition() {
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
     * 媒体パターンNoを取得する
     *
     * @return 媒体パターンNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBaitaipatnno() {
        return _baitaipatnno;
    }

    /**
     * 媒体パターンNoを設定する
     *
     * @param baitaipatnno 媒体パターンNo
     */
    public void setBaitaipatnno(BigDecimal baitaipatnno) {
        this._baitaipatnno = baitaipatnno;
    }

    /**
     * 媒体パターン名を取得する
     *
     * @return 媒体パターン名
     */
    public String getBaitaipatnname() {
        return _baitaipatnname;
    }

    /**
     * 媒体パターン名を設定する
     *
     * @param baitaipatnname 媒体パターン名
     */
    public void setBaitaipatnname(String baitaipatnname) {
        this._baitaipatnname = baitaipatnname;
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * データ更新日時を設定する
     *
     * @param upddate データ更新日時
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * データ更新者を設定する
     *
     * @param updnm データ更新者
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * 更新プログラムを設定する
     *
     * @param updapl 更新プログラム
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param updid 更新担当者ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
