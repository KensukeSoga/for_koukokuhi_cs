package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * システム使用状況検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj01SysStsCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 種別 */
    private String _locktype = null;

    /** 過去ロック状態 */
    private String _lockdatests = null;

    /** データロック年月 */
    private Date _lockdate = null;

    /** データ更新日時 */
    private Date _upddate = null;

    /** データ更新者 */
    private String _updnm = null;

    /** 更新プログラム */
    private String _updapl = null;

    /** 更新担当者ID */
    private String _updid = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj01SysStsCondition() {
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getLocktype() {
        return _locktype;
    }

    /**
     * 種別を設定する
     *
     * @param locktype 種別
     */
    public void setLocktype(String locktype) {
        this._locktype = locktype;
    }

    /**
     * 過去ロック状態を取得する
     *
     * @return 過去ロック状態
     */
    public String getLockdatests() {
        return _lockdatests;
    }

    /**
     * 過去ロック状態を設定する
     *
     * @param lockdatests 過去ロック状態
     */
    public void setLockdatests(String lockdatests) {
        this._lockdatests = lockdatests;
    }

    /**
     * データロック年月を取得する
     *
     * @return データロック年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getLockdate() {
        return _lockdate;
    }

    /**
     * データロック年月を設定する
     *
     * @param lockdate データロック年月
     */
    public void setLockdate(Date lockdate) {
        this._lockdate = lockdate;
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * データ更新日時を設定する
     *
     * @param upddate データ更新日時
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * データ更新者を設定する
     *
     * @param updnm データ更新者
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * 更新プログラムを設定する
     *
     * @param updapl 更新プログラム
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param updid 更新担当者ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
