package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * アラート表示制御マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj41AlertDispControlCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** アラート表示種別 */
    private String _disptype = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** シーケンス番号 */
    private BigDecimal _seqno = null;

    /** 担当者ID */
    private String _hamid = null;

    /** アラート表示先組織コード */
    private String _sikognzuntcd = null;

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
    public Mbj41AlertDispControlCondition() {
    }

    /**
     * アラート表示種別を取得する
     *
     * @return アラート表示種別
     */
    public String getDisptype() {
        return _disptype;
    }

    /**
     * アラート表示種別を設定する
     *
     * @param disptype アラート表示種別
     */
    public void setDisptype(String disptype) {
        this._disptype = disptype;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarcd 電通車種コード
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * シーケンス番号を取得する
     *
     * @return シーケンス番号
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSeqno() {
        return _seqno;
    }

    /**
     * シーケンス番号を設定する
     *
     * @param seqno シーケンス番号
     */
    public void setSeqno(BigDecimal seqno) {
        this._seqno = seqno;
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * アラート表示先組織コードを取得する
     *
     * @return アラート表示先組織コード
     */
    public String getSikognzuntcd() {
        return _sikognzuntcd;
    }

    /**
     * アラート表示先組織コードを設定する
     *
     * @param sikognzuntcd アラート表示先組織コード
     */
    public void setSikognzuntcd(String sikognzuntcd) {
        this._sikognzuntcd = sikognzuntcd;
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
