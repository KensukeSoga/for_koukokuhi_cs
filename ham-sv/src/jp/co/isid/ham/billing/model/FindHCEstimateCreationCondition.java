package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC見積作成検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/13 T.Fujiyoshi)<BR>
 * ・請求業務変更不具合対応(2016/03/16 HLC K.Soga)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateCreationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 画面ID */
    private String _formId;

    /** 種別 */
    private String _funcType;

    /** HAM ID */
    private String _hamId = null;

    /** コードタイプ */
    private List<String> _codeType = null;

    /** 見積案件管理NO */
    private BigDecimal _estSeqNo;

    /** フェイズ */
    private BigDecimal _phase;

    /** 現在のフェイズ */
    private int _currentPhase;

    /** 年月 */
    private String _yearMonth;

    /** 前年月 */
    private String _prevYearMonth;

    /** 見積種別 */
    private String _estimateClass;

    /** 開始日 */
    private Date _startDate;

    /** 終了日 */
    private Date _endDate;

    /** 電通車種コード */
    private String _dcarCd = null;

    /** 区分コード */
    private String _divCd = null;

    /** グループコード */
    private BigDecimal _groupCd = null;

    /** VIEW ID */
    private String _viewid = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** ユーザ種別 */
    private String _usertype = null;

    /** セキュリティコード */
    private String _securitycd = null;


    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormId() {
        return _formId;
    }

    /**
     * 画面IDを設定する
     *
     * @param formID 画面ID
     */
    public void setFormId(String formId) {
        _formId = formId;
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getFuncType() {
        return _funcType;
    }

    /**
     * 種別を設定する
     *
     * @param funcid 種別
     */
    public void setFuncType(String functype) {
        _funcType = functype;
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

    /**
     * コードタイプを取得します
     *
     * @return コードタイプ
     */
    public List<String> getCodeType() {
        return _codeType;
    }

    /**
     * コードタイプを設定します
     *
     * @param codeType コードタイプ
     */
    public void setCodeType(List<String> codeType) {
        _codeType = codeType;
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

    /**
     * フェイズを取得します
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定します
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * 現在のフェイズを取得します
     *
     * @return 現在のフェイズ
     */
    public int getCurrentPhase() {
        return _currentPhase;
    }

    /**
     * 現在のフェイズの設定します
     *
     * @param currentPhase 現在のフェイズ
     */
    public void setCurrentPhase(int currentPhase) {
        _currentPhase = currentPhase;
    }

    /**
     * 年月を取得します
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定します
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * 前年月を取得します
     *
     * @return 前年月
     */
    public String getPrevYearMonth() {
        return _prevYearMonth;
    }

    /**
     * 前年月を設定します
     *
     * @param prevYearMonth 前年月
     */
    public void setPrevYearMonth(String prevYearMonth) {
        _prevYearMonth = prevYearMonth;
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
    * 開始日を取得する
    *
    * @return 開始日
    */
   @XmlElement(required = true, nillable = true)
   public Date getStartDate() {
       return _startDate;
   }

   /**
    * 開始日を設定する
    *
    * @param startDate 終了日
    */
   public void setStartDate(Date startDate) {
       _startDate = startDate;
   }

   /**
    * 終了日を取得する
    *
    * @return 終了日
    */
   @XmlElement(required = true, nillable = true)
   public Date getEndDate() {
       return _endDate;
   }

   /**
    * 終了日を設定する
    *
    * @param endDate 終了日
    */
   public void setEndDate(Date endDate) {
       _endDate = endDate;
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
    * 区分コード
    *
    * @return 区分コード
    */
   public String getDivCd() {
       return _divCd;
   }

   /**
    * 区分コード
    *
    * @param divCd 区分コード
    */
   public void setDivCd(String divCd) {
       _divCd = divCd;
   }

   /**
    * グループコードを取得する
    *
    * @return グループコード
    */
   @XmlElement(required = true, nillable = true)
   public BigDecimal getGroupCd() {
       return _groupCd;
   }

   /**
    * グループコードを設定する
    *
    * @param groupCd グループコード
    */
   public void setGroupCd(BigDecimal groupCd) {
       _groupCd = groupCd;
   }

   /**
    * VIEW IDを取得する
    *
    * @return VIEW ID
    */
   public String getViewID() {
       return _viewid;
   }

   /**
    * VIEW IDを設定する
    *
    * @param viewid VIEW ID
    */
   public void setViewID(String viewid) {
       _viewid = viewid;
   }

   /**
    * 局コードを取得する
    *
    * @return 局コード
    */
   public String getKksikognzuntcd()
   {
       return _kksikognzuntcd;
   }

   /**
    * 局コードを設定する
    *
    * @param kksikognzuntcd 局コード
    */
   public void setKksikognzuntcd(String kksikognzuntcd)
   {
       this._kksikognzuntcd = kksikognzuntcd;
   }

   /**
    * ユーザ種別を取得する
    *
    * @return ユーザ種別
    */
   public String getUsertype() {
       return _usertype;
   }

   /**
    * ユーザ種別を設定する
    *
    * @param usertype ユーザ種別
    */
   public void setUsertype(String usertype) {
       this._usertype = usertype;
   }

   /**
    * セキュリティコードを取得する
    *
    * @return セキュリティコード
    */
   public String getSecuritycd()
   {
       return _securitycd;
   }

   /**
    * セキュリティコードを設定する
    *
    * @param securitycd セキュリティコード
    */
   public void setSecuritycd(String securitycd)
   {
       this._securitycd = securitycd;
   }
}
