package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj20CarCategory;

/**
 * <P>
 * 素材一覧画面ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 HAMチーム)<BR>
 * ・HDX対応(2016/02/17 HLC K.Soga)<BR>
 * </P>
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class LogMaterialListVO extends Tbj26LogSozaiKanriListVO {

    private static final long serialVersionUID = 1L;

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
     * HC担当者
     */
    private String _hcSyatan = null;

    /**
     * HM担当者
     */
    private String _hmSyatan = null;

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
    public LogMaterialListVO() {
        //スーパークラスのコンストラクタを呼び出す
        super();
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new LogMaterialListVO();
    }

    /**
     * 車種名称を取得する
     *
     * @return 車種名称
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名称を設定する
     *
     * @param val 車種名称
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * カテゴリ名称を取得する
     *
     * @return カテゴリ名称
     */
    public String getCATEGORYNM() {
        return (String) get(Mbj20CarCategory.CATEGORYNM);
    }

    /**
     * カテゴリ名称を設定する
     *
     * @param val カテゴリ名称
     */
    public void setCATEGORYNM(String val) {
        set(Mbj20CarCategory.CATEGORYNM, val);
    }

    /**
     * 履歴名称を取得する
     *
     * @return 履歴名称
     */
    public String getHISTORYNM() {
        return (String) get("HISTORYNM");
    }

    /**
     * 履歴名称を設定する
     *
     * @param val 履歴名称
     */
    public void setHISTORYNM(String val) {
        set("HISTORYNM", val);
    }

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
     * HC担当者を設定します
     * @param val
     */
    public void setHCSYATAN(String val) {
        _hcSyatan = val;
    }

    /**
     * HC担当者を取得します
     * @return
     */
    public String getHCSYATAN() {
        return _hcSyatan;
    }

    /**
     * HM担当者を設定します
     * @param val
     */
    public void setHMSYATAN(String val) {
        _hmSyatan = val;
    }

    /**
     * HM担当者を取得します
     * @return
     */
    public String getHMSYATAN() {
        return _hmSyatan;
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
