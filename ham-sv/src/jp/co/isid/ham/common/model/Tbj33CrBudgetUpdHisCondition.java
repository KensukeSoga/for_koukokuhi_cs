package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR予算更新履歴検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj33CrBudgetUpdHisCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 電通車種コード */
    private String _dcarcd = null;

    /** 分類コード */
    private String _classcd = null;

    /** 費目コード */
    private String _expcd = null;

    /** データ作成日時 */
    private Date _crtdate = null;

    /** データ作成者 */
    private String _crtnm = null;

    /** 作成プログラム */
    private String _crtapl = null;

    /** 作成担当者ID */
    private String _crtid = null;

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
    public Tbj33CrBudgetUpdHisCondition() {
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
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getExpcd() {
        return _expcd;
    }

    /**
     * 費目コードを設定する
     *
     * @param expcd 費目コード
     */
    public void setExpcd(String expcd) {
        this._expcd = expcd;
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * データ作成日時を設定する
     *
     * @param crtdate データ作成日時
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * データ作成者を設定する
     *
     * @param crtnm データ作成者
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * 作成プログラムを設定する
     *
     * @param crtapl 作成プログラム
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param crtid 作成担当者ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
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
