package jp.co.isid.ham.common.model;


import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 取引先部門VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu13ThsKgyBmonVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu13ThsKgyBmonVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu13ThsKgyBmonVO();
    }

    /**
     * 取引先企業コードを取得する
     *
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
    }

    /**
     * 取引先企業コードを設定する
     *
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.THSKGYCD, val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SEQNO);
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SEQNO, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.ENDYMD, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.STARTYMD, val);
    }

    /**
     * 申請者コードを取得する
     *
     * @return 申請者コード
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SNSTNT);
    }

    /**
     * 申請者コードを設定する
     *
     * @param val 申請者コード
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SNSTNT, val);
    }

    /**
     * サブ名を取得する
     *
     * @return サブ名
     */
    public String getSUBMEI() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBMEI);
    }

    /**
     * サブ名を設定する
     *
     * @param val サブ名
     */
    public void setSUBMEI(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBMEI, val);
    }

    /**
     * サブ名（カナ）を取得する
     *
     * @return サブ名（カナ）
     */
    public String getSUBKN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBKN);
    }

    /**
     * サブ名（カナ）を設定する
     *
     * @param val サブ名（カナ）
     */
    public void setSUBKN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBKN, val);
    }

    /**
     * サブ名（英文）を取得する
     *
     * @return サブ名（英文）
     */
    public String getSUBEN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBEN);
    }

    /**
     * サブ名（英文）を設定する
     *
     * @param val サブ名（英文）
     */
    public void setSUBEN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBEN, val);
    }

    /**
     * サブ名（検索用カナ）を取得する
     *
     * @return サブ名（検索用カナ）
     */
    public String getSUBSRCHKN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN);
    }

    /**
     * サブ名（検索用カナ）を設定する
     *
     * @param val サブ名（検索用カナ）
     */
    public void setSUBSRCHKN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN, val);
    }

    /**
     * 業種（大中分類）を取得する
     *
     * @return 業種（大中分類）
     */
    public String getGSYLMCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GSYLMCD);
    }

    /**
     * 業種（大中分類）を設定する
     *
     * @param val 業種（大中分類）
     */
    public void setGSYLMCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GSYLMCD, val);
    }

    /**
     * 合併分割先コードを取得する
     *
     * @return 合併分割先コード
     */
    public String getGPIBKTSAKICD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD);
    }

    /**
     * 合併分割先コードを設定する
     *
     * @param val 合併分割先コード
     */
    public void setGPIBKTSAKICD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD, val);
    }

    /**
     * 合併分割先ＳＥＱＮＯを取得する
     *
     * @return 合併分割先ＳＥＱＮＯ
     */
    public String getGPIBKTSAKISEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO);
    }

    /**
     * 合併分割先ＳＥＱＮＯを設定する
     *
     * @param val 合併分割先ＳＥＱＮＯ
     */
    public void setGPIBKTSAKISEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO, val);
    }

    /**
     * 支払先信用コードを取得する
     *
     * @return 支払先信用コード
     */
    public String getSHRSINCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SHRSINCD);
    }

    /**
     * 支払先信用コードを設定する
     *
     * @param val 支払先信用コード
     */
    public void setSHRSINCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SHRSINCD, val);
    }

    /**
     * 本社支社区分を取得する
     *
     * @return 本社支社区分
     */
    public String getHNSHASSHAKBN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN);
    }

    /**
     * 本社支社区分を設定する
     *
     * @param val 本社支社区分
     */
    public void setHNSHASSHAKBN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN, val);
    }

    /**
     * 支払先職種コードを取得する
     *
     * @return 支払先職種コード
     */
    public String getSHRSSKSYUCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD);
    }

    /**
     * 支払先職種コードを設定する
     *
     * @param val 支払先職種コード
     */
    public void setSHRSSKSYUCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD, val);
    }

}
