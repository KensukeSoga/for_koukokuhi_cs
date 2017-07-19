package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj22CategoryContentCondition;
import jp.co.isid.ham.common.model.Mbj20CarCategoryCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;

/**
 * <P>
 * 車種カテゴリ紐付表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarCategoryContentDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種カテゴリ紐付マスタ検索条件 */
    private Mbj22CategoryContentCondition _conditionCarCategoryContent;

    /** 車種カテゴリマスタ検索条件 */
    private Mbj20CarCategoryCondition _conditionCarCategory;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /**
     * 車種カテゴリ紐付マスタ検索条件を設定します
     * @param data セットする _conditionCarCategoryContent
     */
    public void setConditionCarCategoryContent(Mbj22CategoryContentCondition data)
    {
        _conditionCarCategoryContent = data;
    }

    /**
     * 車種カテゴリ紐付マスタ検索条件を取得します
     * @return _conditionCarCategoryContent
     */
    public Mbj22CategoryContentCondition getConditionCarCategoryContent()
    {
        return _conditionCarCategoryContent;
    }

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

    /**
     * 車種マスタ検索条件を設定します
     * @param data セットする _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition data)
    {
        _conditionCar = data;
    }

    /**
     * 車種マスタ検索条件を取得します
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar()
    {
        return _conditionCar;
    }


}
