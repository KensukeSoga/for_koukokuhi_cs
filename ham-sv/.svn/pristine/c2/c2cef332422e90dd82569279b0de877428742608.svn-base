package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj20CarCategoryCondition;

/**
 * <P>
 * 車種カテゴリ表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarCategoryDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種カテゴリマスタ検索条件 */
    private Mbj20CarCategoryCondition _conditionCarCategory;

    /**
     * 車種カテゴリマスタ検索条件を設定します
     * @param data セットする _conditionCarCategory
     */
    public void setConditionCarCategory(Mbj20CarCategoryCondition data)
    {
        _conditionCarCategory = data;
    }

    /**
     * 車種カテゴリマスタ検索条件を取得します
     * @return _conditionCarCategory
     */
    public Mbj20CarCategoryCondition getConditionCarCategory()
    {
        return _conditionCarCategory;
    }

}
