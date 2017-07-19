package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 個人情報View表示情報Condition（含む検索）
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/08 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispLikeCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 個人情報View含む検索Condition */
    private MasterMaintenanceAccUserLikeCondition _likeConditionAccUser;

    /**
     * 個人情報View含む検索Conditionを設定します
     * @param data セットする _likeConditionAccUser
     */
    public void setLikeConditionAccUser(MasterMaintenanceAccUserLikeCondition data)
    {
        _likeConditionAccUser = data;
    }

    /**
     * 個人情報View含む検索Conditionを取得します
     * @return _likeConditionAccUser
     */
    public MasterMaintenanceAccUserLikeCondition getLikeConditionAccUser()
    {
        return _likeConditionAccUser;
    }

}
