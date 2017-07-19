package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj29SetteiKykCondition;

/**
 * <P>
 * �ݒ�Ǖ\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceEstablishmentOfficeDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �ݒ�ǃ}�X�^�������� */
    private Mbj29SetteiKykCondition _conditionEstablishmentOffice;

    /**
     * �ݒ�ǃ}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionEstablishmentOffice
     */
    public void setConditionEstablishmentOffice(Mbj29SetteiKykCondition data)
    {
        _conditionEstablishmentOffice = data;
    }

    /**
     * �ݒ�ǃ}�X�^�����������擾���܂�
     * @return _conditionEstablishmentOffice
     */
    public Mbj29SetteiKykCondition getConditionEstablishmentOffice()
    {
        return _conditionEstablishmentOffice;
    }

}
