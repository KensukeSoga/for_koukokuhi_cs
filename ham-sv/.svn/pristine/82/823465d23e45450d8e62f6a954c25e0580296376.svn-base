package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj14MediaOutCtrlCondition;

/**
 * <P>
 * 媒体表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体マスタ検索条件 */
    private Mbj03MediaCondition _conditionMedia;

    /** 担当者マスタ検索条件 */
    private Mbj02UserCondition _conditionUser;

    /** 媒体出力設定マスタ検索条件 */
    private Mbj14MediaOutCtrlCondition _conditionMediaOutControl;

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
     * 媒体出力設定マスタ検索条件を設定します
     * @param data セットする _conditionMediaOutControl
     */
    public void setConditionMediaOutControl(Mbj14MediaOutCtrlCondition data)
    {
        _conditionMediaOutControl = data;
    }

    /**
     * 媒体出力設定マスタ検索条件を取得します
     * @return _conditionMediaOutControl
     */
    public Mbj14MediaOutCtrlCondition getConditionMediaOutControl()
    {
        return _conditionMediaOutControl;
    }

}
