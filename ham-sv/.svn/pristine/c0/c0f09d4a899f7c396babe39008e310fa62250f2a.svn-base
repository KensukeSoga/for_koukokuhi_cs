package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費　変更内容通知検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/24 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindChangeNoticeCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 更新年月(YYYYMM) */
    private String _updMonth = null;

    /** 制作費管理NO */
    private List<BigDecimal> _sequencenoList = null;

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
     * 更新年月(YYYYMM)を取得する
     *
     * @return 更新年月(YYYYMM)
     */
    public String getUpdMonth() {
        return _updMonth;
    }

    /**
     * 更新年月(YYYYMM)を設定する
     *
     * @param updMonth 更新年月(YYYYMM)
     */
    public void setUpdMonth(String updMonth) {
        this._updMonth = updMonth;
    }

    /**
     * 制作費管理NOを取得する
     *
     * @return 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public List<BigDecimal> getSequencenoList() {
        return _sequencenoList;
    }

    /**
     * 制作費管理NOを設定する
     *
     * @param sequencenoList 制作費管理NOのリスト
     */
    public void setSequencenoList(List<BigDecimal> sequencenoList) {
        this._sequencenoList = sequencenoList;
    }
}
