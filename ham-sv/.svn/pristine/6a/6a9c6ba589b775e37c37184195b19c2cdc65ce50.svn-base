package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 車種担当表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種担当スプレッドCondition */
    private MasterMaintenanceCarUserSpreadCondition _conditionCarUserSpread;

    /**
     * 車種担当スプレッドConditionを設定します
     * @param data セットする _conditionCarUserSpread
     */
    public void setConditionCarUserSpread(MasterMaintenanceCarUserSpreadCondition data)
    {
        _conditionCarUserSpread = data;
    }

    /**
     * 車種担当スプレッドConditionを取得します
     * @return _conditionCarUserSpread
     */
    public MasterMaintenanceCarUserSpreadCondition getConditionCarUserSpread()
    {
        return _conditionCarUserSpread;
    }

}
