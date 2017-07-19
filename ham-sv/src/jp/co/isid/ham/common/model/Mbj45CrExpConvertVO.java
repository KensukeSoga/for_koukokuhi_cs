package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj45CrExpConvert;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算費目変換マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj45CrExpConvertVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj45CrExpConvertVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj45CrExpConvertVO();
    }

    /**
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getEXPCD() {
        return (String) get(Mbj45CrExpConvert.EXPCD);
    }

    /**
     * 費目コードを設定する
     *
     * @param val 費目コード
     */
    public void setEXPCD(String val) {
        set(Mbj45CrExpConvert.EXPCD, val);
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get(Mbj45CrExpConvert.CLASSDIV);
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param val 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set(Mbj45CrExpConvert.CLASSDIV, val);
    }

    /**
     * 開始年月日を取得する
     *
     * @return 開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Mbj45CrExpConvert.DATEFROM);
    }

    /**
     * 開始年月日を設定する
     *
     * @param val 開始年月日
     */
    public void setDATEFROM(Date val) {
        set(Mbj45CrExpConvert.DATEFROM, val);
    }

    /**
     * 終了年月日を取得する
     *
     * @return 終了年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Mbj45CrExpConvert.DATETO);
    }

    /**
     * 終了年月日を設定する
     *
     * @param val 終了年月日
     */
    public void setDATETO(Date val) {
        set(Mbj45CrExpConvert.DATETO, val);
    }

    /**
     * 変換後費目コードを取得する
     *
     * @return 変換後費目コード
     */
    public String getNEWEXPCD() {
        return (String) get(Mbj45CrExpConvert.NEWEXPCD);
    }

    /**
     * 変換後費目コードを設定する
     *
     * @param val 変換後費目コード
     */
    public void setNEWEXPCD(String val) {
        set(Mbj45CrExpConvert.NEWEXPCD, val);
    }

    /**
     * 変換後種別判断フラグを取得する
     *
     * @return 変換後種別判断フラグ
     */
    public String getNEWCLASSDIV() {
        return (String) get(Mbj45CrExpConvert.NEWCLASSDIV);
    }

    /**
     * 変換後種別判断フラグを設定する
     *
     * @param val 変換後種別判断フラグ
     */
    public void setNEWCLASSDIV(String val) {
        set(Mbj45CrExpConvert.NEWCLASSDIV, val);
    }

    /**
     * 変換後開始年月日を取得する
     *
     * @return 変換後開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getNEWDATEFROM() {
        return (Date) get(Mbj45CrExpConvert.NEWDATEFROM);
    }

    /**
     * 変換後開始年月日を設定する
     *
     * @param val 変換後開始年月日
     */
    public void setNEWDATEFROM(Date val) {
        set(Mbj45CrExpConvert.NEWDATEFROM, val);
    }

    /**
     * 変換後終了年月日を取得する
     *
     * @return 変換後終了年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getNEWDATETO() {
        return (Date) get(Mbj45CrExpConvert.NEWDATETO);
    }

    /**
     * 変換後終了年月日を設定する
     *
     * @param val 変換後終了年月日
     */
    public void setNEWDATETO(Date val) {
        set(Mbj45CrExpConvert.NEWDATETO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj45CrExpConvert.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj45CrExpConvert.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj45CrExpConvert.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj45CrExpConvert.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj45CrExpConvert.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj45CrExpConvert.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj45CrExpConvert.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj45CrExpConvert.UPDID, val);
    }

}
