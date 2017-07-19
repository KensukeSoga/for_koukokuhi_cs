/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * @author lis7y1
 *
 */
/**
 * <P>
 * 制作費明細書出力検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/4 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindWorkDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private int _phase;

    /** 年月 */
    private String _crDate;

    /** 電通車種コード */
    private String _dCarCd;

    /** 区分コード */
    private String _divCd;

    /** グループコード */
    private BigDecimal _groupCd;

    /** 見積案件管理NO */
    private BigDecimal _estSeqNo;

    /**
     * フェイズを取得します
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定します
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 年月を取得します
     *
     * @return 年月
     */
    public String getCrDate() {
        return _crDate;
    }

    /**
     * 年月を設定します
     *
     * @param crDate 年月
     */
    public void setCrDate(String crDate) {
    	_crDate = crDate;
    }

    /**
     * 電通車種コードを取得します
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * 電通車種コードを設定します
     *
     * @param dCarCd 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
    	_dCarCd = dCarCd;
    }

    /**
     * 区分コードを取得します
     *
     * @return 区分コード
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * 区分コードを設定します
     *
     * @param divCd 区分コード
     */
    public void setDivCd(String divCd) {
    	_divCd = divCd;
    }

    /**
     * グループコードを取得します
     *
     * @return グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * グループコードを設定します
     *
     * @param groupCd グループコード
     */
    public void setGroupCd(BigDecimal groupCd) {
    	_groupCd = groupCd;
    }

    /**
     * 見積案件管理NOを取得します
     *
     * @return 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * 見積案件管理NOを設定します
     *
     * @param estSeqNo 見積案件管理NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
    	_estSeqNo = estSeqNo;
    }
}