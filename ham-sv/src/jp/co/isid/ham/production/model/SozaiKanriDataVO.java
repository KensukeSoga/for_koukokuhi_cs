package jp.co.isid.ham.production.model;


import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;

/**
 * <P>
 * 素材登録＋名称VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class SozaiKanriDataVO extends Tbj18SozaiKanriDataVO {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /* 2015/12/01 JASRAC対応 HLC S,Fujimoto ADD Start */
    /** 本素材・仮素材フラグ */
    public static final String TEMPFLG = "TEMPFLG";
    /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public SozaiKanriDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new SozaiKanriDataVO();
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
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
