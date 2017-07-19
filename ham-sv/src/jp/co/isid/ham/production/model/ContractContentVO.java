package jp.co.isid.ham.production.model;

import jp.co.isid.nj.model.AbstractModel;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;

/**
 * <P>
 * 契約情報登録登録ボタン押下時取得データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/18 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractContentVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public ContractContentVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new ContentMaterialVO();
    }

    /**
     * 契約期間(From)を取得する
     *
     * @return 契約期間(From)
     */
    public String getDATEFROM() {
        return (String) get(Tbj16ContractInfo.DATEFROM);
    }

    /**
     * 契約期間(From)を設定する
     *
     * @param val 契約期間(From)
     */
    public void setDATEFROM(String val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * 契約期間(To)を設定する
     *
     * @param val 契約期間(To)
     */
    public void setDATETO(String val) {
        set(Tbj16ContractInfo.DATETO, val);
    }

    /**
     * 契約期間(To)を取得する
     *
     * @return 契約期間(To)
     */
    public String getDATETO() {
        return (String) get(Tbj16ContractInfo.DATETO);
    }

    /**
     * 人名、アーティストを設定する
     *
     * @param val 人名、アーティスト
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * 人名、アーティストを取得する
     *
     * @return 人名、アーティスト
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * 楽曲を設定する
     *
     * @param val 楽曲
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * 楽曲を取得する
     *
     * @return 楽曲
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void getCMCD(String val) {
        set(Tbj17Content.CMCD, val);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj16ContractInfo.DELFLG, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj16ContractInfo.DELFLG);
    }

    /**
     * 契約種類(コンテンツテーブル)を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj17Content.CTRTKBN);
    }

    /**
     * 契約種類(コンテンツテーブル)を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj17Content.CTRTKBN, val);
    }
    /**
     * 契約種類(契約情報テーブル)を取得する
     *
     * @return 契約種類
     */
    public String getCONTRACTCTRTKBN() {
        return (String) get(Tbj16ContractInfo.CTRTKBN);
    }

    /**
     * 契約種類(契約情報テーブル)を設定する
     *
     * @param val 契約種類
     */
    public void setCONTRACTCTRTKBN(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * 契約コード(コンテンツテーブル)を取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj17Content.CTRTNO);
    }

    /**
     * 契約コード(コンテンツテーブル)を設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj17Content.CTRTNO, val);
    }

    /**
     * 契約コード(契約情報テーブル)を取得する
     *
     * @return 契約コード
     */
    public String getCONTRACTCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * 契約コード(契約情報テーブル)を設定する
     *
     * @param val 契約コード
     */
    public void setCONTRACTCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }
}
