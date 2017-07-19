package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 車種＆車種検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class CarListCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 系列コード */
    private String _keiretsucd = null;

    /** 車種名 */
    private String _carnm = null;

    /** ソートNo */
    private BigDecimal _sortno = null;

    /** 権限 */
    private String _authority = null;

    /** 担当者ID */
    private String _hamid = null;

    /** 種別 */
    private String _secType = null;


    /**
     * デフォルトコンストラクタ
     */
    public CarListCondition() {
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
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCarnm() {
        return _carnm;
    }

    /**
     * 車種名を設定する
     *
     * @param carnm 車種名
     */
    public void setCarnm(String carnm) {
        this._carnm = carnm;
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
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAuthority() {
        return _authority;
    }

    /**
     * 権限を設定する
     *
     * @param authority 権限
     */
    public void setAuthority(String authority) {
        this._authority = authority;
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
     * 種別を取得する
     *
     * @return 種別
     */
    public String getSecType() {
        return _secType;
    }

    /**
     * 種別を設定する
     *
     * @param secType 種別
     */
    public void setSecType(String secType) {
        this._secType = secType;
    }
}
