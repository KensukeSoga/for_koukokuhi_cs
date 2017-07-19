package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * キャンペーン詳細拒否データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 FM H.Izawa)<BR>
 * </P>
 * @author FM H.Izawa
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindInputRejectionVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**媒体カウント*/
    private String BAITAI_CNT = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindInputRejectionVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindInputRejectionVO();
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj01MediaPlan.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj01MediaPlan.MEDIACD, val);
    }

    /**
     * 出稿予定年月を取得する
     *
     * @return 出稿予定年月
     */
    public String getYOTEIYM() {
        return (String) get(Tbj01MediaPlan.YOTEIYM);
    }

    /**
     * 出稿予定年月を設定する
     *
     * @param val 出稿予定年月
     */
    public void setYOTEIYM(String val) {
        set(Tbj01MediaPlan.YOTEIYM, val);
    }

    /**
     * 媒体カウントを取得する
     *
     * @return 媒体カウント
     */
    public String getBAITAICNT() {
        return (String) get(this.BAITAI_CNT);
    }

    /**
     * 媒体カウントを設定する
     *
     * @param val 媒体カウント
     */
    public void setBAITAICNT(String val) {
        set(this.BAITAI_CNT, val);
    }

}
