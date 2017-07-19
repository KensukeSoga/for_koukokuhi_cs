package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �l���View�\�����Condition�i�܂ތ����j
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/08 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispLikeCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �l���View�܂ތ���Condition */
    private MasterMaintenanceAccUserLikeCondition _likeConditionAccUser;

    /**
     * �l���View�܂ތ���Condition��ݒ肵�܂�
     * @param data �Z�b�g���� _likeConditionAccUser
     */
    public void setLikeConditionAccUser(MasterMaintenanceAccUserLikeCondition data)
    {
        _likeConditionAccUser = data;
    }

    /**
     * �l���View�܂ތ���Condition���擾���܂�
     * @return _likeConditionAccUser
     */
    public MasterMaintenanceAccUserLikeCondition getLikeConditionAccUser()
    {
        return _likeConditionAccUser;
    }

}
