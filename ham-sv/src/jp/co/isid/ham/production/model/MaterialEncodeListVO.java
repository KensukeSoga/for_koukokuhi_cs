package jp.co.isid.ham.production.model;


import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材エンコード表VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialEncodeListVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * コンストラクタ
     */
    public MaterialEncodeListVO() {

    }
    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new MaterialEncodeListVO();
    }

    /**
     * ステータスを取得する
     * @return
     */
    public String getSTATUS() {
        return (String) get(Tbj18SozaiKanriData.STATUS);
    }

    /**
     * ステータスを設定する
     * @param val
     */
    public void setSTATUS(String val) {
        set(Tbj18SozaiKanriData.STATUS, val);
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
     * 車種担当を取得する
     *
     * @return 車種担当
     */
    public String getSYATAN() {
        return (String) get(Tbj18SozaiKanriData.SYATAN);
    }

    /**
     * 車種担当を設定する
     *
     * @param val 車種担当
     */
    public void setSYATAN(String val) {
        set(Tbj18SozaiKanriData.SYATAN, val);
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

}
