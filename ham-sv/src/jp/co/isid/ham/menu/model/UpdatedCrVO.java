package jp.co.isid.ham.menu.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR制作費管理(変更データ)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.menu.ham.isid.co.jp/")
@XmlType(namespace = "http://model.menu.ham.isid.co.jp/")
public class UpdatedCrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public UpdatedCrVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new UpdatedCrVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj11CrCreateData.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj11CrCreateData.PHASE, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true)
    public Date getCRDATE() {
        return (Date) get(Tbj11CrCreateData.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj11CrCreateData.CRDATE, val);
    }

    /**
     * データ件数を取得する
     *
     * @return データ件数
     */
    @XmlElement(required = true)
    public BigDecimal getCNT() {
        return (BigDecimal) get("CNT");
    }

    /**
     * データ件数を設定する
     *
     * @param val データ件数
     */
    public void setCNT(BigDecimal val) {
        set("CNT", val);
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

}
