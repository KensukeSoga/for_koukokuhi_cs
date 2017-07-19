package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.nj.model.AbstractModel;
/**
 * <P>
 * 媒体VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 H.Watabe)<BR>
 * </P>
 * @author H.Watabe
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class MediaListVO extends AbstractModel {


    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MediaListVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new MediaListVO();
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Mbj03Media.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Mbj03Media.MEDIACD, val);
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体名を設定する
     *
     * @param val 媒体名
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 媒体名（媒体費作成用）を取得する
     *
     * @return 媒体名（媒体費作成用）
     */
    public String getHCMEDIANM() {
        return (String) get(Mbj03Media.HCMEDIANM);
    }

    /**
     * 媒体名（媒体費作成用）を設定する
     *
     * @param val 媒体名（媒体費作成用）
     */
    public void setHCMEDIANM(String val) {
        set(Mbj03Media.HCMEDIANM, val);
    }

    /**
     * 電通値引率を取得する
     *
     * @return 電通値引率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDNEBIKI() {
        return (BigDecimal) get(Mbj03Media.DNEBIKI);
    }

    /**
     * 電通値引率を設定する
     *
     * @param val 電通値引率
     */
    public void setDNEBIKI(BigDecimal val) {
        set(Mbj03Media.DNEBIKI, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj03Media.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj03Media.SORTNO, val);
    }

    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAUTHORITY() {
        return (String) get(Mbj10MediaSec.AUTHORITY);
    }

    /**
     * 権限を設定する
     *
     * @param val 権限
     */
    public void setAUTHORITY(String val) {
        set(Mbj10MediaSec.AUTHORITY, val);
    }
}
