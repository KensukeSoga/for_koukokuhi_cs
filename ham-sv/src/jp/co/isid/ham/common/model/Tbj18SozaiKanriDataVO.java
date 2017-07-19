package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材登録VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj18SozaiKanriDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj18SozaiKanriDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj18SozaiKanriDataVO();
    }

    /**
     * 系統を取得する
     *
     * @return 系統
     */
    public String getNOKBN() {
        return (String) get(Tbj18SozaiKanriData.NOKBN);
    }

    /**
     * 系統を設定する
     *
     * @param val 系統
     */
    public void setNOKBN(String val) {
        set(Tbj18SozaiKanriData.NOKBN, val);
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

    /**
     * ステータスを取得する
     *
     * @return ステータス
     */
    public String getSTATUS() {
        return (String) get(Tbj18SozaiKanriData.STATUS);
    }

    /**
     * ステータスを設定する
     *
     * @param val ステータス
     */
    public void setSTATUS(String val) {
        set(Tbj18SozaiKanriData.STATUS, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj18SozaiKanriData.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj18SozaiKanriData.DCARCD, val);
    }

    /**
     * カテゴリを取得する
     *
     * @return カテゴリ
     */
    public String getCATEGORY() {
        return (String) get(Tbj18SozaiKanriData.CATEGORY);
    }

    /**
     * カテゴリを設定する
     *
     * @param val カテゴリ
     */
    public void setCATEGORY(String val) {
        set(Tbj18SozaiKanriData.CATEGORY, val);
    }

    /**
     * タイトルを取得する
     *
     * @return タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj18SozaiKanriData.TITLE);
    }

    /**
     * タイトルを設定する
     *
     * @param val タイトル
     */
    public void setTITLE(String val) {
        set(Tbj18SozaiKanriData.TITLE, val);
    }

    /**
     * 通称タイトルを取得する
     *
     * @return 通称タイトル
     */
    public String getALIASTITLE() {
        return (String) get(Tbj18SozaiKanriData.ALIASTITLE);
    }

    /**
     * 通称タイトルを設定する
     *
     * @param val 通称タイトル
     */
    public void setALIASTITLE(String val) {
        set(Tbj18SozaiKanriData.ALIASTITLE, val);
    }

    /**
     * ぶら下がりを取得する
     *
     * @return ぶら下がり
     */
    public String getENDTITLE() {
        return (String) get(Tbj18SozaiKanriData.ENDTITLE);
    }

    /**
     * ぶら下がりを設定する
     *
     * @param val ぶら下がり
     */
    public void setENDTITLE(String val) {
        set(Tbj18SozaiKanriData.ENDTITLE, val);
    }

    /**
     * 秒数を取得する
     *
     * @return 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj18SozaiKanriData.SECOND);
    }

    /**
     * 秒数を設定する
     *
     * @param val 秒数
     */
    public void setSECOND(String val) {
        set(Tbj18SozaiKanriData.SECOND, val);
    }

    /**
     * 車種担当(電通)を取得する
     *
     * @return 車種担当(電通)
     */
    public String getSYATAN() {
        return (String) get(Tbj18SozaiKanriData.SYATAN);
    }

    /**
     * 車種担当(電通)を設定する
     *
     * @param val 車種担当(電通)
     */
    public void setSYATAN(String val) {
        set(Tbj18SozaiKanriData.SYATAN, val);
    }

    /**
     * 納品日を取得する
     *
     * @return 納品日
     */
    public String getNOHIN() {
        return (String) get(Tbj18SozaiKanriData.NOHIN);
    }

    /**
     * 納品日を設定する
     *
     * @param val 納品日
     */
    public void setNOHIN(String val) {
        set(Tbj18SozaiKanriData.NOHIN, val);
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを取得する
     *
     * @return 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public String getPRODUCT() {
        return (String) get(Tbj18SozaiKanriData.PRODUCT);
    }

    /**
     * 制作ﾌﾟﾛﾀﾞｸｼｮﾝを設定する
     *
     * @param val 制作ﾌﾟﾛﾀﾞｸｼｮﾝ
     */
    public void setPRODUCT(String val) {
        set(Tbj18SozaiKanriData.PRODUCT, val);
    }

    /**
     * 放送開始日を取得する
     *
     * @return 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj18SozaiKanriData.DATEFROM);
    }

    /**
     * 放送開始日を設定する
     *
     * @param val 放送開始日
     */
    public void setDATEFROM(Date val) {
        set(Tbj18SozaiKanriData.DATEFROM, val);
    }

    /**
     * 放送開始日(属性)を取得する
     *
     * @return 放送開始日(属性)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj18SozaiKanriData.DATEFROM_ATTR);
    }

    /**
     * 放送開始日(属性)を設定する
     *
     * @param val 放送開始日(属性)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj18SozaiKanriData.DATEFROM_ATTR, val);
    }

    /**
     * 放送終了日を取得する
     *
     * @return 放送終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj18SozaiKanriData.DATETO);
    }

    /**
     * 放送終了日を設定する
     *
     * @param val 放送終了日
     */
    public void setDATETO(Date val) {
        set(Tbj18SozaiKanriData.DATETO, val);
    }

    /**
     * 放送終了日(属性)を取得する
     *
     * @return 放送終了日(属性)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj18SozaiKanriData.DATETO_ATTR);
    }

    /**
     * 放送終了日(属性)を設定する
     *
     * @param val 放送終了日(属性)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj18SozaiKanriData.DATETO_ATTR, val);
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を取得する
     *
     * @return ﾒﾃﾞｨｱ使用期限
     */
    @XmlElement(required = true, nillable = true)
    public Date getMLIMIT() {
        return (Date) get(Tbj18SozaiKanriData.MLIMIT);
    }

    /**
     * ﾒﾃﾞｨｱ使用期限を設定する
     *
     * @param val ﾒﾃﾞｨｱ使用期限
     */
    public void setMLIMIT(Date val) {
        set(Tbj18SozaiKanriData.MLIMIT, val);
    }

    /**
     * 権利使用期限を取得する
     *
     * @return 権利使用期限
     */
    public String getKLIMIT() {
        return (String) get(Tbj18SozaiKanriData.KLIMIT);
    }

    /**
     * 権利使用期限を設定する
     *
     * @param val 権利使用期限
     */
    public void setKLIMIT(String val) {
        set(Tbj18SozaiKanriData.KLIMIT, val);
    }

    /**
     * 正式承認日を取得する
     *
     * @return 正式承認日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATERECOG() {
        return (Date) get(Tbj18SozaiKanriData.DATERECOG);
    }

    /**
     * 正式承認日を設定する
     *
     * @param val 正式承認日
     */
    public void setDATERECOG(Date val) {
        set(Tbj18SozaiKanriData.DATERECOG, val);
    }

    /**
     * 発行日を取得する
     *
     * @return 発行日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEPRT() {
        return (Date) get(Tbj18SozaiKanriData.DATEPRT);
    }

    /**
     * 発行日を設定する
     *
     * @param val 発行日
     */
    public void setDATEPRT(Date val) {
        set(Tbj18SozaiKanriData.DATEPRT, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj18SozaiKanriData.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj18SozaiKanriData.BIKO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj18SozaiKanriData.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj18SozaiKanriData.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj18SozaiKanriData.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj18SozaiKanriData.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj18SozaiKanriData.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj18SozaiKanriData.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj18SozaiKanriData.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj18SozaiKanriData.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj18SozaiKanriData.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj18SozaiKanriData.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj18SozaiKanriData.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj18SozaiKanriData.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj18SozaiKanriData.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj18SozaiKanriData.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj18SozaiKanriData.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj18SozaiKanriData.UPDID, val);
    }

}
