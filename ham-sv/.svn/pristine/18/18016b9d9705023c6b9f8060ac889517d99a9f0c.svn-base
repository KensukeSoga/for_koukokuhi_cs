package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj40AlertMailAddressCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;

/**
 * <P>
 * メール配信表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/07 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAlertMailAddressDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** メール配信マスタ検索条件 */
    private Mbj40AlertMailAddressCondition _conditionAlertMailAddress;

    /** コードマスタ検索条件リスト */
    private List<Mbj12CodeCondition> _conditionListCode = null;

    /**
     * メール配信マスタConditionを設定します
     * @param data セットする _conditionAlertMailAddress
     */
    public void setConditionAlertMailAddress(Mbj40AlertMailAddressCondition data)
    {
        _conditionAlertMailAddress = data;
    }

    /**
     * メール配信マスタConditionを取得します
     * @return _conditionAlertMailAddress
     */
    public Mbj40AlertMailAddressCondition getConditionAlertMailAddress()
    {
        return _conditionAlertMailAddress;
    }

    /**
     * コードマスタ検索条件リストを設定します
     * @param data セットする _conditionListCode
     */
    public void setConditionListCode(List<Mbj12CodeCondition> data)
    {
        _conditionListCode = data;
    }

    /**
     * コードマスタ検索条件リストを取得します
     * @return _conditionListCode
     */
    public List<Mbj12CodeCondition> getConditionListCode()
    {
        return _conditionListCode;
    }

}
