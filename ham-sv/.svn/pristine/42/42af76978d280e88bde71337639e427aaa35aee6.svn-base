package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.T_MaterialHistory;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * TVCM素材一覧最終更新者検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・HDX対応(2016/03/07 K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindTVCMMaterialListLastUpdateUserVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindTVCMMaterialListLastUpdateUserVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindTVCMMaterialListLastUpdateUserVO();
    }

    /**
     * 更新日時を取得する
     *
     * @return 更新日時
     */
    public Date getUPDATEDATE() {
        return (Date) get(T_MaterialHistory.UPDATEDATE);
    }

    /**
     * 更新日時を設定する
     *
     * @param val 更新日時
     */
    public void setUPDATEDATE(Date val) {
        set(T_MaterialHistory.UPDATEDATE, val);
    }

    /**
     * 更新者ユーザIDを取得する
     *
     * @return 更新者ユーザID
     */
    public String getUPDATEUSERID() {
        return (String) get(T_MaterialHistory.UPDATEUSERID);
    }

    /**
     * 更新者ユーザIDを設定する
     *
     * @param val 更新者ユーザID
     */
    public void setUPDATEUSERID(String val) {
        set(T_MaterialHistory.UPDATEUSERID, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELETEFLG() {
        return (String) get(T_MaterialHistory.DELETEFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELETEFLG(String val) {
        set(T_MaterialHistory.DELETEFLG, val);
    }

    /**
     * カレントフラグを取得する
     *
     * @return カレントフラグ
     */
    public String getCURRENTFLG() {
        return (String) get(T_MaterialHistory.CURRENTFLG);
    }

    /**
     * カレントフラグを設定する
     *
     * @param val カレントフラグ
     */
    public void setCURRENTFLG(String val) {
        set(T_MaterialHistory.CURRENTFLG, val);
    }

    /**
     * ステータスを取得する
     *
     * @return ステータス
     */
    public String getSTATUS() {
        return (String) get(T_MaterialHistory.STATUS);
    }

    /**
     * ステータスを設定する
     *
     * @param val ステータス
     */
    public void setSTATUS(String val) {
        set(T_MaterialHistory.STATUS, val);
    }

    /**
     * 車種コードを取得する
     *
     * @return 車種コード
     */
    public String getDCARCD() {
        return (String) get(T_MaterialHistory.DCARCD);
    }

    /**
     * 車種コードを設定する
     *
     * @param val 車種コード
     */
    public void setDCARCD(String val) {
        set(T_MaterialHistory.DCARCD, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    public Date getSOZAIYM() {
        return (Date) get(T_MaterialHistory.SOZAIYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSOZAIYM(Date val) {
        set(T_MaterialHistory.SOZAIYM, val);
    }

    /**
     * 作成区分を取得する
     *
     * @return 作成区分
     */
    public String getRECKBN() {
        return (String) get(T_MaterialHistory.RECKBN);
    }

    /**
     * 作成区分を設定する
     *
     * @param val 作成区分
     */
    public void setRECKBN(String val) {
        set(T_MaterialHistory.RECKBN, val);
    }

    /**
     * 作成番号を取得する
     *
     * @return 作成番号
     */
    public String getRECNO() {
        return (String) get(T_MaterialHistory.RECNO);
    }

    /**
     * 作成番号を設定する
     *
     * @param val 作成番号
     */
    public void setRECNO(String val) {
        set(T_MaterialHistory.RECNO, val);
    }

    /**
     * ユーザー名(漢字)を取得する
     *
     * @return ユーザー名(漢字)
     */
    public String getUSERNAME() {
        return (String) get(T_UserInfo.USERNAME);
    }

    /**
     * ユーザー名(漢字)を設定する
     *
     * @param val ユーザー名(漢字)
     */
    public void setUSERNAME(String val) {
        set(T_UserInfo.USERNAME, val);
    }

    /**
     * グループ名称を取得する
     *
     * @return グループ名称
     */
    public String getSECURITYGROUPNAME() {
        return (String) get(T_SecurityGroup.SECURITYGROUPNAME);
    }

    /**
     * グループ名称を設定する
     *
     * @param val グループ名称
     */
    public void setSECURITYGROUPNAME(String val) {
        set(T_SecurityGroup.SECURITYGROUPNAME, val);
    }

}
