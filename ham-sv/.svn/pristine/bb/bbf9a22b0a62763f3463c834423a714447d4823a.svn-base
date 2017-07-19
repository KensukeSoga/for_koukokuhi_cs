package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC見積作成登録VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/1 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterHCEstimateCreationVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** 年月 */
    private String _yearMonth = null;

    /** 見積種別 */
    private String _estimateClass;

    /** データ数 */
    private int _dataCount = 0;

    /** 最終更新日 */
    private Date _latestUpdDate = null;

    /** 最終更新者 */
    private String _lagestUpdId = null;

    /** 見積案件 新規 */
    private List<Tbj05EstimateItemVO> _insEstimateListItem = null;

    /** 見積案件 更新 */
    private List<Tbj05EstimateItemVO> _updEstimateListItem = null;

    /** 見積明細 削除 */
    private List<BigDecimal> _delEstimateDetail = null;

    /** 見積明細 新規 */
    private List<Tbj06EstimateDetailVO> _insEstimateDetail = null;

    /** 見積明細 更新 */
    private List<Tbj06EstimateDetailVO> _updEstimateDetail = null;

    /** 見積明細管理NOに紐付く制作費管理NO */
    private List<RelationSeqNoVO> _relationSeqNo = null;

    /** 電通車種コード */
    private String _dcarCd = null;

    /** HAM ID */
    private String _hamId = null;


    /**
     * デフォルトコンストラクタ
     */
    public RegisterHCEstimateCreationVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new RegisterHCEstimateCreationVO();
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
        _phase = phase;
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
        _yearMonth = yearMonth;
    }

   /**
    * 見積種別を取得します
    *
    * @return 見積種別
    */
   public String getEstimateClass() {
       return _estimateClass;
   }

   /**
    * 見積種別を設定します
    *
    * @param estimateClass 見積種別
    */
   public void setEstimateClass(String estimateClass) {
       _estimateClass = estimateClass;
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
     * 見積案件 新規を取得する
     *
     * @return 見積案件 新規
     */
    public List<Tbj05EstimateItemVO> getInsEstimateListItem() {
        return _insEstimateListItem;
    }

    /**
     * 見積案件 新規を設定する
     *
     * @param insEstimateListItem 見積案件 新規
     */
    public void setInsEstimateListItem(List<Tbj05EstimateItemVO> insEstimateListItem) {
        _insEstimateListItem = insEstimateListItem;
    }

    /**
     * 見積案件 更新を取得する
     *
     * @return 見積案件 更新
     */
    public List<Tbj05EstimateItemVO> getUpdEstimateListItem() {
        return _updEstimateListItem;
    }

    /**
     * 見積案件 更新を設定する
     *
     * @param updEstimateListItem 見積案件 更新
     */
    public void setUpdEstimateListItem(List<Tbj05EstimateItemVO> updEstimateListItem) {
        _updEstimateListItem = updEstimateListItem;
    }

    /**
     * 削除対象の見積明細管理NOを取得する
     *
     * @return 削除対象の見積明細管理NO
     */
    public List<BigDecimal> getDelEstimateDetail() {
        return _delEstimateDetail;
    }

    /**
     * 削除対象の見積明細管理NOを設定する
     *
     * @param delEstimateDetail 削除対象の見積明細管理NO
     */
    public void setDelEstimateDetail(List<BigDecimal> delEstimateDetail) {
        _delEstimateDetail = delEstimateDetail;
    }

    /**
     * 新規登録対象の見積明細を取得する
     *
     * @return 新規登録対象の見積明細
     */
    public List<Tbj06EstimateDetailVO> getInsEstimateDetail() {
        return _insEstimateDetail;
    }

    /**
     * 新規登録対象の見積明細を設定する
     *
     * @param insEstimateDetail 新規登録対象の見積明細
     */
    public void setInsEstimateDetail(List<Tbj06EstimateDetailVO> insEstimateDetail) {
        _insEstimateDetail = insEstimateDetail;
    }

    /**
     * 更新対象の見積明細を取得する
     *
     * @return 更新対象の見積明細
     */
    public List<Tbj06EstimateDetailVO> getUpdEstimateDetail() {
        return _updEstimateDetail;
    }

    /**
     * 更新対象の見積明細を設定する
     *
     * @param updEstimateDetail 更新対象の見積明細
     */
    public void setUpdEstimateDetail(List<Tbj06EstimateDetailVO> updEstimateDetail) {
        _updEstimateDetail = updEstimateDetail;
    }

    /**
     * 見積明細管理NOに紐付く制作費管理NOを取得する
     *
     * @return 見積明細管理NOに紐付く制作費管理NO
     */
    public List<RelationSeqNoVO> getRelationSeqNo() {
        return _relationSeqNo;
    }

    /**
     * 見積明細管理NOに紐付く制作費管理NOを設定する
     *
     * @param relationSeqNo 見積明細管理NOに紐付く制作費管理NO
     */
    public void setRelationSeqNo(List<RelationSeqNoVO> relationSeqNo) {
        _relationSeqNo = relationSeqNo;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarCd 電通車種コード
     */
    public void setDCarCd(String dcarCd) {
        _dcarCd = dcarCd;
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
