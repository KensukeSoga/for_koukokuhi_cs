package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 制作費車種VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCostManagementCarVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCostManagementCarVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindCostManagementCarVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Mbj05Car.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Mbj05Car.DCARCD, val);
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCarNm() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCarNm(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 制作費(請求)を取得する
     *
     * @return 制作費(請求)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSeisakuhis() {
        return (BigDecimal) get(Tbj21Seisakuhi.SEISAKUHIS);
    }

    /**
     * 制作費(請求)を設定する
     *
     * @param val 制作費(請求)
     */
    public void setSeisakuhis(BigDecimal val) {
        set(Tbj21Seisakuhi.SEISAKUHIS, val);
    }

    /**
     * 電通車種名を取得する
     *
     * @return 電通車種名
     */
    public String getDCarNm() {
        return (String) get(Tbj21Seisakuhi.DCARNM);
    }

    /**
     * 電通車種名を設定する
     *
     * @param val 電通車種名
     */
    public void setDCarNm(String val) {
        set(Tbj21Seisakuhi.DCARNM, val);
    }

    /**
     * その他を取得する
     *
     * @return その他
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSeisakuhiOther() {
        return (BigDecimal) get(Tbj21Seisakuhi.SEISAKUHIOTHER);
    }

    /**
     * その他を設定する
     *
     * @param val その他
     */
    public void setSeisakuhiOther(BigDecimal val) {
        set(Tbj21Seisakuhi.SEISAKUHIOTHER, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBiko() {
        return (String) get(Tbj21Seisakuhi.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBiko(String val) {
        set(Tbj21Seisakuhi.BIKO, val);
    }

    /**
     * 取込日時を取得する
     *
     * @return 取込日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getGetTime() {
        return (Date) get(Tbj21Seisakuhi.GETTIME);
    }

    /**
     * 取込日時を設定する
     *
     * @param val 取込日時
     */
    public void setGetTime(Date val) {
        set(Tbj21Seisakuhi.GETTIME, val);
    }

    /**
     * 作成日時を取得する
     *
     * @return 作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtDate() {
        return (Date) get(Tbj21Seisakuhi.CRTDATE);
    }

    /**
     * 作成日時を設定する
     *
     * @param val 作成日時
     */
    public void setCrtDate(Date val) {
        set(Tbj21Seisakuhi.CRTDATE, val);
    }

    /**
     * 作成者を取得する
     *
     * @return 作成者
     */
    public String getCrtNm() {
        return (String) get(Tbj21Seisakuhi.CRTNM);
    }

    /**
     * 作成者を設定する
     *
     * @param val 作成者
     */
    public void setCrtNm(String val) {
        set(Tbj21Seisakuhi.CRTNM, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj21Seisakuhi.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj21Seisakuhi.CRTID, val);
    }

    /**
     * 更新日時を取得する
     *
     * @return 更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpdDate() {
        return (Date) get(Tbj21Seisakuhi.UPDDATE);
    }

    /**
     * 更新日時を設定する
     *
     * @param val 更新日時
     */
    public void setUpdDate(Date val) {
        set(Tbj21Seisakuhi.UPDDATE, val);
    }

    /**
     * 更新者IDを取得する
     *
     * @return 更新者ID
     */
    public String getUpdId() {
        return (String) get(Tbj21Seisakuhi.UPDID);
    }

    /**
     * 更新者IDを設定する
     *
     * @param val 更新者ID
     */
    public void setUpdId(String val) {
        set(Tbj21Seisakuhi.UPDID, val);
    }

}
