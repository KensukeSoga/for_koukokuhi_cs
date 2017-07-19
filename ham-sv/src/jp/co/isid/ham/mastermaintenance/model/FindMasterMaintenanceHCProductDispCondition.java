package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;

/**
 * <P>
 * HC商品表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCProductDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC商品スプレッドCondition */
    private MasterMaintenanceHCProductSpreadCondition _conditionHCProductSpread;

    /** HC部門マスタ検索条件 */
    private Mbj06HcBumonCondition _conditionHCSection;

    /** コードマスタ検索条件 */
    private Mbj12CodeCondition _conditionCode = null;

    /**
     * HC商品スプレッドConditionを設定します
     * @param data セットする _conditionHCProductSpread
     */
    public void setConditionHCProductSpread(MasterMaintenanceHCProductSpreadCondition data)
    {
        _conditionHCProductSpread = data;
    }

    /**
     * HC商品スプレッドConditionを取得します
     * @return _conditionHCProductSpread
     */
    public MasterMaintenanceHCProductSpreadCondition getConditionHCProductSpread()
    {
        return _conditionHCProductSpread;
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

    /**
     * コードマスタ検索条件を設定します
     * @param data セットする _conditionLock
     */
    public void setConditionCode(Mbj12CodeCondition data)
    {
        _conditionCode = data;
    }

    /**
     * コードマスタ検索条件を取得します
     * @return _conditionLock
     */
    public Mbj12CodeCondition getConditionCode()
    {
        return _conditionCode;
    }

}
