package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;


public class FindMediaPlanCondition implements Serializable {

    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /** フェイズ */
   private BigDecimal _phase;

   /** 車種コード */
   private String _dcarcd;

   /** 初回起動確認フラグ */
   private boolean _campaignflg;

   /** 実行ユーザID */
   private String _hamid;

   /** 種別(媒体なので0固定) */
   private String _sectype;

   /**FunctionType*/
   private String _functiontype;

   /**画面ID*/
   private String _formId;

   /** ユーザ種別 */
   private String _usertype = null;

   /** 局コード */
   private String _kksikognzuntcd = null;

   /** セキュリティコード */
   private String _securitycd = null;

   /**
    * デフォルトコンストラクタ
    */
   public FindMediaPlanCondition() {
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
    * 車種コードを取得する
    *
    * @return 車種コード
    */
   @XmlElement(required = true)
   public String getDcarcd() {
       return _dcarcd;
   }

   /**
    * 車種コードを設定する
    *
    * @param dcarcd 車種コード
    */
   public void setDcarcd(String dcarcd) {
       this._dcarcd = dcarcd;
   }

  /**
   * フラグを取得する
   *
   * @return フラグ
   */
  public boolean getCampaignflg() {
      return _campaignflg;
  }

  /**
   * フラグを設定する
   *
   * @param campaignflg フラグ
   */
  public void setCampaignflg(boolean campaignflg) {
      this._campaignflg = campaignflg;
  }

  /**
   * ユーザIDを取得する
   *
   * @return ユーザID
   */
  public String getHamid() {
      return _hamid;
  }

  /**
   * ユーザIDを設定する
   *
   * @param hamid ユーザID
   */
  public void setHamid(String hamid) {
      this._hamid = hamid;
  }

  /**
   * 種別を取得する
   *
   * @return 種別
   */
  public String getSectype() {
      return _sectype;
  }

  /**
   * 種別を設定する
   *
   * @param sectype 種別
   */
  public void setSectype(String sectype) {
      this._sectype = sectype;
  }

  /**
   * @return FunctionTypeを取得する
   */
  public String getFunctionType() {
      return _functiontype;
  }
  /**
   * @param formId FunctionTypeを取得する
   */
  public void setFunctionType(String functiontype) {
      this._functiontype = functiontype;
  }

  /**
   * @return formId
   */
  public String getFormID() {
      return _formId;
  }
  /**
   * @param formId セットする formId
   */
  public void setFormID(String formId) {
      this._formId = formId;
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
