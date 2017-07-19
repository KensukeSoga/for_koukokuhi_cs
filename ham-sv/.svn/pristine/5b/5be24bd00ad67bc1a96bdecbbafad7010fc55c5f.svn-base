package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種担当者VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class HCHMSecGrpUserVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * コンストラクタ
     */
    public HCHMSecGrpUserVO() {

    }
    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new HCHMSecGrpUserVO();
    }

    /**
     * トランザクション番号を取得する
     * @return
     */
    public String getTRANSACTIONNO() {
        return (String) get(T_TransactionSecurity.TRANSACTIONNO);
    }

    /**
     * トランザクション番号を設定する
     * @param val
     */
    public void setTRANSACTIONNO(String val) {
        set(T_TransactionSecurity.TRANSACTIONNO, val);
    }

    /**
     * ユーザー名(漢字)を取得する
     * @return
     */
    public String getUSERNAME() {
        return (String) get(T_UserInfo.USERNAME);
    }

    /**
     * ユーザー名(漢字)を設定する
     * @param val
     */
    public void setUSERNAME(String val) {
        set(T_UserInfo.USERNAME, val);
    }

    /**
     * セキュリティグループコードを取得する
     * @return
     */
    public String getSECURITYGROUPCODE() {
        return (String) get(T_SecurityGroup.SECURITYGROUPCODE);
    }

    /**
     * セキュリティグループコードを設定する
     * @param val
     */
    public void setSECURITYGROUPCODE(String val) {
        set(T_SecurityGroup.SECURITYGROUPCODE, val);
    }

    /**
     * 電通車種名を設定する
     * @param val
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 電通車種名を取得する
     * @return
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * コード名称を設定する
     * @param val
     */
    public void setCODENAME(String val) {
        set(Mbj12Code.CODENAME, val);
    }

    /**
     * コード名称を取得する
     * @return
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }
}