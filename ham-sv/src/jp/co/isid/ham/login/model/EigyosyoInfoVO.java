package jp.co.isid.ham.login.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu00Sik;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.nj.model.AbstractModel;

public class EigyosyoInfoVO extends AbstractModel {

	private static final long serialVersionUID = 7561739022049341403L;

	/**
     * 新規インスタンスを構築します
     */
    public EigyosyoInfoVO() {
    }

    /**
     * 新規インスタンスを構築します
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new EigyosyoInfoVO();
    }

    /**
     * 内容(漢字)を取得する
     * @return 内容(漢字)
     */
    public String getNaiyJ() {
        return (String) get(RepaVbjaMeu29Cc.NAIYJ);
    }

    /**
     * 内容(漢字)を設定する
     * @param val 内容(漢字)
     */
    public void setNaiyJ(String val) {
        set(RepaVbjaMeu29Cc.NAIYJ, val);
    }

    /**
     * 営業所コードを取得する
     * @return 営業所コード
     */
    public String getEgsyoCd() {
        return (String) get(RepaVbjaMeu00Sik.EGSYOCD);
    }

    /**
     * 営業所コードを設定する
     * @param val 営業所コード
     */
    public void setEgsyoCd(String val) {
        set(RepaVbjaMeu00Sik.EGSYOCD, val);
    }

    /**
     * 上位組織コードを取得する
     * @return 上位組織コード
     */
    public String getJSikCd() {
        return (String) get(RepaVbjaMeu00Sik.JSIKCD);
    }

    /**
     * 上位組織コードを設定する
     * @param val 上位組織コード
     */
    public void setJSikCd(String val) {
        set(RepaVbjaMeu00Sik.JSIKCD, val);
    }

    /**
     * 階層コードを取得する
     * @return 階層コード
     */
    public String getKaisoCd() {
        return (String) get(RepaVbjaMeu00Sik.KAISOCD);
    }

    /**
     * 階層コードを設定する
     * @param val 階層コード
     */
    public void setKaisoCd(String val) {
        set(RepaVbjaMeu00Sik.KAISOCD, val);
    }

}
