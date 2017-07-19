package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ版AllocationPicture素材情報検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** SEQ */
    public static final String SEQ = "SEQ";

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureMaterialVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindRdAllocationPictureMaterialVO();
    }

    /**
     * SEQを取得する
     * @return BigDecimal SEQ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQ() {
        return (BigDecimal) get(SEQ);
    }

    /**
     * SEQを設定する
     * @param val BigDecimal SEQ
     */
    public void setSEQ(BigDecimal val) {
        set(SEQ, val);
    }

    /**
     * 10桁CMコードを取得する
     * @return String 10桁CMコード
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * 10桁CMコードを設定する
     * @param val String 10桁CMコード
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * 略コードを取得する
     * @return String 略コード
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * 略コードを設定する
     * @param val String 略コード
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * タイトルを取得する
     * @return String タイトル
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * タイトルを設定する
     * @param val String タイトル
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * 車種コードを取得する
     * @return String 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * 車種コードを設定する
     * @param val String 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * 車種名を取得する
     * @return String 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     * @param val String 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 秒数を取得する
     * @return String 秒数
     */
    public String getSecond() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     * @param val String 秒数
     */
    public void setSecond(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * 文字色を取得する
     * @return String 文字色
     */
    public String getFORECOLOR() {
        return (String) get(Tbj20SozaiKanriList.FORECOLOR);
    }

    /**
     * 文字色を設定する
     * @param val String 文字色
     */
    public void setFORECOLOR(String val) {
        set(Tbj20SozaiKanriList.FORECOLOR, val);
    }

    /**
     * 背景色を取得する
     * @return String 背景色
     */
    public String getBACKCOLOR() {
        return (String) get(Tbj20SozaiKanriList.BACKCOLOR);
    }

    /**
     * 背景色を設定する
     * @param val String 背景色
     */
    public void setBACKCOLOR(String val) {
        set(Tbj20SozaiKanriList.BACKCOLOR, val);
    }

}
