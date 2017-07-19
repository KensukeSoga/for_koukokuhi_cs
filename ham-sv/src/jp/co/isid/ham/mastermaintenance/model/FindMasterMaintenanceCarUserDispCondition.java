package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �Ԏ�S���\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �Ԏ�S���X�v���b�hCondition */
    private MasterMaintenanceCarUserSpreadCondition _conditionCarUserSpread;

    /**
     * �Ԏ�S���X�v���b�hCondition��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionCarUserSpread
     */
    public void setConditionCarUserSpread(MasterMaintenanceCarUserSpreadCondition data)
    {
        _conditionCarUserSpread = data;
    }

    /**
     * �Ԏ�S���X�v���b�hCondition���擾���܂�
     * @return _conditionCarUserSpread
     */
    public MasterMaintenanceCarUserSpreadCondition getConditionCarUserSpread()
    {
        return _conditionCarUserSpread;
    }

}
