package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj35MediaPatternCondition;
import jp.co.isid.ham.common.model.Mbj36MediaPatternItemCondition;

/**
 * <P>
 * 媒体パターン表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaPatternDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体パターンマスタ検索条件 */
    private Mbj35MediaPatternCondition _conditionMediaPattern;

    /** 媒体パターン内容マスタ検索条件 */
    private Mbj36MediaPatternItemCondition _conditionMediaPatternItem;

    /** 雑媒体マスタCondition */
    private MasterMaintenanceMEU20MSMZBTCondition _conditionMEU20MSMZBT;

    /**
     * 媒体パターンマスタ検索条件を設定します
     * @param data セットする _conditionMediaPattern
     */
    public void setConditionMediaPattern(Mbj35MediaPatternCondition data)
    {
        _conditionMediaPattern = data;
    }

    /**
     * 媒体パターンマスタ検索条件を取得します
     * @return _conditionMediaPattern
     */
    public Mbj35MediaPatternCondition getConditionMediaPattern()
    {
        return _conditionMediaPattern;
    }

    /**
     * 媒体パターン内容マスタ検索条件を設定します
     * @param data セットする _conditionMediaPatternItem
     */
    public void setConditionMediaPatternItem(Mbj36MediaPatternItemCondition data)
    {
        _conditionMediaPatternItem = data;
    }

    /**
     * 媒体パターン内容マスタ検索条件を取得します
     * @return _conditionMediaPatternItem
     */
    public Mbj36MediaPatternItemCondition getConditionMediaPatternItem()
    {
        return _conditionMediaPatternItem;
    }

    /**
     * 雑媒体マスタConditionを設定します
     * @param data セットする _conditionMEU20MSMZBT
     */
    public void setConditionMEU20MSMZBT(MasterMaintenanceMEU20MSMZBTCondition data)
    {
        _conditionMEU20MSMZBT = data;
    }

    /**
     * 雑媒体マスタConditionを取得します
     * @return _conditionMEU20MSMZBT
     */
    public MasterMaintenanceMEU20MSMZBTCondition getConditionMEU20MSMZBT()
    {
        return _conditionMEU20MSMZBT;
    }

}
