package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj32DepartmentCondition;

/**
 * <P>
 * 部署表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDepartmentDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 部署マスタ検索条件 */
    private Mbj32DepartmentCondition _conditionDepartment = null;

    /** コードマスタ検索条件 */
    private Mbj12CodeCondition _conditionCode = null;

    /**
     * 部署マスタ検索条件を設定します
     * @param data セットする _conditionLock
     */
    public void setConditionDepartment(Mbj32DepartmentCondition data)
    {
        _conditionDepartment = data;
    }

    /**
     * 部署マスタ検索条件を取得します
     * @return _conditionLock
     */
    public Mbj32DepartmentCondition getConditionDepartment()
    {
        return _conditionDepartment;
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
