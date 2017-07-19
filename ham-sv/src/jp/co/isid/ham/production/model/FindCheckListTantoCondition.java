package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費　検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCheckListTantoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 得意先コード */
    private String[] _tokuisakiCdList = null;

    /** 期間From */
    private Date _fromDate = null;

    /** 期間To */
    private Date _toDate = null;

    /** 発注局コード */
    private String[] _kyokuCdList = null;

    /**
     * 営業所コード
     */
    private String _egsCd = null;

    /** 営業日 */
    private String _eigyobi = null;

    /**
     * 得意先コードを取得する
     *
     * @return 得意先コード
     */
    @XmlElement(required = true)
    public String[] getTokuisakiCdList() {
        return _tokuisakiCdList;
    }

    /**
     * 得意先コードを設定する
     *
     * @param tokuisakiCd 得意先コード
     */
    public void setTokuisakiCdList(String[] tokuisakiCdList) {
        this._tokuisakiCdList = tokuisakiCdList;
    }

    /**
     * 期間Fromを取得する
     *
     * @return 期間From
     */
    @XmlElement(required = true)
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * 期間Fromを設定する
     *
     * @param fromDate 期間From
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * 期間Toを取得する
     *
     * @return 期間To
     */
    @XmlElement(required = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * 期間Toを設定する
     *
     * @param toDate 期間To
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * 発注局コードを取得する
     *
     * @return 発注局コード
     */
    @XmlElement(required = true)
    public String[] getKyokuCdList() {
        return _kyokuCdList;
    }

    /**
     * 発注局コードを設定する
     *
     * @param kyokuCdList 発注局コード
     */
    public void setKyokuCdList(String[] kyokuCdList) {
        this._kyokuCdList = kyokuCdList;
    }

    /**
     * 営業所コードを取得する
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * 営業所コードを設定する
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }

    /**
     * 営業日を取得する
     *
     * @return 営業日
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * 営業日を設定する
     *
     * @param eigyobi 営業日
     */
    public void setEigyobi(String eigyobi) {
        _eigyobi = eigyobi;
    }
}
