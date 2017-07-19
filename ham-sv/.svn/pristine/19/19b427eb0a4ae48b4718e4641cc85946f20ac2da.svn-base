package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Vbj01AccUserCondition;

/**
 * <P>
 * 個人情報View検索Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/08 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceAccUserCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 個人情報View検索条件リスト */
    private List<Vbj01AccUserCondition> _conditionListAccUser = null;

    /**
     * 個人情報View検索条件リストを取得します
     * @return _conditionListAccUser
     */
    public List<Vbj01AccUserCondition> getConditionListAccUser()
    {
        return _conditionListAccUser;
    }

    /**
     * 個人情報View検索条件リストを設定します
     * @param data セットする _conditionListAccUser
     */
    public void setConditionListAccUser(List<Vbj01AccUserCondition> data)
    {
        _conditionListAccUser = data;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

}
