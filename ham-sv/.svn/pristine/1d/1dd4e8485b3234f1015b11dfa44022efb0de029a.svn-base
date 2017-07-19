package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj10CrCarInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * BudgetDAO.findBudgetで取得したデータを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RepDataForCostMngHeaderVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepDataForCostMngHeaderVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepDataForCostMngHeaderVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj10CrCarInfo.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj10CrCarInfo.DCARCD, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj10CrCarInfo.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj10CrCarInfo.PHASE, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj10CrCarInfo.CRDATE);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setCRDATE(Date val) {
        set(Tbj10CrCarInfo.CRDATE, val);
    }

    /**
     * RAPを取得する
     *
     * @return RAP
     */
    public String getRAP() {
        return (String) get(Tbj10CrCarInfo.RAP);
    }

    /**
     * RAPを設定する
     *
     * @param val RAP
     */
    public void setRAP(String val) {
        set(Tbj10CrCarInfo.RAP, val);
    }

    /**
     * CP担当者を取得する
     *
     * @return CP担当者
     */
    public String getCPUSER() {
        return (String) get(Tbj10CrCarInfo.CPUSER);
    }

    /**
     * CP担当者を設定する
     *
     * @param val CP担当者
     */
    public void setCPUSER(String val) {
        set(Tbj10CrCarInfo.CPUSER, val);
    }

    /**
     * CD/スタッフを取得する
     *
     * @return CD/スタッフ
     */
    public String getCDSTAFF() {
        return (String) get(Tbj10CrCarInfo.CDSTAFF);
    }

    /**
     * CD/スタッフを設定する
     *
     * @param val CD/スタッフ
     */
    public void setCDSTAFF(String val) {
        set(Tbj10CrCarInfo.CDSTAFF, val);
    }

    /**
     * 製作会社を取得する
     *
     * @return 製作会社
     */
    public String getCRCOMPANY() {
        return (String) get(Tbj10CrCarInfo.CRCOMPANY);
    }

    /**
     * 製作会社を設定する
     *
     * @param val 製作会社
     */
    public void setCRCOMPANY(String val) {
        set(Tbj10CrCarInfo.CRCOMPANY, val);
    }

    /**
     * スケジュール１を取得する
     *
     * @return スケジュール１
     */
    public String getSCHEDULE1() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE1);
    }

    /**
     * スケジュール１を設定する
     *
     * @param val スケジュール１
     */
    public void setSCHEDULE1(String val) {
        set(Tbj10CrCarInfo.SCHEDULE1, val);
    }

    /**
     * スケジュール２を取得する
     *
     * @return スケジュール２
     */
    public String getSCHEDULE2() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE2);
    }

    /**
     * スケジュール２を設定する
     *
     * @param val スケジュール２
     */
    public void setSCHEDULE2(String val) {
        set(Tbj10CrCarInfo.SCHEDULE2, val);
    }

    /**
     * スケジュール３を取得する
     *
     * @return スケジュール３
     */
    public String getSCHEDULE3() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE3);
    }

    /**
     * スケジュール３を設定する
     *
     * @param val スケジュール３
     */
    public void setSCHEDULE3(String val) {
        set(Tbj10CrCarInfo.SCHEDULE3, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getNOTE() {
        return (String) get(Tbj10CrCarInfo.NOTE);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setNOTE(String val) {
        set(Tbj10CrCarInfo.NOTE, val);
    }
}
