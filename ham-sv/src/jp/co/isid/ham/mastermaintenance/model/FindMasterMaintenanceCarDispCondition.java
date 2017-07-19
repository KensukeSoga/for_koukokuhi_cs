package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj04KeiretsuCondition;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj13CarOutCtrlCondition;

/**
 * <P>
 * 車種表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /** 系列マスタ検索条件 */
    private Mbj04KeiretsuCondition _conditionSeries;

    /** 担当者マスタ検索条件 */
    private Mbj02UserCondition _conditionUser;

    /** 車種出力設定マスタ検索条件 */
    private Mbj13CarOutCtrlCondition _conditionCarOutControl;

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
     * 系列マスタ検索条件を設定します
     * @param data セットする _conditionSeries
     */
    public void setConditionSeries(Mbj04KeiretsuCondition data)
    {
        _conditionSeries = data;
    }

    /**
     * 系列マスタ検索条件を取得します
     * @return _conditionSeries
     */
    public Mbj04KeiretsuCondition getConditionSeries()
    {
        return _conditionSeries;
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
     * 車種出力設定マスタ検索条件を設定します
     * @param data セットする _conditionCarOutControl
     */
    public void setConditionCarOutControl(Mbj13CarOutCtrlCondition data)
    {
        _conditionCarOutControl = data;
    }

    /**
     * 車種出力設定マスタ検索条件を取得します
     * @return _conditionCarOutControl
     */
    public Mbj13CarOutCtrlCondition getConditionCarOutControl()
    {
        return _conditionCarOutControl;
    }

}
