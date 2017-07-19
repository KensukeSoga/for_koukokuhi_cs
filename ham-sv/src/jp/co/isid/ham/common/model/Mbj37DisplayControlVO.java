package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj37DisplayControl;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 画面項目表示列制御マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj37DisplayControlVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj37DisplayControlVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj37DisplayControlVO();
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFORMID() {
        return (String) get(Mbj37DisplayControl.FORMID);
    }

    /**
     * 画面IDを設定する
     *
     * @param val 画面ID
     */
    public void setFORMID(String val) {
        set(Mbj37DisplayControl.FORMID, val);
    }

    /**
     * 一覧IDを取得する
     *
     * @return 一覧ID
     */
    public String getVIEWID() {
        return (String) get(Mbj37DisplayControl.VIEWID);
    }

    /**
     * 一覧IDを設定する
     *
     * @param val 一覧ID
     */
    public void setVIEWID(String val) {
        set(Mbj37DisplayControl.VIEWID, val);
    }

    /**
     * 列数を取得する
     *
     * @return 列数
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCOLCNT() {
        return (BigDecimal) get(Mbj37DisplayControl.COLCNT);
    }

    /**
     * 列数を設定する
     *
     * @param val 列数
     */
    public void setCOLCNT(BigDecimal val) {
        set(Mbj37DisplayControl.COLCNT, val);
    }

    /**
     * 列名を取得する
     *
     * @return 列名
     */
    public String getCOLNM() {
        return (String) get(Mbj37DisplayControl.COLNM);
    }

    /**
     * 列名を設定する
     *
     * @param val 列名
     */
    public void setCOLNM(String val) {
        set(Mbj37DisplayControl.COLNM, val);
    }

    /**
     * 列幅を取得する
     *
     * @return 列幅
     */
    public String getCOLWIDTH() {
        return (String) get(Mbj37DisplayControl.COLWIDTH);
    }

    /**
     * 列幅を設定する
     *
     * @param val 列幅
     */
    public void setCOLWIDTH(String val) {
        set(Mbj37DisplayControl.COLWIDTH, val);
    }

    /**
     * 表示区分を取得する
     *
     * @return 表示区分
     */
    public String getDISPLAYKBN() {
        return (String) get(Mbj37DisplayControl.DISPLAYKBN);
    }

    /**
     * 表示区分を設定する
     *
     * @param val 表示区分
     */
    public void setDISPLAYKBN(String val) {
        set(Mbj37DisplayControl.DISPLAYKBN, val);
    }

    /**
     * 制御区分を取得する
     *
     * @return 制御区分
     */
    public String getCONTROLKBN() {
        return (String) get(Mbj37DisplayControl.CONTROLKBN);
    }

    /**
     * 制御区分を設定する
     *
     * @param val 制御区分
     */
    public void setCONTROLKBN(String val) {
        set(Mbj37DisplayControl.CONTROLKBN, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj37DisplayControl.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj37DisplayControl.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj37DisplayControl.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj37DisplayControl.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj37DisplayControl.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj37DisplayControl.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj37DisplayControl.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj37DisplayControl.UPDID, val);
    }

}
