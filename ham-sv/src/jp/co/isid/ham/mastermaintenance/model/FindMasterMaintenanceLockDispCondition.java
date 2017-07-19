package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj01SysStsCondition;

/**
 * <P>
 * 過去ロック表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceLockDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** システム使用状況検索条件 */
    private Mbj01SysStsCondition _conditionLock = null;

    /**
     * システム使用状況検索条件を設定します
     * @param data セットする _conditionLock
     */
    public void setConditionLock(Mbj01SysStsCondition data)
    {
        _conditionLock = data;
    }

    /**
     * システム使用状況検索条件を取得します
     * @return _conditionLock
     */
    public Mbj01SysStsCondition getConditionLock()
    {
        return _conditionLock;
    }

}
