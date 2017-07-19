package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 系列マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj04KeiretsuCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 系列コード */
    private String _keiretsucd = null;

    /** 系列名 */
    private String _keiretsunm = null;

    /** 系列名略 */
    private String _keiretsusnm = null;

    /** ソートNo */
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
    public Mbj04KeiretsuCondition() {
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKeiretsucd() {
        return _keiretsucd;
    }

    /**
     * 系列コードを設定する
     *
     * @param keiretsucd 系列コード
     */
    public void setKeiretsucd(String keiretsucd) {
        this._keiretsucd = keiretsucd;
    }

    /**
     * 系列名を取得する
     *
     * @return 系列名
     */
    public String getKeiretsunm() {
        return _keiretsunm;
    }

    /**
     * 系列名を設定する
     *
     * @param keiretsunm 系列名
     */
    public void setKeiretsunm(String keiretsunm) {
        this._keiretsunm = keiretsunm;
    }

    /**
     * 系列名略を取得する
     *
     * @return 系列名略
     */
    public String getKeiretsusnm() {
        return _keiretsusnm;
    }

    /**
     * 系列名略を設定する
     *
     * @param keiretsusnm 系列名略
     */
    public void setKeiretsusnm(String keiretsusnm) {
        this._keiretsusnm = keiretsusnm;
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * ソートNoを設定する
     *
     * @param sortno ソートNo
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
