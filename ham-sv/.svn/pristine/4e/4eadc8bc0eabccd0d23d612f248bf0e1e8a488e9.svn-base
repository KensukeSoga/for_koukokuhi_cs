package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;

/**
 * <P>
 * 請求先グループ表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDemandGroupDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 請求先グループマスタ検索条件 */
    private Mbj26BillGroupCondition _conditionDemandGroup;

    /** HC部門マスタ検索条件 */
    private Mbj06HcBumonCondition _conditionHCSection;

    /**
     * 請求先グループマスタ検索条件を設定します
     * @param data セットする _conditionDemandGroup
     */
    public void setConditionDemandGroup(Mbj26BillGroupCondition data)
    {
        _conditionDemandGroup = data;
    }

    /**
     * 請求先グループマスタ検索条件を取得します
     * @return _conditionDemandGroup
     */
    public Mbj26BillGroupCondition getConditionDemandGroup()
    {
        return _conditionDemandGroup;
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
