package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/08 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj20SozaiKanriListVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj20SozaiKanriListVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj20SozaiKanriListVO();
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj20SozaiKanriList.SOZAIYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSOZAIYM(Date val) {
        set(Tbj20SozaiKanriList.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getRECKBN() {
        return (String) get(Tbj20SozaiKanriList.RECKBN);
    }

    /**
     * 作成区分を設定する
     *
     * @param val 作成区分
     */
    public void setRECKBN(String val) {
        set(Tbj20SozaiKanriList.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRECNO() {
        return (String) get(Tbj20SozaiKanriList.RECNO);
    }

    /**
     * 作成番号を設定する
     *
     * @param val 作成番号
     */
    public void setRECNO(String val) {
        set(Tbj20SozaiKanriList.RECNO, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj20SozaiKanriList.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj20SozaiKanriList.DELFLG, val);
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj20SozaiKanriList.TEMPCMCD);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param val 仮10桁CMｺｰﾄﾞ
     */
    public void setTEMPCMCD(String val) {
        set(Tbj20SozaiKanriList.TEMPCMCD, val);
    }

    /**
     * タイトルを取得する
     *
     * @return タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * タイトルを設定する
     *
     * @param val タイトル
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * 秒数を取得する
     *
     * @return 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     *
     * @param val 秒数
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * 素材略コードを取得する
     *
     * @return 素材略コード
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * 素材略コードを設定する
     *
     * @param val 素材略コード
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * 予算を取得する
     *
     * @return 予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTIMATE() {
        return (BigDecimal) get(Tbj20SozaiKanriList.ESTIMATE);
    }

    /**
     * 予算を設定する
     *
     * @param val 予算
     */
    public void setESTIMATE(BigDecimal val) {
        set(Tbj20SozaiKanriList.ESTIMATE, val);
    }

    /**
     * OA開始日を取得する
     *
     * @return OA開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj20SozaiKanriList.DATEFROM);
    }

    /**
     * OA開始日を設定する
     *
     * @param val OA開始日
     */
    public void setDATEFROM(Date val) {
        set(Tbj20SozaiKanriList.DATEFROM, val);
    }

    /**
     * OA開始日(属性)を取得する
     *
     * @return OA開始日(属性)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj20SozaiKanriList.DATEFROM_ATTR);
    }

    /**
     * OA開始日(属性)を設定する
     *
     * @param val OA開始日(属性)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj20SozaiKanriList.DATEFROM_ATTR, val);
    }

    /**
     * OA終了日を取得する
     *
     * @return OA終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj20SozaiKanriList.DATETO);
    }

    /**
     * OA終了日を設定する
     *
     * @param val OA終了日
     */
    public void setDATETO(Date val) {
        set(Tbj20SozaiKanriList.DATETO, val);
    }

    /**
     * OA終了日(属性)を取得する
     *
     * @return OA終了日(属性)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj20SozaiKanriList.DATETO_ATTR);
    }

    /**
     * OA終了日(属性)を設定する
     *
     * @param val OA終了日(属性)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj20SozaiKanriList.DATETO_ATTR, val);
    }

    /**
     * 新素材ﾌﾗｸﾞを取得する
     *
     * @return 新素材ﾌﾗｸﾞ
     */
    public String getNEWFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWFLG);
    }

    /**
     * 新素材ﾌﾗｸﾞを設定する
     *
     * @param val 新素材ﾌﾗｸﾞ
     */
    public void setNEWFLG(String val) {
        set(Tbj20SozaiKanriList.NEWFLG, val);
    }

    /**
     * NEW表示を取得する
     *
     * @return NEW表示
     */
    public String getNEWDISPFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWDISPFLG);
    }

    /**
     * NEW表示を設定する
     *
     * @param val NEW表示
     */
    public void setNEWDISPFLG(String val) {
        set(Tbj20SozaiKanriList.NEWDISPFLG, val);
    }

    /**
     * Time使用ﾌﾗｸﾞを取得する
     *
     * @return Time使用ﾌﾗｸﾞ
     */
    public String getTIMEUSE() {
        return (String) get(Tbj20SozaiKanriList.TIMEUSE);
    }

    /**
     * Time使用ﾌﾗｸﾞを設定する
     *
     * @param val Time使用ﾌﾗｸﾞ
     */
    public void setTIMEUSE(String val) {
        set(Tbj20SozaiKanriList.TIMEUSE, val);
    }

    /**
     * Spot使用ﾌﾗｸﾞを取得する
     *
     * @return Spot使用ﾌﾗｸﾞ
     */
    public String getSPOTUSE() {
        return (String) get(Tbj20SozaiKanriList.SPOTUSE);
    }

    /**
     * Spot使用ﾌﾗｸﾞを設定する
     *
     * @param val Spot使用ﾌﾗｸﾞ
     */
    public void setSPOTUSE(String val) {
        set(Tbj20SozaiKanriList.SPOTUSE, val);
    }

    /**
     * Spot契約名を取得する
     *
     * @return Spot契約名
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj20SozaiKanriList.SPOTCTRT);
    }

    /**
     * Spot契約名を設定する
     *
     * @param val Spot契約名
     */
    public void setSPOTCTRT(String val) {
        set(Tbj20SozaiKanriList.SPOTCTRT, val);
    }

    /**
     * Spot期間を取得する
     *
     * @return Spot期間
     */
    public String getSPOTSPAN() {
        return (String) get(Tbj20SozaiKanriList.SPOTSPAN);
    }

    /**
     * Spot期間を設定する
     *
     * @param val Spot期間
     */
    public void setSPOTSPAN(String val) {
        set(Tbj20SozaiKanriList.SPOTSPAN, val);
    }

    /**
     * Spot予算を取得する
     *
     * @return Spot予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSPOTESTM() {
        return (BigDecimal) get(Tbj20SozaiKanriList.SPOTESTM);
    }

    /**
     * Spot予算を設定する
     *
     * @param val Spot予算
     */
    public void setSPOTESTM(BigDecimal val) {
        set(Tbj20SozaiKanriList.SPOTESTM, val);
    }

    /**
     * 使用可能期間を取得する
     *
     * @return 使用可能期間
     */
    @XmlElement(required = true, nillable = true)
    public Date getLIMIT() {
        return (Date) get(Tbj20SozaiKanriList.LIMIT);
    }

    /**
     * 使用可能期間を設定する
     *
     * @param val 使用可能期間
     */
    public void setLIMIT(Date val) {
        set(Tbj20SozaiKanriList.LIMIT, val);
    }

    /**
     * 車種担当(電通)を取得する
     *
     * @return 車種担当(電通)
     */
    public String getSYATAN() {
        return (String) get(Tbj20SozaiKanriList.SYATAN);
    }

    /**
     * 車種担当(電通)を設定する
     *
     * @param val 車種担当(電通)
     */
    public void setSYATAN(String val) {
        set(Tbj20SozaiKanriList.SYATAN, val);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public String getHCSYATAN() {
        return (String) get(Tbj20SozaiKanriList.HCSYATAN);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を設定する
     *
     * @param val 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public void setHCSYATAN(String val) {
        set(Tbj20SozaiKanriList.HCSYATAN, val);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞ)
     */
    public String getHMSYATAN() {
        return (String) get(Tbj20SozaiKanriList.HMSYATAN);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を設定する
     *
     * @param val 車種担当(ﾎﾝﾀﾞ)
     */
    public void setHMSYATAN(String val) {
        set(Tbj20SozaiKanriList.HMSYATAN, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj20SozaiKanriList.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj20SozaiKanriList.BIKO, val);
    }

    /**
     * 文字色を取得する
     *
     * @return 文字色
     */
    public String getFORECOLOR() {
        return (String) get(Tbj20SozaiKanriList.FORECOLOR);
    }

    /**
     * 文字色を設定する
     *
     * @param val 文字色
     */
    public void setFORECOLOR(String val) {
        set(Tbj20SozaiKanriList.FORECOLOR, val);
    }

    /**
     * 背景色を取得する
     *
     * @return 背景色
     */
    public String getBACKCOLOR() {
        return (String) get(Tbj20SozaiKanriList.BACKCOLOR);
    }

    /**
     * 背景色を設定する
     *
     * @param val 背景色
     */
    public void setBACKCOLOR(String val) {
        set(Tbj20SozaiKanriList.BACKCOLOR, val);
    }

    /**
     * HDX開放ﾌﾗｸﾞを取得する
     *
     * @return HDX開放ﾌﾗｸﾞ
     */
    public String getOPENFLG() {
        return (String) get(Tbj20SozaiKanriList.OPENFLG);
    }

    /**
     * HDX開放ﾌﾗｸﾞを設定する
     *
     * @param val HDX開放ﾌﾗｸﾞ
     */
    public void setOPENFLG(String val) {
        set(Tbj20SozaiKanriList.OPENFLG, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj20SozaiKanriList.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj20SozaiKanriList.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj20SozaiKanriList.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj20SozaiKanriList.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj20SozaiKanriList.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj20SozaiKanriList.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj20SozaiKanriList.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj20SozaiKanriList.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj20SozaiKanriList.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj20SozaiKanriList.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj20SozaiKanriList.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj20SozaiKanriList.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj20SozaiKanriList.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj20SozaiKanriList.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj20SozaiKanriList.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj20SozaiKanriList.UPDID, val);
    }

}
