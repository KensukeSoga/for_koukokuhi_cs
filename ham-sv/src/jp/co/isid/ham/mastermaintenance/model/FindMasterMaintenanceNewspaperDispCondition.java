package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj47NewspaperCondition;
import jp.co.isid.ham.common.model.FindContactRequestCondition;

/**
 * <P>
 * 新聞マスタ表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/17 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceNewspaperDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 新聞マスタ検索条件 */
    private Mbj47NewspaperCondition _conditionNewspaper;

    /** 雑媒体マスタCondition */
    private MasterMaintenanceMEU20MSMZBTCondition _conditionMEU20MSMZBT;

    /** 依頼先Condition */
    private FindContactRequestCondition _conditionFindContactRequest;

    /**
     * 新聞マスタ検索条件を設定します
     * @param data セットする _conditionNewspaper
     */
    public void setConditionNewspaper(Mbj47NewspaperCondition data)
    {
        _conditionNewspaper = data;
    }

    /**
     * 新聞マスタ検索条件を取得します
     * @return _conditionNewspaper
     */
    public Mbj47NewspaperCondition getConditionNewspaper()
    {
        return _conditionNewspaper;
    }

    /**
     * 雑媒体マスタConditionを設定します
     * @param data セットする _conditionMEU20MSMZBT
     */
    public void setConditionMEU20MSMZBT(MasterMaintenanceMEU20MSMZBTCondition data)
    {
        _conditionMEU20MSMZBT = data;
    }

    /**
     * 雑媒体マスタConditionを取得します
     * @return _conditionMEU20MSMZBT
     */
    public MasterMaintenanceMEU20MSMZBTCondition getConditionMEU20MSMZBT()
    {
        return _conditionMEU20MSMZBT;
    }

    /**
     * 依頼先Conditionを設定します
     * @param data セットする _conditionFindContactRequest
     */
    public void setConditionFindContactRequest(FindContactRequestCondition data)
    {
        _conditionFindContactRequest = data;
    }

    /**
     * 依頼先Conditionを取得します
     * @return _conditionFindContactRequest
     */
    public FindContactRequestCondition getConditionFindContactRequest()
    {
        return _conditionFindContactRequest;
    }

}
