package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 経理組織展開テーブル表示情報検索Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/02 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMEU07SIKKRSPRDDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 経理組織展開テーブル検索条件 */
    private MasterMaintenanceMEU07SIKKRSPRDCondition _conditionMEU07SIKKRSPRD = null;

    /**
     * 経理組織展開テーブル検索条件を設定します
     * @param data セットする _conditionListMEU07SIKKRSPRD
     */
    public void setConditionMEU07SIKKRSPRD(MasterMaintenanceMEU07SIKKRSPRDCondition data)
    {
        _conditionMEU07SIKKRSPRD = data;
    }

    /**
     * 経理組織展開テーブル検索条件を取得します
     * @return _conditionListMEU07SIKKRSPRD
     */
    public MasterMaintenanceMEU07SIKKRSPRDCondition getConditionMEU07SIKKRSPRD()
    {
        return _conditionMEU07SIKKRSPRD;
    }

}
