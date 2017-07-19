package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj07HcUserCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;

/**
 * <P>
 * HC担当者表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC担当者マスタ検索条件 */
    private Mbj07HcUserCondition _conditionHCUser;

    /** HC部門マスタ検索条件 */
    private Mbj06HcBumonCondition _conditionHCSection;

    /**
     * HC担当者マスタ検索条件を設定します
     * @param data セットする _conditionHCUser
     */
    public void setConditionHCUser(Mbj07HcUserCondition data)
    {
        _conditionHCUser = data;
    }

    /**
     * HC担当者マスタ検索条件を取得します
     * @return _conditionHCUser
     */
    public Mbj07HcUserCondition getConditionHCUser()
    {
        return _conditionHCUser;
    }

    /**
     * HC部門マスタ検索条件を設定します
     * @param data セットする _conditionHCSection
     */
    public void setConditionHCSection(Mbj06HcBumonCondition data)
    {
        _conditionHCSection = data;
    }

    /**
     * HC部門マスタ検索条件を取得します
     * @return _conditionHCSection
     */
    public Mbj06HcBumonCondition getConditionHCSection()
    {
        return _conditionHCSection;
    }

}
