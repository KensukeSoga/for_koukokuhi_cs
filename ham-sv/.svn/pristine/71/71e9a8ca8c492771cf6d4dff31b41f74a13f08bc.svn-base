package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj39FunctionControlBaseCondition;

/**
 * <P>
 * 機能制御表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceFunctionControlDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 機能制御スプレッドCondition */
    private MasterMaintenanceFunctionControlSpreadCondition _conditionFunctionControlSpread;

    /** 担当者マスタ検索条件 */
    private Mbj02UserCondition _conditionUser;

    /** 機能制御ベースマスタ検索条件 */
    private Mbj39FunctionControlBaseCondition _conditionFunctionControlBase;

    /**
     * 機能制御スプレッドConditionを設定します
     * @param data セットする _conditionFunctionControlSpread
     */
    public void setConditionFunctionControlSpread(MasterMaintenanceFunctionControlSpreadCondition data)
    {
        _conditionFunctionControlSpread = data;
    }

    /**
     * 機能制御スプレッドConditionを取得します
     * @return _conditionFunctionControlSpread
     */
    public MasterMaintenanceFunctionControlSpreadCondition getConditionFunctionControlSpread()
    {
        return _conditionFunctionControlSpread;
    }

    /**
     * 担当者マスタ検索条件を設定します
     * @param data セットする _conditionUser
     */
    public void setConditionUser(Mbj02UserCondition data)
    {
        _conditionUser = data;
    }

    /**
     * 担当者マスタ検索条件を取得します
     * @return _conditionUser
     */
    public Mbj02UserCondition getConditionUser()
    {
        return _conditionUser;
    }

    /**
     * 機能制御ベースマスタ検索条件を設定します
     * @param data セットする _conditionFunctionControlBase
     */
    public void setConditionFunctionControlBase(Mbj39FunctionControlBaseCondition data)
    {
        _conditionFunctionControlBase = data;
    }

    /**
     * 機能制御ベースマスタ検索条件を取得します
     * @return _conditionFunctionControlBase
     */
    public Mbj39FunctionControlBaseCondition getConditionFunctionControlBase()
    {
        return _conditionFunctionControlBase;
    }

}
