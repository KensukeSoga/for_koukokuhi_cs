package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj26LogSozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧変更ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj26LogSozaiKanriListVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /** デフォルトコンストラクタ */
    public Tbj26LogSozaiKanriListVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj26LogSozaiKanriListVO();
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj26LogSozaiKanriList.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj26LogSozaiKanriList.DCARCD, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj26LogSozaiKanriList.SOZAIYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSOZAIYM(Date val) {
        set(Tbj26LogSozaiKanriList.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getRECKBN() {
        return (String) get(Tbj26LogSozaiKanriList.RECKBN);
    }

    /**
     * 作成区分を設定する
     *
     * @param val 作成区分
     */
    public void setRECKBN(String val) {
        set(Tbj26LogSozaiKanriList.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRECNO() {
        return (String) get(Tbj26LogSozaiKanriList.RECNO);
    }

    /**
     * 作成番号を設定する
     *
     * @param val 作成番号
     */
    public void setRECNO(String val) {
        set(Tbj26LogSozaiKanriList.RECNO, val);
    }

    /**
     * 履歴NOを取得する
     *
     * @return 履歴NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.HISTORYNO);
    }

    /**
     * 履歴NOを設定する
     *
     * @param val 履歴NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.HISTORYNO, val);
    }

    /**
     * 履歴区分を取得する
     *
     * @return 履歴区分
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj26LogSozaiKanriList.HISTORYKBN);
    }

    /**
     * 履歴区分を設定する
     *
     * @param val 履歴区分
     */
    public void setHISTORYKBN(String val) {
        set(Tbj26LogSozaiKanriList.HISTORYKBN, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj26LogSozaiKanriList.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj26LogSozaiKanriList.DELFLG, val);
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj26LogSozaiKanriList.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj26LogSozaiKanriList.CMCD, val);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj26LogSozaiKanriList.TEMPCMCD);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param val 仮10桁CMｺｰﾄﾞ
     */
    public void setTEMPCMCD(String val) {
        set(Tbj26LogSozaiKanriList.TEMPCMCD, val);
    }

    /**
     * タイトルを取得する
     *
     * @return タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj26LogSozaiKanriList.TITLE);
    }

    /**
     * タイトルを設定する
     *
     * @param val タイトル
     */
    public void setTITLE(String val) {
        set(Tbj26LogSozaiKanriList.TITLE, val);
    }

    /**
     * 秒数を取得する
     *
     * @return 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj26LogSozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     *
     * @param val 秒数
     */
    public void setSECOND(String val) {
        set(Tbj26LogSozaiKanriList.SECOND, val);
    }

    /**
     * 素材略コードを取得する
     *
     * @return 素材略コード
     */
    public String getRCODE() {
        return (String) get(Tbj26LogSozaiKanriList.RCODE);
    }

    /**
     * 素材略コードを設定する
     *
     * @param val 素材略コード
     */
    public void setRCODE(String val) {
        set(Tbj26LogSozaiKanriList.RCODE, val);
    }

    /**
     * 予算を取得する
     *
     * @return 予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTIMATE() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.ESTIMATE);
    }

    /**
     * 予算を設定する
     *
     * @param val 予算
     */
    public void setESTIMATE(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.ESTIMATE, val);
    }

    /**
     * OA開始日を取得する
     *
     * @return OA開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj26LogSozaiKanriList.DATEFROM);
    }

    /**
     * OA開始日を設定する
     *
     * @param val OA開始日
     */
    public void setDATEFROM(Date val) {
        set(Tbj26LogSozaiKanriList.DATEFROM, val);
    }

    /**
     * OA開始日(属性)を取得する
     *
     * @return OA開始日(属性)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj26LogSozaiKanriList.DATEFROM_ATTR);
    }

    /**
     * OA開始日(属性)を設定する
     *
     * @param val OA開始日(属性)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj26LogSozaiKanriList.DATEFROM_ATTR, val);
    }

    /**
     * OA終了日を取得する
     *
     * @return OA終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj26LogSozaiKanriList.DATETO);
    }

    /**
     * OA終了日を設定する
     *
     * @param val OA終了日
     */
    public void setDATETO(Date val) {
        set(Tbj26LogSozaiKanriList.DATETO, val);
    }

    /**
     * OA終了日(属性)を取得する
     *
     * @return OA終了日(属性)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj26LogSozaiKanriList.DATETO_ATTR);
    }

    /**
     * OA終了日(属性)を設定する
     *
     * @param val OA終了日(属性)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj26LogSozaiKanriList.DATETO_ATTR, val);
    }

    /**
     * 新素材ﾌﾗｸﾞを取得する
     *
     * @return 新素材ﾌﾗｸﾞ
     */
    public String getNEWFLG() {
        return (String) get(Tbj26LogSozaiKanriList.NEWFLG);
    }

    /**
     * 新素材ﾌﾗｸﾞを設定する
     *
     * @param val 新素材ﾌﾗｸﾞ
     */
    public void setNEWFLG(String val) {
        set(Tbj26LogSozaiKanriList.NEWFLG, val);
    }

    /**
     * NEW表示を取得する
     *
     * @return NEW表示
     */
    public String getNEWDISPFLG() {
        return (String) get(Tbj26LogSozaiKanriList.NEWDISPFLG);
    }

    /**
     * NEW表示を設定する
     *
     * @param val NEW表示
     */
    public void setNEWDISPFLG(String val) {
        set(Tbj26LogSozaiKanriList.NEWDISPFLG, val);
    }

    /**
     * Time使用ﾌﾗｸﾞを取得する
     *
     * @return Time使用ﾌﾗｸﾞ
     */
    public String getTIMEUSE() {
        return (String) get(Tbj26LogSozaiKanriList.TIMEUSE);
    }

    /**
     * Time使用ﾌﾗｸﾞを設定する
     *
     * @param val Time使用ﾌﾗｸﾞ
     */
    public void setTIMEUSE(String val) {
        set(Tbj26LogSozaiKanriList.TIMEUSE, val);
    }

    /**
     * Spot使用ﾌﾗｸﾞを取得する
     *
     * @return Spot使用ﾌﾗｸﾞ
     */
    public String getSPOTUSE() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTUSE);
    }

    /**
     * Spot使用ﾌﾗｸﾞを設定する
     *
     * @param val Spot使用ﾌﾗｸﾞ
     */
    public void setSPOTUSE(String val) {
        set(Tbj26LogSozaiKanriList.SPOTUSE, val);
    }

    /**
     * Spot契約名を取得する
     *
     * @return Spot契約名
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTCTRT);
    }

    /**
     * Spot契約名を設定する
     *
     * @param val Spot契約名
     */
    public void setSPOTCTRT(String val) {
        set(Tbj26LogSozaiKanriList.SPOTCTRT, val);
    }

    /**
     * Spot期間を取得する
     *
     * @return Spot期間
     */
    public String getSPOTSPAN() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTSPAN);
    }

    /**
     * Spot期間を設定する
     *
     * @param val Spot期間
     */
    public void setSPOTSPAN(String val) {
        set(Tbj26LogSozaiKanriList.SPOTSPAN, val);
    }

    /**
     * Spot予算を取得する
     *
     * @return Spot予算
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSPOTESTM() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.SPOTESTM);
    }

    /**
     * Spot予算を設定する
     *
     * @param val Spot予算
     */
    public void setSPOTESTM(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.SPOTESTM, val);
    }

    /**
     * 使用可能期間を取得する
     *
     * @return 使用可能期間
     */
    @XmlElement(required = true, nillable = true)
    public Date getLIMIT() {
        return (Date) get(Tbj26LogSozaiKanriList.LIMIT);
    }

    /**
     * 使用可能期間を設定する
     *
     * @param val 使用可能期間
     */
    public void setLIMIT(Date val) {
        set(Tbj26LogSozaiKanriList.LIMIT, val);
    }

    /**
     * 車種担当(電通)を取得する
     *
     * @return 車種担当(電通)
     */
    public String getSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.SYATAN);
    }

    /**
     * 車種担当(電通)を設定する
     *
     * @param val 車種担当(電通)
     */
    public void setSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.SYATAN, val);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public String getHCSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.HCSYATAN);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)を設定する
     *
     * @param val 車種担当(ﾎﾝﾀﾞｺﾑﾃｯｸ)
     */
    public void setHCSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.HCSYATAN, val);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を取得する
     *
     * @return 車種担当(ﾎﾝﾀﾞ)
     */
    public String getHMSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.HMSYATAN);
    }

    /**
     * 車種担当(ﾎﾝﾀﾞ)を設定する
     *
     * @param val 車種担当(ﾎﾝﾀﾞ)
     */
    public void setHMSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.HMSYATAN, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj26LogSozaiKanriList.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj26LogSozaiKanriList.BIKO, val);
    }

    /**
     * HDX開放ﾌﾗｸﾞを取得する
     *
     * @return HDX開放ﾌﾗｸﾞ
     */
    public String getOPENFLG() {
        return (String) get(Tbj26LogSozaiKanriList.OPENFLG);
    }

    /**
     * HDX開放ﾌﾗｸﾞを設定する
     *
     * @param val HDX開放ﾌﾗｸﾞ
     */
    public void setOPENFLG(String val) {
        set(Tbj26LogSozaiKanriList.OPENFLG, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj26LogSozaiKanriList.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj26LogSozaiKanriList.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj26LogSozaiKanriList.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj26LogSozaiKanriList.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj26LogSozaiKanriList.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj26LogSozaiKanriList.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj26LogSozaiKanriList.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj26LogSozaiKanriList.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj26LogSozaiKanriList.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj26LogSozaiKanriList.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj26LogSozaiKanriList.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj26LogSozaiKanriList.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj26LogSozaiKanriList.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj26LogSozaiKanriList.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj26LogSozaiKanriList.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj26LogSozaiKanriList.UPDID, val);
    }
}