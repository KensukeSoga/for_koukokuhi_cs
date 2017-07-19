package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj48HmUserCondition;

/**
 * <P>
 * HM担当者表示情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHMUserDispCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HM担当者マスタ検索条件 */
    private Mbj48HmUserCondition _conditionHMUser;
    /** コードマスタ検索条件 */
    private Mbj12CodeCondition _conditionCode;

    /**
     * HM担当者マスタ検索条件を設定する
     * @param cond Mbj48HmUserCondition HM担当者マスタ検索条件
     */
    public void setConditionHMUser(Mbj48HmUserCondition cond) {
        _conditionHMUser = cond;
    }

    /**
     * HM担当者マスタ検索条件を取得する
     * @return Mbj48HmUserCondition HM担当者マスタ検索条件
     */
    public Mbj48HmUserCondition getConditionHMUser() {
        return _conditionHMUser;
    }

    /**
     * コードマスタ検索条件を取得する
     * @param cond Mbj12CodeCondition コードマスタ検索条件
     */
    public void setConditionCode(Mbj12CodeCondition cond) {
        _conditionCode = cond;
    }

    /**
     * コードマスタ検索条件を設定する
     * @return Mbj12CodeCondition コードマスタ検索条件
     */
    public Mbj12CodeCondition getConditionCode() {
        return _conditionCode;
    }

}
