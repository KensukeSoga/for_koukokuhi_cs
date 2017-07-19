package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj01SysSts;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * システム使用状況VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj01SysStsVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj01SysStsVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj01SysStsVO();
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getLOCKTYPE() {
        return (String) get(Mbj01SysSts.LOCKTYPE);
    }

    /**
     * 種別を設定する
     *
     * @param val 種別
     */
    public void setLOCKTYPE(String val) {
        set(Mbj01SysSts.LOCKTYPE, val);
    }

    /**
     * 過去ロック状態を取得する
     *
     * @return 過去ロック状態
     */
    public String getLOCKDATESTS() {
        return (String) get(Mbj01SysSts.LOCKDATESTS);
    }

    /**
     * 過去ロック状態を設定する
     *
     * @param val 過去ロック状態
     */
    public void setLOCKDATESTS(String val) {
        set(Mbj01SysSts.LOCKDATESTS, val);
    }

    /**
     * データロック年月を取得する
     *
     * @return データロック年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getLOCKDATE() {
        return (Date) get(Mbj01SysSts.LOCKDATE);
    }

    /**
     * データロック年月を設定する
     *
     * @param val データロック年月
     */
    public void setLOCKDATE(Date val) {
        set(Mbj01SysSts.LOCKDATE, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj01SysSts.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj01SysSts.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj01SysSts.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj01SysSts.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj01SysSts.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj01SysSts.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj01SysSts.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj01SysSts.UPDID, val);
    }

}
