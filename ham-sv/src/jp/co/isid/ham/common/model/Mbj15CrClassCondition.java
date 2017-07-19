package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR予算分類マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj15CrClassCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 分類コード */
    private String _classcd = null;

    /** 開始年月日 */
    private Date _datefrom = null;

    /** 終了年月日 */
    private Date _dateto = null;

    /** 分類名 */
    private String _classnm = null;

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
    public Mbj15CrClassCondition() {
    }

    /**
     * 分類コードを取得する
     *
     * @return 分類コード
     */
    public String getClasscd() {
        return _classcd;
    }

    /**
     * 分類コードを設定する
     *
     * @param classcd 分類コード
     */
    public void setClasscd(String classcd) {
        this._classcd = classcd;
    }

    /**
     * 開始年月日を取得する
     *
     * @return 開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDatefrom() {
        return _datefrom;
    }

    /**
     * 開始年月日を設定する
     *
     * @param datefrom 開始年月日
     */
    public void setDatefrom(Date datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * 終了年月日を取得する
     *
     * @return 終了年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateto() {
        return _dateto;
    }

    /**
     * 終了年月日を設定する
     *
     * @param dateto 終了年月日
     */
    public void setDateto(Date dateto) {
        this._dateto = dateto;
    }

    /**
     * 分類名を取得する
     *
     * @return 分類名
     */
    public String getClassnm() {
        return _classnm;
    }

    /**
     * 分類名を設定する
     *
     * @param classnm 分類名
     */
    public void setClassnm(String classnm) {
        this._classnm = classnm;
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
