package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有）VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj42SozaiKanriListCmnVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj42SozaiKanriListCmnVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj42SozaiKanriListCmnVO();
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj42SozaiKanriListCmn.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj42SozaiKanriListCmn.DCARCD, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj42SozaiKanriListCmn.SOZAIYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSOZAIYM(Date val) {
        set(Tbj42SozaiKanriListCmn.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getRECKBN() {
        return (String) get(Tbj42SozaiKanriListCmn.RECKBN);
    }

    /**
     * 作成区分を設定する
     *
     * @param val 作成区分
     */
    public void setRECKBN(String val) {
        set(Tbj42SozaiKanriListCmn.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRECNO() {
        return (String) get(Tbj42SozaiKanriListCmn.RECNO);
    }

    /**
     * 作成番号を設定する
     *
     * @param val 作成番号
     */
    public void setRECNO(String val) {
        set(Tbj42SozaiKanriListCmn.RECNO, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj42SozaiKanriListCmn.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj42SozaiKanriListCmn.DELFLG, val);
    }

    /**
     * 共通コードを取得する
     *
     * @return 共通コード
     */
    public String getCMCD() {
        return (String) get(Tbj42SozaiKanriListCmn.CMCD);
    }

    /**
     * 共通コードを設定する
     *
     * @param val 共通コード
     */
    public void setCMCD(String val) {
        set(Tbj42SozaiKanriListCmn.CMCD, val);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj42SozaiKanriListCmn.TEMPCMCD);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param val 仮10桁CMｺｰﾄﾞ
     */
    public void setTEMPCMCD(String val) {
        set(Tbj42SozaiKanriListCmn.TEMPCMCD, val);
    }

    /**
     * 通称タイトルを取得する
     *
     * @return 通称タイトル
     */
    public String getALIASTITLE() {
        return (String) get(Tbj42SozaiKanriListCmn.ALIASTITLE);
    }

    /**
     * 通称タイトルを設定する
     *
     * @param val 通称タイトル
     */
    public void setALIASTITLE(String val) {
        set(Tbj42SozaiKanriListCmn.ALIASTITLE, val);
    }

    /**
     * ぶら下がりを取得する
     *
     * @return ぶら下がり
     */
    public String getENDTITLE() {
        return (String) get(Tbj42SozaiKanriListCmn.ENDTITLE);
    }

    /**
     * ぶら下がりを設定する
     *
     * @param val ぶら下がり
     */
    public void setENDTITLE(String val) {
        set(Tbj42SozaiKanriListCmn.ENDTITLE, val);
    }

    /**
     * BS/CS使用フラグを取得する
     *
     * @return BS/CS使用フラグ
     */
    public String getBSCSUSE() {
        return (String) get(Tbj42SozaiKanriListCmn.BSCSUSE);
    }

    /**
     * BS/CS使用フラグを設定する
     *
     * @param val BS/CS使用フラグ
     */
    public void setBSCSUSE(String val) {
        set(Tbj42SozaiKanriListCmn.BSCSUSE, val);
    }

    /**
     * Time使用フラグを取得する
     *
     * @return Time使用フラグ
     */
    public String getTIMEUSE() {
        return (String) get(Tbj42SozaiKanriListCmn.TIMEUSE);
    }

    /**
     * Time使用フラグを設定する
     *
     * @param val Time使用フラグ
     */
    public void setTIMEUSE(String val) {
        set(Tbj42SozaiKanriListCmn.TIMEUSE, val);
    }

    /**
     * Spot使用フラグを取得する
     *
     * @return Spot使用フラグ
     */
    public String getSPOTUSE() {
        return (String) get(Tbj42SozaiKanriListCmn.SPOTUSE);
    }

    /**
     * Spot使用フラグを設定する
     *
     * @param val Spot使用フラグ
     */
    public void setSPOTUSE(String val) {
        set(Tbj42SozaiKanriListCmn.SPOTUSE, val);
    }

    /**
     * Spot契約名を取得する
     *
     * @return Spot契約名
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj42SozaiKanriListCmn.SPOTCTRT);
    }

    /**
     * Spot契約名を設定する
     *
     * @param val Spot契約名
     */
    public void setSPOTCTRT(String val) {
        set(Tbj42SozaiKanriListCmn.SPOTCTRT, val);
    }

    /**
     * Spot開始日を取得する
     *
     * @return Spot開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getSPOTFROM() {
        return (Date) get(Tbj42SozaiKanriListCmn.SPOTFROM);
    }

    /**
     * Spot開始日を設定する
     *
     * @param val Spot開始日
     */
    public void setSPOTFROM(Date val) {
        set(Tbj42SozaiKanriListCmn.SPOTFROM, val);
    }

    /**
     * Spot終了日を取得する
     *
     * @return Spot終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getSPOTTO() {
        return (Date) get(Tbj42SozaiKanriListCmn.SPOTTO);
    }

    /**
     * Spot終了日を設定する
     *
     * @param val Spot終了日
     */
    public void setSPOTTO(Date val) {
        set(Tbj42SozaiKanriListCmn.SPOTTO, val);
    }

    /**
     * 使用要望を取得する
     *
     * @return 使用要望
     */
    public String getHMORDER() {
        return (String) get(Tbj42SozaiKanriListCmn.HMORDER);
    }

    /**
     * 使用要望を設定する
     *
     * @param val 使用要望
     */
    public void setHMORDER(String val) {
        set(Tbj42SozaiKanriListCmn.HMORDER, val);
    }

    /**
     * 貼付要望欄を取得する
     *
     * @return 貼付要望欄
     */
    public String getLAYOUTORDER() {
        return (String) get(Tbj42SozaiKanriListCmn.LAYOUTORDER);
    }

    /**
     * 貼付要望欄を設定する
     *
     * @param val 貼付要望欄
     */
    public void setLAYOUTORDER(String val) {
        set(Tbj42SozaiKanriListCmn.LAYOUTORDER, val);
    }

    /**
     * OA不可期間を取得する
     *
     * @return OA不可期間
     */
    public String getOANGSPAN() {
        return (String) get(Tbj42SozaiKanriListCmn.OANGSPAN);
    }

    /**
     * OA不可期間を設定する
     *
     * @param val OA不可期間
     */
    public void setOANGSPAN(String val) {
        set(Tbj42SozaiKanriListCmn.OANGSPAN, val);
    }

    /**
     * ターゲットを取得する
     *
     * @return ターゲット
     */
    public String getTARGET() {
        return (String) get(Tbj42SozaiKanriListCmn.TARGET);
    }

    /**
     * ターゲットを設定する
     *
     * @param val ターゲット
     */
    public void setTARGET(String val) {
        set(Tbj42SozaiKanriListCmn.TARGET, val);
    }

    /**
     * 車種NEWSを取得する
     *
     * @return 車種NEWS
     */
    public String getCARNEWS() {
        return (String) get(Tbj42SozaiKanriListCmn.CARNEWS);
    }

    /**
     * 車種NEWSを設定する
     *
     * @param val 車種NEWS
     */
    public void setCARNEWS(String val) {
        set(Tbj42SozaiKanriListCmn.CARNEWS, val);
    }

    /**
     * 次回車種NEWSを取得する
     *
     * @return 次回車種NEWS
     */
    public String getNEXTCARNEWS() {
        return (String) get(Tbj42SozaiKanriListCmn.NEXTCARNEWS);
    }

    /**
     * 次回車種NEWSを設定する
     *
     * @param val 次回車種NEWS
     */
    public void setNEXTCARNEWS(String val) {
        set(Tbj42SozaiKanriListCmn.NEXTCARNEWS, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ﾑｰﾋﾞｰﾁｬﾝﾈﾙ)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(ﾑｰﾋﾞｰﾁｬﾝﾈﾙ)
     */
    public String getOTHERMEDIAUSE_MVCHL() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ﾑｰﾋﾞｰﾁｬﾝﾈﾙ)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(ﾑｰﾋﾞｰﾁｬﾝﾈﾙ)
     */
    public void setOTHERMEDIAUSE_MVCHL(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(HondaYouTube)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(HondaYouTube)
     */
    public String getOTHERMEDIAUSE_YOUTUBE() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(HondaYouTube)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(HondaYouTube)
     */
    public void setOTHERMEDIAUSE_YOUTUBE(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(MXTV)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(MXTV)
     */
    public String getOTHERMEDIAUSE_MXTV() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(MXTV)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(MXTV)
     */
    public void setOTHERMEDIAUSE_MXTV(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(京ｾﾗﾄﾞｰﾑ)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(京ｾﾗﾄﾞｰﾑ)
     */
    public String getOTHERMEDIAUSE_KYOSERADM() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(京ｾﾗﾄﾞｰﾑ)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(京ｾﾗﾄﾞｰﾑ)
     */
    public void setOTHERMEDIAUSE_KYOSERADM(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ｻｰｷｯﾄﾋﾞｼﾞｮﾝ)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(ｻｰｷｯﾄﾋﾞｼﾞｮﾝ)
     */
    public String getOTHERMEDIAUSE_CIRCUITVS() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ｻｰｷｯﾄﾋﾞｼﾞｮﾝ)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(ｻｰｷｯﾄﾋﾞｼﾞｮﾝ)
     */
    public void setOTHERMEDIAUSE_CIRCUITVS(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ﾌｫｰﾐｭﾗﾆｯﾎﾟﾝ)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(ﾌｫｰﾐｭﾗﾆｯﾎﾟﾝ)
     */
    public String getOTHERMEDIAUSE_FMJPN() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(ﾌｫｰﾐｭﾗﾆｯﾎﾟﾝ)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(ﾌｫｰﾐｭﾗﾆｯﾎﾟﾝ)
     */
    public void setOTHERMEDIAUSE_FMJPN(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(WTCC)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(WTCC)
     */
    public String getOTHERMEDIAUSE_WTCC() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(WTCC)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(WTCC)
     */
    public void setOTHERMEDIAUSE_WTCC(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目1)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(予備項目1)
     */
    public String getOTHERMEDIAUSE_OTHER1() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目1)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(予備項目1)
     */
    public void setOTHERMEDIAUSE_OTHER1(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目2)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(予備項目2)
     */
    public String getOTHERMEDIAUSE_OTHER2() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目2)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(予備項目2)
     */
    public void setOTHERMEDIAUSE_OTHER2(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2, val);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目3)を取得する
     *
     * @return 他ﾒﾃﾞｨｱ使用有無(予備項目3)
     */
    public String getOTHERMEDIAUSE_OTHER3() {
        return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3);
    }

    /**
     * 他ﾒﾃﾞｨｱ使用有無(予備項目3)を設定する
     *
     * @param val 他ﾒﾃﾞｨｱ使用有無(予備項目3)
     */
    public void setOTHERMEDIAUSE_OTHER3(String val) {
        set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj42SozaiKanriListCmn.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj42SozaiKanriListCmn.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj42SozaiKanriListCmn.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj42SozaiKanriListCmn.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj42SozaiKanriListCmn.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj42SozaiKanriListCmn.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj42SozaiKanriListCmn.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj42SozaiKanriListCmn.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj42SozaiKanriListCmn.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj42SozaiKanriListCmn.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj42SozaiKanriListCmn.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj42SozaiKanriListCmn.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj42SozaiKanriListCmn.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj42SozaiKanriListCmn.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj42SozaiKanriListCmn.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj42SozaiKanriListCmn.UPDID, val);
    }

}
