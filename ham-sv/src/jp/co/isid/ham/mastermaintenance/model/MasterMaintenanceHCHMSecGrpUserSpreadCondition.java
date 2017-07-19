package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * セキュリティグループユーザー(HC/HM)スプレッドデータCondition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceHCHMSecGrpUserSpreadCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;
}
