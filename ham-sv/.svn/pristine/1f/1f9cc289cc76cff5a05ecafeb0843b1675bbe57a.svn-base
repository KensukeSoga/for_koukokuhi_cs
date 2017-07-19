package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj31InformationCondition;

/**
 * <P>
 * インフォメーション表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInformationDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** インフォメーションマスタ検索条件 */
    private Mbj31InformationCondition _conditionInformation;

    /**
     * インフォメーションマスタ検索条件を設定します
     * @param data セットする _conditionInformation
     */
    public void setConditionInformation(Mbj31InformationCondition data)
    {
        _conditionInformation = data;
    }

    /**
     * インフォメーションマスタ検索条件を取得します
     * @return _conditionInformation
     */
    public Mbj31InformationCondition getConditionInformation()
    {
        return _conditionInformation;
    }

}
