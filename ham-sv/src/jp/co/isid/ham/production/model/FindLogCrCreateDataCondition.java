package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
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
public class FindLogCrCreateDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 年月 */
    private Date _crDate = null;

    /** 制作費管理NO */
    private BigDecimal _sequenceno = null;

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
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarcd 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true)
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
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true)
    public Date getCrDate() {
        return _crDate;
    }

    /**
     * 年月を設定する
     *
     * @param crdate 年月
     */
    public void setCrDate(Date crDate) {
        this._crDate = crDate;
    }

    /**
     * 制作費管理NOを取得する
     *
     * @return 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSequenceno() {
        return _sequenceno;
    }

    /**
     * 制作費管理NOを設定する
     *
     * @param sequenceno 制作費管理NO
     */
    public void setSequenceno(BigDecimal sequenceno) {
        this._sequenceno = sequenceno;
    }
}
