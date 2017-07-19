package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj30InputTntCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;

/**
 * <P>
 * 入力担当表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInputUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 入力担当マスタ検索条件 */
    private Mbj30InputTntCondition _conditionInputUser;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /**
     * 入力担当マスタ検索条件を設定します
     * @param data セットする _conditionInputUser
     */
    public void setConditionInputUser(Mbj30InputTntCondition data)
    {
        _conditionInputUser = data;
    }

    /**
     * 入力担当マスタ検索条件を取得します
     * @return _conditionInputUser
     */
    public Mbj30InputTntCondition getConditionInputUser()
    {
        return _conditionInputUser;
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

}
