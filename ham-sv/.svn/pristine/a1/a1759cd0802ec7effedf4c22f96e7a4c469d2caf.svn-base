package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoCondition;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * MasterForm表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMasterFormDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 機能制御情報Condition */
    private FunctionControlInfoCondition _conditionFunctionControlInfo = null;

    /** セキュリティ情報Condition */
    private SecurityInfoCondition _conditionSecurityInfo = null;

    /**
     * 機能制御情報Conditionを設定します
     * @param data セットする _conditionFunctionControlInfo
     */
    public void setConditionFunctionControlInfo(FunctionControlInfoCondition data)
    {
        _conditionFunctionControlInfo = data;
    }

    /**
     * 機能制御情報Conditionを取得します
     * @return _conditionFunctionControlInfo
     */
    public FunctionControlInfoCondition getConditionFunctionControlInfo()
    {
        return _conditionFunctionControlInfo;
    }

    /**
     * セキュリティ情報Conditionを設定します
     * @param data セットする _conditionSecurityInfo
     */
    public void setConditionSecurityInfo(SecurityInfoCondition data)
    {
        _conditionSecurityInfo = data;
    }

    /**
     * セキュリティ情報Conditionを取得します
     * @return _conditionSecurityInfo
     */
    public SecurityInfoCondition getConditionSecurityInfo()
    {
        return _conditionSecurityInfo;
    }

}
