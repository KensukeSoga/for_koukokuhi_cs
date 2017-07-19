package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
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
public class RepDataForChkListR3VO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepDataForChkListR3VO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepDataForChkListR3VO();
    }

    /**
     * 得意先企業コードを取得する
     *
     * @return 得意先企業コード
     */
    public String getTKSKGYCD() {
        return (String) get("TKSKGYCD");
    }

    /**
     * 得意先企業コードを設定する
     *
     * @param val 得意先企業コード
     */
    public void setTKSKGYCD(String val) {
        set("TKSKGYCD", val);
    }

    /**
     * 得意先部門コードを取得する
     *
     * @return 得意先部門コード
     */
    public String getTKSBMNSEQNO() {
        return (String) get("TKSBMNSEQNO");
    }

    /**
     * 得意先部門コードを設定する
     *
     * @param val 得意先部門コード
     */
    public void setTKSBMNSEQNO(String val) {
        set("TKSBMNSEQNO", val);
    }

    /**
     * 得意先担当コードを取得する
     *
     * @return 得意先担当コード
     */
    public String getTKSTNTSEQNO() {
        return (String) get("TKSTNTSEQNO");
    }

    /**
     * 得意先担当コードを設定する
     *
     * @param val 得意先担当コード
     */
    public void setTKSTNTSEQNO(String val) {
        set("TKSTNTSEQNO", val);
    }

    /**
     * 費目を取得する
     *
     * @return 費目
     */
    public String getHMOKNM() {
        return (String) get("HMOKNM");
    }

    /**
     * 費目を設定する
     *
     * @param val 費目
     */
    public void setHMOKNM(String val) {
        set("HMOKNM", val);
    }
    /**
     * 件名を取得する
     *
     * @return 件名
     */
    public String getKKNAMEJ() {
        return (String) get("KKNAMEJ");
    }

    /**
     * 件名を設定する
     *
     * @param val 件名
     */
    public void setKKNAMEJ(String val) {
        set("KKNAMEJ", val);
    }
    /**
     * 補足内容を取得する
     *
     * @return 補足内容
     */
    public String getHOSOK() {
        return (String) get("HOSOK");
    }

    /**
     * 補足内容を設定する
     *
     * @param val 補足内容
     */
    public void setHOSOK(String val) {
        set("HOSOK", val);
    }
    /**
     * 期間FROM(年）を取得する
     *
     * @return 期間FROM(年）
     */
    public String getTERMFRYY() {
        return (String) get("TERMFRYY");
    }

    /**
     * 期間FROM(年）を設定する
     *
     * @param val 期間FROM(年）
     */
    public void setTERMFRYY(String val) {
        set("TERMFRYY", val);
    }
    /**
     * 期間FROM(月）を取得する
     *
     * @return 期間FROM(月）
     */
    public String getTERMFRMM() {
        return (String) get("TERMFRMM");
    }

    /**
     * 期間FROM(月）を設定する
     *
     * @param val 期間FROM(月）
     */
    public void setTERMFRMM(String val) {
        set("TERMFRMM", val);
    }
    /**
     * 期間FROM(日）を取得する
     *
     * @return 期間FROM(日）
     */
    public String getTERMFRDD() {
        return (String) get("TERMFRDD");
    }

    /**
     * 期間FROM(日）を設定する
     *
     * @param val 期間FROM(日）
     */
    public void setTERMFRDD(String val) {
        set("TERMFRDD", val);
    }
    /**
     * 期間TO(年）を取得する
     *
     * @return 期間TO(年）
     */
    public String getTERMTOYY() {
        return (String) get("TERMTOYY");
    }

    /**
     * 期間TO(年）を設定する
     *
     * @param val 期間TO(年）
     */
    public void setTERMTOYY(String val) {
        set("TERMTOYY", val);
    }
    /**
     * 期間TO(月）を取得する
     *
     * @return 期間TO(月）
     */
    public String getTERMTOMM() {
        return (String) get("TERMTOMM");
    }

    /**
     * 期間TO(月）を設定する
     *
     * @param val 期間TO(月）
     */
    public void setTERMTOMM(String val) {
        set("TERMTOMM", val);
    }
    /**
     * 期間TO(日）を取得する
     *
     * @return 期間TO(日）
     */
    public String getTERMTODD() {
        return (String) get("TERMTODD");
    }

    /**
     * 期間TO(日）を設定する
     *
     * @param val 期間TO(日）
     */
    public void setTERMTODD(String val) {
        set("TERMTODD", val);
    }
    /**
     * 納品日を取得する
     *
     * @return 納品日
     */
    public String getKEISYMD() {
        return (String) get("KEISYMD");
    }

    /**
     * 納品日を設定する
     *
     * @param val 納品日
     */
    public void setKEISYMD(String val) {
        set("KEISYMD", val);
    }
    /**
     * 取り金額を取得する
     *
     * @return 取り金額
     */
    public BigDecimal getTRGAK() {
        return (BigDecimal) get("TRGAK");
    }

    /**
     * 取り金額を設定する
     *
     * @param val 取り金額
     */
    public void setTRGAK(BigDecimal val) {
        set("TRGAK", val);
    }
    /**
     * 値引き額を取得する
     *
     * @return 値引き額
     */
    public BigDecimal getNEBIGAK() {
        return (BigDecimal) get("NEBIGAK");
    }

    /**
     * 値引き額を設定する
     *
     * @param val 値引き額
     */
    public void setNEBIGAK(BigDecimal val) {
        set("NEBIGAK", val);
    }
    /**
     * 区分を取得する
     *
     * @return 区分
     */
    public String getKBNNM() {
        return (String) get("KBNNM");
    }

    /**
     * 区分を設定する
     *
     * @param val 区分
     */
    public void setKBNNM(String val) {
        set("KBNNM", val);
    }

    /**
     * 発注局を取得する
     *
     * @return 発注局
     */
    public String getKYOKUNM() {
        return (String) get("KYOKUNM");
    }

    /**
     * 発注局を設定する
     *
     * @param val 発注局
     */
    public void setKYOKUNM(String val) {
        set("KYOKUNM", val);
    }

    /**
     * 受注NOを取得する
     *
     * @return 受注NO
     */
    public String getJYUTNO() {
        return (String) get("JYUTNO");
    }

    /**
     * 受注NOを設定する
     *
     * @param val 受注NO
     */
    public void setJYUTNO(String val) {
        set("JYUTNO", val);
    }

    /**
     * 受注明細SEQNOを取得する
     *
     * @return 受注明細SEQNO
     */
    public String getJYMEISEQ() {
        return (String) get("JYMEISEQ");
    }

    /**
     * 受注明細SEQNOを設定する
     *
     * @param val 受注明細SEQNO
     */
    public void setJYMEISEQ(String val) {
        set("JYMEISEQ", val);
    }

    /**
     * 担当者コードを取得する
     *
     * @return 担当者コード
     */
    public String getEGTNTCD() {
        return (String) get("EGTNTCD");
    }

    /**
     * 担当者コードを設定する
     *
     * @param val 担当者コード
     */
    public void setEGTNTCD(String val) {
        set("EGTNTCD", val);
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getEGTNTNM() {
        return (String) get("EGTNTNM");
    }

    /**
     * 担当者名を設定する
     *
     * @param val 担当者名
     */
    public void setEGTNTNM(String val) {
        set("EGTNTNM", val);
    }
}
