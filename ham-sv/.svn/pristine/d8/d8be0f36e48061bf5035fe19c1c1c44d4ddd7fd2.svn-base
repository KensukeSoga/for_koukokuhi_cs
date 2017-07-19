package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * タレント・ナレーター・楽曲契約表検索(帳票用)データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = -5319490262128457569L;

    /** 期間開始の最小値 */
    private static final String MIN_DATEFROM = "MIN_DATEFROM";


    /**
     * デフォルトコンストラクタ
     */
    public Contract4ReportVO() {
    }

    /**
     * 車種コードを取得する.
     *
     * @return 車種コード
     */
    public String getDcarcd()     {
        Object obj = get(Tbj18SozaiKanriData.DCARCD);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * 車種コードを設定する.
     *
     * @param val 車種コード
     */
    public void setDcarcd(String val) {
        set(Tbj18SozaiKanriData.DCARCD, val);
    }

    /**
     * 車種名を取得する.
     *
     * @return 車種名
     */
    public String getCarnm() {
        Object obj = get(Mbj05Car.CARNM);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * 車種名を設定する.
     *
     * @param val 車種名
     */
    public void setCarnm(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * タイトルを取得する.
     *
     * @return タイトル
     */
    public String getTitle() {
        Object obj = get(Tbj18SozaiKanriData.TITLE);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * タイトルを設定する.
     *
     * @param val タイトル
     */
    public void setTitle(String val) {
        set(Tbj18SozaiKanriData.TITLE, val);
    }

    /**
     * 期間開始の最小値を取得する.
     *
     * @return 期間開始の最小値
     */
    public Date getMinDateFrom() {
        Object obj = get(MIN_DATEFROM);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * 期間開始の最小値を設定する.
     *
     * @param val 期間開始の最小値
     */
    public void setMinDateFrom(Date val) {
        set(MIN_DATEFROM, val);
    }

    /**
     * 契約種類を取得する.
     *
     * @return 契約種類
     */
    public String getCtrtkbn() {
        Object obj = get(Tbj16ContractInfo.CTRTKBN);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * 契約種類を設定する.
     *
     * @param val 契約種類
     */
    public void setCtrtkbn(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * 名称を取得する.
     *
     * @return 名称
     */
    public String getNames() {
        Object obj = get(Tbj16ContractInfo.NAMES);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * 名称を設定する.
     *
     * @param val 名称
     */
    public void setNames(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * 楽曲名を取得する.
     *
     * @return 楽曲名
     */
    public String getMusic() {
        Object obj = get(Tbj16ContractInfo.MUSIC);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * 楽曲名を設定する.
     *
     * @param val 楽曲名
     */
    public void setMusic(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * 契約期間(From)を取得する.
     *
     * @return 契約期間(From)
     */
    public Date getDateFrom() {
        Object obj = get(Tbj16ContractInfo.DATEFROM);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * 契約期間(From)を設定する.
     *
     * @param val 契約期間(From)
     */
    public void setDateFrom(Date val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * 契約期間(To)を取得する.
     *
     * @return 契約期間(To)
     */
    public Date getDateTo() {
        Object obj = get(Tbj16ContractInfo.DATETO);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * 契約期間(To)を設定する.
     *
     * @param val 契約期間(To)
     */
    public void setDateTo(Date val) {
        set(Tbj16ContractInfo.DATETO, val);
    }
}
