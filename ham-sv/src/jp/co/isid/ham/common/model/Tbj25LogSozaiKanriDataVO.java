package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj25LogSozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材登録変更ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj25LogSozaiKanriDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj25LogSozaiKanriDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj25LogSozaiKanriDataVO();
    }

    /**
     * 系統を取得する
     *
     * @return 系統
     */
    public String getNOKBN() {
        return (String) get(Tbj25LogSozaiKanriData.NOKBN);
    }

    /**
     * 系統を設定する
     *
     * @param val 系統
     */
    public void setNOKBN(String val) {
        set(Tbj25LogSozaiKanriData.NOKBN, val);
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj25LogSozaiKanriData.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj25LogSozaiKanriData.CMCD, val);
    }

    /**
     * 履歴NOを取得する
     *
     * @return 履歴NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj25LogSozaiKanriData.HISTORYNO);
    }

    /**
     * 履歴NOを設定する
     *
     * @param val 履歴NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj25LogSozaiKanriData.HISTORYNO, val);
    }

    /**
     * 履歴区分を取得する
     *
     * @return 履歴区分
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj25LogSozaiKanriData.HISTORYKBN);
    }

    /**
     * 履歴区分を設定する
     *
     * @param val 履歴区分
     */
    public void setHISTORYKBN(String val) {
        set(Tbj25LogSozaiKanriData.HISTORYKBN, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj25LogSozaiKanriData.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj25LogSozaiKanriData.DELFLG, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj25LogSozaiKanriData.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj25LogSozaiKanriData.DCARCD, val);
    }

    /**
     * カテゴリを取得する
     *
     * @return カテゴリ
     */
    public String getCATEGORY() {
        return (String) get(Tbj25LogSozaiKanriData.CATEGORY);
    }

    /**
     * カテゴリを設定する
     *
     * @param val カテゴリ
     */
    public void setCATEGORY(String val) {
        set(Tbj25LogSozaiKanriData.CATEGORY, val);
    }

    /**
     * タイトルを取得する
     *
     * @return タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj25LogSozaiKanriData.TITLE);
    }

    /**
     * タイトルを設定する
     *
     * @param val タイトル
     */
    public void setTITLE(String val) {
        set(Tbj25LogSozaiKanriData.TITLE, val);
    }

    /**
     * 通称タイトルを取得する
     *
     * @return 通称タイトル
     */
    public String getALIASTITLE() {
        return (String) get(Tbj25LogSozaiKanriData.ALIASTITLE);
    }

    /**
     * 通称タイトルを設定する
     *
     * @param val 通称タイトル
     */
    public void setALIASTITLE(String val) {
        set(Tbj25LogSozaiKanriData.ALIASTITLE, val);
    }

    /**
     * ぶら下がりを取得する
     *
     * @return ぶら下がり
     */
    public String getENDTITLE() {
        return (String) get(Tbj25LogSozaiKanriData.ENDTITLE);
    }

    /**
     * ぶら下がりを設定する
     *
     * @param val ぶら下がり
     */
    public void setENDTITLE(String val) {
        set(Tbj25LogSozaiKanriData.ENDTITLE, val);
    }

    /**
     * 秒数を取得する
     *
     * @return 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj25LogSozaiKanriData.SECOND);
    }

    /**
     * 秒数を設定する
     *
     * @param val 秒数
     */
    public void setSECOND(String val) {
        set(Tbj25LogSozaiKanriData.SECOND, val);
    }

    /**
     * 車種担当を取得する
     *
     * @return 車種担当
     */
    public String getSYATAN() {
        return (String) get(Tbj25LogSozaiKanriData.SYATAN);
    }

    /**
     * 車種担当を設定する
     *
     * @param val 車種担当
     */
    public void setSYATAN(String val) {
        set(Tbj25LogSozaiKanriData.SYATAN, val);
    }

    /**
     * 納品日を取得する
     *
     * @return 納品日
     */
    public String getNOHIN() {
        return (String) get(Tbj25LogSozaiKanriData.NOHIN);
    }

    /**
     * 納品日を設定する
     *
     * @param val 納品日
     */
    public void setNOHIN(String val) {
        set(Tbj25LogSozaiKanriData.NOHIN, val);
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを取得する
     *
     * @return 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public String getPRODUCT() {
        return (String) get(Tbj25LogSozaiKanriData.PRODUCT);
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを設定する
     *
     * @param val 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public void setPRODUCT(String val) {
        set(Tbj25LogSozaiKanriData.PRODUCT, val);
    }

    /**
     * 放送開始日を取得する
     *
     * @return 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj25LogSozaiKanriData.DATEFROM);
    }

    /**
     * 放送開始日を設定する
     *
     * @param val 放送開始日
     */
    public void setDATEFROM(Date val) {
        set(Tbj25LogSozaiKanriData.DATEFROM, val);
    }

    /**
     * 放送開始日(属性)を取得する
     *
     * @return 放送開始日(属性)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj25LogSozaiKanriData.DATEFROM_ATTR);
    }

    /**
     * 放送開始日(属性)を設定する
     *
     * @param val 放送開始日(属性)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj25LogSozaiKanriData.DATEFROM_ATTR, val);
    }

    /**
     * 放送終了日を取得する
     *
     * @return 放送終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj25LogSozaiKanriData.DATETO);
    }

    /**
     * 放送終了日を設定する
     *
     * @param val 放送終了日
     */
    public void setDATETO(Date val) {
        set(Tbj25LogSozaiKanriData.DATETO, val);
    }

    /**
     * 放送終了日(属性)を取得する
     *
     * @return 放送終了日(属性)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj25LogSozaiKanriData.DATETO_ATTR);
    }

    /**
     * 放送終了日(属性)を設定する
     *
     * @param val 放送終了日(属性)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj25LogSozaiKanriData.DATETO_ATTR, val);
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を取得する
     *
     * @return ﾒﾃﾞｨｱ使用期限
     */
    @XmlElement(required = true, nillable = true)
    public Date getMLIMIT() {
        return (Date) get(Tbj25LogSozaiKanriData.MLIMIT);
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を設定する
     *
     * @param val ﾒﾃﾞｨｱ使用期限
     */
    public void setMLIMIT(Date val) {
        set(Tbj25LogSozaiKanriData.MLIMIT, val);
    }

    /**
     * 権利使用期限を取得する
     *
     * @return 権利使用期限
     */
    public String getKLIMIT() {
        return (String) get(Tbj25LogSozaiKanriData.KLIMIT);
    }

    /**
     * 権利使用期限を設定する
     *
     * @param val 権利使用期限
     */
    public void setKLIMIT(String val) {
        set(Tbj25LogSozaiKanriData.KLIMIT, val);
    }

    /**
     * 正式承認日を取得する
     *
     * @return 正式承認日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATERECOG() {
        return (Date) get(Tbj25LogSozaiKanriData.DATERECOG);
    }

    /**
     * 正式承認日を設定する
     *
     * @param val 正式承認日
     */
    public void setDATERECOG(Date val) {
        set(Tbj25LogSozaiKanriData.DATERECOG, val);
    }

    /**
     * 発行日を取得する
     *
     * @return 発行日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEPRT() {
        return (Date) get(Tbj25LogSozaiKanriData.DATEPRT);
    }

    /**
     * 発行日を設定する
     *
     * @param val 発行日
     */
    public void setDATEPRT(Date val) {
        set(Tbj25LogSozaiKanriData.DATEPRT, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj25LogSozaiKanriData.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj25LogSozaiKanriData.BIKO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj25LogSozaiKanriData.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj25LogSozaiKanriData.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj25LogSozaiKanriData.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj25LogSozaiKanriData.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj25LogSozaiKanriData.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj25LogSozaiKanriData.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj25LogSozaiKanriData.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj25LogSozaiKanriData.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj25LogSozaiKanriData.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj25LogSozaiKanriData.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj25LogSozaiKanriData.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj25LogSozaiKanriData.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj25LogSozaiKanriData.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj25LogSozaiKanriData.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj25LogSozaiKanriData.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj25LogSozaiKanriData.UPDID, val);
    }

}
