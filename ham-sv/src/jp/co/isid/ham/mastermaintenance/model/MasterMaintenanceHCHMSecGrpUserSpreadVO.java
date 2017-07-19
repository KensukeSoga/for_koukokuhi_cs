package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * セキュリティグループユーザー(HC/HM)スプレッドデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")


public class MasterMaintenanceHCHMSecGrpUserSpreadVO extends AbstractModel
{
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceHCHMSecGrpUserSpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceHCHMSecGrpUserSpreadVO();
    }

    /**
     * ユーザーIDを取得する
     *
     * @return ユーザーID
     */
    public String getUSERID()
    {
        return (String) get(T_TransactionSecurity.USERID);
    }

    /**
     * ユーザーIDを設定する
     *
     * @param val ユーザーID
     */
    public void setUSERID(String val)
    {
        set(T_TransactionSecurity.USERID, val);
    }

    /**
     * トランザクション番号を取得する
     *
     * @return トランザクション番号
     */
    public String getTRANSACTIONNO()
    {
        return (String) get(T_TransactionSecurity.TRANSACTIONNO);
    }

    /**
     * トランザクション番号を設定する
     *
     * @param val トランザクション番号
     */
    public void setTRANSACTIONNO(String val)
    {
        set(T_TransactionSecurity.TRANSACTIONNO, val);
    }

    /**
     * ユーザー名(漢字)を取得する
     *
     * @return ユーザー名(漢字)
     */
    public String getUSERNAME()
    {
        return (String) get(T_UserInfo.USERNAME);
    }

    /**
     * ユーザー名(漢字)を設定する
     *
     * @param val ユーザー名(漢字)
     */
    public void setUSERNAME(String val)
    {
        set(T_UserInfo.USERNAME, val);
    }

    /**
     * セキュリティグループコードを取得する
     *
     * @return セキュリティグループコード
     */
    public String getSECURITYGROUPCODE()
    {
        return (String) get(T_SecurityGroup.SECURITYGROUPCODE);
    }

    /**
     * セキュリティグループコードを設定する
     *
     * @param val セキュリティグループコード
     */
    public void setSECURITYGROUPCODE(String val)
    {
        set(T_SecurityGroup.SECURITYGROUPCODE, val);
    }

    /**
     * グループ名称を取得する
     *
     * @return グループ名称
     */
    public String getSECURITYGROUPNAME()
    {
        return (String) get(T_SecurityGroup.SECURITYGROUPNAME);
    }

    /**
     * グループ名称を設定する
     *
     * @param val グループ名称
     */
    public void setSECURITYGROUPNAME(String val)
    {
        set(T_SecurityGroup.SECURITYGROUPNAME, val);
    }

}
