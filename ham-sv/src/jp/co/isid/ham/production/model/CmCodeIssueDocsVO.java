package jp.co.isid.ham.production.model;


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
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class CmCodeIssueDocsVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * コンストラクタ
     */
    public CmCodeIssueDocsVO() {

    }
    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new CmCodeIssueDocsVO();
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
     * 作成者IDを取得する
     *
     * @return 作成者ID
     */
    public String getCRTID() {
        return (String) get(Tbj18SozaiKanriData.CRTID);
    }

    /**
     * 作成者IDを設定する
     *
     * @param val 作成者ID
     */
    public void setCRTID(String val) {
        set(Tbj18SozaiKanriData.CRTID, val);
    }
}
