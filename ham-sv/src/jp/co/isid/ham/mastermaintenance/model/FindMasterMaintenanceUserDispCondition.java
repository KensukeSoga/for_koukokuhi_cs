package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj34FunctionControlItemCondition;
import jp.co.isid.ham.common.model.Mbj39FunctionControlBaseCondition;
import jp.co.isid.ham.common.model.Mbj43SecurityItemCondition;
import jp.co.isid.ham.common.model.Mbj44SecurityBaseCondition;

/**
 * <P>
 * 担当者表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者スプレッドCondition */
    private MasterMaintenanceUserSpreadCondition _conditionUserSpread;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /** 媒体マスタ検索条件 */
    private Mbj03MediaCondition _conditionMedia;

    /** 機能制御項目マスタ検索条件 */
    private Mbj34FunctionControlItemCondition _conditionFunctionControlItem;

    /** 機能制御ベースマスタ検索条件 */
    private Mbj39FunctionControlBaseCondition _conditionFunctionControlBase;

    /** セキュリティ項目マスタ検索条件 */
    private Mbj43SecurityItemCondition _conditionSecurityItem;

    /** セキュリティベースマスタ検索条件 */
    private Mbj44SecurityBaseCondition _conditionSecurityBase;

    /** コードマスタ検索条件 */
    private Mbj12CodeCondition _conditionCode = null;

    /**
     * 担当者スプレッドConditionを設定します
     * @param data セットする _conditionUserSpread
     */
    public void setConditionUserSpread(MasterMaintenanceUserSpreadCondition data)
    {
        _conditionUserSpread = data;
    }

    /**
     * 担当者スプレッドConditionを取得します
     * @return _conditionUserSpread
     */
    public MasterMaintenanceUserSpreadCondition getConditionUserSpread()
    {
        return _conditionUserSpread;
    }

    /**
     * 車種マスタ検索条件を設定します
     * @param data セットする _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition data)
    {
        _conditionCar = data;
    }

    /**
     * 車種マスタ検索条件を取得します
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar()
    {
        return _conditionCar;
    }

    /**
     * 媒体マスタ検索条件を設定します
     * @param data セットする _conditionMedia
     */
    public void setConditionMedia(Mbj03MediaCondition data)
    {
        _conditionMedia = data;
    }

    /**
     * 媒体マスタ検索条件を取得します
     * @return _conditionMedia
     */
    public Mbj03MediaCondition getConditionMedia()
    {
        return _conditionMedia;
    }

    /**
     * 機能制御項目マスタ検索条件を設定します
     * @param data セットする _conditionFunctionControlItem
     */
    public void setConditionFunctionControlItem(Mbj34FunctionControlItemCondition data)
    {
        _conditionFunctionControlItem = data;
    }

    /**
     * 機能制御項目マスタ検索条件を取得します
     * @return _conditionFunctionControlItem
     */
    public Mbj34FunctionControlItemCondition getConditionFunctionControlItem()
    {
        return _conditionFunctionControlItem;
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

    /**
     * セキュリティ項目マスタ検索条件を設定します
     * @param data セットする _conditionSecurityItem
     */
    public void setConditionSecurityItem(Mbj43SecurityItemCondition data)
    {
        _conditionSecurityItem = data;
    }

    /**
     * セキュリティ項目マスタ検索条件を取得します
     * @return _conditionSecurityItem
     */
    public Mbj43SecurityItemCondition getConditionSecurityItem()
    {
        return _conditionSecurityItem;
    }

    /**
     * セキュリティベースマスタ検索条件を設定します
     * @param data セットする _conditionSecurityBase
     */
    public void setConditionSecurityBase(Mbj44SecurityBaseCondition data)
    {
        _conditionSecurityBase = data;
    }

    /**
     * セキュリティベースマスタ検索条件を取得します
     * @return _conditionSecurityBase
     */
    public Mbj44SecurityBaseCondition getConditionSecurityBase()
    {
        return _conditionSecurityBase;
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
