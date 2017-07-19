package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体種別VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindMediaCategoryVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaCategoryVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMediaCategoryVO();
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj02EigyoDaicho.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj02EigyoDaicho.MEDIACD, val);
    }

    /**
     * 媒体種別コードを取得する
     *
     * @return 媒体種別コード
     */
    public String getMEDIASCD() {
        return (String) get(Tbj02EigyoDaicho.MEDIASCD);
    }

    /**
     * 媒体種別コードを設定する
     *
     * @param val 媒体種別コード
     */
    public void setMEDIASCD(String val) {
        set(Tbj02EigyoDaicho.MEDIASCD, val);
    }

    /**
     * 媒体種別名を取得する
     *
     * @return 媒体種別名
     */
    public String getMEDIASNM() {
        return (String) get(Tbj02EigyoDaicho.MEDIASNM);
    }

    /**
     * 媒体種別名を設定する
     *
     * @param val 媒体種別名
     */
    public void setMEDIASNM(String val) {
        set(Tbj02EigyoDaicho.MEDIASNM, val);
    }


}
