package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj04KeiretsuCondition;

/**
 * <P>
 * 系列表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 神山)<BR>
 * </P>
 * @author 神山
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceSeriesDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 系列マスタ検索条件 */
    private Mbj04KeiretsuCondition _conditionSeries = null;

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

}
