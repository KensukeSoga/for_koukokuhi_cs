package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 車種別予算表(詳細)　検索実行時のデータ取得条件クラス
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
public class FindBudgetDetailsCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 画面ID */
    private String _formid = null;

    /** 担当者ID */
    private String _hamid = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** 過去ロック日付 */
    private Date _lockDate = null;

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * 画面IDを設定する
     *
     * @param formid 画面ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
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
     * @param dCar 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * 過去ロック日付を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getLockDate() {
        return _lockDate;
    }

    /**
     * 過去ロック日付を設定する
     *
     * @param val 期間開始
     */
    public void setLockDate(Date lockDate) {
        _lockDate = lockDate;
    }
}
