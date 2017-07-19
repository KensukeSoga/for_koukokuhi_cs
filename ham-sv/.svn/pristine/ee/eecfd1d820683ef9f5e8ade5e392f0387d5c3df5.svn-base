package jp.co.isid.ham.production.model;

import java.util.Date;

import jp.co.isid.nj.model.AbstractModel;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;

/**
 * <P>
 * 取得したデータを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/04/18 新HAMチーム)<BR>
 * ・JASRAC対応(2015/12/04 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetContentMaterialVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
    /** 本素材・仮素材フラグ */
    public static final String TEMPFLG = "TEMPFLG";
    /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public GetContentMaterialVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new GetContentMaterialVO();
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj17Content.CMCD, val);
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

    /**
     * 放送開始日を取得する
     *
     * @return 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getHOUSOUDATEFROM() {
        return (Date) get(Tbj18SozaiKanriData.DATEFROM);
    }

    /**
     * 放送開始日を設定する
     *
     * @param val 放送開始日
     */
    public void setHOUSOUDATEFROM(Date val) {
        set(Tbj18SozaiKanriData.DATEFROM, val);
    }

    /**
     * 名称を取得する
     *
     * @return 名称
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * 名称を設定する
     *
     * @param val 名称
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * 契約期間(From)を取得する
     *
     * @return 契約期間(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj16ContractInfo.DATEFROM);
    }

    /**
     * 契約期間(From)を設定する
     *
     * @param val 契約期間(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * 契約期間(To)を取得する
     *
     * @return 契約期間(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj16ContractInfo.DATETO);
    }

    /**
     * 契約期間(To)を設定する
     *
     * @param val 契約期間(To)
     */
    public void setDATETO(Date val) {
        set(Tbj16ContractInfo.DATETO, val);
    }

    /**
     * 楽曲名を取得する
     *
     * @return 楽曲名
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * 楽曲名を設定する
     *
     * @param val 楽曲名
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
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
    /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */
}
