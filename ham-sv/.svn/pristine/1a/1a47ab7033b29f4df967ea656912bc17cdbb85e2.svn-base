package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.integ.tbl.Tbj17Content;

/**
 * <P>
 * 契約情報登録使用素材表示用データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/30 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindUseMaterialVO extends Tbj18SozaiKanriDataVO {

    private static final long serialVersionUID = 1L;

    /* 2015/11/30 JASRAC対応 HLC S,Fujimoto ADD Start */
    /** 本素材・仮素材フラグ */
    public static final String TEMPFLG = "TEMPFLG";
    /* 2015/11/30 JASRAC対応 HLC S.Fujimoto ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public FindUseMaterialVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindUseMaterialVO();
    }

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj17Content.CTRTKBN);
    }

    /**
     * 契約種類を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj17Content.CTRTKBN, val);
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj17Content.CTRTNO);
    }

    /**
     * 契約コードを設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj17Content.CTRTNO, val);
    }

    /* 2015/11/30 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * 本素材・仮素材フラグを取得する
     * @return String 本素材・仮素材フラグ
     */
    public String getTEMPFLG() {
        return (String) get(TEMPFLG);
    }

    /**
     * 本素材・仮素材フラグを設定する
     * @param val String 本素材・仮素材フラグ
     */
    public void setTEMPFLG(String val) {
        set(TEMPFLG , val);
    }
    /* 2015/11/30 JASRAC対応 HLC S.Fujimoto ADD End */

}
