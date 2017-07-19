package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積一覧登録VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterHCEstimateListVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 制作原価かどうか */
    private String _cost = null;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** 年月 */
    private String _yearMonth = null;

    /** 見積案件管理NO */
    private List<BigDecimal> _estseqno = null;

    /** コードタイプ */
    private String _codeType = null;

    /** データ数 */
    private int _dataCount = 0;

    /** 最終更新日 */
    private Date _latestUpdDate = null;

    /** 最終更新者 */
    private String _lagestUpdId = null;

    /** HAM ID */
    private String _hamId = null;


    /**
     * デフォルトコンストラクタ
     */
    public RegisterHCEstimateListVO() {
    }

    /**
     * 制作原価かどうかを取得する
     *
     * @return 制作原価かどうか
     */
    public String getCost() {
        return _cost;
    }

    /**
     * 制作原価かどうかを設定する
     *
     * @param cost 制作原価かどうか
     */
    public void setCost(String cost) {
        _cost = cost;
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
     * 年月を取得する
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        this._yearMonth = yearMonth;
    }

    /**
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    public List<BigDecimal> getEstseqno() {
        return _estseqno;
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param estseqno 見積案件管理NO
     */
    public void setEstseqno(List<BigDecimal> estseqno) {
        this._estseqno = estseqno;
    }

    /**
     * コードタイプを取得します
     *
     * @return コードタイプ
     */
    public String getCodeType() {
        return _codeType;
    }

    /**
     * コードタイプを設定します
     *
     * @param codeType コードタイプ
     */
    public void setCodeType(String codeType) {
        _codeType = codeType;
    }

    /**
     * データ数を取得する
     * @return
     */
    public int getDataCount() {
        return _dataCount;
    }

    /**
     * データ数を設定する
     *
     * @param dataCount データ数
     */
    public void setDataCount(int dataCount) {
        _dataCount = dataCount;
    }

    /**
     * 最終更新日を取得する
     *
     * @return 最終更新日
     */
    @XmlElement(required = true, nillable = true)
    public Date getLatestUpdDate() {
        return _latestUpdDate;
    }

    /**
     * 最終更新日を設定する
     *
     * @param latestUpdDate 最終更新日
     */
    public void setLatestUpdDate(Date latestUpdDate) {
        _latestUpdDate = latestUpdDate;
    }

    /**
     * 最終更新者IDを取得する
     *
     * @return 最終更新者ID
     */
    public String getLatestUpdId() {
        return _lagestUpdId;
    }

    /**
     * 最終更新者IDを設定する
     *
     * @param lagestUpdId 最終更新者ID
     */
    public void setLatestUpdId(String lagestUpdId) {
        _lagestUpdId = lagestUpdId;
    }

    /**
     * HAM IDを取得する
     *
     * @return HAM ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * HAM IDを設定する
     *
     * @param hamId HAM ID
     */
    public void setHamId(String hamId) {
        _hamId = hamId;
    }
}
