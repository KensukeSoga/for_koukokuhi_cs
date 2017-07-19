package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj27MediaProductCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;
import jp.co.isid.ham.common.model.Mbj08HcProductCondition;

/**
 * <P>
 * 媒体・商品紐付表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaProductDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体・商品紐付マスタ検索条件 */
    private Mbj27MediaProductCondition _conditionMediaProduct;

    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar;

    /** 媒体マスタ検索条件 */
    private Mbj03MediaCondition _conditionMedia;

    /** HC部門マスタ検索条件 */
    private Mbj06HcBumonCondition _conditionHCSection;

    /** HC商品マスタ検索条件 */
    private Mbj08HcProductCondition _conditionHCProduct;

    /**
     * 媒体・商品紐付マスタ検索条件を設定します
     * @param data セットする _conditionMediaProduct
     */
    public void setConditionMediaProduct(Mbj27MediaProductCondition data)
    {
        _conditionMediaProduct = data;
    }

    /**
     * 媒体・商品紐付マスタ検索条件を取得します
     * @return _conditionMediaProduct
     */
    public Mbj27MediaProductCondition getConditionMediaProduct()
    {
        return _conditionMediaProduct;
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
     * HC部門マスタ検索条件を設定します
     * @param data セットする _conditionHCSection
     */
    public void setConditionHCSection(Mbj06HcBumonCondition data)
    {
        _conditionHCSection = data;
    }

    /**
     * HC部門マスタ検索条件を取得します
     * @return _conditionHCSection
     */
    public Mbj06HcBumonCondition getConditionHCSection()
    {
        return _conditionHCSection;
    }

    /**
     * HC商品マスタ検索条件を設定します
     * @param data セットする _conditionHCProduct
     */
    public void setConditionHCProduct(Mbj08HcProductCondition data)
    {
        _conditionHCProduct = data;
    }

    /**
     * HC商品マスタ検索条件を取得します
     * @return _conditionHCProduct
     */
    public Mbj08HcProductCondition getConditionHCProduct()
    {
        return _conditionHCProduct;
    }

}
