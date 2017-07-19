package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HMユーザマスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj48HmUserCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 期 */
    private String _term = null;

    /** HM担当者職番 */
    private String _hmusercd = null;

    /** HM担当者名 */
    private String _hmusernm = null;

    /** HC担当者内線番号 */
    private String _hmuserextensionno = null;

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
    public Mbj48HmUserCondition() {
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
     * 期を取得する
     *
     * @return 期
     */
    public String getTerm() {
        return _term;
    }

    /**
     * 期を設定する
     *
     * @param term 期
     */
    public void setTerm(String term) {
        this._term = term;
    }

    /**
     * HM担当者職番を取得する
     *
     * @return HM担当者職番
     */
    public String getHmusercd() {
        return _hmusercd;
    }

    /**
     * HM担当者職番を設定する
     *
     * @param hmusercd HM担当者職番
     */
    public void setHmusercd(String hmusercd) {
        this._hmusercd = hmusercd;
    }

    /**
     * HM担当者名を取得する
     *
     * @return HM担当者名
     */
    public String getHmusernm() {
        return _hmusernm;
    }

    /**
     * HM担当者名を設定する
     *
     * @param hmusernm HM担当者名
     */
    public void setHmusernm(String hmusernm) {
        this._hmusernm = hmusernm;
    }

    /**
     * HC担当者内線番号を取得する
     *
     * @return HC担当者内線番号
     */
    public String getHmuserextensionno() {
        return _hmuserextensionno;
    }

    /**
     * HC担当者内線番号を設定する
     *
     * @param hmuserextensionno HC担当者内線番号
     */
    public void setHmuserextensionno(String hmuserextensionno) {
        this._hmuserextensionno = hmuserextensionno;
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
