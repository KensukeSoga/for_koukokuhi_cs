package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj05CarCondition;


/**
 * <P>
 * 車種担当(素材)表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserSozaiDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種担当スプレッドCondition */
    private MasterMaintenanceCarUserSozaiSpreadCondition _conditionCarUserSozaiSpread = null;
    /** 車種マスタ検索条件 */
    private Mbj05CarCondition _conditionCar = null;
    /** セキュリティグループユーザー(HC/HM)スプレッドCondition */
    private MasterMaintenanceHCHMSecGrpUserSpreadCondition _conditionHCHMSecGrpUserSpread = null;

    /**
     * 車種担当(素材)スプレッドConditionを設定します
     * @param data セットする _conditionCarUserSpread
     */
    public void setConditionCarUserSozaiSpread(MasterMaintenanceCarUserSozaiSpreadCondition data)
    {
        _conditionCarUserSozaiSpread = data;
    }

    /**
     * 車種担当(素材)スプレッドConditionを取得します
     * @return _conditionCarUserSpread
     */
    public MasterMaintenanceCarUserSozaiSpreadCondition getConditionCarUserSozaiSpread()
    {
        return _conditionCarUserSozaiSpread;
    }

    /**
     * 車種マスタ検索条件を設定します
     * @param data セットする _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition data) {
        _conditionCar = data;
    }

    /**
     * 車種マスタ検索条件を取得します
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar() {
        return _conditionCar;
    }

    /**
     * セキュリティグループユーザー(HC/HM)スプレッドConditionを設定します
     * @param data セットする _conditionHCHMSecGrpUserSpread
     */
    public void setConditionHCHMSecGrpUserSpread(MasterMaintenanceHCHMSecGrpUserSpreadCondition data) {
        _conditionHCHMSecGrpUserSpread = data;
    }

    /**
     * セキュリティグループユーザー(HC/HM)スプレッドConditionを取得します
     * @return _conditionHCHMSecGrpUserSpread
     */
    public MasterMaintenanceHCHMSecGrpUserSpreadCondition getConditionHCHMSecGrpUserSpread() {
        return _conditionHCHMSecGrpUserSpread;
    }
}
