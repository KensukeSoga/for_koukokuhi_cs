package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 設定局マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj29SetteiKykCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 設定局ナンバー */
    private BigDecimal _stkykno = null;

    /** 設定局名 */
    private String _stkyknm = null;

    /** 組織コード */
    private String _sikcd = null;

    /** SSS公開フラグ */
    private String _sssflg = null;

    /** メール送信フラグ */
    private String _mailflg = null;

    /** ソートNO */
    private BigDecimal _sortno = null;

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
    public Mbj29SetteiKykCondition() {
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * 設定局ナンバーを取得する
     *
     * @return 設定局ナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getStkykno() {
        return _stkykno;
    }

    /**
     * 設定局ナンバーを設定する
     *
     * @param stkykno 設定局ナンバー
     */
    public void setStkykno(BigDecimal stkykno) {
        this._stkykno = stkykno;
    }

    /**
     * 設定局名を取得する
     *
     * @return 設定局名
     */
    public String getStkyknm() {
        return _stkyknm;
    }

    /**
     * 設定局名を設定する
     *
     * @param stkyknm 設定局名
     */
    public void setStkyknm(String stkyknm) {
        this._stkyknm = stkyknm;
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * 組織コードを設定する
     *
     * @param sikcd 組織コード
     */
    public void setSikcd(String sikcd) {
        this._sikcd = sikcd;
    }

    /**
     * SSS公開フラグを取得する
     *
     * @return SSS公開フラグ
     */
    public String getSssflg() {
        return _sssflg;
    }

    /**
     * SSS公開フラグを設定する
     *
     * @param sssflg SSS公開フラグ
     */
    public void setSssflg(String sssflg) {
        this._sssflg = sssflg;
    }

    /**
     * メール送信フラグを取得する
     *
     * @return メール送信フラグ
     */
    public String getMailflg() {
        return _mailflg;
    }

    /**
     * メール送信フラグを設定する
     *
     * @param mailflg メール送信フラグ
     */
    public void setMailflg(String mailflg) {
        this._mailflg = mailflg;
    }

    /**
     * ソートNOを取得する
     *
     * @return ソートNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * ソートNOを設定する
     *
     * @param sortno ソートNO
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
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
