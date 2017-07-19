package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj44SecurityBaseCondition;

/**
 * <P>
 * 権限表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAuthorityDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 権限スプレッドCondition（車種） */
    private MasterMaintenanceAuthoritySpreadCondition _conditionCarAuthoritySpread = null;

    /** 権限スプレッドCondition（媒体） */
    private MasterMaintenanceAuthoritySpreadCondition _conditionMediaAuthoritySpread = null;

    /** セキュリティスプレッドCondition */
    private MasterMaintenanceSecuritySpreadCondition _conditionSecuritySpread = null;

    /** セキュリティベースCondition */
    private Mbj44SecurityBaseCondition _conditionSecurityBase = null;

    /** 担当者マスタ検索条件 */
    private Mbj02UserCondition _conditionUser;

    /**
     * 権限スプレッドCondition（車種）を設定します
     * @param data セットする _conditionCarAuthoritySpread
     */
    public void setConditionCarAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition data)
    {
        _conditionCarAuthoritySpread = data;
    }

    /**
     * 権限スプレッドCondition（車種）を取得します
     * @return _conditionCarAuthoritySpread
     */
    public MasterMaintenanceAuthoritySpreadCondition getConditionCarAuthoritySpread()
    {
        return _conditionCarAuthoritySpread;
    }

    /**
     * 権限スプレッドCondition（媒体）を設定します
     * @param data セットする _conditionMediaAuthoritySpread
     */
    public void setConditionMediaAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition data)
    {
        _conditionMediaAuthoritySpread = data;
    }

    /**
     * 権限スプレッドCondition（媒体）を取得します
     * @return _conditionMediaAuthoritySpread
     */
    public MasterMaintenanceAuthoritySpreadCondition getConditionMediaAuthoritySpread()
    {
        return _conditionMediaAuthoritySpread;
    }

    /**
     * セキュリティスプレッドConditionを設定します
     * @param data セットする _conditionSecuritySpread
     */
    public void setConditionSecuritySpread(MasterMaintenanceSecuritySpreadCondition data)
    {
        _conditionSecuritySpread = data;
    }

    /**
     * セキュリティスプレッドConditionを取得します
     * @return _conditionSecuritySpread
     */
    public MasterMaintenanceSecuritySpreadCondition getConditionSecuritySpread()
    {
        return _conditionSecuritySpread;
    }

    /**
     * セキュリティベースConditionを設定します
     * @param data セットする _conditionSecurityBase
     */
    public void setConditionSecurityBase(Mbj44SecurityBaseCondition data)
    {
        _conditionSecurityBase = data;
    }

    /**
     * セキュリティベースConditionを取得します
     * @return _conditionSecurityBase
     */
    public Mbj44SecurityBaseCondition getConditionSecurityBase()
    {
        return _conditionSecurityBase;
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

}
