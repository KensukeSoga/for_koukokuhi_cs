package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算費目マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj16CrExpenceVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj16CrExpenceVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj16CrExpenceVO();
    }

    /**
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getEXPCD() {
        return (String) get(Mbj16CrExpence.EXPCD);
    }

    /**
     * 費目コードを設定する
     *
     * @param val 費目コード
     */
    public void setEXPCD(String val) {
        set(Mbj16CrExpence.EXPCD, val);
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getCLASSDIV() {
        return (String) get(Mbj16CrExpence.CLASSDIV);
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param val 種別判断フラグ
     */
    public void setCLASSDIV(String val) {
        set(Mbj16CrExpence.CLASSDIV, val);
    }

    /**
     * 開始年月日を取得する
     *
     * @return 開始年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Mbj16CrExpence.DATEFROM);
    }

    /**
     * 開始年月日を設定する
     *
     * @param val 開始年月日
     */
    public void setDATEFROM(Date val) {
        set(Mbj16CrExpence.DATEFROM, val);
    }

    /**
     * 終了年月日を取得する
     *
     * @return 終了年月日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Mbj16CrExpence.DATETO);
    }

    /**
     * 終了年月日を設定する
     *
     * @param val 終了年月日
     */
    public void setDATETO(Date val) {
        set(Mbj16CrExpence.DATETO, val);
    }

    /**
     * 費目名を取得する
     *
     * @return 費目名
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * 費目名を設定する
     *
     * @param val 費目名
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj16CrExpence.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj16CrExpence.SORTNO, val);
    }

    /**
     * フラグ１を取得する
     *
     * @return フラグ１
     */
    public String getFLG1() {
        return (String) get(Mbj16CrExpence.FLG1);
    }

    /**
     * フラグ１を設定する
     *
     * @param val フラグ１
     */
    public void setFLG1(String val) {
        set(Mbj16CrExpence.FLG1, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj16CrExpence.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj16CrExpence.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj16CrExpence.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj16CrExpence.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj16CrExpence.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj16CrExpence.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj16CrExpence.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj16CrExpence.UPDID, val);
    }

}
