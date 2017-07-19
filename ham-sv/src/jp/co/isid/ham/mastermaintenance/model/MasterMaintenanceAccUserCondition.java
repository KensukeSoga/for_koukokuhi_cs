package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Vbj01AccUserCondition;

/**
 * <P>
 * �l���View����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/08 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceAccUserCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �l���View�����������X�g */
    private List<Vbj01AccUserCondition> _conditionListAccUser = null;

    /**
     * �l���View�����������X�g���擾���܂�
     * @return _conditionListAccUser
     */
    public List<Vbj01AccUserCondition> getConditionListAccUser()
    {
        return _conditionListAccUser;
    }

    /**
     * �l���View�����������X�g��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionListAccUser
     */
    public void setConditionListAccUser(List<Vbj01AccUserCondition> data)
    {
        _conditionListAccUser = data;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

}
