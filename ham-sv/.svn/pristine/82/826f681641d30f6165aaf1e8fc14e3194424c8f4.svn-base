package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;

/**
 * <P>
 * 素材一覧VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/18 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListVO extends Tbj20SozaiKanriListVO {

    private static final long serialVersionUID = 1L;

    /**
     * カテゴリソート番号
     */
    private String _CategorySortNo = null;

    /**
     * 車種ソート番号
     */
    private BigDecimal _CarSortNo = null;

    /**
     * カテゴリ番号
     */
    private BigDecimal _CategoryNo = null;

    /**
     * 契約期間From
     */
    private Date _DateFrom = null;

    /**
     * 契約期間TO
     */
    private Date _DateTo = null;

    /**
     * 変更前車種コード
     */
    private String _prevDCarCd = null;

    /** 2015/11/30 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 系統
     */
    private String _noKbn = null;
    /** 2015/11/30 JASRAC対応 HLC K.Soga ADD End */

    /** 2016/02/18 HDX対応 HLC K.Soga ADD Start */
    /**
     * OA開始日(属性)
     */
    private String _dateFromAttr = null;

    /**
     * OA終了日(属性)
     */
    private String _dateToAttr = null;

    /**
     * NEW表示フラグ
     */
    private String _newDispFlg = null;

    /**
     * HDX開放フラグ
     */
    private String _openFlg = null;

    /**
     * 通称タイトル
     */
    private String _aliasTitle = null;

    /**
     * ぶら下がり
     */
    private String _endTitle = null;

    /**
     * BS/CS使用フラグ
     */
    private String _bscsUse = null;

    /**
     * Time使用(HDX)フラグ
     */
    private String _hdxTimeUse = null;

    /**
     * Spot使用(HDX)フラグ
     */
    private String _hdxSpotUse = null;

    /**
     * Spot契約名
     */
    private String _spotCtrt = null;

    /**
     * Spot期間(開始)
     */
    private Date _spotFrom = null;

    /**
     * Spot期間(終了)
     */
    private Date _spotTo = null;

    /**
     * 使用要望
     */
    private String _hmOrder = null;

    /**
     * 貼付要望欄
     */
    private String _layoutOrder = null;

    /**
     * OA不可期間
     */
    private String _oaNgSpan = null;

    /**
     * ターゲット
     */
    private String _target = null;

    /**
     * 車種NEWS
     */
    private String _carNews = null;

    /**
     * 次回車種NEWS
     */
    private String _nextCarNews = null;

    /**
     * 他メディア使用有無(ムービーチャンネル)
     */
    private String _otherMediaUse_mvchl = null;

    /**
     * 他メディア使用有無(HondaYouTube)
     */
    private String _otherMediaUse_youTube = null;

    /**
     * 他メディア使用有無(MXTV)
     */
    private String _otherMediaUse_mxtv = null;

    /**
     * 他メディア使用有無(京セラドーム)
     */
    private String _otherMediaUse_kyoseraDm = null;

    /**
     * 他メディア使用有無(サーキットビジョン)
     */
    private String _otherMediaUse_circuitVs = null;

    /**
     * 他メディア使用有無(フォーミュラニッポン)
     */
    private String _otherMediaUse_fmJpn = null;

    /**
     * 他メディア使用有無(WTCC)
     */
    private String _otherMediaUse_wtcc = null;

    /**
     * 他メディア使用有無(予備項目1)
     */
    private String _otherMediaUse_other1 = null;

    /**
     * 他メディア使用有無(予備項目2)
     */
    private String _otherMediaUse_other2 = null;

    /**
     * 他メディア使用有無(予備項目2)
     */
    private String _otherMediaUse_other3 = null;

    /**
     * OA期間
     */
    private String _oaDateTerm = null;
    /** 2016/02/18 HDX対応 HLC K.Soga ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public MaterialListVO() {
        super();
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new MaterialListVO();
    }

    /**
     * カテゴリソート番号を取得する
     * @return
     */
    public String getCATEGORY_SORTNO() {
        return _CategorySortNo;
    }

    /**
     * カテゴリソート番号を設定する
     * @param val
     */
    public void setCATEGORY_SORTNO(String val) {
        _CategorySortNo = val;
    }

    /**
     * 車種ソート番号を取得する
     * @return
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCAR_SORTNO() {
        return _CarSortNo;
    }

    /**
     * 車種ソート番号を取得する
     * @return
     */
    public void setCAR_SORTNO(BigDecimal val) {
        _CarSortNo = val;
    }

    /**
     * カテゴリ番号を取得する
     * @return
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCATEGORYNO() {
        return _CategoryNo;
    }

    /**
     * カテゴリ番号をセットする
     * @param val
     */
    public void setCATEGORYNO(BigDecimal val) {
        _CategoryNo = val;
    }

    /**
     * 契約期間(From)を取得する
     *
     * @return 契約期間(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCNTDATEFROM() {
        return _DateFrom;
    }

    /**
     * 契約期間(From)を設定する
     *
     * @param val 契約期間(From)
     */
    public void setCNTDATEFROM(Date val) {
        _DateFrom = val;
    }

    /**
     * 契約期間(To)を取得する
     *
     * @return 契約期間(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCNTDATETO() {
        return _DateTo;
    }

    /**
     * 契約期間(To)を設定する
     *
     * @param val 契約期間(To)
     */
    public void setCNTDATETO(Date val) {
        _DateTo = val;
    }

    /**
     * 変更前車種コードを設定します
     * @param val
     */
    public void setPrevDCarCd(String val) {
        _prevDCarCd = val;
    }

    /**
     * 変更前車種コードを取得します
     * @return
     */
    public String getPrevDCarCd() {
        return _prevDCarCd;
    }

    /** 2015/11/30 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 系統を設定します
     * @param val
     */
    public void setNOKBN(String val) {
        _noKbn = val;
    }

    /**
     * 系統を取得します
     * @return
     */
    public String getNOKBN() {
        return _noKbn;
    }
    /** 2015/11/30 JASRAC対応 HLC K.Soga ADD End */

    /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
    /**
     * OA開始日(属性)を設定します
     * @param val
     */
    public void setDATEFROM_ATTR(String val) {
        _dateFromAttr = val;
    }

    /**
     * OA開始日(属性)を取得します
     * @return
     */
    public String getDATEFROM_ATTR() {
        return _dateFromAttr;
    }

    /**
     * OA終了日(属性)を設定します
     * @param val
     */
    public void setDATETO_ATTR(String val) {
        _dateToAttr = val;
    }

    /**
     * OA終了日(属性)を取得します
     * @return
     */
    public String getDATETO_ATTR() {
        return _dateToAttr;
    }

    /**
     * NEW表示フラグを設定します
     * @param val
     */
    public void setNEWDISPFLG(String val) {
        _newDispFlg = val;
    }

    /**
     * NEW表示フラグを取得します
     * @return
     */
    public String getNEWDISPFLG() {
        return _newDispFlg;
    }

    /**
     * HDX開放フラグを設定します
     * @param val
     */
    public void setOPENFLG(String val) {
        _openFlg = val;
    }

    /**
     * HDX開放フラグを取得します
     * @return
     */
    public String getOPENFLG() {
        return _openFlg;
    }

    /**
     * 通称タイトルを設定します
     * @param val
     */
    public void setALIASTITLE(String val) {
        _aliasTitle = val;
    }

    /**
     * 通称タイトルを取得します
     * @return
     */
    public String getALIASTITLE() {
        return _aliasTitle;
    }

    /**
     * ぶら下がりを設定します
     * @param val
     */
    public void setENDTITLE(String val) {
        _endTitle = val;
    }

    /**
     * ぶら下がりを取得します
     * @return
     */
    public String getENDTITLE() {
        return _endTitle;
    }

    /**
     * BS/CS使用フラグを設定します
     * @param val
     */
    public void setBSCSUSE(String val) {
        _bscsUse = val;
    }

    /**
     * BS/CS使用フラグを取得します
     * @return
     */
    public String getBSCSUSE() {
        return _bscsUse;
    }

    /**
     * Time使用(HDX)フラグを設定します
     * @param val
     */
    public void setHDXTIMEUSE(String val) {
        _hdxTimeUse = val;
    }

    /**
     * Time使用(HDX)フラグを取得します
     * @return
     */
    public String getHDXTIMEUSE() {
        return _hdxTimeUse;
    }

    /**
     * Spot使用(HDX)フラグを設定します
     * @param val
     */
    public void setHDXSPOTUSE(String val) {
        _hdxSpotUse = val;
    }

    /**
     * Spot使用(HDX)フラグを取得します
     * @return
     */
    public String getHDXSPOTUSE() {
        return _hdxSpotUse;
    }

    /**
     * Spot契約名を設定します
     * @param val
     */
    public void setSPOTCTRT(String val) {
        _spotCtrt = val;
    }

    /**
     * Spot契約名を取得します
     * @return
     */
    public String getSPOTCTRT() {
        return _spotCtrt;
    }

    /**
     * SPOT期間(開始)を設定する
     *
     * @param val SPOT期間(開始)
     */
    public void setSPOTFROM(Date val) {
        _spotFrom = val;
    }

    /**
     * SPOT期間(開始)を取得する
     *
     * @return SPOT期間(開始)
     */
    @XmlElement(required = true, nillable = true)
    public Date getSPOTFROM() {
        return _spotFrom;
    }

    /**
     * SPOT期間(終了)を設定する
     *
     * @param val SPOT期間(終了)
     */
    public void setSPOTTO(Date val) {
        _spotTo = val;
    }

    /**
     * SPOT期間(終了)を取得する
     *
     * @return SPOT期間(終了)
     */
    @XmlElement(required = true, nillable = true)
    public Date getSPOTTO() {
        return _spotTo;
    }

    /**
     * 使用要望を設定します
     * @param val
     */
    public void setHMORDER(String val) {
        _hmOrder = val;
    }

    /**
     * 使用要望を取得します
     * @return
     */
    public String getHMORDER() {
        return _hmOrder;
    }

    /**
     * 貼付要望欄を設定します
     * @param val
     */
    public void setLAYOUTORDER(String val) {
        _layoutOrder = val;
    }

    /**
     * 貼付要望欄を取得します
     * @return
     */
    public String getLAYOUTORDER() {
        return _layoutOrder;
    }

    /**
     * OA不可期間を設定します
     * @param val
     */
    public void setOANGSPAN(String val) {
        _oaNgSpan = val;
    }

    /**
     * OA不可期間を取得します
     * @return
     */
    public String getOANGSPAN() {
        return _oaNgSpan;
    }

    /**
     * ターゲットを設定します
     * @param val
     */
    public void setTARGET(String val) {
        _target = val;
    }

    /**
     * ターゲットを取得します
     * @return
     */
    public String getTARGET() {
        return _target;
    }

    /**
     * 車種NEWSを設定します
     * @param val
     */
    public void setCARNEWS(String val) {
        _carNews = val;
    }

    /**
     * 車種NEWSを取得します
     * @return
     */
    public String getCARNEWS() {
        return _carNews;
    }

    /**
     * 次回車種NEWSを設定します
     * @param val
     */
    public void setNEXTCARNEWS(String val) {
        _nextCarNews = val;
    }

    /**
     * 次回車種NEWSを取得します
     * @return
     */
    public String getNEXTCARNEWS() {
        return _nextCarNews;
    }

    /**
     * 他メディア使用有無(ムービーチャンネル)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_MVCHL(String val) {
        _otherMediaUse_mvchl = val;
    }

    /**
     * 他メディア使用有無(ムービーチャンネル)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_MVCHL() {
        return _otherMediaUse_mvchl;
    }

    /**
     * 他メディア使用有無(HondaYouTube)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_YOUTUBE(String val) {
        _otherMediaUse_youTube = val;
    }

    /**
     * 他メディア使用有無(HondaYouTube)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_YOUTUBE() {
        return _otherMediaUse_youTube;
    }

    /**
     * 他メディア使用有無(MXTV)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_MXTV(String val) {
        _otherMediaUse_mxtv = val;
    }

    /**
     * 他メディア使用有無(MXTV)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_MXTV() {
        return _otherMediaUse_mxtv;
    }

    /**
     * 他メディア使用有無(京セラドーム)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_KYOSERADM(String val) {
        _otherMediaUse_kyoseraDm = val;
    }

    /**
     * 他メディア使用有無(京セラドーム)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_KYOSERADM() {
        return _otherMediaUse_kyoseraDm;
    }

    /**
     * 他メディア使用有無(サーキットビジョン)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_CIRCUITVS(String val) {
        _otherMediaUse_circuitVs = val;
    }

    /**
     * 他メディア使用有無(サーキットビジョン)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_CIRCUITVS() {
        return _otherMediaUse_circuitVs;
    }

    /**
     * 他メディア使用有無(フォーミュラニッポン)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_FMJPN(String val) {
        _otherMediaUse_fmJpn = val;
    }

    /**
     * 他メディア使用有無(フォーミュラニッポン)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_FMJPN() {
        return _otherMediaUse_fmJpn;
    }

    /**
     * 他メディア使用有無(WTCC)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_WTCC(String val) {
        _otherMediaUse_wtcc = val;
    }

    /**
     * 他メディア使用有無(WTCC)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_WTCC() {
        return _otherMediaUse_wtcc;
    }

    /**
     * 他メディア使用有無(予備項目1)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_OTHER1(String val) {
        _otherMediaUse_other1 = val;
    }

    /**
     * 他メディア使用有無(予備項目1)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_OTHER1() {
        return _otherMediaUse_other1;
    }

    /**
     * 他メディア使用有無(予備項目2)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_OTHER2(String val) {
        _otherMediaUse_other2 = val;
    }

    /**
     * 他メディア使用有無(予備項目2)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_OTHER2() {
        return _otherMediaUse_other2;
    }

    /**
     * 他メディア使用有無(予備項目3)を設定します
     * @param val
     */
    public void setOTHERMEDIAUSE_OTHER3(String val) {
        _otherMediaUse_other3 = val;
    }

    /**
     * 他メディア使用有無(予備項目3)を取得します
     * @return
     */
    public String getOTHERMEDIAUSE_OTHER3() {
        return _otherMediaUse_other3;
    }

    /**
     * OA期間を設定します
     * @param val
     */
    public void setOADATETERM(String val) {
        _oaDateTerm = val;
    }

    /**
     * OA期間を取得します
     * @return
     */
    public String getOADATETERM() {
        return _oaDateTerm;
    }
    /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
}