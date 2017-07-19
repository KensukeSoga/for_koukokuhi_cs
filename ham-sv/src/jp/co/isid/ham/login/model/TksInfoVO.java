package jp.co.isid.ham.login.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu16Skukjk;
import jp.co.isid.nj.model.AbstractModel;

public class TksInfoVO extends AbstractModel {

	private static final long serialVersionUID = 7561739022049341403L;

	/**
     * 新規インスタンスを構築します
     */
    public TksInfoVO() {
    }

    /**
     * 新規インスタンスを構築します
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new TksInfoVO();
    }

    /**
     * 取引先企業コードを取得する
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.THSKGYCD);
    }

    /**
     * 取引先企業コードを設定する
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.THSKGYCD, val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SEQNO);
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.SEQNO, val);
    }

    /**
     * 取担当ＳＥＱＮＯを取得する
     *
     * @return 取担当ＳＥＱＮＯ
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.TRTNTSEQNO);
    }

    /**
     * 取担当ＳＥＱＮＯを設定する
     *
     * @param val 取担当ＳＥＱＮＯ
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.TRTNTSEQNO, val);
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SIKCD);
    }

    /**
     * 組織コードを設定する
     *
     * @param val 組織コード
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.SIKCD, val);
    }

    /**
     * 広告主企業コードを取得する
     *
     * @return 広告主企業コード
     */
    public String getCLNTKGYCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.CLNTKGYCD);
    }

    /**
     * 広告主企業コードを設定する
     *
     * @param val 広告主企業コード
     */
    public void setCLNTKGYCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.CLNTKGYCD, val);
    }

    /**
     * 広告主ＳＥＱＮＯを取得する
     *
     * @return 広告主ＳＥＱＮＯ
     */
    public String getCLNTSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.CLNTSEQNO);
    }

    /**
     * 広告主ＳＥＱＮＯを設定する
     *
     * @param val 広告主ＳＥＱＮＯ
     */
    public void setCLNTSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.CLNTSEQNO, val);
    }

    /**
     * 信用コードを取得する
     *
     * @return 信用コード
     */
    public String getSINCD() {
        return (String) get(RepaVbjaMeu16Skukjk.SINCD);
    }

    /**
     * 信用コードを設定する
     *
     * @param val 信用コード
     */
    public void setSINCD(String val) {
        set(RepaVbjaMeu16Skukjk.SINCD, val);
    }

    /**
     * 代理店区分を取得する
     *
     * @return 代理店区分
     */
    public String getDTENKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.DTENKBN);
    }

    /**
     * 代理店区分を設定する
     *
     * @param val 代理店区分
     */
    public void setDTENKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.DTENKBN, val);
    }

    /**
     * 取引先企業名（表示用漢字）を取得する
     *
     * @return 取引先企業名（表示用漢字）
     */
    public String getTHSKGYDISPKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
    }

    /**
     * 取引先企業名（表示用漢字）を設定する
     *
     * @param val 取引先企業名（表示用漢字）
     */
    public void setTHSKGYDISPKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ, val);
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
     * 組織コード（局）を取得する
     *
     * @return 組織コード（局）
     */
    public String getSIKCDKYK() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKYK);
    }

    /**
     * 組織コード（局）を設定する
     *
     * @param val 組織コード（局）
     */
    public void setSIKCDKYK(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKYK, val);
    }

    /**
     * 組織コード（部）を取得する
     *
     * @return 組織コード（部）
     */
    public String getSIKCDBU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDBU);
    }

    /**
     * 組織コード（部）を設定する
     *
     * @param val 組織コード（部）
     */
    public void setSIKCDBU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDBU, val);
    }

    /**
     * 部表示名（漢字）を取得する
     *
     * @return 部表示名（漢字）
     */
    public String getBUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ);
    }

    /**
     * 部表示名（漢字）を設定する
     *
     * @param val 部表示名（漢字）
     */
    public void setBUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ, val);
    }

    /**
     * 旧取引先コードを取得する
     *
     * @return 旧取引先コード
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.KYUTRCD);
    }

    /**
     * 旧取引先コードを設定する
     *
     * @param val 旧取引先コード
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.KYUTRCD, val);
    }

}
