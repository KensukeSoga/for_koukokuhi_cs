package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj41AlertDispControlCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;

/**
 * <P>
 * アラート表示制御表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAlertDispControlDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** アラート表示制御マスタ検索条件 */
    private Mbj41AlertDispControlCondition _conditionAlertDispControl;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /** 担当者マスタ検索条件 */
    private Mbj02UserCondition _conditionUser;

    /** コードマスタ検索条件リスト */
    private List<Mbj12CodeCondition> _conditionListCode = null;

    /**
     * アラート表示制御マスタConditionを設定します
     * @param data セットする _conditionAlertDispControl
     */
    public void setConditionAlertDispControl(Mbj41AlertDispControlCondition data)
    {
        _conditionAlertDispControl = data;
    }

    /**
     * アラート表示制御マスタConditionを取得します
     * @return _conditionAlertDispControl
     */
    public Mbj41AlertDispControlCondition getConditionAlertDispControl()
    {
        return _conditionAlertDispControl;
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
     * コードマスタ検索条件リストを設定します
     * @param data セットする _conditionListCode
     */
    public void setConditionListCode(List<Mbj12CodeCondition> data)
    {
        _conditionListCode = data;
    }

    /**
     * コードマスタ検索条件リストを取得します
     * @return _conditionListCode
     */
    public List<Mbj12CodeCondition> getConditionListCode()
    {
        return _conditionListCode;
    }

}
