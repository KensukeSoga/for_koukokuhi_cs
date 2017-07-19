package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
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
public class RepDataForChkListHAMVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepDataForChkListHAMVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepDataForChkListHAMVO();
    }
    /**
     * 受注No.を取得する
     *
     * @return 受注No.
     */
    public String getORDERNO() {
        return (String) get(Tbj11CrCreateData.ORDERNO);
    }

    /**
     * 受注No.を設定する
     *
     * @param val 受注No.
     */
    public void setORDERNO(String val) {
        set(Tbj11CrCreateData.ORDERNO, val);
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
    /**
     * 予算表費目を取得する
     *
     * @return 予算表費目
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * 予算表費目を設定する
     *
     * @param val 予算表費目
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }
    /**
     * 費目を取得する
     *
     * @return 費目
     */
    public String getEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * 費目を設定する
     *
     * @param val 費目
     */
    public void setEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
    }
    /**
     * 詳細を取得する
     *
     * @return 詳細
     */
    public String getDETAIL() {
        return (String) get(Tbj11CrCreateData.DETAIL);
    }

    /**
     * 詳細を設定する
     *
     * @param val 詳細
     */
    public void setDETAIL(String val) {
        set(Tbj11CrCreateData.DETAIL, val);
    }
    /**
     * 請求先Ｇｒ．を取得する
     *
     * @return 請求先Ｇｒ．
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * 請求先Ｇｒ．を設定する
     *
     * @param val 請求先Ｇｒ．
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }
    /**
     * 納品日を取得する
     *
     * @return 納品日
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * 納品日を設定する
     *
     * @param val 納品日
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
    }
    /**
     * 請求金額を取得する
     *
     * @return 請求金額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.CLMMONEY);
    }

    /**
     * 請求金額を設定する
     *
     * @param val 請求金額
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.CLMMONEY, val);
    }

    /**
     * 区分を取得する
     *
     * @return 区分
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分を設定する
     *
     * @param val 区分
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * 入力担当者を取得する
     *
     * @return 入力担当者
     */
    public String getINPUTTNTNM() {
        return (String) get(Mbj30InputTnt.INPUTTNT);
    }

    /**
     * 入力担当者を設定する
     *
     * @param val 入力担当者
     */
    public void setINPUTTNTNM(String val) {
        set(Mbj30InputTnt.INPUTTNT, val);
    }


}
