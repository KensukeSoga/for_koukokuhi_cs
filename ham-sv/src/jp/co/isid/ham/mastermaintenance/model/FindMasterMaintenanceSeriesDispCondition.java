package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj04KeiretsuCondition;

/**
 * <P>
 * �n��\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06 �_�R)<BR>
 * </P>
 * @author �_�R
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceSeriesDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �n��}�X�^�������� */
    private Mbj04KeiretsuCondition _conditionSeries = null;

    /**
     * �n��}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionSeries
     */
    public void setConditionSeries(Mbj04KeiretsuCondition data)
    {
        _conditionSeries = data;
    }

    /**
     * �n��}�X�^�����������擾���܂�
     * @return _conditionSeries
     */
    public Mbj04KeiretsuCondition getConditionSeries()
    {
        return _conditionSeries;
    }

}
