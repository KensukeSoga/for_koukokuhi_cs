package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 部署マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj32DepartmentCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 種別 */
    private String _datatype = null;

    /** ナンバー */
    private BigDecimal _datanumber = null;

    /** 局名 */
    private String _kyokuname = null;

    /** 名称 */
    private String _dataname = null;

    /** 出力フラグ */
    private String _outputflg = null;

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
    public Mbj32DepartmentCondition() {
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getDatatype() {
        return _datatype;
    }

    /**
     * 種別を設定する
     *
     * @param datatype 種別
     */
    public void setDatatype(String datatype) {
        this._datatype = datatype;
    }

    /**
     * ナンバーを取得する
     *
     * @return ナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDatanumber() {
        return _datanumber;
    }

    /**
     * ナンバーを設定する
     *
     * @param datanumber ナンバー
     */
    public void setDatanumber(BigDecimal datanumber) {
        this._datanumber = datanumber;
    }

    /**
     * 局名を取得する
     *
     * @return 局名
     */
    public String getKyokuname() {
        return _kyokuname;
    }

    /**
     * 局名を設定する
     *
     * @param kyokuname 局名
     */
    public void setKyokuname(String kyokuname) {
        this._kyokuname = kyokuname;
    }

    /**
     * 名称を取得する
     *
     * @return 名称
     */
    public String getDataname() {
        return _dataname;
    }

    /**
     * 名称を設定する
     *
     * @param dataname 名称
     */
    public void setDataname(String dataname) {
        this._dataname = dataname;
    }

    /**
     * 出力フラグを取得する
     *
     * @return 出力フラグ
     */
    public String getOutputflg() {
        return _outputflg;
    }

    /**
     * 出力フラグを設定する
     *
     * @param outputflg 出力フラグ
     */
    public void setOutputflg(String outputflg) {
        this._outputflg = outputflg;
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
