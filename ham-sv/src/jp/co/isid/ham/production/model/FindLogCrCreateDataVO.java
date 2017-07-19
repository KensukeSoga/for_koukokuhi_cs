package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj27LogCrCreateDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
/**
 * <P>
 * 取得したデータを格納するVOクラス
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
public class FindLogCrCreateDataVO extends Tbj27LogCrCreateDataVO {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindLogCrCreateDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindLogCrCreateDataVO();
    }

    /**
     * 履歴名称を取得する
     *
     * @return 履歴名称
     */
    public String getHISTORYNM() {
        return (String) get("HISTORYNM");
    }

    /**
     * 履歴名称を設定する
     *
     * @param val 履歴名称
     */
    public void setHISTORYNM(String val) {
        set("HISTORYNM", val);
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
     * 分類名を取得する
     *
     * @return 分類名
     */
    public String getCLASSNM() {
        return (String) get(Mbj15CrClass.CLASSNM);
    }

    /**
     * 分類名を設定する
     *
     * @param val 分類名
     */
    public void setCLASSNM(String val) {
        set(Mbj15CrClass.CLASSNM, val);
    }

    /**
     * 費目名を取得する
     *
     * @return 費目名
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * 費目名を設定する
     *
     * @param val 費目名
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * 区分名を取得する
     *
     * @return 区分名
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * 区分名を設定する
     *
     * @param val 区分名
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * グループ名を取得する
     *
     * @return グループ名
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * グループ名を設定する
     *
     * @param val グループ名
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * 設定局名を取得する
     *
     * @return 設定局名
     */
    public String getSTKYKNM() {
        return (String) get(Mbj29SetteiKyk.STKYKNM);
    }

    /**
     * 設定局名を設定する
     *
     * @param val 設定局名
     */
    public void setSTKYKNM(String val) {
        set(Mbj29SetteiKyk.STKYKNM, val);
    }

    /**
     * 入力担当を取得する
     *
     * @return 入力担当
     */
    public String getINPUTTNT() {
        return (String) get(Mbj30InputTnt.INPUTTNT);
    }

    /**
     * 入力担当を設定する
     *
     * @param val 入力担当
     */
    public void setINPUTTNT(String val) {
        set(Mbj30InputTnt.INPUTTNT, val);
    }

    /**
     * 連携ステータス名を取得する
     *
     * @return 連携ステータス名
     */
    public String getRSTATUSNM() {
        return (String) get("RSTATUSNM");
    }

    /**
     * 連携ステータス名を設定する
     *
     * @param val 連携ステータス名
     */
    public void setRSTATUSNM(String val) {
        set("RSTATUSNM", val);
    }

}
