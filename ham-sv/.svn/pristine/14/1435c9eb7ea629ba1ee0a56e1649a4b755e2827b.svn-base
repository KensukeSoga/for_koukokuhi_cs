package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 個人情報View表示情報検索Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/08 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 個人情報View検索条件 */
    private MasterMaintenanceAccUserCondition _conditionAccUser = null;

    /**
     * 個人情報View検索条件を設定します
     * @param data セットする _conditionListAccUser
     */
    public void setConditionAccUser(MasterMaintenanceAccUserCondition data)
    {
        _conditionAccUser = data;
    }

    /**
     * 個人情報View検索条件を取得します
     * @return _conditionListAccUser
     */
    public MasterMaintenanceAccUserCondition getConditionAccUser()
    {
        return _conditionAccUser;
    }

}
