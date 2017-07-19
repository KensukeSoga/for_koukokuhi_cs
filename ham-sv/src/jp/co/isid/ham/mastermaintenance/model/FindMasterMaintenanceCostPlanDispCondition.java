package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj48HmUserCondition;
import jp.co.isid.ham.common.model.Mbj49MediaProductionCondition;

/**
 * <P>
 * 費用企画No表示情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCostPlanDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 費用企画No検索条件 */
    private Mbj09HiyouCondition _conditionCostPlan = null;
    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar = null;
    /** 媒体マスタ検索条件 */
    private Mbj03MediaCondition _conditionMedia = null;
    /** コードマスタ検索条件リスト */
    private List<Mbj12CodeCondition> _conditionListCode = null;

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /** HM担当者マスタ検索条件 */
    private Mbj48HmUserCondition _conditionHmUser = null;
    /** 媒体(制作)マスタ検索条件 */
    private Mbj49MediaProductionCondition _conditionMediaProduction = null;
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /**
     * 費用企画No検索条件を設定します
     * @param val セットする _conditionCostPlan
     */
    public void setConditionCostPlan(Mbj09HiyouCondition val) {
        _conditionCostPlan = val;
    }

    /**
     * 費用企画No検索条件を取得します
     * @return _conditionCostPlan
     */
    public Mbj09HiyouCondition getConditionCostPlan() {
        return _conditionCostPlan;
    }

    /**
     * 車種マスタ検索条件を設定します
     * @param data セットする _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition val) {
        _conditionCar = val;
    }

    /**
     * 車種マスタ検索条件を取得します
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar() {
        return _conditionCar;
    }

    /**
     * 媒体マスタ検索条件を設定します
     * @param data セットする _conditionMedia
     */
    public void setConditionMedia(Mbj03MediaCondition val) {
        _conditionMedia = val;
    }

    /**
     * 媒体マスタ検索条件を取得します
     * @return _conditionMedia
     */
    public Mbj03MediaCondition getConditionMedia() {
        return _conditionMedia;
    }

    /**
     * コードマスタ検索条件リストを設定します
     * @param data セットする _conditionListCode
     */
    public void setConditionListCode(List<Mbj12CodeCondition> val) {
        _conditionListCode = val;
    }

    /**
     * コードマスタ検索条件リストを取得します
     * @return _conditionListCode
     */
    public List<Mbj12CodeCondition> getConditionListCode() {
        return _conditionListCode;
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM担当者マスタ検索条件を取得する
     * @return Mbj48HmUserCondition HM担当者マスタ検索条件
     */
    public Mbj48HmUserCondition getConditionHmUser() {
        return _conditionHmUser;
    }

    /**
     * HM担当者マスタ検索条件を設定する
     * @param val Mbj48HmUserCondition HM担当者マスタ検索条件
     */
    public void setConditionHmUser(Mbj48HmUserCondition val) {
        _conditionHmUser = val;
    }

    /**
     * 媒体(制作)マスタ検索条件を取得する
     * @return Mbj49MediaProductionCondition 媒体(制作)マスタ検索条件
     */
    public Mbj49MediaProductionCondition getConditionMediaProduction() {
        return _conditionMediaProduction;
    }

    /**
     * 媒体(制作)マスタ検索条件を設定する
     * @param val Mbj49MediaProductionCondition 媒体(制作)マスタ検索条件
     */
    public void setConditionMediaProduction(Mbj49MediaProductionCondition val) {
        _conditionMediaProduction = val;
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

}
